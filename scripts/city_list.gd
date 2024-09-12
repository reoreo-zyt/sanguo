extends Control

var cityValue = preload("res://scenes/city_value.tscn")
var city_instances = []

func _ready() -> void:
	SignalBus.connect("change_battle_city", _on_change_battle_city)

func get_city_list():
	if(city_instances.size()):
		for city_insatnce in city_instances:
			city_insatnce.queue_free()
	city_instances = []
	# 获取主公在的那个城市，计算其他城市到这个城市的距离
	var cur_city = Global.characters[Global.cur_character].cityId
	for city in Global.citys:
		var city_insatnce = cityValue.instantiate()
		city_insatnce.city_name = Global.set_name_text(Global.citys[city].name)
		city_insatnce.hero_name = Global.set_name_text(str(Global.characters_select[int(Global.citys[city].ownerId)].name))
		city_insatnce.distance =  Global.set_text(str(calc_distance(Vector2(Global.citys[city].position_x, Global.citys[city].position_y), Vector2(Global.citys[cur_city].position_x, Global.citys[cur_city].position_y))) + "公里")
		city_insatnce.time = Global.set_text(str(calc_get_day(calc_distance(Vector2(Global.citys[city].position_x, Global.citys[city].position_y), Vector2(Global.citys[cur_city].position_x, Global.citys[cur_city].position_y)))) + "天")
		city_instances.append(city_insatnce)
		if(calc_get_day(calc_distance(Vector2(Global.citys[city].position_x, Global.citys[city].position_y), Vector2(Global.citys[cur_city].position_x, Global.citys[cur_city].position_y))) <= 10):
			$ScrollContainer/MarginContainer/VBoxContainer.add_child(city_insatnce)

func _on_change_battle_city():
	get_city_list()

func calc_distance(location1, location2):
	# 武威到天水距离是 572 公里
	return location1.distance_to(location2) * 6.77278

func calc_get_day(value):
	return ceil(value / 80)
