extends Node

@onready var text = $Panel/RichTextLabel
@export var texture_path = "res://assets/texture/citys/1_1.png"
@export var text_name = ""
@export var character_number = 0

var show_text_ui = false

func _ready() -> void:
	text.text = "[color=#fff][u][url]" + text_name + "[/url][/u][/color]"
	var character_item = Global.characters_select[character_number]
	var city_material = character_item["city_material"]
	$Icon.material.set_shader_parameter("green_blue", city_material["green_blue"])
	$Icon.material.set_shader_parameter("green_red", city_material["green_red"])
	$Icon.material.set_shader_parameter("blue_red", city_material["blue_red"])
	$Icon.material.set_shader_parameter("blue", city_material["blue"])
	$Icon.material.set_shader_parameter("green", city_material["green"])
	$Icon.material.set_shader_parameter("red", city_material["red"])

func _on_icon_pressed() -> void:
	SignalBus.emit_signal("show_city_info", text_name)
	if(show_text_ui):
		show_text_ui = false
		# $Panel.hide()
		$"../../CityMessage".hide()
	else:
		show_text_ui = true
		# $Panel.show()
		$"../../CityMessage".show()

func set_texture(texture_path: String) -> void:
	var texture := load(texture_path)
	if texture:
		text.texture = texture
	else:
		print("无法加载纹理: ", texture_path)
