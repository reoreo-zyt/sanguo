extends Node

# 是否显示信息弹框
signal show_message(isShow: bool)

# 显示城市信息
signal show_city_info(cityName: String, cityId: String)

# 显示人物属性
signal show_hero_info(nameId: int)
