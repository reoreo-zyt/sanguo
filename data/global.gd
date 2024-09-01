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
					"level": 30,
					"speed": 80,
					"lorty": 99,
					"curr_physical_strength": 100,
					"command": hero_data[i][2],
					"force": hero_data[i][3],
					"intelligence": hero_data[i][4],
					"politics": hero_data[i][5],
					"morality": hero_data[i][6],
				},
				"weaponId": hero_data[i][11],
				"armorId": hero_data[i][12],
				"skillIds": hero_data[i][13].split(","),
				"work": hero_data[i][9],
				"born": hero_data[i][7],
				"dead": hero_data[i][8]
			}

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
		}
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
				"dead": characters[int(character_data[i][3])].dead
			}

# 当前选择的城池
var cur_city = "61b9c512-225d-d918-086c-e2da4edb860f"

# 当前选择的人物
var cur_hero_id = 100

######### 187 剧本城池数据
#########
var citys = {
"61b9c512-225d-d918-086c-e2da4edb860f": {
	"name": "凉州武威",
	"ownerId": 7,
	"lordId": 7,
	"tong": 60,
	"ren": 20000,
	"jiang": [
		7,
		100,
		101,
		102,
		103,
		104,
		105,
		106,
		107
	],
	"bing": 15600,
	"nong": 25,
	"shang": 25,
	"zhi": 60,
	"jin": 300,
	"liang": 600
},
"95ef07b8-a83a-5216-1772-e1636cc1487b": {
	"name": "凉州金城",
	"ownerId": 7,
	"lordId": 108,
	"tong": 60,
	"ren": 16500,
	"jiang": [
		108,
		109,
	],
	"bing": 13450,
	"nong": 35,
	"shang": 15,
	"zhi": 72,
	"jin": 450,
	"liang": 550
},
"055a5ee1-332d-6889-c21a-5e06d3aa1a04": {
	"name": "凉州武都",
	"ownerId": 7,
	"lordId": 110,
	"tong": 60,
	"ren": 18500,
	"jiang": [
		110,
		111,
		112,
		113,
		114,
		115,
		116,
		117,
		118,
		119,
		120,
		121,
		122,
		123,
	],
	"bing": 17690,
	"nong": 40,
	"shang": 20,
	"zhi": 66,
	"jin": 300,
	"liang": 500
},
"e556187f-fdc8-8478-01b7-700e929bf82b": {
	"name": "雍州安庆",
	"ownerId": 0,
	"lordId": 0,
	"tong": 60,
	"ren": 18500,
	"jiang": [
		124,
		125
	],
	"bing": 17690,
	"nong": 40,
	"shang": 20,
	"zhi": 66,
	"jin": 300,
	"liang": 500
},
"19f4f683-b564-5c14-b6b0-ddce7f229b91": {
	"name": "并州朔方",
	"ownerId": 0,
	"lordId": 0,
	"tong": 60,
	"ren": 21500,
	"jiang": [
		126
	],
	"bing": 21680,
	"nong": 45,
	"shang": 15,
	"zhi": 74,
	"jin": 200,
	"liang": 400
},
"e42f21b7-9cd3-8148-907b-d77faa3d1ef5": {
	"name": "益州汉中",
	"ownerId": 0,
	"lordId": 128,
	"tong": 55,
	"ren": 25647,
	"jiang": [
		128,
		129,
		130,
		131,
		132,
		133,
		134
	],
	"bing": 23670,
	"nong": 25,
	"shang": 35,
	"zhi": 55,
	"jin": 100,
	"liang": 200
},
"bd1ded71-00b0-98b6-9bc4-ffd19583f7ab": {
	"name": "雍州长安",
	"ownerId": 5,
	"lordId": 128,
	"tong": 55,
	"ren": 25647,
	"jiang": [
		5
	],
	"bing": 23670,
	"nong": 25,
	"shang": 35,
	"zhi": 55,
	"jin": 100,
	"liang": 200
},
}

# 公用方法
func set_name_text(name):
	return "[center][color=#91c2d5][u][url]" + name + "[/url][/u][/color]"

func set_text(str):
	return "[center][color=#91c2d5]" + str(str) + "[/color]"

func clear_children(parent: Node):
	for child in parent.get_children():
		child.queue_free()
