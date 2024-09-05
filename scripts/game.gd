extends CanvasLayer

func _ready() -> void:
	SignalBus.connect("show_city_hero_info", _on_show_city_hero_info)
	SignalBus.connect("hide_city_hero_info", _on_hide_city_hero_info)
	SignalBus.connect("hide_city_message", _on_hide_city_message)
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
	$Map/CityMessage/HeroList/CharacterAttr.show()

func _on_hide_city_hero_info():
	$Map/CityMessage/HeroList/CharacterAttr.hide()

func _on_hide_city_message():
	$Map/CityMessage.hide()

func _on_texture_button_pressed() -> void:
	_on_refuse_pressed()
	$GameUi.hide()
