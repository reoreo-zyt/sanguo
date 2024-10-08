extends Node2D

var character_item = preload("res://prefebs/Characters/character_item.tscn")
var save_nodes = []

func _ready() -> void:
	SignalBus.connect("open_characters_list", _on_open_characters_list)

func _on_open_characters_list(city_id):
	$".".show()
	for node in save_nodes:
		$Main/Panel/ScrollContainer/VBoxContainer.remove_child(node)
		save_nodes = []
	for character in Global.citys[city_id].curent_jiang:
		var character_instance = character_item.instantiate()
		character_instance.character_id = character
		$Main/Panel/ScrollContainer/VBoxContainer.add_child(character_instance)
		save_nodes.append(character_instance)

func _on_fold_pressed() -> void:
	$".".hide()
