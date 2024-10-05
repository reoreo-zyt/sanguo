####
## 随机切换图片背景
####

extends TextureRect

@onready var self_node = $"."

var bg_array = [
	{
		"path": "res://assets/bg/bg1.jpg"
	},
	{
		"path": "res://assets/bg/bg2.jpg"
	},
	{
		"path": "res://assets/bg/bg3.jpg"
	},
	{
		"path": "res://assets/bg/bg4.jpg"
	}
]

func _ready() -> void:
	var random_path = Tool.get_random_item(bg_array, "path")
	self_node.texture = load(random_path)
