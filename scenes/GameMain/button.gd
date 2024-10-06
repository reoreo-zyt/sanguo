extends TextureButton

func _on_pressed() -> void:
	SignalBus.emit_signal("change_citys_label")
