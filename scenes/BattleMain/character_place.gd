extends Node2D

var character_item_slice = preload("res://scenes/BattleMain/character_item.tscn")

func _ready() -> void:
	var slices = [
		Vector2i(0, 0), Vector2i(0, 1), Vector2i(0, 2), Vector2i(0, 3), Vector2i(0, 4),
		Vector2i(1, 0), Vector2i(1, 1), Vector2i(1, 2), Vector2i(1, 3), Vector2i(1, 4),
	]
	var color = Color(0.281, 0.703, 0.94, 0.838)
	var colors:PackedColorArray = [color, color, color, color, color, color, color]

	for slice in slices:
		var character_item_slice_instance = character_item_slice.instantiate()
		var position = calc_px(slice)
		character_item_slice_instance.width = position[0]
		character_item_slice_instance.height = position[1]
		character_item_slice_instance.length = 116
		character_item_slice_instance.colors = colors
		$".".add_child(character_item_slice_instance)

# 通过位置计算像素位置
func calc_px(position, gird_width = 238, gird_height = 208):
	var width = 0
	var height = 0
	if(position[0] % 2 == 0):
		width = gird_width / 2 + position[0] * gird_width
		height = gird_height / 2 + position[1] * gird_height
	else:
		width = gird_width / 4 + position[0] * gird_width
		height = gird_height + position[1] * gird_height
	return Vector2(width, height)
