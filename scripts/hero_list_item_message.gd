extends HBoxContainer

@export var name_text = ""
@export var num = 0
@export var name_id = 0
@export var color = ""

func _ready() -> void:
	$Name.text = name_text
	$CityText.text = str(num)
	$Name.name_id = name_id
	$Panel/ColorRect.color = color
