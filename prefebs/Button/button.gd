####
## 绑定对应事件，点击后触发
####

extends Node

@export var btn_text = ""
@export var btn_event = ""

func _ready() -> void:
	$TextureButton/RichTextLabel.text = btn_text

func _on_texture_button_pressed() -> void:
	SignalBus.emit_signal(btn_event)
