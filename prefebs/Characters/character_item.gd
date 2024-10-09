extends TextureButton

@export var character_id = 0

func _ready() -> void:
	var character_attr = Global.characters[int(character_id)].attrs
	$HBoxContainer/Name.text = Global.set_name_text(Global.characters[int(character_id)].name)
	$HBoxContainer/Tong.text = Global.set_name_text(character_attr.command)
	$HBoxContainer/Wu.text = Global.set_name_text(character_attr.force)
	$HBoxContainer/Zhi.text = Global.set_name_text(character_attr.intelligence)
	$HBoxContainer/Zheng.text = Global.set_name_text(character_attr.politics)
	$HBoxContainer/Mei.text = Global.set_name_text(character_attr.morality)
	$HBoxContainer/Event.selected = Global.characters[int(character_id)].event_type
	$HBoxContainer/MaxBing.text = Global.set_name_text(character_attr.max_bing)
	$HBoxContainer/Bing.text = Global.set_name_text(character_attr.bing)

func _on_pressed() -> void:
	# 打开人物列表
	SignalBus.emit_signal("reset_character_attr", character_id)

func _on_event_item_selected(index: int) -> void:
	SignalBus.emit_signal("send_characters_event", character_id, index)
	Global.characters[int(character_id)].event_type = index
