extends Node2D

var select_hero_scene = preload("res://scenes/fightNew/select_hero.tscn")
var lord_scene = preload("res://scenes/fightNew/lord.tscn")
var character_attr_scene = preload("res://scenes/fightNew/character_attr.tscn")
var is_self_turn = false
var create_character_instance = null

var action_array = []
var static_times = {
	'树林': {
		'times': 0
	},
	'平地': {
		'times': 0
	},
	'水': {
		'times': 0
	},
	'山': {
		'times': 0
	}
}
var times_desc = {
	4: '几乎全部地方都是',
	3: '大部分地方是',
	2: '几乎一半以上的地方是',
	1: '只有一些地方是',
	0: '几乎没有地方是'
}

var rng:RandomNumberGenerator

var select_map = {
	-1: false,
	0: {
		'name': '树林'
	},
	1: {
		'name': '平地'
	},
	3: {
		'name': '水'
	},
	4: {
		'name': '山'
	}
}

func _ready():
	# 初始化随机数生成器，可以使用当前时间作为种子以确保每次运行程序时都能得到不同的随机数
	rng = RandomNumberGenerator.new()
	rng.randomize() # 使用基于时间的种子初始化随机数生成器
	SignalBus.connect("select_hero_list", _on_select_hero_list)
	SignalBus.connect("change_next_fight_character_id", _on_change_next_fight_character_id)
	SignalBus.connect("curr_fight_character_move", _on_curr_fight_character_move)
	SignalBus.connect("curr_fight_character_move_forward", _on_curr_fight_character_move_forward)
	SignalBus.connect("curr_fight_character_show_info", _on_curr_fight_character_show_info)
	create_select_heros()
	_on_button_pressed()

#func _input(event):
	#if event is InputEventMouseButton and event.pressed:

func get_text_desc(static_times, times_desc):
	$start/textMessagePanel/RichTextLabel.text = "[center]所在地形因素："
	for i in static_times:
		$start/textMessagePanel/RichTextLabel.text += "[center]" + times_desc[static_times[i].times] + i

func create_select_heros():
	for i in Global.characters:
		if(i == 0):
			continue
		var hero_instance = select_hero_scene.instantiate()
		hero_instance.name_id = int(i)
		hero_instance.name_text = Global.characters[i].name
		$select/Panel/ScrollContainer/HCContainer/ScrollContainer/VBoxContainer.add_child(hero_instance)
	for i in Global.characters:
		if(i == 0):
			continue
		var hero_instance = select_hero_scene.instantiate()
		hero_instance.name_id = int(i)
		hero_instance.name_text = Global.characters[i].name
		hero_instance.is_select_self = false
		$select/Panel/ScrollContainer2/HCContainer/ScrollContainer/VBoxContainer.add_child(hero_instance)

func _on_select_hero_list(is_self):
	if(is_self):
		Global.fight_self_ids = []
		for i in $select/Panel/ScrollContainer/HCContainer/ScrollContainer/VBoxContainer.get_children():
			if(i.is_select):
				Global.fight_self_ids.append(i.name_id)
		print(Global.fight_self_ids)
	else:
		Global.fight_other_ids = []
		for i in $select/Panel/ScrollContainer2/HCContainer/ScrollContainer/VBoxContainer.get_children():
			if(i.is_select):
				Global.fight_other_ids.append(i.name_id)
		print(Global.fight_other_ids)

func _on_button_pressed() -> void:
	if(Global.fight_self_ids.size() == 0):
		return
	if(Global.fight_other_ids.size() == 0):
		return
	if(Global.fight_self_ids.size() > 5):
		return
	if(Global.fight_other_ids.size() > 5):
		return
	$start.show()
	$select.hide()

	#  开始创建我方跟敌方武将
	var self_location = [
		Vector2i(16, 45),
		Vector2i(18, 45),
		Vector2i(20, 45),
		Vector2i(22, 45),
		Vector2i(24, 45),
	]
	var other_location = [
		Vector2i(20, 23),
		Vector2i(22, 23),
		Vector2i(24, 23),
		Vector2i(26, 23),
		Vector2i(28, 23),
	]
	var index = 0
	for i in Global.fight_self_ids:
		var lord_scene_instance = lord_scene.instantiate()
		lord_scene_instance.position = self_location[index] * 16
		index += 1
		lord_scene_instance.character_id = i
		$start/selft.add_child(lord_scene_instance)
		action_array.append({
			"id": i,
			"speed": 110,
			"type": "self",
			"location": self_location[index],
			"instance": lord_scene_instance
		})
	index = 0
	for i in Global.fight_other_ids:
		var lord_scene_instance = lord_scene.instantiate()
		lord_scene_instance.position = other_location[index] * 16
		lord_scene_instance.is_self = false
		index += 1
		lord_scene_instance.character_id = i
		$start/army.add_child(lord_scene_instance)
		action_array.append({
			"id": i,
			"speed": get_random_number(),
			"type": "animy",
			"location": self_location[index],
			"instance": lord_scene_instance
		})
	# 生成速度的人名进度条
	action_array.sort_custom(sort_ascending)
	for i in action_array:
		var label = Label.new()
		label.text = Global.characters[i.id].name
		if(i.type == 'animy'):
			label.modulate = Color.RED
		$start/SpeedPanel/VBoxContainer/ScrollContainer/HBoxContainer.add_child(label)

	# 打开第一个武将的弹窗
	SignalBus.emit_signal("change_curr_fight_character_id", action_array[0].id)
	# 选中当前武将
	get_select(action_array[0].location)

func sort_ascending(a, b):
	if a["speed"] > b["speed"]:
		return true
	return false

func get_random_number():
	# 生成一个0到100之间的随机整数
	return rng.randi_range(0, 100) # randi方法的参数是范围的上限和下限，因此这里生成的是0到100之间的随机整数

func calc_cost(location):
	var result_array = []
	var cost = 0
	for i in static_times:
		static_times[i].times = 0
	var tile_pos_text = select_map[$start/terrain.get_cell_source_id(location)].name
	var right_text = select_map[$start/terrain.get_cell_source_id(Vector2i(location.x + 1, location.y))].name
	var right_bottom_text = select_map[$start/terrain.get_cell_source_id(Vector2i(location.x + 1, location.y + 1))].name
	var bottom_text = select_map[$start/terrain.get_cell_source_id(Vector2i(location.x, location.y + 1))].name
	result_array.append(tile_pos_text)
	result_array.append(right_text)
	result_array.append(right_bottom_text)
	result_array.append(bottom_text)
	print(result_array)
	for i in result_array:
		static_times[i].times += 1
	print(static_times)
	for i in static_times:
		if(i == '树林'):
			cost += static_times[i].times * 4
		if(i == '平地'):
			cost += static_times[i].times * 1
		if(i == '水'):
			cost += static_times[i].times * 4
		if(i == '山'):
			cost += static_times[i].times * 4
	return cost

func get_select(location):
		for i in static_times:
			static_times[i].times = 0
		var result_array = []
		# 获取全局鼠标位置
		# var global_mouse_pos = get_global_mouse_position()
		# 将全局位置转换为TileMap上的tile坐标
		var tile_pos = Vector2i(location.x - 2, location.y)
		$start/Select.show()
		$start/Select.position.x = tile_pos.x * 16
		$start/Select.position.y = tile_pos.y * 16
		if(!select_map[$start/terrain.get_cell_source_id(tile_pos)]):
			return
		if(!select_map[$start/terrain.get_cell_source_id(Vector2i(tile_pos.x + 1, tile_pos.y))]):
			return
		if(!select_map[$start/terrain.get_cell_source_id(Vector2i(tile_pos.x + 1, tile_pos.y + 1))]):
			return
		if(!select_map[$start/terrain.get_cell_source_id(Vector2i(tile_pos.x, tile_pos.y + 1))]):
			return
		# 获取当前格子右 右下 下的相关属性	
		var tile_pos_text = select_map[$start/terrain.get_cell_source_id(tile_pos)].name
		var right_text = select_map[$start/terrain.get_cell_source_id(Vector2i(tile_pos.x + 1, tile_pos.y))].name
		var right_bottom_text = select_map[$start/terrain.get_cell_source_id(Vector2i(tile_pos.x + 1, tile_pos.y + 1))].name
		var bottom_text = select_map[$start/terrain.get_cell_source_id(Vector2i(tile_pos.x, tile_pos.y + 1))].name
		result_array.append(tile_pos_text)
		result_array.append(right_text)
		result_array.append(right_bottom_text)
		result_array.append(bottom_text)
		for i in result_array:
			static_times[i].times += 1
		get_text_desc(static_times, times_desc)

func _on_change_next_fight_character_id():
	# 关闭当前
	SignalBus.emit_signal("close_before_fight_character_id", action_array[0].id)

	# 将角色列表数组首位塞到最后一位
	var first_element = action_array[0]
	action_array.remove_at(0)
	action_array.append(first_element)
	# 打开第一个武将的弹窗
	SignalBus.emit_signal("change_curr_fight_character_id", action_array[0].id)
	# 选中当前武将
	get_select(action_array[0].location)

func _on_curr_fight_character_move(id):
	# 计算当前位置的四个方向的移动点消耗，画上高亮的点
	# print(id)
	pass

func _on_curr_fight_character_move_forward(direction):
	var pixel = 32
	if(direction == "UP"):
		action_array[0].instance.position = Vector2i(action_array[0].instance.position.x, action_array[0].instance.position.y - pixel)
	if(direction == "BOTTOM"):
		action_array[0].instance.position = Vector2i(action_array[0].instance.position.x, action_array[0].instance.position.y + pixel)
	if(direction == "LEFT"):
		action_array[0].instance.position = Vector2i(action_array[0].instance.position.x - pixel, action_array[0].instance.position.y)
	if(direction == "RIGHT"):
		action_array[0].instance.position = Vector2i(action_array[0].instance.position.x + pixel, action_array[0].instance.position.y)
	get_select(Vector2i((action_array[0].instance.position.x + pixel)/ 16, action_array[0].instance.position.y / 16))

func _on_curr_fight_character_show_info(id):
	if(create_character_instance):
		create_character_instance.queue_free()
	var character = character_attr_scene.instantiate()
	character.name_id = id
	character.position.y += 700
	create_character_instance = character
	$start.add_child(character)
