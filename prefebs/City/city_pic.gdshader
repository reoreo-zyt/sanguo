shader_type canvas_item;

uniform bool green_blue = true;
uniform bool green_red = false;
uniform bool blue_red = false;
uniform float blue:hint_range(.0,1.,.1) = 1.;
uniform float green:hint_range(.0,1.,.1) = 1.;
uniform float red:hint_range(.0,1.,.1) = 1.;

void fragment(){
    COLOR = texture(TEXTURE, UV); //read from texture
	if(green_blue){
		COLOR.b = blue;
    	COLOR.g = green;
	}
	if(green_red){
		COLOR.g = green;
		COLOR.r = red;
	}
	if(blue_red){
		COLOR.b = blue;
		COLOR.r = red;
	}
}
