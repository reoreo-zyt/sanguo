@tool
extends Control

# Distance of the children elements to the center of the circle
@export var radius: float = 100.0:
	set(new_value):
		radius = new_value
		if is_node_ready():
			place_elements(get_items(), radius, element_size, spacing_factor)

# Adjust the size of all children
@export var element_size: float = 40.0:
	set(new_value):
		element_size = new_value
		place_elements(get_items(), radius, element_size, spacing_factor)

# Factor to adjust the spacing of the elements
@export_range(0, 1) var spacing_factor: float = 1.0:
	set(new_value):
		spacing_factor = new_value
		place_elements(get_items(), radius, element_size, spacing_factor)

@export_group("Rotation")

# Speed at which the children elements rotate
@export var rotation_speed: float = 0.0:
	set(new_value):
		rotation_speed = new_value
		set_process(rotation_speed != 0.0 or static_rotation)
		if rotation_speed == 0.0 and not static_rotation:
			rotation = 0.0
			reset_child_rotations()

# If true, all children will always be upright regardless of the rotation of the parent
@export var keep_upright: bool = true:
	set(new_value):
		keep_upright = new_value
		if new_value:
			for child in get_children():
				if child is Control:
					child.pivot_offset = child.size / 2.0
		else:
			reset_child_rotations()

# Preview the rotation of the children with this option
@export var editor_preview: bool = true:
	set(new_value):
		editor_preview = new_value
		if rotation_speed != 0.0 or static_rotation:
			set_process(true)
		if not new_value:
			set_process(false)
			rotation = 0.0
			reset_child_rotations()

# If true, applies a static rotation to the children
@export var static_rotation: bool = false:
	set(new_value):
		static_rotation = new_value
		place_elements(get_items(), radius, element_size, spacing_factor)
		set_process(static_rotation or rotation_speed != 0.0)
		if not static_rotation and rotation_speed == 0.0:
			rotation = 0.0
			reset_child_rotations()

func reset_child_rotations():
	for item in get_items():
		item.rotation = 0.0

func get_items():
	var items: Array[CanvasItem] = []
	for node in get_children():
		if node is CanvasItem:
			items.append(node)
	return items

func _ready():
	pivot_offset = size * 0.5
	child_order_changed.connect(place_elements)
	resized.connect(place_elements)
	place_elements()

func _process(delta):
	if not editor_preview and Engine.is_editor_hint():
		set_process(false)
		rotation = 0.0
		for i in get_children():
			i.rotation = 0.0
	if rotation_speed != 0.0:
		rotation += rotation_speed * delta
	if static_rotation:
		rotation = -rotation_speed * PI  # Arbitrary static rotation value, adjust as needed
	if keep_upright:
		for child in get_children():
			if child is CanvasItem or child is Control or child is Node2D:
				child.rotation = -rotation

func place_elements(items: Array[CanvasItem] = get_items(), _radius: float = radius, _element_size: float = element_size, _spacing_factor: float = spacing_factor):
	pivot_offset = size * 0.5
	var step: float = (PI * 2.0) / items.size() * _spacing_factor
	var angle: float = 0.0
	for node in items:
		if node is Control:
			node.size = Vector2(_element_size, _element_size)
			node.pivot_offset = node.size / 2.0
			node.position = (Vector2.RIGHT * _radius).rotated(angle) - node.size * 0.5 + pivot_offset
		else:
			node.position = (Vector2.RIGHT * _radius).rotated(angle) + pivot_offset
		angle += step
	if static_rotation and keep_upright:
		for node in items:
			node.rotation = -angle
