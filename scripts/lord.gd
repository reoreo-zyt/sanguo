extends Panel

@export var lord_name = ""
@export var is_self = true
@export var character_id = 0

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
	
	SignalBus.connect("change_curr_fight_character_id", _on_change_curr_fight_character_id)
	SignalBus.connect("close_before_fight_character_id", _on_close_before_fight_character_id)

func _on_change_curr_fight_character_id(id):
	if(character_id == id):
		$Attack.show()
		$Move.show()
		$End.show()
		$Attr.show()

func _on_button_pressed() -> void:
	SignalBus.emit_signal("change_next_fight_character_id")

func _on_close_before_fight_character_id(id):
	if(character_id == id):
		$Attack.hide()
		$Move.hide()
		$End.hide()
		$Attr.hide()
