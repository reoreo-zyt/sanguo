@tool
extends EditorPlugin


func _enter_tree() -> void:
	add_autoload_singleton("GFloatInfo", "res://addons/float-info/float.tscn")


func _exit_tree() -> void:
	remove_autoload_singleton("GFloatInfo")
