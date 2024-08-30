extends Panel

func _ready():
	SignalBus.connect("show_city_info", _on_show_city_info)
	
func _on_close_pressed() -> void:
	$".".hide()

func _on_show_city_info(text):
	$CityMessage/CityPanel/RichTextLabel.text = "[center][color=#91c2d5][u][url]" + text + "[/url][/u][/color] "
