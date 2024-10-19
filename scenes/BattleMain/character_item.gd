extends Control

@export var width = 238 / 2
@export var height = 208 / 2
@export var length = 100
@export var is_member = false
@export var character_id = 0
@export var control_position = Vector2(0, 0)

# 顶点颜色集合
@export var colors:PackedColorArray = [Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL]
var border_width := 1.0                 # 边线宽度
var antialiased := true                # 抗锯齿

func _ready() -> void:
	SignalBus.connect("batlle_show_actions", _on_batlle_show_actions)

# 正多边形点求取函数
func regular_polygon(center:Vector2,r:float,edges:=3,strat_angle:float=0,close:=false):
	var points:PackedVector2Array = []
	var right = Vector2.RIGHT
	# 利用角度插值和向量旋转获取正多边形顶点
	for i in range(edges):
		var deg = lerp(0,360,float(i)/float(edges))
		var p = right.rotated(deg_to_rad(deg)) * r
		points.append(p)
	
	if close: # 闭合 - 用于draw_polyline
		points.append(points[0])
	# 变换
	var T:= Transform2D().rotated(strat_angle).translated(center)
	return T * points

func _draw() -> void:
	var regular = regular_polygon(Vector2(width, height),length,6,0,true)
	# 绘制空心正多边形和边框
	draw_polygon(regular,colors)
	#draw_polyline(regular,Color.CHOCOLATE, 10)
	if(is_member):
		$Control.position = control_position
		$Control/Name.show()
		$Control/Bing.show()
		$Control/Name.text = "[center]" + Global.characters[int(character_id)].name
		$Control/Bing.text = "[center]" + str(Global.characters[int(character_id)].attrs.bing)

func _on_batlle_show_actions(id):
	if(character_id == id):
		#$Control/Vircle.show()
		# 生成移动色块
		pass

func _on_texture_button_move_pressed() -> void:
	print(111)
