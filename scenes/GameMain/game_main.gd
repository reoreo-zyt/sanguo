extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var button = preload("res://scenes/GameMain/button.tscn")

func _ready() -> void:
	var character_attr_instance = character_attr.instantiate()
	character_attr_instance.name_id = int(Global.cur_hero_id)
	character_attr_instance.is_show_attr = true
	character_attr_instance.is_fold = true
	$CanvasLayer/Main/Control.add_child(character_attr_instance)
	
	var button_instance = button.instantiate()
	button_instance.position = Vector2(0, 52)
	$CanvasLayer/Main/Control.add_child(button_instance)
