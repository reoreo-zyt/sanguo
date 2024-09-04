extends Control

@export var message_text = ""

func _ready() -> void:
	SignalBus.connect("show_message", _on_show_message)

func set_tex():
	if(Global.text_message.has(Global.current_message_title)):
		$Panel/RichTextLabel.text = Global.text_message[Global.current_message_title]
		$".".show()

func _on_show_message(isShow):
	if(isShow):
		set_tex()
	else:
		pass
		#TODO: bug 会出现无法关闭情况	
		#$".".hide()


func _on_button_pressed() -> void:
	$".".hide()
