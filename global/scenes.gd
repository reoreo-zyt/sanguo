####
## 管理场景切换
####

extends Node

func _ready() -> void:
	SignalBus.connect("start_game", _on_start_game)
	SignalBus.connect("end_game", _on_end_game)
	SignalBus.connect("diy_game", _on_diy_game)
	SignalBus.connect("return_start", _on_return_start)
	SignalBus.connect("return_select", _on_return_select)
	SignalBus.connect("change_scenes_to_select_character", _on_change_scenes_to_select_character)
	SignalBus.connect("game_main", _on_game_main)
	SignalBus.connect("battle_main", _on_battle_main)

func _on_start_game():
	get_tree().change_scene_to_file("res://scenes/SelectMap/SelectMap.tscn")

func _on_end_game():
	get_tree().quit()

func _on_diy_game():
	get_tree().change_scene_to_file("res://scenes/Edit/Edit.tscn")

func _on_return_start():
	get_tree().change_scene_to_file("res://scenes/Menu/Menu.tscn")

func _on_return_select():
	get_tree().change_scene_to_file("res://scenes/SelectMap/SelectMap.tscn")

func _on_change_scenes_to_select_character():
	get_tree().change_scene_to_file("res://scenes/SelectCharacter/SelectCharacter.tscn")

func _on_game_main():
	get_tree().change_scene_to_file("res://scenes/GameMain/GameMain.tscn")

func _on_battle_main():
	get_tree().change_scene_to_file("res://scenes/BattleMainStart/BattleMainStart.tscn")
