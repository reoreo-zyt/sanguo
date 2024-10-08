extends Panel

var is_fold = false
var city_item = preload("res://prefebs/CityDetail/city_item.tscn")

var city_item_instances = []

func _ready() -> void:
	city_item_instances = []
	SignalBus.connect("recover_city_select", _on_recover_city_select)
	# 获取到所有城市
	for city_number in Global.characters_select[int(Global.cur_hero_id)].citys:
		var city_item_instance = city_item.instantiate()
		var city_name = Global.citys[city_number].name
		city_item_instance.city_name = city_name
		city_item_instance.city_id = city_number
		$Main/Panel/ScrollContainer/VBoxContainer.add_child(city_item_instance)
		city_item_instances.append(city_item_instance)

func _on_fold_pressed() -> void:
	is_fold = !is_fold
	if(is_fold):
		$BG.hide()
		$Main.hide()
		$Fold.position = Vector2(625, -34)
	else:
		$BG.show()
		$Main.show()
		$Fold.position = Vector2(-64, -34)

func _on_recover_city_select():
	# 更新下数据
	var city = Global.citys[Global.cur_city]
	$Main/Zhu/RichTextLabel.text = str(Global.characters[int(city.ownerId)].name)
	$Main/Tong/RichTextLabel.text = str(city.tong)
	$Main/Ren/RichTextLabel.text = str(city.ren)
	$Main/Jiang/RichTextLabel.text = Global.set_name_text(str(city.curent_jiang.size()))
	$Main/Bing/RichTextLabel.text = str(calc_bing())
	$Main/Kai/RichTextLabel.text = str(city.nong)
	$Main/Shang/RichTextLabel.text = str(city.shang)
	$Main/Zhi/RichTextLabel.text = str(city.zhi)
	$Main/Jin/RichTextLabel.text = str(city.jin)
	$Main/Liang/RichTextLabel.text = str(city.liang)
	for city_item_instance in city_item_instances:
		if(Global.cur_city != city_item_instance.city_id):
			city_item_instance.recover_select = true

func calc_bing():
	var city = Global.citys[Global.cur_city]
	var num = 0
	for jiang in city.curent_jiang:
		num += Global.characters[jiang].attrs.bing
	return num

func _on_rich_text_label_meta_clicked(meta: Variant) -> void:
	SignalBus.emit_signal("open_characters_list", Global.cur_city)
