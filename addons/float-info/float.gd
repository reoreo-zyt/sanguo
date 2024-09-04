extends Marker2D


func show_info(
	_info: String,
	_start_position: Vector2,
	_timer: float = 1.5,
	_color: Color = Color(1, 0, 0),
	_scene: Node = null
) -> void:
	if not is_instance_valid(_scene):
		return
	var info = preload( "res://addons/float-info/info.tscn" ).instantiate()
	_scene.add_child(info)
	info.position = _start_position
	info.modulate = _color
	info.show_info( _info, _timer )
