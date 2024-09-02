extends Panel

var character = preload("res://scenes/fight/lord.tscn")

var troop_self = [
	{
		'name': '将',
		'hp': 100,
		'attack': 100,
		'speed': 64,
		'attack_range': 0,
		'position_x': 56,
		'position_y': 164
	},
	{
		'name': '弓',
		'hp': 50,
		'attack': 50,
		'speed': 32,
		'attack_range': 64,
		'position_x': 96,
		'position_y': 164
	},
	{
		'name': '步',
		'hp': 100,
		'attack': 25,
		'speed': 32,
		'attack_range': 0,
		'position_x': 136,
		'position_y': 164
	},
	{
		'name': '骑',
		'hp': 100,
		'attack': 50,
		'speed': 64,
		'attack_range': 0,
		'position_x': 176,
		'position_y': 164
	}
]

var troop_army = [
	{
		'name': '将',
		'hp': 100,
		'attack': 100,
		'speed': 64,
		'attack_range': 0,
		'position_x': 460,
		'position_y': 164
	},
	{
		'name': '弓',
		'hp': 50,
		'attack': 50,
		'speed': 32,
		'attack_range': 64,
		'position_x': 420,
		'position_y': 164
	},
	{
		'name': '步',
		'hp': 100,
		'attack': 25,
		'speed': 32,
		'attack_range': 0,
		'position_x': 380,
		'position_y': 164
	},
	{
		'name': '骑',
		'hp': 100,
		'attack': 50,
		'speed': 64,
		'attack_range': 0,
		'position_x': 340,
		'position_y': 164
	}
]

func _ready() -> void:
	generate_fight()

func generate_fight():
	for i in troop_self:
		var characterInstance = character.instantiate()
		characterInstance.lord_name = i.name
		characterInstance.position.x = i.position_x
		characterInstance.position.y = i.position_y
		$self.add_child(characterInstance)
	for i in troop_army:
		var characterInstance = character.instantiate()
		characterInstance.lord_name = i.name
		characterInstance.is_self = false
		characterInstance.position.x = i.position_x
		characterInstance.position.y = i.position_y
		$animy.add_child(characterInstance)
