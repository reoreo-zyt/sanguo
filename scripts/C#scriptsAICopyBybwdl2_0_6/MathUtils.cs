using System;
using System.Text;  // 提供字符串操作
using System.Security.Cryptography;  // 用于获取当前时间的随机数生成器

public class MathUtils
{
    // 计算m的n次幂（long类型）
    public static long pow(long m, long n)
    {
        long result = 1L;
        // 循环n次，累乘m
        for (int i = 0; i < n; i++)
        {
            result *= m;
        }
        return result;
    }

    // 计算m除以n的余数
    public static int remainder(int m, int n)
    {
        return m % n;
    }

    // 将整数m转为字节数组，并存储到data中
    public static byte[] transToByteArray(int m, byte[] data)
    {
        int i;
        // 将字节数组初始化为0
        for (i = 0; i < data.Length; i++)
        {
            data[i] = 0;
        }
        // 将整数m转为10进制的各位数字，并存入字节数组
        for (i = 0; i < data.Length && m > 0; i++)
        {
            int k = remainder(m, 10);  // 获取m的个位数字
            data[i] = (byte)k;  // 存入字节数组
            m /= 10;  // 去掉m的个位
        }
        return data;
    }

    // 计算x的n次幂（int类型）
    public static int pow(int x, int n)
    {
        int result = 1;
        // 循环n次，累乘x
        for (int i = 0; i < n; i++)
        {
            result *= x;
        }
        return result;
    }

    // 初始化随机数生成器，使用当前时间作为种子
    private static Random random = new Random(DateTime.Now.Millisecond);

    // 获取一个0到maxInt之间的随机整数
    public static int getRandomInt(int maxInt)
    {
        return random.Next(maxInt);
    }

    // 判断字符串是否是数字
    public static bool isNumeric(string str)
    {
        // 如果字符串为空，返回false
        if (string.IsNullOrEmpty(str) || str.Trim() == "")
        {
            return false;
        }

        // 遍历字符串中的每个字符，检查是否都是数字字符
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if (c < '0' || c > '9')
            {
                return false;
            }
        }

        return true;
    }
}
