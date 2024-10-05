extends Panel

@export var label_text = ""

func _ready() -> void:
	$RichTextLabel.text = label_text
