extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var button = preload("res://scenes/GameMain/button.tscn")
var character_message = preload("res://prefebs/Characters/Characters.tscn")

func _ready() -> void:
	set_year_month(false)
	$CanvasLayer/Main/Top/TextureRect/RichTextLabel.text = "势力：" + Global.characters[int(Global.cur_hero_id)].name

	var character_attr_instance = character_attr.instantiate()
	character_attr_instance.name_id = int(Global.cur_hero_id)
	character_attr_instance.is_show_attr = true
	character_attr_instance.is_fold = true
	$CanvasLayer/Main/Control.add_child(character_attr_instance)
	
	var button_instance = button.instantiate()
	button_instance.position = Vector2(0, 52)
	$CanvasLayer/Main/Control.add_child(button_instance)
	
	var character_message_instance = character_message.instantiate()
	character_message_instance.position = Vector2(-58, 550)
	$CanvasLayer/Main/Control.add_child(character_message_instance)
	character_message_instance.hide()

func _on_dectation_pressed() -> void:
	SignalBus.emit_signal("return_start")

func calc_jin(event_type):
	return Global.characters_event[event_type].cost.jin

func _on_next_pressed() -> void:
	# 开始下一个月
	# 超过限制不进行
	if(!Global.is_finish_next):
		return
	# 开始计算每个城市的下月的收益
	for city in Global.citys:
		var cost_jin = 0
		var curent_jiang = Global.citys[city].curent_jiang
		for jiang in curent_jiang:
			var event_type = Global.characters[jiang].event_type
			var politics = Global.characters[jiang].attrs.politics
			var command = Global.characters[jiang].attrs.command
			if(event_type == 0):
				break
			if(event_type == 1):
				cost_jin += calc_jin(event_type)
				Global.citys[city].shang += round(politics * Tool.get_random_num(1, 10) * 0.2)
			if(event_type == 2):
				cost_jin += calc_jin(event_type)
				Global.citys[city].nong += round(politics * Tool.get_random_num(1, 10) * 0.2)
			if(event_type == 3):
				cost_jin += calc_jin(event_type)
				Global.citys[city].ren += round(politics * Tool.get_random_num(10, 20))
			if(event_type == 4):
				cost_jin += calc_jin(event_type)
				Global.citys[city].zhi += round(politics * Tool.get_random_num(1, 2) * 0.1)
			if(event_type == 5):
				cost_jin += calc_jin(event_type)
				Global.characters[jiang].attrs.bing += round(command * Tool.get_random_num(4, 8))
				if(Global.characters[jiang].attrs.max_bing <= Global.characters[jiang].attrs.bing):
					Global.characters[jiang].attrs.bing = Global.characters[jiang].attrs.max_bing
			if(event_type == 6):
				var stay_characters = []
				# 搜索当前城市，如果有在野武将，则随机取一个出仕
				# 已经出仕列表
				var characters = Global.findAllCharacters(city, Global.hero_data, Global.year)
				for cha in characters:
					if(!Global.save_hire_jiang.has(cha)):
						stay_characters.append(cha)
				if(stay_characters.size() != 0):
					var random = stay_characters[randi() % stay_characters.size()]
					Global.citys[Global.cur_city].curent_jiang.append(random)
					Global.save_hire_jiang.append(random)
		Global.citys[city].jin -= cost_jin
		# 开始计算每一年的收益
		var cur_city = Global.citys[city]
		if(Global.month == 1):
			cur_city.jin += round(200 + (cur_city.shang / 200) + (cur_city.ren / 30000))
			cur_city.liang += round(200 + (cur_city.nong / 200) * (cur_city.ren / 30000))

	SignalBus.emit_signal("recover_city_select")
	SignalBus.emit_signal("open_characters_list", Global.cur_city)
	set_year_month(true)

func set_year_month(is_add):
	if(is_add):
		Global.month += 1
		if(Global.month >= 12):
			Global.month = 1
			Global.year += 1
	$CanvasLayer/Main/Top/TimeControl/TimeLabel.text = "[center]" + str(Global.year) + " 年 " + str(Global.month) + " 月 "
