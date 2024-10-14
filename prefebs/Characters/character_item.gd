extends TextureButton

@export var character_id = 0
@export var is_show_city = true

var last_event_id = 0

func _ready() -> void:
	Global.characters[int(character_id)].battle_location = null

	SignalBus.connect("battle_set_select_disabled", _on_battle_set_select_disabled)
	
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
		var battle_event = Global.battle_event
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
	SignalBus.emit_signal("battle_send_character_location", character_id, index)
	SignalBus.emit_signal("send_characters_event", character_id, index)
	Global.characters[int(character_id)].event_type = index

func _on_battle_set_select_disabled(character, event_id):
	if(character_id == character):
		# 存储位置
		Global.characters[int(character_id)].battle_location = Global.battle_event[event_id].position
		SignalBus.emit_signal("battle_focus_city", event_id)

	# TODO: 未实现禁用
	# 禁用当前
	$HBoxContainer/Event.set_item_disabled(event_id, true)
	if(last_event_id):
		Global.had_selectd_battle_location.remove_at(last_event_id)
	last_event_id = event_id
	# 当前缓存的禁用项
	if(Global.had_selectd_battle_location.has(event_id)):
		Global.had_selectd_battle_location.append(event_id)
	for battle_event_id in Global.battle_event:
		#$HBoxContainer/Event.set_item_disabled(battle_event_id, false)
		if(Global.had_selectd_battle_location.has(battle_event_id)):
			$HBoxContainer/Event.set_item_disabled(battle_event_id, true)
