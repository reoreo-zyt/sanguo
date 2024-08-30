using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


// City 类假设用于表示城市的各种属性
[System.Serializable]
public class CityListCache : MonoBehaviour
{

    // 静态列表，用于存储城市数据
    public static List<City> cityList;

    // 定义城市数量+1的常量
    public static byte CITY_NUM = 49;
    // 空城集合
    public static List<City> unassignedCities = new List<City>();


    //添加空城集合
    public static void addUnassignedCities()
    {
        foreach (City city in cityList)
        {
            if (city.cityBelongKing == 0)
            {
                unassignedCities.Add(city);
            }
        }
    }

    // 清空所有城市列表
    public static void clearAllCities()
    {
        cityList.Clear();
    }

    // 根据城市ID获取城市对象
    public static City GetCityByCityId(byte id)
    {
        foreach (City city in cityList)
        {
            if (city.cityId == id)
            {
                return city;
            }
        }

        Debug.LogError("获取城池错误, CityId: " + id);
        return null;
    }


    // 根据索引获取城市对象
    public static City getCityByIndex(int index)
    {
        // 检查索引范围，并返回对应的城市
        if (index >= 0 && index < cityList.Count)
            return cityList[index];

        Debug.Log("索引超出范围: " + index);
        return null;
    }

    // 添加城市到列表
    public static void AddCity(City city)
    {
        cityList.Add(city);
    }

    // 获取城市数量
    public static byte getCityNum()
    {
        return (byte)cityList.Count;
    }
}

