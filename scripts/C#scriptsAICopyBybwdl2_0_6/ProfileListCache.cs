using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;


// 人物简介缓存类
public class ProfileListCache
{
    // 存储所有Profile对象的列表
    public static List<Profile> profiles = new List<Profile>();

    // 初始化方法，从二进制数据中读取Profile信息
    public static void Init(System.Random random, byte[] data)
    {
        int index = 0;

        // 读取两个字节，并进行解码
        byte byte0 = CommonUtils.byte_bR_a(data[index++], random);
        byte byte1 = CommonUtils.byte_bR_a(data[index++], random);

        // 计算profile的数量
        short profileNum = (short)((byte1 << 8) | (byte0 & 0xFF));

        // 循环读取每个Profile
        for (int i = 0; i < profileNum; i++)
        {
            Profile profile = new Profile();

            // 读取generalId
            byte0 = CommonUtils.byte_bR_a(data[index++], random);
            byte1 = CommonUtils.byte_bR_a(data[index++], random);
            profile.generalId = (short)((byte1 << 8) | (byte0 & 0xFF));

            // 读取profile的长度
            byte profileLength = CommonUtils.byte_bR_a(data[index++], random);
            byte[] profileBytes = new byte[profileLength];

            // 读取profile内容
            for (int j = 0; j < profileLength; j++)
            {
                profileBytes[j] = CommonUtils.byte_bR_a(data[index++], random);
            }

            // 将读取的字节转换为字符串，并设置到profile对象中
            string profileStr = Encoding.UTF8.GetString(profileBytes);
            profile.profile = profileStr;

            // 添加profile到缓存中
            AddProfile(profile);
        }

        // 打印当前缓存中的profile数量
        UnityEngine.Debug.Log("Profile数量: " + GetProfileSize());
    }

    // 添加Profile到列表
    public static void AddProfile(Profile profile)
    {
        profiles.Add(profile);
    }

    // 获取缓存中Profile的数量
    public static int GetProfileSize()
    {
        return profiles.Count;
    }

    // 根据generalId获取对应的Profile字符串
    public static string GetProfile(short generalId)
    {
        string result = string.Empty;

        // 遍历所有Profile，查找匹配的generalId
        foreach (Profile profile in profiles)
        {
            if (profile.generalId == generalId)
            {
                if (!string.IsNullOrEmpty(profile.profile?.Trim()))
                {
                    result = profile.profile;
                }
                break;
            }
        }

        return result;
    }

    // 清除所有缓存的Profile
    public static void clearAllProfiles()
    {
        profiles.Clear();
    }
}
