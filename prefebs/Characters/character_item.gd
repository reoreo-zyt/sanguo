extends TextureButton

@export var character_id = 0
@export var is_show_city = true

func _ready() -> void:
	var character_attr = Global.characters[int(character_id)].attrs
	$HBoxContainer/Name.text = Global.set_name_text(Global.characters[int(character_id)].name)
	$HBoxContainer/Tong.text = Global.set_name_text(character_attr.command)
	$HBoxContainer/Wu.text = Global.set_name_text(character_attr.force)
	$HBoxContainer/Zhi.text = Global.set_name_text(character_attr.intelligence)
	$HBoxContainer/Zheng.text = Global.set_name_text(character_attr.politics)
	$HBoxContainer/Mei.text = Global.set_name_text(character_attr.morality)
	$HBoxContainer/Event.selected = Global.characters[int(character_id)].event_type
	# 清空所有现有的选项
	$HBoxContainer/Event.clear()
	if(is_show_city):
		# 添加选项
		for event_id in Global.characters_event:
			$HBoxContainer/Event.add_item(Global.characters_event[event_id].name, event_id)
	else:
		var battle_event = {
			0: {
				"name": "暂未选择"
			},
			1: {
				"name": "(0, 0)"
			},
			2: {
				"name": "(0, 1)"
			},
			3: {
				"name": "(0, 2)"
			},
			4: {
				"name": "(0, 3)"
			},
			5: {
				"name": "(0, 4)"
			},
			6: {
				"name": "(1, 0)"
			},
			7: {
				"name": "(1, 1)"
			},
			8: {
				"name": "(1, 2)"
			},
			9: {
				"name": "(1, 3)"
			},
			10: {
				"name": "(1, 4)"
			}
		}
		for event_id in battle_event:
			$HBoxContainer/Event.add_item(battle_event[event_id].name, event_id)
	# 设置默认选中的选项（如果需要）
	$HBoxContainer/Event.selected = 0  # 默认选中第一个选项
	$HBoxContainer/MaxBing.text = Global.set_name_text(character_attr.max_bing)
	$HBoxContainer/Bing.text = Global.set_name_text(character_attr.bing)

func _on_pressed() -> void:
	# 打开人物列表
	SignalBus.emit_signal("reset_character_attr", character_id)

func _on_event_item_selected(index: int) -> void:
	SignalBus.emit_signal("send_characters_event", character_id, index)
	Global.characters[int(character_id)].event_type = index
