extends Node

# 默认文本提示
var current_message_title = ''

# 文本说明
var text_message = {}

# 武器
var weapons = {}

# 防具
var armors = {}

# TODO: 技能待设计
var skills = {}

# 自定义君主列表
var characters_select = {}

# 311 英雄数据
var characters = {}

# 当前选择的城池
var cur_city = ""

# 当前选择的人物
var cur_hero_id = 0

# 是否已经选择人物
var is_select_hero = false

# 是否按下点击按钮
var is_press_select_button = false

# 城池数据
var citys = {}

# 城市内政选择的人物 id
var curr_city_character = 0

# 初始政令数量
var polities_times = 3

# 选择的君主
var cur_character = 2

# 初始年月
var year = 189
var month = 1

# 内政相关
# 是否可以显示全部城市的信息
var is_show_other_city_message = false

# 战斗相关
# 我方
var fight_self_ids = []
# 敌方
var fight_other_ids = []

# 当前选择
var curr_fight_character_id = 0

# 当前选择的武将
var save_move_jiang = []

# 维护一个出仕的武将列表
var save_hire_jiang = []

# 读取 xlsx 文件
func _ready():
	var excel = ExcelFile.open_file("res://data/311_data.xlsx")
	var workbook = excel.get_workbook()

	# 获取文本说明
	var text_sheet = workbook.get_sheet(4)
	var text_data = text_sheet.get_table_data()
	current_message_title = text_data[2][1]
	for i in text_data:
		if(i!=1):
			text_message[text_data[i][1]] = text_data[i][2]
	
	# 获取武器
	var weapon_sheet = workbook.get_sheet(1)
	var weapon_data = weapon_sheet.get_table_data()
	for i in weapon_data:
		if(i!=1):
			weapons[weapon_data[i][2]] = {
				"name": weapon_data[i][1],
			}

	# 获取防具
	var armor_sheet = workbook.get_sheet(2)
	var armors_data = armor_sheet.get_table_data()
	for i in armors_data:
		if(i!=1):
			armors[armors_data[i][2]] = {
				"name": armors_data[i][1],
			}

	var skill_sheet = workbook.get_sheet(5)
	var skills_data = skill_sheet.get_table_data()
	# TODO: 技能暂时写死
	for i in skills_data: 
		if(i!=1):
			skills[skills_data[i][2]] = {
				"name": skills_data[i][1],
				"desc": text_message[skills_data[i][1]],
				"type": skills_data[i][3],
			}

	# 获取英雄数据
	var hero_sheet = workbook.get_sheet(0)
	var hero_data = hero_sheet.get_table_data()
	characters[0] = {
		"name": '无人占领城池',
	}
	for i in hero_data:
		if(i!=1):
			characters[i] = {
				"name": hero_data[i][1],
				"headImg": "res://assets/texture/profile/" + hero_data[i][1] + ".jpg",
				"attrs": {
					"level": hero_data[i][14],
					"speed": 80,
					"lorty": 99,
					"curr_physical_strength": 100,
					"command": hero_data[i][2],
					"force": hero_data[i][3],
					"intelligence": hero_data[i][4],
					"politics": hero_data[i][5],
					"morality": hero_data[i][6],
				},
				"cityId": hero_data[i][10],
				"weaponId": hero_data[i][11],
				"armorId": hero_data[i][12],
				"skillIds": get_skill_array(hero_data[i][13]),
				"work": hero_data[i][9],
				"born": hero_data[i][7],
				"dead": hero_data[i][8]
			}


	# 将角色数据加入兵力等信息
	for i in characters:
		if(i!=0):
			# 兵力
			characters[i].attrs.bing = get_bing_by_command(characters[i].attrs.command)
			# 初始金钱
			characters[i].attrs.jin = 200

	# 获取自定义君主列表
	var character_sheet = workbook.get_sheet(6)
	var character_data = character_sheet.get_table_data()
	characters_select[0] = {
		"name": '无人占领城池',
		"city_material": {
			"green_blue": false,
			"green_red": false,
			"blue_red": false,
			"blue": 1,
			"green": 1,
			"red": 1
		},
		"color": "#fff",
	}
	for i in character_data:
		if(i!=1):
			characters_select[int(character_data[i][3])] = {
				"name": character_data[i][1],
				"city_material": {
					"green_blue": character_data[i][2].split(',')[0],
					"green_red": character_data[i][2].split(',')[1],
					"blue_red": character_data[i][2].split(',')[2],
					"blue": character_data[i][2].split(',')[3],
					"green": character_data[i][2].split(',')[4],
					"red": character_data[i][2].split(',')[5]
				},
				"id": character_data[i][3],
				"color": character_data[i][5],
				"citys": character_data[i][4].split(','),
				"headImg": characters[int(character_data[i][3])].headImg,
				"attrs": {
					"curr_physical_strength": characters[int(character_data[i][3])].attrs.curr_physical_strength,
					"level": characters[int(character_data[i][3])].attrs.level,
					"speed": characters[int(character_data[i][3])].attrs.speed,
					"lorty": characters[int(character_data[i][3])].attrs.lorty,
					"command": characters[int(character_data[i][3])].attrs.command,
					"force": characters[int(character_data[i][3])].attrs.force,
					"intelligence": characters[int(character_data[i][3])].attrs.intelligence,
					"politics": characters[int(character_data[i][3])].attrs.politics,
					"morality": characters[int(character_data[i][3])].attrs.morality,
				},
				"weaponId": characters[int(character_data[i][3])].weaponId,
				"armorId": characters[int(character_data[i][3])].armorId,
				"skillIds": characters[int(character_data[i][3])].skillIds,
				"work": characters[int(character_data[i][3])].work,
				"born": characters[int(character_data[i][3])].born,
				"dead": characters[int(character_data[i][3])].dead,
			}
	
	# 获取城池数据
	var city_sheet = workbook.get_sheet(3)
	var city_data = city_sheet.get_table_data()
	cur_city = city_data[2][2]
	for i in city_data:
		if(i!=1):
			citys[city_data[i][2]] = {
				"name": city_data[i][1],
				"ownerId": city_data[i][3],
				"lordId": city_data[i][4],
				"tong": city_data[i][5],
				"ren": city_data[i][6],
				"jiang": findAllCharacters(city_data[i][2], hero_data),
				"curent_jiang": findAllCharacters(city_data[i][2], hero_data, 189),
				"bing": city_data[i][7],
				"nong": city_data[i][8],
				"shang": city_data[i][9],
				"zhi": city_data[i][10],
				"jin": city_data[i][11],
				"liang": city_data[i][12],
				"position_x": city_data[i][13],
				"position_y": city_data[i][14],
			}
	# print(citys)

	for i in citys:
		for item in citys[i].curent_jiang:
			save_hire_jiang.append(item)

# 公用方法
func set_name_text(name):
	return "[center][color=#91c2d5][u][url]" + name + "[/url][/u][/color]"

func set_text(str):
	return "[center][color=#91c2d5]" + str(str) + "[/color]"

func clear_children(parent: Node):
	for child in parent.get_children():
		child.queue_free()

func findAllCharacters(city_code, heros, year = 10000):
	var heros_codes = []
	for i in heros:
		if(i!=1):
			if(!characters[i].cityId):
				continue
			if(characters[i].cityId == city_code && characters[i].work <= year):
				heros_codes.push_back(i)
	return heros_codes

# a b 数组
# 获取 a 在 b 数组中不重复的值
# [3, 15, 43, 174, 189] a
# [3, 15, 43, 174, 189, 374, 421, 478] b
# [374, 421, 478]
func get_array_diff(a, b):
	var temparray = []
	var is_append = true
	for i in b:
		for j in a:
			if(i == j):
				is_append = false
		if(is_append):
			temparray.append(i)
		else:
			is_append = true
	return temparray

func get_skill_array(skill_text):
	if(!skill_text):
		return []
	else:
		return skill_text.split(",")

func get_bing_by_command(command):
	if(command <= 50):
		return 1000
	elif(command <= 70):
		return 1000 + (50 * (command - 50))
	elif(command <= 90):
		return 1000 + (80 * (command - 50))
	else:
		return 1000 + (100 * (command - 50))

func set_message_name(text):
	return "[color=#91c2d5][u][url]"+  text +"[/url][/u][/color]"

func get_skill_desc(nameId):
	var skillsDesc = ""
	var skillIds = Global.characters_select[int(nameId)].skillIds
	for i in Global.characters_select[int(nameId)].skillIds:
		if(Global.skills[i].type == "normal"):
			skillsDesc += "[color=#91c2d5][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
		if(Global.skills[i].type == "self"):
			skillsDesc += "[color=#ffe219][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
		if(Global.skills[i].type == "self_bad"):
			skillsDesc += "[color=#ff5437][u][url]"+  Global.skills[i].name +"[/url][/u][/color]" + " "
	return skillsDesc
