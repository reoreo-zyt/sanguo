@tool
extends ColorRect

@export var location = "0,0"

@export var dark : bool = false :
	set(v):
		dark = v
		color = Color(0x618fb8ff) if dark else Color(0xbfd9f2ff)
