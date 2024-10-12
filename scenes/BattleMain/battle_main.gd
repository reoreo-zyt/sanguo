extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var character_message = preload("res://prefebs/Characters/Characters.tscn")

func _ready() -> void:
	var self_troop = [43, 3, 15]

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
