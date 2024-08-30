shader_type canvas_item;
//噪声纹理
//uniform用于逻辑语言（GDScript/C#等）和着色器之间传递数据。
//注意：这个传递是单向的，即只能由逻辑语言传给着色器，反之不行。
uniform sampler2D noise_teture:repeat_enable,filter_nearest;
//设置云层透明度，值越接近1越不透明
uniform float density:hint_range(0.0, 1.0, 0.1)=0.25;
//云层移动速度
uniform vec2 speed = vec2(0.02,0.01);
void fragment() {
	//设置云层移动
	vec2 uv = UV + speed * TIME;
	//从噪声纹理采样
	float noise = texture(noise_teture,uv).r;
	//将噪声的范围（0.0，1.0）范围调整到（-1.0,1.0）
	float fog = noise*2.0-1.0;
	//将范围在调整回（0.0,1.0）目的是不是云层的地方变为透明
	fog = clamp(fog,0.0,1.0);
	//应用薄雾效果
	COLOR.a *=fog*density;
}
