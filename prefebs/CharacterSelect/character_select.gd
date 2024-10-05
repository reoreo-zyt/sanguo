extends VBoxContainer

var hero_list_item_scene = preload("res://prefebs/CharacterSelect/hero_select_item.tscn")

func _ready() -> void:
	for i in Global.characters_select:
		if(Global.characters_select[i].name == "无人占领城池"):
			continue
		else:
			var instance = hero_list_item_scene.instantiate()
			instance.name_text = "[center]" + Global.characters_select[i].name
			instance.color = Global.characters_select[i].color
			instance.name_id = Global.characters_select[i].id
			$ScrollContainer/VBoxContainer/HBoxContainer.add_child(instance)
