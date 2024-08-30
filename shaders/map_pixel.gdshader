shader_type spatial;

void vertex() {
    // 顶点着色器代码
}

void fragment() {
    // 片段着色器代码
    ALBEDO = vec3(1.0); // 设置反射颜色为白色（不影响结果）
    ALPHA = 0.2; // 设置透明度为0.2
}