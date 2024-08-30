extends HBoxContainer

@export var hero_id = 100

func _ready() -> void:
	var characters = Global.characters
	$NameTextLabel.text = Global.set_name_text(characters[hero_id].name)
	$BingTextLabel.text =  Global.set_text(characters[hero_id].attrs.command * 30)
	$ZhongTextLabel.text = Global.set_text(characters[hero_id].attrs.lorty)
	$TiTextLabel.text =  Global.set_text(characters[hero_id].attrs.curr_physical_strength)
