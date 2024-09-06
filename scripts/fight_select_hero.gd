extends HBoxContainer

@export var name_text = ""
@export var name_id = ""
@export var is_select_self = true
@export var is_select = false

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	$Label.text = name_text
	pass # Replace with function body.
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_check_box_pressed() -> void:
	is_select = !is_select
	SignalBus.emit_signal("select_hero_list", is_select_self)
