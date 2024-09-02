extends ScrollContainer

@onready var vbContainer = $VBoxContainer

var hero_list_item = preload("res://scenes/hero_list_item.tscn")

func _ready() -> void:
	SignalBus.connect("show_city_info", _on_show_city_info)

func create_characters(textname, cityCode):
	var citys = Global.citys
	var characters = Global.characters
	
	Global.clear_children(vbContainer)
	
	print(cityCode, 'cityCode')
	for i in citys[cityCode].jiang:
		var instance = hero_list_item.instantiate()
		instance.hero_id = i
		vbContainer.add_child(instance)

func _on_show_city_info(textname, cityCode):
	create_characters(textname, cityCode)
