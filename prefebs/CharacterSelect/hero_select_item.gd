extends TextureButton

@export var name_text = ""
@export var color = ""
@export var name_id = 0

func _ready() -> void:
	$RichTextLabel.text = name_text
	$ColorRect.color = color

func _on_pressed() -> void:
	SignalBus.emit_signal("get_name_id", name_id)
	SignalBus.emit_signal("change_character_attr")
	SignalBus.emit_signal("show_citys")

	$Panel.show()
	await get_tree().create_timer(0.5).timeout
	$Panel.hide()
