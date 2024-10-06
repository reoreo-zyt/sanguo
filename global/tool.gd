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
