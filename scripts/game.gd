extends CanvasLayer

func _ready() -> void:
	SignalBus.connect("show_city_hero_info", _on_show_city_hero_info)
	SignalBus.connect("hide_city_hero_info", _on_hide_city_hero_info)
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
	$Map/SelectHero/Menu.hide()
	$Map/SelectHero/CharacterSelect.hide()
	$Map/SelectHero/MarginContainer.hide()

func _on_button_pressed() -> void:
	$Map/CityMessage/HeroList/CharacterAttr.hide()

func _on_show_city_hero_info():
	$Map/CityMessage/HeroList/CharacterAttr.show()

func _on_hide_city_hero_info():
	$Map/CityMessage/HeroList/CharacterAttr.hide()
