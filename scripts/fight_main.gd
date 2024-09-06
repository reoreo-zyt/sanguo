extends Node2D

var select_hero_scene = preload("res://scenes/fightNew/select_hero.tscn")
var lord_scene = preload("res://scenes/fightNew/lord.tscn")

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
	create_select_heros()

func _input(event):
	if event is InputEventMouseButton and event.pressed:
		var result_array = []
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
		# 获取全局鼠标位置
		var global_mouse_pos = get_global_mouse_position()
		# 将全局位置转换为TileMap上的tile坐标
		var tile_pos = $start/terrain.local_to_map(global_mouse_pos)
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
		print(tile_pos_text, right_text, right_bottom_text, bottom_text)
		result_array.append(tile_pos_text)
		result_array.append(right_text)
		result_array.append(right_bottom_text)
		result_array.append(bottom_text)
		for i in result_array:
			static_times[i].times += 1
		get_text_desc(static_times, times_desc)

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
	
	var action_array = []
	
	#  开始创建我方跟敌方武将
	var self_location = [
		Vector2i(16, 46),
		Vector2i(18, 46),
		Vector2i(20, 46),
		Vector2i(22, 46),
		Vector2i(24, 46),
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
		$start/selft.add_child(lord_scene_instance)
		action_array.append({
			"id": i,
			"speed": get_random_number(),
			"type": "self",
		})
	index = 0
	for i in Global.fight_other_ids:
		var lord_scene_instance = lord_scene.instantiate()
		lord_scene_instance.position = other_location[index] * 16
		lord_scene_instance.is_self = false
		index += 1
		$start/army.add_child(lord_scene_instance)
		action_array.append({
			"id": i,
			"speed": get_random_number(),
			"type": "animy"
		})
	# 生成速度的人名进度条
	action_array.sort_custom(sort_ascending)
	for i in action_array:
		var label = Label.new()
		label.text = Global.characters[i.id].name
		if(i.type == 'animy'):
			label.modulate = Color.RED
		$start/SpeedPanel/VBoxContainer/ScrollContainer/HBoxContainer.add_child(label)

func sort_ascending(a, b):
	if a["speed"] > b["speed"]:
		return true
	return false

func get_random_number():
	# 生成一个0到100之间的随机整数
	return rng.randi_range(0, 100) # randi方法的参数是范围的上限和下限，因此这里生成的是0到100之间的随机整数
