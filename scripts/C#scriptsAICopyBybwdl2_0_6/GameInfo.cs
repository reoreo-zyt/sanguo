using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInfo
{
    // 游戏月份
    public static byte month = 1;
    // 游戏年份
    public static short years = 189;
    // 人类势力ID
    public static byte humanCountryId=1;
    // 游戏难度
    public static byte difficult = 3;
    // 记录信息数组
    public static string[] recordInfo = new string[3];
    // 最大保留列表
    public static List<string> maxRestainList = new List<string>();
    // 选择的武将名称
    public static string chooseGeneralName;
    // 选择的剧本
    public static string chooseScript;
    // 势力灭亡提示
    public static byte countryDieTips = 0;
    // 是否观看模式
    public static bool isWatch = false;
    // 显示的信息
    public static string ShowInfo;

    // 获取用户命令数量
    public static byte GetUserOrderNum()
    {
        // 获取人类势力拥有的城市数量
        byte CITY_NUM = CountryListCache.GetCountryByCountryId(humanCountryId).GetHaveCityNum();
        
        // 根据城市数量调整命令数量
        if (CITY_NUM < 3)
        {
            CITY_NUM = 3;
        }
        else if (CITY_NUM >= 3 && CITY_NUM <= 4)
        {
            CITY_NUM = 4;
        }
        else if (CITY_NUM >= 5 && CITY_NUM <= 7)
        {
            CITY_NUM = 6;
        }
        else if (CITY_NUM >= 8 && CITY_NUM <= 10)
        {
            CITY_NUM = 7;
        }
        else if (CITY_NUM >= 11)
        {
            CITY_NUM = 8;
        }

        return CITY_NUM;
    }

    // 增加游戏月份
    public static void addMonth()
    {
        month = (byte)(month + 1);
        
        if (month > 12)
        {
            years = (short)(years + 1);
            month = 1;
        }
    }



    // 假设 maxrestainList 是一个静态字段，存储 General 类型的对象
    public static List<General> maxrestainList = new List<General>();

    /// <summary>
    /// 根据武将ID获取武将对象。
    /// </summary>
    /// <param name="generalId">武将的ID。</param>
    /// <returns>如果找到，则返回武将对象；否则返回null。</returns>
    public static General GetGeneral(short generalId)
    {
        // 遍历列表中的每个元素
        foreach (General general in maxrestainList)
        {
            // 如果找到了匹配的武将ID，则返回该武将对象
            if (general.generalId == generalId)
            {
                return general;
            }
        }
        Debug.Log("未找到匹配的武将");
        // 没有找到匹配的武将，返回null
        return null;
    }

    /// <summary>
    /// 判断是否有自定义的武将。
    /// </summary>
    /// <returns>如果有自定义的武将，则返回true；否则返回false。</returns>
    public static bool haveCustomGeneral()
    {
        // 读取武将数据
        ReadMaxrestainGeneralFromFile();

        // 判断列表是否为空
        return maxrestainList.Count != 0;
    }

    /// <summary>
    /// 从列表中删除指定的武将，并保存到文件。
    /// </summary>
    /// <param name="general">要删除的武将对象。</param>
    /*
    public static void deleteMaxrestainGeneralToFile(General general)
    {
        // 从列表中移除指定的武将
        maxrestainList.Remove(general);

        // 保存修改后的列表到文件
        saveMaxrestainGeneralToFile();
    }
    */



    // 保存武将信息到文件
    public static void saveMaxRestainGeneralToFile()
    {
        // 创建一个字节数组用于存储数据
        List<General> maxRestainList = getMaxRestainList(); // 假设这是一个已经定义好的列表
        int listSize = maxRestainList.Count;
        byte[] data = new byte[listSize * 200 + 1];

        // 当前索引位置
        int index = 0;

        // 存储列表大小
        data[index++] = (byte)listSize;

        // 遍历列表
        foreach (var general in maxRestainList)
        {
            // 存储武将ID
            data[index++] = (byte)(general.generalId & 0xFF);
            data[index++] = (byte)(general.generalId >> 8);

            // 处理头像图像字符串
            string headImageString = general.headImage;
            byte[] headImageBytes = Encoding.UTF8.GetBytes(headImageString);
            data[index++] = (byte)headImageBytes.Length;
            for (int i = 0; i < headImageBytes.Length; i++)
            {
                data[index++] = headImageBytes[i];
            }

            // 处理武将名称字符串
            string generalName = general.generalName;
            byte[] generalNameBytes = Encoding.UTF8.GetBytes(generalName);
            data[index++] = (byte)generalNameBytes.Length;
            for (int j = 0; j < generalNameBytes.Length; j++)
            {
                data[index++] = generalNameBytes[j];
            }

            // 存储其他属性
            data[index++] = general.level;
            data[index++] = general.force;
            data[index++] = (byte)(general.generalSoldier & 0xFF);
            data[index++] = (byte)(general.generalSoldier >> 8);
            data[index++] = general.lead;
            data[index++] = general.political;
            data[index++] = general.getCurPhysical();
            data[index++] = general.IQ;
            data[index++] = general.getLoyalty();
            data[index++] = (byte)(general.experience & 0xFF);
            data[index++] = (byte)(general.experience >> 8);
            data[index++] = general.weapon;
            data[index++] = general.armor;
            data[index++] = general.army[0];
            data[index++] = general.army[1];
            data[index++] = general.army[2];
            data[index++] = general.maxPhysical;
            data[index++] = general.moral;
            data[index++] = general.leadExp;
            data[index++] = general.forceExp;
            data[index++] = general.IQExp;
            data[index++] = general.moralExp;
            data[index++] = general.politicalExp;
            data[index++] = (byte)(general.phase & 0xFF);
            data[index++] = (byte)(general.phase >> 8);
            data[index++] = (byte)(general.skills[0] & 0xFF);
            data[index++] = (byte)(general.skills[0] >> 8);
            data[index++] = (byte)(general.skills[1] & 0xFF);
            data[index++] = (byte)(general.skills[1] >> 8);
            data[index++] = (byte)(general.skills[2] & 0xFF);
            data[index++] = (byte)(general.skills[2] >> 8);
            data[index++] = (byte)(general.skills[3] & 0xFF);
            data[index++] = (byte)(general.skills[3] >> 8);
            data[index++] = (byte)(general.skills[4] & 0xFF);
            data[index++] = (byte)(general.skills[4] >> 8);
        }

        // 保存数据到文件
        try
        {
            // 使用FileStream创建或打开文件
            using (FileStream fileStream = File.OpenWrite("newps"))
            {
                // 写入数据
                fileStream.Write(data, 0, index);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("保存数据时发生错误: " + ex.Message);
        }
    }

    // 示例方法，用于获取武将列表
    private static List<General> getMaxRestainList()
    {
        // 这里应该返回一个实际的武将列表
        return new List<General>();
    }





    // 从文件中读取并解析武将信息
    public static void ReadMaxrestainGeneralFromFile()
    {
        FileStream fileStream = null;
        try
        {
            // 尝试打开文件流
            string filePath = Path.Combine(Application.persistentDataPath, "newps.dat"); // 假设文件为"newps.dat"
            if (File.Exists(filePath))
            {
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                // 如果文件中有数据，读取数据并解析
                if (fileStream.Length > 0)
                {
                    byte[] data = new byte[fileStream.Length];
                    fileStream.Read(data, 0, data.Length);
                    analysisMaxrestainGeneralInfoFromData(data, 0);
                }
            }

            // 尝试关闭文件流
            try
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            catch (IOException e)
            {
                // 忽略文件未打开的异常
                Debug.LogError("Error closing file stream: " + e.Message);
            }
            finally
            {
                fileStream = null;
            }
        }
        catch (System.Exception ex)
        {
            // 捕获异常并尝试关闭文件流
            Debug.LogError("Error reading general data: " + ex.Message);

            if (fileStream != null)
            {
                try
                {
                    fileStream.Close();
                }
                catch (IOException e)
                {
                    Debug.LogError("Error closing file stream after exception: " + e.Message);
                }
                finally
                {
                    fileStream = null;
                }
            }
        }
    }


    /// <summary>
    /// 分析最大保留的武将信息
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="offset">偏移量</param>


    // 解析数据并生成General对象列表
    private static int analysisMaxrestainGeneralInfoFromData(byte[] data, int index)
    {
        // 清空现有的General列表
        maxrestainList.Clear();

        // 获取General对象的数量
        byte generalNum = data[index++];
        byte byte1 = 0;
        byte byte2 = 0;

        // 遍历每一个General对象
        for (short i = 0; i < generalNum; i++)
        {
            General general = new General();

            // 解析generalId
            byte1 = data[index++];
            byte2 = data[index++];
            general.generalId = (short)((byte2 << 8) | (byte1 & 0xFF));

            // 解析headImage
            byte headImageLength = data[index++];
            byte[] headImageBytes = new byte[headImageLength];
            for (byte m = 0; m < headImageLength; m++)
            {
                headImageBytes[m] = data[index++];
            }
            try
            {
                general.headImage = Encoding.UTF8.GetString(headImageBytes);
            }
            catch (System.Exception)
            {
                // 处理异常情况
            }

            // 解析generalName
            byte generalNameLength = data[index++];
            byte[] generalNameBytes = new byte[generalNameLength];
            for (byte b1 = 0; b1 < generalNameLength; b1++)
            {
                generalNameBytes[b1] = data[index++];
            }
            try
            {
                general.generalName = Encoding.UTF8.GetString(generalNameBytes);
            }
            catch (System.Exception)
            {
                // 处理异常情况
            }

            // 解析其他属性
            general.level = data[index++];
            general.force = data[index++];
            byte1 = data[index++];
            byte2 = data[index++];
            general.generalSoldier = (short)((byte2 << 8) | (byte1 & 0xFF));
            general.lead = data[index++];
            general.political = data[index++];
            general.setCurPhysical(data[index++]);
            general.IQ = data[index++];
            general.SetLoyalty(data[index++]);
            byte1 = data[index++];
            byte2 = data[index++];
            general.experience = (short)((byte2 << 8) | (byte1 & 0xFF));

            if (general.experience > 0)
            {
                general.experience = 0;
            }

            general.weapon = data[index++];
            general.armor = data[index++];
            general.army[0] = data[index++];
            general.army[1] = data[index++];
            general.army[2] = data[index++];
            general.maxPhysical = data[index++];
            general.moral = data[index++];
            general.leadExp = data[index++];
            general.forceExp = data[index++];
            general.IQExp = data[index++];
            general.moralExp = data[index++];
            general.politicalExp = data[index++];
            general.phase = (short)((data[index + 1] << 8) | (data[index] & 0xFF));
            index += 2;

            // 解析技能
            for (int j = 0; j < 5; j++)
            {
                general.skills[j] = (short)((data[index + 1] << 8) | (data[index] & 0xFF));
                index += 2;
            }

            // 将解析后的General对象添加到列表
            maxrestainList.Add(general);
        }

        // 返回当前数据索引
        return index;
    }

}
 



