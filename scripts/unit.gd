extends CharacterBody2D

@export var speed = 100
var av = Vector2.ZERO
var avoid_weight = 0.1
var target_radius = 50
var selected = false:
	set = set_selected
var target = null:
	set = set_target

func set_selected(value):
	selected = value
	if selected:
		$Sprite2D.self_modulate = Color.AQUA;
	else:
		$Sprite2D.self_modulate = Color.WHITE;

func set_target(value):
	target = value

func avoid():
	var result = Vector2.ZERO
	var neighbors = $Detect.get_overlapping_bodies()
	if neighbors:
		for n in neighbors:
			result += n.position.direction_to(position)
		result /= neighbors.size()
	return result.normalized()

func _physics_process(delta):
	velocity = Vector2.ZERO
	if target != null:
		velocity = position.direction_to(target)
		if position.distance_to(target) < target_radius:
			target = null
	av = avoid()
	velocity = (velocity + av * avoid_weight).normalized() * speed
	move_and_collide(velocity * delta)
