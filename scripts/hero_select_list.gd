extends VBoxContainer

var hero_list_item_scene = preload("res://scenes/hero_select_item.tscn")

func _ready() -> void:
	for i in Global.characters_select:
		if(Global.characters_select[i].name == "无人占领城池"):
			continue
		else:
			var instance = hero_list_item_scene.instantiate()
			instance.name_text = Global.characters_select[i].name
			instance.num = Global.characters_select[i].citys.size()
			instance.color = Global.characters_select[i].color
			instance.name_id = int(Global.characters_select[i].id)
			#instance.green_blue = Global.characters_select[i].city_material.green_blue
			#instance.green_red = Global.characters_select[i].city_material.green_red
			#instance.blue_red = Global.characters_select[i].city_material.blue_red
			#instance.blue = Global.characters_select[i].city_material.blue
			#instance.green = Global.characters_select[i].city_material.green
			#instance.red = Global.characters_select[i].city_material.red
			$ScrollContainer/VBoxContainer.add_child(instance)
