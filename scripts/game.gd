extends CanvasLayer

var dy_character = 0

func _ready() -> void:
	SignalBus.connect("show_city_hero_info", _on_show_city_hero_info)
	SignalBus.connect("hide_city_hero_info", _on_hide_city_hero_info)
	SignalBus.connect("hide_city_message", _on_hide_city_message)
	SignalBus.connect("select_city_for_fight_begin", _on_select_city_for_fight_begin)
	$Menu/UIAnimation.play('fade_in')

func _on_start_pressed() -> void:
	$Menu/UIAnimation.play('fade_out')
	$Menu.hide()
	$Map/CityContainer.show()
	$Map/SelectHero.show()

func _on_refuse_pressed() -> void:
	$Menu/UIAnimation.play('fade_in')
	$Menu.show()
	$Map/CityContainer.hide()
	$Map/SelectHero.hide()

func _on_decide_pressed() -> void:
	Global.is_press_select_button = true
	if(!Global.is_select_hero):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]请在左边先选择一个君主角色", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	$Map/SelectHero.hide()
	$GameUi.show()

func _on_button_pressed() -> void:
	$Map/CityMessage/HeroList/CharacterAttr.hide()

func _on_show_city_hero_info():
	$Map/CityMessage/HeroList/PopupPanel.popup()
	# $Map/CityMessage/HeroList/CharacterAttr.show()

func _on_hide_city_hero_info():
	$Map/CityMessage/HeroList/CharacterAttr.hide()

func _on_hide_city_message():
	$Map/CityMessage.hide()

func _on_texture_button_pressed() -> void:
	_on_refuse_pressed()
	$GameUi.hide()

func _on_button_deside_pressed() -> void:
	if(Global.polities_times <= 0):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]没有政令了", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	SignalBus.emit_signal("change_polities_times")
	# 关闭城市界面
	$popupTCQB/PopupPanel.hide()
	$Map/CityMessage.hide()
	# 允许查看城市界面
	Global.is_show_other_city_message = true

func _on_panel_wjyd_pressed() -> void:
	Global.save_move_jiang = []
	# 计算除了这个城市的所有其他武将列表
	var resultArray = []
	for city in Global.characters_select[Global.cur_character].citys:
		if(city != Global.cur_city):
			for jiang in Global.citys[city].curent_jiang:
				resultArray.append(jiang)
	if(!resultArray.size()):
		return
	SignalBus.emit_signal("change_wjyd_characters_ids", resultArray)
	$popupDJWJ/PopupPanel.popup()

func _on_wjyd_button_deside_pressed() -> void:
	if(Global.polities_times <= 0):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]没有政令了", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	# 找到这个编号在哪个城市，修改掉，然后塞进城市的列表中，通知城市界面更新
	for character_id in Global.save_move_jiang:
		# 从原来的城市中移除
		Global.citys[Global.characters[character_id].cityId].curent_jiang.erase(character_id)
		# 修改武将属于的城市
		Global.characters[character_id].cityId = Global.cur_city
		Global.citys[Global.cur_city].curent_jiang.append(character_id)
	SignalBus.emit_signal("change_polities_times")
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)
	$popupDJWJ/PopupPanel.hide()

# 寻找人才
func _on_xzrc_panel_pressed() -> void:
	# 按照年份获取出仕列表，将已经出仕的武将排除在外
	var jiang = findAllCharacters()
	# 这里需要深度拷贝一下，不然会影响到原数组
	var copy_jiang = jiang.duplicate(true)
	print(copy_jiang)
	for i in jiang:
		for j in Global.save_hire_jiang:
			if(i == j):
				print(j)
				copy_jiang.erase(i)
	# 拿到未出仕的武将列表
	print(copy_jiang)
	if(!copy_jiang.size()):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]野无贤才", Vector2(10, 500), message1.Direction.Up, 1, 0.5)
		return
	# 随机获取一个出仕
	var character = copy_jiang[randi() % copy_jiang.size()]
	# 打开是否出仕弹窗
	$popupCS/PopupPanel.popup()
	dy_character = character

func findAllCharacters():
	var heros_codes = []
	for i in Global.characters:
		if(Global.characters[i].name == "无人占领城池"):
			continue
		if(str(Global.characters[i].cityId) == Global.cur_city && Global.characters[i].work <= Global.year):
				heros_codes.push_back(i)
	return heros_codes

func _on_cs_button_deside_pressed() -> void:
	if(Global.polities_times <= 0):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]没有政令了", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	var message1 = preload("res://scenes/game_state.tscn").instantiate()
	$".".add_child(message1)
	message1.show_message("[color=#ffde66][center]" + Global.characters[dy_character].name + "已出仕", Vector2(10, 500), message1.Direction.Up, 1, 0.5)
	# 出仕列表数据加上这个武将
	Global.save_hire_jiang.append(dy_character)
	# 城池数据加上这个武将
	Global.citys[Global.cur_city].curent_jiang.append(dy_character)
	# 减少政令
	SignalBus.emit_signal("change_polities_times")
	# 刷新城池数据
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)

# 执行内政操作
func _on_nz_detail_panel_pressed() -> void:
	$decideMode/desidePanel/NZN/QB/TextureRect.show()
	$decideMode/desidePanel/NZN/WJYD/TextureRect.hide()
	$decideMode/desidePanel/NZN/XZRC/TextureRect.hide()
	$decideMode/desidePanel/NZN/List.hide()
	$decideMode/desidePanel/NZN/battle.hide()
	# 获取全部选择主公势力下的武将
	var allCharacters = []
	for city in Global.characters_select[Global.cur_character].citys:
		var characters = Global.citys[city].curent_jiang
		for character in characters:
			# 获取到每一个武将的属性，判断执行倾向
			var bing = Global.characters[character].attrs.bing
			# 武将的兵力满员时，执行内政操作
			if(bing >= Global.get_bing_by_command(Global.characters[character].attrs.command)):
				allCharacters.append(character)
	# 支持内政操作的武将
	SignalBus.emit_signal("change_wjyd_characters_ids", allCharacters)
	SignalBus.emit_signal("change_character_list_scroller_width", 522)
	$decideMode/desidePanel/NZN/List.show()

# 执行军队操作
func _on_jdpy_panel_pressed() -> void:
	$decideMode/desidePanel/NZN/QB/TextureRect.hide()
	$decideMode/desidePanel/NZN/WJYD/TextureRect.show()
	$decideMode/desidePanel/NZN/XZRC/TextureRect.hide()
	$decideMode/desidePanel/NZN/List.hide()
	$decideMode/desidePanel/NZN/battle.hide()
	# 获取全部选择主公势力下的武将
	var allCharacters = []
	for city in Global.characters_select[Global.cur_character].citys:
		var characters = Global.citys[city].curent_jiang
		for character in characters:
			# 获取到每一个武将的属性，判断执行倾向
			var bing = Global.characters[character].attrs.bing
			# 武将的兵力未满员时，执行征兵操作
			if(bing < Global.get_bing_by_command(Global.characters[character].attrs.command)):
				allCharacters.append(character)
	# 支持内政操作的武将
	SignalBus.emit_signal("change_wjyd_characters_ids", allCharacters)
	SignalBus.emit_signal("change_character_list_scroller_width", 522)
	$decideMode/desidePanel/NZN/List.show()

# 进行军事侵略
func _on_gcld_panel_pressed() -> void:
	$decideMode/desidePanel/NZN/QB/TextureRect.hide()
	$decideMode/desidePanel/NZN/WJYD/TextureRect.hide()
	$decideMode/desidePanel/NZN/XZRC/TextureRect.show()
	$decideMode/desidePanel/NZN/List.hide()
	# 打开武将列表、城市列表。
	$decideMode/desidePanel/NZN/battle.show()
	# 获取全部选择主公势力下的武将
	#var allCharacters = []
	#for city in Global.characters_select[Global.cur_character].citys:
		#var characters = Global.citys[city].curent_jiang
		#for character in characters:
			#allCharacters.append(character)
	
	SignalBus.emit_signal("change_citys_selcet")
	SignalBus.emit_signal("change_character_list_scroller_width", 200)
	# 支持内政操作的武将
	#SignalBus.emit_signal("change_wjyd_characters_ids", allCharacters)
	#SignalBus.emit_signal("change_character_list_scroller_width", 200)

func _on_select_city_for_fight_begin():
	$decideMode/desidePanel/NZN/battle/List.show()
	$decideMode/desidePanel/NZN/battle/CityList.show()
