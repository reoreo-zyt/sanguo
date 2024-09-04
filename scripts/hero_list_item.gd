extends HBoxContainer

@export var hero_id = 100

func _ready() -> void:
	var characters = Global.characters
	$NameTextLabel.text = Global.set_name_text(characters[hero_id].name)
	if(int(characters[hero_id].attrs.command) <= int(50)):
		$BingTextLabel.text =  Global.set_text(1000)
	else:
		$BingTextLabel.text =  Global.set_text(1000 + ((int(characters[hero_id].attrs.command) - 50) * 50))
	$ZhongTextLabel.text = Global.set_text(characters[hero_id].attrs.lorty)
	$TiTextLabel.text =  Global.set_text(characters[hero_id].attrs.curr_physical_strength)
	$ShiTextLabel.text = "[center]" + str(characters[hero_id].work)
