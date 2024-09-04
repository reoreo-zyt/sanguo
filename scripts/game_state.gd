extends Control

# 动画方向
enum Direction {
	Left,
	Right,
	Up,
	Down,
}

# 参数分别是
# content - 内容
# postion - 位置
# direction - 飞入方向
# duration - 动画时长
# timeout - 消失时长
func show_message(content: String, position: Vector2, direction: Direction = Direction.Right, duration: float = 1, timeout: float = 1):
	$Content.text = content # 设置消息内容

	var screen = get_viewport_rect().size # 获得屏幕大小

	# 计算飞入方向
	var initial_position = position
	match direction:
		Direction.Left:
			initial_position.x = - self.size.x
		Direction.Right:
			initial_position.x = screen.x + self.size.x
		Direction.Up:
			initial_position.y = screen.y + self.size.y
		Direction.Down:
			initial_position.y = - self.size.y

	# 设则 Message 节点 初始位置 （屏幕外）
	self.position = initial_position

	# 创建动画
	var tween = create_tween()
	tween.tween_property(self, "position", position, duration)

	# 创建计时器，让消息消失
	var timer: Timer = Timer.new()
	self.add_child(timer)

	# 计时器结束后触发
	timer.timeout.connect(_on_timer_timeout)
	# 循环一次
	timer.one_shot = true
	# 触发计时器
	timer.start(duration + timeout)

# 计时器结束后，删除节点
func _on_timer_timeout():
	self.queue_free()
