extends PanelContainer

var city_item_scene = preload("res://prefebs/City/City.tscn")
var name_id = 0
@export var is_select = true

func _ready() -> void:
	SignalBus.connect("show_citys", _on_show_citys)
	SignalBus.connect("get_name_id", _on_get_name_id)
	for i in Global.citys:
		var city_item_instace = city_item_scene.instantiate()
		city_item_instace.position = Vector2(Global.citys[i].position_x, Global.citys[i].position_y)
		city_item_instace.text_name = Global.citys[i].name
		city_item_instace.character_number = int(Global.citys[i].lordId)
		city_item_instace.city_code = i
		if(!Global.citys[i].ownerId == 0):
			city_item_instace.color = Global.characters_select[int(Global.citys[i].ownerId)].color
		$".".add_child(city_item_instace)
		if(is_select):
			city_item_instace.hide()

func _on_show_citys():
	var citys = $".".get_children()
	for city in citys:
		if(!city.character_number == name_id):
			city.hide()
		else:
			city.show()

func _on_get_name_id(id):
	name_id = int(id)
