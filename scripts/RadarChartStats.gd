@tool
extends Control

@onready var base = $RadarChart/Base
@onready var main = $RadarChart/Stats

@export var lineCount = 8
@export var labels = ["统","武","智","政","德","体","速","级"]
@export var stats = [80,80,80,80,80,80,80,80]
@export var labelPos = 1.3

#var lineCount = 8
#var labels = ["SHO","SPE","POW","DEF","GK","BOD","MID","ATK"]
#var stats = [50,50,50,50,50,50,50,50]
#var labelPos = 1.3

func update_radar_stats():
	base.update()
	main.update()
