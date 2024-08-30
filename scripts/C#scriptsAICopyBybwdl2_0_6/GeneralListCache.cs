using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;


public class GeneralListCache 
{
    private static short maxGeneralId = 0;
    public static List<General> totalGeneralList = new List<General>();
    public static List<General> generalList = new List<General>();
    public static List<General> noDebutGeneralList = new List<General>();


    public static void clearAllGenerals()
    {
        // 清空所有将领列表
        generalList.Clear();
    }

    public static void clearAllNoDebutGenerals()
    {
        // 清空未登场的将领列表
        noDebutGeneralList.Clear();
        maxGeneralId = 0;
    }

    public static void DebutByYears(short years)
    {
        // 根据指定的年份让将领登场
        if (noDebutGeneralList.Count == 0)
        {
            return; // 如果没有未登场的将领，则直接返回
        }

        for (int i = 0; i < noDebutGeneralList.Count; i++)
        {
            General general = noDebutGeneralList[i];
            if (general.debutYears <= years) // 如果该将领的登场年份小于或等于当前年份
            {
                // 移除未登场将领列表中的当前将领，并将其加入已登场将领列表
                noDebutGeneralList.RemoveAt(i);
                i--; // 因为移除了元素，所以需要将索引回退一位
                generalList.Add(general);
                noDebutGeneralList.Remove(general);

                byte cityId = general.debutCity; // 获取将领的登场城市ID
                if (general.followGeneralId != 0) // 如果该将领跟随其他将领
                {
                    short followCityId = general.followGeneralId;
                    General followGeneral = GetGeneral(followCityId); // 获取跟随的将领
                    if (followGeneral != null)
                    {
                        cityId = followGeneral.debutCity; // 更新城市ID为跟随将领的登场城市
                        City city = CityListCache.GetCityByCityId(cityId);
                        if (followGeneral.isOffice == 1) // 如果跟随的将领是官员
                        {
                            if (city.getCityGeneralNum() >= 10) // 如果城市官员数量已满
                            {
                                if (city.GetOppositionGeneralNum() < 10) // 如果城市非官员数量未满
                                {
                                    city.AddOppositionGeneralId(general.generalId);
                                    Debug.Log("跟随将"+general.generalName+"前往"+city.cityName+"下野");
                                }
                            }
                            else // 如果城市官员数量未满
                            {
                                city.AddOfficeGeneralId(general.generalId);
                                Debug.Log("跟随将"+general.generalName+"成为"+city.cityName+"的官员");
                            }
                        }
                        else if (city != null) // 如果城市存在
                        {
                            if (city.GetOppositionGeneralNum() < 10) // 如果城市非官员数量未满
                            {
                                city.AddOppositionGeneralId(general.generalId);
                                Debug.Log("武将"+general.generalName+"前往"+city.cityName+"下野");
                            }
                        }
                    }
                }
                else if (general.debutCity == 0) // 如果将领没有指定的登场城市
                {
                    cityId = (byte) UnityEngine.Random.Range(0,CityListCache.CITY_NUM); // 随机选择一个城市ID
                    City city = CityListCache.GetCityByCityId(cityId);
                    city.AddNotFoundGeneralId(general.generalId); // 将将领添加到城市的未找到将领列表
                    Debug.Log("武将"+general.generalName+"前往"+city.cityName+"归隐");
                }
                else
                {
                    City city = CityListCache.GetCityByCityId(general.debutCity);
                    city.AddNotFoundGeneralId(general.generalId); // 将将领添加到指定城市的未找到将领列表
                    Debug.Log("武将"+general.generalName+"前往"+city.cityName+"归隐");
                }
            }
        }
    }


    /// <summary>
    /// 根据武将ID获取武将对象
    /// </summary>
    /// <param name="generalId">武将ID</param>
    /// <returns>找到的武将对象，如果没有找到则返回null</returns>
    public static General GetGeneral(int generalId)
    {
        // 遍历武将列表
        for (int i = 0; i < generalList.Count; i++)
        {
            General general = generalList[i];
            // 如果找到匹配的武将ID，则返回该武将对象
            if (general.generalId == generalId)
            {
                return general;
            }
        }
        // 如果没有找到匹配的武将，打印错误信息并返回null
        UnityEngine.Debug.Log("获取武将错误,generalId:" + generalId);
        return null;
    }

    /// <summary>
    /// 根据索引获取武将对象
    /// </summary>
    /// <param name="indexId">索引ID</param>
    /// <returns>指定索引位置的武将对象</returns>
    public static General GetGeneralByIndex(short indexId)
    {
        // 直接通过索引获取武将对象
        return generalList[indexId];
    }

    /// <summary>
    /// 根据索引获取未登场的武将对象
    /// </summary>
    /// <param name="indexId">索引ID</param>
    /// <returns>指定索引位置的未登场武将对象</returns>
    public static General GetNoDebutGeneralByIndex(short indexId)
    {
        // 直接通过索引获取未登场的武将对象
        return noDebutGeneralList[indexId];
    }

    /// <summary>
    /// 获取未登场的武将总数
    /// </summary>
    /// <returns>未登场武将的数量</returns>
    public static short GetTotalNoDebutGeneralNum()
    {
        // 计算未登场武将的数量
        int count = 0;
        for (int i = 0; i < noDebutGeneralList.Count; i++)
        {
            General general = noDebutGeneralList[i];
            // 如果对象不为空，则计数加一
            if (general != null) count++;
        }
        // 返回未登场武将的数量
        return (short)count;
    }



    /// <summary>
    /// 获取出仕武将数量
    /// </summary>
    /// <returns>总的武将数量</returns>
    public static short GetTotalGeneralNum()
    {
        int count = 0; // 初始化计数器

        foreach (General general in generalList) // 遍历武将列表
        {
            if (general == null)
            {
                break; // 如果元素为空，则退出循环
            }
            count++; // 增加计数器
        }

        return (short)count; // 返回计数结果
    }

    /// <summary>
    /// 添加未首秀的武将
    /// </summary>
    /// <param name="general">武将对象</param>
    public static void AddNoDebutGeneral(General general)
    {
        if (general.generalId > maxGeneralId)
        {
            maxGeneralId = general.generalId; // 更新最大武将ID
        }

        noDebutGeneralList.Add(general); // 添加到未首秀武将列表
    }

    /// <summary>
    /// 添加武将
    /// </summary>
    /// <param name="general">武将对象</param>
    public static void AddGeneral(General general)
    {
        if (general.generalId == -1)
        {
            general.generalId = (short)(maxGeneralId + 1); // 如果ID为0，则分配新的ID
        }

        if (general.generalId > maxGeneralId)
        {
            maxGeneralId = general.generalId; // 更新最大武将ID
        }

        generalList.Add(general); // 添加到武将列表
    }



    // 当武将死亡时调用此方法
    public static void GeneralDie(short generalId)
    {
        // 获取指定ID的武将对象
        General general = GetGeneral(generalId);

        // 如果武将不存在，则返回
        if (general == null)
            return;

        // 设置当前选择的武将名称
        GameInfo.chooseGeneralName = general.generalName;

        // 获取武将所在的城市ID
        byte cityId = general.debutCity;

        // 通过城市ID获取城市对象
        City city = CityListCache.GetCityByCityId(cityId);

        // 移除城市中的官员列表中的武将ID
        city.removeOfficeGeneralId(generalId);

        // 移除城市中的失踪武将列表中的武将ID
        city.removeNotFoundGeneralId(generalId);

        // 移除城市中的敌对武将列表中的武将ID
        city.RemoveOppositionGeneralId(generalId);

        // 将武将是否在职设置为0（假定0表示不在职）
        general.isOffice = 0;

        // 通过君主ID获取势力对象
        Country country = CountryListCache.GetCountryByKingId(generalId);

        // 如果势力存在
        if (country != null)
        {
            // 输出君主死亡的消息
            Debug.Log("君主：" + general.generalName + "死亡了!!");

            // 如果是玩家控制的势力
            if (GameInfo.humanCountryId == country.countryId)
            {
                // 设置显示信息为君主死亡
                GameInfo.ShowInfo = general.generalName + " 君主死亡!";

                // 如果势力还有城市
                if (country.GetHaveCityNum() > 0)
                {
                    // 设置势力灭亡提示为特定值
                    GameInfo.countryDieTips = 2;
                }
                else
                {
                    // 设置势力灭亡提示为另一个值
                    GameInfo.countryDieTips = 3;

                    // 设置显示信息为势力灭亡
                    GameInfo.ShowInfo = general.generalName + " 势力灭亡了!";
                }
            }
            else
            {
                // 获取势力拥有的城市数量
                byte CITY_NUM = country.GetHaveCityNum();

                // 如果势力还有城市
                if (CITY_NUM > 0)
                {
                    // 如果只有一个城市且正在战争中
                    if (CITY_NUM == 1 && WarInfo.curWarCityId == country.getCity(0))
                    {
                        // 设置势力灭亡提示为特定值
                        GameInfo.countryDieTips = 4;

                        // 设置显示信息为势力灭亡
                        GameInfo.ShowInfo = general.generalName + " 势力灭亡了!";
                    }
                    else
                    {
                        // 设置势力灭亡提示为另一个值
                        GameInfo.countryDieTips = 1;

                        // 继承新的君主
                        int newKingGeneralId = country.Inherit();

                        // 设置显示信息为新君主继位
                        GameInfo.ShowInfo = general.generalName + "死亡,新君主 " + GetGeneral(newKingGeneralId).generalName + " 继位!";
                    }
                }
                else
                {
                    // 设置势力灭亡提示为特定值
                    GameInfo.countryDieTips = 4;

                    // 设置显示信息为势力灭亡
                    GameInfo.ShowInfo = general.generalName + " 势力灭亡了!";
                }
            }
        }
        else
        {
            // 如果不是君主，则输出普通武将死亡的消息
            Debug.Log("武将：" + general.generalName + "死亡了!!");
        }
    }




    /// <summary>
    /// 增加领导力经验值
    /// </summary>
    /// <param name="generalId">武将ID</param>
    /// <param name="exp">经验值</param>
    public static void addLeadExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addLeadExp(exp);
        }
    }

    /// <summary>
    /// 增加武力经验值
    /// </summary>
    /// <param name="generalId">武将ID</param>
    /// <param name="exp">经验值</param>
    public static void addforceExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addforceExp(exp);
        }
    }

    /// <summary>
    /// 增加智商经验值
    /// </summary>
    /// <param name="generalId">武将ID</param>
    /// <param name="exp">经验值</param>
    public static void addIQExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addIQExp(exp);
        }
    }

    /// <summary>
    /// 增加政治能力经验值
    /// </summary>
    /// <param name="generalId">武将ID</param>
    /// <param name="exp">经验值</param>
    public static void addPoliticalExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addPoliticalExp(exp);
        }
    }

    /// <summary>
    /// 增加德行经验值
    /// </summary>
    /// <param name="generalId">武将ID</param>
    /// <param name="exp">经验值</param>
    public static void addMoralExp(short generalId, byte exp)
    {
        General general = GetGeneral(generalId);
        if (general != null)
        {
            general.addMoralExp(exp);
        }
    }
}


// 战争信息类，用于存储与战争相关的静态数据
public static class WarInfo
{
    // 当前战争发生的城市ID
    public static byte curWarCityId;
}

[System.Serializable]
public class RootObject
{
    public List<General> generals;
}