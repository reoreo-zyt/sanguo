extends HBoxContainer

@export var name_text = ""
@export var num = 0
@export var name_id = 0
@export var color = ""
#@export var green_blue = false
#@export var green_red = false
#@export var blue_red = false
#@export var blue = 0
#@export var green = 0
#@export var red = 0

func _ready() -> void:
	$Name.text = name_text
	$CityText.text = str(num)
	$Name.name_id = name_id
	#$CityNum.material.set_shader_parameter("green_blue", green_blue)
	#$CityNum.material.set_shader_parameter("green_red", green_red)
	#$CityNum.material.set_shader_parameter("blue_red", blue_red)
	#$CityNum.material.set_shader_parameter("blue", blue)
	#$CityNum.material.set_shader_parameter("green", green)
	#$CityNum.material.set_shader_parameter("red", red)
	$ColorRect.color = color
