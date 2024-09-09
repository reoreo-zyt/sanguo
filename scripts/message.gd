extends Control

@export var message_text = ""

func _ready() -> void:
	SignalBus.connect("show_message", _on_show_message)

func set_tex():
	if(Global.text_message.has(Global.current_message_title)):
		$PopupPanel/MarginContainer/RichTextLabel.text = Global.text_message[Global.current_message_title]
		$".".show()
		$PopupPanel.popup()

func _on_show_message(isShow):
	if(isShow):
		set_tex()
	else:
		pass
		#TODO: bug 会出现无法关闭情况	
		#$".".hide()

func _on_button_pressed() -> void:
	$".".hide()

func _on_rich_text_label_meta_clicked(meta: Variant) -> void:
	print(meta)
	if(Global.text_message.has(meta)):
		$PopupPanel/MarginContainer/RichTextLabel.text = Global.text_message[meta]
		$".".show()
		$PopupPanel.popup()
