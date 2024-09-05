extends ScrollContainer

@onready var vbContainer = $VBoxContainer

var hero_list_item = preload("res://scenes/hero_list_item.tscn")

func _ready() -> void:
	SignalBus.connect("show_city_info", _on_show_city_info)

func create_characters(textname, cityCode):
	var citys = Global.citys
	var characters = find_year_character(Global.characters, 189)
	
	Global.clear_children(vbContainer)

	for i in citys[cityCode].curent_jiang:
		var instance = hero_list_item.instantiate()
		instance.hero_id = i
		vbContainer.add_child(instance)

func _on_show_city_info(textname, cityCode):
	create_characters(textname, cityCode)

func find_year_character(char_objects, year):
	var new_character = {}
	for i in char_objects:
		if(i!=0):
			if(int(char_objects[i].work) <= year):
				new_character[i] = char_objects[i]
	return new_character
