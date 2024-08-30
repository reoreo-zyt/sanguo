using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Linq;



[CreateAssetMenu(fileName = "CountryList", menuName = "Scriptable Objects/CountryList")]
public class CountryListCache : ScriptableObject
{
    static byte maxCountryId;

    public static List<Country> countryList;


    // 清空所有势力列表
    public static void clearAllCountries()
    {
        countryList.Clear();
    }

    
    public static void AddCountry(Country country)
    {
        if (country.countryId == 0)
        {
            maxCountryId++;
            country.countryId = maxCountryId;
        }
        else if (maxCountryId < country.countryId)
        {
            maxCountryId = country.countryId;
        }

        short kingId = country.countryKingId;
        General general = GeneralListCache.GetGeneral(kingId);
        if (general != null)
            general.SetLoyalty(100);

        if (country.countryColor == null)
        {
            string tempColor;
            bool haveSameColor;
            do
            {
                tempColor = country.countryColor;
                haveSameColor = false;

                foreach (Country tempCountry in countryList)
                {
                    if (tempCountry.countryColor == tempColor)
                    {
                        haveSameColor = true;
                        break;
                    }
                }
            } while (haveSameColor);

            country.countryColor = tempColor;
        }

        countryList.Add(country);
    }

    public string getCountryColor(byte countryId)
    {
        string color = "FFFFFF";
        if (countryId > 0)
        {
            Country country = GetCountryByCountryId(countryId);
            if (country != null)
            {
                color = country.countryColor;
            }
        }
        return color;
    }
    

    
    public static void removeCountry(byte countryId)
    {
        Country country = GetCountryByCountryId(countryId);
        if (country == null) return;

        if (country.GetHaveCityNum() > 0)
        {
            UnityEngine.Debug.LogError($"{GeneralListCache.GetGeneral(country.countryKingId).generalName} 势力灭亡！但还有：{country.GetHaveCityNum()}个城池！");
            return;
        }

        General general = GeneralListCache.GetGeneral(country.countryKingId);
        if (general == null)
        {
            UnityEngine.Debug.Log($"{GameInfo.chooseGeneralName} 势力灭亡！君主已死亡！");
        }
        else
        {
            GameInfo.chooseGeneralName = general.generalName;
        }

        UnityEngine.Debug.Log($"势力: {GameInfo.chooseGeneralName} 灭亡!!! 剩余势力：{getCountrySize()}");
        /*
        if (GameInfo.humanCountryId == countryId)
        {
            GameInfo.countryDieTips = 3;
        }
        else
        {
            GameInfo.countryDieTips = 4;
            GameInfo.ShowInfo = $"{general.generalName} 势力灭亡了!";
        }
        */
        countryList.Remove(country);
        country.removeAllAlliance();
    }
    
    


    public static byte getCountrySize()
    {
        return (byte)countryList.Count;
    }

    public byte getCanBeChooseCountrySize()
    {
        int count = 0;
        foreach (Country country in countryList)
        {
            if (country.canBeChoose)
            {
                count++;
            }
        }
        return (byte)count;
    }

    public static Country GetCountryByCountryId(byte id)
    {
        return countryList.Find(country => country.countryId == id);
    }

    public static Country getCanBeChooseCountryByIndex(byte id)
    {
        if (countryList == null || countryList.Count == 0)
        {
            Debug.LogError("countryList 为 null 或为空");
            return null;
        }
        int i = 0;
        foreach (Country country in countryList)
        {
            if (country == null) // 处理空对象的情况
            {
                break;
            }

            if (country.canBeChoose) // 检查 canBeChoose
            {
                if (i == id) // 如果当前计数与目标 id 相同，返回该 country
                {
                    return country;
                }
                i++; // 增加计数器
            }
        }
        return null; // 没有找到匹配的 country，返回 null
    }


    public static Country GetCountryByKingId(short kingId)
    {
        return countryList.Find(country => country.countryKingId == kingId);
    }

    public static byte[] getCountryIdArrayBySort()
    {
        byte countrySize = getCountrySize();
        byte[] countryIdArray = new byte[countrySize];
        Country[] countries = countryList.ToArray();

        Array.Sort(countries, (a, b) => a.GetHaveCityNum().CompareTo(b.GetHaveCityNum()));

        for (int i = 0; i < countrySize; i++)
        {
            countryIdArray[i] = countries[i].countryId;
        }

        return countryIdArray;
    }

    public static Country getCountryByIndexId(byte id)
    {
        return countryList[id];
    }

    public static int GetEnemyAdjacentCityDefenseAbility(byte cityId, byte atkCityId)
    {
        City city = CityListCache.GetCityByCityId(cityId);
        City atkCity = CityListCache.GetCityByCityId(atkCityId);
        Country atkCountry = GetCountryByKingId(atkCity.cityBelongKing);
        int maxDefenseAbility = city.GetDefenseAbility();
        short[] cityIdArray = city.connectCityId;

        foreach (byte tempCityId in cityIdArray)
        {
            if (tempCityId != atkCityId)
            {
                City tempCity = CityListCache.GetCityByCityId(tempCityId);
                if (tempCity.cityBelongKing != 0)
                {
                    if (tempCity.cityBelongKing == atkCity.cityBelongKing || atkCountry.isAlliance(tempCityId))
                    {
                        maxDefenseAbility -= (int)(tempCity.getMaxAtkPower() * 0.2);
                    }
                    else
                    {
                        maxDefenseAbility += (int)(tempCity.getMaxAtkPower() * 0.1);
                    }
                }
            }
        }
        return maxDefenseAbility;
    }

    public static byte[] GetEnemyAdjacentCityIdArray(byte countryId)
    {
        List<byte> resultCityIdArray = new List<byte>();
        Country country = GetCountryByCountryId(countryId);
        int CITY_NUM = country.GetHaveCityNum();

        for (byte m = 0; m < CITY_NUM; m++)
        {
            byte otherCityId = country.getCity(m);
            short[] cityIdArray = CityListCache.GetCityByCityId(otherCityId).connectCityId;

            bool haveEnemy = false;

            foreach (byte cityId in cityIdArray)
            {
                short belongKing = CityListCache.GetCityByCityId(cityId).cityBelongKing;
                if (belongKing != country.countryKingId)
                {
                    Country otherCountry = GetCountryByKingId(belongKing);
                    if (otherCountry != null && otherCountry.getAllianceById(countryId) == null)
                    {
                        haveEnemy = true;
                        break;
                    }
                }
            }

            if (haveEnemy)
            {
                resultCityIdArray.Add(otherCityId);
            }
        }
        return resultCityIdArray.ToArray();
    }

    public static byte[] GetNoEnemyAdjacentCityIdArray(byte countryId)
    {
        List<byte> resultCityIdArray = new List<byte>();
        Country country = GetCountryByCountryId(countryId);
        int CITY_NUM = country.GetHaveCityNum();

        for (byte m = 0; m < CITY_NUM; m++)
        {
            byte otherCityId = country.getCity(m);
            short[] cityIdArray = CityListCache.GetCityByCityId(otherCityId).connectCityId;

            bool noHaveEnemy = true;

            foreach (byte cityId in cityIdArray)
            {
                short belongKing = CityListCache.GetCityByCityId(cityId).cityBelongKing;
                if (belongKing != country.countryKingId)
                {
                    Country otherCountry = GetCountryByKingId(belongKing);
                    if (otherCountry != null && otherCountry.getAllianceById(countryId) == null)
                    {
                        noHaveEnemy = false;
                        break;
                    }
                }
            }

            if (noHaveEnemy)
            {
                resultCityIdArray.Add(otherCityId);
            }
        }
        return resultCityIdArray.ToArray();
    }

    public static byte[] GetEnemyCityIdArray(byte cityId)
    {
        short kingId = CityListCache.GetCityByCityId(cityId).cityBelongKing;
        Country country = GetCountryByKingId(kingId);
        short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;
        List<byte> resultCityIdArray = new List<byte>();

        foreach (byte tempCityId in cityIdArray)
        {
            short belongKing = CityListCache.GetCityByCityId(tempCityId).cityBelongKing;
            if (belongKing != kingId)
            {
                Country otherCountry = GetCountryByKingId(belongKing);
                if (otherCountry == null || otherCountry.getAllianceById(country.countryId) == null)
                {
                    resultCityIdArray.Add(tempCityId);
                }
            }
        }
        return resultCityIdArray.ToArray();
    }

    public static byte[] getEnemyCityIdArray_new(byte cityId)
    {
        short kingId = CityListCache.GetCityByCityId(cityId).cityBelongKing;
        short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;
        List<byte> resultCityIdArray = new List<byte>();

        foreach (byte tempCityId in cityIdArray)
        {
            short belongKing = CityListCache.GetCityByCityId(tempCityId).cityBelongKing;
            if (belongKing != kingId)
            {
                resultCityIdArray.Add(tempCityId);
            }
        }
        return resultCityIdArray.ToArray();
    }


    // 获取敌方相邻的最大攻击力
    public static int GetEnemyAdjacentAtkPowerArray(byte cityId)
    {
        short kingId = CityListCache.GetCityByCityId(cityId).cityBelongKing;
        Country country = GetCountryByKingId(kingId);
        short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;
        int[] resultAtkPowerArray = new int[0];

        for (int i = 0; i < cityIdArray.Length; i++)
        {
            short belongKing = CityListCache.GetCityByCityId((byte)cityIdArray[i]).cityBelongKing;
            if (belongKing != kingId)
            {
                Country otherCountry = GetCountryByKingId(belongKing);
                if (otherCountry != null)
                {
                    if (otherCountry.getAllianceById(country.countryId) == null)
                    {
                        int[] tempResultAtkPowerArray = new int[resultAtkPowerArray.Length + 1];
                        for (int k = 0; k < resultAtkPowerArray.Length; k++)
                        {
                            tempResultAtkPowerArray[k] = resultAtkPowerArray[k];
                        }
                        tempResultAtkPowerArray[resultAtkPowerArray.Length] = CityListCache.GetCityByCityId((byte)cityIdArray[i]).getMaxAtkPower();
                        resultAtkPowerArray = tempResultAtkPowerArray;
                    }
                }
            }
        }

        if (resultAtkPowerArray.Length == 0)
        {
            return 0;
        }

        int maxAtkPower = resultAtkPowerArray[0];
        for (int j = 1; j < resultAtkPowerArray.Length; j++)
        {
            if (maxAtkPower < resultAtkPowerArray[j])
            {
                maxAtkPower = resultAtkPowerArray[j];
            }
        }

        return maxAtkPower;
    }

    public static int getOtherCityMaxAtkPower(byte cityId, byte beCityId)
    {
        short kingId = CityListCache.GetCityByCityId(cityId).cityBelongKing;
        Country country = GetCountryByKingId(kingId);
        short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;
        int[] resultAtkPowerArray = new int[0];

        for (int i = 0; i < cityIdArray.Length; i++)
        {
            if (beCityId != cityIdArray[i])
            {
                short belongKing = CityListCache.GetCityByCityId((byte)cityIdArray[i]).cityBelongKing;
                if (belongKing != kingId)
                {
                    Country otherCountry =  GetCountryByKingId(belongKing);
                    if (otherCountry != null && otherCountry.getAllianceById(country.countryId) == null)
                    {
                        int[] tempResultAtkPowerArray = new int[resultAtkPowerArray.Length + 1];
                        for (int k = 0; k < resultAtkPowerArray.Length; k++)
                        {
                            tempResultAtkPowerArray[k] = resultAtkPowerArray[k];
                        }
                        tempResultAtkPowerArray[resultAtkPowerArray.Length] = CityListCache.GetCityByCityId((byte)cityIdArray[i]).getMaxAtkPower();
                        resultAtkPowerArray = tempResultAtkPowerArray;
                    }
                }
            }
        }

        if (resultAtkPowerArray.Length == 0)
        {
            return 0;
        }

        int maxAtkPower = resultAtkPowerArray[0];
        for (int j = 1; j < resultAtkPowerArray.Length; j++)
        {
            if (maxAtkPower < resultAtkPowerArray[j])
            {
                maxAtkPower = resultAtkPowerArray[j];
            }
        }

        return maxAtkPower;
    }

    public static byte getAIOredrNum(byte curTurnsCountryId)
    {
        byte CITY_NUM = GetCountryByCountryId(curTurnsCountryId).GetHaveCityNum();
        if (CITY_NUM < 3)
        {
            CITY_NUM = 3;
        }
        else if (CITY_NUM > 8)
        {
            CITY_NUM = 8;
        }

        return CITY_NUM;
    }

}





// 定义一个名为Alliance的类，用于表示联盟信息
[System.Serializable] // 此属性允许Unity序列化此类，以便在Inspector中使用
public class Alliance
{
    // 存储联盟所属势力ID的字段
    public byte countryId;

    // 存储联盟持续月份的字段，已在构造函数中初始化
    private byte months;

    // Alliance类的构造函数，接受势力ID和月份作为参数
    public Alliance(byte countryId, byte months)
    {
        this.countryId = countryId; // 初始化势力ID
        this.months = months;      // 初始化月份
    }

    // 联盟持续月份的属性，提供getter和setter方法
    public byte Months
    {
        get { return months; }
        set { months = value; }
    }

    // 无参数的构造函数，可能用于Unity的序列化或其他初始化
    public Alliance() { }
}
