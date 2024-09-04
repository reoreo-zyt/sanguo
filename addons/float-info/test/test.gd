extends Control


func _ready() -> void:
	for i in range(0, 30):
		GFloatInfo.show_info(str(i), Vector2(400, 400))
		await get_tree().create_timer(0.8).timeout
