extends Panel

@export var name_id = 200

func _ready() -> void:
	_on_show_city_hero_info()

func _on_show_city_hero_info():
	var nameId = name_id
	var character = Global.characters[nameId]
	var attrs = character.attrs
	$Name/RichTextLabel.text = set_message_name(character.name)
	$Head.texture = load(character.headImg)
	$Wu/RichTextLabel.text = set_message_name(Global.weapons[character.weaponId].name)
	$Fang/RichTextLabel.text = set_message_name(Global.armors[character.armorId].name)
	$Skill/RichTextLabel.text = get_skill_desc(nameId)
	
func set_message_name(text):
	return "[color=#91c2d5][u][url]"+  text +"[/url][/u][/color]"

func get_skill_desc(nameId):
	var skillsDesc = ""
	var skillIds = Global.characters[nameId].skillIds
	for i in Global.characters[nameId].skillIds:
		if(Global.skills[i].type == "normal"):
			skillsDesc += "[color=#91c2d5][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
		if(Global.skills[i].type == "self"):
			skillsDesc += "[color=#ffe219][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
		if(Global.skills[i].type == "self_bad"):
			skillsDesc += "[color=#ff5437][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
	return skillsDesc
