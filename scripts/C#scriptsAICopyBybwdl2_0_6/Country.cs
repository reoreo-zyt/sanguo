using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class Country
{    // 定义公开的字段
    public byte countryId; // 势力ID
    public short countryKingId;// 君主ID
    public string countryColor;// 势力颜色
    public short power; // 力量值
    public bool canBeChoose;// 是否可以被选择
    [JsonProperty("inheritGeneralIds[]")] public short[] inheritGeneralIds; // 继承武将ID数组

    // 用于存储城市的列表
    [SerializeField] public List<byte> cities= new List<byte>();//城市列表
    [SerializeField] public List<Alliance> allianceList;// 盟友列表


    // 使用byte来表示是否轮到这个势力行动
    public byte isTurns = 1; // 是否轮到行动 (1 表示是)
    

    // 添加继承武将ID的方法
    public void addInheritGeneralId(short generalId)
    {
        short[] tempInheritGeneralIds = new short[this.inheritGeneralIds.Length + 1];
        Array.Copy(this.inheritGeneralIds, 0, tempInheritGeneralIds, 0, this.inheritGeneralIds.Length);
        tempInheritGeneralIds[tempInheritGeneralIds.Length - 1] = generalId;
        this.inheritGeneralIds = tempInheritGeneralIds;
    }

    public byte getCityId(short generalId)
    {
        foreach (byte cityId in this.cities)
        {
            // 根据城市ID获取具体的City对象
            City city = CityListCache.GetCityByCityId(cityId); // 你需要实现或使用的查找方法

            // 获取该城市的将军ID数组
            short[] generalIdArray = city.getCityOfficeGeneralIdArray();

            for (int i = 0; i < generalIdArray.Length; i++)
            {
                if (generalIdArray[i] == generalId)
                {
                    return cityId;
                }
            }
        }
        return 0; // C#中，byte不能为0，因此要进行强制转换
    }


    int IntSF(short generalId)
    {
        General general = GeneralListCache.GetGeneral(generalId); // 假设 GetGeneral 是一个静态方法
        int score = general.IQ + general.lead + general.moral;

        // IQ 条件
        if (general.IQ >= 95) score += 100;
        else if (general.IQ >= 90) score += 70;
        else if (general.IQ >= 80) score += 40;
        else if (general.IQ >= 70) score += 20;

        // lead 条件
        if (general.lead >= 95) score += 50;
        else if (general.lead >= 90) score += 30;
        else if (general.lead >= 80) score += 20;
        else if (general.lead >= 70) score += 10;

        // Moral 条件
        if (general.moral >= 95) score += 50;
        else if (general.moral >= 90) score += 40;
        else if (general.moral >= 80) score += 20;
        else if (general.moral >= 70) score += 10;

        return score;
    }



    // 获取继承武将ID的方法
    public short getInheritGeneralId()
    {
        // 首先检查 inheritGeneralIds 数组
        foreach (short id in inheritGeneralIds)
        {
            General general = GeneralListCache.GetGeneral(id);
            if (general != null && getCityId(id) != 0)
            {
                return id;
            }
        }

        // 初始化最大值
        int maxValue = 0;
        short generalId = 0;

        // 遍历国家下辖的城市集合
        foreach (byte cityId in this.cities)  // 假设 this.citys 是 List<City>
        {
            // 根据城市ID获取具体的City对象
            City city = CityListCache.GetCityByCityId(cityId); // 你需要实现或使用的查找方法
            // 获取该城市的将领 ID 数组
            short[] generalIdArray = city.getCityOfficeGeneralIdArray();

            // 遍历将领 ID 数组并计算其分数
            foreach (short id in generalIdArray)
            {
                int value = IntSF(id);
                if (value > maxValue)
                {
                    maxValue = value;
                    generalId = id;
                }
            }
        }

        // 返回分数最高的将领 ID
        return generalId;
    }









    // 获取城市ID
    public byte getCityId(int generalId)
    {
        // 遍历城市列表
        foreach (byte cityId in cities) // 使用foreach代替while循环和elements()
        {
            // 获取城市的武将ID数组
            short[] generalIdArray = CityListCache.GetCityByCityId(cityId).getCityOfficeGeneralIdArray();

            // 检查武将ID数组中是否存在给定的武将ID
            for (int i = 0; i < generalIdArray.Length; i++)
            {
                if (generalIdArray[i] == generalId)
                {
                    // 找到了对应的武将ID，返回城市ID
                    return cityId;
                }
            }
        }
        UnityEngine.Debug.Log("没有找到对应的武将ID");
        //Debug.Log("没有找到对应的武将ID");
        // 如果没有找到对应的武将ID，返回0
        return 0xFF;
    }

    // 计算武将的综合分数
    public int CalculateGeneralScore(short generalId)
    {
        // 获取武将对象
        General general = GeneralListCache.GetGeneral(generalId);

        // 初始化综合分数
        int score = general.IQ + general.lead + general.moral;

        // 根据IQ增加分数
        if (general.IQ >= 95)
        {
            score += 100;
        }
        else if (general.IQ >= 90)
        {
            score += 70;
        }
        else if (general.IQ >= 80)
        {
            score += 40;
        }
        else if (general.IQ >= 70)
        {
            score += 20;
        }

        // 根据lead增加分数
        if (general.lead >= 95)
        {
            score += 50;
        }
        else if (general.lead >= 90)
        {
            score += 30;
        }
        else if (general.lead >= 80)
        {
            score += 20;
        }
        else if (general.lead >= 70)
        {
            score += 10;
        }

        // 根据moral增加分数
        if (general.moral >= 95)
        {
            score += 50;
        }
        else if (general.moral >= 90)
        {
            score += 40;
        }
        else if (general.moral >= 80)
        {
            score += 20;
        }
        else if (general.moral >= 70)
        {
            score += 10;
        }

        // 返回综合分数
        return score;
    }

    

    // 执行继承武将操作
    public short Inherit()
    {
        // 获取继承武将ID
        short inheritGeneralIds = ((short)getInheritGeneralId());

        // 如果找到了符合条件的武将ID
        if (inheritGeneralIds != 0)
        {
            // 执行继承操作
            Inherit(inheritGeneralIds);
        }

        // 返回继承的武将ID
        return inheritGeneralIds;
    }



    // 执行继承操作
    public void Inherit(int inheritGeneralIds)
    {
        // 获取拥有的城市数量
        int CITY_NUM = GetHaveCityNum();

        // 更新每个城市的归属
        for (byte i = 0; i < CITY_NUM; i++)
        {
            // 获取城市对象并更新归属君主ID
            City curCity = CityListCache.GetCityByCityId(getCity(i));
            curCity.cityBelongKing = (short)inheritGeneralIds;
        }

        // 获取继承武将所在的城市ID
        byte cityId = getCityId((int)inheritGeneralIds);

        // 如果找不到对应的武将所在城市，则直接返回
        if (cityId == 0)
            return;

        // 获取城市对象并任命太守
        City liveCity = CityListCache.GetCityByCityId(cityId);
        liveCity.AppointmentPrefect(inheritGeneralIds);

        // 更新武将的忠诚度
        General general = GeneralListCache.GetGeneral(inheritGeneralIds);
        general.SetLoyalty(100);

        // 更新势力君主ID
        this.countryKingId = (short)inheritGeneralIds;
    }

    // 获取势力的力量值
    public short getPower()
    {
        // 返回力量值
        return 0;
    }

    // 获取拥有的城市数量
    public byte GetHaveCityNum()
    {
        Debug.Log("此势力拥有"+cities.Count+"座城池");
        // 直接返回城市列表的大小
        return (byte)cities.Count;
    }

    public void AddCity(byte cityId)
    {
        // 如果城市ID已经在列表中，跳过添加
        if (cities.Contains(cityId))
        {
            return;
        }

        // 获取城市对象
        City city = CityListCache.GetCityByCityId(cityId);

        // 将城市的所属国王ID设置为当前国家的国王ID
        city.cityBelongKing = this.countryKingId;

        // 将城市ID添加到列表中
        this.cities.Add(cityId);
    }

    // 移除城市
    public void RemoveCity(byte cityId)
    {
        City city = CityListCache.GetCityByCityId(cityId);  // 获取城市对象
        if (city != null)
        {
            city.prefectId = 0;  // 清除城市的太守ID
            city.cityBelongKing = 0;  // 清除城市的归属国家

            this.cities.Remove(cityId);  // 从城市列表中移除城市

            byte count = GetHaveCityNum();  // 获取当前拥有的城市数量
        }
    }



    // 获取势力所属城市的ID数组
    public byte[] GetCities()
    {
        byte[] result = new byte[this.cities.Count];
        for (int i = 0; i < this.cities.Count; i++)
        {
            result[i] = this.cities[i];
        }
        return result;
    }


    // 通过城市ID获取城市信息
    public byte GetCity(byte cityId)
    {
        foreach (byte id in this.cities)
        {
            // 获取城市对象
            City city = CityListCache.GetCityByCityId(id);

            if (city.cityId == cityId)
            {
                return city.cityId; // 找到城市，返回城市ID
            }
        }

        // 如果没有找到城市，打印错误信息
        Console.Error.WriteLine("未查询到城池编号：" + cityId);

        // 返回 0 作为无效的城市ID
        return 0;
    }



    // 通过索引获取城市ID
    public byte getCity(int index)
    {
        // 检查索引是否在合法范围内
        if (index < 0 || index >= this.cities.Count)
        {
            Debug.LogError("下标 " + index + " 未查询到城池");
            return 0; // 使用0代替0作为无效ID
        }

        // 直接返回城市ID
        return this.cities[index];
    }





    /*     */
    /*     */

    // 检查城市是否属于联盟
    public bool isAlliance(byte cityId)
    {
        // 获取城市对象
        City city = CityListCache.GetCityByCityId(cityId);

        // 获取归属君主ID
        short belongKing = city.cityBelongKing;

        // 如果归属君主ID为0，则不属于任何势力
        if (belongKing == 0)
            return false;

        // 获取归属君主所属的势力
        Country otherCountry = CountryListCache.GetCountryByKingId(belongKing);

        // 如果没有找到对应的势力，则不属于任何联盟
        if (otherCountry == null)
            return false;

        // 检查是否有联盟关系
        Alliance alliance = getAllianceById(otherCountry.countryId);

        // 如果没有找到对应的联盟，则不属于任何联盟
        if (alliance == null)
            return false;

        // 属于联盟
        return true;
    }



    // 获取联盟大小
    public byte GetAllianceSize()
    {
        // 初始化计数器
        byte size = 0;

        // 遍历联盟列表
        foreach (var alliance in allianceList)
        {
            // 如果联盟对象不为空
            if (alliance != null)
            {
                // 计数器加一
                size++;
            }
        }

        // 返回联盟大小
        return size;
    }

    // 通过索引获取联盟对象
    public Alliance getAlliance(int index)
    {
        // 获取指定索引处的对象
        object obj = allianceList[index];

        // 如果对象为空
        if (obj == null)
        {
            // 返回null
            return null;
        }

        // 强制转换为Alliance对象
        Alliance alliance = (Alliance)obj;

        // 返回联盟对象
        return alliance;
    }


    /*     */
    /*     */
    /*     */

    // 通过势力ID获取联盟对象
    public Alliance getAllianceById(byte countryId)
    {
        // 遍历联盟列表
        foreach (var alliance in allianceList)
        {
            // 如果找到了匹配的势力ID
            if (alliance.countryId == countryId)
            {
                // 返回联盟对象
                return alliance;
            }
        }

        // 如果没有找到对应的联盟
        return null;
    }

    // 添加联盟
    public void AddAlliance(Alliance alliance)
    {
        // 检查是否已经有这个势力的联盟
        Alliance existingAlliance = getAllianceById(alliance.countryId);

        // 如果已经有这个势力的联盟，则直接返回
        if (existingAlliance != null)
            return;

        // 添加新的联盟到列表
        allianceList.Add(alliance);

        // 获取对应的势力
        Country country = CountryListCache.GetCountryByCountryId(alliance.countryId);

        // 如果没有找到对应的势力，则直接返回
        if (country == null)
            return;

        // 在对应的势力中添加联盟
        Alliance reverseAlliance = new Alliance(this.countryId, alliance.Months);
        country.AddAlliance(reverseAlliance);
    }

    // 通过另一个势力ID添加联盟
    public void AddAlliance(byte otherCountryId)
    {
        // 检查是否已经有这个势力的联盟
        Alliance existingAlliance = getAllianceById(otherCountryId);

        // 如果已经有这个势力的联盟，则直接返回
        if (existingAlliance != null)
            return;

        // 创建新的联盟
        Alliance alliance = new Alliance();
        alliance.countryId = otherCountryId;
        alliance.Months = 12;

        // 添加新的联盟到列表
        allianceList.Add(alliance);

        // 获取对应的势力
        Country country = CountryListCache.GetCountryByCountryId(otherCountryId);

        // 创建反向联盟
        Alliance reverseAlliance = new Alliance(this.countryId, 12);

        // 在对应的势力中添加联盟
        country.AddAlliance(reverseAlliance);
    }
    
   
    // 移除联盟
    public bool removeAlliance(byte countryId)
    {
        bool result = false;

        for (int i = 0; i < allianceList.Count; i++)
        {
            Alliance alliance = allianceList[i];
            if (alliance.countryId == countryId)
            {
                allianceList.Remove(alliance); // 在C#中直接从List中删除该元素
                Country country = CountryListCache.GetCountryByCountryId(countryId);
                if (country == null) return false;
                //if (countryId == GameInfo.humanCountryId)
                //{
                    //result = true;
                //}
                //country.removeAlliance(this.countryId);
                break;
            }
        }

        return result;
    }
    

    // 移除所有联盟
    public void removeAllAlliance()
    {
        while (allianceList.Count > 0)
        {
            Alliance alliance = allianceList[0];
            allianceList.RemoveAt(0); // 移除列表中的第一个元素
            Country country = CountryListCache.GetCountryByCountryId(alliance.countryId);
            if (country != null)
            {
                country.removeAlliance(this.countryId);
            }
        }
    }


    // 获取没有联盟关系的势力ID数组
    public byte[] GetNoCountryIdAllianceCountryIdArray()
    {
        // 初始化势力ID数组
        List<byte> countryIdList = new List<byte>();

        // 遍历所有势力
        for (byte i = 0; i < CountryListCache.getCountrySize(); i++)
        {
            // 获取当前势力
            Country country = CountryListCache.getCountryByIndexId(i);

            // 如果找到了对应的势力并且该势力至少有一个城市
            if (country != null && country.GetHaveCityNum() >= 1 &&
                country.countryId != this.countryId)
            {
                // 标记是否有联盟
                bool haveAlliance = false;

                // 遍历联盟列表
                foreach (var alliance in allianceList)
                {
                    // 如果找到了匹配的联盟
                    if (alliance.countryId == country.countryId)
                    {
                        // 设置有联盟标记
                        haveAlliance = true;
                        // 结束循环
                        break;
                    }
                }

                // 如果没有联盟
                if (!haveAlliance)
                {
                    // 将当前势力ID添加到列表
                    countryIdList.Add(country.countryId);
                }
            }
        }

        // 将列表转换为数组并返回
        return countryIdList.ToArray();
    }
    
    // 获取没有联盟关系的势力数量
    public byte getNoAllianceCountrySize()
    {
        // 调用方法获取没有联盟关系的势力ID数组
        byte[] noAllianceCountryIds = GetNoCountryIdAllianceCountryIdArray();

        // 返回数组长度作为势力数量
        return (byte)noAllianceCountryIds.Length;
    }



    // 获取与敌对势力相邻的城市ID数组
    public byte[] GetEnemyAdjacentCityIdArray()
    {
        // 创建一个空的字节列表来存放结果
        List<byte> resultCityIdList = new List<byte>();

        // 遍历城市ID列表
        foreach (byte cityId in cities)
        {
            // 获取当前城市的连接城市ID数组
            short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;

            // 标记是否有敌对城市
            bool haveEnemyCity = false;

            // 遍历连接城市ID数组
            foreach (byte connectCityId in cityIdArray)
            {
                // 获取连接城市的所属君主ID
                short belongKing = CityListCache.GetCityByCityId(connectCityId).cityBelongKing;

                // 如果连接城市的君主ID不是当前势力的君主ID
                if (belongKing != this.countryKingId)
                {
                    // 获取对应的势力
                    Country otherCountry = CountryListCache.GetCountryByKingId(belongKing);

                    // 如果找到了对应的势力并且该势力没有联盟
                    if (otherCountry != null && otherCountry.getAllianceById(otherCountry.countryId) == null)
                    {
                        // 设置有敌对城市标记
                        haveEnemyCity = true;
                        // 结束循环
                        break;
                    }
                }
            }

            // 如果有敌对城市
            if (haveEnemyCity)
            {
                // 将当前城市的ID添加到结果列表
                resultCityIdList.Add(cityId);
            }
        }

        // 将列表转换为数组并返回
        return resultCityIdList.ToArray();
    }



    // 获取与非敌对势力相邻的城市ID数组
    public byte[] GetNoEnemyAdjacentCityIdArray()
    {
        // 创建一个空的字节数组来存放结果
        List<byte> resultCityIdList = new List<byte>();

        // 获取与敌对势力相邻的城市ID数组
        byte[] enemyAdjacentCityIdArray = GetEnemyAdjacentCityIdArray();

        // 如果所有城市都是与敌对势力相邻，则直接返回空数组
        if (enemyAdjacentCityIdArray.Length == GetHaveCityNum())
        {
            return resultCityIdList.ToArray();
        }

        // 遍历城市列表
        foreach (byte cityId in cities)
        {
            // 标记是否是与敌对势力相邻的城市
            bool isAdjacentCity = false;

            // 遍历与敌对势力相邻的城市ID数组
            foreach (byte adjacentCityId in enemyAdjacentCityIdArray)
            {
                // 如果找到了匹配的城市ID
                if (adjacentCityId == cityId)
                {
                    // 设置是与敌对势力相邻的城市标记
                    isAdjacentCity = true;
                    // 结束循环
                    break;
                }
            }

            // 如果不是与敌对势力相邻的城市
            if (!isAdjacentCity)
            {
                // 将当前城市的ID添加到结果列表
                resultCityIdList.Add(cityId);
            }
        }

        // 将列表转换为数组并返回
        return resultCityIdList.ToArray();
    }



    // 必须上任
    public bool mustShangRen()
    {
        byte[] adjacentCity = GetEnemyAdjacentCityIdArray();
        bool flag = false;

        if (!haveGrainShop())
            return flag;

        for (int index = 0; index < adjacentCity.Length; index++)
        {
            byte curCity = adjacentCity[index];
            if (curCity <= 0)
                break;

            City city = CityListCache.GetCityByCityId(curCity);
            int needFood = city.needFoodToHarvest() + city.needFoodWarAMonth();

            if (city.GetFood() < needFood && city.GetMoney() > 200)
            {
                int buyNum = needFood - city.GetFood();
                buyNum = System.Math.Min(30000 - city.GetFood(), buyNum);

                if (buyNum >= 100 || city.GetFood() <= 100)
                {
                    if (buyNum > city.GetMoney() * 4 / 3)
                    {
                        short buy = (short)((city.GetMoney() - 50) * 4 / 3);
                        city.AddFood(buy);
                        city.SetMoney((short)50);
                        UnityEngine.Debug.Log($"{city.cityName} + buy + {city.GetFood()} + {city.GetMoney()}");
                    }
                    else
                    {
                        city.AddFood((short)buyNum);
                        city.DecreaseMoney((short)(buyNum * 3 / 4));
                        UnityEngine.Debug.Log($"{city.cityName} + buyNum + {city.GetFood()} + {city.GetMoney()}");
                    }
                    flag = true;
                }
            }
        }

        for (int index1 = 0; index1 < adjacentCity.Length; index1++)
        {
            byte curCity = adjacentCity[index1];
            if (curCity <= 0)
                break;

            City city = CityListCache.GetCityByCityId(curCity);
            int needFood = city.needFoodToHarvest() + city.needFoodWarAMonth();

            if (city.GetFood() > needFood + 200)
            {
                int sellNum = city.GetFood() - needFood - 200;
                sellNum = System.Math.Min(30000 - city.GetMoney(), sellNum);

                if (sellNum >= 50)
                {
                    city.DecreaseFood((short)sellNum);
                    city.AddMoney((short)(sellNum * 3 / 4));
                    UnityEngine.Debug.Log($"{city.cityName} + sellNum + {(sellNum * 3 / 4)}+ {city.GetMoney()} + {city.GetFood()}");
                    flag = true;
                }
            }
            else if (city.GetMoney() <= 0)
            {
                int needMoney = city.needAllSalariesMoney();
                int needSellFood = needMoney * 4 / 3;

                if (needSellFood >= city.GetFood() / 2)
                    return flag;

                city.AddMoney((short)needMoney);
                city.DecreaseFood((short)needSellFood);
                UnityEngine.Debug.Log($"{city.cityName} + {needSellFood} + needMoney + {city.GetFood()}");
            }
        }

        byte[] noAdjacentCity = GetNoEnemyAdjacentCityIdArray();
        for (int b1 = 0; b1 < noAdjacentCity.Length; b1++)
        {
            byte curCity = noAdjacentCity[b1];
            if (curCity <= 0)
                break;

            City city = CityListCache.GetCityByCityId(curCity);
            int needFood = city.needFoodToHarvest();

            if (city.GetFood() > needFood + 50)
            {
                int sellNum = city.GetFood() - needFood - 50;
                sellNum = System.Math.Min(30000 - city.GetMoney(), sellNum);

                if (sellNum >= 50)
                {
                    city.DecreaseFood((short)sellNum);
                    city.AddMoney((short)(sellNum * 3 / 4));
                    UnityEngine.Debug.Log($"{city.cityName} + sellNum + {(sellNum * 3 / 4)}+ {city.GetMoney()} + {city.GetFood()}");
                    flag = true;
                }
            }
            else if (city.GetMoney() <= 0)
            {
                int needMoney = city.needAllSalariesMoney();
                int needSellFood = needMoney * 4 / 3;

                if (needSellFood >= city.GetFood() / 2)
                    return flag;

                city.AddMoney((short)needMoney);
                city.DecreaseFood((short)needSellFood);
                UnityEngine.Debug.Log($"{city.cityName} + {needSellFood} + needMoney + {city.GetFood()}");
            }
        }

        return flag;
    }

    // 判断是否有粮店的方法
    public bool haveGrainShop()
    {
        // 遍历势力内的所有城市
        foreach (byte cityId in cities)
        {
            // 根据城市ID从缓存中获取城市对象
            City cityFromCache = CityListCache.GetCityByCityId(cityId);

            // 检查城市的k_byte_array1d_fld字段是否包含粮店标志（0x8）
            if ((cityFromCache.k_byte_array1d_fld & 0x8) == 0x8)
            {
                return true;  // 如果有粮店，返回true
            }
        }
        return false;  // 如果没有粮店，返回false
    }


    // 运输金钱
    public bool transportMoney()
    {
        byte[] cityIds = GetCities();
        City bestNeedMoneyCity = null;
        int bestNeedMoney = 0;
        City bestRichMoneyCity = null;
        int bestRichMoney = 0;

        for (int index = 0; index < cityIds.Length; index++)
        {
            byte cityId = cityIds[index];
            City city = CityListCache.GetCityByCityId(cityId);
            int needFood = 0;
            int needMoney = 0;
            bool isNearEnemy = CityIsNearEnemy(cityId);

            if (isNearEnemy)
            {
                needFood = city.needFoodToHarvest() + city.needFoodWarAMonth();
                needMoney += (int)(needMoney + city.getAllSoldierNum() * 0.2 + (city.needAllSalariesMoney() * 12));
            }
            else
            {
                needFood = city.needFoodToHarvest();
                needMoney += city.needAllSalariesMoney() * 12;
            }

            if (city.GetFood() < needFood)
            {
                needMoney = (needFood - city.GetFood()) * 3 / 4;
            }

            if (city.GetMoney() < needMoney)
            {
                if (needMoney - city.GetMoney() > bestNeedMoney)
                {
                    bestNeedMoney = needMoney - city.GetMoney();
                    bestNeedMoneyCity = city;
                }
            }
            else if (city.GetMoney() - needMoney > bestRichMoney)
            {
                bestRichMoney = city.GetMoney() - needMoney;
                bestRichMoneyCity = city;
            }
        }

        if (bestNeedMoneyCity != null && bestRichMoneyCity != null)
        {
            int transportMoney = (bestRichMoney > bestNeedMoney) ? bestNeedMoney : bestRichMoney;
            bestRichMoneyCity.DecreaseMoney((short)transportMoney);
            bestNeedMoneyCity.AddMoney((short)transportMoney);
            UnityEngine.Debug.Log($"{bestRichMoneyCity.cityName} 运输 {transportMoney} 金钱到 {bestNeedMoneyCity.cityName}");
            return true;
        }

        return false;
    }



    // 学习
    public bool study()
    {
        short studyCount = 0;

        // 枚举所有的城市
        foreach (byte cityId in this.cities)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            // 累加所有城市的总学习值
            studyCount += city.studyOfAllGeneral();
        }

        // 如果学习值大于0，则返回true
        return studyCount > 0;
    }

    // 更换将领
    private bool ChangeGeneral(City city, City otherCity)
    {
        // 获取其他城市中战斗力最小的武将的ID
        short minBattlePowerGeneralId = otherCity.getMinBattlePowerGeneralId();
        // 根据ID从缓存中获取武将对象
        General minBattlePowerGeneral = GeneralListCache.GetGeneral(minBattlePowerGeneralId);
        // 获取该武将的战斗力
        double minBattlePower = minBattlePowerGeneral.GetBattlePower();

        // 获取当前城市中战斗力最大的武将的ID
        short maxBattlePowerGeneralId = city.getMaxBattlePowerGeneralId();
        // 根据ID从缓存中获取武将对象
        General battlePowerGeneral = GeneralListCache.GetGeneral(maxBattlePowerGeneralId);
        // 获取该武将的战斗力
        double battlePower = battlePowerGeneral.GetBattlePower();

        // 如果当前城市中战斗力最大的武将的战斗力大于其他城市中战斗力最小的武将
        if (battlePower > minBattlePower)
        {
            // 调换武将，将当前城市的战斗力最大武将与其他城市的战斗力最小武将交换
            ChangeGeneral(city.cityId, maxBattlePowerGeneralId, otherCity.cityId, minBattlePowerGeneralId);

            // 输出日志，记录武将调换信息
            UnityEngine.Debug.Log($"{city.cityName} 的 {battlePowerGeneral.generalName} 与 {otherCity.cityName} 的 {minBattlePowerGeneral.generalName} 进行了交换。");

            // 返回 true，表示交换成功
            return true;
        }

        // 如果不满足交换条件，则返回 false
        return false;
    }


    // 向其他城市添加将领
    private bool AddGeneralToOtherCity(City city, City otherCity)
    {
        short minBattlePowerGeneralId = city.getMinBattlePowerGeneralId();
        bool isMove = false;

        while (true)
        {
            short generalId = city.getMaxBattlePowerGeneralId();

            if (city.getCityGeneralNum() == 1 || generalId == minBattlePowerGeneralId || otherCity.getCityGeneralNum() >= 10)
            {
                return isMove;
            }

            // 移除将领
            city.removeOfficeGeneralId(generalId);

            // 输出移动信息
            UnityEngine.Debug.Log($"将{city.cityName}的{GeneralListCache.GetGeneral(generalId).generalName}移动至{otherCity.cityName}");

            // 添加将领到其他城市
            otherCity.AddOfficeGeneralId(generalId);

            isMove = true;
        }
    }





    public bool Boolean_R()
    {
        bool isMove = false;

        // 获取最需要战斗力的城市
        City maxNeedPowerCity = getMaxNeedPowerCity();

        // 如果没有找到这样一个城市
        if (maxNeedPowerCity == null)
        {
            // 获取敌方相邻城市的ID数组
            byte[] adjacentCityIdArray = GetEnemyAdjacentCityIdArray();
            if (adjacentCityIdArray.Length <= 0)
                return isMove;

            // 获取没有敌人相邻的城市ID数组
            byte[] noEnemyAdjacentCityIdArray = GetNoEnemyAdjacentCityIdArray();

            // 遍历所有没有敌人相邻的城市
            foreach (byte cityId in noEnemyAdjacentCityIdArray)
            {
                City city = CityListCache.GetCityByCityId(cityId);

                // 遍历所有敌方相邻城市
                foreach (byte otherCityId in adjacentCityIdArray)
                {
                    City otherCity = CityListCache.GetCityByCityId(otherCityId);

                    // 如果城市将领数量 <= 1 或者敌方相邻城市的将领数量 > 9
                    if (city.getCityGeneralNum() <= 1 || otherCity.getCityGeneralNum() > 9)
                    {
                        if (ChangeGeneral(city, otherCity))
                            isMove = true;
                    }
                    else
                    {
                        if (AddGeneralToOtherCity(city, otherCity))
                            isMove = true;
                    }
                }
            }
            return isMove;
        }

        // 获取没有敌人相邻的城市ID数组
        byte[] noAdjacentCity = GetNoEnemyAdjacentCityIdArray();

        if (noAdjacentCity.Length > 0)
        {
            // 遍历没有敌人相邻的城市
            foreach (byte cityId in noAdjacentCity)
            {
                City city = CityListCache.GetCityByCityId(cityId);

                // 如果城市将领数量 <= 1 或者 maxNeedPowerCity 的将领数量 > 9
                if (city.getCityGeneralNum() <= 1 || maxNeedPowerCity.getCityGeneralNum() > 9)
                {
                    if (ChangeGeneral(city, maxNeedPowerCity))
                        isMove = true;
                }
                else
                {
                    if (AddGeneralToOtherCity(city, maxNeedPowerCity))
                        isMove = true;
                }
            }
        }
        else
        {
            // 处理敌人相邻的城市
            byte[] adjacentCityIdArray = GetEnemyAdjacentCityIdArray();
            foreach (byte adjacentCityId in adjacentCityIdArray)
            {
                if (adjacentCityId != maxNeedPowerCity.cityId)
                {
                    City adjacentCity = CityListCache.GetCityByCityId(adjacentCityId);
                    byte generalNum = adjacentCity.getCityGeneralNum();
                    int defenseAbility = adjacentCity.GetDefenseAbility();
                    short minBattlePowerGeneralId = adjacentCity.getMinBattlePowerGeneralId();
                    General minBattlePowerGeneral = GeneralListCache.GetGeneral(minBattlePowerGeneralId);
                    double battlePower = minBattlePowerGeneral.GetBattlePower();
                    int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(adjacentCityId);

                    // 如果城市将领数量 > 1 且 maxNeedPowerCity 的将领数量 < 9
                    if (generalNum > 1 && maxNeedPowerCity.getCityGeneralNum() < 9)
                    {
                        if (defenseAbility - battlePower >= enemyAdjacentAtkPower)
                        {
                            maxNeedPowerCity.AddOfficeGeneralId(minBattlePowerGeneralId);
                            maxNeedPowerCity.AppointmentPrefect();
                            adjacentCity.removeOfficeGeneralId(minBattlePowerGeneralId);
                            adjacentCity.AppointmentPrefect();
                            isMove = true;
                            UnityEngine.Debug.Log($"{adjacentCity.cityName} 的战力过大, 将武将: {minBattlePowerGeneral.generalName} 移动至 {maxNeedPowerCity.cityName}");
                        }
                    }
                    else
                    {
                        short needMinBattlePowerGeneralId = maxNeedPowerCity.getMinBattlePowerGeneralId();
                        General needMinBattlePowerGeneral = GeneralListCache.GetGeneral(needMinBattlePowerGeneralId);
                        double needBattlePower = needMinBattlePowerGeneral.GetBattlePower();

                        if (needBattlePower < battlePower && defenseAbility - battlePower + needBattlePower >= enemyAdjacentAtkPower)
                        {
                            ChangeGeneral(maxNeedPowerCity.cityId, needMinBattlePowerGeneralId, adjacentCityId, minBattlePowerGeneralId);
                            UnityEngine.Debug.Log($"{maxNeedPowerCity.cityName} 的 {needMinBattlePowerGeneral.generalName} 与 {adjacentCity.cityName} 的 {minBattlePowerGeneral.generalName} 交换。");
                            isMove = true;
                        }
                    }
                }
            }
        }

        return isMove;
    }







    // 获取最需要战斗力的城市
    public City getMaxNeedPowerCity()
    {
        // 获取敌对邻近城市ID数组
        byte[] enemyAdjacentCityIds = GetEnemyAdjacentCityIdArray();
        int maxNeedPower = 0;
        City moveCity = null;

        foreach (byte adjacentCityId in enemyAdjacentCityIds)
        {
            City adjacentCity = CityListCache.GetCityByCityId(adjacentCityId);
            if (adjacentCity.getCityGeneralNum() <= 9)
            {
                int defenseAbility = adjacentCity.GetDefenseAbility();
                int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(adjacentCityId);
                int needPower = enemyAdjacentAtkPower - defenseAbility;
                if (needPower > maxNeedPower)
                {
                    maxNeedPower = needPower;
                    moveCity = adjacentCity;
                }
            }
        }

        return moveCity;
    }

    // 判断城市是否为敌对城市
    public bool CityIsEnemy(byte cityId)
    {
        City city = CityListCache.GetCityByCityId(cityId);
        short[] connectCityIds = city.connectCityId;

        foreach (byte connectCityId in connectCityIds)
        {
            City connectCity = CityListCache.GetCityByCityId(connectCityId);
            if (connectCity.cityBelongKing != city.cityBelongKing)
            {
                return true;
            }
        }

        return false;
    }


    /*     */

    // 检查城市是否邻近敌方城市
    public bool CityIsNearEnemy(byte cityId)
    {
        // 获取城市对象
        City city = CityListCache.GetCityByCityId(cityId);
        // 初始化是否有敌方城市标志
        bool haveEnemyCity = false;

        foreach (byte connectCityId in city.connectCityId)
        {
            // 获取邻接城市的君主ID
            short belongKing = CityListCache.GetCityByCityId(connectCityId).cityBelongKing;
            // 如果邻接城市的君主ID与当前势力不同
            if (belongKing != this.countryKingId)
            {
                // 获取邻接城市的所属势力
                Country otherCountry = CountryListCache.GetCountryByKingId(belongKing);
                // 如果邻接城市的所属势力存在且不是同盟国
                if (otherCountry != null && otherCountry.getAllianceById(otherCountry.countryId) == null)
                {
                    // 设置有敌方城市标志并退出循环
                    haveEnemyCity = true;
                    break;
                }
            }
        }

        return haveEnemyCity;
    }

    // 调整武将所在城市
    public void ChangeGeneral(byte cityId1, short generalId1, byte cityId2, short generalId2)
    {
        // 获取城市对象
        City city1 = CityListCache.GetCityByCityId(cityId1);
        City city2 = CityListCache.GetCityByCityId(cityId2);

        // 如果城市1的武将数量小于2
        if (city1.getCityGeneralNum() < 2)
        {
            // 将generalId2添加到城市1
            city1.AddOfficeGeneralId(generalId2);
            // 从城市1移除generalId1
            city1.removeOfficeGeneralId(generalId1);

            // 如果城市2的武将数量小于10
            if (city2.getCityGeneralNum() < 10)
            {
                // 将generalId1添加到城市2
                city2.AddOfficeGeneralId(generalId1);
                // 从城市2移除generalId2
                city2.removeOfficeGeneralId(generalId2);
            }
            else
            {
                // 从城市2移除generalId2
                city2.removeOfficeGeneralId(generalId2);
                // 将generalId1添加到城市2
                city2.AddOfficeGeneralId(generalId1);
            }
        }
        else
        {
            // 从城市1移除generalId1
            city1.removeOfficeGeneralId(generalId1);
            // 将generalId2添加到城市1
            city1.AddOfficeGeneralId(generalId2);

            // 如果城市2的武将数量小于10
            if (city2.getCityGeneralNum() < 10)
            {
                // 将generalId1添加到城市2
                city2.AddOfficeGeneralId(generalId1);
                // 从城市2移除generalId2
                city2.removeOfficeGeneralId(generalId2);
            }
            else
            {
                // 从城市2移除generalId2
                city2.removeOfficeGeneralId(generalId2);
                // 将generalId1添加到城市2
                city2.AddOfficeGeneralId(generalId1);
            }
        }

        // 任命城市1的太守
        city1.AppointmentPrefect();
        // 任命城市2的太守
        city2.AppointmentPrefect();
    }



    // 使武将撤退到城市
    public bool RetreatGeneralToCity(short[] generalIdArray, byte curCityId, int food, int money, bool chiefGeneralCaptured)
    {
        bool retreat = false;
        byte[] cityIdArray = GetCities();
        City curCity = CityListCache.GetCityByCityId(curCityId);

        if (cityIdArray.Length == 0 || (cityIdArray.Length == 1 && cityIdArray[0] == curCityId))
        {
            UnityEngine.Debug.Log($"{GeneralListCache.GetGeneral(this.countryKingId).generalName}势力已无城池可撤退！");
            for (int j = 0; j < generalIdArray.Length; j++)
            {
                short generalId = generalIdArray[j];
                General general = GeneralListCache.GetGeneral(generalId);
                if (general != null)
                {
                    if (generalId == this.countryKingId)
                    {
                        UnityEngine.Debug.Log($"君主：{general.generalName}无城池可撤退！死亡了");
                        GeneralListCache.GeneralDie(generalId);
                    }
                    else if (curCity.AddOppositionGeneralId(generalId))
                    {
                        UnityEngine.Debug.Log($"{general.generalName}无城池可撤退！在{curCity.cityName}下野！");
                    }
                }
            }

            return retreat;
        }

        int index = 0;
        for (int i = 0; i < generalIdArray.Length; i++)
        {
            short generalId = generalIdArray[i];
            General general = GeneralListCache.GetGeneral(generalId);
            if (general != null)
            {
                for (int j = 0; j < cityIdArray.Length; j++)
                {
                    byte cityId = (byte)cityIdArray[j];
                    if (cityId != curCityId)
                    {
                        City city = CityListCache.GetCityByCityId(cityId);
                        if (city.getCityGeneralNum() <= 9 || generalId == this.countryKingId)
                        {
                            city.AddOfficeGeneralId(generalId);
                            index++;
                            if (i == 0 && !chiefGeneralCaptured)
                            {
                                city.AddFood((short)food);
                                city.AddMoney((short)money);
                                retreat = true;
                                UnityEngine.Debug.Log($"主将：{general.generalName}撤退到{city.cityName}");
                                break;
                            }
                            UnityEngine.Debug.Log($"武将：{general.generalName}撤退到{city.cityName}");
                            break;
                        }
                    }
                }
            }
        }

        if (index < generalIdArray.Length - 1)
        {
            for (; index < generalIdArray.Length; index++)
            {
                short generalId = generalIdArray[index];
                General general = GeneralListCache.GetGeneral(generalId);
                if (general != null && curCity.AddOppositionGeneralId(generalId))
                {
                    UnityEngine.Debug.Log($"{general.generalName}无城池可撤退！在{curCity.cityName}下野！");
                }
            }
        }

        return chiefGeneralCaptured ? false : retreat;
    }

    class IniClass// 存储IniClass对象的列表，表示势力内的城市列表

    {
        public byte cityId;  // 城市ID
        private Country country;  // 所属势力

        // 构造函数，初始化城市ID和所属势力
        public IniClass(Country country, byte cityId)
        {
            this.country = country;
            this.cityId = cityId;
        }
    }


}
