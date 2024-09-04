extends Node2D

func _ready() -> void:
	set_time_text()
	SignalBus.connect("change_polities_times", _on_change_polities_times)

func _on_change_polities_times():
	Global.polities_times -= 1
	$Panel/Label.text = str(Global.polities_times)

func _on_texture_button_pressed() -> void:
	$HistoryAi/RichTextLabel.text += "[center]" + str(Global.year) + " 年 " + str(Global.month) + " 月"
	if(Global.month == 12):
		Global.month = 1
		Global.year = Global.year + 1
	else:
		Global.month = Global.month + 1

	# 获取到所有除自己以外的君主，执行 AI 的相关操作
	create_ai_action()
	set_time_text()

	Global.polities_times = 3
	$Panel/Label.text = str(Global.polities_times)

func set_time_text():
	$TimePanel/RichTextLabel.text = "[center]" + str(Global.year) + " 年 " + str(Global.month) + " 月 "

func create_ai_action():
	var characters = Global.characters_select
	# print(characters)
	for i in characters:
		# print(characters[i])
		# 开始战略
		$HistoryAi/RichTextLabel.text += "[center] [color=" + Global.characters_select[i].color + "]" + Global.characters[i].name + "战略中"
		# 结束战略
		$HistoryAi/RichTextLabel.text += "[center] [color=" + Global.characters_select[i].color + "]" + Global.characters[i].name + "结束战略"

func _on_clear_texture_button_pressed() -> void:
	$HistoryAi/RichTextLabel.text = ""

func _on_expend_texture_button_pressed() -> void:
	$HistoryAi/Panel.hide()
	$HistoryAi/RichTextLabel.hide()
	if(!$HistoryAi/ClearTextureButton.position.x == 0):
		$HistoryAi/ClearTextureButton.position.x = 0
		$HistoryAi/ExpendTextureButton.position.x = 0
	else:
		$HistoryAi/ClearTextureButton.position.x = 204
		$HistoryAi/ExpendTextureButton.position.x = 204
		$HistoryAi/Panel.show()
		$HistoryAi/RichTextLabel.show()
