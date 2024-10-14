extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var character_message = preload("res://prefebs/Characters/Characters.tscn")
var text_panel = preload("res://prefebs/TextPanel/TextPanel.tscn")
var character_slice = preload("res://scenes/BattleMain/character_item.tscn")

var character_slice_instance_cach = {}
var self_troop = [43, 3, 15]
var emery_troop = [501, 502, 503, 504, 505, 506]
var character_message_instance_save = null

func _ready() -> void:
	SignalBus.connect("battle_send_character_location", _on_battle_send_character_location)

	# 界面
	var character_attr_instance = character_attr.instantiate()
	character_attr_instance.name_id = int(Global.cur_hero_id)
	character_attr_instance.is_show_attr = true
	character_attr_instance.is_fold = true
	$CanvasLayer/Main/Control.add_child(character_attr_instance)

	#var cell_position = Vector2(0, 0)
	## 获取位置的TileSet
	#var texture_id = $TileMapLayer.get_cell_source_id(cell_position)

	var character_message_instance = character_message.instantiate()
	character_message_instance.position = Vector2(-58, 550)
	character_message_instance.jiangs = self_troop
	character_message_instance.is_show_city = false
	$CanvasLayer/Main/Control.add_child(character_message_instance)
	character_message_instance_save = character_message_instance
	SignalBus.emit_signal("open_characters_list", 0)

func _on_battle_send_character_location(character_id, event_id) -> void:
	var color = Color(1, 0.5, 0.3, 0.838)
	var colors:PackedColorArray = [color, color, color, color, color, color, color]
	var character_slice_instance = character_slice.instantiate()

	if(character_slice_instance_cach):
		for cach in character_slice_instance_cach:
			if(cach == character_id):
				if(character_slice_instance_cach[character_id]):
					character_slice_instance_cach[character_id].queue_free()
					character_slice_instance_cach[character_id] = null

	if(event_id == 0):
		return
	var position = Global.battle_event[event_id].position
	character_slice_instance.width = Tool.calc_px(position)[0]
	character_slice_instance.height = Tool.calc_px(position)[1]
	character_slice_instance.length = 116
	character_slice_instance.is_member = true
	character_slice_instance.character_id = character_id
	character_slice_instance.colors = colors
	character_slice_instance.control_position = Vector2(Tool.calc_px(position)[0] - 238 / 2, Tool.calc_px(position)[1] - 208 / 2)
	$Characters.add_child(character_slice_instance)
	character_slice_instance_cach[character_id] = character_slice_instance
	SignalBus.emit_signal("battle_set_select_disabled", character_id, event_id)

func _on_next_pressed() -> void:
	var is_set_location = true
	for troop in self_troop:
		if(!Global.characters[troop].battle_location):
			is_set_location = true
	if(!is_set_location):
		var TextPanel = text_panel.instantiate()
		TextPanel.label_text = "[center]请先配置初始位置"
		$CanvasLayer/Main/PopupPanel.add_child(TextPanel)
		$CanvasLayer/Main/PopupPanel.popup()
	else:
		$CanvasLayer/Main/Next.hide()
		$CanvasLayer/Main/TextureRect/RichTextLabel.text = "战斗阶段"
		$PrePanel.hide()
		$CharacterPlace.hide()
		character_message_instance_save.queue_free()
		
		var position = [
			Vector2i(8, 0),
			Vector2i(8, 1),
			Vector2i(8, 2),
			Vector2i(8, 3),
			Vector2i(8, 4),
			Vector2i(9, 0),
			Vector2i(9, 1),
			Vector2i(9, 2),
			Vector2i(9, 3),
			Vector2i(9, 4),
		]
		
		var color = Color(1, 0.5, 0.3, 0.838)
		var colors:PackedColorArray = [color, color, color, color, color, color, color]
		# 绘制敌方武将
		for troop in emery_troop:
			var i = 0
			var troop_position = position[i]
			i += 1
			var character_emery_instance = character_slice.instantiate()
			character_emery_instance.width = Tool.calc_px(troop_position)[0]
			character_emery_instance.height = Tool.calc_px(troop_position)[1]
			character_emery_instance.length = 116
			character_emery_instance.is_member = true
			character_emery_instance.character_id = troop
			character_emery_instance.colors = colors
			character_emery_instance.control_position = Vector2(Tool.calc_px(troop_position)[0] - 238 / 2, Tool.calc_px(troop_position)[1] - 208 / 2)
			$Characters.add_child(character_emery_instance)
