extends Node2D

var astar = AStar2D.new() # 实例化
# 定义网格
var grid_size = Vector2i(10,5) # 尺寸 - 有多少行、多少列
var cell_size = Vector2i(238,208) # 单元格大小

func _ready():
	# 添加可以到达的位置
	astar.add_point(0,Vector2(0,0))
	astar.add_point(1, Vector2(0, 0))
	astar.add_point(2, Vector2(0, 1), 1) # 默认权重为 1
	astar.add_point(3, Vector2(1, 1))
	astar.add_point(4, Vector2(2, 0))
	# 在点之间创建连接，形成路径
	astar.connect_points(1, 2, false)
	astar.connect_points(2, 3, false)
	astar.connect_points(4, 3, false)
	astar.connect_points(1, 4, false)
	# 查询某两个位置之间的最短路径
	var res = astar.get_id_path(1, 3)
	print(res)

func _draw():
	# 绘制网格
	for x in grid_size.x:
		for y in grid_size.y:
			draw_rect(Rect2i(Vector2i(x,y) * cell_size,cell_size),Color.YELLOW,false,1)
	# 绘制点
	for i in range(astar.get_point_count()):
		var pos = get_grid_pos(astar.get_point_position(i))
		draw_circle(pos,5,Color.YELLOW)
	# 绘制所有路径
	for i in range(astar.get_point_count()):
		var pos = get_grid_pos(astar.get_point_position(i))
		if i+1 <= astar.get_point_count():
			var pos2 = get_grid_pos(astar.get_point_position(i+1))
			draw_line(pos,pos2,Color.GREEN_YELLOW,2)
	# 绘制寻找到的路径
	var path = astar.get_point_path(1,4)
	for i in path.size()-1:
		var pos = get_grid_pos(path[i])
		if i+1 <= path.size():
			var pos2 = get_grid_pos(path[i+1])
			draw_line(pos,pos2,Color.RED,2)

# 返回屏幕中的点或路径中的点对应在网格中的坐标
func get_grid_pos(point_pos:Vector2):
	return point_pos * Vector2(cell_size) + Vector2(cell_size/2)
