extends Control

var instances = []
var battle_city_select = preload("res://scenes/battle_city_select.tscn")

func _ready() -> void:
	SignalBus.connect("change_citys_selcet", _on_change_citys_selcet)
	
func _on_change_citys_selcet():
	if(instances.size()):
		for instance in instances:
			instance.queue_free()
		instances = []
	
	for city in Global.characters_select[Global.cur_character].citys:
		var instance = battle_city_select.instantiate()
		instance.city_name = Global.set_name_text(Global.citys[city].name)
		instance.city_id = city
		instances.append(instance)
		$ScrollContainer/HBoxContainer.add_child(instance)
