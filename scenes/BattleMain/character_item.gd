extends Control

@export var width = 238 / 2
@export var height = 208 / 2
@export var member_type = 0
@export var character_id = 0
@export var control_position = Vector2(0, 0)

func _ready() -> void:
	SignalBus.connect("batlle_show_actions", _on_batlle_show_actions)
	if(member_type == 0):
		show_characters_message("#5269f9", true)
	elif(member_type == 1):
		show_characters_message("#982e2e", true)
	else:
		show_characters_message("#3d51f4f0", false)
		$Control/icon.show()

func _on_batlle_show_actions(id):
	if(character_id == id):
		#$Control/Vircle.show()
		# 生成移动色块
		pass

func show_characters_message(color = "#5269f9", is_show_message = true):
	$Control/TextureButton.modulate = Color(color)
	$Control.position = control_position
	if(is_show_message):
		$Control/Name.show()
		$Control/Bing.show()
		$Control/Name.text = "[center]" + Global.characters[int(character_id)].name
		$Control/Bing.text = "[center]" + str(Global.characters[int(character_id)].attrs.bing)

func _on_texture_button_move_pressed() -> void:
	print(111)
