extends Panel

@export var is_show_attr = false
@export var name_id = 0

var radar_node = null
var rader_scene = preload("res://prefebs/CharacterAttr/RadarChartStats.tscn")
@export var is_fold = false

func _ready() -> void:
	SignalBus.connect("reset_character_attr", _on_reset_character_attr)
	set_attr()

func _on_fold_pressed() -> void:
	is_fold = !is_fold
	if(is_fold):
		hide_ui()
	else:
		show_ui()

func hide_ui():
	$BG.hide()
	$Message.hide()
	if(is_show_attr and radar_node):
		$RadarChartStats.hide()
	$Fold.position = Vector2(0, 0)

func show_ui():
	$BG.show()
	$Message.show()
	if(is_show_attr and radar_node):
		$RadarChartStats.show()
	$Fold.position = Vector2(1048, -32)

func calc_cost(p):
	if(p >= 90):
		return 0.3
	if(p >= 80):
		return 0.5
	if(p >= 70):
		return 0.8
	else:
		return 1

func set_attr():
	if(!name_id):
		return
	if(is_show_attr):
		if(radar_node):
			$".".remove_child(radar_node)
			radar_node = null
		radar_node = rader_scene.instantiate()
		var character = Global.characters[int(name_id)]
		var attrs = character.attrs
		$Message/Head.texture = load(character.headImg)
		$Message/Name/RichTextLabel.text = Global.set_message_name(character.name)
		$Message/Wu/RichTextLabel.text = Global.set_message_name(Global.weapons[character.weaponId].name)
		$Message/Fang/RichTextLabel.text = Global.set_message_name(Global.armors[character.armorId].name)
		$Message/Skill/RichTextLabel.text = Global.get_skill_desc(name_id)
		$Message/Ma/RichTextLabel.text = "[center]暂无"
		$Message/ZiYuan/Bing/RichTextLabel.text = Global.set_message_name(str(attrs.bing) + "兵")
		var cost_jin = round((attrs.bing / 100) * calc_cost(attrs.politics))
		var cost_liang = round((attrs.bing / 50) * calc_cost(attrs.politics))
		$Message/ZiYuan/Jin/RichTextLabel.text = Global.set_message_name(str(attrs.jin))
		$Message/ZiYuan/Liang/RichTextLabel.text = Global.set_message_name(str(attrs.liang))
		radar_node.position = Vector2(653, 280)
		radar_node.scale = Vector2(1.6, 1.6)
		$Message/Level.text = Global.set_message_name("LV " + str(attrs["level"]))
		radar_node.stats = [attrs["command"], attrs["force"], attrs["intelligence"], attrs["politics"], attrs["morality"], attrs["curr_physical_strength"], attrs["speed"], attrs["level"]]
		$Message/XingGe/RichTextLabel.text = Global.set_message_name(character.personalitiy_desc)
		$".".add_child(radar_node)
	if(is_fold):
		hide_ui()

func _on_reset_character_attr(id):
	name_id = id
	is_show_attr = true
	is_fold = false
	show_ui()
	set_attr()
