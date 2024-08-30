using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json; // 确保引入 Newtonsoft.Json 命名空间



// 武器缓存类
public static class WeaponListCache
{
    // 静态列表，用于存储武器数据
    public static List<Weapon> weaponList;


    /*
    // 初始化方法
    public static void Init(System.Random random, byte[] data)
    {
        int index = 0;
        // 获取武器的数量
        byte weaponNum = CommonUtils.byte_bR_a(data[index++], random);

        // 输出初始化开始的日志
        Debug.Log($"初始化武器信息开始，总数: {weaponNum}");

        // 遍历每个武器
        for (int i = 0; i < weaponNum; i++)
        {
            Weapon weapon = new Weapon();

            // 设置武器ID
            weapon.weaponId = CommonUtils.byte_bR_a(data[index++], random);
            // 获取武器名称的长度
            byte weaponNameLength = CommonUtils.byte_bR_a(data[index++], random);

            // 读取武器名称
            byte[] weaponNameBytes = new byte[weaponNameLength];
            for (int j = 0; j < weaponNameLength; j++)
            {
                weaponNameBytes[j] = CommonUtils.byte_bR_a(data[index++], random);
            }
            weapon.weaponName = Encoding.UTF8.GetString(weaponNameBytes);

            // 读取武器价格
            byte byte0 = CommonUtils.byte_bR_a(data[index++], random);
            byte byte1 = CommonUtils.byte_bR_a(data[index++], random);
            weapon.weaponPrice = (short)((byte1 << 8) | (byte0 & 0xFF));

            // 读取武器属性
            weapon.weaponProperties = CommonUtils.byte_bR_a(data[index++], random);
            // 读取武器重量
            weapon.weaponWeight = CommonUtils.byte_bR_a(data[index++], random);
            // 读取武器类型
            weapon.weaponType = CommonUtils.byte_bR_a(data[index++], random);

            // 将武器添加到列表中
            addWeapon(weapon);

            // 输出武器添加的日志
            Debug.Log($"武器ID: {weapon.weaponId}, 名称: {weapon.weaponName}, 类型: {weapon.weaponType} 添加到缓存");
        }

        // 输出初始化完成的日志
        Debug.Log($"初始化武器信息完成，武器数量: {getWeaponSize()}");
    }
    */
    // 添加武器到列表
    public static void addWeapon(Weapon weapon)
    {
        weaponList.Add(weapon);
        // 输出武器添加成功的日志
        Debug.Log($"武器 {weapon.weaponName} 已添加到列表，当前武器总数: {weaponList.Count}");
    }

    // 获取武器列表的大小
    public static byte getWeaponSize()
    {
        return (byte)weaponList.Count;
    }

    // 根据武器ID获取武器
    public static Weapon getWeapon(byte weaponId)
    {
        foreach (Weapon weapon in weaponList)
        {
            if (weapon.weaponId == weaponId)
            {
                // 输出找到武器的日志
                Debug.Log($"找到武器: {weapon.weaponName} (ID: {weaponId})");
                return weapon;
            }
        }
        // 输出未找到武器的日志
        Debug.LogWarning($"未找到武器ID: {weaponId}");
        return null;
    }

    // 清空所有武器
    public static void clearAllWeapons()
    {
        int count = weaponList.Count;
        weaponList.Clear();
        // 输出清空武器的日志
        Debug.Log($"所有武器已清空，共清理 {count} 件武器");
    }
}

// 公用工具类
public static class CommonUtils
{
    // 清除所有缓存信息
    public static void CleanAllInfo()
    {
        CityListCache.clearAllCities();
        CountryListCache.clearAllCountries();
        GeneralListCache.clearAllGenerals();
        GeneralListCache.clearAllNoDebutGenerals();
        WeaponListCache.clearAllWeapons();
        ProfileListCache.clearAllProfiles();
        // 输出清除缓存信息的日志
        Debug.Log("所有缓存信息已清理");
    }

    // 对传入的short数组进行排序，并返回排序后的索引数组
    public static byte[] Xhpx(short[] val)
    {
        byte[] da = new byte[val.Length];
        for (byte b = 0; b < da.Length; b++)
            da[b] = b;

        for (int i = 0; i < val.Length - 1; i++)
        {
            int min = i;
            for (int k = i + 1; k < val.Length; k++)
            {
                if (val[min] > val[k])
                    min = k;
            }
            if (min != i)
            {
                short temp = val[min];
                val[min] = val[i];
                val[i] = temp;

                byte t = da[i];
                da[i] = da[min];
                da[min] = t;
            }
        }
        return da;
    }

    // 使用当前时间种子初始化的随机数生成器
    private static System.Random random = new System.Random(DateTime.Now.Millisecond);

    // 获取一个随机整数
    public static int getRandomInt()
    {
        return Math.Abs(random.Next());
    }

    // 对字节进行随机扰动（类似于加密或混淆操作）
    public static byte byte_bR_a(byte byte0, System.Random random)
    {
        byte byte1 = (byte)(byte0 ^ random.Next());
        return byte1;
    }

    // 检查技能的二进制表示中，从右向左数第i位是否为1
    public static bool HaveSkill(short skill, int i)
    {
        return ((skill >> (10 - i) & 0x1) == 1);
    }
}