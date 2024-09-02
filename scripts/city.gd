extends Node

@onready var text = $Panel/RichTextLabel
@export var texture_path = "res://assets/texture/citys/1_1.png"
@export var text_name = ""
@export var character_number = 261
@export var city_code = ""
@export var color = "#d2dad8"

var show_text_ui = false

func _ready() -> void:
	$ColorRect.color = color

func _on_icon_pressed() -> void:
	Global.cur_city = city_code
	SignalBus.emit_signal("show_city_info", text_name, city_code)
	if(show_text_ui):
		show_text_ui = false
		$"../../CityMessage".hide()
	else:
		show_text_ui = true
		$"../../CityMessage".show()

func set_texture(texture_path: String) -> void:
	var texture := load(texture_path)
	if texture:
		text.texture = texture
	else:
		print("无法加载纹理: ", texture_path)
