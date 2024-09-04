extends Marker2D


@onready var info = $Info

var velocity = Vector2.ZERO
var gravity = Vector2.RIGHT
var mass = 50


func _ready():
	set_physics_process(false)


func _physics_process(_delta: float) -> void:
	velocity += gravity * mass * _delta
	position += velocity * _delta
	position.x += 24 * _delta


func show_info(_info: String, _timer: float) -> void:
	var tween: Tween = get_tree().create_tween()
	info.text = _info
	set_physics_process(true)
	tween.tween_property(
		self,
		"modulate.a",
		0,
		_timer
	)
	tween.tween_property(
		self,
		"scale",
		Vector2(0.4, 0.4),
		_timer
	)
	await tween.finished
	queue_free()
