extends Node2D


@onready var map: TileMap = $TileMap


func _ready() -> void:
	var vecs: PackedVector2Array = []
	var begin_msec: int = 0
	var end_msec: int = 0
	
	begin_msec = Time.get_ticks_msec()
	
	# PASS 1 msec
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.CROSS, 100)
	# PASS 16 msec
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.RANGE, 100)
	# PASS 0 msec
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.TILE_CROSS, 100)
	# PASS 2161 msec O(2)
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.TILE_RANGE, 100)
	
	# PASS
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.CROSS, 5, [1, 2, Vector2(0, 0)])
	# PASS
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.RANGE, 5, [1, 2, Vector2(3, 3)])
	# PASS
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.TILE_CROSS, 5, [1, 2, Vector2(3, 3)])
	# PASS
	#vecs = GCreateGrid.create_grid(GCreateGrid.CREATE_GRID_MODE.TILE_RANGE, 5, [4, Vector2(0, 0)])
	
	end_msec = Time.get_ticks_msec()
	
	for vec in vecs:
		map.set_cell(0, vec, 0, Vector2i(1, 0))
