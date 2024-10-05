extends PanelContainer

var city_item_scene = preload("res://prefebs/City/City.tscn")

func _ready() -> void:
	for i in Global.citys:
		var city_item_instace = city_item_scene.instantiate()
		city_item_instace.position = Vector2(Global.citys[i].position_x, Global.citys[i].position_y)
		city_item_instace.text_name = Global.citys[i].name
		city_item_instace.character_number = int(Global.citys[i].lordId)
		city_item_instace.city_code = i
		# print(Global.citys[i].ownerId)
		# print(Global.characters_select[int(Global.citys[i].ownerId)])
		if(!Global.citys[i].ownerId == 0):
			city_item_instace.color = Global.characters_select[int(Global.citys[i].ownerId)].color
		$".".add_child(city_item_instace)
