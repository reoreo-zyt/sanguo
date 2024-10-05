####
## 生成菜单按钮
####

extends VBoxContainer

var pf_button = preload("res://prefebs/Button/Button.tscn")
@onready var self_node = $"."

var menus = [
	{
		"text": "开创霸业",
		"event": "start_game"
	},
	{
		"text": "再续征程",
		"event": "continute_game"
	},
	{
		"text": "剧本编辑",
		"event": "diy_game"
	},
	{
		"text": "游戏设置",
		"event": "game_help"
	},
	{
		"text": "卸甲归田",
		"event": "end_game"
	}
]

func _ready() -> void:
	for menu in menus:
		var button = pf_button.instantiate()
		button.btn_text = "[center]" + menu.text
		button.btn_event = menu.event
		self_node.add_child(button)
