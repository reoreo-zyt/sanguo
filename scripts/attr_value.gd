extends VBoxContainer

@export var character_id = 15
@export var is_select = false

func _ready() -> void:
	var character = Global.characters[character_id]
	$Button/HBoxContainer/RichTextLabel.text = Global.set_name_text(character.name)
	# 计算武将所属势力
	$Button/HBoxContainer/RichTextLabel2.text = Global.set_text(search_lord(character_id))
	$Button/HBoxContainer/RichTextLabel3.text = Global.citys[character.cityId].name
	$Button/HBoxContainer/RichTextLabel4.text = Global.set_text(character.attrs.force)
	$Button/HBoxContainer/RichTextLabel5.text = Global.set_text(character.attrs.command)
	$Button/HBoxContainer/RichTextLabel6.text = Global.set_text(character.attrs.intelligence)
	$Button/HBoxContainer/RichTextLabel7.text = Global.set_text(character.attrs.politics)
	$Button/HBoxContainer/RichTextLabel8.text = Global.set_text(character.attrs.lorty)

func search_lord(character_id):
	var city_id = Global.characters[character_id].cityId
	var ownerId = int(Global.citys[city_id].ownerId)
	var ownerName = Global.characters_select[ownerId].name
	return ownerName


func _on_button_pressed() -> void:
	is_select = !is_select
	$Button.flat = !$Button.flat
	# 保存一份已选择的武将数组
	if(is_select):
		Global.save_move_jiang.append(character_id)
	else:
		Global.save_move_jiang.erase(character_id)
