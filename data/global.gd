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

	# 获取防具
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

######### 角色数据
######### 。。。用数字100累加表示，0-7 是君主
var characters = {
0: {
	"name": "无人占领城池",
},
5: {
	"name": "董卓",
	"headImg": "res://assets/texture/profile/董卓 Dong Zhuo.jpg",
	"weaponId": "e7911e0f-5360-0b88-785e-be47f99f4680",
	"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
	"skillIds": [
		"335ba8c3-916a-20e7-5a61-563202e99805",
		"a091a2c4-2033-3c31-d86c-27866f38e90d",
		"976bce1c-7f84-0fad-f6f5-57f133e80766"
	],
	"attrs": {
		"level": 50,
		"command": 81,
		"politics": 34,
		"force": 87,
		"intelligence": 69,
		"physical_strength": 100,
		"morality": 25,
		"speed": 80
	},
	"work": 184,
	"born": 139,
	"dead": 192
},
7: {
	"name": "马腾",
	"headImg": "res://assets/texture/profile/马腾 Ma Teng.jpg",
	"weaponId": "8bc8766e-804f-770d-281a-600b7bcbebcb",
	"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
	"skillIds": [
		"b4950dc9-1472-3a65-539a-539175e4bf4c",
		"337a5371-fd68-d7df-3565-a3e6177bb13d",
		"7e1823d0-f790-5fb1-d171-81fb6d7ca747",
		"48193d31-df5a-2535-2e63-53aa517b679d"
	],
	"attrs": {
		"level": 40,
		"command": 82,
		"force": 80,
		"intelligence": 51,
		"politics": 59,
		"morality": 89,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 99,
		"curr_physical_strength": 100,
	},
	"work": 184,
	"born": 149,
	"dead": 211
},
# 除了君主以外的其他将领
100: {
	"name": "成公英",
	"headImg": "res://assets/texture/profile/成公英 cheng gong ying.jpg",
	"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
	"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
	"skillIds": [
		"44037d60-ee22-4bd8-4e04-f966f0af082d"
	],
	"attrs": {
		"level": 20,
		"command": 73,
		"force": 71,
		"intelligence": 80,
		"politics": 62,
		"morality": 68,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 99,
		"curr_physical_strength": 100,
	},
	"work": 189,
	"born": 172,
	"dead": 220
},
101: {
	"name": "张横",
	"headImg": "res://assets/texture/profile/张横 zhang heng.jpg",
	"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
	"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
	"skillIds": [
		"77d464d9-e901-f941-663e-020850cdf7b4"
	],
	"attrs": {
		"level": 20,
		"command": 59,
		"force": 70,
		"intelligence": 23,
		"politics": 24,
		"morality": 49,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 89,
		"curr_physical_strength": 100,
	},
	"work": 197,
	"born": 178,
	"dead": 211
},
102: {
	"name": "邓贤",
	"headImg": "res://assets/texture/profile/邓贤 deng Xian.jpg",
	"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
	"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
	"skillIds": [],
	"attrs": {
		"level": 20,
		"command": 61,
		"force": 73,
		"intelligence": 45,
		"politics": 36,
		"morality": 51,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 92,
		"curr_physical_strength": 100,
	},
	"work": 208,
	"born": 188,
	"dead": 248
},
103: {
	"name": "李堪",
	"headImg": "res://assets/texture/profile/李堪 Li Kan.jpg",
	"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
	"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
	"skillIds": [],
	"attrs": {
		"level": 20,
		"command": 58,
		"force": 59,
		"intelligence": 33,
		"politics": 37,
		"morality": 45,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 92,
		"curr_physical_strength": 100,
	},
	"work": 195,
	"born": 176,
	"dead": 211
},
104: {
	"name": "梁兴",
	"headImg": "res://assets/texture/profile/梁兴 Liang Xin.jpg",
	"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
	"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
	"skillIds": [],
	"attrs": {
		"level": 20,
		"command": 61,
		"force": 65,
		"intelligence": 19,
		"politics": 22,
		"morality": 26,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 92,
		"curr_physical_strength": 100,
	},
	"work": 188,
	"born": 169,
	"dead": 211
},
105: {
	"name": "马岱",
	"headImg": "res://assets/texture/profile/马岱 Ma Dai.jpg",
	"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
	"armorId": "dceaf567-ca94-2a19-01d9-efbb9844ffc6",
	"skillIds": [
		"aac701bf-f18d-3677-7ee6-1f63446cd2b4",
		"7e1823d0-f790-5fb1-d171-81fb6d7ca747"
	],
	"attrs": {
		"level": 30,
		"command": 81,
		"force": 85,
		"intelligence": 56,
		"politics": 54,
		"morality": 74,
		"physical_strength": 100,
		"speed": 80,

		"lorty": 92,
		"curr_physical_strength": 100,
	},
	"work": 197,
	"born": 183,
	"dead": 246
},
	106: {
		"name": "杨欣",
		"headImg": "res://assets/texture/profile/杨兴 Yang Xin.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 61,
			"force": 68,
			"intelligence": 61,
			"politics": 58,
			"morality": 64,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 239,
		"born": 220,
		"dead": 278
	},
	107: {
		"name": "张横",
		"headImg": "res://assets/texture/profile/张横 Zhang Heng.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 59,
			"force": 70,
			"intelligence": 23,
			"politics": 24,
			"morality": 49,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 197,
		"born": 178,
		"dead": 211
	},
	108: {
		"name": "韩遂",
		"headImg": "res://assets/texture/profile/韩遂 han Sui.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 40,
			"command": 89,
			"force": 70,
			"intelligence": 77,
			"politics": 61,
			"morality": 80,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 184,
		"born": 142,
		"dead": 215
	},
	109: {
		"name": "阎行",
		"headImg": "res://assets/texture/profile/阎行 Yan Xing.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 72,
			"force": 84,
			"intelligence": 61,
			"politics": 58,
			"morality": 69,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 184,
		"born": 159,
		"dead": 222
	},
	110: {
		"name": "姜维",
		"headImg": "res://assets/texture/profile/姜维 Jiang Wei.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 40,
			"command": 90,
			"force": 89,
			"intelligence": 90,
			"politics": 67,
			"morality": 80,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 225,
		"born": 202,
		"dead": 264
	},
	111: {
		"name": "费诗",
		"headImg": "res://assets/texture/profile/费诗 Fei Shi.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 15,
			"force": 28,
			"intelligence": 64,
			"politics": 74,
			"morality": 66,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 195,
		"born": 176,
		"dead": 240
	},
	112: {
		"name": "费耀",
		"headImg": "res://assets/texture/profile/费耀 Fei Yao.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 70,
			"force": 66,
			"intelligence": 73,
			"politics": 62,
			"morality": 67,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 195,
		"born": 176,
		"dead": 240
	},
	113: {
		"name": "侯选",
		"headImg": "res://assets/texture/profile/侯选 Hou Xuan.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 63,
			"force": 66,
			"intelligence": 34,
			"politics": 55,
			"morality": 52,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 194,
		"born": 175,
		"dead": 228
	},
	114: {
		"name": "胡车儿",
		"headImg": "res://assets/texture/profile/胡车儿 Hu Che Er.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 26,
			"force": 82,
			"intelligence": 41,
			"politics": 2,
			"morality": 30,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 188,
		"born": 164,
		"dead": 206
	},
	115: {
		"name": "华雄",
		"headImg": "res://assets/texture/profile/华雄 Hua Xiong.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 40,
			"command": 81,
			"force": 92,
			"intelligence": 56,
			"politics": 40,
			"morality": 57,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 184,
		"born": 155,
		"dead": 190
	},
	116: {
		"name": "梁绪",
		"headImg": "res://assets/texture/profile/梁绪 Liang Xu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 56,
			"force": 52,
			"intelligence": 66,
			"politics": 68,
			"morality": 58,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 217,
		"born": 198,
		"dead": 260
	},
	117: {
		"name": "尹赏",
		"headImg": "res://assets/texture/profile/尹赏 Yi Shang.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 51,
			"force": 44,
			"intelligence": 61,
			"politics": 66,
			"morality": 53,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 213,
		"born": 194,
		"dead": 260
	},
	118: {
		"name": "杨阜",
		"headImg": "res://assets/texture/profile/杨阜 Yang Fu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 30,
			"command": 67,
			"force": 50,
			"intelligence": 83,
			"politics": 78,
			"morality": 77,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 197,
		"born": 178,
		"dead": 239
	},
	119: {
		"name": "王异",
		"headImg": "res://assets/texture/profile/王异 Wang Yi.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 30,
			"command": 58,
			"force": 26,
			"intelligence": 82,
			"politics": 68,
			"morality": 78,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 190,
		"born": 171,
		"dead": 230
	},
	120: {
		"name": "王韬",
		"headImg": "res://assets/texture/profile/王韬 Wang Tao.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 46,
			"force": 59,
			"intelligence": 72,
			"politics": 51,
			"morality": 49,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 229,
		"born": 210,
		"dead": 269
	},
	121: {
		"name": "马遵",
		"headImg": "res://assets/texture/profile/马遵 Ma Zun.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 38,
			"force": 52,
			"intelligence": 31,
			"politics": 51,
			"morality": 48,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 215,
		"born": 196,
		"dead": 260
	},
	122: {
		"name": "宁随",
		"headImg": "res://assets/texture/profile/宁随 Ning Sui.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 67,
			"force": 69,
			"intelligence": 72,
			"politics": 44,
			"morality": 52,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 253,
		"born": 234,
		"dead": 264
	},
	123: {
		"name": "王双",
		"headImg": "res://assets/texture/profile/王双 Wang Shuang.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 64,
			"force": 88,
			"intelligence": 19,
			"politics": 22,
			"morality": 27,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 219,
		"born": 195,
		"dead": 228
	},
	124: {
		"name": "张既",
		"headImg": "res://assets/texture/profile/张既 Zhang ji.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 74,
			"force": 35,
			"intelligence": 75,
			"politics": 88,
			"morality": 81,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 189,
		"born": 170,
		"dead": 223
	},
	125: {
		"name": "张缉",
		"headImg": "res://assets/texture/profile/张缉 Zhang ji.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 31,
			"force": 29,
			"intelligence": 70,
			"politics": 74,
			"morality": 50,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 215,
		"born": 196,
		"dead": 254
	},
	126: {
		"name": "韩珩",
		"headImg": "res://assets/texture/profile/韩珩 Han Yan.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 54,
			"force": 62,
			"intelligence": 67,
			"politics": 74,
			"morality": 88,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 188,
		"born": 166,
		"dead": 205
	},
	127: {
		"name": "蒋舒",
		"headImg": "res://assets/texture/profile/蒋舒 Jiang Shu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 55,
			"force": 76,
			"intelligence": 35,
			"politics": 29,
			"morality": 30,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 244,
		"born": 225,
		"dead": 290
	},
	128: {
		"name": "阎圃",
		"headImg": "res://assets/texture/profile/阎圃 Yan Pu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 29,
			"force": 25,
			"intelligence": 82,
			"politics": 79,
			"morality": 70,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 187,
		"born": 163,
		"dead": 231
	},
	129: {
		"name": "杨昂",
		"headImg": "res://assets/texture/profile/杨昂 Yang Ang.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 68,
			"force": 72,
			"intelligence": 38,
			"politics": 35,
			"morality": 42,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 191,
		"born": 172,
		"dead": 215
	},
	130: {
		"name": "杨柏",
		"headImg": "res://assets/texture/profile/杨柏 Yang Bai.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 44,
			"force": 45,
			"intelligence": 19,
			"politics": 26,
			"morality": 21,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 189,
		"born": 171,
		"dead": 214
	},
	131: {
		"name": "杨任",
		"headImg": "res://assets/texture/profile/杨任 Yang Reng.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 70,
			"force": 78,
			"intelligence": 53,
			"politics": 40,
			"morality": 56,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 189,
		"born": 170,
		"dead": 215
	},
	132: {
		"name": "杨松",
		"headImg": "res://assets/texture/profile/杨松 Yang Song.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 2,
			"force": 5,
			"intelligence": 28,
			"politics": 34,
			"morality": 5,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 186,
		"born": 167,
		"dead": 215
	},
	133: {
		"name": "张卫",
		"headImg": "res://assets/texture/profile/张卫 Zhang Wei.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 74,
			"force": 66,
			"intelligence": 45,
			"politics": 44,
			"morality": 61,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 191,
		"born": 154,
		"dead": 195
	},
	134: {
		"name": "蒋舒",
		"headImg": "res://assets/texture/profile/蒋舒 Jiang Shu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 55,
			"force": 76,
			"intelligence": 35,
			"politics": 29,
			"morality": 30,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 191,
		"born": 154,
		"dead": 195
	},
	135: {
		"name": "杜畿",
		"headImg": "res://assets/texture/profile/杜畿 Du Ji.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 66,
			"force": 32,
			"intelligence": 74,
			"politics": 87,
			"morality": 76,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 184,
		"born": 163,
		"dead": 224
	},
	136: {
		"name": "杜预",
		"headImg": "res://assets/texture/profile/杜预 Du Yu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 85,
			"force": 30,
			"intelligence": 85,
			"politics": 80,
			"morality": 81,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 241,
		"born": 222,
		"dead": 284
	},
	137: {
		"name": "傅嘏",
		"headImg": "res://assets/texture/profile/傅嘏 Fu Gu.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 44,
			"force": 35,
			"intelligence": 81,
			"politics": 82,
			"morality": 70,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 228,
		"born": 209,
		"dead": 255
	},
	138: {
		"name": "傅巽",
		"headImg": "res://assets/texture/profile/傅巽 Fu Xun.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 14,
			"force": 13,
			"intelligence": 69,
			"politics": 72,
			"morality": 46,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 184,
		"born": 162,
		"dead": 230
	},
	139: {
		"name": "金旋",
		"headImg": "res://assets/texture/profile/金旋 Jin Xuan.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 52,
			"force": 68,
			"intelligence": 13,
			"politics": 29,
			"morality": 47,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 184,
		"born": 155,
		"dead": 208
	},
	140: {
		"name": "金祎",
		"headImg": "res://assets/texture/profile/金祎 Jin Yi.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 17,
			"force": 38,
			"intelligence": 64,
			"politics": 68,
			"morality": 60,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 197,
		"born": 177,
		"dead": 218
	}
}

######### 初始剧本数据
# name 君主名称
# city_material 城池颜色
# weaponId 武器id
# armorId 防具id
# skillIds 技能id列表
#########
var characters_select = {
	0: {
		"name": '无人占领城池',
		"city_material": {
			"green_blue": false,
			"green_red": false,
			"blue_red": false,
			"blue": 1,
			"green": 1,
			"red": 1
		}
	},
	1: {
		"name": "刘备",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0.4,
			"green": 0.8,
			"red": 0.3
		},
		"headImg": "res://assets/texture/profile/刘备 Liu Bei.jpg",
		"weaponId": "0172a8c4-56fc-5f6e-c2c7-6a49d1f4f978",
		"armorId": "9758bc13-633b-b16f-adf4-37003b972b85",
		"skillIds": [
			"0602b27f-98fb-7c3b-23f0-b43a622c5476",
			"b3e63ced-2bc7-a75c-4a1c-2d9efc8d7020",
			"feb8d909-2a8b-1db4-3b54-1329f9ee1730",
			"d140202d-55d6-1709-7675-35b80263f6a6",
			"48193d31-df5a-2535-2e63-53aa517b679d",
			"e0f6c8e3-5c8a-7c9f-7b6b-9b6a4e8e8d9f",
		],
		"attrs": {
			"level": 30,
			"command": 81,
			"politics": 84,
			"force": 73,
			"intelligence": 74,
			"physical_strength": 100,
			"morality": 100,
			"speed": 80
		}
	},
	2: {
		"name": "曹操",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0.1,
			"green": 0.3,
			"red": 1
		},
		"headImg": "res://assets/texture/profile/曹操 Cao Cao.jpg",
		"weaponId": "716f6a59-c241-0f0e-831f-ed8eb2cf107b",
		"armorId": "dceaf567-ca94-2a19-01d9-efbb9844ffc6",
		"skillIds": [
			"f065ded1-72df-0d63-8479-5cc38e77bee8",
			"9ea2890f-47cf-c9c6-00a4-5218d675dae6",
			"be437047-2f70-655e-5a15-25d0f1965db8",
			"62fec892-6287-ffc9-3ace-345fd50c18a3",
			"997c2db0-2dec-a7d4-5923-75b7f9f5c500",
			"b3e63ced-2bc7-a75c-4a1c-2d9efc8d7020",
			"6d7b87b6-4023-7b80-24f8-734d583e06d7"
		],
		"attrs": {
			"level": 30,
			"command": 97,
			"politics": 94,
			"force": 71,
			"intelligence": 91,
			"physical_strength": 100,
			"morality": 96,
			"speed": 80
		}
	},
	3: {
		"name": "袁绍",
		"headImg": "res://assets/texture/profile/袁绍 Yuan Shao.jpg",
		"weaponId": "cb670c15-b222-f01c-9fa7-6173826f77c0",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"city_material": {
			"green_blue": false,
			"green_red": true,
			"blue_red": false,
			"blue": 0,
			"green": 0.3,
			"red": 0.2
		},
		"skillIds": [
			"5ec6b2fd-7559-e832-05f9-aa5be4e0c502",
			"976bce1c-7f84-0fad-f6f5-57f133e80766",
			"48193d31-df5a-2535-2e63-53aa517b679d"
		],
		"attrs": {
			"level": 40,
			"command": 81,
			"politics": 82,
			"force": 69,
			"intelligence": 70,
			"physical_strength": 100,
			"morality": 87,
			"speed": 80
		}
	},
	4: {
		"name": "孙策",
		"city_material": {
			"green_blue": false,
			"green_red": true,
			"blue_red": false,
			"blue": 0,
			"green": 0.1,
			"red": 0.4
		},
		"headImg": "res://assets/texture/profile/孙策 Sun Ce.jpg",
		"weaponId": "cb670c15-b222-f01c-9fa7-6173826f77c0",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"skillIds": [
			"3e096696-4a2c-533e-1ed6-dc5c03d88a25",
			"7e1823d0-f790-5fb1-d171-81fb6d7ca747",
			"88752da3-9ce2-7ffb-318d-fa9a8a55732b",
			"976bce1c-7f84-0fad-f6f5-57f133e80766",
			"48193d31-df5a-2535-2e63-53aa517b679d"
		],
		"attrs": {
			"level": 40,
			"command": 92,
			"politics": 70,
			"force": 92,
			"intelligence": 68,
			"physical_strength": 100,
			"morality": 90,
			"speed": 80
		}
	},
	5: {
		"name": "董卓",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0.8,
			"green": 0.1,
			"red": 0
		},
		"headImg": "res://assets/texture/profile/董卓 Dong Zhuo.jpg",
		"weaponId": "e7911e0f-5360-0b88-785e-be47f99f4680",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"skillIds": [
			"335ba8c3-916a-20e7-5a61-563202e99805",
			"a091a2c4-2033-3c31-d86c-27866f38e90d",
			"976bce1c-7f84-0fad-f6f5-57f133e80766"
		],
		"attrs": {
			"level": 50,
			"command": 81,
			"politics": 34,
			"force": 87,
			"intelligence": 69,
			"physical_strength": 100,
			"morality": 25,
			"speed": 80
		}
	},
	6: {
		"name": "刘璋",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0,
			"green": 0.6,
			"red": 1
		},
		"headImg": "res://assets/texture/profile/刘璋 Liu Zhang.jpg",
		"weaponId": "cb670c15-b222-f01c-9fa7-6173826f77c0",
		"armorId": "b06f5ac3-d5e6-32f6-90c4-659c0e78fd0e",
		"skillIds": [
			"f555fb3a-8dc8-9f15-2a39-be6555714dcf",
			"e0f6c8e3-5c8a-7c9f-7b6b-9b6a4e8e8d9f"
		],
		"attrs": {
			"level": 20,
			"command": 27,
			"politics": 68,
			"force": 31,
			"intelligence": 44,
			"physical_strength": 100,
			"morality": 84,
			"speed": 80
		}
	},
	7: {
		"name": "马腾",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 1,
			"green": 1,
			"red": 1
		},
		"headImg": "res://assets/texture/profile/马腾 Ma Teng.jpg",
		"weaponId": "8bc8766e-804f-770d-281a-600b7bcbebcb",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"skillIds": [
			"b4950dc9-1472-3a65-539a-539175e4bf4c",
			"337a5371-fd68-d7df-3565-a3e6177bb13d",
			"7e1823d0-f790-5fb1-d171-81fb6d7ca747",
			"48193d31-df5a-2535-2e63-53aa517b679d"
		],
		"attrs": {
			"level": 40,
			"command": 82,
			"politics": 59,
			"force": 80,
			"intelligence": 51,
			"physical_strength": 100,
			"morality": 89,
			"speed": 80
		},
		"has_citys": [
			"61b9c512-225d-d918-086c-e2da4edb860f",
			"95ef07b8-a83a-5216-1772-e1636cc1487b",
			"055a5ee1-332d-6889-c21a-5e06d3aa1a04"
		]
	}
}

# 公用方法
func set_name_text(name):
	return "[center][color=#91c2d5][u][url]" + name + "[/url][/u][/color]"

func set_text(str):
	return "[center][color=#91c2d5]" + str(str) + "[/color]"

func clear_children(parent: Node):
	for child in parent.get_children():
		child.queue_free()
