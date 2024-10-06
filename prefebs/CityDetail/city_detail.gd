extends Panel

var is_fold = false
var city_item = preload("res://prefebs/CityDetail/city_item.tscn")

var city_item_instances = []

func _ready() -> void:
	city_item_instances = []
	SignalBus.connect("recover_city_select", _on_recover_city_select)
	# 获取到所有城市
	for city_number in Global.characters_select[int(Global.cur_hero_id)].citys:
		var city_item_instance = city_item.instantiate()
		var city_name = Global.citys[city_number].name
		city_item_instance.city_name = city_name
		city_item_instance.city_id = city_number
		$Main/Panel/ScrollContainer/VBoxContainer.add_child(city_item_instance)
		city_item_instances.append(city_item_instance)

func _on_fold_pressed() -> void:
	is_fold = !is_fold
	if(is_fold):
		$BG.hide()
		$Main.hide()
		$Fold.position = Vector2(625, -34)
	else:
		$BG.show()
		$Main.show()
		$Fold.position = Vector2(-64, -34)

func _on_recover_city_select():
	# 更新下数据
	
	for city_item_instance in city_item_instances:
		if(Global.cur_city != city_item_instance.city_id):
			city_item_instance.recover_select = true
