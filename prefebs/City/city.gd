extends Node

@onready var text = $Panel/RichTextLabel
@export var texture_path = "res://assets/texture/citys/1_1.png"
@export var text_name = ""
@export var character_number = 261
@export var city_code = ""
@export var color = "#d2dad8"

var is_hide_label = false

func _ready() -> void:
	SignalBus.connect("change_citys_label", _on_change_citys_label)
	SignalBus.connect("change_city_size", _on_change_city_size)
	$ColorRect.color = color
	$Panel/RichTextLabel.text = "[center]" + text_name

func show_message():
	SignalBus.emit_signal("show_city_info", text_name, city_code)
	$"../../CityMessage".show()

func _on_icon_pressed() -> void:
	if(!Global.is_press_select_button):
		return
	Global.cur_city = city_code
	if(character_number != Global.cur_character):
		#var message = messageScene.instantiate()
		if(Global.is_show_other_city_message):
			show_message()
			return
		#$".".add_child(message)
		#message.show_message("[color=#ffde66][center]此地非君主治所", Vector2(10, 10), message.Direction.Down, 1, 2)
		return
	show_message()

func set_texture(texture_path: String) -> void:
	var texture := load(texture_path)
	if texture:
		text.texture = texture
	else:
		print("无法加载纹理: ", texture_path)

func _on_change_citys_label():
	is_hide_label = !is_hide_label
	if(is_hide_label):
		$Panel.show()
	else:
		$Panel.hide()

func _on_change_city_size(zoom):
	$".".scale = Vector2(1 / zoom, 1 / zoom)
