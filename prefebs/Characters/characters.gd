extends Node2D

var character_item = preload("res://prefebs/Characters/character_item.tscn")
var save_nodes = []
@export var is_show_city = true
@export var jiangs = [43]
var is_open = true

func _ready() -> void:
	SignalBus.connect("open_characters_list", _on_open_characters_list)

func _on_open_characters_list(city_id):
	open_panel()
	for node in save_nodes:
		$Main/Panel/ScrollContainer/VBoxContainer.remove_child(node)
		save_nodes = []
	if(is_show_city):
		for character in Global.citys[city_id].curent_jiang:
			var character_instance = character_item.instantiate()
			character_instance.character_id = character
			$Main/Panel/ScrollContainer/VBoxContainer.add_child(character_instance)
			save_nodes.append(character_instance)
	else:
		for character in jiangs:
			var character_instance = character_item.instantiate()
			character_instance.character_id = character
			character_instance.is_show_city = false
			$Main/Panel/ScrollContainer/VBoxContainer.add_child(character_instance)
			save_nodes.append(character_instance)
	if(!is_show_city):
		$Main/Panel/Attr/Event.text = "位置"

func _on_fold_pressed() -> void:
	is_open = !is_open
	if(!is_open):
		$BG.hide()
		$Main.hide()
		$Fold.position = Vector2(950, 313)
	else:
		open_panel()

func open_panel():
	$BG.show()
	$Main.show()
	$Fold.position = Vector2(950, -66)
