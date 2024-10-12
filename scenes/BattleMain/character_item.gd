extends Node2D

@export var width = 238 / 2
@export var height = 208 / 2
@export var length = 100

# 顶点颜色集合
@export var colors:PackedColorArray = [Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL,Color.CORAL]
var border_width := 1.0                 # 边线宽度
var antialiased := false                # 抗锯齿

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
