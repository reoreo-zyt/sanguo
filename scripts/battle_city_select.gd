extends RichTextLabel

@export var city_name = ""
@export var city_id = ""

func _ready() -> void:
	$".".text = city_name

func _on_meta_clicked(meta: Variant) -> void:
	SignalBus.emit_signal("select_city_for_fight_begin", city_id)
