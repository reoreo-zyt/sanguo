extends TileMap

var astar = TileMapAStar2D.new(self,0)

func _ready() -> void:
	astar.show_navigation_cells_pos = true # 显示单元格的坐标
	astar.show_navigation_cells_id = true  # 显示TileMapAStar2D为单元个创建的位置ID
