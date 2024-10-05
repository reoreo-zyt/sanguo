extends Panel

@export var is_show_attr = false
@export var name_id = 0

var radar_node = null
var rader_scene = preload("res://prefebs/CharacterAttr/RadarChartStats.tscn")

func _ready() -> void:
	if(is_show_attr):
		radar_node = rader_scene.instantiate()
		var character = Global.characters_select[int(name_id)]
		var attrs = character.attrs
		$Head.texture = load(character.headImg)
		$Name/RichTextLabel.text = Global.set_message_name(character.name)
		$Wu/RichTextLabel.text = Global.set_message_name(Global.weapons[character.weaponId].name)
		$Fang/RichTextLabel.text = Global.set_message_name(Global.armors[character.armorId].name)
		$Skill/RichTextLabel.text = Global.get_skill_desc(name_id)
		$Ma/RichTextLabel.text = "[center]暂无"
		radar_node.position = Vector2(623, 180)
		radar_node.scale = Vector2(2, 2)
		radar_node.stats = [attrs["command"], attrs["force"], attrs["intelligence"], attrs["politics"], attrs["morality"], attrs["curr_physical_strength"], attrs["speed"], attrs["level"]]
		$".".add_child(radar_node)
