extends Panel

@export var is_show_close = true

func _ready() -> void:
	if(is_show_close):
		$Button.show()
	else:
		$Button.hide()

func _on_button_pressed() -> void:
	SignalBus.emit_signal("hide_city_hero_info")
	$".".hide()
