extends Panel

@export var hero_id = 288

func _on_button_pressed() -> void:
	SignalBus.emit_signal("hide_city_hero_info")
	Global.curr_city_character = 0
	$".".hide()
