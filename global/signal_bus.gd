####
## 所有触发事件
####

extends Node

signal start_game()

signal end_game()

signal diy_game()

signal return_start()

signal change_scenes_to_select_character()

signal return_select()

signal change_character_attr()

signal get_name_id(id: int)

signal game_main()

signal show_citys()

signal change_citys_label()

signal recover_city_select()

signal change_city_size(zoom)

signal focus_map_city(city_id)

signal open_characters_list(city_id)

signal reset_character_attr(name_id)

signal send_characters_event(character_id, event_index)
