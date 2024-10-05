extends Node2D

var text_scene = preload("res://prefebs/TextPanel/TextPanel.tscn")

func _ready() -> void:
	var text_scene_instance = text_scene.instantiate()
	text_scene_instance.label_text = "[center]编辑剧本尚未完成。"
	$Main.add_child(text_scene_instance)

func _on_texture_button_pressed() -> void:
	SignalBus.emit_signal("return_start")
