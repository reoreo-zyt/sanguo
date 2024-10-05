####
## 一些常用的方法
####

extends Node

# 返回数组的随机一项
func get_random_item(array, attr):
	return array[randi() % array.size()][attr]
