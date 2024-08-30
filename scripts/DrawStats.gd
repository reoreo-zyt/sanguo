@tool
extends Node2D

@onready var data = get_parent().get_parent()
@onready var base = get_parent().get_node("Base")

func _ready():
	pass
	#update()

func _draw():
	var poly = []
#	var line = 0
	var color = Color.AQUA
	var thick = 10.0
	var par = get_child_count()-1
	var stats = data.stats
	
	for i in par:
		get_child(i).position = lerp(Vector2.ZERO,base.get_child(i).position,stats[i]/108.0)
	get_child(par).position = lerp(Vector2.ZERO,base.get_child(par).position,stats[par]/108.0)
	
	for i in get_child_count():
		poly.append(get_child(i).position)
	
	var colour = PackedColorArray()
	colour = [Color(0.5,0.8,1,0.8)]
	draw_polygon(poly,colour)
	
	poly.append(get_child(0).position)
	poly.append(get_child(1).position)
	draw_polyline(poly,color,thick,true)
	
#	for i in 7:
#		draw_circle(get_child(i).position,15.0,Color.red)
