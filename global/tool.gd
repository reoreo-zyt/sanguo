####
## 一些常用的方法
####

extends Node

# 返回数组的随机一项
func get_random_item(array, attr):
	return array[randi() % array.size()][attr]

# 生成随机值
func get_random_num(min, max):
	var rng = RandomNumberGenerator.new()
	return rng.randi_range(min, max)

# 通过位置计算像素位置
func calc_px(position, gird_width = 238, gird_height = 208):
	var width = 0
	var height = 0
	# 计算(0, 0)
	if(position[0] == 0):
		width = gird_width / 2
		height = gird_height / 2 + position[1] * gird_height
		return Vector2(width, height)
	# 计算偶数列
	if(position[0] % 2 == 0):
		width = (gird_width / 2) + (gird_width * (position[0] / 2)) + ((gird_width / 2) * (position[0] / 2))
		height = gird_height / 2 + position[1] * gird_height
		return Vector2(width, height)
	# 计算奇数列
	if(position[0] == 1):
		width = gird_width / 4 + gird_width - (gird_width / 2) + gird_width / 2
		height = gird_height + position[1] * gird_height
		return Vector2(width, height)
	else:
		width = (gird_width / 4 + gird_width - (gird_width / 2) + gird_width / 2) + ((gird_width * (position[0] / 2)) + ((gird_width / 2) * (position[0] / 2)))
		height = gird_height + position[1] * gird_height
		return Vector2(width, height)
	return null
