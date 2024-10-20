extends Node2D

var character_attr = preload("res://prefebs/CharacterAttr/CharacterAttr.tscn")
var character_message = preload("res://prefebs/Characters/Characters.tscn")
var text_panel = preload("res://prefebs/TextPanel/TextPanel.tscn")
var character_slice = preload("res://scenes/BattleMain/character_item.tscn")
var character_item_slice = preload("res://scenes/BattleMain/character_item.tscn")

var character_slice_instance_cach = {}
var self_troop = [43, 3, 15]
var emery_troop = [501, 502, 503, 504, 505, 506]
var character_message_instance_save = null

# 寻路算法
var astar = AStar2D.new()

func _ready() -> void:
	# 添加层的节点
	#var astar_area = [
		#{
			#"location": Vector2i(0,0),
			#"id": 0
		#},
		#{
			#"location": Vector2i(0,1),
			#"id": 1
		#},
		#{
			#"location": Vector2i(0,2),
			#"id": 2
		#}
	#]
	#for node in astar_area:
		#astar.add_point(node.id, node.location)
		#for node2 in astar_area:
			#if node2 != node:
				#astar.connect_points(node.id, node2.id, false)
	#var res = astar.get_id_path(0, 2)
	#print(res)
		# 添加可以到达的位置
	astar.add_point(0,Vector2(0,0))
	astar.add_point(1, Vector2(0, 0))
	astar.add_point(2, Vector2(0, 1), 1) # 默认权重为 1
	astar.add_point(3, Vector2(1, 1))
	astar.add_point(4, Vector2(2, 0))
	# 在点之间创建连接，形成路径
	astar.connect_points(1, 2, false)
	astar.connect_points(2, 3, false)
	astar.connect_points(4, 3, false)
	astar.connect_points(1, 4, false)
	# 查询某两个位置之间的路径
	var res = astar.get_id_path(0, 3) # [1,4]
	print(res)

	SignalBus.connect("battle_send_character_location", _on_battle_send_character_location)

	# 界面
	var character_attr_instance = character_attr.instantiate()
	character_attr_instance.name_id = int(Global.cur_hero_id)
	character_attr_instance.is_show_attr = true
	character_attr_instance.is_fold = true
	$CanvasLayer/Main/Control.add_child(character_attr_instance)

	#var cell_position = Vector2(0, 0)
	## 获取位置的TileSet
	#var texture_id = $TileMapLayer.get_cell_source_id(cell_position)

	var character_message_instance = character_message.instantiate()
	character_message_instance.position = Vector2(-58, 550)
	character_message_instance.jiangs = self_troop
	character_message_instance.is_show_city = false
	$CanvasLayer/Main/Control.add_child(character_message_instance)
	character_message_instance_save = character_message_instance
	SignalBus.emit_signal("open_characters_list", 0)

func _on_battle_send_character_location(character_id, event_id) -> void:
	var color = Color(1, 0.5, 0.3, 0.838)
	var colors:PackedColorArray = [color, color, color, color, color, color, color]
	var character_slice_instance = character_slice.instantiate()

	if(character_slice_instance_cach):
		for cach in character_slice_instance_cach:
			if(cach == character_id):
				if(character_slice_instance_cach[character_id]):
					character_slice_instance_cach[character_id].queue_free()
					character_slice_instance_cach[character_id] = null

	if(event_id == 0):
		return
	var position = Global.battle_event[event_id].position
	character_slice_instance.width = Tool.calc_px(position)[0]
	character_slice_instance.height = Tool.calc_px(position)[1]
	character_slice_instance.member_type = 0
	character_slice_instance.character_id = character_id
	character_slice_instance.control_position = Vector2(Tool.calc_px(position)[0] - 238 / 2, Tool.calc_px(position)[1] - 208 / 2)
	$Characters.add_child(character_slice_instance)
	character_slice_instance_cach[character_id] = character_slice_instance
	SignalBus.emit_signal("battle_set_select_disabled", character_id, event_id)

func _on_next_pressed() -> void:
	$CanvasLayer/Main/Control/Time.show()
	var is_set_location = true
	for troop in self_troop:
		if(!Global.characters[troop].battle_location):
			is_set_location = true
	if(!is_set_location):
		var TextPanel = text_panel.instantiate()
		TextPanel.label_text = "[center]请先配置初始位置"
		$CanvasLayer/Main/PopupPanel.add_child(TextPanel)
		$CanvasLayer/Main/PopupPanel.popup()
	else:
		$CanvasLayer/Main/Next.hide()
		$CanvasLayer/Main/TextureRect/RichTextLabel.text = "战斗阶段"
		$PrePanel.hide()
		$CharacterPlace.queue_free()
		character_message_instance_save.queue_free()
		
		var position = [
			Vector2i(8, 0),
			Vector2i(8, 1),
			Vector2i(8, 2),
			Vector2i(8, 3),
			Vector2i(8, 4),
			Vector2i(9, 0),
			Vector2i(9, 1),
			Vector2i(9, 2),
			Vector2i(9, 3),
			Vector2i(9, 4),
		]
		
		var color = Color(0.875, 0.239, 0.188, 1)
		var colors:PackedColorArray = [color, color, color, color, color, color, color]
		var i = 0
		# 绘制敌方武将
		for troop in emery_troop:
			Global.characters[troop].battle_location = position[i]
			var troop_position = position[i]
			i += 1
			var character_emery_instance = character_slice.instantiate()
			character_emery_instance.width = Tool.calc_px(troop_position)[0]
			character_emery_instance.height = Tool.calc_px(troop_position)[1]
			character_emery_instance.member_type = 1
			character_emery_instance.character_id = troop
			character_emery_instance.control_position = Vector2(Tool.calc_px(troop_position)[0] - 238 / 2, Tool.calc_px(troop_position)[1] - 208 / 2)
			$Characters.add_child(character_emery_instance)
		# 进入战棋模式
		$Camera2D.zoom(-1)
		var merge_array = self_troop + emery_troop
		var action_list = []
		for character in merge_array:
			var list_item = {}
			list_item.id = character
			list_item.speed = Global.characters[character].attrs.speed
			action_list.append(list_item)
		action_list.sort_custom(func(a, b): return a['speed'] > b['speed'])

		SignalBus.emit_signal("batlle_show_actions", action_list[0].id)
		$Camera2D.position = Tool.calc_px(Global.characters[action_list[0].id].battle_location)
		var TextPanel = text_panel.instantiate()
		TextPanel.label_text = Global.set_name_text("[center]轮到" + Global.characters[action_list[0].id].name + "行动")
		$CanvasLayer/Main/PopupPanel.add_child(TextPanel)
		$CanvasLayer/Main/PopupPanel.popup()
		# 开始移动逻辑
		SignalBus.emit_signal("batlle_show_actions", action_list[0].id)
		# 将这个格子临近的格子全部涂色	
		var slices = get_nerber_positions(Global.characters[action_list[0].id].battle_location)
		var color_silce = Color(0.281, 0.703, 0.94, 0.838)
		var colors_slice:PackedColorArray = [color_silce, color_silce, color_silce, color_silce, color_silce, color_silce, color_silce]

		for slice in slices:
			var character_item_slice_instance = character_item_slice.instantiate()
			var position_slice = Tool.calc_px(slice)
			character_item_slice_instance.width = position_slice[0]
			character_item_slice_instance.height = position_slice[1]
			character_item_slice_instance.member_type = 2
			character_item_slice_instance.control_position = Vector2(Tool.calc_px(slice)[0] - 238 / 2, Tool.calc_px(slice)[1] - 208 / 2)
			$".".add_child(character_item_slice_instance)

		SignalBus.emit_signal("reset_character_attr", action_list[0].id)
		$CanvasLayer/Main/TextureRect/RichTextLabel.text = Global.characters[action_list[0].id].name + "-移动阶段"

func get_nerber_positions(position):
	var slices = []
	if(position[0] % 2 == 0):
		slices.append(Vector2i(position[0], position[1] - 1))
		slices.append(Vector2i(position[0] + 1, position[1] - 1))
		slices.append(Vector2i(position[0] + 1, position[1]))
		slices.append(Vector2i(position[0], position[1] + 1))
		slices.append(Vector2i(position[0] - 1, position[1]))
		slices.append(Vector2i(position[0] - 1, position[1] - 1))
	else:
		slices.append(Vector2i(position[0], position[1] - 1))
		slices.append(Vector2i(position[0] + 1, position[1]))
		slices.append(Vector2i(position[0] + 1, position[1] + 1))
		slices.append(Vector2i(position[0], position[1] + 1))
		slices.append(Vector2i(position[0] - 1, position[1] + 1))
		slices.append(Vector2i(position[0] - 1, position[1]))
	return slices
