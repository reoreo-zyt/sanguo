extends Node2D

var character_item_slice = preload("res://scenes/BattleMain/character_item.tscn")

func _ready() -> void:
	var slices = [
		 Vector2i(0, 0), Vector2i(0, 1), Vector2i(0, 2), Vector2i(0, 3), Vector2i(0, 4),
		Vector2i(1, 0), Vector2i(1, 1), Vector2i(1, 2), Vector2i(1, 3), Vector2i(1, 4),
		 #Vector2i(2, 0), Vector2i(2, 1), Vector2i(2, 2), Vector2i(2, 3), Vector2i(2, 4),
		#Vector2i(3, 0), Vector2i(3, 1), Vector2i(3, 2), Vector2i(3, 3), Vector2i(3, 4),
		 #Vector2i(4, 0), Vector2i(4, 1), Vector2i(4, 2), Vector2i(4, 3), Vector2i(4, 4),
		#Vector2i(5, 0), Vector2i(5, 1), Vector2i(5, 2), Vector2i(5, 3), Vector2i(5, 4),
		 #Vector2i(6, 0), Vector2i(6, 1), Vector2i(6, 2), Vector2i(6, 3), Vector2i(6, 4),
		#Vector2i(7, 0), Vector2i(7, 1), Vector2i(7, 2), Vector2i(7, 3), Vector2i(7, 4),
		 #Vector2i(8, 0), Vector2i(8, 1), Vector2i(8, 2), Vector2i(8, 3), Vector2i(8, 4),
		#Vector2i(9, 0), Vector2i(9, 1), Vector2i(9, 2), Vector2i(9, 3), Vector2i(9, 4),
		 #Vector2i(10, 0), Vector2i(10, 1), Vector2i(10, 2), Vector2i(10, 3), Vector2i(10, 4),
	]
	var color = Color(0.281, 0.703, 0.94, 0.838)
	var colors:PackedColorArray = [color, color, color, color, color, color, color]

	for slice in slices:
		var character_item_slice_instance = character_item_slice.instantiate()
		var position = Tool.calc_px(slice)
		character_item_slice_instance.width = position[0]
		character_item_slice_instance.height = position[1]
		character_item_slice_instance.length = 116
		character_item_slice_instance.colors = colors
		$".".add_child(character_item_slice_instance)
