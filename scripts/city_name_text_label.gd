extends RichTextLabel

func _on_meta_clicked(meta: Variant) -> void:
	Global.cur_hero_id = $"..".hero_id
	SignalBus.emit_signal("show_city_hero_info")

func _on_meta_hover_started(meta: Variant) -> void:
	Global.current_message_title = meta
	SignalBus.emit_signal("show_message", true)

func _on_meta_hover_ended(meta: Variant) -> void:
	SignalBus.emit_signal("show_message", false)
