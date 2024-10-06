extends Node2D

func _on_texture_button_pressed() -> void:
	SignalBus.emit_signal("return_start")

func _on_verify_pressed() -> void:
	SignalBus.emit_signal("change_scenes_to_select_character")

func _on_dectation_pressed() -> void:
	_on_texture_button_pressed()
