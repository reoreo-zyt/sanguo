# =====================================================
# TileMapAStar2D
# AStar2D扩展类型，用于为TileMap自动化的创建A*导航网格
# ====================================================

extends AStar2D
class_name TileMapAStar2D

var _tile_map:TileMap
var _layer_id:int

var _pos_labs:Array[Label] = []
var _id_labs:Array[Label] = []

# 是否用Label显示所有可通行位置的单元格坐标
@export var show_navigation_cells_pos:bool = false:
	set(val):
		show_navigation_cells_pos = val
		if val:
			for cell in get_has_navigation_cells():
				show_cell_pos(cell)
		else:
			for lab in _pos_labs:
				lab.queue_free()
			_pos_labs.clear()


# 是否用Label显示所有可通行位置的单元格坐标
@export var show_navigation_cells_id:bool = false:
	set(val):
		show_navigation_cells_id = val
		if val:
			for point_id in get_point_ids():
				var cell = Vector2i(get_point_position(point_id))
				if cell in get_has_navigation_cells():
					show_cell_id(cell,point_id)
		else:
			for lab in _id_labs:
				lab.queue_free()
			_id_labs.clear()


# 基于TileMap，添加可通行点和连接线，创建Astar网格,并返回一个AStar2D实例
func _init(tile_map:TileMap,layer_id:int):
	# 存储TileMap对象和layer_id
	_tile_map = tile_map
	_layer_id = layer_id
	
	# 添加可通行点
	for cell in get_has_navigation_cells():
		var id = get_available_point_id()
		add_point(id,cell)
	
	# 遍历已经添加了的可通行点,进行连线
	var points_ids = get_point_ids()
	for point_id in points_ids:
		var point_cell_pos = get_point_position(point_id) # id转为单元格坐标
		var surround_cell_pos_arr = tile_map.get_surrounding_cells(point_cell_pos)# 获取周边6个位置
		for cel in surround_cell_pos_arr:
			var cel_id = get_closest_point(cel)# 尝试获取最接近的点的id
			if Vector2i(get_point_position(cel_id)) in surround_cell_pos_arr: # 验证获取的点的ID在周围6个位置内
				if cel_id in points_ids: # 验证点在已经添加的位置内
					if !are_points_connected(cel_id,point_id): # 验证两个点之间不存在连接
						connect_points(cel_id,point_id)

# 判断单元格是否存在导航多边形
func is_cell_has_navigation_polygon(cell:Vector2i):
	var bol = false
	var data = _tile_map.get_cell_tile_data(_layer_id,cell)
	if data:
		if data.get_navigation_polygon(_layer_id): # 有导航区域
			bol = true
	return bol

# 获取TileMap所有拥有导航网格的单元格
# 查找是在get_used_cells基础上进行的
func get_has_navigation_cells() -> Array[Vector2i]:
	var cells:Array[Vector2i] = []
	# 获取所有已经绘制的单元格
	var used_cells:Array[Vector2i] = _tile_map.get_used_cells(_layer_id)
	# 遍历所有网格，将带有导航区域的单元格位置添加为AStar的可通行点
	for cell in used_cells:
		if is_cell_has_navigation_polygon(cell): # 格子有导航多边形
			cells.append(cell)
	return cells


# =================================== 底层辅助函数 ===================================

func create_lab(content:String,font_color:Color = Color("#ffffff")):
	var lab = Label.new()
	lab.horizontal_alignment = HORIZONTAL_ALIGNMENT_CENTER
	lab.vertical_alignment = VERTICAL_ALIGNMENT_CENTER
	# 构造LabelSettings
	var lab_setting = LabelSettings.new()
	lab_setting.font_color = font_color
	lab_setting.font_size = _tile_map.tile_set.tile_size.x /8
	lab_setting.outline_color = Color("#444444")
	lab_setting.outline_size = lab_setting.font_size/3
	lab_setting.shadow_color = Color("#3333339e")
	lab_setting.shadow_size = 1
	lab_setting.shadow_offset = Vector2(2,2)
	# 其他配置
	lab.label_settings = lab_setting
	lab.text = content
	return lab

# 显示TileMap对应单元格的位置信息
func show_cell_pos(cell:Vector2i):
	var lab = create_lab(str(cell))
	lab.position = _tile_map.map_to_local(cell)
	_tile_map.add_child(lab)
	_pos_labs.append(lab)

# 显示单元格对应的AStar2D的点ID
func show_cell_id(cell:Vector2i,id:int):
	var lab = create_lab(str(id),Color.ORANGE)
	lab.position = _tile_map.map_to_local(cell) - Vector2(_tile_map.tile_set.tile_size /5.5)
	_tile_map.add_child(lab)
	_id_labs.append(lab)
