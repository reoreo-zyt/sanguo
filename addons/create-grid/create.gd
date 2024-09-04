class_name CreateGrid
extends Node


## 模式
enum CREATE_GRID_MODE {
	## 十字
	CROSS,
	## 范围
	RANGE,
	## 倾斜十字，就是 X 字形
	TILE_CROSS,
	## 倾斜范围，就是菱形
	TILE_RANGE
}


## 生成格子
## 需要传入几个参数
## 1.生成模式
## 2.步长
## 3.忽略值
## 4.偏移量
func create_grid(_mode: CREATE_GRID_MODE, _step: int, _ignores: Array = [], _offset: Vector2 = Vector2.ZERO) -> PackedVector2Array:
	var result: PackedVector2Array = []
	match _mode:
		CREATE_GRID_MODE.CROSS:
			for index in range(1, _step + 1):
				# 如果是要忽略的步数
				if _ignores.find(index) != -1:
					continue
				result.push_back(index * Vector2.UP)
				result.push_back(index * Vector2.LEFT)
				result.push_back(index * Vector2.DOWN)
				result.push_back(index * Vector2.RIGHT)
			result.push_back(Vector2(0, 0))
		
		CREATE_GRID_MODE.RANGE:
			# 当前的结果的字典
			# 初始化一个 0，0
			var dic: Dictionary = { 
				Vector2(0, 0): null
			}
			var all: Dictionary = {
				Vector2(0, 0): null
			}
			result.push_back(Vector2(0, 0))
			var flood_call: Callable = func (_positions: Dictionary) -> Dictionary:
				var res: Dictionary
				for index in _positions:
					res[index + Vector2.UP] = null
					res[index + Vector2.LEFT] = null
					res[index + Vector2.DOWN] = null
					res[index + Vector2.RIGHT] = null
					res[index + Vector2(1, 1)] = null
					res[index + Vector2(-1, 1)] = null
					res[index + Vector2(1, -1)] = null
					res[index + Vector2(-1, -1)] = null
				return res
			
			for index in range(1, _step + 1):
				var res: Dictionary = flood_call.call(dic)
				# 合并
				var new: Dictionary
				for key in res:
					if not all.has(key):
						new[key] = null
						all[key] = null
						# 如果是要忽略的步数
						# 就不添加加入到结果中
						if _ignores.find(index) == -1:
							result.push_back(key)
				dic = new
		
		CREATE_GRID_MODE.TILE_CROSS:
			for index in range(1, _step + 1):
				# 如果是要忽略的步数
				if _ignores.find(index) != -1:
					continue
				result.push_back(index * Vector2(1, 1))
				result.push_back(index * Vector2(-1, 1))
				result.push_back(index * Vector2(1, -1))
				result.push_back(index * Vector2(-1, -1))
			result.push_back(Vector2(0, 0))
		
		CREATE_GRID_MODE.TILE_RANGE:
			# 当前的结果的字典
			# 初始化一个 0，0
			var dic: Dictionary = {
				Vector2(0, 0): null
			}
			var all: Dictionary = {
				Vector2(0, 0): null
			}
			result.push_back(Vector2(0, 0))
			
			var flood_call: Callable = func (_positions: Dictionary) -> Dictionary:
				var res: Dictionary
				for index in _positions:
					res[index + Vector2.UP] = null
					res[index + Vector2.LEFT] = null
					res[index + Vector2.DOWN] = null
					res[index + Vector2.RIGHT] = null
				return res
			
			for index in range(1, _step + 1):
				var res: Dictionary = flood_call.call(dic)
				# 合并
				var new: Dictionary
				for key in res:
					if not all.has(key):
						new[key] = null
						all[key] = null
						# 如果是要忽略的步数
						# 就不添加加入到结果中
						if _ignores.find(index) == -1:
							result.push_back(key)
				dic = new
	
	# 删除指定的要忽略的位置
	var ignore_vec: PackedVector2Array = []
	for item in _ignores:
		if item is Vector2:
			ignore_vec.push_back(item)
	
	result = carve_grid(result, ignore_vec)
	
	# 设置偏移量
	for index in range(0, result.size()):
		result[index] = result[index] + _offset
	
	return result


# 拼接格子
# 将需要拼接的都传入
# [[vec2...], [vec2...]]
# TODO
func splicing_grid(_grids: Array) -> Array[Vector2]:
	var result: Array[Vector2] = []
	return result


# 剔除格子
# 第一个是要剔除的对象，第二个是要删除的格子集合
func carve_grid(_grid: PackedVector2Array, _remove: PackedVector2Array) -> PackedVector2Array:
	var result: PackedVector2Array = []
	for item in _grid:
		if _remove.find(item) == -1:
			result.push_back(item)
	return result
