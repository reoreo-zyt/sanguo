extends Button

@export var name_id = 0

func _on_pressed() -> void:
	SignalBus.emit_signal("show_hero_info", name_id)
