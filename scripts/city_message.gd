extends Panel

func _ready():
	SignalBus.connect("show_city_info", _on_show_city_info)

func _on_close_pressed() -> void:
	Global.is_show_other_city_message = false
	$".".hide()

func _on_show_city_info(name, cityId):
	if(Global.is_show_other_city_message):
		$NZN.hide()
	else:
		$NZN.show()
	# print(name)
	var city_data = Global.citys[cityId]
	$CityMessage/CityPanel/RichTextLabel.text = "[center][color=#91c2d5][u][url]" + name + "[/url][/u][/color]"
#	TODO: bug 消息悬浮框无法消失
	$CityMessage/MasterPanel/RichTextLabel.text = set_color(Global.characters[int(city_data.lordId)].name)
	$CityMessage/TongPanel/RichTextLabel.text = set_color(city_data.tong)
	$CityMessageMore/ScrollContainer/VBoxContainer/RenContainer/RenPanel/RichTextLabel.text = set_color(city_data.ren)
	$CityMessageMore/ScrollContainer/VBoxContainer/JiangContainer/JangPanel/RichTextLabel.text = set_color(city_data.curent_jiang.size())
	$CityMessageMore/ScrollContainer/VBoxContainer/BingContainer/BingPanel/RichTextLabel.text = set_color(city_data.bing)
	$CityMessageMore/ScrollContainer/VBoxContainer/KaiContainer/KaiPanel/RichTextLabel.text = set_color(city_data.nong)
	$CityMessageMore/ScrollContainer/VBoxContainer/ShangContainer/ShangPanel/RichTextLabel.text = set_color(city_data.shang)
	$CityMessageMore/ScrollContainer/VBoxContainer/ShangContainer/ShangPanel/RichTextLabel.text = set_color(city_data.shang)
	$CityMessageMore/ScrollContainer/VBoxContainer/ZhiContainer/ZhiPanel/RichTextLabel.text = set_color(city_data.zhi)
	$CityMessageMore/ScrollContainer/VBoxContainer/JinContainer/JinPanel/RichTextLabel.text = set_color(city_data.jin)
	$CityMessageMore/ScrollContainer/VBoxContainer/LiangContainer/LiangPanel/RichTextLabel.text = set_color(city_data.liang)

func set_color(str):
	return "[center][color=#91c2d5]" + str(str) + "[/color]"
