extends Node2D

var select_character = preload("res://prefebs/CharacterSelect/CharacterSelect.tscn")
var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")

var attr_node = null
var name_id = 0

func _ready() -> void:
	$Main/Menu.add_child(select_character.instantiate())
	attr_node = character_attr.instantiate()
	$Main/Menu/Character.add_child(attr_node)
	SignalBus.connect("change_character_attr", _on_change_character_attr)
	SignalBus.connect("get_name_id", _on_get_name_id)
	
func _on_texture_button_pressed() -> void:
	SignalBus.emit_signal("return_select")

func _on_change_character_attr():
	$Main/Menu/Character.remove_child(attr_node)
	attr_node = null
	attr_node = character_attr.instantiate()
	attr_node.is_show_attr = true
	attr_node.name_id = name_id
	$Main/Menu/Character.add_child(attr_node)

func _on_get_name_id(id):
	name_id = id

func _on_verify_pressed() -> void:
	Global.cur_hero_id = name_id
	SignalBus.emit_signal("game_main")

func _on_dectation_pressed() -> void:
	_on_texture_button_pressed()
