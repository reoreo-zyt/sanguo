extends TextureButton

@export var city_name = ""
@export var city_id = ""
@export var recover_select = false

func _ready() -> void:
	$RichTextLabel.text = Global.set_message_name(city_name)

func _process(delta: float) -> void:
	if recover_select:
		$Panel.hide()
		recover_select = false

func _on_pressed() -> void:
	Global.cur_city = city_id
	# 定位到地图的位置
	SignalBus.emit_signal("focus_map_city", city_id)
	$Panel.show()
	SignalBus.emit_signal("recover_city_select")
