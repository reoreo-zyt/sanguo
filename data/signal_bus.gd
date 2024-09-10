extends Node

# 是否显示信息弹框
signal show_message(isShow: bool)

# 显示城市信息
signal show_city_info(cityName: String, cityId: String)

# 显示人物属性
signal show_hero_info(nameId: int)

# 显示城市中的人物详情
signal show_city_hero_info()

# 关闭人物详情
signal hide_city_hero_info()

# 政务指令次数
signal change_polities_times()

# 关闭城市信息
signal hide_city_message()

# 选择战场人物
signal select_hero_list(is_self: bool)

signal change_curr_fight_character_id(character_id: int)

signal change_next_fight_character_id()

signal close_before_fight_character_id(character_id: int)

# 通知人物移动
signal curr_fight_character_move(character_id: int)

# 通知具体移动
signal curr_fight_character_move_forward(upward: String)

# 通知人物显示属性
signal curr_fight_character_show_info(character_id: int)

# 武将移动
signal change_wjyd_characters_ids(character_ids: Array)

# 修改武将列表的宽度
signal change_character_list_scroller_width(width: int)
