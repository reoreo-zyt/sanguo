@tool
extends Node2D

@onready var data = get_parent().get_parent()
@onready var labelIns = preload("res://prefebs/CharacterAttr/LabelStats.tscn")

func _ready():
	pass
	#update()

func _draw():
	var poly = []
#	var line = 0
	var color = Color.WHITE
	var thick = 10.0
#	print(get_child_count())
	for i in get_child_count():
		poly.append(get_child(i).position)
	
	var colour = PackedColorArray()
	colour = [Color(0,0,0,0.2)]
	draw_polygon(poly,colour)
	
	poly.append(get_child(0).position)
	poly.append(get_child(1).position)
	draw_polyline(poly,color,thick,true)
	
	## ve cac duong cheo
	for i in 4:
		draw_line(get_child(i).position,get_child(i+4).position,color,thick,true)
	
	create_label()

func create_label():
	if get_parent().get_node("Label").get_child_count()>0:
		for unit in get_parent().get_node("Label").get_children():
			unit.queue_free()
	
	for i in 8:
		var ins = labelIns.instantiate()
		get_parent().get_node("Label").add_child(ins)
		ins.position = lerp(Vector2.ZERO,get_child(i).position,data.labelPos)
		ins.get_node("RichTextLabel").text = '[color=#91c2d5][u][url]' + data.labels[i] + str(data.stats[i]) + '[/url][/u][/color]'
