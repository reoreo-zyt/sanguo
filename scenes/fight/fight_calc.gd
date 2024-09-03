extends VBoxContainer

var character = preload("res://scenes/fight/lord.tscn")

var turn_time = 0.5

var solder_template = {
	'将': {
		'hp': 100,
		'attack': 25,
	},
	'步': {
		'hp': 100,
		'attack': 25,
	},
	'弓': {
		'hp': 100,
		'attack': 25,
	},
	'骑': {
		'hp': 100,
		'attack': 25,
	}
}

# TODO: 按速度排列
var troop_self = [
	{
		'name': '将',
		'node': "rank1/e1",
		'speed': 100,
		'hp': solder_template['将'].hp
	},
	{
		'name': '骑',
		'node': "rank2/e2",
		'speed': 80,
		'hp': solder_template['骑'].hp
	},
	{
		'name': '步',
		'node': "rank2/d2",
		'speed': 60,
		'hp': solder_template['步'].hp
	},
	{
		'name': '步',
		'node': "rank2/c2",
		'speed': 60,
		'hp': solder_template['步'].hp
	},
	{
		'name': '步',
		'node': "rank2/f2",
		'speed': 60,
		'hp': solder_template['步'].hp
	},
	{
		'name': '步',
		'node': "rank2/g2",
		'speed': 60,
		'hp': solder_template['步'].hp
	},
	{
		'name': '弓',
		'node': "rank1/c1",
		'speed': 50,
		'hp': solder_template['弓'].hp
	},
	{
		'name': '弓',
		'node': "rank1/d1",
		'speed': 50,
		'hp': solder_template['弓'].hp
	},
	{
		'name': '弓',
		'node': "rank1/f1",
		'speed': 50,
		'hp': solder_template['弓'].hp
	},
	{
		'name': '弓',
		'node': "rank1/g1",
		'speed': 50,
		'hp': solder_template['弓'].hp
	},
]

var troop_army = [
	{
		'name': '将',
		'node': "rank8/e8",
		'speed': 100,
		'hp': solder_template['将'].hp
	},
	{
		'name': '骑',
		'node': "rank7/e7",
		'speed': 80,
		'hp': solder_template['将'].hp
	},
	{
		'name': '步',
		'node': "rank7/d7",
		'speed': 40,
		'hp': solder_template['步'].hp
	},
	{
		'name': '步',
		'node': "rank7/c7",
		'speed': 40,
		'hp': solder_template['步'].hp
	},
	{
		'name': '步',
		'node': "rank7/f7",
		'speed': 40,
		'hp': solder_template['步'].hp
	},
	{
		'name': '步',
		'node': "rank7/g7",
		'speed': 40,
		'hp': solder_template['步'].hp
	},
	{
		'name': '弓',
		'node': "rank8/c8",
		'speed': 60,
		'hp': solder_template['弓'].hp
	},
	{
		'name': '弓',
		'node': "rank8/d8",
		'speed': 60,
		'hp': solder_template['弓'].hp
	},
	{
		'name': '弓',
		'node': "rank8/f8",
		'speed': 60,
		'hp': solder_template['弓'].hp
	},
	{
		'name': '弓',
		'node': "rank8/g8",
		'speed': 60,
		'hp': solder_template['弓'].hp
	},
]

func _ready() -> void:
	generate_fight()

func generate_fight():
	for i in troop_self:
		var characterInstance = character.instantiate()
		characterInstance.lord_name = i.name
		i.instance = characterInstance
		get_node(i.node).add_child(characterInstance)
	for i in troop_army:
		var characterInstance = character.instantiate()
		characterInstance.lord_name = i.name
		characterInstance.is_self = false
		i.instance = characterInstance
		get_node(i.node).add_child(characterInstance)
	start_fight()

func start_fight():
	# 开始移动，速度快的格子先执行
	# 将-骑-兵-弓
	for i in troop_self:
		if(i.name == '将'):
			await get_tree().create_timer(turn_time).timeout
			move(i, true)
			await get_tree().create_timer(turn_time).timeout
			move(i, true)
		if(i.name == '骑'):
			await get_tree().create_timer(turn_time).timeout
			move(i, true)
			await get_tree().create_timer(turn_time).timeout
			move(i, true)
		if(i.name == '步'):
			await get_tree().create_timer(turn_time).timeout
			move(i, true)
		if(i.name == '弓'):
			await get_tree().create_timer(turn_time).timeout
			move(i, true)
	for i in troop_army:
		if(i.name == '将'):
			await get_tree().create_timer(turn_time).timeout
			move(i)
			await get_tree().create_timer(turn_time).timeout
			move(i)
		if(i.name == '骑'):
			await get_tree().create_timer(turn_time).timeout
			move(i)
			await get_tree().create_timer(turn_time).timeout
			move(i)
		if(i.name == '步'):
			await get_tree().create_timer(turn_time).timeout
			move(i)
		if(i.name == '弓'):
			await get_tree().create_timer(turn_time).timeout
			move(i)
	# 递归 继续下一回合
	start_fight()

func move(i, is_self = false):
	### 此处获取当前节点的下一个节点
	# 获取当前节点的索引
	var curr_index = get_node(i.node).get_index()
	var parent_index = get_node(i.node).get_parent().get_index()
	var top_node = get_node(i.node).get_parent().get_parent()
	var index = 0
	if(is_self):
		# 友方移动
		index = parent_index - 1
	else:
		# 敌方移动
		index = parent_index + 1
	var next_node = top_node.get_child(index).get_child(curr_index)
	if(is_self):
		# 友方移动
		print(next_node.get_path())
	else:
		# 敌方移动
		print(next_node.get_path())
	if(next_node.get_child_count() == 1):
		print("前方有友军，无法移动或者攻击")
		return
	i.instance.free()
	var characterInstance = character.instantiate()
	characterInstance.lord_name = i.name
	i.instance = characterInstance
	if(!is_self):
		characterInstance.is_self = false
	next_node.add_child(characterInstance)
	i.node = next_node.get_path()
