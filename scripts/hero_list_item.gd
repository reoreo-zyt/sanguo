extends HBoxContainer

@export var hero_id = 100

func _ready() -> void:
	var characters = Global.characters
	$NameTextLabel.text = Global.set_name_text(characters[hero_id].name)
	if(int(characters[hero_id].attrs.command) <= int(50)):
		$BingTextLabel.text =  Global.set_text(1000)
	else:
		$BingTextLabel.text =  Global.set_text(characters[hero_id].attrs.bing)
	$ZhongTextLabel.text = Global.set_text(characters[hero_id].attrs.lorty)
	$TiTextLabel.text =  Global.set_text(characters[hero_id].attrs.curr_physical_strength)
	$ShiTextLabel.text = Global.set_text(characters[hero_id].attrs.command + characters[hero_id].attrs.force + characters[hero_id].attrs.intelligence + characters[hero_id].attrs.politics + characters[hero_id].attrs.morality)
