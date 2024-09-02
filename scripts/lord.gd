extends Panel

@export var lord_name = ""
@export var is_self = true

var stylebox = StyleBoxFlat.new()

func _ready() -> void:
	$force.texture = load("res://assets/texture/force/" + lord_name + ".png")
	stylebox.border_width_left = 4
	stylebox.border_width_right = 4
	stylebox.border_width_top = 4
	stylebox.border_width_bottom = 4
	if(is_self):
		stylebox.border_color = "#a8d6f5"
	else:
		stylebox.border_color = "#cc1a2d"
	$".".add_theme_stylebox_override("panel", stylebox)
