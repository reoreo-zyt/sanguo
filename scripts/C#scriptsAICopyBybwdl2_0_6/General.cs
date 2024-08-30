using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.Text;


public class General  // 武将类
{
    [SerializeField] public short generalId;         // 武将ID
    [SerializeField] public string headImage;        // 头像图片路径
    [SerializeField] public string generalName;      // 武将姓名
    [SerializeField] public byte lead;               // 领导力
    [SerializeField] public byte political;          // 政治能力
    [SerializeField] public short phase;             // 当前阶段
    [SerializeField] public byte isOffice;           // 是否在职
    [SerializeField] public byte level;              // 等级
    [JsonProperty("army[]")][SerializeField] public byte[] army = new byte[3];  // 军队构成
    [SerializeField] public byte force;              // 武力值
    [SerializeField] public short generalSoldier;    // 所属士兵数量                               
    [SerializeField] public int maxSoldiers; // 最大士兵数
    [SerializeField] public int maxAttributeValue = 120; // 最大属性值
    [SerializeField] public byte moral;              // 德行
    [SerializeField] public byte curPhysical; // 当前体力
    [SerializeField] public byte maxPhysical = 100;  // 最大体力
    [SerializeField] public byte IQ;                 // 智商
    [SerializeField] public short debutYears;        // 出道年份
    public byte loyalty=99;           // 忠诚度
    [SerializeField] public byte debutCity;          // 出道城市
    [SerializeField] public short followGeneralId;   // 跟随的武将ID
    [SerializeField] public int experience;        // 经验值
    [SerializeField] public byte weapon;             // 武器
    [SerializeField] public byte armor;              // 铠甲
    [JsonProperty("skills[]")] public short[] skills = new short[5]; // 技能列表
    public byte leadExp;            // 领导力经验值
    public byte forceExp;           // 武力经验值
    public byte IQExp;              // 智商经验值
    public byte moralExp;           // 德行经验值
    public byte politicalExp;       // 政治能力经验值
    private byte salary = 1;        // 工资
    public short haveMoney = 0;     // 拥有的金钱
    public bool IsDie = false;      // 是否死亡
    public string profile = "";     // 个人简介



    // 根据数组中的值生成特定格式的字符串
    public string GetArmyS()
    {
        // 定义每个数字对应的后缀字符
        char[] suffixes = { 'C', 'B', 'A', 'S' }; // 假设0-3分别对应'C', 'S', 'A', 'B'

        // 定义前缀字符串数组
        string[] prefixes = { "平", "山", "水" };

        // 使用StringBuilder来构建结果字符串
        StringBuilder result = new StringBuilder();

        // 确保数组长度不超过prefixes数组长度
        int Length = Mathf.Min(army.Length, prefixes.Length);

        // 遍历数组中的每个元素
        for (int i = 0; i < Length; i++)
        {
            // 检查数组值是否在suffixes数组的索引范围内
            if (army[i] < suffixes.Length)
            {
                // 添加前缀和对应的后缀字符
                result.Append(prefixes[i]);
                result.Append(suffixes[army[i]]);
            }
            else
            {
                // 如果数组值超出范围，可以添加错误处理，例如追加一个错误字符或者忽略
                result.Append("?");
            }
        }

        return result.ToString();
    }


    /// <summary>
    /// 获取当前体力值
    /// </summary>
    /// <returns>当前体力值</returns>
    public byte getCurPhysical()
    {
        return curPhysical;
    }

    /// <summary>
    /// 设置当前体力值
    /// </summary>
    /// <param name="curPhysical">新的体力值</param>
    public void setCurPhysical(byte curPhysical)
    {
        if (curPhysical > maxPhysical)
        {
            curPhysical = maxPhysical;
        }
        else if (curPhysical < 0)
        {
            curPhysical = 0;
        }

        this.curPhysical = curPhysical;
    }

    /// <summary>
    /// 增加体力值
    /// </summary>
    /// <param name="physical">增加的体力值</param>
    public void addCurPhysical(byte physical)
    {
        if (physical > maxPhysical - curPhysical)
        {
            physical = (byte)(maxPhysical - curPhysical);
        }

        curPhysical = (byte)(curPhysical + physical);
    }

    /// <summary>
    /// 减少体力值
    /// </summary>
    /// <param name="physical">减少的体力值</param>
    /// <returns>是否体力降为0</returns>
    public bool decreaseCurPhysical(byte physical)
    {
        if (physical < 0)
        {
            physical = (byte)-physical;
        }

        curPhysical = (byte)(curPhysical - physical);

        if (curPhysical <= 0)
        {
            curPhysical = 0;
            return true;
        }

        return false;
    }



    /// <summary>
    /// 获取调整后的薪水
    /// </summary>
    /// <returns>返回调整后的薪水</returns>
    public byte getSalary()
    {
        return (byte)(salary + level * 2);
    }

    /// <summary>
    /// 设置忠诚度，最大值为100
    /// </summary>
    /// <param name="tempLoyalty">新的忠诚度值</param>
    public void SetLoyalty(byte tempLoyalty)
    {
        if (tempLoyalty > 100)
        {
            tempLoyalty = 100;
        }
        loyalty = tempLoyalty;
    }

    /// <summary>
    /// 获取当前忠诚度
    /// </summary>
    /// <returns>返回当前忠诚度</returns>
    public byte getLoyalty()
    {
        return loyalty;
    }

    /// <summary>
    /// 减少忠诚度，最小值为0
    /// </summary>
    /// <param name="tempLoyalty">减少的忠诚度值</param>
    public void decreaseLoyalty(byte tempLoyalty)
    {
        if (loyalty - tempLoyalty < 0)
        {
            loyalty = 0;
        }
        else
        {
            loyalty = (byte)(loyalty - tempLoyalty);
        }
    }

    /// <summary>
    /// 增加忠诚度，最大值为100
    /// </summary>
    /// <param name="tempLoyalty">增加的忠诚度值</param>
    public void AddLoyalty(byte tempLoyalty)
    {
        if (tempLoyalty + loyalty >= 100)
        {
            // 假设 CountryListCache 和 GetCountryByKingId 在其他地方定义。
            Country country = CountryListCache.GetCountryByKingId(generalId);
            if (country == null)
            {
                loyalty = 99;
            }
            else
            {
                loyalty = 100;
            }
        }
        else
        {
            loyalty = (byte)(loyalty + tempLoyalty);
        }
    }

    /// <summary>
    /// 根据条件增加忠诚度
    /// </summary>
    /// <param name="useMoney">是否使用金钱</param>
    /// <returns>返回忠诚度的变化量</returns>
    public byte AddLoyalty(bool useMoney)
    {
        byte tempLoyalty = loyalty;
        if (loyalty < 30)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 11) + 20);
        }
        else if (loyalty < 50)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 11) + 10);
        }
        else if (loyalty < 70)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 11) + 5);
        }
        else if (loyalty < 80)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 8) + 3);
        }
        else if (loyalty < 85)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 7) + 1);
        }
        else if (loyalty < 90)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 5) + 1);
        }
        if (!useMoney)
        {
            loyalty = (byte)(loyalty + UnityEngine.Random.Range(0, 10));
        }
        if (loyalty > 99)
        {
            loyalty = 99;
        }
        return (byte)(loyalty - tempLoyalty);
    }



    /// <summary>
    /// 获取升级到下一级所需的最大经验值
    /// </summary>
    /// <returns>最大经验值</returns>
    public short getMaxExp()
    {
        switch (this.level)
        {
            case 1: return 6000;
            case 2: return 10000;
            case 3: return 14000;
            case 4: return 18000;
            case 5: return 22000;
            case 6: return 26000;
            case 7: return 30000;
            case 8: return short.MaxValue;
            default: return short.MaxValue;
        }
    }

    /// <summary>
    /// 向玩家添加经验值
    /// </summary>
    /// <param name="exp">要添加的经验值</param>
    public void addexperience(int exp)
    {
        while (exp > 0)
        {
            exp--;
            experience++;

            // 检查当前经验值是否大于或等于最大经验值
            if (experience >= getMaxExp())
            {
                // 升级后将经验值重置为零
                experience = 0;
                levelUp();
            }
        }
    }

    /// <summary>
    /// 处理升级过程
    /// </summary>
    private void levelUp()
    {
        level++;
        generalUpgrade();
    }



    /// <summary>
    /// 获取战斗能力
    /// </summary>
    /// <returns>返回计算后的战斗力</returns>
    public double GetBattlePower()
    {
        double power = 0.0D;

        // 获取武器对象
        Weapon weaponObj = WeaponListCache.getWeapon(this.weapon);
        if (weaponObj != null)
        {
            // 计算武器对战斗力的影响
            power += weaponObj.weaponProperties * 1.3D;
        }

        // 获取防具对象
        // 注意: 通常防具不会从武器列表中获取，这里假设是正确的逻辑
        Weapon armorObj = WeaponListCache.getWeapon(this.armor);
        if (armorObj != null)
        {
            // 计算防具对战斗力的影响
            power += armorObj.weaponProperties * 1.3D;
        }

        // 计算其他属性对战斗力的影响
        power += this.force * 1.3D + this.IQ * 1.2D + this.curPhysical * 1.1D + (this.generalSoldier / 5);

        return power;
    }

    /// <summary>
    /// 获取将领得分
    /// </summary>
    /// <returns>返回将领的各项属性总和</returns>
    public int getGeneralScore()
    {
        return this.lead + this.political + this.force + this.moral + this.IQ;
    }

    /// <summary>
    /// 获取将领等级
    /// </summary>
    /// <returns>返回将领的等级</returns>
    public byte getGeneralGrade()
    {
        int generalScore = getGeneralScore();
        if (generalScore <= 297)
        {
            return 1;
        }
        else if (generalScore >= 298 && generalScore <= 338)
        {
            return 2;
        }
        else if (generalScore >= 339 && generalScore <= 449)
        {
            return 3;
        }
        else if (generalScore >= 450)
        {
            return 4;
        }
        return 0;
    }

    public string getGeneralGradeS()
    {
        // 调用已有的getGeneralGrade方法获取等级数值
        byte grade = getGeneralGrade();

        // 根据等级数值返回相应的描述
        switch (grade)
        {
            case 1:
                return "愚钝";
            case 2:
                return "平庸";
            case 3:
                return "精英";
            case 4:
                return "奇才";
            default:
                // 如果等级不是预期值，返回"未知"
                return "未知";
        }
    }

    /// <summary>
    /// 将领升级
    /// </summary>
    public void generalUpgrade()
    {
        if (this.level >= 8)
        {
            // 如果等级已经达到最大值，则不进行升级
            return;
        }

        this.level = (byte)(this.level + 1); // 提升等级
        this.curPhysical = 100; // 回复体力

        byte grade = getGeneralGrade(); // 获取当前等级

        // 根据等级随机增加属性点
        int totalValue = UnityEngine.Random.Range(0, grade) + 1;
        for (int i = 0; i < totalValue; i++)
        {
            int index = UnityEngine.Random.Range(0, 5);
            addGeneralAttributeValue(index, 0); // 注意: 第二个参数为0，可能需要修改为实际增加的属性点数
        }
    }



    // 向武将添加属性值
    public void addGeneralAttributeValue(int attributeIndex, int iterationCount)
    {
        // 如果迭代次数达到5次，则退出递归
        if (iterationCount >= 5) return;

        switch (attributeIndex)
        {
            // 如果领导力小于最大值，则增加领导力
            case 0 when lead < maxAttributeValue:
                lead++;
                break;
            // 如果政治力小于最大值，则增加政治力
            case 1 when political < maxAttributeValue:
                political++;
                break;
            // 如果武力小于最大值，则增加武力
            case 2 when force < maxAttributeValue:
                force++;
                break;
            // 如果道德小于最大值，则增加道德
            case 3 when moral < maxAttributeValue:
                moral++;
                break;
            // 如果智力小于最大值，则增加智力
            case 4 when IQ < maxAttributeValue:
                IQ++;
                break;
            // 默认情况，设置属性索引为0
            default:
                attributeIndex = 0;
                break;
        }

        // 如果属性索引不是0，则递增属性索引并继续递归
        if (attributeIndex != 0)
        {
            attributeIndex++;
            iterationCount++;
            addGeneralAttributeValue(attributeIndex, iterationCount);
        }
    }


    // 获取武将的最大士兵数
    public short getMaxGeneralSoldier()
    {
        // 直接使用 haveKill 逻辑来检查特定技能
        // 检查第 5 个技能（索引为 4）是否被“杀死”或解锁
        bool GetSkill_4 = ((this.skills[4] >> 10 - 0) & 0x1) == 1;

        if (GetSkill_4)
        {
            // 如果特定技能被解锁，返回 3000
            return 3000;
        }
        else
        {
            // 如果特定技能未解锁，根据领导力和等级计算士兵数量
            return (short)(1000 + 12 * this.lead + 10 * this.level);
        }
    }


    /// <summary>
    ///设定总督值
    /// <summary>
    /// <returns>总督值</returns>
    public int getSatrapValue()
    {
        // 计算公式
        return (int)(this.lead * 1.42f + this.IQ * 0.25f + this.force * 0.33f + ((this.lead * 2 + this.force + this.IQ) * (this.level - 1)) * 0.04f);
    }

    /// <summary>
    /// 获取武将的战斗力
    /// </summary>
    /// <returns>战斗力</returns>
    public int getGeneralPower()
    {
        int power = 1;
        short satrapValue = (short)getSatrapValue();
        long adjustedValue = (1 + satrapValue * satrapValue * satrapValue / 100000);

        if (this.generalSoldier < 100)
        {
            adjustedValue = Math.Min(100L, adjustedValue);
            return 0;
        }

        if (adjustedValue < 20L)
        {
            adjustedValue = Math.Max((this.generalSoldier / 150), adjustedValue);
        }

        power += (int)(adjustedValue * (this.generalSoldier + 1));
        return power;
    }

    /// <summary>
    /// 增加领导经验
    /// </summary>
    /// <param name="exp">增加的经验值</param>
    public void addLeadExp(byte exp)
    {
        if (this.lead < 120)
        {
            for (int i = 0; i < exp; i++)
            {
                this.leadExp = (byte)(this.leadExp + 1);
                if (this.leadExp >= 100)
                {
                    this.leadExp = (byte)(this.leadExp - 100);
                    this.lead = (byte)(this.lead + 1);
                    if (this.lead == 120)
                    {
                        this.leadExp = 100;
                        return;
                    }
                }
            }
        }
    }



    /// <summary>
    /// 增加力量经验值。
    /// </summary>
    /// <param name="exp">经验值</param>
    public void addforceExp(byte exp)
    {
        // 如果力量值小于最大值
        if (force < 120)
        {
            for (int i = 0; i < exp; i++)
            {
                // 增加力量经验值
                forceExp = (byte)(forceExp + 1);
                // 如果力量经验值达到或超过100
                if (forceExp >= 100)
                {
                    // 重置力量经验值
                    forceExp = (byte)(forceExp - 100);
                    // 提升力量值
                    force = (byte)(force + 1);
                    // 如果力量值达到最大值
                    if (force == 120)
                    {
                        // 重置力量经验值到100
                        forceExp = 100;
                        // 结束循环
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 增加智力经验值。
    /// </summary>
    /// <param name="exp">经验值</param>
    public void addIQExp(byte exp)
    {
        // 如果智力值小于最大值
        if (IQ < 120)
        {
            for (int i = 0; i < exp; i++)
            {
                // 增加智力经验值
                IQExp = (byte)(IQExp + 1);
                // 如果智力经验值达到或超过100
                if (IQExp >= 100)
                {
                    // 重置智力经验值
                    IQExp = (byte)(IQExp - 100);
                    // 提升智力值
                    IQ = (byte)(IQ + 1);
                    // 如果智力值达到最大值
                    if (IQ == 120)
                    {
                        // 重置智力经验值到100
                        IQExp = 100;
                        // 结束循环
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 增加政治经验值。
    /// </summary>
    /// <param name="exp">经验值</param>
    public void addPoliticalExp(byte exp)
    {
        // 如果政治值小于最大值
        if (political < 120)
        {
            // 直接增加政治经验值
            politicalExp = (byte)(politicalExp + exp);
            // 如果政治经验值达到或超过100
            if (politicalExp >= 100)
            {
                // 重置政治经验值
                politicalExp = (byte)(politicalExp - 100);
                // 提升政治值
                political = (byte)(political + 1);
                // 如果政治值达到最大值
                if (political == 120)
                {
                    // 重置政治经验值到100
                    politicalExp = 100;
                }
            }
        }
    }

    /// <summary>
    /// 增加道德经验值。
    /// </summary>
    /// <param name="exp">经验值</param>
    public void addMoralExp(byte exp)
    {
        // 如果道德值小于最大值
        if (moral < 120)
        {
            // 直接增加道德经验值
            moralExp = (byte)(moralExp + exp);
            // 如果道德经验值达到或超过100
            if (moralExp >= 100)
            {
                // 重置道德经验值
                moralExp = (byte)(moralExp - 100);
                // 提升道德值
                moral = (byte)(moral + 1);
                // 如果道德值达到最大值
                if (moral == 120)
                {
                    // 重置道德经验值到100
                    moralExp = 100;
                }
            }
        }
    }



    /// <summary>
    /// 学习方法
    /// </summary>
    /// <param name="learnNum">初始学习次数</param>
    public void study(short learnNum)
    {
        // 如果智力低于120
        if (this.IQ < 120)
        {
            // 根据智力值除以10的结果进行不同的处理
            switch (this.IQ / 10)
            {
                // 智力在0-40之间
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    // 如果经验值足够学习
                    if (this.experience >= getLearnNeedExp())
                    {
                        startStudy();
                    }
                    // 增加学习次数
                    learnNum = (short)(learnNum + 1);
                    break;
                // 智力为50
                case 5:
                    // 如果经验值足够且等级大于等于2
                    if (this.experience >= getLearnNeedExp() && this.level >= 2)
                    {
                        startStudy();
                    }
                    // 增加学习次数
                    learnNum = (short)(learnNum + 1);
                    break;
                // 智力为60
                case 6:
                    // 如果经验值足够且等级大于等于3
                    if (this.experience >= getLearnNeedExp() && this.level >= 3)
                    {
                        startStudy();
                    }
                    // 增加学习次数
                    learnNum = (short)(learnNum + 1);
                    break;
                // 智力为70
                case 7:
                    // 如果经验值足够且等级大于等于4
                    if (this.experience >= getLearnNeedExp() && this.level >= 4)
                    {
                        startStudy();
                    }
                    // 增加学习次数
                    learnNum = (short)(learnNum + 1);
                    break;
                // 智力为80
                case 8:
                    // 如果经验值足够且等级大于等于7
                    if (this.experience >= getLearnNeedExp() && this.level >= 7)
                    {
                        startStudy();
                    }
                    break;
                // 智力为90到120之间
                case 9:
                case 10:
                case 11:
                case 12:
                    // 如果经验值足够且等级等于8
                    if (this.experience >= getLearnNeedExp() && this.level == 8)
                    {
                        startStudy();
                    }
                    // 增加学习次数
                    learnNum = (short)(learnNum + 1);
                    break;
            }
        }
    }

    /// <summary>
    /// 开始学习
    /// </summary>
    void startStudy()
    {
        // 减少所需的经验值
        this.experience = (short)(this.experience - getLearnNeedExp());
        // 提升智力
        this.IQ = (byte)(this.IQ + 5);
        // 输出学习结果
        Debug.Log("武将: " + this.generalName + " 学习后 IQ 增加 5.");
    }

    /// <summary>
    /// 获取学习所需的最小经验值
    /// </summary>
    /// <returns>所需经验值</returns>
    short getLearnNeedExp()
    {
        // 计算所需经验值
        return (short)(200 + this.IQ * 50);
    }


    /// <summary>
    /// 根据IQ和等级返回武将计划的数量
    /// </summary>
    /// <returns>返回计划数量</returns>
    public byte getGeneralPlanNum()
    {
        // 如果智商大于等于100且等级大于等于8，则返回16
        if (IQ >= 100 && level >= 8)
            return 16;

        // 如果智商大于等于95且等级大于等于7，则返回15
        if (IQ >= 95 && level >= 7)
            return 15;

        // 如果智商大于等于93且等级大于等于5，则返回14
        if (IQ >= 93 && level >= 5)
            return 14;

        // 如果智商大于等于90且等级大于等于4，则返回12
        if (IQ >= 90 && level >= 4)
            return 12;

        // 如果智商大于等于85，则返回10
        if (IQ >= 85)
            return 10;

        // 如果智商大于等于80，则返回8
        if (IQ >= 80)
            return 8;

        // 如果智商大于等于60，则返回6
        if (IQ >= 60)
            return 6;

        // 如果智商小于40，则返回2；否则返回4
        return (byte)((IQ < 40) ? 2 : 4);
    }

    public static string GetActiveSkills(General general)
    {
        if (general.skills == null || general.skills.Length != 5)
        {
            Debug.LogError("技能数组不能为空且必须包含 5 个元素。");
            return string.Empty;
        }

        // 特技的映射表，50 个技能
        string[] skillNames = new string[]
        {
            "沉着", "鬼谋", "百出", "军师", "火攻", "神算", "反计", "待伏", "袭粮", "内讧",
            "骑神", "骑将", "弓神", "弓将", "水将", "乱战", "连弩", "金刚", "不屈", "猛将",
            "单骑", "奇袭", "铁壁", "攻城", "守城", "神速", "攻心", "精兵", "军魂", "军神",
            "王佐", "仁政", "耕作", "商才", "名士", "风水", "义军", "内助", "仁义", "抢运",
            "统领", "掠夺", "恐吓", "一骑", "水练", "能吏", "练兵", "言教", "冷静", "束缚"
        };

        List<string> activeSkills = new List<string>();

        // 遍历 skills[] 数组
        for (int i = 0; i < general.skills.Length; i++)
        {
            short skillValue = general.skills[i];

            // 如果这一行的值为 0，跳过
            if (skillValue == 0)
            {
                Debug.Log($"技能[{i}]的值为0，跳过。");
                continue;
            }

            // 遍历每个 skillValue 的 10 位
            for (int bitPosition = 0; bitPosition < 11; bitPosition++)
            {
                // 检查 skillValue 的第 (10 - bitPosition) 位是否为 1
                if ((skillValue & (1 << (10 - bitPosition))) != 0)
                {
                    int skillIndex = i * 10 + bitPosition;

                    // 确保索引在技能表的范围内
                    if (skillIndex < skillNames.Length)
                    {
                        Debug.Log($"发现特技: {skillNames[skillIndex]} (技能[{i}]的第 {bitPosition + 1} 位)");
                        activeSkills.Add(skillNames[skillIndex]);
                    }
                    else
                    {
                        Debug.LogWarning($"技能索引超出范围: {skillIndex}");
                    }
                }
            }
        }

        // 返回拼接后的特技字符串，使用两个空格分隔
        return string.Join("  ", activeSkills);
    }
}
