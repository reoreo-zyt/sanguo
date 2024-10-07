extends Camera2D

# 相机的当前缩放值
var zoom_value = 1.0
# 鼠标按下的位置
var press_pos = Vector2(0, 0)
# 相机位置
var camera_pos = Vector2(0, 0)
var pre_city = ""

func _ready() -> void:
	SignalBus.connect("focus_map_city", _on_focus_map_city)

func _input(event):
	if event is InputEventMouseButton:
		if event.button_index == 4:
			zoom(1)
		elif event.button_index == 5:
			zoom(-1)
	# TODO 此处移动尚有问题，不能
	if event is InputEventScreenTouch:
		press_pos = event.position
		camera_pos = $".".position
	if event is InputEventScreenDrag:
		var mouse_offset = event.position - press_pos
		if(zoom_value != 1):
			$".".position = camera_pos - mouse_offset

# 缩放相机的函数
func zoom(zoom_direction):
	# 计算新的缩放值
	zoom_value += zoom_direction * 0.1 # 假设每次缩放增加或减少0.1
	# 确保缩放值不低于1.0
	zoom_value = max(zoom_value, 1.0)
	if(zoom_value == 1):
		$".".position = Vector2(960, 540)
	# 设置相机的缩放
	set_zoom(Vector2(zoom_value, zoom_value))
	# 城市也会跟着变大变小，使用 CanvasLayer 固定的话会导致位置变动
	# 直接改变里面的城市UI大小
	SignalBus.emit_signal("change_city_size", zoom_value)

func _on_focus_map_city(city_id):
	if(city_id != pre_city):
		zoom(4)
		$".".position = Vector2(Global.citys[city_id].position_x, Global.citys[city_id].position_y)
	pre_city = city_id
