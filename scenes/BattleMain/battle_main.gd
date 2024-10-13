extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var character_message = preload("res://prefebs/Characters/Characters.tscn")
var character_slice = preload("res://scenes/BattleMain/character_item.tscn")

var character_slice_instance_cach = {}

func _ready() -> void:
	SignalBus.connect("battle_send_character_location", _on_battle_send_character_location)

	var self_troop = [43, 3, 15, 51, 22, 44]

	# 界面
	var character_attr_instance = character_attr.instantiate()
	character_attr_instance.name_id = int(Global.cur_hero_id)
	character_attr_instance.is_show_attr = true
	character_attr_instance.is_fold = true
	$CanvasLayer/Main/Control.add_child(character_attr_instance)

	var cell_position = Vector2(0, 0)
	# 获取位置的TileSet
	var texture_id = $TileMapLayer.get_cell_source_id(cell_position)

	var character_message_instance = character_message.instantiate()
	character_message_instance.position = Vector2(-58, 550)
	character_message_instance.jiangs = self_troop
	character_message_instance.is_show_city = false
	$CanvasLayer/Main/Control.add_child(character_message_instance)
	SignalBus.emit_signal("open_characters_list", 0)

func _on_battle_send_character_location(character_id, event_id) -> void:
	print(character_id, event_id)
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
	SignalBus.emit_signal("battle_set_select_disabled", event_id)
