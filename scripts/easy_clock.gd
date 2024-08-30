# !error: scene/main/canvas_item.cpp:896 - Condition "p_font.is_null()" is true.
# ========================================================
# 名称：EasyClock
# 类型：Control扩展节点
# 简介：利用_draw实现的参数化的指针型钟表组件
# ========================================================
@tool
extends Control
class_name EasyClock
# =================================== 参数 ===================================
# 功能开关
@export_group("switch")
## 是否绘制中心
@export var draw_center:bool = false:
	set(val):
		draw_center = val
		queue_redraw()
## 是否绘制数字
@export var draw_nums:bool = false:
	set(val):
		draw_nums = val
		queue_redraw()
## 是否绘制刻度
@export var draw_scales:bool = false:
	set(val):
		draw_scales = val
		queue_redraw()
# 颜色
@export_group("Color")
## 表盘 - 颜色
@export var bk_color:Color = Color("#ccc"):
	set(val):
		bk_color = val
		queue_redraw()
## 时针 - 颜色
@export var h_color:Color = Color("#444"):
	set(val):
		h_color = val
		queue_redraw()
## 分针 - 颜色
@export var m_color:Color = Color("#444"):
	set(val):
		m_color = val
		queue_redraw()
## 秒针 - 颜色
@export var s_color:Color = Color("#444"):
	set(val):
		s_color = val
		queue_redraw()
## 中心点 - 颜色
@export var center_color:Color = Color("#ccc"):
	set(val):
		center_color = val
		queue_redraw()
# 宽度
@export_group("Width")
## 时针 - 宽度
@export var h_width:int = 10:
	set(val):
		h_width = val
		queue_redraw()
## 分针 - 宽度
@export var m_width:int = 5:
	set(val):
		m_width = val
		queue_redraw()
## 秒针 - 宽度
@export var s_width:int = 3:
	set(val):
		s_width = val
		queue_redraw()
@export_group("nums")
## 表盘数字 - 颜色
@export var nums_color:Color = Color("#ccc"):
	set(val):
		nums_color = val
		queue_redraw()
## 默认字体大小
@export var font_size = 14:
	set(val):
		font_size = val
		queue_redraw()
## 默认字体	
@export var font:SystemFont:
	set(val):
		font = val
		queue_redraw()


# =================================== 动态计算参数 ===================================
var center = Vector2(100,100) # 表盘中心
var r = 80 # 表盘半径
var h_r = 60 # 时针长度
var m_r = 50 # 分针长度
var s_r = 40 # 秒针长度

func _ready():
	resized.connect(func():
		calc()
	)
	calc()
	queue_redraw()

# 重新计算
func calc():
	center = get_global_rect().get_center()
	r = get_global_rect().size.y/2
	h_r = r * 0.82
	m_r = r * 0.85
	s_r = r * 0.9

func _process(delta):
	queue_redraw()

func _draw():
	# 获取当前时间信息
	var dict = Time.get_datetime_dict_from_system()
	# 绘制表盘
	draw_circle(center,r,bk_color)
	draw_circle(center,r * 0.8,bk_color.darkened(0.2))
	draw_circle(center,r * 0.8 - 10,bk_color.darkened(0.15))
	# 绘制日期
	var date := "%d.%d.%d" % [dict["year"],dict["month"],dict["day"]]
	draw_string(font, 
	Vector2.DOWN * r * 0.4 + center - Vector2(font_size * 2,-font_size/2),
	date,HORIZONTAL_ALIGNMENT_CENTER,-1,font_size * 1.5,nums_color)
	# 绘制时间
	# 绘制数字
	if draw_nums:
		for i in range(1,13):
			var f_size = font_size if i % 3 != 0 else font_size * 2
			draw_string(font, 
			(Vector2.UP * (r - f_size/1.25)).rotated((2* PI /12) * i) + center - Vector2(f_size/3,-f_size/2),
			str(i),HORIZONTAL_ALIGNMENT_CENTER,-1,f_size,nums_color)
	# 绘制
	draw_line(center,(Vector2.UP * h_r).rotated((2* PI /12) * dict["hour"]) + center,h_color,h_width)
	draw_line(center,(Vector2.UP * m_r).rotated((2* PI /60) * dict["minute"]) + center,m_color,m_width)
	draw_line(center,(Vector2.UP * s_r).rotated((2* PI /60) * dict["second"]) + center,s_color,s_width)
	# 绘制中心
	if draw_center:
		draw_circle(center,r * 0.1,center_color)
		draw_circle(center,r * 0.1 - 8,center_color.darkened(0.2))
		draw_circle(center,5,center_color.darkened(0.3))
	# 绘制刻度线
	if draw_scales:
		for i in range(60):
			draw_line((Vector2.UP * r * 0.9).rotated((2* PI /60) * i) + center ,(Vector2.UP * r * 0.95).rotated((2* PI /60) * i) + center,s_color,1)
