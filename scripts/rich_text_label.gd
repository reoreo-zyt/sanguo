extends RichTextLabel

func _on_meta_hover_started(meta: Variant) -> void:
	Global.current_message_title = meta
	SignalBus.emit_signal("show_message", true)

func _on_meta_hover_ended(meta: Variant) -> void:
	SignalBus.emit_signal("show_message", false)
