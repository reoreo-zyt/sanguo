extends Control

var arrtValue = preload("res://scenes/attr_value.tscn")
var character_instances = []

func _ready() -> void:
	SignalBus.connect("change_character_list_scroller_width", _on_change_character_list_scroller_width)
	SignalBus.connect("change_wjyd_characters_ids", _on_change_wjyd_characters_ids)

func _on_change_wjyd_characters_ids(character_ids):
	if(character_instances.size()):
		for i in character_instances:
			i.queue_free()
		character_instances = []
	for i in character_ids:
		var arrtValueInstance = arrtValue.instantiate()
		arrtValueInstance.character_id = i
		character_instances.append(arrtValueInstance)
		$ScrollContainer/MarginContainer/VBoxContainer/AttrKey.add_child(arrtValueInstance)

func _on_change_character_list_scroller_width(x):
	$ScrollContainer.size.x = x
