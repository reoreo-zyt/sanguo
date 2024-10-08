extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var button = preload("res://scenes/GameMain/button.tscn")
var character_message = preload("res://prefebs/Characters/Characters.tscn")

func _ready() -> void:
	var character_attr_instance = character_attr.instantiate()
	character_attr_instance.name_id = int(Global.cur_hero_id)
	character_attr_instance.is_show_attr = true
	character_attr_instance.is_fold = true
	$CanvasLayer/Main/Control.add_child(character_attr_instance)
	
	var button_instance = button.instantiate()
	button_instance.position = Vector2(0, 52)
	$CanvasLayer/Main/Control.add_child(button_instance)
	
	var character_message_instance = character_message.instantiate()
	character_message_instance.position = Vector2(-58, 550)
	$CanvasLayer/Main/Control.add_child(character_message_instance)
	character_message_instance.hide()
