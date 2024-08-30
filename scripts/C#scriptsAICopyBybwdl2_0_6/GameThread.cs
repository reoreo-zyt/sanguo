using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;


    public class GameThread // 假设这是一个新的类名
    {
        // 字段定义
        byte txxxx;
        int[] gfZL;
        int[] ffZL;
        int gfZZL;
        int ffZZL;
        short sd1;
        short sd2;
        bool wjct;
        bool ctsb;
        private short jsbl;
        byte fsjl;
        byte gdcs;
        bool bngd;
        bool bxct;
        bool dttb;
        byte[] maxrestrain;
        readonly byte a_byte_fld = 1;
        readonly byte b_byte_fld = 2;
        readonly byte c_byte_fld = 4;
        readonly byte d_byte_fld = 8;
        readonly byte e_byte_fld = 16;
        readonly byte f_byte_fld = 32;

        byte[] k_byte_array1d_fld;

        byte[] warWeaponShop;

        // 刀剑、刀具、长矛、护甲类型
        byte[,] swordKind = new byte[,] {
            { 0, 1, 2, 3 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
            { 0, 1, 2, 3 },
            { 0, 1, 2, 3 },
            { 0, 1, 2, 3 },
            { 1, 2, 3, 4 }
        };
        byte[,] knifeKind = new byte[,] {
            { 8, 9, 10, 11 },
            { 10, 11, 12, 13 },
            { 10, 11, 12, 13 },
            { 8, 9, 10, 11 },
            { 8, 9, 10, 15 },
            { 8, 9, 10, 11 },
            { 10, 11, 12, 13 }
        };
        byte[,] pikeKind = new byte[,] {
            { 16, 17, 18, 19 },
            { 17, 18, 19, 20 },
            { 17, 18, 19, 20 },
            { 16, 17, 18, 23 },
            { 17, 18, 19, 20 },
            { 17, 18, 19, 22 },
            { 18, 19, 20, 21 }
        };
        byte[,] armorKind = new byte[,] {
            { 24, 25, 26, 27 },
            { 26, 27, 28, 29 },
            { 26, 27, 28, 30 },
            { 24, 25, 26, 27 },
            { 25, 26, 27, 28 },
            { 24, 25, 26, 27 },
            { 26, 27, 28, 29 }
        };
        short[] r_short_array1d_fld;
        byte[] D_byte_array1d_fld;
        short[] s_short_array1d_fld;
        System.Random random;
        byte j_byte_fld;
        byte curTurnsCountryId;
        byte m_byte_fld;
        byte tarCity;
        byte curCity;
        byte p_byte_fld;
        short HMGeneralId;
        short AIGeneralId;
        short[] chooseGeneralIdArray;
        byte chooseGeneralNum;
        byte s_byte_fld;
        byte AIUseOrderNum;
        byte userOrderNum;
        bool a_boolean_fld;
        bool b_boolean_fld;
        bool c_boolean_fld;
        short tipsGeneralId;
        string a_java_lang_String_fld;
        bool d_boolean_fld;
        short[] canToDoGeneral_Array;
        byte canToDoGeneralNum;
        int eventId;
        int b_int_fld;
        byte[] noAllianceCountryIdArray;
        byte[] G_byte_array1d_fld;
        byte disasterThings;
        byte x_byte_fld;
        bool e_boolean_fld;
        short e_short_fld;
        short userKingId;
        short f_short_fld;
        short aiKingId;
        public static byte curWarCityId;
        byte B_byte_fld;
        short humanMoney_inWar;
        short humanGrain_inWar;
        short aiMoney_inWar;
        short aiGrain_inWar;
        short[] humanGeneralId_inWar;
        short[] aiGeneralId_inWar;
        byte humanGeneralNum_inWar;
        byte aiGeneralNum_inWar;
        byte E_byte_fld;
        byte F_byte_fld;
        byte[,] bigWar_coordinate= new byte[19, 32];
        byte cols;
        byte rows;
        bool AIAttackHM;
        byte[] humanUnitCellX;
        byte[] humanUnitCellY;
        byte[] aiUnitCellX;
        byte[] aiUnitCellY;
        byte[] humanUnitTrapped;
        byte[] aiUnitTrapped;
        byte I_byte_fld;
        byte J_byte_fld;
        byte K_byte_fld;
        byte L_byte_fld;
        byte day;
        bool g_boolean_fld;
        byte N_byte_fld;
        string b_java_lang_String_fld;
        bool h_boolean_fld;
        byte O_byte_fld;
        byte warTerrain;
        byte humanSmallSoldierNum;
        byte aiSmallSoldierNum;
        // 声明并初始化smallWarCoordinate二维数组，用于表示战场的坐标状态
        byte[][] smallWarCoordinate;

        byte T_byte_fld;
        byte U;
        byte V;
        byte W;
        byte X;
        byte Y;
        byte[][] i_byte_array2d_fld = new byte[][]
        {
        new byte[] { 2, 100 },
        new byte[] { 2, 3, 3, 99, 4, 1 },
        new byte[] { 5, 1 },
        new byte[] { 2, 3, 6, 3, 83, 3, 84, 85, 1 },
        new byte[] { 2, 8 },
        new byte[] { 9, 3, 91, 1 },
        new byte[] { 3, 10, 1 },
        new byte[] { 3, 3, 98, 1 },
        new byte[] { 3, 11, 1 },
        new byte[] { 3, 97 },
        new byte[] { 3, 12, 96, 1 },
        new byte[] { 3, 12, 95, 1 },
        new byte[] { 2, 16, 1 },
        new byte[] { 3, 13, 94, 1 },
        new byte[] { 3, 12, 93, 1 },
        new byte[] { 14, 1 },
        new byte[] { 3, 15, 1 },
        new byte[] { 3, 89 },
        new byte[] { 3, 88, 1 },
        new byte[] { 2, 3, 3, 92, 1 },
        new byte[] { 2, 3, 3, 90, 1 },
        new byte[] { 17, 87 },
        new byte[] { 17, 86 }
        };

        byte[][] smallSoldierCellX;
        byte[][] smallSoldierCellY;
        byte[][] smallSoldierKind;
        short[][] smallSoldierAtk;
        short[][] smallSoldierDef;
        byte[][] smallSoldierAction;
        byte[][] smallSoldierOrder;
        short[][] smallSoldierBlood;
        bool[][] a_boolean_array2d_fld;
        bool[][] smallSoldier_isSurvive;
        byte Z;
        byte aa;
        byte ab;
        byte ac;
        short[] x_short_array1d_fld = new short[4];
        short[] y_short_array1d_fld = new short[4];
        byte ad;
        byte[] P_byte_array1d_fld = new byte[4];

        byte ae;

        bool i_boolean_fld;
        bool j_boolean_fld;
        byte af;
        byte ag;
        byte ah;
        byte ai;
        byte aj;
        byte ak;
        byte al;
        byte am;
        bool k_boolean_fld;
        bool l_boolean_fld;
        short HMSingleAtk;
        short HMSingleDef;
        short AISingleAtk;
        short AISingleDef;
        bool m_boolean_fld;
        byte an;
        int c_int_fld;
        byte ao;
        byte ap;
        byte aq;
        int d_int_fld;
        bool n_boolean_fld;
        byte ar;
        int e_int_fld;
        byte a_s;
        byte at;
        byte[] Q_byte_array1d_fld;
        int f_int_fld;
        bool o_boolean_fld;
        byte au;
        byte av;
        int score;
        int unify;
        byte aw;
        int i_int_fld;
        int j_int_fld;
        byte[] R_byte_array1d_fld;
        byte[] S_byte_array1d_fld;
        byte[] T_byte_array1d_fld;
        string c_java_lang_String_fld;
        string d_java_lang_String_fld;
        string e_java_lang_String_fld;
        byte[] countryOrder;
        short[] countryPhase;

        // 位置坐标
        byte[][] CAS_sc;

        // 顶部信息
        float[] topInf;

        // 士兵攻击、防御
        short[,] soldierAtk;
        short[,] soldierDef;

        // 士兵种类坐标
        byte[][] coodinateSoldierKind;

        // AI 攻击状态
        bool aiAtkHm;

        // 战斗索引
        byte hmbattleIndex;
        byte aibettleIndex;

        // AI 将领相关
        byte[] aiGeneralFinshMove;
        byte[] aiGeneralHaveMove;
        byte[] aiGeneralMoveBonus;

        bool lessMoveBouns;
        byte curAIindex;

        // 建筑物移动地图
        byte[,] buildingMoveMap;

        // 当前将领移动地图
        byte[,] curGeneralMoveMap;

        // 移动路径
        UnityEngine.Vector2 movePath;

        // 人类将领相关
        byte[] humanGeneralFinshMove;
        byte[] humanGeneralMoveBonus;

        bool DJ;
        bool AIJH;
        bool HMJH;

        // 伤害统计
        short HMTotalSoldierHurt;
        short AITotalSoldierHurt;
        short HMTotalGeneralHurt;
        short AITotalGeneralHurt;

        bool singleFigth;

        // 战斗初始属性
        byte HMfirstPhy;
        byte AIfirstPhy;

        // 模拟数据
        short moniSd1;
        short moniSd2;
        int fmoney;
        int ffood;
        byte warNum;
        int[] gfzdl;
        int[] ffzdl;

        // 模拟战争数据
        byte[][] moniwarT;

        // 公共字段
        public string re;
        public byte[] higSort;

        // 根据得分调整R_byte_array1d_fld数组中的元素值
        void void_ii_a(int i1, int j1)
        {
            if (i1 >= 700)
            {
                this.R_byte_array1d_fld[j1] = 6;
                this.score += 100;
            }
            else if (i1 >= 600)
            {
                this.R_byte_array1d_fld[j1] = 5;
                this.score += 80;
            }
            else if (i1 >= 500)
            {
                this.R_byte_array1d_fld[j1] = 4;
                this.score += 70;
            }
            else if (i1 >= 400)
            {
                this.R_byte_array1d_fld[j1] = 3;
                this.score += 60;
            }
            else if (i1 >= 300)
            {
                this.R_byte_array1d_fld[j1] = 2;
                this.score += 40;
            }
            else if (i1 >= 200)
            {
                this.R_byte_array1d_fld[j1] = 1;
                this.score += 20;
            }
            else
            {
                this.R_byte_array1d_fld[j1] = 0;
            }
            this.unify = 1 + i1 / 100;
        }


        // 计算农业平均值并调用评分方法
        void void_a()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).agro;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            void_ii_a(i1, 0);
        }

        // 计算贸易平均值并调用评分方法
        void void_b()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < 37; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).trade;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            void_ii_a(i1, 1);
        }

        // 计算防洪平均值并调用评分方法
        void void_c()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).floodControl;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            if (i1 >= 99)
            {
                this.R_byte_array1d_fld[2] = 4;
                this.score += 100;
            }
            else if (i1 >= 80)
            {
                this.R_byte_array1d_fld[2] = 3;
                this.score += 80;
            }
            else if (i1 >= 70)
            {
                this.R_byte_array1d_fld[2] = 2;
                this.score += 70;
            }
            else if (i1 >= 50)
            {
                this.R_byte_array1d_fld[2] = 1;
                this.score += 50;
            }
            else
            {
                this.R_byte_array1d_fld[2] = 0;
            }
            this.unify += 1 + i1 / 10;
        }

        // 计算人口平均值并调用评分方法
        void void_d()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).population;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            if (i1 >= 700000)
            {
                this.R_byte_array1d_fld[3] = 5;
                this.score += 100;
            }
            else if (i1 >= 600000)
            {
                this.R_byte_array1d_fld[3] = 4;
                this.score += 80;
            }
            else if (i1 >= 400000)
            {
                this.R_byte_array1d_fld[3] = 3;
                this.score += 70;
            }
            else if (i1 >= 200000)
            {
                this.R_byte_array1d_fld[3] = 2;
                this.score += 50;
            }
            else if (i1 >= 100000)
            {
                this.R_byte_array1d_fld[3] = 1;
                this.score += 40;
            }
            else
            {
                this.R_byte_array1d_fld[3] = 0;
            }
            this.unify += i1 / 100000 + 1;
        }

    



        // 计算统治力平均值并调用评分方法
        void void_e()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                i1 += (CityListCache.GetCityByCityId(byte0)).rule;
            }
            i1 /= CityListCache.CITY_NUM - 1;
            if (i1 >= 99)
            {
                this.R_byte_array1d_fld[5] = 5;
                this.score += 100;
            }
            else if (i1 >= 90)
            {
                this.R_byte_array1d_fld[5] = 4;
                this.score += 90;
            }
            else if (i1 >= 80)
            {
                this.R_byte_array1d_fld[5] = 3;
                this.score += 80;
            }
            else if (i1 >= 60)
            {
                this.R_byte_array1d_fld[5] = 2;
                this.score += 60;
            }
            else if (i1 >= 30)
            {
                this.R_byte_array1d_fld[5] = 1;
                this.score += 20;
            }
            else
            {
                this.R_byte_array1d_fld[5] = 0;
            }
            this.unify += i1 / 10 + 1;
        }

        // 计算士兵平均值并调用评分方法
        void void_f()
        {
            int i1 = 0;
            short wjsl = 1; byte byte0;
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    i1 += (GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).generalSoldier;
                }
            }

            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 1000)
            {
                this.R_byte_array1d_fld[6] = 5;
                this.score += 100;
            }
            else if (i1 >= 900)
            {
                this.R_byte_array1d_fld[6] = 4;
                this.score += 90;
            }
            else if (i1 >= 800)
            {
                this.R_byte_array1d_fld[6] = 3;
                this.score += 80;
            }
            else if (i1 >= 700)
            {
                this.R_byte_array1d_fld[6] = 2;
                this.score += 70;
            }
            else if (i1 >= 500)
            {
                this.R_byte_array1d_fld[6] = 1;
                this.score += 50;
            }
            else
            {
                this.R_byte_array1d_fld[6] = 0;
                this.score += 30;
            }
            if (i1 >= 1000)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += i1 / 100;
            }
        }

        // 计算忠诚度平均值并调用评分方法
        void void_g()
        {
            int i1 = -100;
            short wjsl = 1; byte byte0;
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    i1 += GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]).getLoyalty();
                }
            }
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 99)
            {
                this.R_byte_array1d_fld[4] = 6;
                this.score += 100;
            }
            else if (i1 >= 95)
            {
                this.R_byte_array1d_fld[4] = 5;
                this.score += 90;
            }
            else if (i1 >= 90)
            {
                this.R_byte_array1d_fld[4] = 4;
                this.score += 80;
            }
            else if (i1 >= 80)
            {
                this.R_byte_array1d_fld[4] = 3;
                this.score += 70;
            }
            else if (i1 >= 60)
            {
                this.R_byte_array1d_fld[4] = 2;
                this.score += 50;
            }
            else if (i1 >= 36)
            {
                this.R_byte_array1d_fld[4] = 1;
                this.score += 20;
            }
            else
            {
                this.R_byte_array1d_fld[4] = 0;
                this.score += 10;
            }
            this.unify += i1 / 10 + 1;
        }




         // 计算将军等级平均值并调用评分方法
        void void_h()
        {
            int i1 = 0;
            short wjsl = 1; byte byte0;
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    i1 += (GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).level;
                }
            }
            for (byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 8)
            {
                this.score += 100;
            }
            else if (i1 >= 7)
            {
                this.score += 90;
            }
            else if (i1 >= 6)
            {
                this.score += 80;
            }
            else if (i1 >= 5)
            {
                this.score += 70;
            }
            else if (i1 >= 4)
            {
                this.score += 60;
            }
            else if (i1 >= 3)
            {
                this.score += 30;
            }
            if (i1 == 8)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += i1;
            }
        }

        // 计算智力平均值并调用评分方法
        void void_i()
        {
            int i1 = 0;
            short wjsl = 1;
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1 = (byte)(byte1 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte1);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte2 = 0; byte2 < officeGeneralIdArray.Length; byte2 = (byte)(byte2 + 1))
                {
                    byte b = (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).IQ;
                    i1 += b;
                }
            }

            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                wjsl = (short)(wjsl + CityListCache.GetCityByCityId(byte0).getCityGeneralNum());
            }

            i1 /= wjsl;
            if (i1 >= 90)
            {
                this.score += 100;
            }
            else if (i1 == 80)
            {
                this.score += 80;
            }
            else if (i1 == 70)
            {
                this.score += 60;
            }
            else if (i1 >= 60)
            {
                this.score += 50;
            }
            else if (i1 >= 40)
            {
                this.score += 40;
            }
            if (wjsl >= 150)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += wjsl / 15;
            }
        }

        // 计算装备加成并调用评分方法
        void void_j()
        {
            int i1 = 0;
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                for (byte byte1 = 1; byte1 < officeGeneralIdArray.Length; byte1 = (byte)(byte1 + 1))
                {
                    switch ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).weapon)
                    {
                        case 15:
                        case 23:
                            i1 += 2;
                            break;

                        case 22:
                            i1++;
                            break;

                        case 5:
                        case 6:
                        case 7:
                            i1 += 3;
                            break;

                        case 14:
                            i1 += 2;
                            break;
                    }
                    switch ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte1])).armor)
                    {
                        case 30:
                            i1 += 2;
                            break;

                        case 31:
                            i1 += 4;
                            break;
                    }
                }
            }
            this.score += i1 * 50;

            if (i1 > 10)
            {
                this.unify += 10;
            }
            else
            {
                this.unify += i1;
            }
        }




        // 执行一系列方法调用，并检查排序是否可以设置
        void void_k()
        {
            if (this.txxxx != 1)
            {
                return;
            }
            void_a();
            void_b();
            void_c();
            void_d();
            void_e();
            void_f();
            void_g();
            void_h();
            void_i();
            void_j();

            byte[] abyte0 = new byte[7];
            for (int i = 0; i < this.R_byte_array1d_fld.Length; i++)
            {
                abyte0[i] = this.R_byte_array1d_fld[i];
            }
            bool canSet = true;
            for (int j = 0; j < abyte0.Length; j++)
            {
                if (abyte0[j] < this.higSort[j])
                {
                    canSet = false;
                }
            }
            if (canSet)
            {
                //setHighSort(abyte0);
            }
        }

        // 获取灾害警告信息
        string String_i_a(int i1)
        {
            return d.disaster_warning_information[i1][this.R_byte_array1d_fld[i1]];
        }

        // 根据给定的值计算对应的等级
        public byte Byte_s_a(short word0)
        {
            for (byte i = 15; i > 0; i = (byte)(i - 1))
            {
                if (i * i <= word0)
                    return i;
            }
            return 0;
        }



        // 咒缚成功判断
        bool IsSuccessOfCurse(short generalId, short beGeneralId)
        {
            General general = GeneralListCache.GetGeneral(generalId);
            int i1 = general.IQ - GeneralListCache.GetGeneral(beGeneralId).IQ;
            if (getSkill_5(generalId, 9))
            {
                i1 += 30;
            }

            if (i1 < 0)
                return false;
            byte retreatCityId = getCanRetreatCityId(this.aiKingId);
            if (retreatCityId > 0)
            {
                return (MathUtils.getRandomInt(100) <= i1);
            }
            return (MathUtils.getRandomInt(80) <= i1);
        }

        // 咒缚成功后的处理
        bool Boolean_a()
        {
            if (IsSuccessOfCurse(this.HMGeneralId, this.AIGeneralId))
            {
                this.aa = 20;
                if (this.HMGeneralId == 161)
                {
                    this.aa = 21;
                }
                return true;
            }
            return false;
        }

        // 一骑挑战成功判断
        bool IsSuccessOfCompetition()
        {
            bool flag = false;
            General general = GeneralListCache.GetGeneral(this.AIGeneralId);
            if (general.getCurPhysical() < 25)
            {
                return false;
            }

            if (getSkill_5(this.HMGeneralId, 3) &&
              general.force > 80)
            {
                return true;
            }

            int ai = (int)Math.Ceiling((getAtkDea(this.AIGeneralId, this.AISingleAtk, this.HMSingleDef) *
                getPercentage(this.AIGeneralId, this.HMGeneralId, false, false) / 100.0));
            int hm = (int)Math.Ceiling((getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) *
                getPercentage(this.HMGeneralId, this.AIGeneralId, false, false) / 100.0));
            int aival = ai * general.getCurPhysical();

            int hmval = hm * GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical();
            if (aival > hmval + 25 &&
              MathUtils.getRandomInt(aival - hmval) > 25)
            {
                flag = true;
            }

            return flag;
        }



        // 爆炎成功判断
        bool IsSuccessOfBoom()
        {
            short word0 = 0;
            for (byte byte0 = 1; byte0 < this.humanSmallSoldierNum; byte0 = (byte)(byte0 + 1))
            {
                word0 = (short)(word0 + this.smallSoldierBlood[0][byte0]);
            }
            return (word0 >= 1000);
        }

        // 对战计策需求智力
        bool Boolean_b_a(byte byte0)
        {
            this.V = (byte)(this.V - NeedTacticsBonus(byte0));
            switch (byte0)
            {
                case 0:
                    return Boolean_a();

                case 1:
                    return IsSuccessOfCompetition();

                case 2:
                    this.aa = 51;
                    return true;

                case 3:
                    this.aa = 68;
                    return true;

                case 4:
                    this.aa = 83;
                    return true;

                case 5:
                    return IsSuccessOfBoom();
            }
            return false;
        }

        // 对战计策需求计策点数
        byte NeedTacticsBonus(byte byte0)
        {
            switch (byte0)
            {
                case 0:
                    return 5;

                case 1:
                    return 2;

                case 2:
                    return 7;

                case 3:
                    return 8;

                case 4:
                    return 10;

                case 5:
                    return 12;
            }
            return 100;
        }



        // 标记士兵的位置状态
        // byte0: 表示X轴的坐标
        // byte1: 表示Y轴的坐标
        // flag: 表示是否为敌军（true: 敌军, false: 己方）
        void SmallWarSoldierStatus(byte byte0, byte byte1, bool flag)
        {
            if (flag)
            {
                // 如果是敌军，设置该位置的状态为 0x80 (10000000)，表示敌军占领
                this.smallWarCoordinate[byte1][byte0] = (byte)(this.smallWarCoordinate[byte1][byte0] | 0x80);
            }
            else
            {
                // 如果是己方，设置该位置的状态为 0x40 (01000000)，表示己方占领
                this.smallWarCoordinate[byte1][byte0] = (byte)(this.smallWarCoordinate[byte1][byte0] | 0x40);
            }
        }


        // 初始化士兵的阵型和位置
        void defCastleSoldierPos(bool isHm)
        {
            // 初始化阵型数据，7 行 16 列
            byte[,] formation = new byte[7, 16];

            if (isHm)
            {
                // 己方士兵阵型文件路径
                string s = "/formation/hc0.exp";

                // 读取阵型文件数据
                byte[] formationDat = formationArray(s);

                // 解析阵型数据
                formation = getFormationArray(formationDat, formation);

                // 遍历阵型行列，分配士兵位置
                for (byte celly = 0; celly < 7; celly++)
                {
                    for (byte cellx = 0; cellx < 16; cellx++)
                    {
                        // 如果当前单元格有士兵编号
                        if (formation[celly, cellx] < 0) // 修正条件判断
                        {
                            // 遍历己方所有士兵，匹配编号
                            for (byte index = 0; index < this.humanSmallSoldierNum; index++)
                            {
                                if (formation[celly, cellx] == index)
                                {
                                    // 设置士兵位置
                                    this.smallSoldierCellX[0][index] = cellx;
                                    this.smallSoldierCellY[0][index] = celly;

                                    // 更新士兵位置（传递参数：坐标x, 坐标y, 是否敌方）
                                    SmallWarSoldierStatus(this.smallSoldierCellX[0][index], this.smallSoldierCellY[0][index], false);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // 敌方士兵阵型文件路径
                byte fileIndex;
                string s = "/formation/ac";

                // 根据敌方将领等级选择不同阵型文件
                if ((GeneralListCache.GetGeneral(this.AIGeneralId)).level >= 7)
                {
                    fileIndex = 2;
                }
                else if ((GeneralListCache.GetGeneral(this.AIGeneralId)).level >= 4)
                {
                    fileIndex = 1;
                }
                else
                {
                    fileIndex = 0;
                }

                // 拼接完整的文件名
                s = s + fileIndex + ".exp";

                // 读取阵型文件数据
                byte[] formationDat = formationArray(s);

                // 解析阵型数据
                formation = getFormationArray(formationDat, formation);

                // 遍历阵型行列，分配敌方士兵位置
                for (byte celly = 0; celly < 7; celly++)
                {
                    for (byte cellx = 0; cellx < 16; cellx++)
                    {
                        // 如果当前单元格有士兵编号
                        if (formation[celly, cellx] < 0) // 修正条件判断
                        {
                            // 遍历敌方所有士兵，匹配编号
                            for (byte index = 0; index < this.aiSmallSoldierNum; index++)
                            {
                                if (formation[celly, cellx] == index)
                                {
                                    // 设置敌方士兵位置
                                    this.smallSoldierCellX[1][index] = cellx;
                                    this.smallSoldierCellY[1][index] = celly;

                                    // 更新敌方士兵位置（传递参数：坐标x, 坐标y, 是否敌方）
                                    SmallWarSoldierStatus(this.smallSoldierCellX[1][index], this.smallSoldierCellY[1][index], true);
                                }
                            }
                        }
                    }
                }
            }
        }




        // 初始化士兵种类
        // 定义城堡中的士兵属性
        void defCastleSoldier(bool isHm)
        {
            if (isHm)
            {
                // 根据将军等级确定士兵数量 aNum
                byte aNum;
                if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 7)
                {
                    aNum = 10;
                }
                else if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 4)
                {
                    aNum = 8;
                }
                else
                {
                    aNum = 6;
                }

                // 循环设置每个士兵的种类，忽略索引 0，从 1 开始
                for (byte byte1 = 1; byte1 < this.humanSmallSoldierNum; byte1++)
                {
                    if (byte1 <= aNum)
                    {
                        // 将人类阵营的士兵种类设置为 2
                        this.smallSoldierKind[0][byte1] = 2;
                    }
                    else
                    {
                        // 超过 aNum 的士兵种类设置为 3
                        this.smallSoldierKind[0][byte1] = 3;
                    }
                }
            }
            else
            {
                // AI 阵营，和人类阵营逻辑类似，确定士兵数量 aNum
                byte aNum;
                if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 7)
                {
                    aNum = 10;
                }
                else if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 4)
                {
                    aNum = 8;
                }
                else
                {
                    aNum = 6;
                }

                // 循环设置 AI 阵营士兵的种类，忽略索引 0，从 1 开始
                for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2++)
                {
                    if (byte2 <= aNum)
                    {
                        // AI 阵营的士兵种类设置为 2
                        this.smallSoldierKind[1][byte2] = 2;
                    }
                    else
                    {
                        // 超过 aNum 的士兵种类设置为 3
                        this.smallSoldierKind[1][byte2] = 3;
                    }
                }
            }
        }

        // 士兵分配种类
        void changeAtkCastleSoldier(bool isHm)
        {
            if (isHm)
            {
                // 定义攻击士兵数量 gjsl
                byte gjsl;

                // 根据敌方将军等级和领导力决定士兵的种类分配
                if (GeneralListCache.GetGeneral(this.AIGeneralId).level == 8 && GeneralListCache.GetGeneral(this.AIGeneralId).lead >= 95)
                {
                    gjsl = 10;
                }
                else if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 6 && GeneralListCache.GetGeneral(this.AIGeneralId).lead >= 90)
                {
                    gjsl = 8;
                }
                else if (GeneralListCache.GetGeneral(this.AIGeneralId).level >= 4 && GeneralListCache.GetGeneral(this.AIGeneralId).lead >= 80)
                {
                    gjsl = 6;
                }
                else
                {
                    gjsl = 4;
                }

                // 分配 AI 小兵种类，忽略索引 0，从 1 开始
                for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2++)
                {
                    if (byte2 <= gjsl)
                    {
                        // 士兵种类设为 2
                        this.smallSoldierKind[1][byte2] = 2;
                    }
                    else
                    {
                        // 士兵种类设为 3
                        this.smallSoldierKind[1][byte2] = 3;
                    }
                }
            }
            else
            {
                // 定义己方士兵数量 gjsl
                byte gjsl;

                // 根据己方将军等级和领导力决定士兵的种类分配
                if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 7 && GeneralListCache.GetGeneral(this.HMGeneralId).lead >= 95)
                {
                    gjsl = 8;
                }
                else if (GeneralListCache.GetGeneral(this.HMGeneralId).level >= 4 && GeneralListCache.GetGeneral(this.HMGeneralId).lead >= 85)
                {
                    gjsl = 6;
                }
                else
                {
                    gjsl = 4;
                }

                // 分配人类小兵种类，忽略索引 0，从 1 开始
                for (byte byte1 = 1; byte1 < this.humanSmallSoldierNum; byte1++)
                {
                    if (byte1 <= gjsl)
                    {
                        // 士兵种类设为 2
                        this.smallSoldierKind[0][byte1] = 2;
                    }
                    else
                    {
                        // 士兵种类设为 3
                        this.smallSoldierKind[0][byte1] = 3;
                    }
                }
            }
        }



        // 大战场设定逻辑具体找jDI
        public GameThread()
        {
            // 初始化 CAS_sc 数组
            this.CAS_sc = new byte[][]
            {
            new byte[] { 6, 2, 2 },
            new byte[] { 4, 3, 3 },
            new byte[] { 2, 4, 4 },
            new byte[] { 0, 4, 6 },
            new byte[] { 4, 4, 2 },
            new byte[] { 2, 4, 4 },
            new byte[] { 0, 4, 6 },
            new byte[] { 0, 2, 8 },
            new byte[] { 0, 8, 2 },
            new byte[] { 0, 6, 4 },
            new byte[] { 0, 4, 6 },
            new byte[] { 0, 2, 8 }
            };




            // 初始化 topInf 数组
            this.topInf = new float[] { 1.1F, 1.0F, 0.9F, 0.8F };

            // 初始化 soldierAtk 和 soldierDef 数组
            this.soldierAtk = new short[2,4];
            this.soldierDef = new short[2,4];

            // 初始化 aiAtkHm
            this.aiAtkHm = false;

            // 初始化 buildingMoveMap
            this.buildingMoveMap = new byte[19, 32];

            // 初始化 moniSd1 和 moniSd2
            this.moniSd1 = 0;
            this.moniSd2 = 0;


            // 在C#中，不允许存在空数组（{}），需要使用占位符代替
            this.moniwarT = new byte[][]
            {
                new byte[] { 0, 0 },
                new byte[] { 6, 9 },
                new byte[] { 7, 9 },
                new byte[] { 6, 9 },
                new byte[] { 5, 9 },
                new byte[] { 5, 8 },
                new byte[] { 6, 8 },
                new byte[] { 5, 8 },
                new byte[] { 5, 8 },
                new byte[] { 5, 9 },
                new byte[] { 5, 8 },
                new byte[] { 4, 8 },
                new byte[] { 5, 9 },
                new byte[] { 5, 8 },
                new byte[] { 5, 9 },
                new byte[] { 4, 8 },
                new byte[] { 5, 10 },
                new byte[] { 5, 7 },
                new byte[] { 5, 9 },
                new byte[] { 4, 9 },
                new byte[] { 5, 9 },
                new byte[] { 4, 9 },
                new byte[] { 4, 10 },
                new byte[] { 3, 9 },
                new byte[] { 5, 8 },
                new byte[] { 4, 9 },
                new byte[] { 4, 5 },
                new byte[] { 5, 6 },
                new byte[] { 4, 8 },
                new byte[] { 4, 7 },
                new byte[] { 3, 8 },
                new byte[] { 5, 9 },
                new byte[] { 5, 9 },
                new byte[] { 4, 5 },
                new byte[] { 4, 5 },
                new byte[] { 4, 7 },
                new byte[] { 4, 6 },
                new byte[] { 4, 8 },
                new byte[] { 3, 9 },
                new byte[] { 3, 10 },
                new byte[] { 3, 9 },
                new byte[] { 3, 9 },
                new byte[] { 4, 9 },
                new byte[] { 3, 9 },
                new byte[] { 3, 9 },
                new byte[] { 3, 10 },
                new byte[] { 4, 9 },
                new byte[] { 4, 6 },
                new byte[] { 3, 4 }
            };




            // 初始化 re 字符串
            this.re = "record";

            // 初始化其他数组和变量
            this.higSort = new byte[7];
            this.countryOrder = new byte[10];
            this.countryPhase = new short[9];
            this.k_byte_array1d_fld = new byte[CityListCache.CITY_NUM];
            this.warWeaponShop = new byte[CityListCache.CITY_NUM];
            this.r_short_array1d_fld = new short[3];
            this.D_byte_array1d_fld = new byte[3];
            this.s_short_array1d_fld = new short[3];
            this.random = new System.Random();
            this.j_byte_fld = 0;
            this.chooseGeneralIdArray = new short[10];
            this.s_byte_fld = 0;
            this.AIUseOrderNum = 0;
            this.a_boolean_fld = true;
            this.b_boolean_fld = true;
            this.c_boolean_fld = true;
            this.d_boolean_fld = true;
            this.canToDoGeneral_Array = new short[10];
            this.canToDoGeneralNum = 0;
            this.noAllianceCountryIdArray = new byte[8];
            this.G_byte_array1d_fld = new byte[CityListCache.CITY_NUM];
            this.e_boolean_fld = true;
            this.humanGeneralId_inWar = new short[10];
            this.aiGeneralId_inWar = new short[10];
            this.cols = 32;
            this.rows = 19;
            this.bigWar_coordinate = new byte[this.rows, this.cols];
            this.humanUnitCellX = new byte[10];
            this.humanUnitCellY = new byte[10];
            this.aiUnitCellX = new byte[10];
            this.aiUnitCellY = new byte[10];
            this.humanUnitTrapped = new byte[10];
            this.aiUnitTrapped = new byte[10];
            this.T_byte_fld = 16;
            this.U = 7;
            this.aa = 0;
            this.ab = 0;
            this.ae = 0;
            this.o_boolean_fld = false;
            this.au = 0;
            this.R_byte_array1d_fld = new byte[7];
            this.S_byte_array1d_fld = new byte[10240];
            this.txxxx = 1;

            // 调用读取最大保留值的方法
            //readMaxRestain();
        }

        // 用户回合结束处理
        public void UserEndTurn()
        {
            this.userOrderNum = 0;
            this.X = 0;
            this.j_byte_fld = 3;
            RefreshFeedBack((byte)4);
        }



        // 根据不同的战场地形和将军类型来设置战斗中的阵型（Combat Array Setup，CAS）
        public void SetCAS(bool isHM)
        {
            short genId;
            float tef = 1.0F;
    
            if (isHM)
            {
                genId = this.HMGeneralId;
            }
            else
            {
                genId = this.AIGeneralId;
            }

            byte[] sc = new byte[3];

            if (this.warTerrain >= 1 && this.warTerrain <= 7)
            {
                switch (GeneralListCache.GetGeneral(genId).army[0])
                {
                    case 0:
                        sc = this.CAS_sc[3];
                        tef = this.topInf[3];
                        break;
                    case 1:
                        sc = this.CAS_sc[2];
                        tef = this.topInf[2];
                        break;
                    case 2:
                        sc = this.CAS_sc[1];
                        tef = this.topInf[1];
                        break;
                    case 3:
                        sc = this.CAS_sc[0];
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain >= 11 && this.warTerrain <= 12)
            {
                switch (GeneralListCache.GetGeneral(genId).army[1])
                {
                    case 0:
                        sc = this.CAS_sc[7];
                        tef = this.topInf[3];
                        break;
                    case 1:
                        sc = this.CAS_sc[6];
                        tef = this.topInf[2];
                        break;
                    case 2:
                        sc = this.CAS_sc[5];
                        tef = this.topInf[1];
                        break;
                    case 3:
                        sc = this.CAS_sc[4];
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain == 9)
            {
                switch (GeneralListCache.GetGeneral(genId).army[2])
                {
                    case 0:
                        sc = this.CAS_sc[11];
                        tef = this.topInf[3];
                        break;
                    case 1:
                        sc = this.CAS_sc[10];
                        tef = this.topInf[2];
                        break;
                    case 2:
                        sc = this.CAS_sc[9];
                        tef = this.topInf[1];
                        break;
                    case 3:
                        sc = this.CAS_sc[8];
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain == 8)
            {
                sc[0] = 0;
                if (!this.i_boolean_fld)
                {
                    if (isHM)
                    {
                        if (GeneralListCache.GetGeneral(genId).level >= 7)
                        {
                            sc[1] = 10;
                            sc[2] = 0;
                        }
                        else if (GeneralListCache.GetGeneral(genId).level >= 4)
                        {
                            sc[1] = 8;
                            sc[2] = 2;
                        }
                        else
                        {
                            sc[1] = 6;
                            sc[2] = 4;
                        }
                    }
                    else if (GeneralListCache.GetGeneral(genId).level >= 7)
                    {
                        sc[1] = 8;
                        sc[2] = 2;
                    }
                    else if (GeneralListCache.GetGeneral(genId).level >= 4)
                    {
                        sc[1] = 6;
                        sc[2] = 4;
                    }
                    else
                    {
                        sc[1] = 4;
                        sc[2] = 6;
                    }
                }
                else if (isHM)
                {
                    if (GeneralListCache.GetGeneral(genId).level >= 7)
                    {
                        sc[1] = 8;
                        sc[2] = 2;
                    }
                    else if (GeneralListCache.GetGeneral(genId).level >= 4)
                    {
                        sc[1] = 6;
                        sc[2] = 4;
                    }
                    else
                    {
                        sc[1] = 4;
                        sc[2] = 6;
                    }
                }
                else if (GeneralListCache.GetGeneral(genId).level >= 7)
                {
                    sc[1] = 10;
                    sc[2] = 0;
                }
                else if (GeneralListCache.GetGeneral(genId).level >= 4)
                {
                    sc[1] = 8;
                    sc[2] = 2;
                }
                else
                {
                    sc[1] = 6;
                    sc[2] = 4;
                }
            }

            SetCAS(sc, isHM, tef);
        }


        // 设置游戏中士兵的行为和属性
        public void SetCAS(byte[] sc, bool isHm, float tef)
        {
            if (isHm)
            {
                int sNum = GeneralListCache.GetGeneral(this.HMGeneralId).generalSoldier;
                for (byte index = 1; index < this.humanSmallSoldierNum; index = (byte)(index + 1))
                {
                    this.smallSoldierAction[0][index] = 3;
                    if (index <= sc[0])
                    {
                        this.smallSoldierKind[0][index] = 1;
                    }
                    else if (index - sc[0] <= sc[1])
                    {
                        this.smallSoldierKind[0][index] = 2;
                    }
                    else
                    {
                        this.smallSoldierKind[0][index] = 3;
                    }
                    this.smallSoldierBlood[0][index] = (short)(sNum / (this.humanSmallSoldierNum - index));
                    sNum -= this.smallSoldierBlood[0][index];
                    SetSoldierAtkDef(true, index, tef);
                    this.smallSoldier_isSurvive[0][index] = true;
                }
            }
            else
            {
                int sNum = GeneralListCache.GetGeneral(this.AIGeneralId).generalSoldier;
                for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
                {
                    this.smallSoldierAction[1][index] = 2;
                    if (index <= sc[0])
                    {
                        this.smallSoldierKind[1][index] = 1;
                    }
                    else if (index - sc[0] <= sc[1])
                    {
                        this.smallSoldierKind[1][index] = 2;
                    }
                    else
                    {
                        this.smallSoldierKind[1][index] = 3;
                    }
                    this.smallSoldierBlood[1][index] = (short)(sNum / (this.aiSmallSoldierNum - index));
                    sNum -= this.smallSoldierBlood[1][index];
                    SetSoldierAtkDef(false, index, tef);
                    this.smallSoldier_isSurvive[1][index] = true;
                }
            }
        }

        // 初始化和设置游戏中的战斗单位，包括它们的属性、行为和阵型
        public void VoidBA(byte byte0)
        {
            this.dttb = false;
            this.sd1 = 0;
            this.sd2 = 0;
            this.wjct = false;
            this.ctsb = false;

            this.smallSoldierKind = new byte[2][];
            this.smallSoldierCellX = new byte[2][];
            this.smallSoldierCellY = new byte[2][];
            this.smallSoldierAction = new byte[2][];
            this.smallSoldierBlood = new short[2][];
            this.a_boolean_array2d_fld = new bool[2][];
            this.smallSoldier_isSurvive = new bool[2][];
            this.smallSoldierAtk = new short[2][];
            this.smallSoldierDef = new short[2][];
            this.smallSoldierOrder = new byte[2][];

            this.smallSoldierKind[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierCellX[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierCellY[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierAction[0] = new byte[this.humanSmallSoldierNum];
            this.smallSoldierBlood[0] = new short[this.humanSmallSoldierNum];
            this.a_boolean_array2d_fld[0] = new bool[this.humanSmallSoldierNum];
            this.smallSoldier_isSurvive[0] = new bool[this.humanSmallSoldierNum];
            this.smallSoldierAtk[0] = new short[this.humanSmallSoldierNum];
            this.smallSoldierDef[0] = new short[this.humanSmallSoldierNum];
            this.smallSoldierOrder[0] = new byte[this.humanSmallSoldierNum];

            this.smallSoldierKind[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierCellX[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierCellY[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierAction[1] = new byte[this.aiSmallSoldierNum];
            this.smallSoldierBlood[1] = new short[this.aiSmallSoldierNum];
            this.a_boolean_array2d_fld[1] = new bool[this.aiSmallSoldierNum];
            this.smallSoldier_isSurvive[1] = new bool[this.aiSmallSoldierNum];
            this.smallSoldierAtk[1] = new short[this.aiSmallSoldierNum];
            this.smallSoldierDef[1] = new short[this.aiSmallSoldierNum];
            this.smallSoldierOrder[1] = new byte[this.aiSmallSoldierNum];

            this.smallSoldierKind[0][0] = 0;
            this.smallSoldierAction[0][0] = 3;
            this.smallSoldierBlood[0][0] = 300;
            this.smallSoldierKind[1][0] = 0;
            this.smallSoldierAction[1][0] = 2;
            this.smallSoldierBlood[1][0] = 300;

            SetAD(true, (byte)0);
            SetCAS(true);
            SetAD(false, (byte)0);
            SetCAS(false);

            if (!this.i_boolean_fld && this.j_boolean_fld)
            {
                defCastleSoldierPos(true);
            }
            else if (this.i_boolean_fld || !this.j_boolean_fld)
            {
                hmSelectFormation(byte0);
            }

            if (this.i_boolean_fld && this.j_boolean_fld)
            {
                defCastleSoldierPos(false);
            }
            else if (!this.i_boolean_fld && this.j_boolean_fld)
            {
                aiSelectFormation(getAIFormation());
            }
            else
            {
                aiSelectFormation((byte)MathUtils.getRandomInt(4));
            }

            SetSingleAtkAndDef();
            InitCSK();
        }


        // 确定 AI 的阵型选择
        public byte getAIFormation()
        {
            byte index = 2;
            byte hMatcherNum = 0;
            for (int i = 1; i < this.humanSmallSoldierNum; i++)
            {
                if (this.smallSoldierKind[0][i] == 2)
                    hMatcherNum = (byte)(hMatcherNum + 1);
            }
            if (hMatcherNum >= 3)
                return 1;
            return index;
        }

        // 从资源文件中加载阵型数据
        public byte[] formationArray(string name)
        {
            byte[] abyte0 = null;
            try
            {
                using (Stream inputstream = GetType().Assembly.GetManifestResourceStream(name))
                {
                    if (inputstream != null)
                    {
                        abyte0 = new byte[inputstream.Length];
                        inputstream.Read(abyte0, 0, abyte0.Length);
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
            return abyte0;
        }

        // 将加载的阵型数据解析到一个二维数组中
        public byte[,] getFormationArray(byte[] dat, byte[,] formation)
        {
            byte star = 0;
            for (byte celly = 0; celly < 7; celly = (byte)(celly + 1))
            {
                for (int cellx = 0; cellx < 16; cellx++)
                {
                    formation[celly,cellx] = dat[star];
                    star = (byte)(star + 1);
                }
            }
            return formation;
        }

        // 用于人类玩家选择阵型
        public void hmSelectFormation(byte index)
        {
            // 初始化7行16列的阵型数组
            byte[,] hmFormation = new byte[7, 16];

            // 加载阵型文件
            string name = $"/formation/h{index}.exp";
            byte[] formationDat = formationArray(name);

            // 解析阵型文件到阵型数组
            hmFormation = getFormationArray(formationDat, hmFormation);

            // 遍历阵型，设置士兵位置
            for (byte celly = 0; celly < 7; celly++)
            {
                for (byte cellx = 0; cellx < 16; cellx++)
                {
                    // 判断是否有士兵
                    if (hmFormation[celly, cellx] < 0) // 修正条件判断
                    {
                        // 遍历所有士兵
                        for (byte i = 0; i < this.humanSmallSoldierNum; i++)
                        {
                            // 如果士兵编号匹配
                            if (i == hmFormation[celly, cellx])
                            {
                                // 设置士兵位置
                                this.smallSoldierCellX[0][i] = cellx;
                                this.smallSoldierCellY[0][i] = celly;

                                // 更新士兵位置，传递参数（坐标x, 坐标y, 是否敌方）
                                SmallWarSoldierStatus(this.smallSoldierCellX[0][i], this.smallSoldierCellY[0][i], false);
                            }
                        }
                    }
                }
            }
        }

        // 用于 AI 玩家选择阵型
        public void aiSelectFormation(byte index)
        {
            // 初始化7行16列的阵型数组
            byte[,] aiFormation = new byte[7, 16];

            // 加载阵型文件
            string name = $"/formation/a{index}.exp";
            byte[] formationDat = formationArray(name);

            // 解析阵型文件到阵型数组
            aiFormation = getFormationArray(formationDat, aiFormation);

            // 遍历阵型，设置士兵位置
            for (byte celly = 0; celly < 7; celly++)
            {
                for (byte cellx = 0; cellx < 16; cellx++)
                {
                    // 判断是否有士兵
                    if (aiFormation[celly, cellx] < 0) // 修正条件判断
                    {
                        // 遍历所有敌方士兵
                        for (byte i = 0; i < this.aiSmallSoldierNum; i++)
                        {
                            // 如果士兵编号匹配
                            if (i == aiFormation[celly, cellx])
                            {
                                // 设置敌方士兵位置
                                this.smallSoldierCellX[1][i] = cellx;
                                this.smallSoldierCellY[1][i] = celly;

                                // 更新敌方士兵位置，传递参数（坐标x, 坐标y, 是否敌方）
                                SmallWarSoldierStatus(this.smallSoldierCellX[1][i], this.smallSoldierCellY[1][i], true);
                            }
                        }
                    }
                }
            }
        }


        // 用于计算人类玩家和 AI 玩家单个单位的攻击力和防御力
        public void SetSingleAtkAndDef()
        {
            byte force = GeneralListCache.GetGeneral(this.HMGeneralId).force;
            this.HMSingleAtk = (short)(force + force * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.HMGeneralId).weapon)).weaponProperties / 100);
            this.HMSingleDef = (short)(force + force * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.HMGeneralId).armor)).weaponProperties / 100);
            byte aiforce = GeneralListCache.GetGeneral(this.AIGeneralId).force;
            this.AISingleAtk = (short)(aiforce + aiforce * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.AIGeneralId).weapon)).weaponProperties / 100);
            this.AISingleDef = (short)(aiforce + aiforce * (WeaponListCache.getWeapon(GeneralListCache.GetGeneral(this.AIGeneralId).armor)).weaponProperties / 100);
        }

        // 对人类玩家和 AI 玩家的将军和士兵的生命值进行更新和累加
        public void ReGenHPSoldierNum()
        {
            for (byte byte0 = 1; byte0 < 4; byte0 = (byte)(byte0 + 1))
            {
                this.x_short_array1d_fld[byte0] = 0;
                this.y_short_array1d_fld[byte0] = 0;
            }
            this.x_short_array1d_fld[0] = GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical();
            for (byte byte1 = 1; byte1 < this.humanSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.x_short_array1d_fld[this.smallSoldierKind[0][byte1]] = (short)(this.x_short_array1d_fld[this.smallSoldierKind[0][byte1]] + this.smallSoldierBlood[0][byte1]);
            this.y_short_array1d_fld[0] = GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical();
            for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                this.y_short_array1d_fld[this.smallSoldierKind[1][byte2]] = (short)(this.y_short_array1d_fld[this.smallSoldierKind[1][byte2]] + this.smallSoldierBlood[1][byte2]);
        }
        //根据游戏规则和技能调整计算攻击力(atk)和防御力(def)，并设置士兵的生存状态
        // 设置士兵的攻击力和防御力
        public void SetSoldierAtkDef(bool flag, byte byte0, float tef)
        {
            byte side;
            short id;

            if (flag)
            {
                side = 0;
                id = this.HMGeneralId;
            }
            else
            {
                side = 1;
                id = this.AIGeneralId;
            }

            short atk = (short)(((GeneralListCache.GetGeneral(id)).lead * 2 + (GeneralListCache.GetGeneral(id)).force) / 3 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).force) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);
            short def = (short)(((GeneralListCache.GetGeneral(id)).lead * 3 + (GeneralListCache.GetGeneral(id)).IQ) / 4 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).IQ) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);

            if (getSkill_3(id, 7))
            {
                atk = (short)(atk + atk / 4);
                def = (short)(def + def / 4);
            }
            else if (getSkill_3(id, 8))
            {
                atk = (short)(atk + atk / 5);
                def = (short)(def + def / 5);
            }
            else if (getSkill_3(id, 3))
            {
                if (this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (!this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if (getSkill_3(id, 4))
            {
                if (!this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if ((flag && this.HMJH) || (!flag && this.AIJH))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 1) && flag && !this.aiAtkHm)
            {
                if (!this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 1) && !flag && this.aiAtkHm && (this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 2) && flag && this.aiAtkHm)
            {
                if (this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 2) && !flag && !this.aiAtkHm && (!this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (!this.i_boolean_fld && this.j_boolean_fld && flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            if (!flag)
            {
                atk = (short)(atk * 4 / 3);
                def = (short)(def * 4 / 3);
            }
            atk = (short)(atk * tef);
            def = (short)(def * tef);
            this.a_boolean_array2d_fld[side][byte0] = false;
            this.smallSoldier_isSurvive[side][byte0] = true;
            if (this.smallSoldierKind[side][byte0] == 0)
            {
                this.smallSoldierAtk[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).weapon)).weaponProperties / 100);
                this.smallSoldierDef[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).armor)).weaponProperties / 100);
            }
            else if (this.smallSoldierKind[side][byte0] == 1)
            {
                this.smallSoldierAtk[side][byte0] = atk;
                this.smallSoldierDef[side][byte0] = def;
            }
            else if (this.smallSoldierKind[side][byte0] == 2)
            {
                this.smallSoldierAtk[side][byte0] = (short)(atk * 2 / 3);
                this.smallSoldierDef[side][byte0] = (short)(def * 4 / 5);
            }
            else if (this.smallSoldierKind[side][byte0] == 3)
            {
                this.smallSoldierAtk[side][byte0] = (short)(atk * 4 / 5);
                this.smallSoldierDef[side][byte0] = (short)(def * 6 / 5);
            }
            if (this.smallSoldierAtk[side][byte0] <= 0)
                this.smallSoldierAtk[side][byte0] = 1;
            if (this.smallSoldierDef[side][byte0] <= 0)
                this.smallSoldierDef[side][byte0] = 1;
        }

        // 简单设置攻击力和防御力
        public void SetAD(bool flag, byte byte0)
        {
            byte side;
            short id;

            if (flag)
            {
                side = 0;
                id = this.HMGeneralId;
            }
            else
            {
                side = 1;
                id = this.AIGeneralId;
            }

            this.a_boolean_array2d_fld[side][byte0] = false;
            this.smallSoldier_isSurvive[side][byte0] = true;
            if (this.smallSoldierKind[side][byte0] == 0)
            {
                this.smallSoldierAtk[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).weapon)).weaponProperties / 100);
                this.smallSoldierDef[side][byte0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).armor)).weaponProperties / 100);
                this.smallSoldierAtk[side][byte0] = (short)(this.smallSoldierAtk[side][byte0] + (short)(int)((this.smallSoldierAtk[side][byte0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));
                this.smallSoldierDef[side][byte0] = (short)(this.smallSoldierDef[side][byte0] + (short)(int)((this.smallSoldierDef[side][byte0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));
            }
            if (this.smallSoldierAtk[side][byte0] <= 0)
                this.smallSoldierAtk[side][byte0] = 1;
            if (this.smallSoldierDef[side][byte0] <= 0)
                this.smallSoldierDef[side][byte0] = 1;
        }

        // 设置所有士兵的攻击力和防御力
        public void SetAtk_Def1()
        {
            float tef = 1.0f;
            tef = GetTef(this.HMGeneralId);
            SetAtk_Def2(true, tef);
            tef = GetTef(this.AIGeneralId);
            SetAtk_Def2(false, tef);
        }

        // 设置单个士兵的攻击力和防御力
        public void SetAtk_Def2(bool flag, float tef)
        {
            byte side;
            short id;

            if (flag)
            {
                side = 0;
                id = this.HMGeneralId;
            }
            else
            {
                side = 1;
                id = this.AIGeneralId;
            }

            short atk = (short)(((GeneralListCache.GetGeneral(id)).lead * 2 + (GeneralListCache.GetGeneral(id)).force) / 3 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).force) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);
            short def = (short)(((GeneralListCache.GetGeneral(id)).lead * 3 + (GeneralListCache.GetGeneral(id)).IQ) / 4 + ((GeneralListCache.GetGeneral(id)).lead + (GeneralListCache.GetGeneral(id)).IQ) * ((GeneralListCache.GetGeneral(id)).level - 1) / 25);

            if (getSkill_3(id, 7))
            {
                atk = (short)(atk + atk / 4);
                def = (short)(def + def / 4);
            }
            else if (getSkill_3(id, 8))
            {
                atk = (short)(atk + atk / 5);
                def = (short)(def + def / 5);
            }
            else if (getSkill_3(id, 3))
            {
                if (this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (!this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if (getSkill_3(id, 4))
            {
                if (!this.i_boolean_fld && this.j_boolean_fld && flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
                else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
                {
                    atk = (short)(atk + atk / 5);
                    def = (short)(def + def / 5);
                }
            }
            else if ((flag && this.HMJH) || (!flag && this.AIJH))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 1) && flag && !this.aiAtkHm)
            {
                if (!this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 1) && !flag && this.aiAtkHm && (this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (getSkill_3(id, 2) && flag && this.aiAtkHm)
            {
                if (this.i_boolean_fld || !this.j_boolean_fld)
                {
                    atk = (short)(atk + atk / 7);
                    def = (short)(def + def / 7);
                }
            }
            else if (getSkill_3(id, 2) && !flag && !this.aiAtkHm && (!this.i_boolean_fld || !this.j_boolean_fld))
            {
                atk = (short)(atk + atk / 7);
                def = (short)(def + def / 7);
            }
            if (!this.i_boolean_fld && this.j_boolean_fld && flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            else if (this.i_boolean_fld && this.j_boolean_fld && !flag)
            {
                atk = (short)(atk * 3 / 2);
                def = (short)(def * 3 / 2);
            }
            if (!flag)
            {
                atk = (short)(atk * 4 / 3);
                def = (short)(def * 4 / 3);
            }
            atk = (short)(atk * tef);
            def = (short)(def * tef);

            // 设置第一种类型的士兵的攻击力和防御力
            this.soldierAtk[side,0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).weapon)).weaponProperties / 100);
            this.soldierDef[side,0] = (short)((GeneralListCache.GetGeneral(id)).force + (GeneralListCache.GetGeneral(id)).force * (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(id)).armor)).weaponProperties / 100);
            this.soldierAtk[side,0] = (short)(this.soldierAtk[side,0] + (short)(int)((this.soldierAtk[side,0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));
            this.soldierDef[side,0] = (short)(this.soldierDef[side,0] + (short)(int)((this.soldierDef[side,0] * ((GeneralListCache.GetGeneral(id)).level - 1)) * 0.05D));

            // 设置其他类型的士兵的攻击力和防御力
            this.soldierAtk[side,1] = atk;
            this.soldierDef[side,1] = def;
            this.soldierAtk[side,2] = (short)(atk * 2 / 3);
            this.soldierDef[side,2] = (short)(def * 4 / 5);
            this.soldierAtk[side,3] = (short)(atk * 4 / 5);
            this.soldierDef[side,3] = (short)(def * 6 / 5);
        }

        // 获取地形系数
        public float GetTef(short genId)
        {
            float tef = 1.0f;
            if (this.warTerrain >= 1 && this.warTerrain <= 7)
            {
                switch ((GeneralListCache.GetGeneral(genId)).army[0])
                {
                    case 0:
                        tef = this.topInf[3];
                        break;
                    case 1:
                        tef = this.topInf[2];
                        break;
                    case 2:
                        tef = this.topInf[1];
                        break;
                    case 3:
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain >= 10 && this.warTerrain <= 12)
            {
                switch ((GeneralListCache.GetGeneral(genId)).army[1])
                {
                    case 0:
                        tef = this.topInf[3];
                        break;
                    case 1:
                        tef = this.topInf[2];
                        break;
                    case 2:
                        tef = this.topInf[1];
                        break;
                    case 3:
                        tef = this.topInf[0];
                        break;
                }
            }
            else if (this.warTerrain == 9)
            {
                switch ((GeneralListCache.GetGeneral(genId)).army[2])
                {
                    case 0:
                        tef = this.topInf[3];
                        break;
                    case 1:
                        tef = this.topInf[2];
                        break;
                    case 2:
                        tef = this.topInf[1];
                        break;
                    case 3:
                        tef = this.topInf[0];
                        break;
                }
            }
            return tef;
        }

        // 设置 V 和 W 的值
        public void TotalTacticsBonus()
        {
            this.V = (byte)((GeneralListCache.GetGeneral(this.HMGeneralId)).IQ * 13 / 100);
            this.W = (byte)((GeneralListCache.GetGeneral(this.AIGeneralId)).IQ * 13 / 100);
        }

        // 计算单次攻击造成的伤害
        public void singleDea()
        {
            int ai = (int)Math.Ceiling((getAtkDea(this.AIGeneralId, this.AISingleAtk, this.HMSingleDef) * getPercentage(this.AIGeneralId, this.HMGeneralId, false, false) / 100.0));
            int hm = (int)Math.Ceiling((getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) * getPercentage(this.HMGeneralId, this.AIGeneralId, false, false) / 100.0));
        }

        // 向上移动士兵
        void UpMoveSoldier(byte byte0, byte byte1)
        {
            // 如果士兵位置已经在边界 (0, 0)，且在 Y 轴上没有移动的余地，直接返回
            if (byte0 == 0 && byte1 == 0 && this.smallSoldierCellY[0][0] <= 1)
                return;

            // 取当前坐标处数据的高 2 位 (0xC0 = 11000000)
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // 清除当前单元格的位置信息 (保留低位数据信息)
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // 向上移动士兵 (Y 坐标 - 1)
            this.smallSoldierCellY[byte0][byte1] = (byte)(this.smallSoldierCellY[byte0][byte1] - 1);

            // 设置士兵的行为为向上 (0 表示向上)
            this.smallSoldierAction[byte0][byte1] = 0;

            // 更新新单元格的数据，并将之前保存的高 2 位写回
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }

        // 向下移动士兵
        public void DownMoveSoldier(byte byte0, byte byte1)
        {
            // 如果士兵位置已经在边界 (0, 0)，且在 Y 轴上已经到达底部，直接返回
            if (byte0 == 0 && byte1 == 0 && this.smallSoldierCellY[0][0] >= 5)
                return;

            // 取当前坐标处数据的高 2 位
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // 清除当前单元格的位置信息
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // 向下移动士兵 (Y 坐标 + 1)
            this.smallSoldierCellY[byte0][byte1] = (byte)(this.smallSoldierCellY[byte0][byte1] + 1);

            // 设置士兵的行为为向下 (1 表示向下)
            this.smallSoldierAction[byte0][byte1] = 1;

            // 更新新单元格的数据，并将之前保存的高 2 位写回
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }

        // 向左移动士兵
        public void LeftMoveSoldier(byte byte0, byte byte1)
        {
            // 取当前坐标处数据的高 2 位
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // 清除当前单元格的位置信息
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // 向左移动士兵 (X 坐标 - 1)
            this.smallSoldierCellX[byte0][byte1] = (byte)(this.smallSoldierCellX[byte0][byte1] - 1);

            // 设置士兵的行为为向左 (2 表示向左)
            this.smallSoldierAction[byte0][byte1] = 2;

            // 更新新单元格的数据，并将之前保存的高 2 位写回
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }

        // 向右移动士兵
        public void RightMoveSoldier(byte byte0, byte byte1)
        {
            // 取当前坐标处数据的高 2 位
            byte byte2 = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0xC0);

            // 清除当前单元格的位置信息
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] & 0x32);

            // 向右移动士兵 (X 坐标 + 1)
            this.smallSoldierCellX[byte0][byte1] = (byte)(this.smallSoldierCellX[byte0][byte1] + 1);

            // 设置士兵的行为为向右 (3 表示向右)
            this.smallSoldierAction[byte0][byte1] = 3;

            // 更新新单元格的数据，并将之前保存的高 2 位写回
            this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] =
                (byte)(this.smallWarCoordinate[this.smallSoldierCellY[byte0][byte1]][this.smallSoldierCellX[byte0][byte1]] | byte2);
        }


        // 初始化士兵坐标数组
        void InitCSK()
        {
            // 初始化7行16列的二维数组
            this.coodinateSoldierKind = new byte[7][];
            for (int y = 0; y < 7; y++)
            {
                this.coodinateSoldierKind[y] = new byte[16];
                for (int x = 0; x < 16; x++)
                {
                    // 将所有坐标点初始化为 0，表示该位置没有士兵
                    this.coodinateSoldierKind[y][x] = 0;
                }
            }
        }

        // 设置士兵种类坐标数组
        void setCSK()
        {
            // 处理己方士兵
            for (int hmindex = 0; hmindex < this.humanSmallSoldierNum; hmindex++)
            {
                // 如果该士兵存活
                if (this.smallSoldier_isSurvive[0][hmindex])
                {
                    byte hx = this.smallSoldierCellX[0][hmindex]; // 获取X坐标
                    byte hy = this.smallSoldierCellY[0][hmindex]; // 获取Y坐标
                                                                   // 将该位置的士兵种类设置为当前士兵的种类
                    this.coodinateSoldierKind[hy][hx] = this.smallSoldierKind[0][hmindex];
                }
            }

            // 处理敌方士兵
            for (int aiIndex = 0; aiIndex < this.aiSmallSoldierNum; aiIndex++)
            {
                // 如果该士兵存活
                if (this.smallSoldier_isSurvive[1][aiIndex])
                {
                    byte aix = this.smallSoldierCellX[1][aiIndex]; // 获取X坐标
                    byte aiy = this.smallSoldierCellY[1][aiIndex]; // 获取Y坐标
                                                                    // 将该位置的士兵种类设置为当前士兵的种类
                    this.coodinateSoldierKind[aiy][aix] = this.smallSoldierKind[1][aiIndex];
                }
            }
        }
        /*
        // 设置游戏画布
        public void setGameCanvas(MyGameCanvas c1)
        {
            this.GameCanvas = c1;
            this.e_boolean_fld = true;
        }

        // 游戏循环逻辑
        private void VoidN()
        {
            long l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while (true)
            {
                if (this.GameCanvas.GetKeyValue() > 0)
                {
                    this.GameCanvas.VoidK();
                    if (!this.GameCanvas.C_Boolean_Fld)
                        this.GameCanvas.SetKeyValue((byte)0);
                }
                if (this.j_byte_fld <= 0)
                {
                    if (this.X != 111)
                        this.GameCanvas.SetKeyValue((byte)0);
                    long l2 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - l1;
                    if (l2 < 20L)
                    {
                        lock (this)
                        {
                            System.Threading.Thread.Sleep((int)(20L - l2));
                        }
                    }
                    this.GameCanvas.Repaint();
                    l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    continue;
                }
                break;
            }
        }

        // 调用 void_aq 方法
        private void VoidO()
        {
            void_aq();
            this.GameCanvas.SVoidBA((byte)1);
        }

        // 调用 s_void_b_a 方法
        private void VoidP()
        {
            this.GameCanvas.SVoidBA((byte)18);
        }

        // 根据 byte0 参数执行不同的操作
        private void VoidBB(byte byte0)
        {
            if (byte0 == 5)
            {
                this.GameCanvas.SVoidBA((byte)1);
            }
            else
            {
                this.eventId = byte0;
                ReadRecord();
                this.j_byte_fld = 2;
            }
        }
        */

        // 查找目标城市
        private void FindTarCity()
        {
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            short userKingId = country.countryKingId;
            byte[] cityIds = country.GetCities();
            for (int index = 0; index < cityIds.Length; index++)
            {
                byte cityId = country.GetCity((byte)index);
                City city = CityListCache.GetCityByCityId(cityId);
                if (city.prefectId == userKingId)
                {
                    this.tarCity = cityId;
                    this.p_byte_fld = this.tarCity;
                    break;
                }
            }
        }

        // 从资源文件读取字符串
        private string StringSa(string s1)
        {
            string s2 = null;
            try
            {
                using (System.IO.Stream inputstream = this.GetType().Assembly.GetManifestResourceStream(s1))
                {
                    if (inputstream == null)
                        return s2;

                    byte[] abyte0 = new byte[inputstream.Length];
                    inputstream.Read(abyte0, 0, (int)inputstream.Length);
                    s2 = System.Text.Encoding.UTF8.GetString(abyte0);
                }
            }
            catch (Exception exception) { }
            return s2;
        }

        // 设置大规模战争的坐标状态
        void SetBigWarStatus(short word0, byte byte0, string s1)
        {
            // 将传入的字符串转换为字节并存储到指定的坐标中
            this.bigWar_coordinate[word0,byte0] = byte.Parse(s1); // C# 的 byte.Parse 用于将字符串转换为 byte
        }

        // 解析字符串并设置 bigWar_coordinate 数组
        private void VoidSA(string s1)
        {
            int i1 = 0;
            int j1 = 0;
            byte byte0 = 0;
            byte byte1 = 0;
            try
            {
                while (j1 < s1.Length)
                {
                    if (s1[j1] == ',' || s1[j1] == '\n' || s1[j1] == '\r')
                    {
                        if (j1 != i1)
                        {
                            string s2 = s1.Substring(i1, j1 - i1);
                                SetBigWarStatus((short)byte1, byte0, s2);
                        }
                        i1 = j1 + 1;
                        if (s1[j1] == '\n')
                        {
                            byte1 = (byte)(byte1 + 1);
                            byte0 = 0;
                        }
                        else
                        {
                            byte0 = (byte)(byte0 + 1);
                        }
                    }
                    j1++;
                }
            }
            catch (Exception exception) { }
        }

        // 读取地图数据并解析
        private void VoidS()
        {
            string s1 = StringSa("/" + curWarCityId + ".map");
            VoidSA(s1);
        }

        // 读取地图文件
        private void ReadMap()
        {
            // 构建地图文件的路径，当前战争城市ID（curWarCityId）将用于确定具体的地图文件
            string name = "/map/" + curWarCityId + ".map";

            // 存储从文件读取的字节数据
            byte[] abyte0 = null;

            try
            {
                // 使用流来读取嵌入的资源文件（假定地图文件是作为嵌入资源放置在项目中）
                using (System.IO.Stream inputstream = this.GetType().Assembly.GetManifestResourceStream(name))
                {
                    // 如果文件不存在，则直接返回
                    if (inputstream == null)
                        return;

                    // 分配字节数组的大小，等于文件的长度
                    abyte0 = new byte[inputstream.Length];

                    // 将文件流读入到字节数组 abyte0 中
                    inputstream.Read(abyte0, 0, (int)inputstream.Length);
                }
            }
            catch (Exception e)
            {
                // 捕获异常，并打印异常信息（实际应用中可考虑使用日志记录）
                e.ToString();
            }

            // 从文件中读取的数据依次填充到 bigWar_coordinate 数组中
            int num = 0; // 指针，指向 byte 数组中的当前位置
            for (byte i = 0; i < 19; i = (byte)(i + 1))
            {
                for (byte j = 0; j < 32; j = (byte)(j + 1))
                {
                    // 将读取的字节值存储到 bigWar_coordinate 数组中，代表地图中某个位置的状态
                    this.bigWar_coordinate[i, j] = abyte0[num];
                    num++; // 递增指针，读取下一个字节
                }
            }
        }


        // 获取单元格单位类型
        private int getCellUnit(byte byte0)
        {
            int i1 = byte0 & 0xC0;
            if (i1 == 64)
                return 1;
            return (i1 != 128) ? 0 : 2;
        }

        // 对 AI 将领按领导力排序
        private void SortAiGeneralByLead()
        {
            for (byte byte0 = 1; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                for (byte byte1 = 1; byte1 < this.aiGeneralNum_inWar - 1; byte1 = (byte)(byte1 + 1))
                {
                    General general1 = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[byte1]);
                    General general2 = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[byte1 + 1]);

                    if (general1.lead > general2.lead)
                    {
                        short word0 = this.aiGeneralId_inWar[byte1];
                        this.aiGeneralId_inWar[byte1] = this.aiGeneralId_inWar[byte1 + 1];
                        this.aiGeneralId_inWar[byte1 + 1] = word0;
                    }
                }
            }
        }

        // 更新单位位置的函数
        void RefreshUnitPosition(byte byte0, int i1)
        {
            if (i1 == 1)
            { // 如果 i1 等于 1
                switch (byte0)
                {
                    case 1:
                        // 向右移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 2:
                        // 向上移动
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 3:
                        // 向下移动
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 4:
                        // 向左移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] - 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 5:
                        // 向右上移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 6:
                        // 向右下移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 7:
                        // 向右上移动两个单元格
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 8:
                        // 向右下移动三个单元格
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 3);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 9:
                        // 向右下移动两个单元格
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                }
            }
            else if (i1 == 2)
            { // 如果 i1 等于 2
                switch (byte0)
                {
                    case 1:
                        // 向右移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 2:
                        // 向下移动
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 3:
                        // 向上移动
                        this.aiUnitCellX[byte0] = this.aiUnitCellX[0];
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 4:
                        // 向左移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] - 1);
                        this.aiUnitCellY[byte0] = this.aiUnitCellY[0];
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 5:
                        // 向右下移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 6:
                        // 向左下移动
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] - 1);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 7:
                        // 向右下移动两个单元格
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 8:
                        // 向右下移动三个单元格
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 3);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] + 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                    case 9:
                        // 向右上移动两个单元格
                        this.aiUnitCellX[byte0] = (byte)(this.aiUnitCellX[0] + 2);
                        this.aiUnitCellY[byte0] = (byte)(this.aiUnitCellY[0] - 1);
                        this.bigWar_coordinate[this.aiUnitCellY[byte0], this.aiUnitCellX[byte0]] |= 0x80;
                        this.aiUnitTrapped[byte0] = 0;
                        break;
                }
            }
        }


        // 根据方向移动AI将领
        void void_bb_g(byte byte0, byte byte1)
        {
            if (byte0 == 1 && byte1 == 0)
            {
                for (byte byte2 = 1; byte2 < this.aiGeneralNum_inWar; byte2 = (byte)(byte2 + 1))
                    RefreshUnitPosition(byte2, 1); // 移动AI将领
            }
            else if (byte0 == 1 && byte1 == 1)
            {
                for (byte byte3 = 1; byte3 < this.aiGeneralNum_inWar; byte3 = (byte)(byte3 + 1))
                    RefreshUnitPosition(byte3, 2); // 移动AI将领
            }
            else if (byte0 == 0 && byte1 == 1)
            {
                for (byte byte4 = 1; byte4 < this.aiGeneralNum_inWar; byte4 = (byte)(byte4 + 1))
                    RefreshUnitPosition(byte4, 3); // 移动AI将领
            }
            else if (byte0 == 0 && byte1 == 0)
            {
                for (byte byte5 = 1; byte5 < this.aiGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
                    RefreshUnitPosition(byte5, 4); // 移动AI将领
            }
        }

        // 初始化AI将领位置
        void void_u()
        {
            int i1 = 0;
            int j1 = 0;
            for (byte byte4 = 0; byte4 < 32; byte4 = (byte)(byte4 + 1))
            {
                byte byte7 = 0;
                while (byte7 < 19)
                {
                    if (this.bigWar_coordinate[byte7, byte4] == 2)
                    {
                        i1 = byte4;
                        j1 = byte7;
                        if (byte4 > 15)
                        {
                            this.I_byte_fld = 0;
                        }
                        else
                        {
                            this.K_byte_fld = 0;
                        }
                        if (byte7 > 10)
                        {
                            this.J_byte_fld = 0;
                            break;
                        }
                        this.L_byte_fld = 0;
                        break;
                    }
                    byte7 = (byte)(byte7 + 1);
                }
            }
            this.aiUnitCellX[0] = (byte)i1;
            this.aiUnitCellY[0] = (byte)j1;
            this.aiUnitTrapped[0] = 0;
            this.bigWar_coordinate[j1, i1] = (byte)(this.bigWar_coordinate[j1, i1] | 0x80);
            SortAiGeneralByLead(); // 调用其他方法
            void_bb_g(this.I_byte_fld, this.J_byte_fld); // 根据方向移动AI将领
            for (byte byte6 = 0; byte6 < this.humanGeneralNum_inWar; byte6 = (byte)(byte6 + 1))
            {
                byte byte1, byte3;
                do
                {
                    byte1 = (byte)((MathUtils.getRandomInt(2) + 12) * this.I_byte_fld + i1);
                    byte3 = (byte)(MathUtils.getRandomInt(5) * this.J_byte_fld + j1);
                } while (getCellUnit(this.bigWar_coordinate[byte3, byte1]) > 0);
                this.humanUnitCellX[byte6] = byte1;
                this.humanUnitCellY[byte6] = byte3;
                this.bigWar_coordinate[byte3, byte1] = (byte)(this.bigWar_coordinate[byte3, byte1] | 0x40);
                this.humanUnitTrapped[byte6] = 0;
            }
        }

        // 初始化人类将领位置
        void void_v()
        {
            int i1 = 0;
            int j1 = 0;
            for (byte byte4 = 0; byte4 < 31; byte4 = (byte)(byte4 + 1))
            {
                byte byte7 = 0;
                while (byte7 < 19)
                {
                    if (this.bigWar_coordinate[byte7, byte4] == 2)
                    {
                        i1 = byte4;
                        j1 = byte7;
                        if (byte4 > 15)
                        {
                            this.I_byte_fld = 0;
                            this.K_byte_fld = 0;
                        }
                        if (byte7 > 10)
                        {
                            this.J_byte_fld = 0;
                            this.L_byte_fld = 0;
                        }
                        break;
                    }
                    byte7 = (byte)(byte7 + 1);
                }
            }
            this.humanUnitCellX[0] = (byte)i1;
            this.humanUnitCellY[0] = (byte)j1;
            this.humanUnitTrapped[0] = 0;
            this.bigWar_coordinate[j1, i1] = (byte)(this.bigWar_coordinate[j1, i1] | 0x40);
            for (byte byte5 = 1; byte5 < this.humanGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
            {
                byte byte0, byte2;
                do
                {
                    byte0 = (byte)(MathUtils.getRandomInt(2) * this.I_byte_fld + i1);
                    byte2 = (byte)(MathUtils.getRandomInt(5) * this.J_byte_fld + j1);
                } while (getCellUnit(this.bigWar_coordinate[byte2, byte0]) > 0);
                this.humanUnitCellX[byte5] = byte0;
                this.humanUnitCellY[byte5] = byte2;
                this.bigWar_coordinate[byte2, byte0] = (byte)(this.bigWar_coordinate[byte2, byte0] | 0x40);
                this.humanUnitTrapped[byte5] = 0;
            }
            for (byte byte6 = 0; byte6 < this.aiGeneralNum_inWar; byte6 = (byte)(byte6 + 1))
            {
                byte byte1, byte3;
                do
                {
                    byte1 = (byte)((MathUtils.getRandomInt(2) + 12) * this.I_byte_fld + i1);
                    byte3 = (byte)(MathUtils.getRandomInt(5) * this.J_byte_fld + j1);
                } while (getCellUnit(this.bigWar_coordinate[byte3, byte1]) > 0);
                this.aiUnitCellX[byte6] = byte1;
                this.aiUnitCellY[byte6] = byte3;
                this.bigWar_coordinate[byte3, byte1] = (byte)(this.bigWar_coordinate[byte3, byte1] | 0x80);
                this.aiUnitTrapped[byte6] = 0;
            }
        }

        // 设置AI方的初始位置
        void AIStance()
        {
            byte[,] ai = new byte[15, 2];
            byte[,] hm = new byte[15, 2];
            byte num1 = 0;
            byte num2 = 0;
            byte hx0 = 0;
            byte hy0 = 0;
            for (byte i = 0; i < 19; i = (byte)(i + 1))
            {
                for (byte j = 0; j < 32; j = (byte)(j + 1))
                {
                    if (this.bigWar_coordinate[i, j] == 2)
                    {
                        ai[num1, 0] = j;
                        ai[num1, 1] = i;
                        num1 = (byte)(num1 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 1)
                    {
                        hm[num2, 0] = j;
                        hm[num2, 1] = i;
                        num2 = (byte)(num2 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 8)
                    {
                        hx0 = j;
                        hy0 = i;
                    }
                }
            }
            this.aiUnitCellX[0] = hx0;
            this.aiUnitCellY[0] = hy0;
            this.aiUnitTrapped[0] = 0;
            this.bigWar_coordinate[hy0, hx0] = (byte)(this.bigWar_coordinate[hy0, hx0] | 0x80);
            for (byte index = 1; index < this.aiGeneralNum_inWar; index = (byte)(index + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = ai[index2, 0];
                    y = ai[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.aiUnitCellX[index] = x;
                this.aiUnitCellY[index] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x80);
                this.aiUnitTrapped[index] = 0;
            }
            for (byte byte5 = 0; byte5 < this.humanGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = hm[index2, 0];
                    y = hm[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.humanUnitCellX[byte5] = x;
                this.humanUnitCellY[byte5] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x40);
                this.humanUnitTrapped[byte5] = 0;
            }
        }

        // 设置人类方的初始位置
        void HMStance()
        {
            byte[,] ai = new byte[15, 2];
            byte[,] hm = new byte[15, 2];
            byte num1 = 0;
            byte num2 = 0;
            byte hx0 = 0;
            byte hy0 = 0;
            for (byte i = 0; i < 19; i = (byte)(i + 1))
            {
                for (byte j = 0; j < 32; j = (byte)(j + 1))
                {
                    if (this.bigWar_coordinate[i, j] == 1)
                    {
                        ai[num1, 0] = j;
                        ai[num1, 1] = i;
                        num1 = (byte)(num1 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 2)
                    {
                        hm[num2, 0] = j;
                        hm[num2, 1] = i;
                        num2 = (byte)(num2 + 1);
                    }
                    else if (this.bigWar_coordinate[i, j] == 8)
                    {
                        hx0 = j;
                        hy0 = i;
                    }
                }
            }
            for (byte index = 0; index < this.aiGeneralNum_inWar; index = (byte)(index + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = ai[index2, 0];
                    y = ai[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.aiUnitCellX[index] = x;
                this.aiUnitCellY[index] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x80);
                this.aiUnitTrapped[index] = 0;
            }
            this.humanUnitCellX[0] = hx0;
            this.humanUnitCellY[0] = hy0;
            this.humanUnitTrapped[0] = 0;
            this.bigWar_coordinate[hy0, hx0] = (byte)(this.bigWar_coordinate[hy0, hx0] | 0x40);
            for (byte byte5 = 1; byte5 < this.humanGeneralNum_inWar; byte5 = (byte)(byte5 + 1))
            {
                byte x, y;
                do
                {
                    byte index2 = (byte)MathUtils.getRandomInt(15);
                    x = hm[index2, 0];
                    y = hm[index2, 1];
                } while (getCellUnit(this.bigWar_coordinate[y, x]) > 0);
                this.humanUnitCellX[byte5] = x;
                this.humanUnitCellY[byte5] = y;
                this.bigWar_coordinate[y, x] = (byte)(this.bigWar_coordinate[y, x] | 0x40);
                this.humanUnitTrapped[byte5] = 0;
            }
        }

        // 开始战争前的准备
        void PrepareWarStance()
        {
            ReadMap();
            if (this.AIAttackHM)
            {
                HMStance(); // 如果AI攻击人类，则先设置人类的位置
            }
            else
            {
                AIStance(); // 否则先设置AI的位置
            }
            ////this.gamecanvas.s_void_b_a((byte)20); // 调用其他方法
            this.Q_byte_array1d_fld = new byte[this.aiGeneralNum_inWar]; // 初始化数组
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
                this.Q_byte_array1d_fld[byte0] = 0; // 清空数组
            this.f_int_fld = 0; // 初始化整型变量
        }

        void void_x()
        {
            this.j_byte_fld = 0; // 初始化字节型变量
            this.e_short_fld = (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId; // 获取人类国家国王ID
            this.userKingId = this.e_short_fld; // 复制国王ID到用户变量
            this.f_short_fld = (CityListCache.GetCityByCityId(this.curCity)).cityBelongKing; // 获取当前城市所属国王ID
            this.aiKingId = this.f_short_fld; // 复制国王ID到AI变量
            this.B_byte_fld = this.tarCity; // 设置目标城市ID
            curWarCityId = this.curCity; // 当前战争城市ID
            WarInfo.curWarCityId = curWarCityId; // 更新战争信息中的城市ID
            this.humanGeneralNum_inWar = this.chooseGeneralNum; // 设置人类参战将军数量
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
                this.humanGeneralId_inWar[i] = this.chooseGeneralIdArray[i]; // 设置人类参战将军ID
            for (byte byte0 = 0; byte0 < this.humanGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
                this.humanUnitTrapped[byte0] = 0; // 初始化人类单位被俘状态
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId); // 获取当前战争城市对象
            this.aiGeneralNum_inWar = curWarCity.getCityGeneralNum(); // 获取该城市的将军数量
            short[] officeGeneralIdArray = curWarCity.getCityOfficeGeneralIdArray(); // 获取该城市的将军ID数组
            for (int j = 0; j < this.aiGeneralNum_inWar; j++)
                this.aiGeneralId_inWar[j] = officeGeneralIdArray[j]; // 设置AI参战将军ID
            if (this.aiGeneralNum_inWar < 10)
            {
                short[] connectCityId = curWarCity.connectCityId; // 获取连接城市ID数组
                for (int k = 0; k < connectCityId.Length || this.aiGeneralNum_inWar >= 10; k++)
                {
                    byte cityId = (byte)connectCityId[k]; // 获取连接城市ID
                    City city = CityListCache.GetCityByCityId(cityId); // 获取连接城市对象
                    if (city.cityBelongKing == this.aiKingId)
                    {
                        while ((city.getCityOfficeGeneralIdArray()).Length < 2 && this.aiGeneralNum_inWar >= 10)
                        {
                            short generalId = city.getMaxBattlePowerGeneralId(); // 获取战斗力最高的将军ID
                            if (generalId == this.aiKingId)
                            {
                                short otherGeneralId = this.aiGeneralId_inWar[0]; // 获取第一个参战将军ID
                                this.aiGeneralId_inWar[this.aiGeneralNum_inWar] = otherGeneralId; // 替换最后一个参战将军ID
                                this.aiGeneralId_inWar[0] = generalId; // 将战斗力最高的将军ID放到第一位
                            }
                            else
                            {
                                this.aiGeneralId_inWar[this.aiGeneralNum_inWar] = generalId; // 添加新的参战将军ID
                            }
                            this.aiGeneralNum_inWar = (byte)(this.aiGeneralNum_inWar + 1); // 增加参战将军数量
                            city.removeOfficeGeneralId(generalId); // 移除该将军ID
                        }
                        city.AppointmentPrefect(); // 任命太守
                    }
                }
            }
            for (byte byte1 = 0; byte1 < this.aiGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
                this.aiUnitTrapped[byte1] = 0; // 初始化AI单位被俘状态
            this.AIAttackHM = false; // 设置AI是否攻击人类的状态
            this.I_byte_fld = 1; // 初始化字节型变量
            this.J_byte_fld = 1; // 初始化字节型变量
            this.K_byte_fld = 1; // 初始化字节型变量
            this.L_byte_fld = 1; // 初始化字节型变量
            this.day = 0; // 初始化天数
            this.F_byte_fld = 0; // 初始化字节型变量
            this.aiMoney_inWar = curWarCity.GetMoney(); // 获取当前城市金钱
            this.aiGrain_inWar = curWarCity.GetFood(); // 获取当前城市粮食
            this.g_boolean_fld = true; // 初始化布尔型变量
            this.N_byte_fld = 0; // 初始化字节型变量
            setHunmanMoveBonus(); // 设置人类移动奖励
            PrepareWarStance(); // 进行其他初始化工作
            /*//this.gamecanvas.void_b(); // 调用游戏画布的方法
            //this.gamecanvas.void_a(); // 调用游戏画布的方法
            //this.gamecanvas.void_i(); // 调用游戏画布的方法*/
        }

        //单元格所需机动力
        int getCellNeedMoves(byte terrain, short genId)
        {
            if ((terrain & 0xC0) != 0)
                return 100;
            terrain = (byte)(terrain & 0x1F);
            int movesNeed = 0;
            switch (terrain)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 19:
                case 22:
                    movesNeed = 2;
                    return movesNeed;
                case 10:
                case 12:
                    movesNeed = 6;
                    if (getSkill_3(genId, 5))
                        movesNeed--;
                    switch ((GeneralListCache.GetGeneral(genId)).army[1])
                    {
                        case 1:
                            movesNeed--;
                            break;
                        case 2:
                            movesNeed -= 2;
                            break;
                        case 3:
                            movesNeed -= 3;
                            break;
                    }
                    return movesNeed;
                case 9:
                case 15:
                    movesNeed = 6;
                    if (getSkill_5(genId, 4))
                        movesNeed--;
                    switch ((GeneralListCache.GetGeneral(genId)).army[2])
                    {
                        case 1:
                            movesNeed--;
                            break;
                        case 2:
                            movesNeed -= 2;
                            break;
                        case 3:
                            movesNeed -= 3;
                            break;
                    }
                    return movesNeed;
                case 11:
                    movesNeed = 5;
                    switch ((GeneralListCache.GetGeneral(genId)).army[2])
                    {
                        case 1:
                            movesNeed--;
                            break;
                        case 2:
                            movesNeed -= 2;
                            break;
                        case 3:
                            movesNeed -= 3;
                            break;
                    }
                    return movesNeed;
            }
            movesNeed = 120;
            return movesNeed;
        }

        short getAllSoldierCountInWar(short[] generalIdInWarArray, byte generalInWarNum, byte[] unitTrapped)
        {
            short allSoldierCount = 0;
            for (byte index = 0; index < generalInWarNum; index = (byte)(index + 1))
            {
                if (unitTrapped[index] == 0 || unitTrapped[index] > 3)
                    allSoldierCount = (short)(allSoldierCount + (GeneralListCache.GetGeneral(generalIdInWarArray[index])).generalSoldier);
            }
            return allSoldierCount;
        }

        bool getSkill_1(short genId, int skillID)
        {
            return getSkill(0, genId, skillID);
        }

        bool getSkill_2(short genId, int skillID)
        {
            return getSkill(1, genId, skillID);
        }

        bool getSkill_3(short genId, int skillId)
        {
            return getSkill(2, genId, skillId);
        }

        bool GetSkill_4(short genId, int skillID)
        {
            return getSkill(3, genId, skillID);
        }

        bool getSkill_5(short genId, int skillId)
        {
            return getSkill(4, genId, skillId);
        }

        private bool getSkill(int i, short genId, int skillId)
        {
            General general = GeneralListCache.GetGeneral(genId);
            return ((general.skills[i] >> 10 - skillId & 0x1) == 1);
        }

        byte planNeedMoves(byte planIndex, short genId)
        {
            byte need = 0;
            switch (planIndex)
            {
                case 0:
                case 3:
                    need = 6;
                    break;
                case 1:
                    need = 5;
                    break;
                case 2:
                    need = 4;
                    break;
                case 4:
                    need = 7;
                    break;
                case 5:
                case 6:
                case 7:
                case 13:
                    need = 8;
                    break;
                case 9:
                    need = 9;
                    break;
                case 8:
                case 10:
                case 11:
                case 12:
                case 15:
                    need = 10;
                    break;
                case 14:
                    need = 12;
                    break;
                default:
                    need = 100;
                    return need;
            }
            if (getSkill_1(genId, 2))
                need = (byte)(need - 2);
            return need;
        }

        bool isInRange(byte x1, byte y1, byte x2, byte y2, int distance)
        {
            // 检查两个坐标之间的距离是否小于等于指定的距离
            return (System.Math.Abs(x1 - x2) <= distance && System.Math.Abs(y1 - y2) <= distance);
        }

        bool isAdjacent(byte x1, byte y1, byte x2, byte y2)
        {
            // 检查两个坐标是否相邻
            return (System.Math.Abs(x1 - x2) + System.Math.Abs(y1 - y2) == 1);
        }

            // 获取相邻单位的数量
            byte getAdjacentUnitNum(byte x, byte y)
            {
                byte byte2 = 0;

                // 检查x坐标左边的单元格
                if (x > 0)
                {
                    // 如果当前单元格和左边单元格的高位字节都设置了（0xC0表示高位字节），则设置 byte2 的 0x10 位
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y, x - 1]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // 如果当前单元格和左边单元格的高位字节都非零，则设置 byte2 的 0x1 位
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y, x - 1] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // 检查x坐标右边的单元格
                if (x < this.bigWar_coordinate.GetLength(1) - 1)
                {
                    // 如果当前单元格和右边单元格的高位字节都设置了，则设置 byte2 的 0x10 位
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y, x + 1]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // 如果当前单元格和右边单元格的高位字节都非零，则设置 byte2 的 0x1 位
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y, x + 1] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // 检查y坐标上方的单元格
                if (y > 0)
                {
                    // 如果当前单元格和上方单元格的高位字节都设置了，则设置 byte2 的 0x10 位
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y - 1, x]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // 如果当前单元格和上方单元格的高位字节都非零，则设置 byte2 的 0x1 位
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y - 1, x] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // 检查y坐标下方的单元格
                if (y < this.bigWar_coordinate.GetLength(0) - 1)
                {
                    // 如果当前单元格和下方单元格的高位字节都设置了，则设置 byte2 的 0x10 位
                    if (((this.bigWar_coordinate[y, x] | this.bigWar_coordinate[y + 1, x]) & 0xC0) == 192)
                    {
                        byte2 = (byte)(byte2 | 0x10);
                    }
                    // 如果当前单元格和下方单元格的高位字节都非零，则设置 byte2 的 0x1 位
                    else if ((this.bigWar_coordinate[y, x] & this.bigWar_coordinate[y + 1, x] & 0xC0) != 0)
                    {
                        byte2 = (byte)(byte2 | 0x1);
                    }
                }

                // 返回最终的 byte2 值
                return byte2;
            }

            bool curCellCanPlan(short planGenId, int planGeneralIndex, int bePlanCeneralIndex, byte curPlanIndex, bool isHunmanPlan)
        {
            byte[] abyte0, abyte1, abyte2, abyte3;
            if (isHunmanPlan)
            {
                abyte0 = this.humanUnitCellX;
                abyte1 = this.humanUnitCellY;
                abyte2 = this.aiUnitCellX;
                abyte3 = this.aiUnitCellY;
            }
            else
            {
                abyte0 = this.aiUnitCellX;
                abyte1 = this.aiUnitCellY;
                abyte2 = this.humanUnitCellX;
                abyte3 = this.humanUnitCellY;
            }

            byte x1 = abyte0[planGeneralIndex];
            byte y1 = abyte1[planGeneralIndex];
            byte x2 = abyte2[bePlanCeneralIndex];
            byte y2 = abyte3[bePlanCeneralIndex];

            byte planUnitCellType = (byte)(this.bigWar_coordinate[y1,x1] & 0x1F);
            byte bePlanUnitCellType = (byte)(this.bigWar_coordinate[y2,x2] & 0x1F);

            bool canPlan = false;
            byte range = 0;

            switch (curPlanIndex)
            {
                case 0:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (((bePlanUnitCellType >= 1 && bePlanUnitCellType <= 4) || bePlanUnitCellType == 10 || bePlanUnitCellType == 11) && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 1:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 12 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 2:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 12 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 3:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 12 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 4:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType == 9 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 5:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 8))
                    {
                        range = (byte)(range + 1);
                    }
                    if (bePlanUnitCellType != 8 && bePlanUnitCellType != 9 && bePlanCeneralIndex == 0 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 6:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 9))
                    {
                        range = (byte)(range + 1);
                    }
                    if (bePlanUnitCellType == 12 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 1)
                        canPlan = true;
                    break;
                case 7:
                    if (getSkill_1(planGenId, 1))
                    {
                        if (bePlanUnitCellType == 8 && isInRange(x1, y1, x2, y2, 1))
                            canPlan = true;
                        break;
                    }
                    if (bePlanUnitCellType == 8 && isAdjacent(x1, y1, x2, y2))
                        canPlan = true;
                    break;
                case 8:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 8))
                    {
                        range = (byte)(range + 1);
                    }
                    if ((bePlanUnitCellType == 10 || bePlanUnitCellType == 11) && isInRange(x1, y1, x2, y2, range) && bePlanCeneralIndex == 0)
                        canPlan = true;
                    break;
                case 9:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType != 8 && (planUnitCellType == 8 || planUnitCellType == 12) && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 10:
                    range = 5;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType == 9 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 1)
                        canPlan = true;
                    break;
                case 11:
                    range = 2;
                    if (getSkill_1(planGenId, 7))
                    {
                        range = (byte)(range + 2);
                    }
                    else if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    if (planUnitCellType >= 10 && planUnitCellType <= 12 && bePlanUnitCellType != 8 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 12:
                    range = 3;
                    if (getSkill_1(planGenId, 1))
                    {
                        range = (byte)(range + 1);
                    }
                    else if (getSkill_1(planGenId, 9))
                    {
                        range = (byte)(range + 1);
                    }
                    if (bePlanUnitCellType == 9 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 1)
                        canPlan = true;
                    break;
                case 13:
                    range = 2;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if ((planUnitCellType == 8 || planUnitCellType == 12) && bePlanUnitCellType != 8 && isInRange(x1, y1, x2, y2, range))
                        canPlan = true;
                    break;
                case 14:
                    range = 3;
                    if (getSkill_1(planGenId, 1))
                        range = (byte)(range + 1);
                    if (bePlanUnitCellType >= 10 && bePlanUnitCellType <= 11 && isInRange(x1, y1, x2, y2, range) && getAdjacentUnitNum(x2, y2) >= 2)
                        canPlan = true;
                    break;
                case 15:
                    canPlan = false;
                    break;
            }
            return canPlan;
        }

        byte byte_s1bs_a(short[] aword0, byte byte0, short word0)
        {
            for (byte byte1 = 0; byte1 < byte0; byte1 = (byte)(byte1 + 1))
            {
                // 寻找数组中指定值的位置
                if (aword0[byte1] == word0)
                    return byte1;
            }
            return 0;
        }

        bool userRetreatGeneral()
        {
            this.HMGeneralId = this.humanGeneralId_inWar[0];
            FindRetreatCity(curWarCityId);
            if (this.disasterThings == 0 && this.HMGeneralId == this.userKingId)
            {
                if (GeneralDie(this.HMGeneralId, true))
                {
                    this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];
                    this.j_byte_fld = 0;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                this.N_byte_fld = 0;
                ////this.gamecanvas.void_B_a(true);
            }
            return true;
        }

        void void_s_c(short generalId)
        {
            this.HMGeneralId = generalId;
            byte byte0 = byte_s1bs_a(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, generalId);
            FindRetreatCity(curWarCityId);
            if (byte0 == 0)
            {
                if (this.disasterThings == 0 && this.HMGeneralId == this.userKingId)
                {
                    ////this.gamecanvas.r_byte_fld = 18;//主将撤退
                }
                else
                {
                    this.N_byte_fld = 0;
                }
            }
            else
            {
                this.N_byte_fld = (byte)-byte0;
            }
            ////this.gamecanvas.void_B_a(true);
        }

        void void_sbs_a(short generalId, byte cityId, short belongKing)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            city.AddOfficeGeneralId(generalId);
            if (city.cityBelongKing == 0)
            {
                Country country = CountryListCache.GetCountryByKingId(belongKing);
                country.AddCity(cityId);
                city.prefectId = generalId;
            }
            else if (generalId == belongKing)
            {
                city.prefectId = generalId;
            }
            city.AppointmentPrefect();
        }

        void void_y()
        {
            byte byte0 = (byte)Math.Abs(this.N_byte_fld);
            if (byte0 < this.humanGeneralNum_inWar)
            {
                this.humanUnitTrapped[byte0] = 1;
                this.bigWar_coordinate[this.humanUnitCellY[byte0],this.humanUnitCellX[byte0]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[byte0],this.humanUnitCellX[byte0]] & 0x3F);
            }
            else
            {
                byte0 = (byte)(byte0 - this.humanGeneralNum_inWar);
                this.aiUnitTrapped[byte0] = 1;
                this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] & 0x3F);
            }
        }

        void void_z()
        {
            Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            userCountry.RemoveCity(curWarCityId);
            if (userCountry.GetHaveCityNum() <= 0)
                GameInfo.countryDieTips = 3;
            CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).AddCity(curWarCityId);
            City city = CityListCache.GetCityByCityId(curWarCityId);
            city.ClearAllOfficeGeneral();
            city.cityBelongKing = (CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId;
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
                city.AddOfficeGeneralId(this.aiGeneralId_inWar[i]);
            city.AppointmentPrefect();
        }

        void void_A()
        {
            byte byte0 = 0;
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId);
            for (byte byte1 = 0; byte1 < this.aiGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
            {
                if (this.aiUnitTrapped[byte1] == 0 || this.aiUnitTrapped[byte1] > 3)
                {
                    byte0 = (byte)(byte0 + 1);
                    this.aiGeneralId_inWar[byte0] = this.aiGeneralId_inWar[byte1];
                }
            }
            this.aiGeneralNum_inWar = byte0;
            for (byte byte2 = 0; byte2 < this.humanGeneralNum_inWar; byte2 = (byte)(byte2 + 1))
            {
                if (this.humanUnitTrapped[byte2] == 2)
                {
                    short userGeneralId = this.humanGeneralId_inWar[byte2];
                    if (this.aiGeneralNum_inWar < 10)
                    {
                        RandomSetGeneralLoyalty(userGeneralId);
                        this.aiGeneralNum_inWar = (byte)(this.aiGeneralNum_inWar + 1);
                        this.aiGeneralId_inWar[this.aiGeneralNum_inWar] = userGeneralId;
                    }
                    else
                    {
                        curWarCity.AddNotFoundGeneralId(userGeneralId);
                    }
                }
            }
            curWarCity.ClearAllOfficeGeneral();
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
                curWarCity.AddOfficeGeneralId(this.aiGeneralId_inWar[i]);
            curWarCity.AppointmentPrefect();
            curWarCity.SetMoney(this.aiMoney_inWar);
            curWarCity.SetFood(this.aiGrain_inWar);
            if (this.h_boolean_fld)
            {
                curWarCity.AddMoney(this.humanMoney_inWar);
                curWarCity.AddFood(this.humanGrain_inWar);
            }
            if (GameInfo.countryDieTips > 1)
            {
                //this.gamecanvas.r_byte_fld = 8;
                void_B();
                this.j_byte_fld = 0;
                if (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).GetHaveCityNum() <= 0)
                    GameInfo.countryDieTips = 3;
            }
        }

        void void_b_d(byte cityId)
        {
            if (cityId > 0)
            {
                void_sbs_a(this.HMGeneralId, cityId, (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId);
            }
            else
            {
                if (CountryListCache.GetCountryByKingId(this.HMGeneralId) != null)
                {
                    //this.gamecanvas.void_B_a(false);
                    return;
                }
                CityListCache.GetCityByCityId(curWarCityId).AddNotFoundGeneralId(this.HMGeneralId);
            }
            if (this.N_byte_fld == 0 && cityId > 0)
            {
                City city = CityListCache.GetCityByCityId(cityId);
                city.AddMoney(this.humanMoney_inWar);
                city.AddFood(this.humanGrain_inWar);
            }
            if (this.N_byte_fld < 0)
            {
                //this.gamecanvas.void_B_a(false);
            }
            else
            {
                //this.gamecanvas.s_boolean_fld = true;
                this.N_byte_fld = (byte)(this.N_byte_fld + 1);
                byte byte1;
                for (byte1 = this.N_byte_fld; byte1 < this.humanGeneralNum_inWar && this.humanUnitTrapped[byte1] != 0 && this.humanUnitTrapped[byte1] <= 3;)
                    byte1 = (byte)(byte1 + 1);
                if (byte1 < this.humanGeneralNum_inWar)
                {
                    FindRetreatCity(curWarCityId);
                    this.N_byte_fld = byte1;
                    this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];
                }
                else
                {
                    if (this.N_byte_fld < this.humanGeneralNum_inWar)
                        this.N_byte_fld = this.humanGeneralNum_inWar;
                    byte byte2;
                    for (byte2 = (byte)(this.N_byte_fld - this.humanGeneralNum_inWar); byte2 < this.aiGeneralNum_inWar && this.aiUnitTrapped[byte2] != 2;)
                        byte2 = (byte)(byte2 + 1);
                    if (byte2 < this.aiGeneralNum_inWar)
                    {
                        FindRetreatCity(curWarCityId);
                        if (this.disasterThings > 0)
                            RandomSetGeneralLoyalty(this.aiGeneralId_inWar[byte2]);
                        this.N_byte_fld = (byte)(this.humanGeneralNum_inWar + byte2);
                        this.HMGeneralId = this.aiGeneralId_inWar[byte2];
                    }
                    else
                    {
                        //this.gamecanvas.void_B_a(false);
                        if (this.AIAttackHM)
                            void_z();
                        void_A();
                        this.j_byte_fld = 4;
                        return;
                    }
                }
            }
            void_y();
        }

        //处理城市间的连接和归属逻辑
        void FindRetreatCity(byte cityId)
        {
            byte byte1 = 0;
            City curCity = CityListCache.GetCityByCityId(cityId);
            for (byte index = 0; index < curCity.connectCityId.Length; index = (byte)(index + 1))
            {
                byte byte3 = (byte)curCity.connectCityId[index];
                City city = CityListCache.GetCityByCityId(byte3);
                if (city.cityBelongKing != 0 && (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId == city.cityBelongKing && city.getCityGeneralNum() < 10)
                {
                    byte1 = (byte)(byte1 + 1);
                    this.G_byte_array1d_fld[byte1] = (byte)byte3;
                }
            }
            this.G_byte_array1d_fld[byte1] = 0;
            this.disasterThings = byte1;
        }

        void void_B()
        {/*
            long l1 = System.Environment.TickCount;
            while (true)
            {
                if (//this.gamecanvas.getKeyValue() != 0)
                {
                    //this.gamecanvas.void_h();
                    if (!//this.gamecanvas.C_boolean_fld)
                        //this.gamecanvas.setKeyValue((byte)0);
                }
                if (this.j_byte_fld <= 0)
                {
                    long l2 = System.Environment.TickCount - l1;
                    if (l2 < 100L)
                        try
                        {
                            System.Threading.Thread.Sleep((int)(100L - l2));
                        }
                        catch (System.Exception exception) { }
                    //this.gamecanvas.repaint();
                    l1 = System.Environment.TickCount;
                    continue;
                }
                break;
            }*/
        }

        void void_s1bb1_a(short[] humanInWarGeneralIdArray, byte humanInWarGeneralNum, byte[] abyte0)
        {
            for (byte index = 0; index < humanInWarGeneralNum; index = (byte)(index + 1))
            {
                if (abyte0[index] >= 4)
                {
                    if (abyte0[index] > 7)
                    {
                        General humanGeneral = GeneralListCache.GetGeneral(humanInWarGeneralIdArray[index]);
                        humanGeneral.generalSoldier = (short)(humanGeneral.generalSoldier - 100 + MathUtils.getRandomInt(150 - humanGeneral.lead));
                        if (humanGeneral.generalSoldier < 0)
                            humanGeneral.generalSoldier = 0;
                    }
                    if (abyte0[index] == 4 || abyte0[index] == 5 || abyte0[index] == 8)
                    {
                        abyte0[index] = 0;
                    }
                    else
                    {
                        abyte0[index] = (byte)(abyte0[index] - 1);
                    }
                }
            }
        }

        // 检查是否有可支援的城市
        bool boolean_bsi_a(byte warCityId, short kingId)
        {
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId);
                if (city.cityBelongKing == kingId && cityId != warCityId && city.getCityGeneralNum() < 10)
                    return true;
            }
            return false;
        }

        // 计算受困的将军数量
        int TrappedUnitNum()
        {
            int i1 = 0;
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.aiUnitTrapped[byte0] > 0 && this.aiUnitTrapped[byte0] < 4)
                    i1++;
            }
            for (byte byte1 = 0; byte1 < this.humanGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
            {
                if (this.humanUnitTrapped[byte1] == 2)
                    i1++;
            }
            return i1;
        }

        // 判断 AI 是否可以撤退
        bool boolean_d()
        {
            TrappedUnitNum();
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;
            return !((GeneralListCache.GetGeneral(this.aiGeneralId_inWar[0])).generalSoldier >= 100 && GeneralListCache.GetGeneral(this.aiGeneralId_inWar[0]).getCurPhysical() >= 15);
        }

        // 计算人类方的战斗力
        short short_a()
        {
            short word0 = 0;
            for (byte byte0 = 0; byte0 < this.humanGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.humanUnitTrapped[byte0] <= 0 || this.humanUnitTrapped[byte0] >= 4)
                {
                    word0 = (short)(word0 + 500);
                    word0 = (short)(word0 + (GeneralListCache.GetGeneral(this.humanGeneralId_inWar[byte0])).generalSoldier);
                }
            }
            return word0;
        }

        // 计算 AI 方的战斗力
        short short_b()
        {
            short word0 = 0;
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.aiUnitTrapped[byte0] <= 0 || this.aiUnitTrapped[byte0] >= 4)
                {
                    word0 = (short)(word0 + 500);
                    word0 = (short)(word0 + (GeneralListCache.GetGeneral(this.aiGeneralId_inWar[byte0])).generalSoldier);
                }
            }
            return word0;
        }

        // 随机选择一个可以撤退的城市 ID
        byte RandomRetreatCityId(short word0, byte[] abyte0, byte byte0, byte byte1)
        {
            return abyte0[MathUtils.getRandomInt(byte0)];
        }

        // 获取可以撤退的城市 ID
        byte getCanRetreatCityId(short aiKingId)
        {
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId);
            byte[] abyte0 = new byte[curWarCity.connectCityId.Length];
            byte byte1 = 0;
            for (int i1 = 0; i1 < curWarCity.connectCityId.Length; i1++)
            {
                byte b = (byte)curWarCity.connectCityId[i1];
                City city = CityListCache.GetCityByCityId(b);
                if (city.cityBelongKing == aiKingId && city.getCityGeneralNum() < 10)
                {
                    abyte0[byte1] = b;
                    byte1 = (byte)(byte1 + 1);
                }
            }
            if (byte1 > 0)
                return getCanRetreatCityId(aiKingId, abyte0, byte1, curWarCityId);
            byte[] abyte1 = new byte[CityListCache.CITY_NUM];
            byte byte2 = 0;
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                if (cityId != curWarCityId)
                {
                    City city = CityListCache.GetCityByCityId(cityId);
                    if (city.cityBelongKing == aiKingId && city.getCityGeneralNum() < 10)
                    {
                        abyte1[byte2] = cityId;
                        byte2 = (byte)(byte2 + 1);
                    }
                }
            }
            if (byte2 > 0)
                return getCanRetreatCityId(aiKingId, abyte1, byte2, curWarCityId);
            return 0;
        }

        // 设置将军为撤退状态
        void GeneralPrepareRetreat(short generalId)
        {
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.aiGeneralId_inWar[byte0] == generalId)
                {
                    this.aiUnitTrapped[byte0] = 1;
                    this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] & 0x3F);
                    return;
                }
            }
        }

        // 将将军撤退到指定城市
        void generalRetreat(short generalId, byte cityId)
        {
            CityListCache.GetCityByCityId(curWarCityId).removeOfficeGeneralId(generalId);
            if (cityId > 0)
            {
                void_sbs_a(generalId, cityId, this.aiKingId);
            }
            else if (GeneralListCache.GetGeneral(generalId) != null)
            {
                CityListCache.GetCityByCityId(curWarCityId).AddNotFoundGeneralId(generalId);
            }
            GeneralPrepareRetreat(generalId);
        }

        // 将将军加入当前战争城市的官员列表
        void void_s1b_a(short[] aword0, byte generalNum)
        {
            for (int i1 = 0; i1 < generalNum; i1++)
                CityListCache.GetCityByCityId(curWarCityId).AddOfficeGeneralId(aword0[i1]);
        }

        void void_C()
        {
            // 初始化数组
            short[] AINoRetreatGeneralIdArray = new short[10];
            short[] generalIdArray = new short[10];
            List<short> aiGeneralIdArray=new List<short>();
            byte generalNum = 0;
            byte AINoRetreatGeneralNum = 0;

            // 获取当前战争城市
            City curWarCity = CityListCache.GetCityByCityId(curWarCityId);
            curWarCity.ClearAllOfficeGeneral();

            // 获取攻击国和 AI 国家
            Country attackCountry = CountryListCache.GetCountryByKingId(this.e_short_fld);
            Country aiCountry = CountryListCache.GetCountryByKingId(this.aiKingId);

            // 根据攻击国是否为人类国家执行不同逻辑
            if (attackCountry.countryId == GameInfo.humanCountryId)
            {
                aiCountry.RemoveCity(curWarCityId);
                curWarCity.prefectId = this.humanGeneralId_inWar[0];
                attackCountry.AddCity(curWarCityId);
            }

            // 设置当前战争城市的粮食和金钱
            curWarCity.SetFood(this.humanGrain_inWar);
            curWarCity.SetMoney(this.humanMoney_inWar);

            bool masterRetreat = true;

            // 处理 AI 将军
            for (byte b1 = 0; b1 < this.aiGeneralNum_inWar; b1 = (byte)(b1 + 1))
            {
                if (this.aiUnitTrapped[b1] == 0 || this.aiUnitTrapped[b1] > 3)
                {
                    aiGeneralIdArray.Add(this.aiGeneralId_inWar[b1]);
                    continue;
                }

                if (this.aiUnitTrapped[b1] == 2 || this.aiUnitTrapped[b1] == 3)
                {
                    if (b1 == 0)
                    {
                        masterRetreat = false;
                        Country country = CountryListCache.GetCountryByKingId(this.aiGeneralId_inWar[0]);
                        if (country != null)
                        {
                            GameInfo.chooseGeneralName = (GeneralListCache.GetGeneral(country.countryKingId)).generalName;
                            this.m_byte_fld = country.countryId;
                            if (country.GetHaveCityNum() > 0)
                            {
                                short newKingGeneralId = country.Inherit();
                                if (this.AIAttackHM)
                                {
                                    this.e_short_fld = newKingGeneralId;
                                }
                                else
                                {
                                    this.f_short_fld = newKingGeneralId;
                                }
                                this.aiKingId = newKingGeneralId;
                                GameInfo.countryDieTips = 1;
                                GameInfo.ShowInfo = string.Format("{0} 死亡, 新君主 {1} 继位!", GameInfo.chooseGeneralName, GeneralListCache.GetGeneral(newKingGeneralId).generalName);
                            }
                            else
                            {
                                CountryListCache.removeCountry(country.countryId);
                            }
                            continue;
                        }
                    }

                    if (this.aiUnitTrapped[b1] == 2)
                    {
                        AINoRetreatGeneralNum = (byte)(AINoRetreatGeneralNum + 1);
                        AINoRetreatGeneralIdArray[AINoRetreatGeneralNum] = this.aiGeneralId_inWar[b1];
                    }
                    else
                    {
                        GeneralListCache.GeneralDie(this.aiGeneralId_inWar[b1]);
                    }
                }
            }

            // 处理人类将军
            for (byte b1 = 0; b1 < this.humanGeneralNum_inWar; b1 = (byte)(b1 + 1))
            {
                if (this.humanUnitTrapped[b1] == 0 || this.humanUnitTrapped[b1] > 3)
                {
                    generalNum = (byte)(generalNum + 1);
                    generalIdArray[generalNum] = this.humanGeneralId_inWar[b1];
                }
                else if (this.humanUnitTrapped[b1] == 2)
                {
                    if (masterRetreat)
                    {
                        RandomSetGeneralLoyalty(this.humanGeneralId_inWar[b1]);
                        aiGeneralIdArray.Add(this.humanGeneralId_inWar[b1]);
                    }
                    else
                    {
                        generalNum = (byte)(generalNum + 1);
                        generalIdArray[generalNum] = this.humanGeneralId_inWar[b1];
                    }
                }
            }

            // 如果主将军未撤退，则更新城市的金钱和粮食
            if (!masterRetreat)
            {
                curWarCity.AddMoney(this.aiMoney_inWar);
                curWarCity.AddFood(this.aiGrain_inWar);
            }

            // AI 将军撤退到城市
            aiCountry.RetreatGeneralToCity(aiGeneralIdArray.ToArray(), curWarCityId, this.aiGrain_inWar, this.aiMoney_inWar, !masterRetreat);

            // 更新人类将军列表
            this.humanGeneralId_inWar = generalIdArray;
            curWarCity.prefectId = this.humanGeneralId_inWar[0];
            this.humanGeneralNum_inWar = generalNum;
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
                curWarCity.AddOfficeGeneralId(this.humanGeneralId_inWar[i]);

            // 添加无法撤退的 AI 将军到反对派列表
            for (byte byte10 = 0; byte10 < AINoRetreatGeneralNum; byte10 = (byte)(byte10 + 1))
                curWarCity.AddOppositionGeneralId(AINoRetreatGeneralIdArray[byte10]);

            // 设置战争状态
            this.j_byte_fld = 4;
        }

        void void_D()
        {
            // 调用 void_C 方法
            void_C();
        }

        short short_c()
        {
            short word0 = 0;
            // 计算总士兵数
            for (byte byte0 = 0; byte0 < this.humanGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
            {
                if (this.humanUnitTrapped[byte0] <= 0 || this.humanUnitTrapped[byte0] >= 4)
                {
                    word0 = (short)(word0 + 500);
                    word0 = (short)(word0 + (GeneralListCache.GetGeneral(this.humanGeneralId_inWar[byte0])).generalSoldier);
                }
            }
            return word0;
        }

        void void_s_e(short word0)
        {
            // 减少将军士兵数量
            int i1 = (GeneralListCache.GetGeneral(word0)).generalSoldier / 2;
            i1 += MathUtils.getRandomInt(200);
            if (i1 < 200)
                i1 = 200 + MathUtils.getRandomInt(100);
            if (i1 > (GeneralListCache.GetGeneral(word0)).generalSoldier)
                i1 = (GeneralListCache.GetGeneral(word0)).generalSoldier;
            (GeneralListCache.GetGeneral(word0)).generalSoldier = (short)((GeneralListCache.GetGeneral(word0)).generalSoldier - i1);
        }

        void void_ii_b(int i1, int j1)
        {
            try
            {
                // 设置将军 ID 和索引
                this.HMGeneralId = this.humanGeneralId_inWar[i1];
                this.AIGeneralId = this.aiGeneralId_inWar[j1];
                this.hmbattleIndex = (byte)i1;
                this.aibettleIndex = (byte)j1;
                //this.gamecanvas.humanGeneralId = this.HMGeneralId;
                //this.gamecanvas.AIGeneralId = this.AIGeneralId;
                this.warTerrain = (byte)(this.bigWar_coordinate[this.humanUnitCellY[i1],this.humanUnitCellX[i1]] & 0xF);
                //this.gamecanvas.r_byte_fld = 2;
                this.aiAtkHm = true;
                void_B(); // 调用 void_B 方法
                this.j_byte_fld = 3;
            }
            catch (Exception exception) { }
        }

        byte planSuccessRate(short planGeneralId, short bePlanGeneralId, byte plan)
        {
            int s1, s2, success = 0;
            General planGeneral = GeneralListCache.GetGeneral(planGeneralId);
            General bePlanGeneral = GeneralListCache.GetGeneral(bePlanGeneralId);
            byte IQ1 = planGeneral.IQ;
            byte IQ2 = bePlanGeneral.IQ;
            byte lead1 = planGeneral.lead;
            byte lead2 = bePlanGeneral.lead;
            byte force2 = bePlanGeneral.force;
            byte moral2 = bePlanGeneral.moral;
            byte type = bePlanGeneral.army[2];

            // 根据不同的计划进行成功率计算
            switch (plan)
            {
                case 0:
                case 1:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 40.0 - (100 - IQ1) * 0.1 - lead2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 4:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 40.0 - (100 - IQ1) * 0.1 - lead2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    if (type > 0)
                    {
                        s1 -= type * 3;
                        s2 -= type * 2;
                    }
                    success = Math.Min(s1, s2);
                    break;

                case 2:
                case 3:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - force2 * 0.08);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 45.0 - (100 - IQ1) * 0.1 - force2 * 0.08);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 5:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - lead2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 6:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - moral2 * 0.05);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - moral2 * 0.05);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 7:
                    if (GeneralListCache.GetGeneral(bePlanGeneralId).generalSoldier > 1800 + MathUtils.getRandomInt(300))
                    {
                        s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - moral2 * 0.05);
                        s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - moral2 * 0.05);
                        if (IQ1 < IQ2)
                            s2 -= (IQ2 - IQ1) / 6;
                        success = Math.Min(s1, s2);
                    }
                    else
                    {
                        success = 0;
                    }
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    s1 = (int)(IQ1 * 0.3 - IQ2 * 0.2 + 70.0 - lead2 * 0.05 + lead1 * 0.08);
                    s2 = (int)((IQ1 * IQ1) * (100.0 - IQ2 * 0.9) * 100.0 / (IQ1 * IQ1 + IQ2 * IQ2) / 60.0 - (100 - IQ1) * 0.1 - lead2 * 0.05 + lead1 * 0.08);
                    if (IQ1 < IQ2)
                        s2 -= (IQ2 - IQ1) / 6;
                    success = Math.Min(s1, s2);
                    break;

                case 15:
                    success = 99;
                    break;
            }

            // 技能调整成功率
            if (getSkill_1(planGeneralId, 5))
            {
                success = (int)(success + success * 0.2);
            }
            else if (getSkill_1(planGeneralId, 4) && (plan == 0 || plan == 14))
            {
                success += success / 3;
            }
            else if (getSkill_1(planGeneralId, 7) && plan == 10)
            {
                success += success / 3;
            }
            else if (getSkill_1(planGeneralId, 8) && (plan == 5 || plan == 8))
            {
                success += success / 3;
            }
            else if (getSkill_1(planGeneralId, 9) && (plan == 6 || plan == 12))
            {
                success += success / 3;
            }

            if (getSkill_1(bePlanGeneralId, 0) || getSkill_1(bePlanGeneralId, 5))
            {
                success -= success / 2;
            }
            else if (getSkill_1(bePlanGeneralId, 5))
            {
                success = (int)(success - success * 0.2);
            }

            // 限制成功率范围
            if (success > 99)
                success = 99;
            if (success < 0)
                success = 0;

            return (byte)success;
        }


        // 计策结果
        public int setplanResult(short planGeneralId, short bePlanGeneralId, byte plan, byte index, bool flag)
        {
            byte upday;
            int hurt2, totalhurt, sroundHurt1, totalhurt2;
            byte IQ1 = GeneralListCache.GetGeneral(planGeneralId).IQ; // 获取攻击方武将的智力
            General bePlanGeneral = GeneralListCache.GetGeneral(bePlanGeneralId); // 获取被攻击方武将
            byte IQ2 = bePlanGeneral.IQ; // 获取被攻击方的智力
            int hurt = 0; // 初始化伤害值

            // 根据策略类型处理
            switch (plan)
            {
                case 0:
                case 3:
                case 4:
                case 7:
                    // 当攻击方智力大于等于防御方时
                    if (IQ1 >= IQ2)
                    {
                        hurt = MathUtils.getRandomInt((IQ1 - IQ2) * 2 + 2); // 根据智力差距计算伤害
                    }
                    else
                    {
                        hurt -= MathUtils.getRandomInt((IQ2 - IQ1) * 2 + 2); // 防御方智力高时减低攻击伤害
                    }
                    hurt += 250; // 基础伤害
                    if (getSkill_1(planGeneralId, 4) && plan == 0)
                    {
                        hurt *= 2; // 技能加成：若有技能并且为特定计划，双倍伤害
                    }
                    else if (getSkill_1(planGeneralId, 3))
                    {
                        hurt += hurt / 2; // 其他技能加成
                    }
                    // 确保不会减少士兵数超过现有士兵数
                    if (bePlanGeneral.generalSoldier < hurt)
                        hurt = bePlanGeneral.generalSoldier;
                    bePlanGeneral.generalSoldier = (short)(bePlanGeneral.generalSoldier - hurt); // 减少士兵数量
                    this.b_java_lang_String_fld = "士兵数减少 " + hurt; // 更新输出信息
                    break;

                case 1:
                    hurt = MathUtils.getRandomInt(6) + 15; // 计算体力减少的值
                    if (bePlanGeneral.getCurPhysical() - 1 < hurt)
                        hurt = bePlanGeneral.getCurPhysical() - 1; // 防止体力减少到负值
                    bePlanGeneral.decreaseCurPhysical((byte)hurt); // 减少体力
                    this.b_java_lang_String_fld = "武将体力减少 " + hurt; // 更新输出信息
                    break;

                case 2:
                    upday = 4; // 初始困兵天数
                    if (getSkill_1(planGeneralId, 3))
                        upday = 5; // 技能加成困兵时间
                    if (flag)
                    {
                        this.aiUnitTrapped[index] = upday; // 更新AI单位的被困状态
                    }
                    else
                    {
                        this.humanUnitTrapped[index] = upday; // 更新玩家单位的被困状态
                    }
                    this.b_java_lang_String_fld = "军队中计被困"; // 更新输出信息
                    break;

                case 5:
                    if (flag)
                    {
                        hurt = this.aiGrain_inWar / 4; // 计算粮食损失
                        if (getSkill_1(planGeneralId, 3))
                            hurt += hurt / 2; // 技能加成
                        if (hurt < 200)
                            hurt = this.aiGrain_inWar; // 若损失过少，设为全部损失
                        this.aiGrain_inWar = (short)(this.aiGrain_inWar - hurt); // AI粮食减少
                        this.humanGrain_inWar = (short)(this.humanGrain_inWar + hurt); // 玩家粮食增加
                        if (this.humanGrain_inWar > 30000)
                            this.humanGrain_inWar = 30000; // 限制最大粮食数量
                    }
                    else
                    {
                        hurt = this.humanGrain_inWar / 4; // 同理计算玩家粮食损失
                        if (getSkill_1(planGeneralId, 3))
                            hurt += hurt / 2;
                        if (hurt < 200)
                            hurt = this.humanGrain_inWar;
                        this.humanGrain_inWar = (short)(this.humanGrain_inWar - hurt); // 玩家粮食减少
                        this.aiGrain_inWar = (short)(this.aiGrain_inWar + hurt); // AI粮食增加
                        if (this.aiGrain_inWar > 30000)
                            this.aiGrain_inWar = 30000; // 限制AI粮食数量
                    }
                    this.b_java_lang_String_fld = "粮食减少 " + hurt; // 更新输出信息
                    hurt = 0;
                    break;

                // 其他 case 处理逻辑与以上类似...

                case 15:
                    this.b_java_lang_String_fld = "奇门遁甲施展完毕!"; // 特殊情况的处理
                    break;
            }

            return hurt; // 返回最终伤害值
        }


        public void getAttackRangeMap(byte[,] attackRangeMap, int unitCellX, int unitCellY)
        {
            // 计算最小与最大攻击范围
            int minRange = 1;
            int maxRange = 1;

            // 计算开始和结束坐标
            int startCellX = unitCellX - maxRange;
            if (startCellX < 0)
                startCellX = 0;
            int startCellY = unitCellY - maxRange;
            if (startCellY < 0)
                startCellY = 0;
            int endCellX = unitCellX + maxRange;
            if (endCellX >= 19)
                endCellX = 18;
            int endCellY = unitCellY + maxRange;
            if (endCellY >= 32)
                endCellY = 31;

            // 根据范围更新地图
            for (int i = startCellX; i <= endCellX; i++)
            {
                for (int j = startCellY; j <= endCellY; j++)
                {
                    int range = Math.Abs(i - unitCellX) + Math.Abs(j - unitCellY);
                    if (range >= minRange && range <= maxRange && attackRangeMap[i, j] < 0)
                        attackRangeMap[i, j] = byte.MaxValue;
                }
            }
        }

        void getAttackMoveRangeMap(byte[,] attackRangeMap, byte moves, byte index)
        {
            getMoveMap(attackRangeMap, index);
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (attackRangeMap[i, j] >= 0 && attackRangeMap[i, j] != byte.MaxValue)
                        getAttackRangeMap(attackRangeMap, i, j);
                }
            }
        }

        void getMoveMap(byte[,] moveMap, byte index)
        {
            getMoveMap(moveMap, this.humanUnitCellY[index], this.humanUnitCellX[index], this.humanGeneralMoveBonus[index], 0, this.humanGeneralId_inWar[index], (byte)1, false);
        }

        public bool getMoveMap(byte[,] moveMap, int curCellX, int curCellY, int movesLeft, int ignoreDir, short unitType, byte unitSide, bool returnWhenMovable)
        {
            // 更新当前位置的移动步数
            if (movesLeft > moveMap[curCellX, curCellY])
            {
                moveMap[curCellX, curCellY] = (byte)movesLeft;
            }
            else
            {
                return false;
            }

            // 检查各个方向
            if (ignoreDir != 1)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY - 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX, curCellY - 1, newMovesLeft, 2, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }
            if (ignoreDir != 2)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY + 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX, curCellY + 1, newMovesLeft, 1, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }
            if (ignoreDir != 4)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX - 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX - 1, curCellY, newMovesLeft, 8, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }
            if (ignoreDir != 8)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX + 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap(moveMap, curCellX + 1, curCellY, newMovesLeft, 4, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            return false;
        }

        public int movesNeededForCell(int cellX, int cellY, short genId)
        {
            if (cellX >= 0 && cellY >= 0 && cellX < 19 && cellY < 32)
            {
                byte terrain = this.bigWar_coordinate[cellX, cellY];
                if (terrain < 0)
                    return 1000;
                return getCellNeedMoves(terrain, genId);
            }
            return 10000;
        }

        void plan(byte aiIndex, byte humanIndex)
        {
            byte plan = getplan(aiIndex, humanIndex);
            if (plan < 0)
                return;

            this.aiGeneralMoveBonus[aiIndex] = (byte)(this.aiGeneralMoveBonus[aiIndex] - planNeedMoves(plan, this.humanGeneralId_inWar[humanIndex]));
            byte su = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], plan);
            if (MathUtils.getRandomInt(70) < su)
            {
                int exp = setplanResult(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], plan, humanIndex, false);
                General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);
                aiGeneral.addexperience(exp / 3);
                aiGeneral.addIQExp((byte)(exp / 100));
            }
            else
            {
                if (getSkill_1(this.humanGeneralId_inWar[humanIndex], 6))
                    if (curCellCanPlan(this.humanGeneralId_inWar[humanIndex], humanIndex, aiIndex, plan, true))
                    {
                        byte su2 = planSuccessRate(this.humanGeneralId_inWar[humanIndex], this.aiGeneralId_inWar[aiIndex], plan);
                        if (MathUtils.getRandomInt(100) < su2)
                        {
                            int exp = setplanResult(this.humanGeneralId_inWar[humanIndex], this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, true);
                            General general = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);
                            general.addexperience(exp / 3);
                            general.addIQExp((byte)(exp / 100));
                        }
                    }
                this.b_java_lang_String_fld = "计策失败！";
            }
            //this.gamecanvas.r_byte_fld = 100;
            void_B();
            this.j_byte_fld = 0;
        }

        byte getplan(byte aiIndex, byte humanIndex)
        {
            // 获取 AI 将领信息
            General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);

            // 获取玩家将领信息
            General userGeneral = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);

            // 初始化计划数组
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // 遍历所有可能的计划
            for (byte planIndex = 0; planIndex < aiGeneral.getGeneralPlanNum(); planIndex++)
            {
                // 判断是否可以执行该计划
                if (planNeedMoves(planIndex, this.aiGeneralId_inWar[aiIndex]) <= this.aiGeneralMoveBonus[aiIndex] && curCellCanPlan(this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, planIndex, false))
                {
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (userGeneral.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 1:
                            if (userGeneral.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 30 && this.humanUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.humanGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 10:
                            if (this.humanUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                    }
                }
            }

            // 如果有可用的计划，则选择成功率最高的一个
            if (byte1 > 0)
            {
                byte su = 0;
                byte index = 0;
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], abyte0[i]);
                    if (tsc > su)
                    {
                        su = tsc;
                        index = abyte0[i];
                    }
                }
                return index;
            }

            // 如果没有可用的计划，则返回 0
            return 0;
        }

        void retreat(byte aiIndex)
        {
            // 设置游戏界面状态
            if (aiIndex == 0)
            {
                //this.gamecanvas.r_byte_fld = 5;
            }
            else
            {
                //this.gamecanvas.r_byte_fld = 3;
                void_B();
                this.j_byte_fld = 0;
                generalRetreat(this.aiGeneralId_inWar[aiIndex], getCanRetreatCityId(this.aiKingId));
            }

            // 模拟延迟
            System.Threading.Thread.Sleep(500);

            // 重新绘制游戏界面
            //this.gamecanvas.repaint();
        }

        bool allretreat()
        {
            // 检查是否满足撤退条件
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;

            // 计算双方士兵总数
            int i1 = GetTotalGeneralFightValInWar(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped);
            int j1 = GetTotalGeneralFightValInWar(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped);

            // 获取主将信息
            General aiMainGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[0]);

            // 如果主将不存在，则允许撤退
            if (aiMainGeneral == null)
                return true;

            // 计算额外士兵数量
            int k1 = aiMainGeneral.lead * aiMainGeneral.generalSoldier * 3 / 2;
            j1 += k1;

            // 判断是否满足撤退条件
            if (j1 * 3 < i1 * 2 && aiMainGeneral.generalSoldier <= 250)
                return true;

            // 最终判断是否撤退
            return !(aiMainGeneral.generalSoldier >= 100 && (aiMainGeneral.generalSoldier >= 400 || aiMainGeneral.getCurPhysical() >= 15));
        }

        byte[] randomArray(byte[] array)
        {
            // 创建随机数生成器
            System.Random random = new System.Random();

            // 对数组进行随机化处理
            for (int i = 0; i < array.Length; i++)
            {
                int p = random.Next(array.Length);
                byte tmp = array[i];
                array[i] = array[p];
                array[p] = tmp;
            }

            // 返回随机化后的数组
            return array;
        }

        int[] getAroundMovesHeight(byte aiIndex)
        {
            // 初始化高度数组
            int[] height = new int[4];

            // 上方格子的高度
            if (this.aiUnitCellY[aiIndex] - 1 >= 0)
            {
                height[0] = this.buildingMoveMap[this.aiUnitCellY[aiIndex] - 1,this.aiUnitCellX[aiIndex]];
            }
            else
            {
                height[0] = 0;
            }

            // 下方格子的高度
            if (this.aiUnitCellY[aiIndex] + 1 < 18)
            {
                height[1] = this.buildingMoveMap[this.aiUnitCellY[aiIndex] + 1,this.aiUnitCellX[aiIndex]];
            }
            else
            {
                height[1] = 0;
            }

            // 左侧格子的高度
            if (this.aiUnitCellX[aiIndex] - 1 >= 0)
            {
                height[2] = this.buildingMoveMap[this.aiUnitCellY[aiIndex],this.aiUnitCellX[aiIndex] - 1];
            }
            else
            {
                height[2] = 0;
            }

            // 右侧格子的高度
            if (this.aiUnitCellX[aiIndex] + 1 < 31)
            {
                height[3] = this.buildingMoveMap[this.aiUnitCellY[aiIndex],this.aiUnitCellX[aiIndex] + 1];
            }
            else
            {
                height[3] = 0;
            }

            // 返回周围格子的高度数组
            return height;
        }

        bool isRetreat(short generalId)
        {
            // 检查是否满足撤退条件
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;

            // 获取将领信息
            General general = GeneralListCache.GetGeneral(generalId);

            // 如果将领不存在，则不允许撤退
            if (general == null)
                return false;

            // 检查士兵数量是否少于 100
            return (general.generalSoldier < 100);
        }

        // 人类玩家攻击AI_test3
        void humanAttackAI_test3()
        {
            // 用来存储 AI 武将的撤退状态
            byte[] abyte0 = new byte[this.aiGeneralNum_inWar];
            // 用来存储 AI 武将的其他状态
            byte[] abyte2 = new byte[this.aiGeneralNum_inWar];

            // 初始化所有AI武将的状态
            for (byte intdex = 0; intdex < this.aiGeneralNum_inWar; intdex++)
            {
                // 检查所有 AI 是否撤退
                if (allretreat())
                {
                    abyte0[intdex] = 3; // 3 表示撤退
                }
                else
                {
                    abyte0[intdex] = 0; // 0 表示正常状态
                }
                abyte2[intdex] = 0; // 重置状态
            }

            // 如果第一个 AI 武将已经撤退
            if (abyte0[0] == 3)
            {
                //this.gamecanvas.r_byte_fld = 5; // 设置撤退标志
                void_B(); // 执行撤退逻辑
                return;
            }

            // 处理 AI 武将的移动和行动
            for (byte aiIndex = 1; aiIndex < this.aiGeneralNum_inWar; aiIndex++)
            {
                // 处理未被困的 AI 武将
                if (this.aiUnitTrapped[aiIndex] <= 0 || this.aiUnitTrapped[aiIndex] >= 4)
                {
                    short generalId = this.aiGeneralId_inWar[aiIndex]; // 获取 AI 武将 ID

                    // 如果 AI 武将处于撤退状态
                    if (isRetreat(generalId))
                    {
                        retreat(aiIndex); // 执行撤退操作
                        this.aiGeneralFinshMove[aiIndex] = 1; // 标记武将已经行动完成

                        // 线程睡眠，模拟执行的时间延迟
                        try
                        {
                            Thread.Sleep(200); // 200毫秒延迟
                        }
                        catch (Exception e) { }
                    }
                }
            }

            // 线程睡眠，模拟延迟
            try
            {
                Thread.Sleep(200); // 200毫秒延迟
            }
            catch (Exception e) { }

            // 重新绘制游戏画面
            //this.gamecanvas.repaint();

            // 对 AI 单位的移动顺序进行排序
            byte[] moveOrder = sortAIUnit();

            // 遍历每个移动顺序的 AI 单位
            for (byte index = 0; index < moveOrder.Length; index++)
            {
                byte b = moveOrder[index]; // 获取当前 AI 单位索引
                this.curAIindex = b; // 记录当前 AI 单位索引

                // 如果 AI 单位没有被困住且尚未行动
                if (this.aiUnitTrapped[b] <= 0 && this.aiGeneralFinshMove[b] != 1)
                {
                    // 特殊处理第一个 AI 单位
                    if (b == 0 && !this.AIAttackHM)
                    {
                        // 循环处理 AI 的行动直到完成
                        while (this.aiGeneralFinshMove[b] == 0)
                        {
                            byte planHunmanIndex = 0; // 计划攻击的人类武将索引
                            byte maxsu = 0; // 最大成功率

                            // 遍历所有人类武将
                            for (byte humanIndex = 0; humanIndex < this.humanGeneralNum_inWar; humanIndex++)
                            {
                                // 如果人类武将未被困
                                if (this.humanUnitTrapped[humanIndex] <= 0 || this.humanUnitTrapped[humanIndex] >= 4)
                                {
                                    // 检查 AI 是否在攻击范围内
                                    if (isInRange(this.aiUnitCellX[b], this.aiUnitCellY[b], this.humanUnitCellX[humanIndex], this.humanUnitCellY[humanIndex], 5))
                                    {
                                        // 获取计划的成功率
                                        byte willPlan = getplan(b, humanIndex);
                                        if (willPlan >= 0)
                                        {
                                            byte su = planSuccessRate(this.aiGeneralId_inWar[b], this.humanGeneralId_inWar[humanIndex], willPlan);

                                            // 检查是否成功率大于当前最大值
                                            if ((su > 15 || b == 0) && su > maxsu)
                                            {
                                                maxsu = su; // 更新最大成功率
                                                planHunmanIndex = humanIndex; // 记录计划攻击的人类武将索引
                                            }
                                        }
                                    }
                                }
                            }

                            // 如果找到计划攻击的对象，执行计划
                            if (planHunmanIndex > 0)
                            {
                                plan(b, planHunmanIndex);
                                try
                                {
                                    Thread.Sleep(200); // 延迟模拟
                                }
                                catch (Exception e) {}
                                continue;
                            }

                            // 如果没有找到计划，标记 AI 行动完成
                            this.aiGeneralFinshMove[b] = 1;
                        }
                    }
                    // 处理其他已移动过的 AI 单位
                    else if (this.aiGeneralHaveMove[b] == 1)
                    {
                        // 检查并处理 AI 的移动和计划
                        while (this.aiGeneralFinshMove[b] == 0)
                        {
                            byte planHunmanIndex = 0;
                            byte maxsu = 0;

                            // 遍历所有人类武将，寻找可行的计划
                            for (byte humanIndex = 0; humanIndex < this.humanGeneralNum_inWar; humanIndex++)
                            {
                                if (this.humanUnitTrapped[humanIndex] <= 0 || this.humanUnitTrapped[humanIndex] >= 4)
                                {
                                    if (isInRange(this.aiUnitCellX[b], this.aiUnitCellY[b], this.humanUnitCellX[humanIndex], this.humanUnitCellY[humanIndex], 5))
                                    {
                                        byte willPlan = getUsePlan(b, humanIndex);
                                        if (willPlan >= 0)
                                        {
                                            byte su = planSuccessRate(this.aiGeneralId_inWar[b], this.humanGeneralId_inWar[humanIndex], willPlan);
                                            if (su > 35 && su > maxsu)
                                            {
                                                maxsu = su;
                                                planHunmanIndex = humanIndex;
                                            }
                                        }
                                    }
                                }
                            }

                            // 执行计划
                            if (planHunmanIndex > 0)
                            {
                                plan(b, planHunmanIndex);
                                try
                                {
                                    Thread.Sleep(200); // 延迟模拟
                                }
                                catch (Exception e) { }
                                continue;
                            }

                            // 如果未找到合适计划，完成行动
                            this.aiGeneralFinshMove[b] = 1;
                        }
                    }
                }
            }
        }


        byte[] sortAIUnit()
        {
            // 初始化数组
            byte[] array = new byte[this.aiGeneralNum_inWar];
            short[] moveNum = new short[this.aiGeneralNum_inWar];

            // 遍历每个 AI 将领
            for (byte aiIndex = 0; aiIndex < this.aiGeneralNum_inWar; aiIndex = (byte)(aiIndex + 1))
            {
                // 初始化移动范围和目标移动地图
                byte[,] moveRange = new byte[19, 32];
                byte[,] tarMoveMap = new byte[19, 32];

                // 获取目标移动地图
                getMoveMap3(tarMoveMap, this.humanUnitCellY[0], this.humanUnitCellX[0], 90, 0, this.aiGeneralId_inWar[aiIndex], (byte)1, false);

                // 根据条件获取移动范围
                if (aiIndex == 0 && this.day <= 3)
                {
                    getMoveMap2(moveRange, this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex], this.aiGeneralMoveBonus[aiIndex] - 10, 0, this.aiGeneralId_inWar[aiIndex], false);
                }
                else
                {
                    getMoveMap2(moveRange, this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex], this.aiGeneralMoveBonus[aiIndex], 0, this.aiGeneralId_inWar[aiIndex], false);
                }

                // 计算移动数值
                for (int i = 0; i < 19; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (moveRange[i, j] > 0)
                        {
                            if (aiIndex == 0 && tarMoveMap[i, j] >= 86)
                            {
                                moveNum[aiIndex] = (short)(moveNum[aiIndex] + tarMoveMap[i, j] * 2 / 3);
                            }
                            else
                            {
                                moveNum[aiIndex] = (short)(moveNum[aiIndex] + tarMoveMap[i, j]);
                            }
                        }
                    }
                }

                // 特殊处理第一个 AI 将领
                if (aiIndex == 0)
                    moveNum[aiIndex] = 0;
            }

            // 调用通用工具类进行排序
            array = CommonUtils.Xhpx(moveNum);

            // 返回排序后的数组
            return array;
        }

        public void moveUnit(byte aiIndex, int x, int y)
        {
            // 模拟延迟
            System.Threading.Thread.Sleep(50);

            // 计算需要的移动次数
            byte needMoves = (byte)getCellNeedMoves(this.bigWar_coordinate[y, x], this.aiGeneralId_inWar[aiIndex]);

            // 更新移动剩余次数
            this.aiGeneralMoveBonus[aiIndex] = (byte)(this.aiGeneralMoveBonus[aiIndex] - needMoves);

            // 更新当前坐标的状态
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] & 0x3F);
            this.aiUnitCellX[aiIndex] = (byte)x;
            this.aiUnitCellY[aiIndex] = (byte)y;
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] | 0x80);

            // 刷新界面
            //this.gamecanvas.repaint();

            // 再次模拟延迟
            System.Threading.Thread.Sleep(50);

            // 处理特殊事件
            if ((this.bigWar_coordinate[y, x] & 0x20) != 0)
            {
                this.aiUnitTrapped[aiIndex] = 17;
                this.b_java_lang_String_fld = "中计谋奇门遁甲";
                //this.gamecanvas.r_byte_fld = 100;
                void_B();
                this.j_byte_fld = 0;
                this.aiGeneralFinshMove[aiIndex] = 1;
            }
        }

        public System.Collections.Generic.List<short[]> getPathToCell(int curCellX, int curCellY, int destCellX, int destCellY)
        {
            // 初始化路径列表
            System.Collections.Generic.List<short[]> returnPath = null;

            // 当前目标坐标
            short[] thisCell = { (short)destCellX, (short)destCellY };

            // 如果当前位置就是目标位置
            if (curCellX == destCellX && curCellY == destCellY)
            {
                returnPath = new System.Collections.Generic.List<short[]>();
                returnPath.Add(thisCell);
                return returnPath;
            }

            // 初始化方向上的值
            int upVal = 0, downVal = 0, leftVal = 0, rightVal = 0;

            // 计算上方的值
            if (destCellY > 0)
                upVal = this.curGeneralMoveMap[destCellY - 1, destCellX];

            // 计算下方的值
            if (destCellY < this.rows - 1)
                downVal = this.curGeneralMoveMap[destCellY + 1, destCellX];

            // 计算左侧的值
            if (destCellX > 0)
                leftVal = this.curGeneralMoveMap[destCellY, destCellX - 1];

            // 计算右侧的值
            if (destCellX < this.cols - 1)
                rightVal = this.curGeneralMoveMap[destCellY, destCellX + 1];

            // 找出最大值的方向
            int maxVal = System.Math.Max(System.Math.Max(upVal, downVal), System.Math.Max(leftVal, rightVal));

            // 根据最大值的方向递归计算路径
            if (maxVal == upVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX, destCellY - 1);
            }
            else if (maxVal == downVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX, destCellY + 1);
            }
            else if (maxVal == leftVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX - 1, destCellY);
            }
            else if (maxVal == rightVal)
            {
                returnPath = getPathToCell(curCellX, curCellY, destCellX + 1, destCellY);
            }

            // 添加当前坐标到路径列表
            returnPath.Add(thisCell);

            // 返回路径列表
            return returnPath;
        }

        public bool getMoveMap2(byte[,] moveMap, int curCellX, int curCellY, int movesLeft, int ignoreDir, short unitType, bool returnWhenMovable)
        {
            // 更新移动地图中的移动次数
            if (movesLeft > moveMap[curCellX, curCellY] - 1)
            {
                moveMap[curCellX, curCellY] = (byte)(movesLeft + 1);
            }
            else
            {
                return false;
            }

            // 向上探索
            if (ignoreDir != 1)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY - 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX, curCellY - 1, newMovesLeft, 2, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // 向下探索
            if (ignoreDir != 2)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX, curCellY + 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX, curCellY + 1, newMovesLeft, 1, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // 向左探索
            if (ignoreDir != 4)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX - 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX - 1, curCellY, newMovesLeft, 8, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // 向右探索
            if (ignoreDir != 8)
            {
                int newMovesLeft = movesLeft - movesNeededForCell(curCellX + 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap2(moveMap, curCellX + 1, curCellY, newMovesLeft, 4, unitType, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            return false;
        }

        byte getAIThinkPlan(byte aiIndex, byte humanIndex, byte moves, byte willX, byte willY)
        {
            // 获取 AI 将领信息
            General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);

            // 获取玩家将领信息
            General userGeneral = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);

            // 初始化计划数量
            byte planNum = aiGeneral.getGeneralPlanNum();

            // 初始化计划数组
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // 保存原始坐标
            byte OriginalX = this.aiUnitCellX[aiIndex];
            byte OriginalY = this.aiUnitCellY[aiIndex];

            // 更新坐标状态
            this.aiUnitCellX[aiIndex] = willX;
            this.aiUnitCellY[aiIndex] = willY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] & 0x3F);
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] | 0x80);

            // 遍历所有计划
            for (byte planIndex = 0; planIndex < planNum; planIndex = (byte)(planIndex + 1))
            {
                // 检查是否满足移动条件
                if (planNeedMoves(planIndex, this.aiGeneralId_inWar[aiIndex]) <= moves && curCellCanPlan(this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, planIndex, false))
                {
                    // 根据不同的计划条件选择合适的计划
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (userGeneral.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 1:
                            if (userGeneral.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 30 && this.humanUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.humanGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 10:
                            if (this.humanUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                    }
                }
            }

            // 恢复原始坐标状态
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] & 0x3F);
            this.aiUnitCellX[aiIndex] = OriginalX;
            this.aiUnitCellY[aiIndex] = OriginalY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] | 0x80);

            // 如果有可用的计划
            if (byte1 > 0)
            {
                byte minsu = 35;
                byte num = 0;
                byte[] wellplan = new byte[byte1];
                for (int i = 0; i < wellplan.Length; i++)
                    wellplan[i] = 0;

                // 筛选成功率较高的计划
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], abyte0[i]);
                    if (tsc > minsu)
                    {
                        wellplan[num] = abyte0[i];
                        num = (byte)(num + 1);
                    }
                }

                byte tsh = 0;
                // 评估计划价值
                for (int j = 0; j < wellplan.Length; j++)
                {
                    byte sh = 0;
                    switch (wellplan[j])
                    {
                        case 0:
                        case 3:
                        case 4:
                            sh = 3;
                            break;
                        case 1:
                            sh = 1;
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 1400)
                            {
                                sh = 4;
                                break;
                            }
                            sh = 2;
                            break;
                        case 6:
                        case 7:
                        case 9:
                            sh = 6;
                            break;
                        case 5:
                        case 8:
                            sh = 10;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            sh = 8;
                            break;
                    }
                    if (sh > tsh)
                        tsh = sh;
                }

                return tsh;
            }

            // 如果没有可用的计划
            return 0;
        }

        byte getHMThinkPlan(byte humanIndex, byte aiIndex, byte moves, byte willX, byte willY)
        {
            // 获取玩家将领ID
            short humanGeneralId = this.humanGeneralId_inWar[humanIndex];

            // 获取玩家将领信息
            General general = GeneralListCache.GetGeneral(humanGeneralId);

            // 初始化计划数量
            byte planNum = general.getGeneralPlanNum();

            // 初始化计划数组
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // 保存原始坐标
            byte OriginalX = this.aiUnitCellX[aiIndex];
            byte OriginalY = this.aiUnitCellY[aiIndex];

            // 更新坐标状态
            this.aiUnitCellX[aiIndex] = willX;
            this.aiUnitCellY[aiIndex] = willY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] & 0x3F);
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] | 0x80);

            // 遍历所有计划
            for (byte planIndex = 0; planIndex < planNum; planIndex = (byte)(planIndex + 1))
            {
                // 检查是否满足移动条件
                if (planNeedMoves(planIndex, humanGeneralId) <= moves && curCellCanPlan(humanGeneralId, humanIndex, aiIndex, planIndex, true))
                {
                    // 根据不同的计划条件选择合适的计划
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (general.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 1:
                            if (general.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 2:
                            if (general.generalSoldier > 1 && this.aiUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.aiGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                        case 10:
                            if (this.aiUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1 = (byte)(byte1 + 1);
                            }
                            break;
                    }
                }
            }

            // 恢复原始坐标状态
            this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[aiIndex], this.aiUnitCellX[aiIndex]] & 0x3F);
            this.aiUnitCellX[aiIndex] = OriginalX;
            this.aiUnitCellY[aiIndex] = OriginalY;
            this.bigWar_coordinate[OriginalY, OriginalX] = (byte)(this.bigWar_coordinate[OriginalY, OriginalX] | 0x80);

            // 如果有可用的计划
            if (byte1 > 0)
            {
                byte su = 40;
                byte index = 0;
                byte[] planwell = new byte[byte1];
                for (int i = 0; i < planwell.Length; i++)
                    planwell[i] = 0;

                // 筛选成功率较高的计划
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(humanGeneralId, this.aiGeneralId_inWar[aiIndex], abyte0[i]);
                    if (tsc > su)
                    {
                        planwell[index] = abyte0[i];
                        index = (byte)(index + 1);
                    }
                }

                byte tsh = 0;
                // 评估计划价值
                for (int j = 0; j < planwell.Length; j++)
                {
                    byte sh = 0;
                    switch (planwell[j])
                    {
                        case 0:
                        case 1:
                        case 4:
                            sh = 1;
                            break;
                        case 2:
                        case 3:
                            sh = 3;
                            break;
                        case 6:
                        case 7:
                        case 9:
                            sh = 4;
                            break;
                        case 5:
                        case 8:
                            sh = 10;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            sh = 7;
                            break;
                    }
                    if (sh > tsh)
                        tsh = sh;
                }

                return tsh;
            }

            // 如果没有可用的计划
            return 0;
        }

        public bool getMoveMap3(byte[,] moveMap, int curCellX, int curCellY, int movesLeft, int ignoreDir, short unitType, byte unitSide, bool returnWhenMovable)
        {
            // 如果剩余移动次数大于当前格子的移动次数，则更新格子的移动次数
            if (movesLeft > moveMap[curCellX, curCellY])
            {
                moveMap[curCellX, curCellY] = (byte)movesLeft;
            }
            else
            {
                return false;
            }

            // 如果忽略方向不是向北，则尝试向北移动
            if (ignoreDir != 1)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX, curCellY - 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX, curCellY - 1, newMovesLeft, 2, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // 如果忽略方向不是向东，则尝试向东移动
            if (ignoreDir != 2)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX, curCellY + 1, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX, curCellY + 1, newMovesLeft, 1, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // 如果忽略方向不是向西，则尝试向西移动
            if (ignoreDir != 4)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX - 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX - 1, curCellY, newMovesLeft, 8, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            // 如果忽略方向不是向南，则尝试向南移动
            if (ignoreDir != 8)
            {
                int newMovesLeft = movesLeft - movesNeededForCell3(curCellX + 1, curCellY, unitType);
                if (newMovesLeft >= 0 && getMoveMap3(moveMap, curCellX + 1, curCellY, newMovesLeft, 4, unitType, unitSide, returnWhenMovable) && returnWhenMovable)
                    return true;
            }

            return false;
        }

        public int movesNeededForCell3(int cellX, int cellY, short genId)
        {
            // 检查坐标是否有效
            if (cellX >= 0 && cellY >= 0 && cellX < 19 && cellY < 32)
            {
                // 获取地形类型
                byte terrain = (byte)(this.bigWar_coordinate[cellX, cellY] & 0x1F);
                byte movesNeed = 0;

                // 根据地形类型计算所需的移动次数
                switch (terrain)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 5:
                    case 6:
                    case 7:
                        movesNeed = 2;
                        break;
                    case 4:
                        General general = GeneralListCache.GetGeneral(genId);
                        if (general == null)
                            return 10000;
                        switch (general.army[0])
                        {
                            case 0:
                            case 1:
                                movesNeed = 3;
                                break;
                            case 2:
                            case 3:
                                movesNeed = 2;
                                break;
                        }
                        break;
                    case 12:
                        general = GeneralListCache.GetGeneral(genId);
                        if (general == null)
                            return 10000;
                        switch (general.army[1])
                        {
                            case 0:
                                movesNeed = 6;
                                break;
                            case 1:
                                movesNeed = 5;
                                break;
                            case 2:
                                movesNeed = 4;
                                break;
                            case 3:
                                movesNeed = 3;
                                break;
                        }
                        if (getSkill_3(genId, 5))
                            movesNeed = (byte)(movesNeed - 1);
                        break;
                    case 10:
                        movesNeed = 5;
                        if (getSkill_3(genId, 5))
                            movesNeed = (byte)(movesNeed - 1);
                        break;
                    case 11:
                        movesNeed = 6;
                        if (getSkill_3(genId, 5))
                            movesNeed = (byte)(movesNeed - 1);
                        break;
                    case 9:
                        general = GeneralListCache.GetGeneral(genId);
                        if (general == null)
                            return 10000;
                        switch (general.army[2])
                        {
                            case 0:
                                movesNeed = 6;
                                break;
                            case 1:
                                movesNeed = 5;
                                break;
                            case 2:
                                movesNeed = 4;
                                break;
                            case 3:
                                movesNeed = 3;
                                break;
                        }
                        break;
                    case 8:
                        movesNeed = 6;
                        break;
                    case 13:
                        movesNeed = 120;
                        break;
                    default:
                        movesNeed = 120;
                        break;
                }

                return movesNeed;
            }

            // 如果坐标无效，则返回一个大值
            return 10000;
        }

        public byte getUsePlan(byte aiIndex, byte humanIndex)
        {
            // 获取 AI 将领信息
            General aiGeneral = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[aiIndex]);
            // 获取 AI 将领可用的计策数量
            byte planNum = aiGeneral.getGeneralPlanNum();
            // 获取玩家将领信息
            General userGeneral = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[humanIndex]);
            // 初始化计策数组
            byte[] abyte0 = new byte[16];
            byte byte1 = 0;

            // 遍历所有可用的计策
            for (byte planIndex = 0; planIndex < planNum; planIndex++)
            {
                // 判断当前计策是否可行
                if (planNeedMoves(planIndex, this.aiGeneralId_inWar[aiIndex]) <= this.aiGeneralMoveBonus[aiIndex] &&
                    curCellCanPlan(this.aiGeneralId_inWar[aiIndex], aiIndex, humanIndex, planIndex, false))
                {
                    // 根据不同的计策条件选择合适的计策
                    switch (planIndex)
                    {
                        case 0:
                        case 3:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            if (userGeneral.generalSoldier > 30)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 1:
                            if (userGeneral.getCurPhysical() > 1)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 30 && this.humanUnitTrapped[humanIndex] == 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 5:
                        case 8:
                            if (this.humanGrain_inWar > 0)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                        case 10:
                            if (this.humanUnitTrapped[humanIndex] < 6)
                            {
                                abyte0[byte1] = planIndex;
                                byte1++;
                            }
                            break;
                    }
                }
            }

            // 如果找到了至少一个可用的计策
            if (byte1 > 0)
            {
                byte minsu = 35;
                byte num = 0;
                byte[] wellplan = new byte[byte1];

                // 初始化最佳计策数组
                for (int i = 0; i < wellplan.Length; i++)
                    wellplan[i] = 0;

                // 遍历所有可行的计策，找到成功率高于阈值的计策
                for (int i = 0; i < byte1; i++)
                {
                    byte tsc = planSuccessRate(this.aiGeneralId_inWar[aiIndex], this.humanGeneralId_inWar[humanIndex], abyte0[i]);
                    if (tsc > minsu)
                    {
                        wellplan[num] = abyte0[i];
                        num++;
                    }
                }

                // 初始化最佳计策索引
                byte index = 0;
                byte tsh = 0;

                // 遍历所有成功率较高的计策，选择最佳计策
                for (int j = 0; j < wellplan.Length; j++)
                {
                    byte sh = 0;
                    switch (wellplan[j])
                    {
                        case 0:
                        case 3:
                        case 4:
                            sh = 3;
                            break;
                        case 1:
                            sh = 1;
                            break;
                        case 2:
                            if (userGeneral.generalSoldier > 1400)
                            {
                                sh = 4;
                            }
                            else
                            {
                                sh = 2;
                            }
                            break;
                        case 6:
                        case 7:
                        case 9:
                            sh = 6;
                            break;
                        case 5:
                        case 8:
                            sh = 10;
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            sh = 8;
                            break;
                    }
                    if (sh > tsh)
                    {
                        tsh = sh;
                        index = wellplan[j];
                    }
                }

                // 返回最佳计策索引
                return index;
            }

            // 如果没有找到任何可用的计策，则返回 0
            return 0;
        }

        // 方法: byte_s1b1b_a
        public byte byte_s1b1b_a(short[] aword0, byte[] abyte0, byte byte0)
        {
            int i1 = 0;
            for (int j1 = 1; j1 < 64; j1++)
            {
                if ((aword0[j1] & 0x100) == 0 && aword0[j1] < aword0[i1])
                    i1 = j1;
            }
            return (byte)i1;
        }

        // 方法: boolean_b_b
        public bool boolean_b_b(byte byte0)
        {
            if ((this.bigWar_coordinate[this.aiUnitCellY[byte0],this.aiUnitCellX[byte0]] & 0xF) == 8)
            {
                this.bxct = true;
                //this.gamecanvas.r_byte_fld = 21;
                void_B();
                return true;
            }
            return false;
        }

        // 方法: getSequence
        public static int[] getSequence(int no)
        {
            int[] sequence = new int[no];
            for (int i = 0; i < no; i++)
                sequence[i] = i;
            System.Random random = new System.Random();
            for (int j = 0; j < no; j++)
            {
                int p = random.Next(no);
                int tmp = sequence[j];
                sequence[j] = sequence[p];
                sequence[p] = tmp;
            }
            random = null;
            return sequence;
        }

        // 方法: setAIMoveBonus
        public void setAIMoveBonus()
        {
            this.aiGeneralFinshMove = new byte[this.aiGeneralNum_inWar];
            this.aiGeneralMoveBonus = new byte[this.aiGeneralNum_inWar];
            this.aiGeneralHaveMove = new byte[this.aiGeneralNum_inWar];
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
            {
                this.aiGeneralFinshMove[i] = 0;
                this.aiGeneralHaveMove[i] = 0;
                General general = GeneralListCache.GetGeneral(this.aiGeneralId_inWar[i]);
                if (general != null)
                {
                    int bl = general.generalSoldier / 300;
                    switch (bl)
                    {
                        case 9:
                        case 10:
                            this.aiGeneralMoveBonus[i] = 20;
                            break;
                        case 7:
                        case 8:
                            this.aiGeneralMoveBonus[i] = 18;
                            break;
                        case 6:
                            this.aiGeneralMoveBonus[i] = 16;
                            break;
                        case 5:
                            this.aiGeneralMoveBonus[i] = 15;
                            break;
                        case 3:
                        case 4:
                            this.aiGeneralMoveBonus[i] = 14;
                            break;
                        case 2:
                            this.aiGeneralMoveBonus[i] = 12;
                            break;
                        case 0:
                        case 1:
                            this.aiGeneralMoveBonus[i] = 10;
                            break;
                    }
                }
            }
        }

        // 方法: setHunmanMoveBonus
        public void setHunmanMoveBonus()
        {
            this.humanGeneralFinshMove = new byte[this.humanGeneralNum_inWar];
            this.humanGeneralMoveBonus = new byte[this.humanGeneralNum_inWar];
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
            {
                this.humanGeneralFinshMove[i] = 0;
                General general = GeneralListCache.GetGeneral(this.humanGeneralId_inWar[i]);
                if (general != null)
                {
                    int bl = general.generalSoldier / 300;
                    switch (bl)
                    {
                        case 9:
                        case 10:
                            this.humanGeneralMoveBonus[i] = 20;
                            break;
                        case 7:
                        case 8:
                            this.humanGeneralMoveBonus[i] = 18;
                            break;
                        case 6:
                            this.humanGeneralMoveBonus[i] = 16;
                            break;
                        case 5:
                            this.humanGeneralMoveBonus[i] = 15;
                            break;
                        case 4:
                            this.humanGeneralMoveBonus[i] = 14;
                            break;
                        case 3:
                            this.humanGeneralMoveBonus[i] = 12;
                            break;
                        case 2:
                            this.humanGeneralMoveBonus[i] = 10;
                            break;
                        case 1:
                            this.humanGeneralMoveBonus[i] = 8;
                            break;
                        case 0:
                            this.humanGeneralMoveBonus[i] = 7;
                            break;
                    }
                }
            }
        }

        // 方法: execThreaten
        private void execThreaten(short[] generalIdArray, byte generalNum, byte[] unitTrapped, short[] otherGeneralIdArray, byte otherGeneralNum, byte[] otherUnitTrapped)
        {
            for (int i = 0; i < generalNum; i++)
            {
                if (unitTrapped[i] <= 0 || unitTrapped[i] >= 4)
                {
                    short generalId = generalIdArray[i];
                    if (getSkill_5(generalId, 2))
                    {
                        General general = GeneralListCache.GetGeneral(generalId);
                        if (general != null && general.generalSoldier >= 300)
                            for (int j = 1; j < otherGeneralNum; j++)
                            {
                                int hurt = general.generalSoldier / 30;
                                if (otherUnitTrapped[j] <= 0 || otherUnitTrapped[j] >= 4)
                                {
                                    short otherGeneralId = otherGeneralIdArray[j];
                                    General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                                    if (otherGeneral != null && otherGeneral.generalSoldier >= 600 && general.force >= otherGeneral.force && MathUtils.getRandomInt(100) <= 50)
                                    {
                                        hurt += MathUtils.getRandomInt(general.force);
                                        otherGeneral.generalSoldier = (short)(otherGeneral.generalSoldier - hurt);
                                        System.Console.WriteLine(String.Format("{0}对{1}发动恐吓，减少士兵{2}", general.generalName, otherGeneral.generalName, hurt));
                                        general.addexperience((int)(hurt * 1.2D));
                                    }
                                }
                            }
                    }
                }
            }
        }

        // 方法: void_I
        void void_I()
        {
            while (true)
            {
                if (this.j_byte_fld == 0)
                {
                    this.i_boolean_fld = true;
                    this.day = (byte)(this.day + 1);
                    this.g_boolean_fld = true;
                    execThreaten(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped, this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped);
                    execThreaten(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped, this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped);
                    if (this.day > 1)
                        setHunmanMoveBonus();
                    void_B();
                }
                else if (this.j_byte_fld == 2 || this.j_byte_fld == 5 || this.j_byte_fld == 6)
                {
                    this.j_byte_fld = 0;
                    void_B();
                }
                if (this.j_byte_fld == 1)
                {
                    this.j_byte_fld = 0;
                    void_s1bb1_a(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped);
                    setAIMoveBonus();
                    this.g_boolean_fld = false;
                    this.i_boolean_fld = false;
                    this.O_byte_fld = 0;
                }
                else
                {
                    if (this.j_byte_fld == 2 || this.j_byte_fld == 4 || this.j_byte_fld == 5 || this.j_byte_fld == 6)
                        break;
                    if (this.j_byte_fld == 3)
                        this.j_byte_fld = 0;
                }
                humanAttackAI_test3();
                if (this.j_byte_fld == 3)
                    break;
                void_s1bb1_a(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped);
                this.humanGrain_inWar = (short)(this.humanGrain_inWar - (getAllSoldierCountInWar(this.humanGeneralId_inWar, this.humanGeneralNum_inWar, this.humanUnitTrapped) - 1) / 250 + 1);
                if (this.humanGrain_inWar <= 0)
                {
                    this.bxct = true;
                    this.humanGrain_inWar = 0;
                    //this.gamecanvas.r_byte_fld = 7;
                    void_B();
                    break;
                }
                this.aiGrain_inWar = (short)(this.aiGrain_inWar - (getAllSoldierCountInWar(this.aiGeneralId_inWar, this.aiGeneralNum_inWar, this.aiUnitTrapped) - 1) / 250 + 1);
                if (this.aiGrain_inWar <= 0)
                {
                    this.aiGrain_inWar = 0;
                    //this.gamecanvas.r_byte_fld = 6;
                }
                if (this.day == 30)
                {
                    if (!this.AIAttackHM)
                    {
                        //this.gamecanvas.r_byte_fld = 20;
                        this.bxct = true;
                        void_B();
                        break;
                    }
                    //this.gamecanvas.r_byte_fld = 22;
                    //this.gamecanvas.r_byte_fld = 5;
                    void_B();
                }
            }
        }

        // 方法: void_J
        void void_J()
        {
            this.DJ = false;
            this.AIJH = false;
            this.HMJH = false;
            this.moniSd1 = (GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier;
            this.moniSd2 = (GeneralListCache.GetGeneral(this.AIGeneralId)).generalSoldier;
            if (this.moniSd1 == 0)
                this.DJ = true;

            // 检查 AI 将军是否有将军技能
            for (int i = 0; i < this.aiGeneralNum_inWar; i++)
            {
                if (getSkill_3(this.aiGeneralId_inWar[i], 8))
                    if (this.AIGeneralId != this.aiGeneralId_inWar[i] && this.aiUnitTrapped[i] == 0)
                    {
                        int dx = Math.Abs(this.aiUnitCellX[i] - this.aiUnitCellX[this.aibettleIndex]);
                        int dy = Math.Abs(this.aiUnitCellY[i] - this.aiUnitCellY[this.aibettleIndex]);
                        if (dx <= 3 && dy <= 3)
                        {
                            this.AIJH = true;
                            break;
                        }
                    }
            }

            // 检查人类玩家将军是否有将军技能
            for (int i = 0; i < this.humanGeneralNum_inWar; i++)
            {
                if (getSkill_3(this.humanGeneralId_inWar[i], 8) && this.HMGeneralId != this.humanGeneralId_inWar[i] && this.humanUnitTrapped[i] == 0)
                {
                    int dx = Math.Abs(this.humanUnitCellX[i] - this.humanUnitCellX[this.hmbattleIndex]);
                    int dy = Math.Abs(this.humanUnitCellY[i] - this.humanUnitCellY[this.hmbattleIndex]);
                    if (dx <= 3 && dy <= 3)
                    {
                        this.HMJH = true;
                        break;
                    }
                }
            }

            this.j_boolean_fld = false;
            if ((GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier == 0)
            {
                this.humanSmallSoldierNum = 1;
            }
            else
            {
                this.humanSmallSoldierNum = (byte)(((GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier - 1) / 300 + 2);
            }

            if ((GeneralListCache.GetGeneral(this.AIGeneralId)).generalSoldier == 0)
            {
                this.aiSmallSoldierNum = 1;
            }
            else
            {
                this.aiSmallSoldierNum = (byte)(((GeneralListCache.GetGeneral(this.AIGeneralId)).generalSoldier - 1) / 300 + 2);
            }

            // 初始化小地图坐标数组
            for (byte byte0 = 0; byte0 < this.T_byte_fld; byte0 = (byte)(byte0 + 1))
            {
                for (byte byte6 = 0; byte6 < this.U; byte6 = (byte)(byte6 + 1))
                    this.smallWarCoordinate[byte6][byte0] = 0;
            }

            // 初始化 P_byte_array1d_fld 数组
            for (byte byte1 = 0; byte1 < 4; byte1 = (byte)(byte1 + 1))
                this.P_byte_array1d_fld[byte1] = 0;

            // 根据地形设置城堡布局
            if (this.warTerrain == 8)
            {
                if (this.i_boolean_fld)
                {
                    byte[,] aiCastle = new byte[7, 16];
                    string name = "/formation/ac.exp";
                    byte[] formationDat = formationArray(name);
                    aiCastle = getFormationArray(formationDat,aiCastle);
                    for (int celly = 0; celly < 7; celly++)
                    {
                        for (int cellx = 0; cellx < 16; cellx++)
                        {
                            if (aiCastle[celly,cellx] > 1)
                                switch (aiCastle[celly, cellx])
                                {
                                    case 2:
                                        this.smallWarCoordinate[celly][cellx] = 32;
                                        break;
                                    case 3:
                                        this.smallWarCoordinate[celly][cellx] = 16;
                                        break;
                                    case 4:
                                        this.smallWarCoordinate[celly][cellx] = 2;
                                        break;
                                }
                        }
                    }
                }
                else
                {
                    byte[,] hmCastle = new byte[7, 16];
                    string name = "/formation/hc.exp";
                    byte[] formationDat = formationArray(name);
                    hmCastle = getFormationArray(formationDat,hmCastle);
                    for (int celly = 0; celly < 7; celly++)
                    {
                        for (int cellx = 0; cellx < 16; cellx++)
                        {
                            if (hmCastle[celly,cellx] > 1)
                                switch (hmCastle[celly,cellx])
                                {
                                    case 2:
                                        this.smallWarCoordinate[celly][cellx] = 32;
                                        break;
                                    case 3:
                                        this.smallWarCoordinate[celly][cellx] = 16;
                                        break;
                                    case 4:
                                        this.smallWarCoordinate[celly][cellx] = 2;
                                        break;
                                }
                        }
                    }
                    for (byte byte4 = 0; byte4 < 4; byte4 = (byte)(byte4 + 1))
                        this.P_byte_array1d_fld[byte4] = 1;
                }
                this.j_boolean_fld = true;
            }

            void_m();
            this.Z = 0;
            this.aa = 0;
            this.ab = 0;
            this.ac = 0;
            this.ad = 0;
            this.ae = 0;
            this.ag = 0;
            this.ah = 0;
            this.jsbl = 0;
            this.k_boolean_fld = false;

            // 初始化 x_short_array1d_fld 和 y_short_array1d_fld
            for (byte byte5 = 0; byte5 < 4; byte5 = (byte)(byte5 + 1))
            {
                this.x_short_array1d_fld[byte5] = 0;
                this.y_short_array1d_fld[byte5] = 0;
            }

            //this.gamecanvas.s_void_b_a((byte)21);
            //this.gamecanvas.battlefieldSatge = 1;
            //this.gamecanvas.t_boolean_fld = false;
            SetAtk_Def1();
        }

        // 方法: void_K
        void void_K()
        {/*
            if ((GeneralListCache.GetGeneral(this.HMGeneralId)).generalSoldier >= 500)
            {
                //this.gamecanvas.canMoni = true;
                //this.gamecanvas.moniBattle = false;
            }
            else
            {
                //this.gamecanvas.canMoni = false;
                //this.gamecanvas.moniBattle = false;
            }
            //this.gamecanvas.isDrawMoning = false;
            //this.gamecanvas.finishMoni = false;
            //this.gamecanvas.moniBattlePage = false;
            //this.gamecanvas.moniPersent = 0;
            long l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while (true)
            {
                if (//this.gamecanvas.getKeyValue() != 0)
                {
                    //this.gamecanvas.void_g();
                    //this.gamecanvas.setKeyValue((byte)0);
                }
                if (this.j_byte_fld <= 0)
                {
                    long l2 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - l1;
                    long tx = 100L;
                    if (//this.gamecanvas.isDrawMoning)
                        tx = 10L;
                    if (l2 < tx)
                    {
                        try
                        {
                            lock (this)
                            {
                                System.Threading.Thread.Sleep((int)(tx - l2));
                            }
                        }
                        catch (System.Exception exception) { }
                    }
                    //this.gamecanvas.repaint();
                    l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    continue;
                }
                break;
            }*/
        }

        // 方法: boolean_f
        bool boolean_f()
        {
            short word1 = 0;
            if (this.smallSoldierOrder[1][0] == 2)
                return true;
            for (int i1 = 1; i1 < this.humanSmallSoldierNum; i1++)
            {
                if (this.smallSoldier_isSurvive[0][i1])
                    for (int j1 = 1; j1 < this.aiSmallSoldierNum; j1++)
                    {
                        if (this.smallSoldier_isSurvive[1][j1])
                            word1 = (short)(word1 + this.smallSoldierBlood[1][j1]);
                    }
            }
            return (word1 < 100 && (((GeneralListCache.GetGeneral(this.AIGeneralId)).force - (GeneralListCache.GetGeneral(this.HMGeneralId)).force) * 3 / 2 + GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() - GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical() < 0 || GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < 45 || (this.V >= 12 && word1 < 100)));
        }

        // 方法: void_i_a
        void void_i_a(int i1)
        {
            if (boolean_f() && i1 >= 4)
            {
                for (int j1 = 0; j1 < this.aiSmallSoldierNum; j1++)
                    this.smallSoldierOrder[1][j1] = 2;
                return;
            }
            for (int k1 = 0; k1 < this.aiSmallSoldierNum; k1++)
                this.smallSoldierOrder[1][k1] = 1;
        }

        // 方法: void_i_b
        void void_i_b(int i1)
        {
            aiDefSiege(i1);
        }

        // 方法: void_i_c
        void void_i_c(int i1)
        {
            if (boolean_f() && i1 >= 4)
            {
                for (int j1 = 0; j1 < this.aiSmallSoldierNum; j1++)
                    this.smallSoldierOrder[1][j1] = 2;
                return;
            }
            if (i1 >= 7)
            {
                this.smallSoldierOrder[1][0] = 0;
            }
            else
            {
                this.smallSoldierOrder[1][0] = 1;
            }
            for (int k1 = 1; k1 < this.aiSmallSoldierNum; k1++)
                this.smallSoldierOrder[1][k1] = 0;
        }

        // 方法: void_i_d
        void void_i_d(int i1)
        {
            aiSiege(i1);
        }

        // 方法: void_i_e
        void void_i_e(int i1)
        {
            aifield(i1);
        }

        // 方法: void_i_f
        void void_i_f(int i1)
        {
            if (this.j_boolean_fld)
            {
                if (this.i_boolean_fld)
                {
                    void_i_b(i1);
                }
                else
                {
                    void_i_d(i1);
                }
            }
            else
            {
                void_i_e(i1);
            }
        }

        public byte hmSoldierMove(byte index)
        {
            // 取得友军士兵坐标
            byte aix = this.smallSoldierCellX[1][0];  // 友军士兵X坐标
            byte aiy = this.smallSoldierCellY[1][0];  // 友军士兵Y坐标

            // 取得敌军士兵坐标
            byte hmx = this.smallSoldierCellX[0][index];  // 敌军士兵X坐标
            byte hmy = this.smallSoldierCellY[0][index];  // 敌军士兵Y坐标

            byte de = 0; // 默认返回值为0，C#中byte范围为0-0，避免溢出问题

            if (aix < 15)
            {
                if (hmx < aix)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // 向右移动
                    if (hmy == 0)
                    {
                        if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                            return 1; // 向下移动
                    }
                    else if (hmy == 6)
                    {
                        if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                            return 0; // 向上移动
                    }
                    else if (hmy > 0 && hmy < 6)
                    {
                        // 根据y坐标选择向上还是向下
                        if (hmx < aix - 3 && hmy < 3)
                        {
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                        }
                        else if (hmx < aix - 3 && hmy > 3)
                        {
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                        }
                        else
                        {
                            // 随机选择向上或向下移动
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32 && this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return (byte)MathUtils.getRandomInt(2); // 随机上下移动
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                        }
                    }
                }
                else if (hmx > aix)
                {
                    if (Math.Abs(hmx - aix) == 1)
                    {
                        if (hmy == 0)
                        {
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                        }
                        else if (hmy == 6)
                        {
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                        }
                        else
                        {
                            if (aiy > hmy && this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                            if (aiy < hmy && this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                        }
                    }
                    else
                    {
                        if (this.smallWarCoordinate[hmy][hmx - 1] < 32)
                            return 2; // 向左
                        if (hmy == 0)
                        {
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                        }
                        else if (hmy == 6)
                        {
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                        }
                        else
                        {
                            // 随机选择向上或向下移动
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32 && this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return (byte)MathUtils.getRandomInt(2); // 随机上下移动
                            if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                                return 0; // 向上
                            if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                                return 1; // 向下
                        }
                    }
                }
                else if (hmx == aix)
                {
                    // 根据友军士兵Y坐标移动
                    if (aiy == 0)
                    {
                        if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                            return 0; // 向上
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // 向右
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // 向左
                        }
                    }
                    else if (aiy == 6)
                    {
                        if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                            return 1; // 向下
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // 向右
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // 向左
                        }
                    }
                    else if (aiy > hmy)
                    {
                        if (Math.Abs(aiy - hmy) == 1 && this.smallWarCoordinate[hmy][hmx + 1] < 32 && MathUtils.getRandomInt(2) > 0)
                            return 3; // 向右
                        if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                            return 1; // 向下
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // 向右
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // 向左
                        }
                    }
                    else
                    {
                        if (Math.Abs(aiy - hmy) == 1 && this.smallWarCoordinate[hmy][hmx + 1] < 32 && MathUtils.getRandomInt(2) > 0)
                            return 3; // 向右
                        if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                            return 0; // 向上
                        if (hmx < 15)
                        {
                            if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                                return 3; // 向右
                        }
                        else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                        {
                            return 2; // 向左
                        }
                    }
                }
            }
            else if (hmx < aix)
            {
                // 敌军士兵向右移动
                if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                    return 3; // 向右
                if (hmy == 0)
                {
                    if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                        return 1; // 向下
                }
                else if (hmy == 6)
                {
                    if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                        return 0; // 向上
                }
                else if (hmy > 0 && hmy < 6)
                {
                    if (this.smallWarCoordinate[hmy - 1][hmx] < 32 && this.smallWarCoordinate[hmy + 1][hmx] < 32)
                        return (byte)MathUtils.getRandomInt(2); // 随机上下移动
                    if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                        return 0; // 向上
                    if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                        return 1; // 向下
                }
            }
            else if (aiy == 0)
            {
                if (this.smallWarCoordinate[hmy - 1][hmx] < 32)
                    return 0; // 向上
                if (hmx < 15)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // 向右
                }
                else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                {
                    return 2; // 向左
                }
            }
            else if (aiy == 6)
            {
                if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                    return 1; // 向下
                if (hmx < 15)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // 向右
                }
                else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                {
                    return 2; // 向左
                }
            }
            else if (aiy > hmy)
            {
                if (this.smallWarCoordinate[hmy + 1][hmx] < 32)
                    return 1; // 向下
                if (hmx < 15)
                {
                    if (this.smallWarCoordinate[hmy][hmx + 1] < 32)
                        return 3; // 向右
                }
                else if (hmx > 0 && this.smallWarCoordinate[hmy][hmx - 1] < 32)
                {
                    return 2; // 向左
                }
            }

            // 默认返回de值
            return de;
        }


        //方法: void_bbb_a
        void void_bbb_a(byte byte0, byte byte1, byte byte2)
        {
            switch (byte2)
            {
                case 0:
                    UpMoveSoldier(byte0, byte1);
                    break;
                case 1:
                    DownMoveSoldier(byte0, byte1);
                    break;
                case 2:
                    LeftMoveSoldier(byte0, byte1);
                    break;
                case 3:
                    RightMoveSoldier(byte0, byte1);
                    break;
            }
        }

        // 方法: byte_bb_b
        byte byte_bb_b(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[5];
            int i1 = 0;
            if (this.smallSoldierCellY[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
            {
                if (byte1 == 0 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0] - 1))
                    return 0;
                abyte0[i1++] = 0;
            }
            if (this.smallSoldierCellY[0][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
            {
                if (byte1 == 1 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0] + 1))
                    return 1;
                abyte0[i1++] = 1;
            }
            if (this.smallSoldierCellX[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - 1] & 0x80) != 0)
            {
                if (byte1 == 2 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] - 1 && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0]))
                    return 2;
                abyte0[i1++] = 2;
            }
            if (this.smallSoldierCellX[0][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + 1] & 0x80) != 0)
            {
                if (byte1 == 3 || (this.smallSoldierKind[0][byte0] == 0 && this.smallSoldierCellX[1][0] == this.smallSoldierCellX[0][byte0] + 1 && this.smallSoldierCellY[1][0] == this.smallSoldierCellY[0][byte0]))
                    return 3;
                abyte0[i1++] = 3;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
            {
                byte byte2 = (byte)(CommonUtils.getRandomInt() % i1);
                return abyte0[byte2];
            }
            return 0;
        }

        // 方法: void_bbbbB_a
        void void_bbbbB_a(byte byte0, byte byte1, byte byte2, byte byte3, bool flag)
        {
            this.aj = byte0;
            this.ak = byte1;
            this.al = byte2;
            this.am = byte3;
            this.k_boolean_fld = flag;
            this.ai = 6;
        }

        // 同步方法: s_void_bbB_b
        void s_void_bbB_b(byte byte0, byte byte1, bool flag)
        {
            byte byte2;
            byte byte3;

            if (flag)
            {
                byte2 = this.smallSoldierCellX[1][byte0];
                byte3 = this.smallSoldierCellY[1][byte0];
            }
            else
            {
                byte2 = this.smallSoldierCellX[0][byte0];
                byte3 = this.smallSoldierCellY[0][byte0];
            }

            switch (byte1)
            {
                case 0:
                    byte3 = (byte)(byte3 - 1);
                    break;
                case 1:
                    byte3 = (byte)(byte3 + 1);
                    break;
                case 2:
                    byte2 = (byte)(byte2 - 1);
                    break;
                case 3:
                    byte2 = (byte)(byte2 + 1);
                    break;
            }

            if (flag)
            {
                for (byte byte4 = 0; byte4 < this.humanSmallSoldierNum; byte4 = (byte)(byte4 + 1))
                {
                    if (this.smallSoldierCellX[0][byte4] == byte2 && this.smallSoldierCellY[0][byte4] == byte3)
                        void_bbbbB_a((byte)1, byte0, (byte)0, byte4, flag);
                }
            }
            else
            {
                for (byte byte5 = 0; byte5 < this.aiSmallSoldierNum; byte5 = (byte)(byte5 + 1))
                {
                    if (this.smallSoldierCellX[1][byte5] == byte2 && this.smallSoldierCellY[1][byte5] == byte3)
                        void_bbbbB_a((byte)0, byte0, (byte)1, byte5, flag);
                }
            }
        }

        // 方法: boolean_bb_b
        bool boolean_bb_b(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_b(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_b(byte0, byte2, false);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // 方法: byte_bb_c
        byte byte_bb_c(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.HMGeneralId, 6))
                byte2 = (byte)(byte2 + 1);
            if (this.smallSoldierCellY[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0 && byte1 == 0)
                return 0;
            if (this.smallSoldierCellY[0][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0 && byte1 == 1)
                return 1;
            if (this.smallSoldierCellX[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - 1] & 0x80) != 0 && byte1 == 2)
                return 2;
            if (this.smallSoldierCellX[0][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + 1] & 0x80) != 0 && byte1 == 3)
                return 3;
            if ((this.aa & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            int j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[0][byte0] + j1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + j1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[0][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - j1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[0][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[0][byte0] + j1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                j1++;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
                return abyte0[CommonUtils.getRandomInt() % i1];
            return 0;
        }

        // 同步方法: s_void_bbB_c
        void s_void_bbB_c(byte byte0, byte byte1, bool flag)
        {
            byte byte2, byte3, byte10, byte4, byte5, byte6, byte7, byte11 = 5;

            if (flag)
            {
                byte2 = this.smallSoldierCellX[1][byte0];
                byte3 = this.smallSoldierCellY[1][byte0];
                byte10 = 64;
                if (getSkill_2(this.AIGeneralId, 6))
                    byte11 = (byte)(byte11 + 1);
                if ((this.ab & 0xF0) == 48)
                    byte11 = (byte)(byte11 + 2);
            }
            else
            {
                byte2 = this.smallSoldierCellX[0][byte0];
                byte3 = this.smallSoldierCellY[0][byte0];
                byte10 = Byte.MinValue;
                if (getSkill_2(this.HMGeneralId, 6))
                    byte11 = (byte)(byte11 + 1);
                if ((this.aa & 0xF0) == 48)
                    byte11 = (byte)(byte11 + 2);
            }

            switch (byte1)
            {
                case 0:
                    byte4 = 1;
                    while (byte4 < byte11)
                    {
                        if (byte3 - byte4 >= 0 && (this.smallWarCoordinate[byte3 - byte4][byte2] & byte10) != 0)
                        {
                            byte3 = (byte)(byte3 - byte4);
                            break;
                        }
                        byte4 = (byte)(byte4 + 1);
                    }
                    break;
                case 1:
                    byte5 = 1;
                    while (byte5 < byte11)
                    {
                        if (byte3 + byte5 <= 6 && (this.smallWarCoordinate[byte3 + byte5][byte2] & byte10) != 0)
                        {
                            byte3 = (byte)(byte3 + byte5);
                            break;
                        }
                        byte5 = (byte)(byte5 + 1);
                    }
                    break;
                case 2:
                    byte6 = 1;
                    while (byte6 < byte11)
                    {
                        if (byte2 - byte6 >= 0 && (this.smallWarCoordinate[byte3][byte2 - byte6] & byte10) != 0)
                        {
                            byte2 = (byte)(byte2 - byte6);
                            break;
                        }
                        byte6 = (byte)(byte6 + 1);
                    }
                    break;
                case 3:
                    byte7 = 1;
                    while (byte7 < byte11)
                    {
                        if (byte2 + byte7 <= 15 && (this.smallWarCoordinate[byte3][byte2 + byte7] & byte10) != 0)
                        {
                            byte2 = (byte)(byte2 + byte7);
                            break;
                        }
                        byte7 = (byte)(byte7 + 1);
                    }
                    break;
            }

            if (flag)
            {
                //this.gamecanvas.void_bbbbB_a(this.smallSoldierCellX[1][byte0], this.smallSoldierCellY[1][byte0], byte2, byte3, !flag);
                for (byte byte8 = 0; byte8 < this.humanSmallSoldierNum; byte8 = (byte)(byte8 + 1))
                {
                    if (this.smallSoldierCellX[0][byte8] == byte2 && this.smallSoldierCellY[0][byte8] == byte3)
                        void_bbbbB_a((byte)1, byte0, (byte)0, byte8, flag);
                }
            }
            else
            {
                //this.gamecanvas.void_bbbbB_a(this.smallSoldierCellX[0][byte0], this.smallSoldierCellY[0][byte0], byte2, byte3, !flag);
                for (byte byte9 = 0; byte9 < this.aiSmallSoldierNum; byte9 = (byte)(byte9 + 1))
                {
                    if (this.smallSoldierCellX[1][byte9] == byte2 && this.smallSoldierCellY[1][byte9] == byte3)
                        void_bbbbB_a((byte)0, byte0, (byte)1, byte9, flag);
                }
            }
        }

        // 方法: boolean_bb_c
        bool boolean_bb_c(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_c(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_c(byte0, byte2, false);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }
        // 方法：boolean_b_c
        // 参数：byte0，类型byte
        // 功能：根据byte0的不同类型，调用不同的处理方法

        bool boolean_b_c(byte byte0)
        {
            // 获取hmSoldierMove返回的值
            byte byte1 = hmSoldierMove(byte0);

            // 如果返回值大于等于0，将其赋值给smallSoldier_action[0][byte0]
            if (byte1 >= 0)
            {
                this.smallSoldierAction[0][byte0] = byte1;
            }

            // 根据smallSoldierKind[0][byte0]的值执行不同操作
            switch (this.smallSoldierKind[0][byte0])
            {
                case 0:
                case 1:
                case 3:
                    // 处理情况0、1和3，调用boolean_bb_b
                    return boolean_bb_b(byte0, byte1);
                case 2:
                    // 处理情况2，调用boolean_bb_c
                    return boolean_bb_c(byte0, byte1);
            }

            // 如果没有匹配的情况，返回false
            return false;
        }




        // 方法: boolean_b_d
        bool boolean_b_d(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            if (this.smallSoldierCellY[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                abyte0[i1++] = 0;
            if (this.smallSoldierCellY[0][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + 1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                abyte0[i1++] = 1;
            if (this.smallSoldierCellX[0][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - 1] & 0x80) != 0)
                abyte0[i1++] = 2;
            if (this.smallSoldierCellX[0][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + 1] & 0x80) != 0)
                abyte0[i1++] = 3;
            if (i1 == 0)
                return false;
            s_void_bbB_b(byte0, abyte0[CommonUtils.getRandomInt() % i1], false);
            return true;
        }

        // 方法: boolean_b_e
        bool boolean_b_e(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.HMGeneralId, 6))
                byte2 = (byte)(byte2 + 1);
            if ((this.aa & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            byte byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[0][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] - byte1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[0][byte0] + byte1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0] + byte1][this.smallSoldierCellX[0][byte0]] & 0x80) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[0][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] - byte1] & 0x80) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[0][byte0] + byte1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[0][byte0]][this.smallSoldierCellX[0][byte0] + byte1] & 0x80) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            if (i1 == 0)
                return false;
            s_void_bbB_c(byte0, abyte0[CommonUtils.getRandomInt() % i1], false);
            return true;
        }

        // 方法: boolean_b_f
        bool boolean_b_f(byte byte0)
        {
            switch (this.smallSoldierKind[0][byte0])
            {
                case 0:
                case 1:
                case 3:
                    return boolean_b_d(byte0);
                case 2:
                    return boolean_b_e(byte0);
            }
            return false;
        }

        // 方法: boolean_b_g
        bool boolean_b_g(byte index)
        {
            if (this.smallSoldierCellX[0][index] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][index]][this.smallSoldierCellX[0][index] - 1] & 0xE0) != 0)
            {
                int i1 = 0;
                if (this.smallSoldierCellY[0][index] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[0][index] - 1][this.smallSoldierCellX[0][index]] & 0xE0) == 0)
                    i1++;
                if (this.smallSoldierCellY[0][index] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[0][index] + 1][this.smallSoldierCellX[0][index]] & 0xE0) == 0)
                    i1 += 2;
                byte byte1 = 0;
                if (i1 == 1)
                {
                    UpMoveSoldier(byte1, index);
                }
                else if (i1 == 2)
                {
                    DownMoveSoldier(byte1, index);
                }
                else if (i1 == 3)
                {
                    if (CommonUtils.getRandomInt() % 2 == 0)
                    {
                        UpMoveSoldier(byte1, index);
                    }
                    else
                    {
                        DownMoveSoldier(byte1, index);
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            if (this.smallSoldierCellX[0][index] == 0)
            {
                this.smallWarCoordinate[this.smallSoldierCellY[0][index]][this.smallSoldierCellX[0][index]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[0][index]][this.smallSoldierCellX[0][index]] & 0x32);
                this.smallSoldierCellX[0][index] = 0;
                this.smallSoldierCellY[0][index] = 0;
                this.smallSoldier_isSurvive[0][index] = false;
                return true;
            }
            LeftMoveSoldier((byte)0, index);
            return true;
        }

        // 方法: byte_bb_d
        byte byte_bb_d(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[5];
            int i1 = 0;
            byte byte2 = this.smallSoldierCellX[0][byte0];
            byte byte3 = this.smallSoldierCellY[0][byte0];
            byte byte4 = this.smallSoldierCellX[1][0];
            byte byte5 = this.smallSoldierCellY[1][0];

            // 检查向上移动的情况
            if (byte1 == 0 && byte5 == byte3 - 1 && byte4 == byte2)
            {
                byte1 = 0;
            }
            else if (byte3 > 0 && (this.smallWarCoordinate[byte3 - 1][byte2] & 0x80) != 0 && (byte5 != byte3 - 1 || byte4 != byte2))
            {
                if (byte1 == 0)
                    return 0;
                abyte0[i1++] = 0;
            }

            // 检查向下移动的情况
            if (byte1 == 1 && byte5 == byte3 + 1 && byte4 == byte2)
            {
                byte1 = 0;
            }
            else if (byte3 < 6 && (this.smallWarCoordinate[byte3 + 1][byte2] & 0x80) != 0 && (byte5 != byte3 + 1 || byte4 != byte2))
            {
                if (byte1 == 1)
                    return 1;
                abyte0[i1++] = 1;
            }

            // 检查向左移动的情况
            if (byte1 == 2 && byte5 == byte3 && byte4 == byte2 - 1)
            {
                byte1 = 0;
            }
            else if (byte2 > 0 && (this.smallWarCoordinate[byte3][byte2 - 1] & 0x80) != 0 && (byte5 != byte3 || byte4 != byte2 - 1))
            {
                if (byte1 == 2)
                    return 2;
                abyte0[i1++] = 2;
            }

            // 检查向右移动的情况
            if (byte1 == 3 && byte5 == byte3 && byte4 == byte2 + 1)
            {
                byte1 = 0;
            }
            else if (byte2 < 15 && (this.smallWarCoordinate[byte3][byte2 + 1] & 0x80) != 0 && (byte4 != byte2 + 1 || byte5 != byte3))
            {
                if (byte1 == 3)
                    return 3;
                abyte0[i1++] = 3;
            }

            // 如果有可选的方向，则随机选择一个方向
            if (i1 > 0 && (byte1 < 0 || CommonUtils.getRandomInt() % 10 >= 10))
            {
                byte byte6 = (byte)(CommonUtils.getRandomInt() % i1);
                return abyte0[byte6];
            }

            // 返回默认值
            return (byte)((byte1 >= 0) ? 0 : -2);
        }

        // 方法: boolean_bb_d
        bool boolean_bb_d(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_d(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_b(byte0, byte2, false);
            }
            else if (byte1 >= 0 && byte2 != -2)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // 方法: byte_bb_e
        byte byte_bb_e(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = this.smallSoldierCellX[0][byte0];
            byte byte3 = this.smallSoldierCellY[0][byte0];
            byte byte4 = this.smallSoldierCellX[1][0];
            byte byte5 = this.smallSoldierCellY[1][0];
            byte byte6 = 5;

            // 检查技能是否激活
            if (getSkill_2(this.HMGeneralId, 6))
                byte6 = (byte)(byte6 + 1);

            // 检查向上移动的情况
            if (byte3 > 0 && (this.smallWarCoordinate[byte3 - 1][byte2] & 0x80) != 0 && byte1 == 0)
                if (byte5 == byte3 - 1 && byte4 == byte2)
                {
                    byte1 = 0;
                }
                else
                {
                    return 0;
                }

            // 检查向下移动的情况
            if (byte3 < 6 && (this.smallWarCoordinate[byte3 + 1][byte2] & 0x80) != 0 && byte1 == 1)
                if (byte5 == byte3 + 1 && byte4 == byte2)
                {
                    byte1 = 0;
                }
                else
                {
                    return 1;
                }

            // 检查向左移动的情况
            if (byte2 > 0 && (this.smallWarCoordinate[byte3][byte2 - 1] & 0x80) != 0 && byte1 == 2)
                if (byte5 == byte3 && byte4 == byte2 - 1)
                {
                    byte1 = 0;
                }
                else
                {
                    return 2;
                }

            // 检查向右移动的情况
            if (byte2 < 15 && (this.smallWarCoordinate[byte3][byte2 + 1] & 0x80) != 0 && byte1 == 3)
                if (byte5 == byte3 && byte4 == byte2 + 1)
                {
                    byte1 = 0;
                }
                else
                {
                    return 3;
                }

            // 检查额外技能
            if ((this.aa & 0xF0) == 48)
                byte6 = (byte)(byte6 + 2);

            // 检查上方多个位置
            int j1 = 1;
            while (j1 < byte6 && byte3 >= j1 && (byte5 != byte3 - j1 || byte4 != byte2))
            {
                if ((this.smallWarCoordinate[byte3 - j1][byte2] & 0x80) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                j1++;
            }

            // 检查下方多个位置
            j1 = 1;
            while (j1 < byte6 && byte3 + j1 <= 6 && (byte5 != byte3 + j1 || byte4 != byte2))
            {
                if ((this.smallWarCoordinate[byte3 + j1][byte2] & 0x80) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                j1++;
            }

            // 检查左侧多个位置
            j1 = 1;
            while (j1 < byte6 && byte2 >= j1 && (byte5 != byte3 || byte4 != byte2 - j1))
            {
                if ((this.smallWarCoordinate[byte3][byte2 - j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                j1++;
            }

            // 检查右侧多个位置
            j1 = 1;
            while (j1 < byte6 && byte2 + j1 <= 15 && (byte5 != byte3 || byte4 != byte2 + j1))
            {
                if ((this.smallWarCoordinate[byte3][byte2 + j1] & 0x80) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                j1++;
            }

            // 如果有可选的方向，则随机选择一个方向
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 6))
                return abyte0[CommonUtils.getRandomInt() % i1];

            // 返回默认值
            return (byte)((byte1 != 0) ? 0 : -2);
        }

        // 方法: boolean_bb_e
        bool boolean_bb_e(byte byte0, byte byte1)
        {
            byte1 = hmSoldierMove(byte0);
            byte byte2 = byte_bb_e(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_c(byte0, byte2, false);
            }
            else if (byte1 >= 0 && byte2 != -2)
            {
                void_bbb_a((byte)0, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // 方法: boolean_b_h
        bool boolean_b_h(byte byte0)
        {
            byte byte1 = hmSoldierMove(byte0);
            if (byte1 >= 0)
                this.smallSoldierAction[0][byte0] = byte1;
            switch (this.smallSoldierKind[0][byte0])
            {
                case 0:
                case 1:
                case 3:
                    return boolean_bb_d(byte0, byte1);
                case 2:
                    return boolean_bb_e(byte0, byte1);
            }
            return false;
        }

        // 方法: boolean_b_i
        bool boolean_b_i(byte byte0)
        {
            bool flag = false;
            if (!this.smallSoldier_isSurvive[0][byte0])
                return false;
            this.smallSoldierOrder[0][byte0] = this.P_byte_array1d_fld[this.smallSoldierKind[0][byte0]];
            switch (this.smallSoldierOrder[0][byte0])
            {
                case 0:
                    flag = boolean_b_c(byte0);
                    break;
                case 1:
                    flag = boolean_b_f(byte0);
                    break;
                case 2:
                    flag = boolean_b_g(byte0);
                    break;
                case 3:
                    flag = boolean_b_h(byte0);
                    break;
            }
            setCSK();
            return flag;
        }

        // 方法: byte_b_e
        byte byte_b_e(byte byte0)
        {
            byte hG_X = this.smallSoldierCellX[0][0];
            byte hG_Y = this.smallSoldierCellY[0][0];
            byte ai_X = this.smallSoldierCellX[1][byte0];
            byte ai_Y = this.smallSoldierCellY[1][byte0];
            byte byte5 = 0;

            try
            {
                // 检查向左移动的情况
                if (hG_X > 0 && (this.smallWarCoordinate[hG_Y][hG_X + 1] & 0xA0) == 0 && hG_Y - ai_Y != 0)
                {
                    hG_X = (byte)(hG_X - 1);
                }
                // 检查向上移动的情况
                else if (hG_Y - ai_Y <= 0)
                {
                    if (hG_Y > 0 && (this.smallWarCoordinate[hG_Y - 1][hG_X] & 0xA0) == 0)
                    {
                        hG_Y = (byte)(hG_Y - 1);
                    }
                    else if (hG_Y < 6 && (this.smallWarCoordinate[hG_Y + 1][hG_X] & 0xA0) == 0)
                    {
                        hG_Y = (byte)(hG_Y + 1);
                    }
                    else if (hG_X < 15 && (this.smallWarCoordinate[hG_Y][hG_X - 1] & 0xA0) == 0)
                    {
                        hG_X = (byte)(hG_X + 1);
                    }
                }
                // 检查向下移动的情况
                else if (hG_Y < 6 && (this.smallWarCoordinate[hG_Y + 1][hG_X] & 0xA0) == 0)
                {
                    hG_Y = (byte)(hG_Y + 1);
                }
                // 检查向上移动的情况
                else if (hG_Y > 0 && (this.smallWarCoordinate[hG_Y - 1][hG_X] & 0xA0) == 0)
                {
                    hG_Y = (byte)(hG_Y - 1);
                }
                // 检查向右移动的情况
                else if (hG_X < 15 && (this.smallWarCoordinate[hG_Y][hG_X - 1] & 0xA0) == 0)
                {
                    hG_X = (byte)(hG_X + 1);
                }

                // 检查目标位置在右侧的情况
                if (ai_X < 15 && hG_X - ai_X > 0 && (this.smallWarCoordinate[ai_Y][ai_X + 1] & 0xA0) == 0)
                    if (hG_X == ai_X + 1 && hG_Y == ai_Y)
                    {
                        byte5 = 3;
                    }
                    else
                    {
                        return 3;
                    }
                // 检查目标位置在左侧的情况
                if (ai_X > 0 && hG_X - ai_X < 0 && (this.smallWarCoordinate[ai_Y][ai_X - 1] & 0xA0) == 0)
                    if (hG_X == ai_X - 1 && hG_Y == ai_Y)
                    {
                        byte5 = 2;
                    }
                    else
                    {
                        return 2;
                    }
                // 检查目标位置在下方的情况
                if (ai_Y < 6 && hG_Y - ai_Y > 0 && (this.smallWarCoordinate[ai_Y + 1][ai_X] & 0xA0) == 0)
                    return 1;
                // 检查目标位置在上方的情况
                if (ai_Y > 0 && hG_Y - ai_Y < 0 && (this.smallWarCoordinate[ai_Y - 1][ai_X] & 0xA0) == 0)
                    return 0;

                // 检查水平方向相同的情况
                if (hG_X - ai_X == 0)
                {
                    if (ai_X < 15 && ai_X > 0 && (this.smallWarCoordinate[ai_Y][ai_X + 1] & 0xA0) == 0 && this.smallWarCoordinate[ai_Y][ai_X - 1] == 0)
                        return (byte)(CommonUtils.getRandomInt() % 2 + 2);
                    if (ai_X < 15 && (this.smallWarCoordinate[ai_Y][ai_X + 1] & 0xA0) == 0)
                        return 3;
                    if (ai_X > 0 && (this.smallWarCoordinate[ai_Y][ai_X - 1] & 0xA0) == 0)
                        return 2;
                }

                // 检查垂直方向相同的情况
                if (hG_Y - ai_Y == 0)
                {
                    if (ai_Y > 0 && ai_Y < 6 && (this.smallWarCoordinate[ai_Y + 1][ai_X] & 0xA0) == 0 && (this.smallWarCoordinate[ai_Y - 1][ai_X] & 0xA0) == 0)
                        return (byte)(CommonUtils.getRandomInt() % 2);
                    if (ai_Y < 6 && (this.smallWarCoordinate[ai_Y + 1][ai_X] & 0xA0) == 0)
                        return 1;
                    if (ai_Y > 0 && (this.smallWarCoordinate[ai_Y - 1][ai_X] & 0xA0) == 0)
                        return 0;
                }
            }
            catch (System.Exception e)
            {
                e.ToString(); // 在 C# 中使用 e.ToString() 打印异常信息
                return byte5;
            }

            return byte5;
        }

        // 将byte类型定义为无符号的byte
        public byte aiSoldierMove(byte index)
        {
            // 取得己方士兵和AI士兵的坐标
            byte hmx = this.smallSoldierCellX[0][0]; // 己方士兵X坐标
            byte hmy = this.smallSoldierCellY[0][0]; // 己方士兵Y坐标
            byte aix = this.smallSoldierCellX[1][index]; // AI士兵X坐标
            byte aiy = this.smallSoldierCellY[1][index]; // AI士兵Y坐标

            // 如果己方士兵的X坐标大于0
            if (hmx > 0)
            {
                // 如果AI士兵的X坐标大于己方士兵
                if (aix > hmx)
                {
                    // 如果X坐标差值为1，并且Y坐标相等，进行边界处理
                    if (Math.Abs(aix - hmx) == 1)
                    {
                        if (aiy == hmy)
                        {
                            if (aiy == 0)
                            {
                                // 如果AI士兵在地图最上方，检查下方是否可移动
                                if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                                    return 1; // 向下移动
                                return 2; // 向左移动
                            }
                            if (aiy == 6)
                            {
                                // 如果AI士兵在地图最下方，检查上方是否可移动
                                if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                                    return 0; // 向上移动
                                return 2; // 向左移动
                            }
                        }
                        else if (hmy - aiy >= 2)
                        {
                            // 如果AI士兵Y坐标比己方士兵小2以上，检查下方或左方可移动
                            if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                                return 1; // 向下移动
                            if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                                return 2; // 向左移动
                        }
                        else if (aiy - hmy >= 2)
                        {
                            // 如果AI士兵Y坐标比己方士兵大2以上，检查上方或左方可移动
                            if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                                return 0; // 向上移动
                            if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                                return 2; // 向左移动
                        }
                        else
                        {
                            // 否则，优先向左或上移动
                            if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                                return 2; // 向左移动
                            if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                                return 0; // 向上移动
                        }
                    }
                    // AI士兵在地图最上方时的边界处理
                    else if (aiy == 0)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return 1; // 向下移动
                    }
                    // AI士兵在地图最下方时的边界处理
                    else if (aiy == 6)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                            return 0; // 向上移动
                    }
                    else
                    {
                        // 检查左方、上方和下方移动的可能性
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16 &&
                            this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return (byte)(CommonUtils.getRandomInt() % 2); // 随机选择上或下移动
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                            return 0; // 向上移动
                        if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return 1; // 向下移动
                    }
                }
                // AI士兵和己方士兵X坐标相同的情况处理
                else if (aix == hmx)
                {
                    if (aiy - hmy == 1)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // 向右移动
                        return 0; // 向上移动
                    }
                    if (hmy - aiy == 1)
                    {
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // 向右移动
                        return 1; // 向下移动
                    }
                    // AI士兵Y坐标比己方士兵大2以上时的处理
                    if (aiy - hmy >= 2)
                    {
                        if (this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                            return 0; // 向上移动
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // 向右移动
                    }
                    // AI士兵Y坐标比己方士兵小2以上时的处理
                    else if (hmy - aiy >= 2)
                    {
                        if (this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                            return 1; // 向下移动
                        if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                            return 2; // 向左移动
                        if (hmx < 15 && this.smallWarCoordinate[aiy][aix + 1] >= 0 && this.smallWarCoordinate[aiy][aix + 1] <= 16)
                            return 3; // 向右移动
                    }
                    // 默认优先向左移动
                    if (this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                        return 2; // 向左移动
                }
            }

            // 根据不同条件，默认返回一个移动方向，防止异常情况
            return 0; // 向上移动
        }


        // 方法: byte_bb_f
        byte byte_bb_f(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            if (this.smallSoldierCellY[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
            {
                if (byte1 == 0 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0] - 1))
                    return 0;
                abyte0[i1++] = 0;
            }
            if (this.smallSoldierCellY[1][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
            {
                if (byte1 == 1 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0] + 1))
                    return 1;
                abyte0[i1++] = 1;
            }
            if (this.smallSoldierCellX[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - 1] & 0x40) != 0)
            {
                if (byte1 == 4 || byte1 == 2 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] - 1 && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0]))
                    return 2;
                abyte0[i1++] = 2;
            }
            if (this.smallSoldierCellX[1][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + 1] & 0x40) != 0)
            {
                if (byte1 == 3 || (this.smallSoldierKind[1][byte0] == 0 && this.smallSoldierCellX[0][0] == this.smallSoldierCellX[1][byte0] + 1 && this.smallSoldierCellY[0][0] == this.smallSoldierCellY[1][byte0]))
                    return 3;
                abyte0[i1++] = 3;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
                return abyte0[CommonUtils.getRandomInt() % i1];
            return 0;
        }

        // 方法: boolean_bb_f
        bool boolean_bb_f(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_f(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_b(byte0, byte2, true);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)1, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }

        // 方法: byte_bb_g
        byte byte_bb_g(byte byte0, byte byte1)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.AIGeneralId, 6))
                byte2 = (byte)(byte2 + 1);
            if (this.smallSoldierCellY[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0 && byte1 == 0)
                return 0;
            if (this.smallSoldierCellY[1][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0 && byte1 == 1)
                return 1;
            if (this.smallSoldierCellX[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - 1] & 0x40) != 0 && byte1 == 2)
                return 2;
            if (this.smallSoldierCellX[1][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + 1] & 0x40) != 0 && byte1 == 3)
                return 3;
            if ((this.ab & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            int j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[1][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - j1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellY[1][byte0] + j1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + j1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[1][byte0] >= j1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - j1] & 0x40) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                j1++;
            }
            j1 = 1;
            while (j1 < byte2 && this.smallSoldierCellX[1][byte0] + j1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + j1] & 0x40) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                j1++;
            }
            if (i1 > 0 && (byte1 == 0 || CommonUtils.getRandomInt() % 10 >= 0))
                return abyte0[CommonUtils.getRandomInt() % i1];
            return 0;
        }

        // 方法: boolean_bb_g
        bool boolean_bb_g(byte byte0, byte byte1)
        {
            byte byte2 = byte_bb_g(byte0, byte1);
            if (byte2 >= 0)
            {
                s_void_bbB_c(byte0, byte2, true);
            }
            else if (byte1 >= 0)
            {
                void_bbb_a((byte)1, byte0, byte1);
            }
            else
            {
                return false;
            }
            return true;
        }


        // 方法: boolean_b_j
        public bool boolean_b_j(byte byte0)
        {
            if (this.smallSoldier_isSurvive[1][byte0])
            {
                byte byte1 = 0;
                try
                {
                    byte1 = aiSoldierMove(byte0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // 在Unity中可以使用 UnityEngine.Debug.LogError(e) 来打印异常
                    try
                    {
                        byte1 = byte_b_e(byte0);
                    }
                    catch (Exception e2)
                    {
                        Console.WriteLine(e2); // 同上
                    }
                }
                if (byte1 >= 0)
                    this.smallSoldierAction[1][byte0] = byte1;
                switch (this.smallSoldierKind[1][byte0])
                {
                    case 0:
                    case 1:
                    case 3:
                        return boolean_bb_f(byte0, byte1);
                    case 2:
                        return boolean_bb_g(byte0, byte1);
                }
            }
            return false;
        }

        // 方法: boolean_b_k
        public bool boolean_b_k(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            if (this.smallSoldierCellY[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                abyte0[i1++] = 0;
            if (this.smallSoldierCellY[1][byte0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + 1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                abyte0[i1++] = 1;
            if (this.smallSoldierCellX[1][byte0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - 1] & 0x40) != 0)
                abyte0[i1++] = 2;
            if (this.smallSoldierCellX[1][byte0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + 1] & 0x40) != 0)
                abyte0[i1++] = 3;
            if (i1 == 0)
                return false;
            s_void_bbB_b(byte0, abyte0[CommonUtils.getRandomInt() % i1], true);
            return true;
        }

        // 方法: boolean_b_l
        public bool boolean_b_l(byte byte0)
        {
            byte[] abyte0 = new byte[4];
            int i1 = 0;
            byte byte2 = 5;
            if (getSkill_2(this.AIGeneralId, 3))
                byte2 = (byte)(byte2 + 1);
            if ((this.ab & 0xF0) == 48)
                byte2 = (byte)(byte2 + 2);
            byte byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[1][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] - byte1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 0;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellY[1][byte0] + byte1 <= 6)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0] + byte1][this.smallSoldierCellX[1][byte0]] & 0x40) != 0)
                {
                    abyte0[i1++] = 1;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[1][byte0] >= byte1)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] - byte1] & 0x40) != 0)
                {
                    abyte0[i1++] = 2;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            byte1 = 1;
            while (byte1 < byte2 && this.smallSoldierCellX[1][byte0] + byte1 <= 15)
            {
                if ((this.smallWarCoordinate[this.smallSoldierCellY[1][byte0]][this.smallSoldierCellX[1][byte0] + byte1] & 0x40) != 0)
                {
                    abyte0[i1++] = 3;
                    break;
                }
                byte1 = (byte)(byte1 + 1);
            }
            if (i1 == 0)
                return false;
            s_void_bbB_c(byte0, abyte0[CommonUtils.getRandomInt() % i1], true);
            return true;
        }

        // 处理小兵的生存状态与行为，判断是否进行特定动作
        bool boolean_b_m(byte byte0)
        {
            // 检查该小兵是否存活
            if (this.smallSoldier_isSurvive[1][byte0])
            {
                // 根据小兵的类型，执行不同的逻辑
                switch (this.smallSoldierKind[1][byte0])
                {
                    case 0:
                    case 1:
                    case 3:
                        // 调用boolean_b_k方法处理对应类型
                        return boolean_b_k(byte0);
                    case 2:
                        // 调用boolean_b_l方法处理类型2
                        return boolean_b_l(byte0);
                }
            }

            // 默认返回false，表示没有进行任何操作
            return false;
        }

        // 根据小兵的坐标判断其能否移动或消失
        bool boolean_b_n(byte byte0)
        {
            byte x = this.smallSoldierCellX[1][byte0];  // 获取小兵当前的X坐标
            byte y = this.smallSoldierCellY[1][byte0];  // 获取小兵当前的Y坐标

            // 如果小兵位于最右侧边界(15)
            if (x == 15)
            {
                this.smallWarCoordinate[y][x] = (byte)(this.smallWarCoordinate[y][x] & 0x32);  // 更新小兵坐标状态
                this.smallSoldierCellX[1][byte0] = 0;  // 将小兵的X坐标标记为无效
                this.smallSoldierCellY[1][byte0] = 0;  // 将小兵的Y坐标标记为无效
                this.smallSoldier_isSurvive[1][byte0] = false;  // 标记小兵为死亡
                return true;  // 返回true，表示小兵已移出战场
            }

            // 如果小兵未到达边界，检查其左侧是否有可移动空间
            if (x < 15)
            {
                byte t_Left = this.smallWarCoordinate[y][x + 1];
                if (t_Left >= 0 && t_Left <= 16)
                {
                    // 执行小兵的向左移动逻辑
                    RightMoveSoldier((byte)1, byte0);
                    return true;
                }
            }

            int i = 0;

            // 检查小兵的上方位置是否可移动
            if (y > 0)
            {
                byte t_UP = this.smallWarCoordinate[y - 1][x];
                if (t_UP >= 0 && t_UP <= 16)
                    i++;
            }

            // 检查小兵的下方位置是否可移动
            if (y < 6)
            {
                byte t_Down = this.smallWarCoordinate[y + 1][x];
                if (t_Down >= 0 && t_Down <= 16)
                    i += 2;
            }

            // 根据i的值判断方向
            if (i == 1)
            {
                UpMoveSoldier((byte)1, byte0);  // 向上移动
                return true;
            }
            if (i == 2)
            {
                DownMoveSoldier((byte)1, byte0);  // 向下移动
                return true;
            }
            if (i == 3)
            {
                if (CommonUtils.getRandomInt() % 2 > 0)
                {
                    UpMoveSoldier((byte)1, byte0);  // 随机向上移动
                    return true;
                }
                DownMoveSoldier((byte)1, byte0);  // 向下移动
                return true;
            }

            return false;  // 默认返回false
        }

        // 根据小兵当前的指令，执行相应的动作
        bool boolean_b_o(byte byte0)
        {
            bool flag = false;

            // 如果小兵已经死亡，直接返回false
            if (!this.smallSoldier_isSurvive[1][byte0])
                return false;

            // 根据小兵的指令类型，执行不同的操作
            switch (this.smallSoldierOrder[1][byte0])
            {
                case 0:
                    // 执行类型为0的指令
                    flag = boolean_b_j(byte0);
                    break;
                case 1:
                    // 执行类型为1的指令
                    flag = boolean_b_m(byte0);
                    break;
                case 2:
                    // 执行类型为2的指令，首先检查移动，失败时执行类型1指令
                    flag = boolean_b_n(byte0);
                    if (!flag)
                        flag = boolean_b_m(byte0);
                    break;
            }

            setCSK();  // 调用setCSK方法，更新状态
            return flag;  // 返回执行结果
        }


        public short sht(bool aiAtk)
        {
            // 获取进攻方攻击力和防守方防御力
            int gjl = this.smallSoldierAtk[this.aj][this.ak]; // 当前AI或玩家的攻击力
            int fyl = this.smallSoldierDef[this.al][this.am]; // 当前防御方的防御力

            // 计算当前血量的20分之一作为最小伤害
            int F = this.smallSoldierBlood[this.aj][this.ak] / 20;

            // 防御系数计算
            float t1 = fyl / 150.0F;
            t1 *= d.hj[fyl - 1]; // 乘以一个修正系数

            // 计算最终的伤害值
            float sh = gjl * 1.0F / (1.0F + t1);

            // 保证伤害值不低于最小值
            if (sh < F)
                sh = F;

            // 如果血量低于200，伤害减少
            if (this.smallSoldierBlood[this.aj][this.ak] < 200)
                sh = sh * this.smallSoldierBlood[this.aj][this.ak] / 200.0F;

            // 确保伤害最小为1
            if (sh < 1.0F)
                sh = 1.0F;

            // 标记是否暴击
            bool isbaoji = false;

            // AI进攻时的计算
            if (aiAtk)
            {
                // 检查是否触发特定攻击效果
                if ((this.ab & 0xF0) == 64)
                {
                    sh = sh * 4.0F / 3.0F; // 特殊增伤效果
                }
                else if ((this.ab & 0xF0) == 80 && this.smallSoldierKind[this.aj][this.ak] == 2)
                {
                    sh = sh * 5.0F / 3.0F; // 另一个增伤效果
                }

                // 判断不同兵种是否触发技能暴击
                if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_3(this.AIGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 2 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_2(this.AIGeneralId, 9))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                // 其他兵种暴击的处理逻辑类似
                if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.AIGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.AIGeneralId, 0) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.AIGeneralId, 2))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.AIGeneralId, 3) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                // 判断地形是否触发特殊效果
                if (getSkill_2(this.AIGeneralId, 4) && this.warTerrain == 9 && !isbaoji)
                {
                    if (CommonUtils.getRandomInt() % 7 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (getSkill_2(this.AIGeneralId, 5) && (this.warTerrain == 10 || this.warTerrain == 11) && !isbaoji && CommonUtils.getRandomInt() % 7 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
            }
            // 玩家进攻时的计算逻辑，类似于AI
            else
            {
                if ((this.aa & 0xF0) == 64)
                {
                    sh = sh * 4.0F / 3.0F;
                }
                else if ((this.aa & 0xF0) == 80 && this.smallSoldierKind[this.aj][this.ak] == 2)
                {
                    sh = sh * 5.0F / 3.0F;
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_3(this.HMGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 2 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 0 && getSkill_2(this.HMGeneralId, 9))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.HMGeneralId, 0))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 1 && getSkill_2(this.HMGeneralId, 1) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.HMGeneralId, 2))
                {
                    if (CommonUtils.getRandomInt() % 3 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (this.smallSoldierKind[this.aj][this.ak] == 2 && getSkill_2(this.HMGeneralId, 2) && CommonUtils.getRandomInt() % 5 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
                if (getSkill_2(this.HMGeneralId, 4) && this.warTerrain == 9 && !isbaoji)
                {
                    if (CommonUtils.getRandomInt() % 7 < 1)
                    {
                        sh += sh / 2.0F;
                        isbaoji = true;
                    }
                }
                else if (getSkill_2(this.HMGeneralId, 5) && (this.warTerrain == 10 || this.warTerrain == 11) && !isbaoji && CommonUtils.getRandomInt() % 7 < 1)
                {
                    sh += sh / 2.0F;
                    isbaoji = true;
                }
            }

            // 返回最终的伤害值
            return (short)(int)sh;
        }


        // 计算平方根的函数
        double getSqrt(double a)
        {
            return Math.Sqrt(a); // 使用C#中的Math.Sqrt函数
        }

        // 执行战斗逻辑
        void void_B_b(bool flag)
        {
            short sh = sht(flag); // 调用sht方法获取伤害值

            // 检查技能3，减少伤害值
            if (getSkill_3(this.AIGeneralId, 9) && !flag)
            {
                sh = (short)(sh / 2);
            }
            else if (getSkill_3(this.HMGeneralId, 9) && flag)
            {
                sh = (short)(sh / 2);
            }

            // 检查技能2，如果伤害值小于30可能将伤害值置为0
            if (sh < 30)
            {
                if (getSkill_2(this.AIGeneralId, 7) && CommonUtils.getRandomInt() % 3 < 1 && !flag)
                {
                    sh = 0;
                }
                else if (getSkill_2(this.HMGeneralId, 7) && CommonUtils.getRandomInt() % 3 < 1 && flag)
                {
                    sh = 0;
                }
            }

            // 检查血量，如果士兵的血量小于50并且不是步兵
            if (this.smallSoldierBlood[this.al][this.am] < 50 && this.smallSoldierKind[this.al][this.am] != 0)
            {
                if (getSkill_2(this.AIGeneralId, 8) && CommonUtils.getRandomInt() % 3 < 1 && !flag)
                {
                    sh = 0;
                }
                else if (getSkill_2(this.HMGeneralId, 8) && CommonUtils.getRandomInt() % 3 < 1 && flag)
                {
                    sh = 0;
                }
            }

            // 步兵对战逻辑
            if (this.smallSoldierKind[this.al][this.am] == 0)
            {
                if (this.smallSoldierKind[this.aj][this.ak] == 0)
                {
                    this.singleFigth = true; // 设置单挑模式
                    return;
                }

                General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId);
                General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId);

                if (flag)
                {
                    userGeneral.decreaseCurPhysical((byte)(sh / 6));
                    if (userGeneral.getCurPhysical() <= 0)
                    {
                        this.smallSoldier_isSurvive[this.al][this.am] = false;
                    }
                }
                else
                {
                    aiGeneral.decreaseCurPhysical((byte)(sh / 6));
                    if (aiGeneral.getCurPhysical() <= 0)
                    {
                        this.smallSoldier_isSurvive[this.al][this.am] = false;
                    }
                }
            }
            else
            {
                short first = this.smallSoldierBlood[this.al][this.am];
                this.smallSoldierBlood[this.al][this.am] = (short)(this.smallSoldierBlood[this.al][this.am] - sh);

                if (this.smallSoldierBlood[this.al][this.am] <= 0)
                {
                    this.smallSoldier_isSurvive[this.al][this.am] = false;
                    this.smallSoldierBlood[this.al][this.am] = 0;
                    this.smallWarCoordinate[this.smallSoldierCellY[this.al][this.am]][this.smallSoldierCellX[this.al][this.am]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[this.al][this.am]][this.smallSoldierCellX[this.al][this.am]] & 0x32);
                    this.smallSoldierCellY[this.al][this.am] = 0;
                    this.smallSoldierCellX[this.al][this.am] = 0;
                }

                short end = this.smallSoldierBlood[this.al][this.am];

                if (this.smallSoldierKind[this.aj][this.ak] == 0)
                {
                    if (flag)
                    {
                        this.AITotalGeneralHurt = (short)(this.AITotalGeneralHurt + first - end);
                    }
                    else
                    {
                        this.HMTotalGeneralHurt = (short)(this.HMTotalGeneralHurt + first - end);
                    }
                }
                else if (flag)
                {
                    this.AITotalSoldierHurt = (short)(this.AITotalSoldierHurt + first - end);
                }
                else
                {
                    this.HMTotalSoldierHurt = (short)(this.HMTotalSoldierHurt + first - end);
                }
            }
        }

        // 检查并执行附近区域的士兵战斗逻辑
        void void_L()
        {
            byte byte0 = this.smallSoldierCellX[0][0];
            byte byte1 = this.smallSoldierCellY[0][0];

            for (int i1 = byte0 + 1; i1 < byte0 + 4 && i1 <= 15; i1++)
            {
                for (int j1 = byte1 - 1; j1 < byte1 + 2; j1++)
                {
                    if (j1 >= 0)
                    {
                        if (j1 > 6)
                            break;

                        for (int k1 = 0; k1 < this.aiSmallSoldierNum; k1++)
                        {
                            if (this.smallSoldierCellX[1][k1] == i1 && this.smallSoldierCellY[1][k1] == j1)
                            {
                                if (k1 == 0)
                                {
                                    General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId);
                                    aiGeneral.decreaseCurPhysical((byte)(CommonUtils.getRandomInt() % 1));
                                    if (aiGeneral.getCurPhysical() <= 0)
                                    {
                                        this.smallSoldier_isSurvive[1][0] = false;
                                    }
                                }
                                else if (this.smallSoldier_isSurvive[1][k1])
                                {
                                    this.smallSoldierBlood[1][k1] = (short)(this.smallSoldierBlood[1][k1] - CommonUtils.getRandomInt() % 60 + 50);
                                    if (this.smallSoldierBlood[1][k1] <= 0)
                                    {
                                        this.smallWarCoordinate[this.smallSoldierCellY[1][k1]][this.smallSoldierCellX[1][k1]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[1][k1]][this.smallSoldierCellX[1][k1]] & 0x3F);
                                        this.smallSoldierBlood[1][k1] = 0;
                                        this.smallSoldier_isSurvive[1][k1] = false;
                                        this.smallSoldierCellX[1][k1] = 0;
                                        this.smallSoldierCellY[1][k1] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        // void_M 方法，执行士兵战斗逻辑
        void void_m()
        {
            byte byte0 = this.smallSoldierCellX[1][0]; // 获取第1个敌军士兵的X坐标
            byte byte1 = this.smallSoldierCellY[1][0]; // 获取第1个敌军士兵的Y坐标

            // 在敌军士兵附近的坐标范围内搜索
            for (int i1 = byte0 - 1; i1 > byte0 - 4 && i1 >= 0; i1--)
            {
                for (int j1 = byte1 - 1; j1 < byte1 + 2; j1++)
                {
                    if (j1 >= 0)
                    {
                        if (j1 > 6)
                            break;

                        // 检查所有我方士兵的位置
                        for (int k1 = 0; k1 < this.humanSmallSoldierNum; k1++)
                        {
                            if (this.smallSoldierCellX[0][k1] == i1 && this.smallSoldierCellY[0][k1] == j1)
                            {
                                // 处理第1个我方士兵
                                if (k1 == 0)
                                {
                                    General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // 获取玩家将领
                                    userGeneral.decreaseCurPhysical((byte)(CommonUtils.getRandomInt() % 21 + 30)); // 减少体力
                                    if (userGeneral.getCurPhysical() <= 0)
                                        this.smallSoldier_isSurvive[0][0] = false; // 如果体力耗尽，标记士兵死亡
                                }
                                else if (this.smallSoldier_isSurvive[0][k1])
                                {
                                    // 对其他士兵造成伤害
                                    this.smallSoldierBlood[0][k1] = (short)(this.smallSoldierBlood[0][k1] - (CommonUtils.getRandomInt() % 60 + 50));
                                    if (this.smallSoldierBlood[0][k1] <= 0)
                                    {
                                        // 如果士兵死亡，更新战斗地图并清除坐标
                                        this.smallWarCoordinate[this.smallSoldierCellY[0][k1]][this.smallSoldierCellX[0][k1]] = (byte)(this.smallWarCoordinate[this.smallSoldierCellY[0][k1]][this.smallSoldierCellX[0][k1]] & 0x3F);
                                        this.smallSoldierBlood[0][k1] = 0;
                                        this.smallSoldier_isSurvive[0][k1] = false;
                                        this.smallSoldierCellX[0][k1] = 0;
                                        this.smallSoldierCellY[0][k1] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // boolean_g 方法，判断AI是否撤退
        bool boolean_g()
        {
            byte CITY_NUM = getCanRetreatCityId(this.aiKingId); // 获取AI国王是否有可以撤退的城市
            byte byte0 = 0;
            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // 获取AI将领

            // 如果将领的体力或者忠诚度超过一定值，AI将不会撤退
            if (aiGeneral.getCurPhysical() > (int)(25.0 - aiGeneral.force * 1.7 / 10.0) || aiGeneral.getLoyalty() > 99)
                return false;

            // 检查周围的敌方单位，并计算撤退的可能性
            if (this.smallSoldierCellY[1][0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0] - 1][this.smallSoldierCellX[1][0]] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);
            if (this.smallSoldierCellY[1][0] < 6 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0] + 1][this.smallSoldierCellX[1][0]] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);
            if (this.smallSoldierCellX[1][0] > 0 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0]][this.smallSoldierCellX[1][0] - 1] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);
            if (this.smallSoldierCellX[1][0] < 15 && (this.smallWarCoordinate[this.smallSoldierCellY[1][0]][this.smallSoldierCellX[1][0] + 1] & 0x40) != 0)
                byte0 = (byte)(byte0 + 1);

            // 根据包围情况设置撤退概率
            if (byte0 == 4)
            {
                byte0 = 100;
            }
            else if (byte0 == 3)
            {
                byte0 = 80;
            }
            else if (byte0 == 2)
            {
                byte0 = 60;
            }
            else if (byte0 == 1)
            {
                byte0 = 20;
            }
            else
            {
                return false;
            }

            // 如果AI的力量或忠诚度较高，降低撤退的概率
            if ((aiGeneral.force > 95 || aiGeneral.getLoyalty() > 95) && CITY_NUM > 0)
            {
                byte0 = (byte)(byte0 - 50);
            }
            else if ((aiGeneral.force > 85 || aiGeneral.getLoyalty() > 85) && CITY_NUM > 0)
            {
                byte0 = (byte)(byte0 - 30);
            }
            else if ((aiGeneral.force > 75 || aiGeneral.getLoyalty() > 75) && CITY_NUM > 0)
            {
                byte0 = (byte)(byte0 - 20);
            }

            // 根据忠诚度进一步调整撤退概率
            if (byte0 > 0)
            {
                if (aiGeneral.getLoyalty() < 15)
                {
                    byte0 = (byte)(byte0 + 40);
                }
                else if (aiGeneral.getLoyalty() < 35)
                {
                    byte0 = (byte)(byte0 + 20);
                }
                else if (aiGeneral.getLoyalty() < 50)
                {
                    byte0 = (byte)(byte0 + 10);
                }
            }

            // 根据计算的撤退概率决定是否撤退
            return (CommonUtils.getRandomInt() % 100 < byte0);
        }


        // WarGeneralHpSoldierNum 方法，判断战斗中玩家或AI将领的状态，并进行相应处理
        void WarGeneralHpSoldierNum()
        {
            // 检查玩家士兵是否存活
            if (!this.smallSoldier_isSurvive[0][0])
            {
                General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // 获取玩家将领
                this.wjct = true; // 标记为玩家战败

                // 如果玩家将领体力耗尽
                if (userGeneral.getCurPhysical() <= 0)
                {
                    this.Z = 2; // 玩家失败标记
                }
                else
                {
                    this.Z = 6; // 玩家状态正常
                                // 如果玩家具备特定技能 单骑 且DJ为真
                    if (getSkill_3(this.HMGeneralId, 0) && this.DJ)
                    {
                        // 随机数判定是否发动特技
                        if (CommonUtils.getRandomInt() % 10 > 4)
                        {
                            this.ctsb = true; // 标记特技生效
                            this.ac = (byte)(CommonUtils.getRandomInt() % 5 + 1); // 计算体力消耗
                            if (this.ac >= userGeneral.getCurPhysical())
                            {
                                this.ac = userGeneral.getCurPhysical();
                                this.Z = 2; // 玩家失败标记
                            }
                            userGeneral.decreaseCurPhysical(this.ac); // 减少玩家将领的体力
                        }
                    }
                    // 其他情况下，普通随机判定
                    else if (CommonUtils.getRandomInt() % 10 > 1)
                    {
                        this.ctsb = true;
                        this.ac = (byte)(CommonUtils.getRandomInt() % 12 + 2); // 计算体力消耗
                        if (this.ac >= userGeneral.getCurPhysical())
                        {
                            this.ac = userGeneral.getCurPhysical();
                            this.Z = 2;
                        }
                        userGeneral.decreaseCurPhysical(this.ac);
                    }
                }
                return;
            }

            // 检查AI士兵是否存活
            if (!this.smallSoldier_isSurvive[1][0])
            {
                General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // 获取AI将领

                // 如果AI将领体力耗尽
                if (aiGeneral.getCurPhysical() <= 0)
                {
                    this.Z = 1; // AI失败标记
                }
                else
                {
                    this.Z = 5; // AI状态正常
                    if (getSkill_5(this.AIGeneralId, 7)) return; // 如果AI具备特定技能，提前结束

                    byte bytek = getCanRetreatCityId(this.aiKingId); // 获取AI是否有可以撤退的城市
                    if (bytek > 0)
                    {
                        // 如果AI体力较低
                        if (aiGeneral.getCurPhysical() <= 10)
                        {
                            this.ac = 0;
                        }
                        // 正常体力消耗计算
                        else if (CommonUtils.getRandomInt() % 10 > 4)
                        {
                            this.ac = (byte)(CommonUtils.getRandomInt() % 4 + 1);
                            if (this.ac >= aiGeneral.getCurPhysical())
                            {
                                this.ac = aiGeneral.getCurPhysical();
                                this.Z = 1; // AI失败标记
                            }
                            aiGeneral.decreaseCurPhysical(this.ac); // 减少AI将领的体力
                        }
                    }
                    // 其他随机体力消耗
                    else if (CommonUtils.getRandomInt() % 10 > 1)
                    {
                        this.ac = (byte)(CommonUtils.getRandomInt() % 12 + 2);
                        if (this.ac >= aiGeneral.getCurPhysical())
                        {
                            this.ac = aiGeneral.getCurPhysical();
                            this.Z = 1;
                        }
                        aiGeneral.decreaseCurPhysical(this.ac);
                    }
                }
            }
        }

        // AfterWarSettlement 方法，处理战斗结果并进行经验值分配
        void AfterWarSettlement()
        {
            short word0 = this.sd1;
            short word1 = this.sd2;

            General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // 获取玩家将领
            userGeneral.generalSoldier = 0; // 初始化玩家将领士兵数量

            // 统计玩家士兵剩余数量
            for (byte byte0 = 1; byte0 < this.humanSmallSoldierNum; byte0 = (byte)(byte0 + 1))
            {
                userGeneral.generalSoldier = (short)(userGeneral.generalSoldier + this.smallSoldierBlood[0][byte0]);
                if (userGeneral.generalSoldier > userGeneral.getMaxGeneralSoldier())
                    userGeneral.generalSoldier = userGeneral.getMaxGeneralSoldier(); // 确保不超过最大士兵数
            }

            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // 获取AI将领
            aiGeneral.generalSoldier = 0; // 初始化AI将领士兵数量

            // 统计AI士兵剩余数量
            for (byte byte1 = 1; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
            {
                aiGeneral.generalSoldier = (short)(aiGeneral.generalSoldier + this.smallSoldierBlood[1][byte1]);
                if (aiGeneral.generalSoldier > aiGeneral.getMaxGeneralSoldier())
                    aiGeneral.generalSoldier = aiGeneral.getMaxGeneralSoldier(); // 确保不超过最大士兵数
            }

            // 计算经验值差异
            int expHM = word1 - aiGeneral.generalSoldier;
            int expAI = word0 - userGeneral.generalSoldier;

            // 分配经验值
            addExp_P(this.HMGeneralId, this.AIGeneralId, expHM);
            addExp_P(this.AIGeneralId, this.HMGeneralId, expAI);

            // 增加领导和武力经验
            GeneralListCache.addLeadExp(this.HMGeneralId, (byte)(this.HMTotalSoldierHurt / 300));
            GeneralListCache.addLeadExp(this.AIGeneralId, (byte)(this.AITotalSoldierHurt / 300));
            GeneralListCache.addforceExp(this.HMGeneralId, (byte)(this.HMTotalGeneralHurt / 50));
            GeneralListCache.addforceExp(this.AIGeneralId, (byte)(this.AITotalGeneralHurt / 50));

            // 重置总伤害统计
            this.HMTotalSoldierHurt = 0;
            this.AITotalSoldierHurt = 0;
            this.HMTotalGeneralHurt = 0;
            this.AITotalGeneralHurt = 0;

            // 特定技能效果 攻心 处理
            if (getSkill_3(this.AIGeneralId, 6) && aiGeneral.generalSoldier > 0)
            {
                if (CommonUtils.getRandomInt() % 10 < 2)
                    aiGeneral.generalSoldier = (short)(aiGeneral.generalSoldier + expAI / 3);
                if (aiGeneral.generalSoldier > aiGeneral.getMaxGeneralSoldier())
                    aiGeneral.generalSoldier = aiGeneral.getMaxGeneralSoldier();
            }

            // 玩家特殊状态下的士兵交换处理
            if (this.wjct && this.ctsb)
            {
                if (userGeneral.generalSoldier > 0)
                {
                    int i = CommonUtils.getRandomInt() % 15 + 3;
                    this.jsbl = (short)(i * 15); // 计算交换的士兵数量

                    if (this.i_boolean_fld)
                        this.jsbl = (short)(this.jsbl + 250); // 特殊情况下增加交换数量

                    if (getSkill_5(this.AIGeneralId, 7))
                        this.jsbl = (short)(this.jsbl / 2); // 如果AI有特殊技能，减少交换量

                    if (userGeneral.generalSoldier < this.jsbl)
                        this.jsbl = userGeneral.generalSoldier;

                    userGeneral.generalSoldier = (short)(userGeneral.generalSoldier - this.jsbl); // 减少玩家士兵
                    if (userGeneral.generalSoldier < 0)
                        userGeneral.generalSoldier = 0;

                    aiGeneral.generalSoldier = (short)(aiGeneral.generalSoldier + this.jsbl); // 增加AI士兵
                    if (aiGeneral.generalSoldier > aiGeneral.getMaxGeneralSoldier())
                        aiGeneral.generalSoldier = aiGeneral.getMaxGeneralSoldier();
                }
                return;
            }

            // 如果玩家具有特定技能
            if (getSkill_3(this.HMGeneralId, 6) && userGeneral.generalSoldier > 0)
            {
                if (CommonUtils.getRandomInt() % 10 < 2)
                    userGeneral.generalSoldier = (short)(userGeneral.generalSoldier + expHM / 3);
                if (userGeneral.generalSoldier > userGeneral.getMaxGeneralSoldier())
                    userGeneral.generalSoldier = userGeneral.getMaxGeneralSoldier();
            }
        }



        // 方法: void_P
        public void void_P()
        {
            AfterWarSettlement(); // 调用 AfterWarSettlement 方法
            if (this.i_boolean_fld) // 判断 i_boolean_fld 是否为 true
            {
                this.j_byte_fld = 2; // 如果为 true，则 j_byte_fld 设置为 2
            }
            else
            {
                this.j_byte_fld = 3; // 否则设置为 3
            }
        }

        // 方法: newArray
        public byte[] newArray(byte Length)
        {
            byte[] array = new byte[Length]; // 创建一个长度为 Length 的 byte 数组
            for (byte i = 0; i < Length; i = (byte)(i + 1)) // 遍历数组并填充
                array[i] = i;
            return array; // 返回填充后的数组
        }

        // 方法: PrepareWarStancejgjbh
        public void PrepareWarStancejgjbh()
        {
            this.smallSoldierBlood[0][0] = (short)(300 * GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical() / (GeneralListCache.GetGeneral(this.HMGeneralId)).maxPhysical); // 计算 smallSoldierBlood 的值
            if (GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical() * 2 < (GeneralListCache.GetGeneral(this.HMGeneralId)).maxPhysical) // 判断当前体力是否小于最大体力的一半
                this.smallSoldierBlood[0][0] = 200; // 如果小于，则设置 smallSoldierBlood 的值为 200
        }


        // 方法：void_Q
        void void_Q()
        {
            // 设置单挑标志为 false
            this.singleFigth = false;

            // 创建双方士兵索引数组
            byte[] hmIndex = new byte[this.humanSmallSoldierNum];
            byte[] aiIndex = new byte[this.aiSmallSoldierNum];

            // 初始化和打乱数组
            hmIndex = newArray((byte)hmIndex.Length);
            aiIndex = newArray((byte)aiIndex.Length);
            hmIndex = randomArray(hmIndex);
            aiIndex = randomArray(aiIndex);

            // 如果 j_byte_fld 为 0，初始化战斗状态
            if (this.j_byte_fld == 0)
            {
                //this.gamecanvas.s_byte_fld = 0;
                this.aq = 0;
                this.d_int_fld = 0;

                // 判断 AI 是否攻击玩家
                if (this.aiAtkHm)
                {
                    this.ar = 1;
                }
                else
                {
                    this.ar = 0;
                }

                this.e_int_fld = 0;
                this.a_s = 0;
                this.ao = 0;
                this.ap = 0;
                this.at = 0;
            }
            else
            {
                // 重置 j_byte_fld
                this.j_byte_fld = 0;
            }

            // 获取当前系统时间，用于控制帧率
            long l1 = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

            // 进入主循环，直到 j_byte_fld 大于 0 为止
            bool outerLoop = true;
            while (this.j_byte_fld <= 0)
            {
                // 如果检测到玩家输入，处理输入
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_g();
                    //this.gamecanvas.setKeyValue((byte)0);

                    // 如果是单挑模式，执行相关操作
                    if (this.singleFigth)
                    {
                        void_S();
                        void_T();
                        //this.gamecanvas.s_void_b_a((byte)21);
                        //this.gamecanvas.battlefieldSatge = 2;
                    }
                }

                // 计算自上次循环的时间差
                long l2 = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond - l1;

                // 控制帧率，每次循环至少间隔 15 毫秒
                if (l2 < 15L)
                {
                    try
                    {
                        lock (this)
                        {
                            Thread.Sleep((int)(15L - l2));
                        }
                    }
                    catch (Exception exception) { }
                }

                // 重新绘制游戏画面
                //this.gamecanvas.repaint();

                // 更新当前时间
                l1 = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

                // 检查战斗状态
                if (this.ad != 2 && this.Z <= 0)
                {
                    if (this.aa != 0)
                    {
                        if (this.e_int_fld == 0)
                        {
                            this.e_int_fld = this.d_int_fld;
                            this.a_s = this.humanSmallSoldierNum;
                        }
                        else if (this.d_int_fld > this.e_int_fld && this.humanSmallSoldierNum >= this.a_s)
                        {
                            this.e_int_fld = this.d_int_fld;
                            this.aa = (byte)(this.aa - 1);

                            // 处理回合结束逻辑
                            if ((this.aa & 0xF) == 0)
                            {
                                this.aa = 0;
                                this.e_int_fld = 0;
                            }
                        }
                    }

                    // 更新回合计数
                    this.at = (byte)(this.at + 1);

                    // 检查是否可以进入下一阶段
                    if (!(Input.touchCount > 0))
                    {
                        if (this.ai > 0)
                        {
                            this.a_boolean_array2d_fld[this.al][this.am] = true;
                            this.ai = (byte)(this.ai - 1);

                            // AI 执行操作
                            if (this.ai == 0)
                            {
                                void_B_b(this.k_boolean_fld);
                                this.at = 0;
                                WarGeneralHpSoldierNum();

                                if (this.singleFigth)
                                {
                                    void_S();
                                    void_T();
                                    //this.gamecanvas.s_void_b_a((byte)21);
                                    //this.gamecanvas.battlefieldSatge = 2;
                                    this.singleFigth = false;
                                }
                            }
                            continue;
                        }

                        // 检查是否处于战斗阶段
                        if (!(Input.touchCount > 0))
                        {
                            if (this.at >= 10)
                            {
                                WarGeneralHpSoldierNum();
                                if (this.Z <= 0)
                                {
                                    this.at = 0;

                                    // 检查当前回合状态
                                    if (this.ar > 1)
                                    {
                                        this.d_int_fld++;
                                        hmIndex = randomArray(hmIndex);
                                        this.ao = 0;
                                        aiIndex = randomArray(aiIndex);
                                        this.ap = 0;
                                        this.ar = 0;
                                    }

                                    // 玩家执行操作
                                    if (this.ar != 0)
                                    {
                                        if (this.ar == 1)
                                        {
                                            this.n_boolean_fld = false;
                                            void_i_f(this.d_int_fld);

                                            while (true)
                                            {
                                                if (aiIndex[this.ap] == 0 && (this.aa & 0xF0) == 16)
                                                {
                                                    this.n_boolean_fld = boolean_b_m((byte)0);
                                                }
                                                else
                                                {
                                                    this.n_boolean_fld = boolean_b_o(aiIndex[this.ap]);
                                                }

                                                // 检查 AI 士兵是否存活，更新回合状态
                                                if (!this.smallSoldier_isSurvive[1][aiIndex[this.ap]] || this.smallSoldierKind[1][aiIndex[this.ap]] >= 2 || this.aq >= 1)
                                                {
                                                    this.ap = (byte)(this.ap + 1);
                                                    this.aq = 0;
                                                }
                                                else
                                                {
                                                    this.aq = (byte)(this.aq + 1);
                                                }

                                                // 检查 AI 士兵数组是否遍历完毕
                                                if (this.ap == this.aiSmallSoldierNum)
                                                {
                                                    this.aq = 0;
                                                    this.ar = 2;
                                                    outerLoop = false;  // 退出最外层循环
                                                }

                                                // 如果找到符合条件的AI士兵，继续当前回合
                                                if (this.n_boolean_fld)
                                                    outerLoop = false;  // 退出最外层循环
                                            }
                                        }
                                        continue;
                                    }

                                    // 玩家操作
                                    this.n_boolean_fld = false;
                                    while (true)
                                    {
                                        this.n_boolean_fld = boolean_b_i(hmIndex[this.ao]);

                                        // 检查玩家士兵是否存活
                                        if (!this.smallSoldier_isSurvive[0][hmIndex[this.ao]] || this.smallSoldierKind[0][hmIndex[this.ao]] >= 2 || this.aq >= 1)
                                        {
                                            this.ao = (byte)(this.ao + 1);
                                            this.aq = 0;
                                        }
                                        else
                                        {
                                            this.aq = (byte)(this.aq + 1);
                                        }

                                        // 检查玩家士兵数组是否遍历完毕
                                        if (this.ao == this.humanSmallSoldierNum)
                                        {
                                            this.aq = 0;
                                            this.ar = 1;

                                            // 检查是否需要进入下一回合
                                            if (boolean_g())
                                            {
                                                this.Z = 3;
                                                outerLoop = false;  // 退出最外层循环
                                            }

                                            // 更新回合状态
                                            if (this.ab == 0)
                                                outerLoop = false;  // 退出最外层循环

                                            if ((this.ab & 0xF) == 0)
                                            {
                                                this.ab = 0;
                                                outerLoop = false;  // 退出最外层循环
                                            }

                                            this.ab = (byte)(this.ab - 1);
                                            outerLoop = false;  // 退出最外层循环
                                        }

                                        // 如果找到符合条件的玩家士兵，继续当前回合
                                        if (this.n_boolean_fld)
                                            outerLoop = false;  // 退出最外层循环
                                    }
                                }
                            }
                            continue;
                        }

                        // 处理游戏画面状态
                        if (this.ag > 0 && (this.ag = (byte)(this.ag - 1)) == 0)
                        {
                            void_L();
                            //this.gamecanvas.v_boolean_fld = false;
                            this.at = 0;
                        }

                        if (this.ah > 0 && (this.ah = (byte)(this.ah - 1)) == 0)
                        {
                            void_m();
                            //this.gamecanvas.w_boolean_fld = false;
                        }
                    }
                }
            }

            // 重置AI攻击玩家状态
            this.aiAtkHm = false;
        }

        // 判断玩家与AI将领的对战结果
        bool boolean_ss_b(short userGeneralId, short aiGeneralId)
        {
            // 如果条件dttb为true，直接返回false，不执行后续逻辑
            if (this.dttb)
                return false;

            // 获取玩家与AI将领的力量差值，除以20用于计算概率
            int i1 = (GeneralListCache.GetGeneral(userGeneralId).force - GeneralListCache.GetGeneral(aiGeneralId).force) / 20;

            // 使用随机数生成器，判断是否满足指定概率条件
            // this.random是Java中的Random类，在C#中使用System.Random
            return (this.random.Next() % 10 < 4 + i1);
        }


        bool boolean_ss_gj_b(short word0, short word1)
        {
            // 获取双方将领的武力差并除以15作为影响因素
            int i1 = ((GeneralListCache.GetGeneral(word0)).force - (GeneralListCache.GetGeneral(word1)).force) / 15;

            // 通过随机数来判断结果
            return (this.random.Next() % 10 < 10 + i1);
        }

        byte byte_ss_a(short word0, short word1)
        {
            // 当前体力低于20且随机数为偶数，返回4
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < 20 && CommonUtils.getRandomInt() % 2 == 0)
                return 4;

            // 当前体力低于最大体力的一半且对方体力比自身高10，随机数小于3时返回2
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < GeneralListCache.GetGeneral(word0).maxPhysical / 2 &&
                GeneralListCache.GetGeneral(word1).getCurPhysical() - GeneralListCache.GetGeneral(word0).getCurPhysical() > 10 &&
                CommonUtils.getRandomInt() % 10 < 3)
                return 2;

            // 当前体力低于对方体力时，根据随机数返回0或1
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < GeneralListCache.GetGeneral(word1).getCurPhysical())
                return (byte)((CommonUtils.getRandomInt() % 10 >= 6) ? 0 : 1);

            // 否则根据随机数返回1或0
            return (byte)((CommonUtils.getRandomInt() % 10 >= 6) ? 1 : 0);
        }

        byte byte_ss_b(short word0, short word1)
        {
            // 调用AISingleOrder方法并返回结果
            return AISingleOrder(word0, word1);
        }

        byte weaponEffect(short atkGeneralId, short defGeneralId, byte sc, bool sm)
        {
            // 获取进攻方的武器类型和防守方的防具类型
            byte a = (GeneralListCache.GetGeneral(atkGeneralId)).weapon;
            byte b = (GeneralListCache.GetGeneral(defGeneralId)).armor;

            // 根据武器和防具的类型调整sc的值
            if (a == 5 && sm)
                sc = (byte)(sc + 20);
            if ((a == 6 || a == 7 || a == 14) && !sm)
                sc = (byte)(sc + 15);
            if (b == 30 && !sm)
                sc = (byte)(sc - 15);
            if (b == 31 && !sm)
                sc = (byte)(sc - 20);
            else if (b == 31 && sm)
                sc = 0;

            // 返回调整后的sc
            return sc;
        }

        byte getPercentage(short atkId, short defId, bool sm, bool HMatk)
        {
            byte sc = 0;
            byte weaponType1 = (byte)((GeneralListCache.GetGeneral(atkId)).weapon / 8);
            byte b = (byte)((GeneralListCache.GetGeneral(defId)).weapon / 8);

            // 根据双方的武器类型设置基础命中率
            if (weaponType1 == 0 && b == 0)
                sc = 70;
            else if (weaponType1 == 0 && b == 1)
                sc = 75;
            else if (weaponType1 == 0 && b == 2)
                sc = 60;
            else if (weaponType1 == 1 && b == 0)
                sc = 55;
            else if (weaponType1 == 1 && b == 1)
                sc = 60;
            else if (weaponType1 == 1 && b == 2)
                sc = 70;
            else if (weaponType1 == 2 && b == 0)
                sc = 80;
            else if (weaponType1 == 2 && b == 1)
                sc = 50;
            else if (weaponType1 == 2 && b == 2)
                sc = 60;

            // 根据攻击方式调整命中率
            if (HMatk)
                sc = (byte)(sc - 20);
            if (sm && HMatk)
                sc = (byte)(sc / 3);
            else if (sm && !HMatk)
                sc = (byte)(sc / 2);

            // 使用weaponEffect方法进一步调整命中率
            sc = weaponEffect(atkId, defId, sc, sm);

            // 返回最终的命中率
            return sc;
        }

        void void_S()
        {
            this.m_boolean_fld = false;

            // 检查AI将领是否符合特定ID并设置相关标志
            if (this.AIGeneralId == 1 || this.AIGeneralId == 4 || this.AIGeneralId == 24 || this.AIGeneralId == 30 || this.AIGeneralId == 40 || this.AIGeneralId == 61 || this.AIGeneralId == 69)
            {
                Country country = CountryListCache.GetCountryByKingId(this.AIGeneralId);
                if ((CityListCache.GetCityByCityId(curWarCityId)).cityBelongKing == country.countryKingId && country.GetHaveCityNum() <= 1)
                    this.m_boolean_fld = true;
            }

            // 记录双方的初始体力
            this.HMfirstPhy = GeneralListCache.GetGeneral(this.HMGeneralId).getCurPhysical();
            this.AIfirstPhy = GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical();
        }

        void void_B_c(bool flag)
        {
            // 根据flag的值设置不同阵营的士兵指令
            if (flag)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
            }
            else
            {
                this.smallSoldierOrder[0][0] = 2;
                for (byte byte1 = 0; byte1 < 4; byte1 = (byte)(byte1 + 1))
                    this.P_byte_array1d_fld[byte1] = 2;
            }
        }

        int obtainWeaponOrArmor()
        {
            // 如果m_boolean_fld为true，根据AI将领ID分配武器或防具
            if (this.m_boolean_fld)
            {
                if (this.AIGeneralId == 61)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 6;
                    return 0;
                }
                if (this.AIGeneralId == 4)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).armor = 31;
                    return 1;
                }
                if (this.AIGeneralId == 1)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 7;
                    return 2;
                }
                if (this.AIGeneralId == 24)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 5;
                    return 3;
                }
                if (this.AIGeneralId == 69 || this.AIGeneralId == 30 || this.AIGeneralId == 40)
                {
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).weapon = 14;
                    return 4;
                }
            }
            return 0;
        }


        // 定义方法 void_T，在Unity中运行
        void void_T()
        {
            //this.gamecanvas.s_void_b_a((byte)22); // 调用 gamecanvas 的方法
            while (true)
            {
                // 获取当前时间戳
                long l1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                // 检查按键输入
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_f(); // 调用清除键值的方法
                    //this.gamecanvas.setKeyValue((byte)0); // 重置键值为0
                }

                // 计算消耗的时间
                long l2 = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - l1;
                if (l2 < 500L)
                {
                    try
                    {
                        // 线程休眠，保证间隔
                        Thread.Sleep((int)(50L - l2));
                    }
                    catch (Exception exception) { }
                }

                // 重绘界面
                //this.gamecanvas.repaint();

                // 检查是否处于单人战斗状态
                if (!this.singleFigth)
                {
                    SingleFightaddforceExp(); // 增加战斗经验
                    return;
                }
            }
        }

        // 单人战斗中增加战斗经验的方法
        void SingleFightaddforceExp()
        {
            General userGeneral = GeneralListCache.GetGeneral(this.HMGeneralId); // 获取玩家的将领
            int userCurPhysical = 0;
            if (userGeneral != null)
                userCurPhysical = userGeneral.getCurPhysical(); // 获取玩家当前体力

            int aiCurPhysical = 0;
            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId); // 获取AI将领
            if (aiGeneral != null)
                aiCurPhysical = aiGeneral.getCurPhysical(); // 获取AI当前体力

            // 计算经验值
            int aiExp = (int)((this.HMfirstPhy - userCurPhysical) * 1.2D);
            int hmExp = this.AIfirstPhy - aiCurPhysical;
            aiExp /= 3;
            hmExp /= 3;

            // 设置经验值的下限和上限
            if (aiExp <= 0)
                aiExp = 2;
            if (hmExp < 0)
                hmExp = 0;
            if (aiExp >= 20)
                aiExp = 20;
            if (hmExp >= 20)
                hmExp = 20;

            // 添加将领经验
            GeneralListCache.addforceExp(this.AIGeneralId, (byte)aiExp);
            GeneralListCache.addforceExp(this.HMGeneralId, (byte)hmExp);

            // 重置初始体力
            this.HMfirstPhy = 0;
            this.AIfirstPhy = 0;
        }

        // 模拟人类与AI的战斗过程
        void hm_AI_Moni()
        {
            int hmpower = 0;  // 玩家战力
            int aipower = 0;  // AI战力
            int hmpf = 0;     // 玩家战力系数
            int aipf = 0;     // AI战力系数
            int i;

            // 玩家小兵战斗力计算
            for (i = 1; i < this.humanSmallSoldierNum; i++)
            {
                int theAtk = this.smallSoldierAtk[0][i];  // 小兵攻击力
                int theDef = this.smallSoldierDef[0][i];  // 小兵防御力

                // 检查技能触发并调整防御力
                if (getSkill_2(this.HMGeneralId, 7) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;
                if (getSkill_2(this.HMGeneralId, 8) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;

                // 检查第三个技能，增加攻击和防御力
                if (getSkill_3(this.HMGeneralId, 9))
                {
                    theAtk += theAtk / 2;
                    theDef += theDef / 2;
                }

                // 根据兵种调整战斗力
                if (this.smallSoldierKind[0][i] == 1)  // 兵种1的处理
                {
                    // 检查技能并增加攻击力
                    if (getSkill_2(this.HMGeneralId, 0) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.HMGeneralId, 1) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    // 特定地形加成
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.HMGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1) + theAtk * this.V / 8;
                    hmpower += p * p;
                }
                else if (this.smallSoldierKind[0][i] == 2)  // 兵种2的处理
                {
                    // 特定技能和地形加成
                    if (getSkill_2(this.HMGeneralId, 6) && CommonUtils.getRandomInt() % 10 > 3)
                        theAtk += theAtk / 2;
                    if (getSkill_2(this.HMGeneralId, 2) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.HMGeneralId, 3) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    // 地形与其他技能加成
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.HMGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if (this.warTerrain == 9 && getSkill_2(this.HMGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    // 根据当前的游戏状态进行处理
                    if (!this.i_boolean_fld && this.j_boolean_fld)
                    {
                        if (this.V >= 14)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 3);
                            hmpower += p * p;
                        }
                        else if (this.V >= 10)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 3);
                            hmpower += p * p;
                        }
                        else if (this.V >= 8)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 2);
                            hmpower += p * p;
                        }
                        else if (this.V >= 7)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 2);
                            hmpower += p * p;
                        }
                        else
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1);
                            hmpower += p * p;
                        }
                    }
                    else
                    {
                        int p = (theAtk + theDef) * 2 + theAtk * CommonUtils.getRandomInt() % 2 + theAtk * this.V / 7;
                        hmpower += p * p;
                    }
                }
                else  // 其他兵种处理
                {
                    // 特定地形加成
                    if (this.warTerrain == 9 && getSkill_2(this.HMGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.HMGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 / 3;
                    hmpower += p * p;
                }
            }

            // AI小兵战斗力计算，逻辑同上
            for (i = 1; i < this.aiSmallSoldierNum; i++)
            {
                int theAtk = this.smallSoldierAtk[1][i];
                int theDef = this.smallSoldierDef[1][i];

                if (getSkill_2(this.AIGeneralId, 7) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;
                if (getSkill_2(this.AIGeneralId, 8) && CommonUtils.getRandomInt() % 10 > 6)
                    theDef += theDef / 2;

                if (getSkill_3(this.AIGeneralId, 9))
                {
                    theAtk += theAtk / 2;
                    theDef += theDef / 2;
                }

                if (this.smallSoldierKind[1][i] == 1)
                {
                    if (getSkill_2(this.AIGeneralId, 0) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.AIGeneralId, 1) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.AIGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1) + theAtk * this.W / 8;
                    aipower += p * p;
                }
                else if (this.smallSoldierKind[1][i] == 2)
                {
                    if (getSkill_2(this.AIGeneralId, 6) && CommonUtils.getRandomInt() % 10 > 3)
                        theAtk += theAtk / 2;
                    if (getSkill_2(this.AIGeneralId, 2) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 2;
                    else if (getSkill_2(this.AIGeneralId, 3) && CommonUtils.getRandomInt() % 10 > 6)
                        theAtk += theAtk / 3;

                    if (this.warTerrain == 9 && getSkill_2(this.AIGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.AIGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    if (this.i_boolean_fld && this.j_boolean_fld)
                    {
                        if (this.W >= 14)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 3);
                            aipower += p * p;
                        }
                        else if (this.W >= 10)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 3);
                            aipower += p * p;
                        }
                        else if (this.W >= 8)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 3 + 2);
                            aipower += p * p;
                        }
                        else if (this.W >= 7)
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 2);
                            aipower += p * p;
                        }
                        else
                        {
                            int p = (theAtk + theDef) * 2 + theAtk * (CommonUtils.getRandomInt() % 2 + 1);
                            aipower += p * p;
                        }
                    }
                    else
                    {
                        int p = (theAtk + theDef) * 2 + theAtk * CommonUtils.getRandomInt() % 2 + theAtk * this.W / 7;
                        aipower += p * p;
                    }
                }
                else
                {
                    if (this.warTerrain == 9 && getSkill_2(this.AIGeneralId, 4) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;
                    if ((this.warTerrain == 10 || this.warTerrain == 11) && getSkill_2(this.AIGeneralId, 5) && CommonUtils.getRandomInt() % 10 > 8)
                        theAtk += theAtk / 2;

                    int p = (theAtk + theDef) * 2 / 3;
                    aipower += p * p;
                }
            }

            // 判断战斗结果
            if (hmpower > aipower)
            {
                // 玩家胜利
            }
            else if (hmpower < aipower)
            {
                // AI胜利
            }
            else
            {
                // 平局
            }
        }



        // 模拟战斗场景的主流程
        void void_U()
        {
            this.j_byte_fld = 0;  // 初始化状态标志
            //this.gamecanvas.finishMoni = false;  // 设置模拟战斗结束标志为false
            void_J();  // 调用方法J，初始化相关状态
            void_K();  // 调用方法K，初始化相关状态
            this.sd1 = GeneralListCache.GetGeneral(this.HMGeneralId).generalSoldier;  // 获取玩家将军的士兵信息
            this.sd2 = GeneralListCache.GetGeneral(this.AIGeneralId).generalSoldier;  // 获取AI将军的士兵信息

            // 如果模拟战斗已结束
            if (Input.touchCount > 0)
            {
                if (this.i_boolean_fld)  // 玩家胜利
                {
                    this.j_byte_fld = 2;
                }
                else  // AI胜利
                {
                    this.j_byte_fld = 3;
                }
                return;
            }

            this.j_byte_fld = 0;  // 重新初始化状态标志

            while (true)
            {
                this.l_boolean_fld = false;  // 复位标志
                void_Q();  // 调用方法Q，处理当前循环逻辑

                // 判断战斗状态
                if (this.j_byte_fld != 1)
                {
                    if (this.j_byte_fld == 2)
                    {
                        void_P();  // 如果战斗结束，调用方法P处理结束逻辑
                        return;
                    }
                }
            }
        }

        // 判断将军是否死亡，并进行相应处理
        bool GeneralDie(short generalId, bool isUser)
        {
            if (isUser)  // 如果是玩家的将军死亡
            {
                if (generalId == this.humanGeneralId_inWar[0])  // 判断玩家的主要将军是否死亡
                {
                    this.bxct = true;  // 设置战斗结束标志
                    this.j_byte_fld = 2;  // 设置战斗状态为结束
                    this.h_boolean_fld = true;  // 设置玩家胜利标志
                    this.humanUnitTrapped[0] = 3;  // 将玩家的主要将军标记为已陷落
                    this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] & 0x3F);  // 更新战场坐标

                    if (this.humanGeneralId_inWar[0] == this.userKingId)  // 如果死亡的是玩家的国王
                        GeneralListCache.GeneralDie(generalId);  // 调用缓存，处理将军死亡逻辑

                    for (byte b1 = 0; b1 < this.aiGeneralNum_inWar; b1++)  // 解救AI被困的将军
                    {
                        if (this.aiUnitTrapped[b1] == 2)
                            this.aiUnitTrapped[b1] = 0;
                    }

                    this.N_byte_fld = 1;
                    byte byte1;

                    // 循环查找仍然存活的玩家将军
                    for (byte1 = 1; byte1 < this.humanGeneralNum_inWar && this.humanUnitTrapped[byte1] != 0 && this.humanUnitTrapped[byte1] <= 3;)
                        byte1++;

                    if (byte1 < this.humanGeneralNum_inWar)  // 如果还有存活的将军
                    {
                        FindRetreatCity(curWarCityId);  // 处理当前城市相关逻辑
                        this.N_byte_fld = byte1;  // 更新存活将军编号
                        this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];  // 设置新的玩家将军
                        //this.gamecanvas.void_c();  // 更新UI显示
                        //this.gamecanvas.void_B_a(true);  // 更新战斗状态
                        //this.gamecanvas.k_boolean_fld = false;  // 重置标志
                        //this.gamecanvas.l_boolean_fld = true;  // 更新标志
                    }
                    else  // 如果玩家将军全部阵亡
                    {
                        if (this.AIAttackHM)  // 如果AI在攻击玩家
                            void_z();  // 调用AI攻击结束逻辑
                        void_A();  // 调用战斗结束逻辑
                        return false;
                    }
                }

                // 检查其他玩家将军是否阵亡
                for (byte index = 1; index < this.humanGeneralNum_inWar; index++)
                {
                    if (this.humanGeneralId_inWar[index] == generalId)
                    {
                        this.humanUnitTrapped[index] = 3;  // 将死亡的将军标记为陷落
                        this.bigWar_coordinate[this.humanUnitCellY[index],this.humanUnitCellX[index]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[index],this.humanUnitCellX[index]] & 0x3F);  // 更新战场坐标
                        return true;
                    }
                }
            }
            else  // 如果是AI将军死亡
            {
                if (generalId == this.aiGeneralId_inWar[0])  // 判断AI主要将军是否死亡
                {
                    this.j_byte_fld = 2;  // 设置战斗状态为结束
                    this.aiUnitTrapped[0] = 3;  // 将AI主要将军标记为已陷落
                    this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] & 0x3F);  // 更新战场坐标

                    // 解救玩家被困的将军
                    for (byte b = 1; b < this.humanGeneralNum_inWar; b++)
                    {
                        if (this.humanUnitTrapped[b] == 2)
                            this.humanUnitTrapped[b] = 0;
                    }

                    //this.gamecanvas.r_byte_fld = 5;  // 更新游戏UI标志
                    return true;
                }

                // 检查其他AI将军是否阵亡
                for (byte index = 1; index < this.aiGeneralNum_inWar; index++)
                {
                    if (this.aiGeneralId_inWar[index] == generalId)
                    {
                        this.aiUnitTrapped[index] = 3;  // 将AI将军标记为陷落
                        this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] & 0x3F);  // 更新战场坐标
                        return true;
                    }
                }
            }

            return true;  // 默认返回true表示处理结束
        }


        // 处理将军是否被困或死亡的逻辑
        bool boolean_sB_b(short generalId, bool isUser)
        {
            if (isUser)  // 如果是玩家
            {
                if (generalId == this.humanGeneralId_inWar[0])  // 如果是玩家的主要将军
                {
                    this.bxct = true;  // 设置战斗结束标志
                    this.j_byte_fld = 2;  // 更新战斗状态
                    this.h_boolean_fld = true;  // 设置玩家胜利标志
                    this.humanUnitTrapped[0] = 2;  // 标记玩家将军已被困
                    this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[0],this.humanUnitCellX[0]] & 0x3F);  // 更新战场坐标

                    // 解救AI被困将军
                    for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0++)
                    {
                        if (this.aiUnitTrapped[byte0] == 2)
                            this.aiUnitTrapped[byte0] = 0;
                    }

                    this.N_byte_fld = 1;
                    byte byte1;
                    // 查找下一个未被困的将军
                    for (byte1 = 1; byte1 < this.humanGeneralNum_inWar && this.humanUnitTrapped[byte1] != 0 && this.humanUnitTrapped[byte1] <= 3;)
                        byte1++;

                    if (byte1 < this.humanGeneralNum_inWar)  // 如果还有未被困的将军
                    {
                        FindRetreatCity(curWarCityId);  // 处理当前城市的逻辑
                        this.N_byte_fld = byte1;  // 更新玩家将军编号
                        this.HMGeneralId = this.humanGeneralId_inWar[this.N_byte_fld];  // 设置新的玩家将军
                        //this.gamecanvas.void_c();  // 更新UI
                        //this.gamecanvas.void_B_a(true);  // 更新战斗状态
                        //this.gamecanvas.k_boolean_fld = false;  // 重置标志
                        //this.gamecanvas.l_boolean_fld = true;  // 更新标志
                    }
                    else  // 玩家将军全部被困
                    {
                        if (this.AIAttackHM)
                            void_z();  // AI攻击结束逻辑
                        void_A();  // 战斗结束逻辑
                        return false;
                    }
                }

                // 检查其他玩家将军是否被困
                for (byte byte2 = 1; byte2 < this.humanGeneralNum_inWar; byte2++)
                {
                    if (this.humanGeneralId_inWar[byte2] == generalId)
                    {
                        this.humanUnitTrapped[byte2] = 2;  // 将军被困
                        this.bigWar_coordinate[this.humanUnitCellY[byte2],this.humanUnitCellX[byte2]] = (byte)(this.bigWar_coordinate[this.humanUnitCellY[byte2],this.humanUnitCellX[byte2]] & 0x3F);  // 更新战场坐标
                        return true;
                    }
                }
            }
            else  // 如果是AI将军
            {
                if (generalId == this.aiGeneralId_inWar[0])  // 检查AI主要将军是否被困
                {
                    this.j_byte_fld = 2;  // 战斗状态更新
                    this.aiUnitTrapped[0] = 2;  // AI将军被困
                    this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[0],this.aiUnitCellX[0]] & 0x3F);  // 更新战场坐标

                    // 解救玩家被困的将军
                    for (byte byte3 = 1; byte3 < this.humanGeneralNum_inWar; byte3++)
                    {
                        if (this.humanUnitTrapped[byte3] == 2)
                            this.humanUnitTrapped[byte3] = 0;
                    }

                    //this.gamecanvas.r_byte_fld = 5;  // 更新游戏状态
                    return true;
                }

                // 检查其他AI将军是否被困
                for (byte index = 1; index < this.aiGeneralNum_inWar; index++)
                {
                    if (this.aiGeneralId_inWar[index] == generalId)
                    {
                        this.aiUnitTrapped[index] = 2;  // AI将军被困
                        this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] = (byte)(this.bigWar_coordinate[this.aiUnitCellY[index],this.aiUnitCellX[index]] & 0x3F);  // 更新战场坐标
                        return true;
                    }
                }
            }
            return true;  // 默认返回true，表示处理结束
        }

        // 处理不同情况的将军死亡逻辑
        bool boolean_h()
        {
            Country country;
            bool isCountry;
            byte countryId;
            bool result = false;

            switch (this.Z)
            {
                case 1:  // 处理AI将军死亡逻辑
                    country = CountryListCache.GetCountryByKingId(this.AIGeneralId);  // 获取AI将军所属国家
                    isCountry = false;
                    countryId = 0;

                    if (country != null)  // 如果找到国家信息
                    {
                        countryId = country.countryId;
                        isCountry = true;
                    }

                    result = GeneralDie(this.AIGeneralId, false);  // AI将军死亡处理
                    GameInfo.chooseGeneralName = GeneralListCache.GetGeneral(this.AIGeneralId).generalName;  // 记录将军姓名
                    GeneralListCache.GeneralDie(this.AIGeneralId);  // 将军死亡缓存更新

                    if (isCountry)  // 如果AI将军为国王
                    {
                        short newKingGeneralId = CountryListCache.GetCountryByCountryId(countryId).countryKingId;  // 获取新的国王
                        if (this.AIAttackHM)
                        {
                            this.e_short_fld = newKingGeneralId;
                        }
                        else
                        {
                            this.f_short_fld = newKingGeneralId;
                        }
                        this.aiKingId = newKingGeneralId;  // 更新AI国王ID
                    }
                    return result;

                case 2:  // 处理玩家将军死亡逻辑
                    result = GeneralDie(this.HMGeneralId, true);
                    GameInfo.chooseGeneralName = GeneralListCache.GetGeneral(this.HMGeneralId).generalName;
                    GeneralListCache.GeneralDie(this.HMGeneralId);
                    return result;

                case 3:  // 处理AI将军被困逻辑
                    return boolean_sB_b(this.AIGeneralId, false);

                case 4:  // 处理玩家将军被困逻辑
                    return boolean_sB_b(this.HMGeneralId, true);
            }

            return true;  // 默认返回true
        }

        // 战斗场景的结束处理
        void void_V()
        {
            //this.gamecanvas.B_boolean_fld = true;  // 更新战斗状态
            //this.gamecanvas.s_void_b_a((byte)17);  // 调用场景切换逻辑
            this.j_byte_fld = 0;  // 重置战斗状态
            GameTurn();  // 调用结束逻辑
        }

        // 战斗胜利的处理
        void void_W()
        {
            //this.gamecanvas.B_boolean_fld = true;  // 更新战斗状态
            //this.gamecanvas.s_void_b_a((byte)16);  // 调用胜利场景切换逻辑
            this.j_byte_fld = 0;  // 重置战斗状态
            GameTurn();  // 调用结束逻辑
        }

        // 设置战斗中的标志位
        void void_b_f(byte byte0)
        {
            //this.gamecanvas.s_void_b_a((byte)20);  // 更新战斗状态
            //this.gamecanvas.r_byte_fld = byte0;  // 设置场景状态
            this.j_byte_fld = 0;  // 重置战斗状态
            void_B();  // 调用更新逻辑
        }


        // 处理战斗循环的逻辑
        void void_X()
        {
            this.HMGeneralId = 0;  // 重置玩家将军ID
            void_x();  // 调用战斗相关的逻辑
            void_B();  // 更新游戏状态
            this.j_byte_fld = 0;  // 重置战斗状态
            this.bxct = false;  // 重置战斗结束标志

            // 无限循环处理战斗状态
            while (true)
            {
                void_I();  // 执行战斗中的某个操作

                // 如果战斗状态为2或3，处理相关逻辑
                if (this.j_byte_fld == 2 || this.j_byte_fld == 3)
                {
                    byte byte0 = this.j_byte_fld;
                    void_U();  // 调用某个战斗操作
                    //this.gamecanvas.s_void_b_a((byte)20);  // 切换战斗场景
                    //this.gamecanvas.void_c();  // 更新UI
                    this.j_byte_fld = byte0;

                    // 检查将军是否死亡
                    if (!boolean_h())
                        this.j_byte_fld = 4;  // 更新战斗状态
                    //this.gamecanvas.repaint();  // 刷新画面
                    continue;
                }

                // 处理战斗状态为5的情况
                if (this.j_byte_fld == 5)
                {
                    this.j_byte_fld = 0;
                    void_V();  // 执行战斗结束后的处理

                    // 根据不同状态设置相应的标志位
                    switch (this.j_byte_fld)
                    {
                        case 1:
                            void_b_f((byte)11);  // 设置状态11
                            break;
                        case 2:
                            void_b_f((byte)10);  // 设置状态10
                            break;
                        case 3:
                            void_b_f((byte)12);  // 设置状态12
                            break;
                        case 4:
                            void_b_f((byte)13);  // 设置状态13
                            break;
                    }
                    this.j_byte_fld = 5;  // 重置战斗状态
                    //this.gamecanvas.void_c();  // 更新UI
                    continue;
                }

                // 处理战斗状态不为6的情况
                if (this.j_byte_fld != 6)
                {
                    if (this.j_byte_fld > 0)
                        break;  // 如果状态大于0，退出循环
                    continue;  // 否则继续循环
                }

                void_W();  // 执行战斗胜利的处理

                // 根据不同状态设置相应的标志位
                switch (this.j_byte_fld)
                {
                    case 1:
                        void_b_f((byte)14);  // 设置状态14
                        break;
                    case 2:
                        void_b_f((byte)10);  // 设置状态10
                        break;
                }
                this.j_byte_fld = 6;  // 重置战斗状态
                //this.gamecanvas.void_c();  // 更新UI
            }
        }

        // AI攻击玩家的逻辑
        void AIattackUser()
        {
            void_Y();  // 执行AI攻击前的初始化
            this.HMGeneralId = 0;  // 重置玩家将军ID
            void_B();  // 更新游戏状态
            this.j_byte_fld = 0;  // 重置战斗状态
            this.curAIindex = 0;  // 重置AI索引
            this.bxct = false;  // 重置战斗结束标志

            // 无限循环处理战斗状态
            while (true)
            {
                void_I();  // 执行战斗中的某个操作

                // 如果战斗状态为2或3，处理相关逻辑
                if (this.j_byte_fld == 2 || this.j_byte_fld == 3)
                {
                    byte byte0 = this.j_byte_fld;
                    void_U();  // 调用某个战斗操作
                    //this.gamecanvas.s_void_b_a((byte)20);  // 切换战斗场景
                    //this.gamecanvas.void_c();  // 更新UI
                    this.j_byte_fld = byte0;

                    // 检查将军是否死亡
                    if (!boolean_h())
                        this.j_byte_fld = 4;  // 更新战斗状态
                    continue;
                }

                // 处理战斗状态为5的情况
                if (this.j_byte_fld == 5)
                {
                    this.j_byte_fld = 0;
                    void_V();  // 执行战斗结束后的处理

                    // 根据不同状态设置相应的标志位
                    switch (this.j_byte_fld)
                    {
                        case 1:
                            void_b_f((byte)11);  // 设置状态11
                            break;
                        case 2:
                            void_b_f((byte)10);  // 设置状态10
                            break;
                        case 3:
                            void_b_f((byte)12);  // 设置状态12
                            break;
                        case 4:
                            void_b_f((byte)13);  // 设置状态13
                            break;
                    }
                    this.j_byte_fld = 5;  // 重置战斗状态
                    //this.gamecanvas.void_c();  // 更新UI
                    continue;
                }

                // 处理战斗状态不为6的情况
                if (this.j_byte_fld != 6)
                {
                    if (this.j_byte_fld > 0)
                        break;  // 如果状态大于0，退出循环
                    continue;  // 否则继续循环
                }

                void_W();  // 执行战斗胜利的处理

                // 根据不同状态设置相应的标志位
                switch (this.j_byte_fld)
                {
                    case 1:
                        void_b_f((byte)14);  // 设置状态14
                        break;
                    case 2:
                        void_b_f((byte)10);  // 设置状态10
                        break;
                }
                this.j_byte_fld = 6;  // 重置战斗状态
                //this.gamecanvas.void_c();  // 更新UI
            }
        }

        // 攻击逻辑
        void void_Y()
        {
            this.j_byte_fld = 0;  // 重置战斗状态
            this.B_byte_fld = this.tarCity;  // 设置目标城市
            curWarCityId = this.curCity;  // 当前战斗城市ID
            WarInfo.curWarCityId = curWarCityId;  // 更新全局战斗城市ID
            City curWarCity = CityListCache.GetCityByCityId(this.curCity);  // 获取当前城市对象
            this.f_short_fld = curWarCity.cityBelongKing;  // 获取城市所属的国王
            this.userKingId = this.f_short_fld;  // 设置玩家国王ID
            this.e_short_fld = (CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId;  // 获取AI国王ID
            this.aiKingId = this.e_short_fld;  // 设置AI国王ID

            // 如果选择的将军数量少于10，选择AI城市的将军
            if (this.chooseGeneralNum < 10)
            {
                City aiCity = CityListCache.GetCityByCityId(this.tarCity);  // 获取目标城市对象
                short[] connectCityId = aiCity.connectCityId;  // 获取与目标城市相连的城市ID
                for (int i = 0; i < connectCityId.Length || this.chooseGeneralNum >= 10; i++)  // 遍历连接城市
                {
                    byte cityId = (byte)connectCityId[i];  // 获取城市ID
                    City city = CityListCache.GetCityByCityId(cityId);  // 获取城市对象

                    // 如果城市属于AI国王
                    if (city.cityBelongKing == this.aiKingId)
                    {
                        // 如果城市中的将军数量少于2，且选择的将军数量小于10，继续选择将军
                        while ((city.getCityOfficeGeneralIdArray()).Length < 2 && this.chooseGeneralNum < 10)
                        {
                            short generalId = city.getMaxBattlePowerGeneralId();  // 获取战斗力最高的将军

                            // 如果将军是AI国王
                            if (generalId == this.aiKingId)
                            {
                                short otherGeneralId = this.chooseGeneralIdArray[0];  // 替换第一位将军
                                this.chooseGeneralIdArray[this.chooseGeneralNum] = otherGeneralId;
                                this.chooseGeneralIdArray[0] = generalId;
                            }
                            else
                            {
                                this.chooseGeneralIdArray[this.chooseGeneralNum] = generalId;  // 选择将军
                            }

                            this.chooseGeneralNum = (byte)(this.chooseGeneralNum + 1);  // 增加选择的将军数量
                            city.removeOfficeGeneralId(generalId);  // 移除将军
                        }
                        city.AppointmentPrefect();  // 任命地方长官
                    }
                }
            }

            // 设置战斗信息
            this.humanGeneralNum_inWar = curWarCity.getCityGeneralNum();  // 获取玩家城市中的将军数量
            this.aiGeneralNum_inWar = this.chooseGeneralNum;  // AI选择的将军数量

            // 设置AI参战将军ID
            for (byte byte0 = 0; byte0 < this.aiGeneralNum_inWar; byte0 = (byte)(byte0 + 1))
                this.aiGeneralId_inWar[byte0] = this.chooseGeneralIdArray[byte0];

            // 设置玩家参战将军ID
            short[] officeGeneralIdArray = curWarCity.getCityOfficeGeneralIdArray();
            for (byte byte1 = 0; byte1 < this.humanGeneralNum_inWar; byte1 = (byte)(byte1 + 1))
                this.humanGeneralId_inWar[byte1] = officeGeneralIdArray[byte1];

            // 设置玩家的战斗资源
            this.humanMoney_inWar = curWarCity.GetMoney();  // 玩家资金
            this.humanGrain_inWar = curWarCity.GetFood();  // 玩家粮食
            this.AIAttackHM = true;  // AI是否攻击玩家

            // 初始化战斗状态
            for (byte byte2 = 0; byte2 < this.humanGeneralNum_inWar; byte2 = (byte)(byte2 + 1))
                this.humanUnitTrapped[byte2] = 0;  // 玩家单位未陷入

            for (byte byte3 = 0; byte3 < this.aiGeneralNum_inWar; byte3 = (byte)(byte3 + 1))
                this.aiUnitTrapped[byte3] = 0;  // AI单位未陷入

            // 初始化战斗轮次等信息
            this.I_byte_fld = 1;
            this.J_byte_fld = 1;
            this.K_byte_fld = 1;
            this.L_byte_fld = 1;
            this.day = 0;
            this.F_byte_fld = 0;
            this.g_boolean_fld = true;
            this.N_byte_fld = 0;

            // 设置玩家移动加成
            setHunmanMoveBonus();

            // 执行战斗初始化
            PrepareWarStance();
            //this.gamecanvas.void_b();  // 更新游戏画布
            //this.gamecanvas.void_a();  // 刷新界面
            //this.gamecanvas.void_i();  // 初始化战斗UI
        }

        // 游戏循环逻辑，主要用于处理游戏内的用户操作与界面刷新
        IEnumerator GameTurn()
        {
            float l1 = Time.time * 1000;  // 获取当前系统时间（以毫秒为单位）

            while (true)
            {
                // 检测玩家输入的按键
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_e();  // 执行按键处理

                    // 如果游戏状态未改变
                    if (Input.touchCount > 0) { }
                        //this.gamecanvas.setKeyValue((byte)0);  // 重置按键值
                }

                // 检测战斗状态
                if (this.j_byte_fld <= 0)
                {
                    // 计算上次循环的耗时，使用 Unity 的时间系统
                    float l2 = (Time.time * 1000) - l1;

                    if (l2 < 100f)  // 如果耗时小于100毫秒
                    {
                        // 确保循环间隔不低于100毫秒
                        yield return new WaitForSeconds((100f - l2) / 1000f);
                    }

                    //this.gamecanvas.repaint();  // 刷新游戏画面

                    l1 = Time.time * 1000;  // 更新循环开始时间
                    continue;  // 继续下一次循环
                }

                // 如果战斗状态大于0，退出循环
                break;
            }
        }



        // 设置目标城市
        void SelectTarCity()
        {
            this.p_byte_fld = this.tarCity;  // 将目标城市ID存储到p_byte_fld
        }

        // 切换到某个画布状态，并调用GameTurn进行刷新
        void void_ad()
        {
            //this.gamecanvas.s_void_b_a((byte)7);  // 切换到画布状态7
            GameTurn();  // 调用刷新方法
        }

        // 继承逻辑处理，循环检测当前将军状态
        void InheritCanvas()
        {
            this.X = 22;  // 设置X为22
            Country humanCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);  // 获取玩家国家
            this.tarCity = humanCountry.getCity(0);  // 获取玩家国家的第一个城市作为目标城市
            this.d_boolean_fld = true;  // 标记为真，表示某个状态激活
            while (true)
            {
                SelectTarCity();  // 设置目标城市
                this.j_byte_fld = 0;  // 重置j_byte_fld
                void_ad();  // 切换画布并刷新
                if (this.j_byte_fld <= 1)
                {
                    this.j_byte_fld = 0;  // 重置状态
                    continue;  // 继续循环
                }
                break;  // 退出循环
            }
            City city = CityListCache.GetCityByCityId(this.tarCity);  // 根据城市ID获取城市对象
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // 获取城市中的将军ID数组
            for (int i = 0; i < officeGeneralIdArray.Length; i++)  // 遍历将军ID
            {
                if (this.HMGeneralId == officeGeneralIdArray[i])  // 如果发现指定的将军
                {
                    humanCountry.Inherit(this.HMGeneralId);  // 玩家国家继承该将军
                    this.j_byte_fld = 0;  // 重置状态
                    //this.gamecanvas.s_void_b_a((byte)4);  // 切换到状态4
                    return;
                }
            }
            humanCountry.Inherit();  // 如果没有指定的将军，直接继承
            this.j_byte_fld = 0;  // 重置状态
            //this.gamecanvas.s_void_b_a((byte)4);  // 切换到状态4
        }

        // 国家交替处理
        void NewCountryTurnCanvas(byte byte0, short newcountryKingId)
        {
            //this.gamecanvas.NewCountryTurnCanvas(byte0, newcountryKingId);  // 更新画布状态
            GameTurn();  // 刷新
            this.j_byte_fld = 0;  // 重置状态
        }

        // 处理国家灭亡逻辑
        void CountryDieCanvas()
        {
            //this.gamecanvas.s_void_b_a((byte)4);  // 切换到状态4
            this.j_byte_fld = 0;  // 重置状态
            if (GameInfo.countryDieTips == 1)
            {
                NewCountryTurnCanvas((byte)6, (short)0);  // 切换状态并处理
            }
            else if (GameInfo.countryDieTips == 2)
            {
                NewCountryTurnCanvas((byte)6, (short)0);
                InheritCanvas();  // 调用继承逻辑
                GameInfo.ShowInfo = GameInfo.ShowInfo + "新君主" + (GeneralListCache.GetGeneral((CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)).generalName + " 继位!";  // 更新信息
                NewCountryTurnCanvas((byte)6, (short)0);  // 切换状态并处理
            }
            else if (GameInfo.countryDieTips == 3)
            {
                this.userOrderNum = 1;  // 设置用户指令
                NewCountryTurnCanvas((byte)5, (short)0);  // 切换状态
                this.j_byte_fld = 99;  // 设置状态为99
                return;
            }
            else if (GameInfo.countryDieTips == 4)
            {
                NewCountryTurnCanvas((byte)6, (short)0);  // 切换状态
            }
            GameInfo.countryDieTips = 0;  // 重置国家灭亡提示
            this.j_byte_fld = 4;  // 更新状态为4
        }

        // 处理粮食和资金
        void foodMoneyDea1()
        {
            if (this.curTurnsCountryId == GameInfo.humanCountryId)  // 如果是玩家国家的回合
            {
                this.fmoney = CityListCache.GetCityByCityId(this.tarCity).GetMoney();  // 获取资金
                this.ffood = CityListCache.GetCityByCityId(this.tarCity).GetFood();  // 获取粮食
            }
        }

        // 检查粮食和资金变化
        void foodMoneyDea2()
        {
            if (this.ffood > CityListCache.GetCityByCityId(this.tarCity).GetFood() || this.fmoney > CityListCache.GetCityByCityId(this.tarCity).GetMoney())  // 如果粮食或资金减少
            {
                CityListCache.GetCityByCityId((byte)37).SetFood((short)0);  // 设置某个城市的粮食为0
                return;
            }
        }

        // 处理玩家操作
        IEnumerator userDoSomething()
        {
            if (GameInfo.isWatch)  // 如果是观察状态，直接返回
                yield break;

            if (this.j_byte_fld == 0)  // 初始状态
            {
                this.userOrderNum = GameInfo.GetUserOrderNum();  // 获取用户指令编号
                this.X = 0;
                this.Y = 0;
                FindTarCity();  // 执行某个操作
                //this.gamecanvas.calculationUserKingIndex();  // 计算玩家国王索引
                //this.gamecanvas.repaint();  // 刷新画布
                //this.gamecanvas.void_e();  // 处理按键事件
            }
            else if (this.j_byte_fld == 2)
            {
                InitiateCanvasMark();  // 执行某个操作
                this.j_byte_fld = 0;  // 重置状态
            }
            else if (this.j_byte_fld == 4)
            {
                this.j_byte_fld = 0;  // 重置状态
                EndDecreaseOrder();  // 执行某个操作
            }

            float l1 = Time.time * 1000;  // 获取当前时间（毫秒）

            while (true)
            {
                // 检查按键输入
                if (Input.touchCount > 0)
                {
                    //this.gamecanvas.void_e();  // 处理按键事件

                    // 如果游戏状态未改变
                    if (Input.touchCount > 0) { }
                        //this.gamecanvas.setKeyValue((byte)0);  // 重置按键值
                }

                if (this.j_byte_fld <= 0)
                {
                    // 计算时间差
                    float l2 = (Time.time * 1000) - l1;

                    if (l2 < 20f)  // 确保每帧的最小间隔为20毫秒
                    {
                        // 使用协程控制等待
                        yield return new WaitForSeconds((20f - l2) / 1000f);
                    }

                    //this.gamecanvas.repaint();  // 刷新画布
                    l1 = Time.time * 1000;  // 更新时间
                    continue;
                }

                // 如果条件不符合，退出循环
                break;
            }
        }


        // 冒泡排序算法
        public byte[] bubbleSort(byte[] args)
        {
            for (int i = 0; i < args.Length - 1; i++)
            {
                for (int j = i + 1; j < args.Length; j++)
                {
                    if (args[i] < args[j])  // 比较大小并交换
                    {
                        byte temp = args[i];
                        args[i] = args[j];
                        args[j] = temp;
                    }
                }
            }
            return args;  // 返回排序后的数组
        }

        // 处理回合顺序，是否刷新国家状态
        void turnsort(bool isFlush)
        {
            byte[] havecitys = CountryListCache.getCountryIdArrayBySort();  // 获取排序后的国家ID数组
            this.countryOrder = new byte[CountryListCache.getCountrySize()];  // 初始化国家顺序数组
            for (int i = 0; i < havecitys.Length; i++)
            {
                Country country = CountryListCache.GetCountryByCountryId(havecitys[i]);
                if (country.GetHaveCityNum() <= 0)  // 如果国家没有城市
                {
                    this.countryOrder[i] = 0;  // 设置顺序为0
                    country.isTurns = 0;  // 标记为不参与回合
                }
                else if (isFlush)
                {
                    this.countryOrder[i] = havecitys[i];  // 设置顺序为国家ID
                    country.isTurns = 1;  // 标记为参与回合
                }
                else if (country.isTurns == 0)
                {
                    this.countryOrder[i] = 0;  // 不参与回合
                }
                else
                {
                    this.countryOrder[i] = havecitys[i];  // 参与回合
                }
            }
        }


        // 获取当前执行的国家ID
        private byte getCurrentExecutionCountryId()
        {
            for (int i = 0; i < this.countryOrder.Length; i++)  // 遍历国家顺序数组
            {
                Country country = CountryListCache.GetCountryByCountryId(this.countryOrder[i]);  // 根据国家ID获取国家对象
                if (country != null && country.isTurns == 1)  // 如果国家存在并且轮到其回合
                {
                    this.curTurnsCountryId = this.countryOrder[i];  // 更新当前轮到的国家ID
                    country.isTurns = 0;  // 标记该国家的回合已执行
                    return this.countryOrder[i];  // 返回国家ID
                }
            }
            return (byte)0;  // 如果没有国家可执行，返回0
        }

        // 主回合处理逻辑
        void TurnTestCanvas()
        {
            if (this.j_byte_fld != 2)  // 如果状态不是2
                turnsort(true);  // 执行国家顺序排序
            this.au = 0;  // 初始化变量
            while (true)
            {
                if (this.j_byte_fld == 0)  // 如果状态为0
                {
                    int i = getCurrentExecutionCountryId();  // 获取当前执行的国家ID
                    if (i == 0)  // 如果没有国家可执行
                        break;  // 退出循环
                    this.gdcs = 0;  // 重置计数器
                    this.bngd = false;  // 重置标志位
                    if (this.au == this.curTurnsCountryId && this.curTurnsCountryId != 0)  // 如果当前国家已经执行过且ID不为0
                        continue;  // 继续循环
                }
                if (this.curTurnsCountryId <= 0)  // 如果当前轮到的国家ID不合法
                {
                    this.curTurnsCountryId = this.au;  // 恢复为前一个国家ID
                    continue;  // 继续循环
                }
                this.au = this.curTurnsCountryId;  // 保存当前国家ID
                if (this.curTurnsCountryId == GameInfo.humanCountryId)  // 如果是玩家国家
                {
                    userDoSomething();  // 执行玩家的操作
                    if (this.o_boolean_fld)
                        this.o_boolean_fld = false;
                    if (this.j_byte_fld == 3)
                        this.j_byte_fld = 0;
                    if (this.j_byte_fld != 4)
                        continue;
                    void_X();  // 执行特定逻辑
                    CountryDieCanvas();  // 处理战斗后的结算
                    this.gdcs = (byte)(this.gdcs + 1);  // 增加计数器
                    if (this.gdcs >= 2)  // 如果超过两次回合
                        this.bngd = true;  // 标记为特殊状态
                    if (this.j_byte_fld == 99)  // 如果状态为99
                    {
                        this.j_byte_fld = 0;
                        return;  // 结束函数
                    }
                    continue;
                }
                //this.gamecanvas.repaint();  // 刷新画布
                System.Console.WriteLine(GeneralListCache.GetGeneral(CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).countryKingId).generalName + "开始执行任务");  // 输出日志
                //this.gamecanvas.serviceRepaints();  // 触发重绘服务
                long l1 = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;  // 获取当前时间
                this.j_byte_fld = 0;
                AITurns(this.curTurnsCountryId);  // AI执行回合
                this.j_byte_fld = 0;
                long l2 = (System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - l1;  // 计算时间差
                if (l2 >= 2000L)
                    continue;
                try
                {
                    lock (this)  // 使用同步块确保线程安全
                    {
                        System.Threading.Thread.Sleep((int)2000L - (int)l2);  // 保证AI回合时间至少为2000毫秒
                    }
                }
                catch (System.Exception) { }
            }
        }

        // AI执行回合的逻辑
        void AITurns(byte curTurnsCountryId)
        {
            byte orderNum = CountryListCache.getAIOredrNum(curTurnsCountryId);  // 获取AI指令数
            this.warNum = 2;  // 初始化战争次数
            while (this.AIUseOrderNum < orderNum)  // 当AI未执行完所有指令时
            {
                this.AIUseOrderNum = (byte)(this.AIUseOrderNum + 1);  // 增加已执行指令数
                this.X = 0;  // 初始化AI状态
                this.tarCity = 0;  // 初始化目标城市
                this.curCity = 0;  // 初始化当前城市
                System.GC.Collect();  // 强制进行垃圾回收
                alliance(curTurnsCountryId);  // 执行结盟
                AiStartInterior(curTurnsCountryId);  // 开始内政处理
                aiDoSearchGen(curTurnsCountryId);  // AI搜索将领
                Country country1 = CountryListCache.GetCountryByCountryId(curTurnsCountryId);  // 获取当前国家
                country1.mustShangRen();  // 强制商人交易
                AIConscription();  // AI进行征兵
                country1.Boolean_R();  // 执行某个布尔操作
                country1.transportMoney();  // AI进行资金运输

                if (AiFindLowLoyaltyGeneral())  // 如果满足某个条件
                    AiRewardGeneral();  // 执行相应操作

                if (this.AIUseOrderNum < orderNum && this.warNum > 0)  // 如果AI还有指令未执行且还有战争次数
                {
                    byte num = (orderNum - this.AIUseOrderNum > this.warNum) ? this.warNum : (byte)(orderNum - this.AIUseOrderNum);  // 计算当前战争次数
                    if (AIThinkWar(curTurnsCountryId, num) && warRand(num))  // 如果AI决定战争且符合随机条件
                    {
                        this.warNum = (byte)(this.warNum - 1);  // 减少战争次数
                        startWar();  // 开始战争
                        if (this.j_byte_fld == 3)
                        {
                            AIattackUser();  // AI攻击玩家
                            CountryDieCanvas();  // 执行战斗后的结算
                            if (this.j_byte_fld == 99)
                            {
                                this.j_byte_fld = 0;
                                return;  // 如果状态为99，结束函数
                            }
                        }
                        continue;  // 继续执行下一个回合
                    }
                }
                AIConscription();  // AI进行额外的征兵
                if (canTreatment())  // 如果可以进行治疗
                {
                    AiTreat();  // 执行治疗操作
                    continue;  // 继续执行下一个回合
                }
                AiFindLowLoyaltyGeneral();  // 执行某个操作
                if (this.X == 8)  // 如果AI状态为8
                {
                    AiRewardGeneral();  // 执行特定操作
                    continue;  // 继续执行下一个回合
                }
                AiStartInterior(curTurnsCountryId);  // 继续进行内政处理
            }
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);  // 获取当前国家
            byte CITY_NUM = country.GetHaveCityNum();  // 获取国家拥有的城市数
            for (int i = 0; i < CITY_NUM; i++)  // 遍历所有城市
            {
                byte cityId = country.getCity(i);  // 获取城市ID
                City city = CityListCache.GetCityByCityId(cityId);  // 获取城市对象
                if (city.GetMoney() <= 100)  // 如果城市资金少于等于100
                    city.AddMoney((short)MathUtils.getRandomInt(20));  // 增加城市资金
                if (city.GetFood() <= 300)  // 如果城市粮食少于等于300
                    city.AddFood((short)MathUtils.getRandomInt(100));  // 增加城市粮食
                if (isUprising(cityId))  // 如果城市发生起义
                {
                    short prefectId = city.prefectId;  // 获取城市太守ID
                    General general = GeneralListCache.GetGeneral(prefectId);  // 获取将领对象
                    Country oldCountry = CountryListCache.GetCountryByKingId(city.cityBelongKing);  // 获取旧国家
                    oldCountry.RemoveCity(cityId);  // 从旧国家移除该城市
                    CITY_NUM = (byte)(CITY_NUM - 1);  // 更新城市数量
                    i--;  // 调整索引以处理城市数量变化
                    Country newCountry = new Country();  // 创建新国家
                    newCountry.countryId = (byte)(CountryListCache.getCountrySize() + 1);  // 设置新国家ID
                    newCountry.countryKingId = general.generalId;  // 设置新国家的国王ID
                    city.prefectId = general.generalId;  // 设置城市的太守为该将领
                    newCountry.AddCity(cityId);  // 新国家添加城市
                    this.AIGeneralId = general.generalId;  // 更新AI将领ID
                    this.eventId = 20;  // 设置事件ID
                    RefreshFeedBack((byte)19);  // 执行特定操作
                    FloodDisasterCanvans();  // 处理事件
                    CountryListCache.AddCountry(newCountry);  // 将新国家添加到国家缓存
                    byte[] tempCountryOrder = new byte[this.countryOrder.Length + 1];  // 创建临时数组以包含新国家
                    for (int j = 0; j < this.countryOrder.Length; j++)
                        tempCountryOrder[j] = this.countryOrder[j];  // 复制旧国家顺序
                    tempCountryOrder[tempCountryOrder.Length - 1] = newCountry.countryId;  // 添加新国家
                    this.countryOrder = tempCountryOrder;  // 更新国家顺序
                    System.Console.WriteLine(general.generalName + "在" + city.cityName + "起义！");  // 输出起义日志
                }
            }
            if (this.j_byte_fld != 3)  // 如果状态不是3
                this.AIUseOrderNum = 0;  // 重置AI已用指令数
        }


        // 执行结盟操作
        private void alliance(byte countryId)
        {
            // 获取指定ID的国家
            Country country = CountryListCache.GetCountryByCountryId(countryId);
            // 获取该国家拥有的城市数量
            byte CityNum = country.GetHaveCityNum();
            // 如果城市数量大于3，则无需结盟
            if (CityNum > 3)
                return;

            // 获取该国家拥有的所有城市ID
            byte[] cityIds = country.GetCities();
            int qz = 0;  // 记录是否有城市与其他国家结盟

            // 遍历所有城市
            for (int i = 0; i < cityIds.Length; i++)
            {
                byte cityId = cityIds[i];
                // 获取城市对象
                City city = CityListCache.GetCityByCityId(cityId);
                // 获取该城市连接的城市ID
                short[] connectCityId = city.connectCityId;

                // 遍历连接的城市
                for (int m = 0; m < connectCityId.Length; m++)
                {
                    // 获取连接城市的所属国王ID
                    short kingId = (CityListCache.GetCityByCityId((byte)connectCityId[m])).cityBelongKing;
                    // 获取该国王所属的国家
                    Country otherCountry = CountryListCache.GetCountryByKingId(kingId);

                    // 如果其他国家存在且其ID为人类国家ID
                    if (otherCountry != null && otherCountry.countryId == GameInfo.humanCountryId)
                    {
                        qz++;  // 增加结盟计数
                        break;  // 跳出循环
                    }
                }
            }

            // 如果没有找到可结盟的国家且随机值大于10，则无需结盟
            if (qz == 0 && MathUtils.getRandomInt(100) > 10)
                return;

            // 计算结盟阈值
            byte gl = (byte)(8 - MathUtils.pow(2, CityNum - 1) + CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).GetHaveCityNum());
            int k = MathUtils.getRandomInt(100);
            gl = (byte)(gl + qz);

            // 如果结盟阈值小于随机值，则无需结盟
            if (gl < k)
                return;

            // 获取没有结盟的国家ID数组
            byte[] noAllianceCountryId = country.GetNoCountryIdAllianceCountryIdArray();
            // 如果没有没有结盟的国家，则返回
            if (noAllianceCountryId.Length < 1)
                return;

            Country allianceCountry = null;  // 记录要结盟的国家
            int dPhase = 0;  // 记录最小的相位差
                                // 获取当前国家国王
            General countryKing = GeneralListCache.GetGeneral(country.countryKingId);

            // 遍历没有结盟的国家
            for (int j = 0; j < noAllianceCountryId.Length; j++)
            {
                byte otherCountryId = noAllianceCountryId[j];
                // 获取其他国家
                Country otherCountry = CountryListCache.GetCountryByCountryId(otherCountryId);
                if (otherCountry != null && otherCountryId != GameInfo.humanCountryId)
                {
                    // 获取其他国家国王
                    General otherCountryKing = GeneralListCache.GetGeneral(otherCountry.countryKingId);
                    if (otherCountryKing != null)
                    {
                        // 计算当前国家国王和其他国家国王的相位差
                        int d1 = GetdPhase(countryKing.phase, otherCountryKing.phase);
                        if (dPhase == 0 || dPhase > d1)
                        {
                            dPhase = d1;  // 更新最小的相位差
                            allianceCountry = otherCountry;  // 记录当前最适合结盟的国家
                        }
                    }
                }
            }

            // 如果没有找到适合结盟的国家，则返回
            if (allianceCountry == null)
                return;

            // 如果相位差加上被结盟国家的城市数小于随机值
            if (dPhase + allianceCountry.GetHaveCityNum() <= MathUtils.getRandomInt(75))
            {
                // 执行结盟操作
                country.AddAlliance(allianceCountry.countryId);
                // 输出结盟成功的日志
                System.Console.WriteLine(countryKing.generalName + "势力与" + (GeneralListCache.GetGeneral(allianceCountry.countryKingId)).generalName + "势力同盟成功！");
                // 更新游戏信息显示
                GameInfo.ShowInfo = countryKing.generalName + "势力与" + (GeneralListCache.GetGeneral(allianceCountry.countryKingId)).generalName + "达成同盟！";
                this.eventId = 21;  // 设置事件ID
                RefreshFeedBack((byte)19);  // 执行特定操作
                FloodDisasterCanvans();  // 处理事件
            }
        }


        // 判断城市是否发生叛乱
        private bool isUprising(byte cityId)
        {
            // 获取指定ID的城市
            City city = CityListCache.GetCityByCityId(cityId);
            // 获取城市的督察ID
            short prefectId = city.prefectId;
            // 获取督察的将军
            General general = GeneralListCache.GetGeneral(prefectId);
            // 获取城市所属的国家
            Country oldCountry = CountryListCache.GetCountryByKingId(city.cityBelongKing);

            // 如果将军的忠诚度大于90或者城市的所属国王ID等于督察ID，则不叛乱
            if (general.getLoyalty() > 90 || city.cityBelongKing == city.prefectId)
                return false;

            // 计算忠诚度
            int loyalty = 100 - general.getLoyalty();
            // 获取城市所属国王的将军
            General kingGeneral = GeneralListCache.GetGeneral(city.cityBelongKing);
            // 计算将军的阶段差
            int phase = GetdPhase(general.phase, kingGeneral.phase);

            // 如果忠诚度小于10或阶段差小于5，则不叛乱
            if (loyalty < 10 || phase < 5)
                return false;

            // 计算叛乱的临界值
            int x = loyalty - 5 + phase / 2 - oldCountry.GetHaveCityNum() - getMoral(kingGeneral) - CountryListCache.getCountrySize() / 2;
            x /= 2;

            // 如果计算出的值小于等于0，则不叛乱
            if (x <= 0)
                return false;

            // 随机值除以临界值
            int m = MathUtils.getRandomInt(100) / x;
            // 如果随机值大于0，则不叛乱
            if (m > 0)
                return false;

            // 获取城市连接的所有城市ID
            short[] cityIdArray = city.connectCityId;
            int maxAtkPower = 0;

            // 遍历连接城市，找出最大攻击力
            for (int i = 0; i < cityIdArray.Length; i++)
            {
                short tempCityId = cityIdArray[i];
                City tempCity = CityListCache.GetCityByCityId((byte)tempCityId);
                int atkPower = tempCity.getMaxAtkPower();
                if (atkPower > maxAtkPower)
                    maxAtkPower = atkPower;
            }

            // 如果城市的防御能力小于最大攻击力的70%，则不叛乱
            if (city.GetDefenseAbility() < maxAtkPower * 0.7f)
                return false;

            return true;
        }

        // 获取将军的德望值
        public int getMoral(General general)
        {
            int moral = general.moral - 80;
            int result = moral / 9;
            return result;
        }

        // 判断是否为特定事件
        bool DisasterRate_i()
        {
            // 判断当前月份是否在3月到11月之间
            if (GameInfo.month < 11 && GameInfo.month > 2)
            {
                // 随机生成一个0到499之间的整数，并判断是否小于4
                int i1 = CommonUtils.getRandomInt() % 500;
                return (i1 < 4);
            }
            return false;
        }

        // 判断是否为特定事件
        bool DisasterRate_j()
        {
            // 随机生成一个0到499之间的整数，并判断是否小于等于1
            return (CommonUtils.getRandomInt() % 500 <= 1);
        }

        // 计算某值
        int FloodDisasterLoss(int i1, byte byte0, int j1)
        {
            i1 /= 2;
            return byte0 * i1 / j1;
        }


        // 处理城市的洪水灾难
        private void FloodDisaster(byte byte0)
        {
            // 获取指定ID的城市
            City city = CityListCache.GetCityByCityId(byte0);

            // 如果城市的洪水控制小于90
            if (city.floodControl < 90)
            {
                // 减少城市的金钱、食物和统治力
                city.DecreaseMoney((short)FloodDisasterLoss(city.GetMoney(), city.floodControl, 90));
                city.DecreaseFood((short)FloodDisasterLoss(city.GetFood(), city.floodControl, 90));
                city.rule = (byte)(city.rule - FloodDisasterLoss(city.rule, city.floodControl, 90));
            }

            // 如果城市的洪水控制小于99
            if (city.floodControl < 99)
            {
                // 减少城市的贸易和农业
                city.trade = (short)(city.trade - FloodDisasterLoss(city.trade, city.floodControl, 99));
                city.agro = (short)(city.agro - FloodDisasterLoss(city.agro, city.floodControl, 99));
            }

            // 如果城市的洪水控制大于0
            if (city.floodControl > 0)
                // 减少洪水控制值，每次减少1/10加1
                city.floodControl = (byte)(city.floodControl - city.floodControl / 10 + 1);
        }

        // 执行其他操作并设置事件ID
        private void FloodDisasterCanvans()
        {
            void_bb();
            RefreshFeedBack((byte)4);
        }

        /// <summary>
        /// 处理城市的洪水灾害
        /// </summary>
        /// <param name="byte0"></param>
        private void DisasterHurt(byte byte0)
        {
            // 获取指定ID的城市
            City city = CityListCache.GetCityByCityId(byte0);
            // 获取城市中的将军ID数组
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 如果城市的洪水控制小于90
            if (city.floodControl < 90)
            {
                // 遍历城市中的将军，减少将军的士兵数量
                for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]);
                    general.generalSoldier = (short)(general.generalSoldier - FloodDisasterLoss(general.generalSoldier, city.floodControl, 90));
                }
                // 减少城市储备士兵数量和统治力
                city.cityReserveSoldier -= FloodDisasterLoss(city.cityReserveSoldier, city.floodControl, 90);
                city.rule = (byte)(city.rule - FloodDisasterLoss(city.rule, city.floodControl, 90));
            }

            // 如果城市的洪水控制小于99
            if (city.floodControl < 99)
                // 减少城市人口
                city.population -= FloodDisasterLoss(city.population, city.floodControl, 99);

            // 如果城市的洪水控制大于0
            if (city.floodControl > 0)
                // 减少洪水控制值，每次减少1/10加1
                city.floodControl = (byte)(city.floodControl - city.floodControl / 10 + 1);
        }

        // 判断城市是否会发生叛乱
        private bool IsRebelDisaster(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            if (city.rule < 15)
            {
                // 计算叛乱发生的概率
                int i1 = city.rule * 10 / 15 + 80;
                if (CommonUtils.getRandomInt() % 100 >= i1)
                    return true;
            }
            else if (city.rule < 30)
            {
                int j1 = (city.rule - 15) / 3 + 90;
                if (CommonUtils.getRandomInt() % 100 >= j1)
                    return true;
            }
            else if (city.rule < 40)
            {
                int k1 = (city.rule - 30) / 5 + 98;
                if (CommonUtils.getRandomInt() % 100 >= k1)
                    return true;
            }
            else if (city.rule < 60)
            {
                int l1 = (city.rule - 40) / 5 + 998;
                if (CommonUtils.getRandomInt() % 1000 >= l1)
                    return true;
            }
            return false;
        }

        // 随机减少城市的统治力
        private void DecreaseCityRule(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            city.rule = (byte)((city.rule - CommonUtils.getRandomInt() % 15));
            if (city.rule < 0)
                city.rule = 0;
        }

        // 计算一个整数值
        private int RebelDisasterLoss(int word0, int i1, int j1)
        {
            int k1 = word0 * i1 / j1;
            if (k1 > 0)
                return (short)(word0 - CommonUtils.getRandomInt() % k1);
            return word0;
        }

        // 计算一个短整型值
        private short RebelDisasterLoss(short word0, int i1, int j1)
        {
            int k1 = word0 * i1 / j1;
            if (k1 > 0)
                return (short)(word0 - CommonUtils.getRandomInt() % k1);
            return word0;
        }

        /// <summary>
        /// 处理城市的统治度控制钱粮
        /// </summary>
        /// <param name="cityId"></param>
        private void RebelDisasterLowRule(byte cityId)
        {
            int i1 = 0;
            // 获取指定ID的城市
            City city = CityListCache.GetCityByCityId(cityId);
            // 获取城市中的将军ID数组
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 根据城市的统治度来处理不同的情况
            if (city.rule < 15)
            {
                // 统治度小于15，城市的各种资源减少
                city.population /= 3;
                city.agro = (short)(city.agro / 3);
                city.trade = (short)(city.trade / 3);
                city.SetMoney((short)(city.GetMoney() / 2));
                city.SetFood((short)(city.GetFood() / 2));
                DecreaseCityRule(cityId);
                city.cityReserveSoldier = RebelDisasterLoss(city.cityReserveSoldier, 2, 3);
                for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]);
                    general.generalSoldier = RebelDisasterLoss(general.generalSoldier, 2, 3);
                    i1 += general.generalSoldier;
                }
            }
            else if (city.rule < 30)
            {
                // 统治度在15到30之间，城市的各种资源减少
                city.population /= 2;
                city.agro = (short)(city.agro / 2);
                city.trade = (short)(city.trade / 2);
                city.SetMoney((short)(city.GetMoney() * 3 / 7));
                city.SetFood((short)(city.GetFood() * 3 / 7));
                DecreaseCityRule(cityId);
                city.cityReserveSoldier = RebelDisasterLoss(city.cityReserveSoldier, 1, 2);
                for (byte byte2 = 0; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]);
                    general.generalSoldier = RebelDisasterLoss(general.generalSoldier, 1, 2);
                    i1 += general.generalSoldier;
                }
            }
            else
            {
                // 统治度在30以上，城市的各种资源减少
                city.population = city.population * 2 / 3;
                city.agro = (short)(city.agro * 2 / 3);
                city.trade = (short)(city.trade * 2 / 3);
                city.SetMoney((short)(city.GetMoney() * 1 / 7));
                city.SetFood((short)(city.GetFood() * 1 / 7));
                DecreaseCityRule(cityId);
                city.cityReserveSoldier = RebelDisasterLoss(city.cityReserveSoldier, 1, 5);
                for (byte byte3 = 0; byte3 < city.getCityGeneralNum(); byte3 = (byte)(byte3 + 1))
                {
                    General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte3]);
                    general.generalSoldier = RebelDisasterLoss(general.generalSoldier, 1, 5);
                    i1 += general.generalSoldier;
                }
            }
        }

        /// <summary>
        /// 计算某种资源的影响值
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="j1"></param>
        /// <param name="k1"></param>
        /// <returns></returns>
        private int FoodIncome(int i1, int j1, int k1)
        {
            int l1 = k1 / 100;
            int i2 = l1 * i1 * 4 / 5 / 125;
            l1 += i2;
            i2 = 0;
            if (j1 > 90)
            {
                i2 += l1 * 4 / 5;
            }
            else if (j1 > 80)
            {
                i2 += l1 * 3 / 5;
            }
            else if (j1 > 70)
            {
                i2 += l1 * 2 / 5;
            }
            else if (j1 > 50)
            {
                i2 += l1 / 5;
            }
            l1 += i2;
            return l1;
        }

        /// <summary>
        /// 计算金钱收入
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="rule"></param>
        /// <param name="population"></param>
        /// <returns></returns>
        private int MoneyIncome(int trade, int rule, int population)
        {
            int l1 = population / 400;
            l1++;
            int i2 = l1 * trade * 3 / 5 / 125;
            l1 += i2;
            i2 = 0;
            if (rule > 90)
            {
                i2 += l1 * 4 / 5;
            }
            else if (rule > 80)
            {
                i2 += l1 * 3 / 5;
            }
            else if (rule > 70)
            {
                i2 += l1 * 2 / 5;
            }
            else if (rule > 50)
            {
                i2 += l1 / 5;
            }
            l1 += i2;
            return l1;
        }

        /// <summary>
        /// 定期收获金钱
        /// </summary>
        /// <param name="byte0"></param>
        private void RegularGiveOutMoney(byte byte0)
        {
            // 获取指定ID的城市
            City city = CityListCache.GetCityByCityId(byte0);
            // 获取城市中的将军ID数组
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            // 计算金钱收入
            int i1 = MoneyIncome(city.trade, city.rule, city.population);

            // 如果有将军拥有特定技能，则金钱收入增加50%
            for (int i = 0; i < city.getCityGeneralNum(); i++)
            {
                short id = officeGeneralIdArray[i];
                if (GetSkill_4(id, 5))
                {
                    i1 += i1 / 2;
                    break;
                }
            }

            // 如果城市不属于玩家国家，则金钱收入增加20%
            if (city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                i1 = (int)(i1 * 1.2D);

            // 添加金钱到城市
            city.AddMoney((short)i1);
        }

        /// <summary>
        /// 定期收获食物
        /// </summary>
        /// <param name="byte0"></param>
        private void RegularGiveOutFood(byte byte0)
        {
            // 获取指定ID的城市
            City city = CityListCache.GetCityByCityId(byte0);
            // 计算食物产量
            int getnum = FoodIncome(city.agro, city.rule, city.population);
            // 获取城市中的将军ID数组
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 如果有将军拥有特定技能，则食物产量增加50%
            for (int i = 0; i < city.getCityGeneralNum(); i++)
            {
                short id = officeGeneralIdArray[i];
                if (GetSkill_4(id, 5))
                {
                    getnum += getnum / 2;
                    break;
                }
            }

            // 如果城市不属于玩家国家，则食物产量增加20%
            if (city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                getnum = (int)(getnum * 1.2D);

            // 添加食物到城市
            city.AddFood((short)getnum);
        }


        /// <summary>
        /// 检查所有城市是否都属于玩家国家的国王
        /// </summary>
        /// <returns></returns>
        private bool UserhaveAllCity()
        {
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                // 获取城市的所属国王ID，并与玩家国家的国王ID进行比较
                if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                    return false; // 如果有任何一个城市的国王ID不匹配，则返回false
            }
            return true; // 所有城市都属于玩家国家的国王，返回true
        }

        /// <summary>
        /// 检查玩家国家是否没有城市
        /// </summary>
        /// <returns></returns>
        private bool UserhaveNoneCity()
        {
            Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            // 如果玩家国家存在且拥有的城市数量不为0，则返回false，否则返回true
            return !(userCountry != null && userCountry.GetHaveCityNum() != 0);
        }

        /// <summary>
        /// 随机改变城市的状态
        /// </summary>
        /// <param name="byte0"></param>
        private void RandomChangeCity(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);

            // 根据年份决定不同的随机操作
            if (GameInfo.years <= 194)
            {
                int i1 = CommonUtils.getRandomInt() % 4;
                int j1 = CommonUtils.getRandomInt() % 5 + 1;
                switch (i1)
                {
                    case 0:
                        city.agro = (short)(city.agro + j1);
                        if (city.agro > 999)
                            city.agro = 999; // 确保agro值不会超过999
                        break;
                    case 1:
                        city.trade = (short)(city.trade + j1);
                        if (city.trade > 999)
                            city.trade = 999; // 确保trade值不会超过999
                        break;
                    case 2:
                        city.population += j1 * 1000;
                        if (city.population > 990000)
                            city.population = 990000; // 确保population值不会超过990000
                        break;
                    case 3:
                        city.floodControl = (byte)(city.floodControl + j1 / 2 + 8);
                        if (city.floodControl > 99)
                            city.floodControl = 99; // 确保floodControl值不会超过99
                        break;
                }
                j1 = CommonUtils.getRandomInt() % 3 + 1;
                if (city.rule < 30)
                {
                    city.rule = (byte)(city.rule + j1 + 8);
                }
                else if (city.rule < 40)
                {
                    city.rule = (byte)(city.rule + j1 + 2);
                }
                else if (city.rule < 80)
                {
                    city.rule = (byte)(city.rule + j1);
                }
            }
            else
            {
                int i1 = CommonUtils.getRandomInt() % 2;
                int j1 = CommonUtils.getRandomInt() % 5 + 1;
                switch (i1)
                {
                    case 0:
                        city.floodControl = (byte)(city.floodControl + j1 / 2 + 8);
                        if (city.floodControl > 99)
                            city.floodControl = 99; // 确保floodControl值不会超过99
                        break;
                    case 1:
                        city.population += j1 * 500;
                        if (city.population > 990000)
                            city.population = 990000; // 确保population值不会超过990000
                        break;
                }
                j1 = CommonUtils.getRandomInt() % 3 + 1;
                if (city.rule < 30)
                {
                    city.rule = (byte)(city.rule + j1 + 6);
                }
                else if (city.rule < 40)
                {
                    city.rule = (byte)(city.rule + j1 + 2);
                }
                else if (city.rule < 80)
                {
                    city.rule = (byte)(city.rule + j1);
                }
            }
            // 确保rule值不会超过99
            if (city.rule > 99)
                city.rule = 99;
        }

        /// <summary>
        /// 对所有国家的城市进行某些操作
        /// </summary>
        private void RandomChangeAllCity()
        {
            for (byte i1 = 1; i1 < 8; i1 = (byte)(i1 + 1))
            {
                Country country = CountryListCache.GetCountryByCountryId(i1);
                if (country.countryId > 0 && country.countryId != GameInfo.humanCountryId)
                    for (int j1 = 0; j1 < country.GetHaveCityNum(); j1++)
                        RandomChangeCity(country.getCity(j1)); // 对每个城市调用RandomChangeCity
            }
        }

        /// <summary>
        /// 对玩家国家进行自动内政
        /// </summary>
        private void AutoInterior()
        {
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            // 如果玩家国家不存在或拥有的城市少于10个，则返回
            if (country == null || country.GetHaveCityNum() < 10)
                return;

            for (int index = 0; index < country.GetHaveCityNum(); index++)
            {
                City city = CityListCache.GetCityByCityId(country.getCity(index));
                if (city.GetMoney() >= 40)
                    if (CommonUtils.getRandomInt() % 100 > 30)
                        AutoInteriorLogic(city.cityId); // 如果满足条件，调用AutoInteriorLogic
            }
        }

        /// <summary>
        /// 自动对AI所有城市进行内政处理
        /// </summary>
        private void AutoInteriorAllCity()
        {
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId);
                if (city.cityBelongKing > 0 && city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                {
                    byte CITY_NUM = CountryListCache.GetCountryByKingId(city.cityBelongKing).GetHaveCityNum();
                    if (CITY_NUM > 0 && CITY_NUM <= 6)
                    {
                        if (city.GetMoney() < 600)
                            city.AddMoney((short)(30 + CommonUtils.getRandomInt() % 600 / CITY_NUM));
                        if (city.GetFood() < city.GetCityAllSoldierNum() / 1000 * 6 * 30)
                            city.AddFood((short)(150 + CommonUtils.getRandomInt() % 600 / CITY_NUM));
                    }
                    else if (city.GetMoney() < 30)
                    {
                        city.AddMoney((short)(20 + CommonUtils.getRandomInt() % 10));
                    }

                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                    byte minLoyalty = 100;
                    short word0 = 0;
                    for (byte byte3 = 0; byte3 < city.getCityGeneralNum(); byte3 = (byte)(byte3 + 1))
                    {
                        short generalId = officeGeneralIdArray[byte3];
                        General general = GeneralListCache.GetGeneral(generalId);
                        if (general.getLoyalty() < 50)
                        {
                            general.AddLoyalty(false);
                        }
                        else if (minLoyalty > general.getLoyalty())
                        {
                            word0 = generalId;
                            minLoyalty = general.getLoyalty();
                        }
                    }
                    if (minLoyalty < 90)
                    {
                        General general = GeneralListCache.GetGeneral(word0);
                        general.AddLoyalty(false);
                    }

                    if ((this.k_byte_array1d_fld[cityId] & 0x2) == 2)
                        AIDoLearn(cityId);

                    if ((this.k_byte_array1d_fld[cityId] & 0x4) == 4)
                        for (byte id = 0; id < city.getCityGeneralNum(); id = (byte)(id + 1))
                        {
                            short generalId = officeGeneralIdArray[id];
                            General general2 = GeneralListCache.GetGeneral(generalId);
                            if (general2.getCurPhysical() < general2.maxPhysical)
                            {
                                byte addPhysical = (byte)AiTreatValue();
                                general2.addCurPhysical(addPhysical);
                            }
                        }

                    if (city.GetMoney() >= 30)
                    {
                        DoFlood(cityId);
                        if (city.GetMoney() >= 30)
                            if (CITY_NUM > 6)
                            {
                                if (city.getCityGeneralNum() > 1)
                                {
                                    if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                        AutoInteriorLogic(cityId);
                                }
                                else if (CommonUtils.getRandomInt() % 40 > CITY_NUM * 2)
                                {
                                    AutoInteriorLogic(cityId);
                                }
                            }
                            else if (city.getCityGeneralNum() > 1)
                            {
                                if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                    AutoInteriorLogic(cityId);
                            }
                            else if (CommonUtils.getRandomInt() % 3 > 1)
                            {
                                AutoInteriorLogic(cityId);
                            }
                    }
                }
            }
        }


        /// <summary>
        /// 自动处理AI所有城市的内政
        /// </summary>
        private void AutoInteriorAllCity2()
        {
            for (byte byte0 = 1; byte0 < CityListCache.CITY_NUM; byte0 = (byte)(byte0 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte0);

                // 如果城市的国王ID大于0且不属于玩家国家的国王
                if (city.cityBelongKing > 0 && city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                {
                    byte curCountryCitys = CountryListCache.GetCountryByKingId(city.cityBelongKing).GetHaveCityNum();

                    // 如果当前国家的城市数量小于等于10
                    if (curCountryCitys <= 10)
                    {
                        // 如果城市的资金少于600，则增加一定的资金
                        if (city.GetMoney() < 600)
                            city.AddMoney((short)(30 + CommonUtils.getRandomInt() % 6000 / curCountryCitys));

                        // 如果城市的食物少于城市所有士兵数量的 6 * 60 倍
                        if (city.GetFood() < city.GetCityAllSoldierNum() / 1000 * 6 * 60)
                            city.SetFood((short)(150 + CommonUtils.getRandomInt() % 6000 / curCountryCitys));
                    }
                    else if (city.GetMoney() < 30)
                    {
                        // 如果城市的资金少于30，则增加一定的资金
                        city.AddMoney((short)(20 + CommonUtils.getRandomInt() % 10));
                    }

                    byte byte1 = 100; // 初始最小忠诚度
                    short word0 = 0;  // 初始忠诚度最低的将军ID
                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                    // 遍历城市中所有将军
                    for (byte byte3 = 0; byte3 < city.getCityGeneralNum(); byte3 = (byte)(byte3 + 1))
                    {
                        short generalId = officeGeneralIdArray[byte3];
                        General general = GeneralListCache.GetGeneral(generalId);

                        // 如果将军的忠诚度低于50，则提升忠诚度
                        if (general.getLoyalty() < 50)
                        {
                            general.AddLoyalty(true);
                        }
                        // 如果当前将军的忠诚度低于最小忠诚度，则更新最小忠诚度
                        else if (byte1 > general.getLoyalty())
                        {
                            word0 = generalId;
                            byte1 = general.getLoyalty();
                        }
                    }
                    // 如果最小忠诚度低于90，则提升对应将军的忠诚度
                    if (byte1 < 90)
                        GeneralListCache.GetGeneral(word0).AddLoyalty(true);

                    // 如果城市的标志位包含0x2，则调用AIDoLearn方法
                    if ((this.k_byte_array1d_fld[byte0] & 0x2) == 2)
                        AIDoLearn(byte0);

                    // 如果城市的标志位包含0x4，则对每个将军进行体力恢复
                    if ((this.k_byte_array1d_fld[byte0] & 0x4) == 4)
                        for (byte byte5 = 0; byte5 < city.getCityGeneralNum(); byte5 = (byte)(byte5 + 1))
                        {
                            short word4 = officeGeneralIdArray[byte5];
                            General general = GeneralListCache.GetGeneral(word4);
                            if (general.getCurPhysical() < general.maxPhysical)
                            {
                                byte addPhysical = (byte)AiTreatValue();
                                general.addCurPhysical(addPhysical);
                            }
                        }

                    // 如果城市的资金大于等于30
                    if (CityListCache.GetCityByCityId(byte0).GetMoney() >= 30)
                    {
                        DoFlood(byte0); // 调用DoFlood方法

                        // 如果城市的资金仍然大于等于30
                        if (CityListCache.GetCityByCityId(byte0).GetMoney() >= 30)
                        {
                            if (curCountryCitys > 10)
                            {
                                if (city.getCityGeneralNum() > 1)
                                {
                                    if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                        AutoInteriorLogic(byte0); // 调用AutoInteriorLogic方法
                                }
                                else if (CommonUtils.getRandomInt() % 60 > curCountryCitys * 2)
                                {
                                    AutoInteriorLogic(byte0); // 调用AutoInteriorLogic方法
                                }
                            }
                            else if (city.getCityGeneralNum() > 1)
                            {
                                if (CommonUtils.getRandomInt() % city.getCityGeneralNum() > 0)
                                    AutoInteriorLogic(byte0); // 调用AutoInteriorLogic方法
                            }
                            else if (CommonUtils.getRandomInt() % 3 > 0)
                            {
                                AutoInteriorLogic(byte0); // 调用AutoInteriorLogic方法
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行水灾处理
        /// </summary>
        /// <param name="city"></param>
        private void DoFlood(byte city)
        {
            short generalId = AiFindMostIQPoliticalGeneralInCity(city); // 获取将军ID
                                                // 如果城市的防洪控制小于99，则调用AiTameOrder方法
            if ((CityListCache.GetCityByCityId(city)).floodControl < 99)
                AiTameOrder(city, generalId);
        }


        /// <summary>
        /// 处理游戏中的各种事件
        /// </summary>
        private void DoThingsInTurn()
        {
            this.disasterThings = 0; // 初始化 disasterThings 为 0

            // 如果 UserhaveNoneCity() 返回 true
            if (UserhaveNoneCity())
            {
                this.eventId = 1; // 设置事件 ID 为 1
                RefreshFeedBack((byte)23); // 调用 RefreshFeedBack 方法，参数为 23
                GameTurn(); // 调用 GameTurn 方法
                this.j_byte_fld = 1; // 设置 j_byte_fld 为 1
                return; // 结束方法
            }

            // 如果 UserhaveAllCity() 返回 true
            if (UserhaveAllCity())
            {
                this.eventId = 0; // 设置事件 ID 为 0
                RefreshFeedBack((byte)23); // 调用 RefreshFeedBack 方法，参数为 23
                GameTurn(); // 调用 GameTurn 方法
                this.j_byte_fld = 1; // 设置 j_byte_fld 为 1
                return; // 结束方法
            }

            // 增加游戏的月份
            GameInfo.month = (byte)(GameInfo.month + 1);

            // 遍历所有城市 ID
            for (short word0 = 1; word0 < CityListCache.CITY_NUM; word0 = (short)(word0 + 1))
            {
                // 如果 DisasterRate_i() 返回 true
                if (DisasterRate_i())
                {
                    this.disasterThings = (byte)(this.disasterThings + 1);
                    this.G_byte_array1d_fld[this.disasterThings] = (byte)word0;
                }
            }

            // 如果 disasterThings 小于 1
            if (this.disasterThings < 1)
            {
                // 遍历所有城市 ID
                for (short word1 = 1; word1 < CityListCache.CITY_NUM; word1 = (short)(word1 + 1))
                {
                    // 如果 DisasterRate_j() 返回 true
                    if (DisasterRate_j())
                    {
                        this.disasterThings = (byte)(this.disasterThings + 1);
                        this.G_byte_array1d_fld[this.disasterThings] = (byte)word1;
                    }
                }
            }
            else
            {
                // 对 disasterThings 中存储的城市 ID 执行 FloodDisaster 操作
                for (short word2 = 0; word2 < this.disasterThings; word2 = (short)(word2 + 1))
                    FloodDisaster(this.G_byte_array1d_fld[word2]);

                this.eventId = CommonUtils.getRandomInt() % 3 + 6; // 设置事件 ID 为随机值 6 到 8 之间
                RefreshFeedBack((byte)19); // 调用 RefreshFeedBack 方法，参数为 19
                FloodDisasterCanvans(); // 调用 FloodDisasterCanvans 方法
                this.disasterThings = 0; // 重置 disasterThings
            }

            // 如果 disasterThings 大于 0
            if (this.disasterThings > 0)
            {
                // 对 disasterThings 中存储的城市 ID 执行 DisasterHurt 操作
                for (short word3 = 0; word3 < this.disasterThings; word3 = (short)(word3 + 1))
                    DisasterHurt(this.G_byte_array1d_fld[word3]);

                this.eventId = 9; // 设置事件 ID 为 9
                RefreshFeedBack((byte)19); // 调用 RefreshFeedBack 方法，参数为 19
                FloodDisasterCanvans(); // 调用 FloodDisasterCanvans 方法
                this.disasterThings = 0; // 重置 disasterThings
            }

            // 遍历所有城市 ID
            for (byte word4 = 1; word4 < CityListCache.CITY_NUM; word4 = (byte)(word4 + 1))
            {
                City city = CityListCache.GetCityByCityId(word4);

                // 如果城市的国王 ID 大于 0 且 IsRebelDisaster(word4) 返回 true
                if ((city.cityBelongKing > 0) && IsRebelDisaster(word4))
                {
                    this.disasterThings = (byte)(this.disasterThings + 1);
                    this.G_byte_array1d_fld[this.disasterThings] = word4;
                }
            }

            // 如果 disasterThings 大于 0
            if (this.disasterThings > 0)
            {
                // 对 disasterThings 中存储的城市 ID 执行 RebelDisasterLowRule 操作
                for (short word5 = 0; word5 < this.disasterThings; word5 = (short)(word5 + 1))
                    RebelDisasterLowRule(this.G_byte_array1d_fld[word5]);

                this.eventId = 13; // 设置事件 ID 为 13
                RefreshFeedBack((byte)19); // 调用 RefreshFeedBack 方法，参数为 19
                FloodDisasterCanvans(); // 调用 FloodDisasterCanvans 方法
                this.disasterThings = 0; // 重置 disasterThings
                AutoInteriorAllCity2(); // 调用 AutoInteriorAllCity2 方法
            }

            AutoInteriorAllCity(); // 调用 AutoInteriorAllCity 方法

            short userKingId = (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId; // 获取玩家国家的国王 ID
            byte cityId;

            // 遍历所有城市 ID
            for (cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId);

                // 如果城市的国王 ID 大于 0
                if (city.cityBelongKing > 0)
                {
                    // 如果城市的国王 ID 不等于玩家国家的国王 ID
                    if (city.cityBelongKing != userKingId)
                    {
                        city.AppointmentPrefect(); // 任命城市长

                        // 如果随机数小于 1
                        if (CommonUtils.getRandomInt() % 5 < 1)
                        {
                            byte notFoundGeneralNum = city.getCityNotFoundGeneralNum();

                            // 如果城市中有未找到的将军
                            if (notFoundGeneralNum > 0)
                            {
                                int index = MathUtils.getRandomInt(notFoundGeneralNum);
                                short generalId = city.getNotFoundGeneralId((byte)index);
                                city.removeNotFoundGeneralId(generalId);

                                if (generalId <= 0)
                                    continue;

                                city.AddOppositionGeneralId(generalId); // 添加敌对将军
                            }
                        }
                    }

                    city.soldierEatFood(); // 城市的士兵吃粮食
                    city.paySalaries(); // 支付城市的工资

                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
                    bool haveSY = false;
                    int j;

                    // 遍历城市中的将军
                    for (j = 0; j < city.getCityGeneralNum(); j++)
                    {
                        short id = officeGeneralIdArray[j];

                        // 如果将军具有技能 4
                        if (GetSkill_4(id, 7))
                        {
                            haveSY = true;
                            break;
                        }
                    }

                    // 遍历城市中的将军
                    for (j = 0; j < city.getCityGeneralNum(); j++)
                    {
                        short id = officeGeneralIdArray[j];
                        General general = GeneralListCache.GetGeneral(id);

                        // 如果将军的体力小于最大体力
                        if (general.getCurPhysical() < general.maxPhysical)
                        {
                            // 如果有技能 4，则增加 10 到 14 的体力
                            if (haveSY)
                            {
                                byte addPhysical = (byte)(10 + CommonUtils.getRandomInt() % 5);
                                general.addCurPhysical(addPhysical);
                            }
                            // 否则增加 1 到 3 的体力
                            else
                            {
                                byte addPhysical = (byte)(1 + CommonUtils.getRandomInt() % 3);
                                general.addCurPhysical(addPhysical);
                            }
                        }
                    }

                    // 如果城市的预备兵力小于等于 10000
                    if (city.cityReserveSoldier <= 10000)
                    {
                        for (j = 0; j < city.getCityGeneralNum(); j++)
                        {
                            short id = officeGeneralIdArray[j];

                            // 如果将军具有技能 6 且城市人口大于等于 20000
                            if (GetSkill_4(id, 6) && city.population >= 20000)
                            {
                                int addReserveSoldier = (GeneralListCache.GetGeneral(id)).moral + city.population / 1000 + MathUtils.getRandomInt(200) - 100;

                                if (addReserveSoldier >= 0)
                                {
                                    city.cityReserveSoldier += addReserveSoldier;
                                    city.population -= addReserveSoldier;
                                    break;
                                }
                            }
                        }

                        bool haveRY = false;
                        int k;

                        // 遍历城市中的将军，检查是否具有技能 8仁义
                        for (k = 0; k < city.getCityGeneralNum(); k++)
                        {
                            short id = officeGeneralIdArray[k];

                            if (GetSkill_4(id, 8))
                            {
                                haveRY = true;
                                break;
                            }
                        }

                        // 遍历城市中的将军
                        for (k = 0; k < city.getCityGeneralNum(); k++)
                        {
                            short id = officeGeneralIdArray[k];
                            General general = GeneralListCache.GetGeneral(id);

                            // 如果将军的忠诚度小于 95
                            if (general.getLoyalty() < 95)
                            {
                                // 如果有技能 8 仁义且将军的忠诚度小于 90
                                if (haveRY && general.getLoyalty() < 90)
                                {
                                    byte x = (byte)(5 + CommonUtils.getRandomInt() % 6);

                                    if (general.getLoyalty() + x >= 90)
                                        x = (byte)(90 - general.getLoyalty());

                                    general.AddLoyalty(x);
                                }
                            }
                        }
                    }
                }
                continue;
            }

            // 如果游戏月份是 4、8 或 12
            if (GameInfo.month == 4 || GameInfo.month == 8 || GameInfo.month == 12)
            {
                // 遍历所有城市 ID
                for (cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
                {
                    // 如果城市的国王 ID 大于 0
                    if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing > 0)
                        RegularGiveOutMoney(cityId); // 调用 RegularGiveOutMoney 方法
                }

                this.eventId = 10; // 设置事件 ID 为 10
                RefreshFeedBack((byte)19); // 调用 RefreshFeedBack 方法，参数为 19
                FloodDisasterCanvans(); // 调用 FloodDisasterCanvans 方法
            }
            // 如果游戏月份是 5 或 10
            else if (GameInfo.month == 5 || GameInfo.month == 10)
            {
                // 遍历所有城市 ID
                for (cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
                {
                    // 如果城市的国王 ID 大于 0
                    if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing > 0)
                        RegularGiveOutFood(cityId); // 调用 RegularGiveOutFood 方法
                }

                this.eventId = 11; // 设置事件 ID 为 11
                RefreshFeedBack((byte)19); // 调用 RefreshFeedBack 方法，参数为 19
                FloodDisasterCanvans(); // 调用 FloodDisasterCanvans 方法
            }

            // 如果游戏月份是 3、6、9 或 12
            if (GameInfo.month == 3 || GameInfo.month == 6 || GameInfo.month == 9 || GameInfo.month == 12)
                for (byte b = 1; b < CityListCache.CITY_NUM; b = (byte)(b + 1))
                {
                    City city = CityListCache.GetCityByCityId(b);
                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                    // 遍历城市中的将军
                    for (int j = 0; j < city.getCityGeneralNum(); j++)
                    {
                        short generalId = officeGeneralIdArray[j];
                        short kingId = city.cityBelongKing;
                        General general = GeneralListCache.GetGeneral(generalId);

                        // 计算将军与城市国王的阶段差
                        int d = GetdPhase(general.phase, (GeneralListCache.GetGeneral(kingId)).phase);

                        // 如果阶段差大于 10 且将军的忠诚度不等于 100
                        if (d > 10 && general.getLoyalty() != 100)
                        {
                            // 如果随机数小于阶段差的 80%
                            if (CommonUtils.getRandomInt() % 80 < d)
                            {
                                int val = d / 10;
                                val = Mathf.Max(0, general.getLoyalty() - val);
                                general.decreaseLoyalty((byte)val); // 减少将军的忠诚度
                            }
                        }
                    }
                }

            byte i;

            // 遍历所有城市 ID
            for (i = 1; i < CityListCache.CITY_NUM; i = (byte)(i + 1))
            {
                City city = CityListCache.GetCityByCityId(i);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                // 遍历城市中的将军
                for (int j = 0; j < city.getCityGeneralNum(); j++)
                {
                    short id = officeGeneralIdArray[j];

                    // 如果将军具有技能 5掠夺
                    if (getSkill_5(id, 1))
                    {
                        General general = GeneralListCache.GetGeneral(id);

                        // 如果将军的智商大于等于随机值 120
                        if (general.IQ >= MathUtils.getRandomInt(120))
                        {
                            byte[] enemyCityId = CountryListCache.getEnemyCityIdArray_new(city.cityId);

                            // 遍历敌方城市
                            for (int k = 0; k < enemyCityId.Length; k++)
                            {
                                byte b1 = enemyCityId[k];
                                City beCity = CityListCache.GetCityByCityId(b1);
                                General prefectGeneral = GeneralListCache.GetGeneral(beCity.prefectId);
                                byte b = (byte)(general.force - prefectGeneral.force);

                                // 如果力量差大于等于随机值 70
                                if (GetLueDuoByForceD(b) >= MathUtils.getRandomInt(70))
                                {
                                    short food = (short)(int)(beCity.GetFood() * 0.04D - city.GetFood() * 0.01D);
                                    if (food < 0)
                                        food = 0;

                                    short money = (short)(int)(beCity.GetMoney() * 0.04D - city.GetMoney() * 0.01D);
                                    if (money < 0)
                                        money = 0;

                                    short population = (short)(int)(beCity.population * 0.04D - city.population * 0.01D);
                                    if (population < 0)
                                        population = 0;

                                    // 减少敌方城市资源
                                    beCity.DecreaseFood(food);
                                    beCity.DecreaseMoney(money);
                                    beCity.population -= population;
                                    if (beCity.population < 0)
                                        beCity.population = 0;

                                    // 打印掠夺信息
                                    Debug.Log($"{city.cityName}掠夺{beCity.cityName}粮食：{food} 金：{money} 人口：{population}");

                                    // 增加本城市资源
                                    city.AddFood(food);
                                    city.AddMoney(money);
                                    city.population += population;

                                    if (city.population < 0 || city.population > 990000)
                                        city.population = 990000;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            // 遍历所有城市 ID
            for (i = 1; i < CityListCache.CITY_NUM; i = (byte)(i + 1))
            {
                City city = CityListCache.GetCityByCityId(i);
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                // 遍历城市中的将军
                for (int j = 0; j < city.getCityGeneralNum(); j++)
                {
                    short id = officeGeneralIdArray[j];
                    General general = GeneralListCache.GetGeneral(id);

                    // 如果将军具有技能 5能吏
                    if (getSkill_5(id, 5))
                    {
                        // 如果将军的政治值大于等于随机值 100
                        if (general.political < MathUtils.getRandomInt(100))
                            continue;

                        int random = MathUtils.getRandomInt(4);

                        // 根据随机值更新城市属性
                        switch (random)
                        {
                            case 0:
                                city.agro = (short)(city.agro + general.political / 10);
                                if (city.agro > 999)
                                    city.agro = 999;
                                break;
                            case 1:
                                city.trade = (short)(city.trade + general.political / 10);
                                if (city.trade > 999)
                                    city.trade = 999;
                                break;
                            case 2:
                                city.population += general.political * 10;
                                if (city.population > 990000)
                                    city.population = 990000;
                                break;
                            case 3:
                                city.floodControl = (byte)(city.floodControl + MathUtils.getRandomInt(4));
                                if (city.floodControl > 99)
                                    city.floodControl = 99;
                                break;
                        }
                    }

                    // 如果将军具有技能 6练兵
                    if (getSkill_5(id, 6))
                        for (int k = 0; k < officeGeneralIdArray.Length; k++)
                        {
                            short otherGeneralId = officeGeneralIdArray[k];
                            General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                            otherGeneral.addexperience(MathUtils.getRandomInt(general.force));
                        }

                    // 如果将军具有技能 7言教
                    if (getSkill_5(id, 7))
                        for (int k = 0; k < officeGeneralIdArray.Length; k++)
                        {
                            short otherGeneralId = officeGeneralIdArray[k];
                            General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                            otherGeneral.addIQExp((byte)(1 + MathUtils.getRandomInt(general.IQ / 10)));
                        }
                }
            }

            // 遍历所有国家
            for (i = 0; i < CountryListCache.getCountrySize(); i = (byte)(i + 1))
            {
                Country country = CountryListCache.getCountryByIndexId(i);
                List<Alliance> allianceList = country.allianceList;

                // 遍历联盟列表
                for (int k = 0; k < allianceList.Count; k++)
                {
                    Alliance alliance = allianceList [k];
                    alliance.Months = (byte)(alliance.Months - 1);

                    // 如果联盟持续时间小于等于 0
                    if (alliance.Months <= 0)
                    {
                        bool isRemoveAlliance = country.removeAlliance(alliance.countryId);

                        // 如果联盟被移除
                        if (isRemoveAlliance)
                        {
                            this.eventId = 14; // 设置事件 ID 为 14
                            this.m_byte_fld = alliance.countryId;
                            RefreshFeedBack((byte)19); // 调用 RefreshFeedBack 方法，参数为 19
                            FloodDisasterCanvans(); // 调用 FloodDisasterCanvans 方法
                        }
                    }
                }
            }

            oppGenMove(); // 调用 oppGenMove 方法
        }


        private int GetLueDuoByForceD(byte a)
        {
            int result = 30;
            if (a >= 50)
            {
                result = 60;
            }
            else if (a >= 40)
            {
                result = 55;
            }
            else if (a >= 30)
            {
                result = 50;
            }
            else if (a >= 20)
            {
                result = 45;
            }
            else if (a >= 10)
            {
                result = 40;
            }
            else if (a >= 0)
            {
                result = 35;
            }
            return result;
        }

        /// <summary>
        /// 处理在野将领的移动逻辑
        /// </summary>
        void oppGenMove()
        {
            List<short> vector = new List<short>(); // 创建一个列表来存储将领ID

            for (byte cityIndex = 0; cityIndex < CityListCache.getCityNum(); cityIndex++)
            {
                City city = CityListCache.getCityByIndex(cityIndex);
                for (byte index = 0; index < city.GetOppositionGeneralNum(); index++)
                {
                    short generalId = city.GetOppositionGeneralId(index);
                    if (generalId > 0)
                    {
                        if (vector.Contains(generalId))
                        {
                            // 如果列表中已包含该将领ID，则跳过当前循环
                            continue;
                        }
                        vector.Add(generalId); // 添加将领ID到列表

                        bool ev = false;
                        byte evKing = 0;

                        // 查找符合条件的国家
                        for (byte indexId = 1; indexId < CountryListCache.getCountrySize(); indexId++)
                        {
                            if ((GeneralListCache.GetGeneral(CountryListCache.getCountryByIndexId(indexId).countryKingId)).phase == GeneralListCache.GetGeneral(generalId).phase &&
                                CountryListCache.getCountryByIndexId(indexId).countryId > 0)
                            {
                                ev = true;
                                evKing = indexId;
                            }
                        }

                        if (city.cityBelongKing > 0)
                        {
                            short kingPhase = GeneralListCache.GetGeneral(city.cityBelongKing).phase;

                            if (ev)
                            {
                                // 如果找到符合条件的国家
                                Country evCountry = CountryListCache.GetCountryByCountryId(evKing);
                                if (evCountry != null && evCountry.countryKingId != city.cityBelongKing)
                                {
                                    // 遍历符合条件的城市，并进行对手将领移动
                                    for (int i = 0; i < evCountry.GetHaveCityNum(); i++)
                                    {
                                        byte city1 = evCountry.getCity(i);
                                        if (CityListCache.GetCityByCityId(city1).getCityOfficeGeneralIdArray()[0] == evCountry.countryKingId)
                                        {
                                            OppGenMove(generalId, city.cityId, city1);
                                        }
                                    }
                                }
                            }
                            else if (GetdPhase(kingPhase, GeneralListCache.GetGeneral(generalId).phase) > 5 || city.getCityGeneralNum() >= 10)
                            {
                                // 如果将领的阶段差距大于5，或者城市将领数量大于等于10
                                byte moveCityId = getOppmovetarCity(city.cityId);
                                if (moveCityId > 0)
                                {
                                    OppGenMove(generalId, city.cityId, moveCityId);
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 获取在野将领可以移动到的目标城市
        /// </summary>
        /// <param name="curcity"></param>
        /// <returns></returns>
        byte getOppmovetarCity(byte curcity)
        {
            byte tarCityId = curcity;
            short[] connectionCityIds = CityListCache.GetCityByCityId(curcity).connectCityId;
            byte[] canMoveCityIds = new byte[connectionCityIds.Length];
            byte canMoveIndex = 0;

            for (byte index = 0; index < connectionCityIds.Length; index++)
            {
                City city = CityListCache.GetCityByCityId((byte)connectionCityIds[index]);
                if (city.cityId != tarCityId && city.GetOppositionGeneralNum() < 10)
                {
                    canMoveCityIds[canMoveIndex] = city.cityId;
                    canMoveIndex++;
                }
            }

            if (canMoveIndex == 0)
                return 0;

            int moveIndex = MathUtils.getRandomInt(canMoveIndex);
            if (canMoveCityIds[moveIndex] > 0)
                tarCityId = canMoveCityIds[moveIndex];

            return tarCityId;
        }

        /// <summary>
        /// 执行在野将领的移动
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="curCity"></param>
        /// <param name="tarCity"></param>
        void OppGenMove(short generalId, byte curCity, byte tarCity)
        {
            if (curCity == tarCity)
                return;

            City tCity = CityListCache.GetCityByCityId(tarCity);
            tCity.AddOppositionGeneralId(generalId);

            City cCity = CityListCache.GetCityByCityId(curCity);
            cCity.RemoveOppositionGeneralId(generalId);
        }

        /// <summary>
        /// 执行月度操作
        /// </summary>
        void MonthDoThings()
        {
            while (GameInfo.month <= 12)
            {
                TurnTestCanvas();
                if (this.j_byte_fld != 0)
                    return;

                this.s_byte_fld = 0;
                DoThingsInTurn();

                if (GameInfo.isWatch)
                    testGeneral();

                if (this.j_byte_fld != 0)
                    return;
            }
        }

        /// <summary>
        /// 测试将领
        /// </summary>
        public void testGeneral()
        {
            short generalNum = GeneralListCache.GetTotalGeneralNum();

            for (short k = 0; k < generalNum; k++)
            {
                General general = GeneralListCache.GetGeneralByIndex(k);

                if (general == null)
                {
                    Debug.LogError("系统异常！！！第" + k + "个武将不存在.");
                }
                else
                {
                    string cityInfoString = "";
                    int n = 0;

                    for (byte i = 0; i < CityListCache.getCityNum(); i++)
                    {
                        City city = CityListCache.getCityByIndex(i);
                        byte index;

                        // 检查城市中的将领
                        for (index = 0; index < city.getCityGeneralNum(); index++)
                        {
                            if (city.getCityOfficeGeneralIdArray()[index] == general.generalId)
                            {
                                cityInfoString += city.cityName;
                                n++;
                            }
                        }

                        // 检查城市中的对手将领
                        for (index = 0; index < city.GetOppositionGeneralNum(); index++)
                        {
                            if (city.GetOppositionGeneralId(index) == general.generalId)
                            {
                                cityInfoString += "[-" + city.cityName + "-]";
                                n++;
                            }
                        }

                        // 检查未找到的将领
                        for (index = 0; index < city.getCityNotFoundGeneralNum(); index++)
                        {
                            if (city.getCityNotFoundGeneralIdArray()[index] == general.generalId)
                            {
                                cityInfoString += "[" + city.cityName + "]";
                                n++;
                            }
                        }
                    }

                    if (n > 1)
                        Debug.LogError("系统异常！！！" + general.generalName + "在城池：" + cityInfoString + " 任职！");
                }
            }
        }

        /// <summary>
        /// 更新游戏信息并准备新的一年
        /// </summary>
        void NewYearDebt()
        {
            GameInfo.month = 1;
            GameInfo.years = (short)(GameInfo.years + 1);
            GeneralListCache.DebutByYears(GameInfo.years);
        }

        /// <summary>
        /// 主要的游戏循环
        /// </summary>
        void GameLoop()
        {
            while (true)
            {
                MonthDoThings();
                if (this.j_byte_fld != 0)
                    return;
                NewYearDebt();
            }
        }

        // 主运行函数
        public void run()
        {
            try
            {
                GameInfo.month = 1;
                GameInfo.years = 189;
                CommonUtils.CleanAllInfo();
                AfterWarSettlement();
                WarGeneralHpSoldierNum();
                if (this.j_byte_fld == 1)
                    this.j_byte_fld = 0;
                GameLoop();
            }
            catch (Exception exception)
            {
                Debug.LogError(exception.ToString());
            }
        }

        // 处理排序信息
        void void_aq()
        {
            //void_bK();
            //readHighSort(7);

            for (int i = 0; i < 7 && Mathf.Abs(this.higSort[i] - d.disaster_warning_information[i].Length - 1) <= 2; i++) ;
        }

        // 将将领ID数组扩展到新数组中
        short[] ExpandGeneralIdArray(short[] aword0, byte num, short generalId)
        {
            short[] aword1 = new short[num + 1];
            for (byte byte1 = 0; byte1 < num; byte1++)
                aword1[byte1] = aword0[byte1];

            aword1[num] = generalId;
            return aword1;
        }

        /// <summary>
        /// 设置国家ID
        /// </summary>
        /// <param name="countryId"></param>
        void void_b_p(byte countryId)
        {
            GameInfo.humanCountryId = countryId;
            this.j_byte_fld = 1;
            //this.gamecanvas.s_void_b_a((byte)4);
        }

        // 计算将领兵力
        short CalculateTotalGeneralSoldierNum(short[] generalIdArray, byte generalNum)
        {
            short word0 = 0;

            for (byte byte1 = 0; byte1 < generalNum; byte1++)
                word0 += GeneralListCache.GetGeneral(generalIdArray[byte1]).generalSoldier;

            return word0;
        }

        /// <summary>
        /// 征兵操作
        /// </summary>
        /// <param name="soldierNum"></param>
        /// <param name="cityId"></param>
        void conscriptionOfUser(short soldierNum, byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            city.cityReserveSoldier += soldierNum; // 增加城市储备兵员
            city.DecreaseMoney((short)((soldierNum + 4) / 5)); // 扣除相应的钱币
            city.population -= soldierNum * 3 / 2; // 减少城市人口
            city.rule = (byte)(city.rule - soldierNum / 500); // 规则减少
            if (city.rule < 0)
                city.rule = 0; // 确保规则不会小于0
            if (city.population < 0)
                city.population = 0; // 确保人口不会小于0
        }

        // 更新游戏画布和标记布尔值
        void RefreshFeedBack(byte byte0)
        {
            //this.gamecanvas.s_void_b_a(byte0);
            //this.gamecanvas.repaint();
            this.e_boolean_fld = true;
        }

        // 初始化状态
        void InitiateCanvasMarkValue()
        {
            this.Y = 0;
            this.X = 0;
            this.d_boolean_fld = true;
            this.a_boolean_fld = true;
            this.c_boolean_fld = true;
            this.p_byte_fld = this.tarCity;
        }

        // 执行操作6
        void InitiateCanvasMark()
        {
            InitiateCanvasMarkValue();
            RefreshFeedBack((byte)6);
        }

        // 执行操作6，并减少用户订单数量
        void EndDecreaseOrder()
        {
            InitiateCanvasMarkValue();
            this.userOrderNum = (byte)(this.userOrderNum - 1);
            if (this.userOrderNum <= 0)
            {
                this.X = 0;
                this.j_byte_fld = 3;
                RefreshFeedBack((byte)4);
            }
            else
            {
                if ((CityListCache.GetCityByCityId(this.tarCity)).cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                    FindTarCity();
                RefreshFeedBack((byte)6);
            }
        }

        /// <summary>
        /// 计算用户国王ID
        /// </summary>
        void CanvascalculationUserKingIndex()
        {
            //this.gamecanvas.calculationUserKingIndex();
            RefreshFeedBack((byte)4);
        }

        /// <summary>
        /// 设置目标城市并更新状态
        /// </summary>
        void CanvasSetTarCity()
        {
            this.tarCity = this.curCity;
            this.Y = (byte)(this.Y + 1);
            DoMenuSwitch();
        }

        /// <summary>
        /// 设置AI将领ID并更新状态
        /// </summary>
        void CanvasSetAiGeneralId()
        {
            this.AIGeneralId = this.HMGeneralId;
            RefreshFeedBack((byte)7);
        }

        /// <summary>
        /// 执行操作，并更新状态
        /// </summary>
        void AppointTheHMGenToTarCity()
        {
            AppointPrefectInCity(this.HMGeneralId, this.tarCity);
            this.Y = (byte)(this.Y + 1);
            DoMenuSwitch();
        }

        /// <summary>
        /// 设置提示信息
        /// </summary>
        void AppointTheHMGenToTarCityTips()
        {
            AppointPrefectInCity(this.HMGeneralId, this.tarCity);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][3]);
            this.HMGeneralId = this.chooseGeneralIdArray[0];
            this.Y = 6;
        }

        /// <summary>
        /// 搜索将领并更新状态
        /// </summary>
        void CanvasSearchGeneral()
        {
            SearchOrder(this.tarCity, this.HMGeneralId);
            RefreshFeedBack((byte)11);
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 设置提示信息的方法
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="info"></param>
        void SetTipsInfo(short generalId, string info)
        {
            this.tipsGeneralId = generalId;
            this.a_java_lang_String_fld = info;
            RefreshFeedBack((byte)10);
        }

        /// <summary>
        /// 检查将领是否被雇佣，并设置提示信息
        /// </summary>
        void EmployResult()
        {
            if (isEmploy(this.tarCity, this.HMGeneralId, this.AIGeneralId))
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][0]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][1]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 执行将领操作并设置提示信息
        /// </summary>
        void AppointNextPrefect()
        {
            CanvasAppointPrefectInCity(this.HMGeneralId, this.tarCity);
            this.Y = (byte)(this.Y + 1);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][3]);
        }

        /// <summary>
        /// 将将领ID进行排序
        /// </summary>
        void AppointMainGeneral()
        {
            for (int i1 = 0; i1 < this.chooseGeneralNum; i1++)
            {
                if (this.chooseGeneralIdArray[i1] == this.HMGeneralId)
                {
                    this.chooseGeneralIdArray[i1] = this.chooseGeneralIdArray[0];
                    this.chooseGeneralIdArray[0] = this.HMGeneralId;
                }
            }
            this.Y = (byte)(this.Y + 1);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[0][2]);
        }

        /// <summary>
        /// 处理所需的钱币
        /// </summary>
        /// <param name="needMoney"></param>
        void IsEnoughMoney(int needMoney)
        {
            if (needMoney > CityListCache.GetCityByCityId(this.tarCity).GetMoney())
                this.eventId = CityListCache.GetCityByCityId(this.tarCity).GetMoney();
            RefreshFeedBack((byte)13);
        }

        /// <summary>
        /// 计算内部所需的钱币
        /// </summary>
        void NeedMoneyOfInteriorF()
        {
            int needMoney = GetNeedMoneyOfInterior(this.HMGeneralId, (byte)1);
            this.eventId = needMoney;
            IsEnoughMoney(needMoney);
        }

        /// <summary>
        /// 处理所需的钱币
        /// </summary>
        void NeedMoneyOfInteriorL()
        {
            this.eventId = GetNeedMoneyOfInterior(this.HMGeneralId, (byte)3);
            IsEnoughMoney(this.eventId);
        }

        /// <summary>
        /// 开垦城市
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int Reclaim1(byte cityId, short generalId, int useMoney)
        {
            int j1 = ReclaimValue(generalId, useMoney);
            City city = CityListCache.GetCityByCityId(cityId);
            city.DecreaseMoney((short)useMoney); // 扣除钱币
            if (city.agro + j1 > 999)
                j1 = 999 - city.agro; // 确保农业不会超过999
            city.agro = (short)(city.agro + j1); // 增加农业值
            return j1;
        }

        /// <summary>
        /// 执行开垦操作
        /// </summary>
        void Reclaim2Tip()
        {
            int num = Reclaim1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][0] + num + "点");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 执行贸易操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int Mercantile1(byte byte0, short word0, int useMoney)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            int j1 = MercantileValue(word0, useMoney);
            city.DecreaseMoney((short)useMoney); // 扣除钱币
            if (city.trade + j1 > 999)
                j1 = 999 - city.trade; // 确保贸易不会超过999
            city.trade = (short)(city.trade + j1); // 增加贸易值
            return j1;
        }

        /// <summary>
        /// 执行贸易操作
        /// </summary>
        void Mercantile2Tip()
        {
            int num = Mercantile1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][1] + num + "点");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 执行防洪操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int Tame1(byte byte0, short word0, int i1)
        {
            int j1 = TameValue(word0, i1);
            City city = CityListCache.GetCityByCityId(byte0);
            city.DecreaseMoney((short)i1); // 扣除钱币
            if (city.floodControl + j1 > 99)
                j1 = 99 - city.floodControl; // 确保防洪值不会超过99
            city.floodControl = (byte)(city.floodControl + j1); // 增加防洪值
            return j1;
        }


        /// <summary>
        /// 执行防洪提示操作
        /// </summary>
        void Tame2Tip()
        {
            int num = Tame1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][3] + num + "点");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 处理巡查操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int Patrol1(byte byte0, short word0, int i1)
        {
            int j1 = PatrolValue(word0, i1);
            City city = CityListCache.GetCityByCityId(byte0);
            city.DecreaseMoney((short)i1); // 扣除钱币
            if (city.population > 990000)
                j1 = 990000 - city.population; // 确保人口不超过990000
            if (city.rule < 99)
            {
                if (j1 < 1500)
                {
                    city.rule = (byte)(city.rule + 1);
                }
                else if (j1 < 2500)
                {
                    city.rule = (byte)(city.rule + 2);
                }
                else
                {
                    city.rule = (byte)(city.rule + 3);
                }
            }
            if (city.rule > 99)
                city.rule = 99; // 确保规则不超过99
            city.population += j1; // 增加人口
            return j1;
        }

        /// <summary>
        /// 执行巡查提示操作
        /// </summary>
        void Patrol2Tip()
        {
            int num = Patrol1(this.tarCity, this.HMGeneralId, this.eventId);
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[3][4] + num + "人");
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 计算将领离间成功的概率
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        int AlienateRate(short gohireId, short behireId)
        {
            General beGeneral = GeneralListCache.GetGeneral(behireId);
            if (beGeneral.getLoyalty() > 95)
                return 0;
            if (beGeneral.getLoyalty() > 87)
            {
                if (MathUtils.getRandomInt(100) > (95 - beGeneral.getLoyalty()) * 2)
                    return 0;
            }
            else
            {
                int i = (95 - beGeneral.getLoyalty()) * (95 - beGeneral.getLoyalty()) / 4;
                if (i > 90)
                    i = 90;
                if (MathUtils.getRandomInt(100) > i)
                    return 0;
            }
            short bepk = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(behireId))).phase;
            short pk = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(gohireId))).phase;
            int d1 = GetdPhase(bepk, beGeneral.phase);
            int d2 = GetdPhase(pk, beGeneral.phase);
            int d3 = GetdPhase((GeneralListCache.GetGeneral(gohireId)).phase, beGeneral.phase);
            if (d1 == 0)
                return 0;
            if (d2 == 0)
                return 10 + CommonUtils.getRandomInt() % 15;
            if (d3 > d1 + 10)
                return 0;
            int val = d1 - d2 * 4 / 3 - d3 * 2 + 110 - beGeneral.getLoyalty();
            if (val > 0)
            {
                if (CommonUtils.getRandomInt() % val > 5)
                    return 5 + CommonUtils.getRandomInt() % 10;
                if (CommonUtils.getRandomInt() % 40 < 100 - beGeneral.getLoyalty())
                    return 2 + CommonUtils.getRandomInt() % 5;
                return 1 + CommonUtils.getRandomInt() % 3;
            }
            if (CommonUtils.getRandomInt() % 120 < (GeneralListCache.GetGeneral(gohireId)).IQ - beGeneral.IQ)
                return 1 + CommonUtils.getRandomInt() % 3;
            return 0;
        }

        /// <summary>
        /// 检查离间是否成功
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        bool IsSuccessOfAlienate(short gohireId, short behireId)
        {
            int i1 = AlienateRate(gohireId, behireId);
            if (i1 > 0)
            {
                General beGeneral = GeneralListCache.GetGeneral(behireId);
                Debug.Log((GeneralListCache.GetGeneral(gohireId)).generalName + "离间" + beGeneral.generalName + "忠诚度降低：" + i1);
                beGeneral.decreaseLoyalty((byte)i1); // 降低忠诚度
                return true;
            }
            return false;
        }

        /// <summary>
        /// 执行离间消息操作
        /// </summary>
        void Alienate2Tip()
        {
            if (IsSuccessOfAlienate(this.HMGeneralId, this.AIGeneralId))
            {
                GeneralListCache.addIQExp(this.HMGeneralId, (byte)1);
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][1]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][0]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 获取联盟概率
        /// </summary>
        /// <param name="userKingId"></param>
        /// <param name="otherKingId"></param>
        /// <returns></returns>
        int getAllianceProbability(short userKingId, short otherKingId)
        {
            int dPhase = GetdPhase((GeneralListCache.GetGeneral(userKingId)).phase, (GeneralListCache.GetGeneral(otherKingId)).phase);
            dPhase += CountryListCache.GetCountryByKingId(otherKingId).GetHaveCityNum() - CountryListCache.GetCountryByKingId(userKingId).GetHaveCityNum();
            if (dPhase < MathUtils.getRandomInt(75))
                return 0;
            return 0;
        }

        /// <summary>
        /// 执行联盟操作
        /// </summary>
        void Negotiate()
        {
            short otherKingId = (CountryListCache.GetCountryByCountryId(this.m_byte_fld)).countryKingId;
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);
            int probability = getAllianceProbability(country.countryKingId, otherKingId);
            if (probability == 0)
            {
                Alliance alliance = new Alliance(this.m_byte_fld, (byte)12);
                country.AddAlliance(alliance);
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[1][0]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[1][1]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 随机设置将领忠诚度
        /// </summary>
        /// <param name="generalId"></param>
        void RandomSetGeneralLoyalty(short generalId)
        {
            GeneralListCache.GetGeneral(generalId).SetLoyalty((byte)(60 + CommonUtils.getRandomInt() % 15));
        }

        /// <summary>
        /// 检查将领是否可以被离间
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        bool BribeRate(short gohireId, short behireId)
        {
            General beGeneral = GeneralListCache.GetGeneral(behireId);
            if (beGeneral.getLoyalty() >= 90)
                return false;
            short pk1 = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(gohireId))).phase;
            short pk2 = (GeneralListCache.GetGeneral(GetOfficeGenBelongKing(behireId))).phase;
            int d1 = GetdPhase(pk1, beGeneral.phase);
            int d2 = GetdPhase(pk2, beGeneral.phase);
            int d3 = GetdPhase((GeneralListCache.GetGeneral(gohireId)).phase, beGeneral.phase);
            if (d2 == 0)
                return false;
            if (d2 < 5)
            {
                int val = d2 - d1 * 2 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 2;
                if (val > 0)
                    return true;
            }
            else if (d2 <= 10)
            {
                int val = d2 - d1 * 3 / 2 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 2;
                if (val > 0)
                    return true;
            }
            else if (d2 <= 20)
            {
                int val = d2 - d1 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 2;
                if (val > 0)
                    return true;
            }
            else
            {
                int val = d2 - d1 - d3 * 2 + (100 - beGeneral.getLoyalty()) / 3;
                if (val > 0)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 尝试笼络将领从一个城市转移到另一个城市
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="cityId"></param>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        /// <returns></returns>
        bool BribeMovePossibility(byte byte0, byte cityId, short word0, short word1)
        {
            if (BribeRate(word0, word1))
            {
                RandomSetGeneralLoyalty(word1); // 随机设置将领忠诚度
                GeneralListCache.addMoralExp(word0, (byte)5); // 增加将领的道德经验
                GeneralListCache.addIQExp(word0, (byte)2); // 增加将领的智力经验
                City city = CityListCache.GetCityByCityId(cityId);
                city.removeOfficeGeneralId(word1); // 从城市中移除将领
                City city2 = CityListCache.GetCityByCityId(byte0);
                city2.AddOfficeGeneralId(word1); // 将将领添加到另一个城市
                Debug.Log(city2.cityName + "的" + GeneralListCache.GetGeneral(word0).generalName + "招揽" + city.cityName + "的" + GeneralListCache.GetGeneral(word1).generalName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 执行笼络将领转移操作
        /// </summary>
        void BribeResultTip()
        {
            if (BribeMovePossibility(this.tarCity, this.curCity, this.HMGeneralId, this.AIGeneralId))
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][3]);
            }
            else
            {
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[5][2]);
            }
            this.Y = (byte)(this.Y + 1);
        }

        // 减少将领经验，并返回1
        int SchoolIncreaseIQValue(short word0)
        {
            GeneralListCache.GetGeneral(word0).experience = (short)(GeneralListCache.GetGeneral(word0).experience - getLearnNeedExp(word0));
            return 1;
        }

        /// <summary>
        /// 学院增加将领的智力值Tip
        /// </summary>
        void SchoolTip1()
        {
            GeneralListCache.GetGeneral(this.HMGeneralId).IQ = (byte)(GeneralListCache.GetGeneral(this.HMGeneralId).IQ + SchoolIncreaseIQValue(this.HMGeneralId));
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[4][3]);
            this.Y = (byte)(this.Y + 1);
        }

        /// <summary>
        /// 医馆增加将领生命值Tip
        /// </summary>
        void HospitalTip1()
        {
            AiTreat(); // 执行相关操作
            SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[4][4]);
            this.Y = (byte)(this.Y + 1);
        }

    

    
    

        // 执行 DoMenuSwitch 操作
        void DoMenuSwitch()
        {
            // 获取当前坐标的字节值
            byte byte0 = this.i_byte_array2d_fld[this.X][this.Y];
            System.GC.Collect(); // 强制进行垃圾回收

            // 根据 byte0 的值执行不同的方法
            switch (byte0)
            {
                case 0:
                    InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                    break;
                case 1:
                    EndDecreaseOrder(); // 执行 EndDecreaseOrder 方法
                    break;
                case 2:
                    CanvascalculationUserKingIndex(); // 执行 CanvascalculationUserKingIndex 方法
                    break;
                case 3:
                    CanvasSetAiGeneralId(); // 执行 CanvasSetAiGeneralId 方法
                    break;
                case 4:
                    this.Y = (byte)(this.Y + 1); // 更新 Y 坐标
                    RefreshFeedBack((byte)10); // 执行 RefreshFeedBack 方法
                    break;
                case 5:
                    RefreshFeedBack((byte)8); // 执行 RefreshFeedBack 方法
                    break;
                case 6:
                    RefreshFeedBack((byte)14); // 执行 RefreshFeedBack 方法
                    break;
                case 8:
                    RefreshFeedBack((byte)5); // 执行 RefreshFeedBack 方法
                    break;
                case 9:
                    RefreshFeedBack((byte)15); // 执行 RefreshFeedBack 方法
                    break;
                case 10:
                    CanvasSearchGeneral(); // 执行 CanvasSearchGeneral 方法
                    break;
                case 11:
                    RefreshFeedBack((byte)12); // 执行 RefreshFeedBack 方法
                    break;
                case 12:
                    NeedMoneyOfInteriorF(); // 执行 NeedMoneyOfInteriorF 方法
                    break;
                case 13:
                    NeedMoneyOfInteriorL(); // 执行 NeedMoneyOfInteriorL 方法
                    break;
                case 14:
                    RefreshFeedBack((byte)16); // 执行 RefreshFeedBack 方法
                    break;
                case 15:
                    RefreshFeedBack((byte)17); // 执行 RefreshFeedBack 方法
                    break;
                case 16:
                    RefreshFeedBack((byte)9); // 执行 RefreshFeedBack 方法
                    break;
                case 17:
                    RefreshFeedBack((byte)18); // 执行 RefreshFeedBack 方法
                    break;
                case 83:
                    AppointTheHMGenToTarCityTips(); // 执行 AppointTheHMGenToTarCityTips 方法
                    break;
                case 84:
                    AppointMainGeneral(); // 执行 AppointMainGeneral 方法
                    break;
                case 85:
                    //void_aS(); // 执行 void_aS 方法
                    break;
                case 86:
                    //void_aR(); // 执行 void_aR 方法
                    break;
                case 87:
                    //saveGame(); // 保存游戏
                    break;
                case 88:
                    HospitalTip1(); // 执行 HospitalTip1 方法
                    break;
                case 89:
                    SchoolTip1(); // 执行 SchoolTip1 方法
                    break;
                case 90:
                    BribeResultTip(); // 执行 BribeResultTip 方法
                    break;
                case 91:
                    Negotiate(); // 执行 Negotiate 方法
                    break;
                case 92:
                    Alienate2Tip(); // 执行 Alienate2Tip 方法
                    break;
                case 93:
                    Patrol2Tip(); // 执行 Patrol2Tip 方法
                    break;
                case 94:
                    Tame2Tip(); // 执行 Tame2Tip 方法
                    break;
                case 95:
                    Mercantile2Tip(); // 执行 Mercantile2Tip 方法
                    break;
                case 96:
                    Reclaim2Tip(); // 执行 Reclaim2Tip 方法
                    break;
                case 97:
                    AppointNextPrefect(); // 执行 AppointNextPrefect 方法
                    break;
                case 98:
                    EmployResult(); // 执行 EmployResult 方法
                    break;
                case 99:
                    AppointTheHMGenToTarCity(); // 执行 AppointTheHMGenToTarCity 方法
                    break;
                case 100:
                    CanvasSetTarCity(); // 执行 CanvasSetTarCity 方法
                    break;
            }
        }


        // 检查 e_boolean_fld 字段并返回布尔值
        bool CanvasMark1()
        {
            if (this.e_boolean_fld)
            {
                this.e_boolean_fld = false; // 设置 e_boolean_fld 为 false
                return true; // 返回 true
            }
            return false; // 返回 false
        }

        // 执行 CanvasMark1Refresh 操作
        void CanvasMark1Refresh(byte cityId, int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            if (this.X == 1 || this.X == 3)
            {
                this.p_byte_fld = this.tarCity; // 设置 p_byte_fld 为目标城市 ID
            }
            else
            {
                this.p_byte_fld = cityId; // 设置 p_byte_fld 为传入的城市 ID
            }
            this.curCity = cityId; // 更新当前城市 ID
            this.Y = (byte)(this.Y + 1); // 更新 Y 坐标
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行复活操作
        void RebornModel(int i1)
        {
            short[] cityOfficeGeneralIdArray;
            byte generalNum;

            if (this.X != 22 && !CanvasMark1()) // 如果 X 不是 22 并且 CanvasMark1() 返回 false，退出方法
                return;

            if (this.d_boolean_fld)
            {
                cityOfficeGeneralIdArray = CityListCache.GetCityByCityId(this.p_byte_fld).getCityOfficeGeneralIdArray(); // 获取城市的将军 ID 数组
                generalNum = (byte)cityOfficeGeneralIdArray.Length; // 获取将军数量
            }
            else
            {
                cityOfficeGeneralIdArray = this.canToDoGeneral_Array; // 获取可以操作的将军数组
                generalNum = this.canToDoGeneralNum; // 获取可以操作的将军数量
                this.d_boolean_fld = true; // 设置 d_boolean_fld 为 true
            }

            if (i1 == 1)
            {
                RebornGeneralMark(cityOfficeGeneralIdArray, generalNum); // 执行 RebornGeneralMark 方法
                if (this.X == 22)
                {
                    this.j_byte_fld = 1; // 设置 j_byte_fld 为 1
                    return;
                }
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            byte byte1 = 0;
            while (byte1 < generalNum)
            {
                if ((GeneralListCache.GetGeneral(cityOfficeGeneralIdArray[byte1])).IsDie) // 如果将军死亡
                {
                    this.HMGeneralId = cityOfficeGeneralIdArray[byte1]; // 设置 HMGeneralId 为将军 ID
                    (GeneralListCache.GetGeneral(this.HMGeneralId)).IsDie = false; // 将将军标记为未死亡
                    break;
                }
                byte1 = (byte)(byte1 + 1); // 递增索引
            }

            if (this.X == 22)
            {
                this.j_byte_fld = 2; // 设置 j_byte_fld 为 2
                return;
            }

            if (this.X == 9)
                this.e_boolean_fld = true; // 如果 X 为 9，设置 e_boolean_fld 为 true

            this.Y = (byte)(this.Y + 1); // 更新 Y 坐标
            this.p_byte_fld = this.tarCity; // 设置 p_byte_fld 为目标城市 ID
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 AppointPrefectInCity 操作
        void AppointPrefectInCity(short generalId, byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
            city.AppointmentPrefect(generalId); // 任命将军为城市官员
        }

        // 执行 CanvasAppointPrefectInCity 操作
        void CanvasAppointPrefectInCity(short word0, byte byte0)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            AppointPrefectInCity(word0, byte0); // 执行 AppointPrefectInCity 方法
        }

        // 执行 MoveKingAppointPrefectInCity 操作
        void MoveKingAppointPrefectInCity()
        {
            City city = CityListCache.GetCityByCityId(this.curCity); // 获取当前城市对象
            for (byte byte0 = 0; byte0 < this.chooseGeneralNum; byte0 = (byte)(byte0 + 1))
                city.AddOfficeGeneralId(this.chooseGeneralIdArray[byte0]); // 将将军 ID 添加到城市

            if (city.cityBelongKing == this.chooseGeneralIdArray[0]) // 如果城市的国王 ID 匹配第一个选择的将军 ID
            {
                this.e_boolean_fld = true; // 设置 e_boolean_fld 为 true
                CanvasAppointPrefectInCity(this.chooseGeneralIdArray[0], this.curCity); // 执行 CanvasAppointPrefectInCity 方法
            }
        }

        // 执行 MoveOffGeneral 操作
        void MoveOffGeneral()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象
            for (int i = 0; i < this.chooseGeneralNum; i++)
            {
                short generalId = this.chooseGeneralIdArray[i]; // 获取将军 ID
                city.removeOfficeGeneralId(generalId); // 从城市中移除将军 ID
            }
        }


        // 执行 MoveKingAppointPrefectInCity 和 MoveOffGeneral 方法
        void MoveKingReplaceGeneral()
        {
            MoveKingAppointPrefectInCity(); // 执行 MoveKingAppointPrefectInCity 方法
            MoveOffGeneral(); // 执行 MoveOffGeneral 方法
        }

        // 执行 RemoveGeneralIdInArray 方法
        void RemoveGeneralIdInArray()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象
            short[] officeGeneralId = city.getCityOfficeGeneralIdArray(); // 获取城市的将军 ID 数组

            // 遍历所有将军 ID 并将其从城市中移除
            for (int i = 0; i < officeGeneralId.Length; i++)
            {
                short generalId = officeGeneralId[i];
                city.removeOfficeGeneralId(generalId); // 从城市中移除将军
            }
        }

        // 执行 CanvasMoveKingRefresh 方法
        void CanvasMoveKingRefresh(int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            if (this.X == 1)
            {
                MoveKingAppointPrefectInCity(); // 执行 MoveKingAppointPrefectInCity 方法
                RemoveGeneralIdInArray(); // 执行 RemoveGeneralIdInArray 方法
                this.tarCity = this.curCity; // 更新目标城市为当前城市
                this.Y = 4; // 设置 Y 坐标为 4
            }
            else
            {
                this.HMGeneralId = this.chooseGeneralIdArray[0]; // 设置 HMGeneralId 为选择的将军 ID
                this.Y = 2; // 设置 Y 坐标为 2
            }
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 RebornGeneralMark 方法
        void RebornGeneralMark(short[] aword0, byte byte0)
        {
            for (byte byte1 = 0; byte1 < byte0; byte1 = (byte)(byte1 + 1))
                (GeneralListCache.GetGeneral(aword0[byte1])).IsDie = false; // 将将军标记为未死亡
        }

        // 执行 MoveTooMuchRebornGeneral 方法
        void MoveTooMuchRebornGeneral(int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市的将军 ID 数组

            if (i1 == 1)
            {
                RebornGeneralMark(officeGeneralIdArray, city.getCityGeneralNum()); // 执行 RebornGeneralMark 方法
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            bool flag = false;
            this.a_boolean_fld = true; // 设置 a_boolean_fld 为 true
            this.chooseGeneralNum = 0; // 重置选择的将军数量

            // 遍历将军 ID 数组，处理死亡的将军
            for (byte byte0 = 0; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                if ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte0])).IsDie) // 如果将军死亡
                {
                    if (byte0 == 0)
                        flag = true; // 如果是第一个将军，设置 flag 为 true
                    this.chooseGeneralNum = (byte)(this.chooseGeneralNum + 1); // 增加选择的将军数量
                    this.chooseGeneralIdArray[this.chooseGeneralNum] = officeGeneralIdArray[byte0]; // 添加将军 ID 到选择数组
                    (GeneralListCache.GetGeneral(officeGeneralIdArray[byte0])).IsDie = false; // 将将军标记为未死亡
                }
            }

            this.tipsGeneralId = this.chooseGeneralIdArray[0]; // 设置提示将军 ID

            if (this.X == 1)
            {
                if (this.chooseGeneralNum + CityListCache.GetCityByCityId(this.curCity).getCityGeneralNum() > 10)
                {
                    SetTipsInfo(this.chooseGeneralIdArray[0], "移动武将数过多!"); // 设置提示信息
                    this.Y = 6; // 设置 Y 坐标为 6
                    return;
                }
                this.a_java_lang_String_fld = d.DoThingsResultInfo[0][0]; // 设置字符串字段
            }

            if (this.chooseGeneralNum == city.getCityGeneralNum())
            {
                //this.gamecanvas.Void_m(); // 执行 gamecanvas 的 Void_m 方法
                this.e_boolean_fld = true; // 设置 e_boolean_fld 为 true
                //this.gamecanvas.Repaint(); // 重新绘制 gamecanvas
                return;
            }

            if (this.X == 1)
            {
                if (flag)
                {
                    this.p_byte_fld = this.tarCity; // 设置 p_byte_fld 为目标城市
                    this.c_boolean_fld = false; // 设置 c_boolean_fld 为 false
                    this.Y = 2; // 设置 Y 坐标为 2
                }
                else
                {
                    this.Y = 4; // 设置 Y 坐标为 4
                }
                MoveKingReplaceGeneral(); // 执行 MoveKingReplaceGeneral 方法
            }
            else
            {
                this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
            }
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 CanvasMarkReInitTOMenu 方法
        void CanvasMarkReInitTOMenu(int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 DoCanvasMarkReInitTOMenu 方法
        void DoCanvasMarkReInitTOMenu(int i1)
        {
            CanvasMarkReInitTOMenu(i1); // 执行 CanvasMarkReInitTOMenu 方法
        }

        // 执行 CheckCanvasMarkReInitTOMenu 方法
        void CheckCanvasMarkReInitTOMenu()
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行输送调整城池方法
        void TransportationAdjustCity(short[] aword0)
        {
            CityListCache.GetCityByCityId(this.tarCity).DecreaseMoney(aword0[0]); // 从目标城市减少金钱
            CityListCache.GetCityByCityId(this.tarCity).DecreaseFood(aword0[1]); // 从目标城市减少粮食
            (CityListCache.GetCityByCityId(this.tarCity)).treasureNum = (byte)((CityListCache.GetCityByCityId(this.tarCity)).treasureNum - aword0[2]); // 更新目标城市的宝物数量
            CityListCache.GetCityByCityId(this.curCity).AddMoney(aword0[0]); // 向当前城市添加金钱
            CityListCache.GetCityByCityId(this.curCity).AddFood(aword0[1]); // 向当前城市添加粮食
            (CityListCache.GetCityByCityId(this.curCity)).treasureNum = (byte)((CityListCache.GetCityByCityId(this.curCity)).treasureNum + aword0[2]); // 更新当前城市的宝物数量
        }

        // 执行输送指令方法
        void TransportationOrder(int i1, short[] aword0)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
            }
            else
            {
                TransportationAdjustCity(aword0); // 执行 TransportationAdjustCity 方法
                bool needZhiLing = true; // 标记是否需要指令
                City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市的将军 ID 数组

                // 检查城市中是否有将军拥有技能 4
                for (int i = 0; i < city.getCityGeneralNum(); i++)
                {
                    short id = officeGeneralIdArray[i];
                    if (GetSkill_4(id, 9))
                    {
                        needZhiLing = false; // 如果有将军拥有该技能，标记为不需要指令
                        break;
                    }
                }

                if (needZhiLing)
                {
                    this.Y = (byte)(this.Y + 1); // 如果需要指令，增加 Y 坐标
                }
                else
                {
                    this.Y = (byte)(this.Y + 2); // 如果不需要指令，增加 Y 坐标
                }
                SetTipsInfo(city.prefectId, d.DoThingsResultInfo[0][0]); // 设置提示信息
            }
        }


        // 执行 PrepareStartWar 方法
        void PrepareStartWar(short word0, short word1, int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            // 设置战斗中的资源
            this.humanMoney_inWar = word0; // 设置战斗中的金钱
            this.humanGrain_inWar = word1; // 设置战斗中的粮食
            this.Y = 6; // 设置 Y 坐标为 6
            this.a_java_lang_String_fld = d.DoThingsResultInfo[0][2]; // 设置字符串字段

            // 根据选择的将军数量和城市的将军数量进行处理
            if (this.chooseGeneralNum != CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum())
            {
                if (this.chooseGeneralIdArray[0] == CityListCache.GetCityByCityId(this.tarCity).prefectId)
                {
                    this.c_boolean_fld = false; // 设置 c_boolean_fld 为 false
                    this.p_byte_fld = this.tarCity; // 设置 p_byte_fld 为目标城市
                    this.Y = 3; // 设置 Y 坐标为 3
                }
                else
                {
                    this.c_boolean_fld = false; // 设置 c_boolean_fld 为 false
                    this.d_boolean_fld = false; // 设置 d_boolean_fld 为 false

                    // 复制选择的将军到可执行将军数组
                    for (int j1 = 0; j1 < this.chooseGeneralNum; j1++)
                        this.canToDoGeneral_Array[j1] = this.chooseGeneralIdArray[j1];
                    this.canToDoGeneralNum = this.chooseGeneralNum; // 更新可执行将军数量
                    this.Y = 5; // 设置 Y 坐标为 5
                }
            }

            MoveOffGeneral(); // 执行 MoveOffGeneral 方法
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 奖励将军
        void rewardGeneral(short money)
        {
            General general = GeneralListCache.GetGeneral(this.HMGeneralId); // 获取将军对象
            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象

            if (money == 200)
            {
                city.treasureNum = (byte)(city.treasureNum - 1); // 从城市中减少宝物数量
                general.AddLoyalty(false); // 增加将军的忠诚度
            }
            else
            {
                city.DecreaseMoney(money); // 从城市中减少金钱
                general.AddLoyalty(true); // 增加将军的忠诚度
            }
        }

        // 执行 RewardGeneralTips 方法
        void RewardGeneralTips(short money, int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
            }
            else
            {
                rewardGeneral(money); // 奖励将军
                this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
                SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[2][2]); // 设置提示信息
            }
        }

        // 执行 void_i_l 方法
        void void_i_l(int i1)
        {
            CanvasMarkReInitTOMenu(i1); // 执行 CanvasMarkReInitTOMenu 方法
        }

        // 执行 void_bi_c 方法
        void void_bi_c(byte byte0, int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            this.m_byte_fld = byte0; // 设置 m_byte_fld 为 byte0
            this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 void_aZ 方法
        void void_aZ()
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            this.Y = 0; // 设置 Y 坐标为 0
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 void_i_m 方法
        void void_i_m(int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 1)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
            }
            else
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[4][0]); // 设置提示信息
                this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
            }
        }

        // 执行 BuyWeaponTips 方法
        void BuyWeaponTips(int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            switch (i1)
            {
                case 0:
                    SetTipsInfo(this.HMGeneralId, d.DoThingsResultInfo[4][1]); // 设置提示信息
                    this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
                    break;
                case 1:
                    InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                    break;
                case 2:
                    SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "资财不足"); // 设置提示信息
                    this.Y = 3; // 设置 Y 坐标为 3
                    break;
                case 3:
                    SetTipsInfo(this.HMGeneralId, "启禀主公,属下无法使用此武器"); // 设置提示信息
                    this.Y = 3; // 设置 Y 坐标为 3
                    break;
            }
        }

        // 执行 void_i_o 方法
        void void_i_o(int i1)
        {
            if (!CanvasMark1()) // 检查 CanvasMark1() 的结果
                return; // 如果返回 false，退出方法

            if (i1 == 5)
            {
                InitiateCanvasMark(); // 执行 InitiateCanvasMark 方法
                return;
            }

            this.eventId = i1; // 设置 eventId 为 i1
            this.Y = (byte)(this.Y + 1); // 增加 Y 坐标
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 void_b_s 方法
        void void_b_s(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }


        // 执行 MoveOrderTips 方法
        void MoveOrderTips(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            // 遍历所有城市，检查是否有可以移动的城市
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1 = (byte)(byte1 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte1); // 获取城市对象
                if (city.cityBelongKing == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing && byte1 != this.tarCity)
                {
                    this.a_boolean_fld = false; // 设置 a_boolean_fld 为 false
                    DoMenuSwitch(); // 执行 DoMenuSwitch 方法
                    return;
                }
            }
            // 如果没有符合条件的城市，设置提示信息和 Y 坐标
            this.Y = 6;
            SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "当前无可移动的城!");
        }

        // 执行 TransportationOrderTips 方法
        void TransportationOrderTips(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            // 遍历所有城市，检查是否有可以输送的城市
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1 = (byte)(byte1 + 1))
            {
                City city = CityListCache.GetCityByCityId(byte1); // 获取城市对象
                if (city.cityBelongKing == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing && byte1 != this.tarCity)
                {
                    DoMenuSwitch(); // 执行 DoMenuSwitch 方法
                    return;
                }
            }
            // 如果没有符合条件的城市，设置提示信息和 Y 坐标
            this.Y = 3;
            SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "当前无可输送的城!");
        }

        // 执行 RewardOrder 方法
        void RewardOrder(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0
            this.canToDoGeneralNum = 0; // 初始化可执行将军数量

            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市中的将军 ID 数组

            // 遍历城市中的将军，检查忠诚度
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]); // 获取将军对象
                if (general.getLoyalty() < 99) // 如果将军忠诚度小于 99
                {
                    this.canToDoGeneralNum = (byte)(this.canToDoGeneralNum + 1); // 增加可执行将军数量
                    this.canToDoGeneral_Array[this.canToDoGeneralNum] = officeGeneralIdArray[byte1]; // 添加将军 ID 到数组中
                }
            }

            if (this.canToDoGeneralNum > 0)
            {
                this.d_boolean_fld = false; // 设置 d_boolean_fld 为 false
                DoMenuSwitch(); // 执行 DoMenuSwitch 方法
            }
            else
            {
                this.Y = 3; // 设置 Y 坐标为 3
                SetTipsInfo(city.prefectId, "吏士皆忠心不贰!"); // 设置提示信息
            }
        }

        // 执行 SearchOrder 方法
        void SearchOrder(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象

            if (city.getCityGeneralNum() == 10) // 如果城市中的将军数量为 10
            {
                SetTipsInfo(city.prefectId, "本城置吏已足!"); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            if (city.GetOppositionGeneralNum() == 0) // 如果在野将军数量为 0
            {
                SetTipsInfo(city.prefectId, "野无遗贤!"); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            this.d_boolean_fld = false; // 设置 d_boolean_fld 为 false
            this.canToDoGeneralNum = city.GetOppositionGeneralNum(); // 设置可执行将军数量

            if (this.canToDoGeneralNum > 10)
                this.canToDoGeneralNum = 10; // 如果可执行将军数量大于 10，设置为 10

            // 将在野将军 ID 添加到数组中
            for (byte byte1 = 0; byte1 < this.canToDoGeneralNum; byte1 = (byte)(byte1 + 1))
                this.canToDoGeneral_Array[byte1] = city.GetOppositionGeneralId(byte1);

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 AppointVeto 方法
        void AppointVeto(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象

            if (city.cityBelongKing == city.prefectId) // 如果城市的国王 ID 与城市的行政官 ID 相同
            {
                SetTipsInfo(city.cityBelongKing, d.DoThingsResultInfo[2][4]); // 设置提示信息
                this.Y = 2; // 设置 Y 坐标为 2
                return;
            }

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 检查是否有足够的金钱
        bool haveEnoughMoney()
        {
            if (CityListCache.GetCityByCityId(this.tarCity).GetMoney() == 0) // 如果目标城市的金钱为 0
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "资财不足"); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return true; // 返回 true
            }
            return false; // 返回 false
        }

        // 执行开垦操作
        void Reclaim(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            if (haveEnoughMoney()) // 检查是否有足够的金钱
                return;

            if (CityListCache.GetCityByCityId(this.tarCity).agro == 999) // 如果城市的农业值为 999
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][2]); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            this.b_int_fld = 0; // 设置 b_int_fld 为 0
            this.Y = 0; // 设置 Y 坐标为 0
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行劝商操作
        void Mercantile(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            if (haveEnoughMoney()) // 检查是否有足够的金钱
                return;

            if (CityListCache.GetCityByCityId(this.tarCity).trade == 999) // 如果城市的贸易值为 999
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][5]); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            this.b_int_fld = 1; // 设置 b_int_fld 为 1
            this.Y = 0; // 设置 Y 坐标为 0
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }


        // 执行 TameFlood 方法
        void TameFlood(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            if (haveEnoughMoney()) // 检查是否有足够的金钱
                return;

            // 检查城市的洪水控制值
            if (CityListCache.GetCityByCityId(this.tarCity).floodControl == 99)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][6]); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            this.b_int_fld = 2; // 设置 b_int_fld 为 2
            this.Y = 0; // 设置 Y 坐标为 0
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 Patrol 方法
        void Patrol(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            if (haveEnoughMoney()) // 检查是否有足够的金钱
                return;

            // 检查城市的人口数量
            if (CityListCache.GetCityByCityId(this.tarCity).population == 990000)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, d.DoThingsResultInfo[3][7]); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            this.b_int_fld = 3; // 设置 b_int_fld 为 3
            this.Y = 0; // 设置 Y 坐标为 0
            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 Employ 方法
        void Employ(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            // 检查城市中的将军数量
            if (CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum() == 10)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "本城置吏已足!"); // 设置提示信息
                this.Y = 5; // 设置 Y 坐标为 5
                return;
            }

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 Shopping 方法
        void Shopping(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            // 检查城市是否有粮店
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x8) != 8)
            {
                this.Y = 2; // 设置 Y 坐标为 2
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "本城无粮店,无法买卖粮草"); // 设置提示信息
                return;
            }

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 执行 Smithy 方法
        void Smithy(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            // 检查城市是否有武器店
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x1) != 1)
            {
                this.Y = 3; // 设置 Y 坐标为 3
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "本城无武器店,无法购入武器"); // 设置提示信息
                return;
            }

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 计算将军的学习情况
        short AIDoLearn(byte cityId)
        {
            short learnNum = 0; // 初始化学习数量
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市中的将军 ID 数组

            // 遍历城市中的将军
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                short generalId = officeGeneralIdArray[byte1]; // 获取将军 ID
                General general = GeneralListCache.GetGeneral(generalId); // 获取将军对象

                // 根据将军的 IQ 值来决定是否可以学习
                if (general.IQ < 120)
                {
                    switch (general.IQ / 10)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            if (general.experience >= getLearnNeedExp(generalId)) // 检查是否有足够的经验
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // 增加 IQ 值
                            learnNum = (short)(learnNum + 1); // 增加学习数量
                            break;
                        case 5:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 2)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // 增加 IQ 值
                            learnNum = (short)(learnNum + 1); // 增加学习数量
                            break;
                        case 6:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 3)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // 增加 IQ 值
                            learnNum = (short)(learnNum + 1); // 增加学习数量
                            break;
                        case 7:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 4)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // 增加 IQ 值
                            learnNum = (short)(learnNum + 1); // 增加学习数量
                            break;
                        case 8:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level >= 7)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // 增加 IQ 值
                            break;
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            if (general.experience >= getLearnNeedExp(generalId) && general.level == 8)
                                general.IQ = (byte)(general.IQ + SchoolIncreaseIQValue(generalId)); // 增加 IQ 值
                            learnNum = (short)(learnNum + 1); // 增加学习数量
                            break;
                    }
                }
            }
            return learnNum; // 返回学习数量
        }

        // 检查是否可以学习
        bool canLearn(byte cityId)
        {
            bool flag = false; // 初始化标志为 false
            this.canToDoGeneralNum = 0; // 初始化可执行将军数量
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市中的将军 ID 数组

            // 遍历城市中的将军
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]); // 获取将军对象
                if (general.IQ < 120 && general.experience >= getLearnNeedExp(officeGeneralIdArray[byte1])) // 检查将军的 IQ 和经验
                {
                    this.canToDoGeneralNum = (byte)(this.canToDoGeneralNum + 1); // 增加可执行将军数量
                    this.canToDoGeneral_Array[this.canToDoGeneralNum] = officeGeneralIdArray[byte1]; // 添加将军 ID 到数组中
                }
            }
            return flag; // 返回标志
        }

        // 执行 School 方法
        void School(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0

            // 检查城市是否有学堂
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x2) == 2)
            {
                canLearn(this.tarCity); // 检查是否可以学习
                if (this.canToDoGeneralNum > 0)
                {
                    this.d_boolean_fld = false; // 设置 d_boolean_fld 为 false
                    DoMenuSwitch(); // 执行 DoMenuSwitch 方法
                }
                else
                {
                    SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "本城没有可以学习的武将"); // 设置提示信息
                    this.Y = 2; // 设置 Y 坐标为 2
                }
            }
            else
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "本城无学堂,无法修习智力"); // 设置提示信息
                this.Y = 2; // 设置 Y 坐标为 2
            }
        }

        // 获取学习所需经验
        short getLearnNeedExp(short generalId)
        {
            short needExp = 0; // 初始化所需经验
            needExp = (short)(200 + (GeneralListCache.GetGeneral(generalId).IQ * 50)); // 计算所需经验
            return needExp; // 返回所需经验
        }


        // 执行 Hospital 方法
        void Hospital(byte byte0)
        {
            bool flag = false; // 初始化标志为 false
            this.X = byte0; // 设置 X 为 byte0
            City city = CityListCache.GetCityByCityId(this.tarCity); // 获取城市对象
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市中的将军 ID 数组

            // 检查城市是否有医院
            if ((this.k_byte_array1d_fld[this.tarCity] & 0x4) != 4)
            {
                SetTipsInfo(city.prefectId, "本城无医院,无法治疗武将"); // 设置提示信息
                this.Y = 3; // 设置 Y 坐标为 3
                return;
            }

            this.canToDoGeneralNum = 0; // 初始化可以处理的将军数量
            for (byte byte1 = 0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]); // 获取将军对象
                if (general.getCurPhysical() < general.maxPhysical) // 检查将军的当前体力是否小于最大体力
                {
                    this.canToDoGeneralNum = (byte)(this.canToDoGeneralNum + 1); // 增加可以处理的将军数量
                    this.canToDoGeneral_Array[this.canToDoGeneralNum] = officeGeneralIdArray[byte1]; // 将将军 ID 添加到数组中
                }
            }

            // 根据城市的资金情况决定下一步操作
            if (this.canToDoGeneralNum > 0)
            {
                if (city.GetMoney() >= 50) // 检查城市是否有足够的资金
                {
                    this.d_boolean_fld = false; // 设置 d_boolean_fld 为 false
                    DoMenuSwitch(); // 执行 DoMenuSwitch 方法
                }
                else
                {
                    SetTipsInfo(city.prefectId, "资财不足"); // 设置提示信息
                    this.Y = 3; // 设置 Y 坐标为 3
                }
            }
            else
            {
                SetTipsInfo(city.prefectId, "将士均龙精虎猛!"); // 设置提示信息
                this.Y = 3; // 设置 Y 坐标为 3
            }
        }

        // 执行 Alienate 方法
        void Alienate(byte byte0)
        {
            this.X = byte0; // 设置 X 为 byte0
            Country userCountry = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId); // 获取用户国家对象
            this.noAllianceCountryIdArray = userCountry.GetNoCountryIdAllianceCountryIdArray(); // 获取无联盟国家的 ID 数组
            this.x_byte_fld = (byte)this.noAllianceCountryIdArray.Length; // 设置 x_byte_fld 为无联盟国家数量

            // 检查用户国家是否已与所有势力同盟
            if (userCountry.GetAllianceSize() == CountryListCache.getCountrySize() - 1)
            {
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "已与所有势力同盟"); // 设置提示信息
                this.Y = 4; // 设置 Y 坐标为 4
                return;
            }

            DoMenuSwitch(); // 执行 DoMenuSwitch 方法
        }

        // 检查城市是否属于联盟
        bool theCityIsAlliance(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
            if (city.cityBelongKing == 0)
                return false; // 城市没有国王，返回 false

            Country otherCountry = CountryListCache.GetCountryByKingId(city.cityBelongKing); // 获取属于该城市的国家对象
            if (otherCountry == null)
                return false; // 国家对象为空，返回 false

            Alliance alliance = otherCountry.getAllianceById(GameInfo.humanCountryId); // 获取联盟对象
            return (alliance != null); // 如果联盟对象不为空，返回 true，否则返回 false
        }

        // 执行 AttackOrder 方法
        void AttackOrder(byte byte0)
        {
            if (this.bngd) // 检查是否已经攻击过
            {
                this.X = byte0; // 设置 X 为 byte0
                SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "你这个月已经攻打2次了，不能再攻打了!"); // 设置提示信息
                this.Y = 8; // 设置 Y 坐标为 8
            }
            else
            {
                this.X = byte0; // 设置 X 为 byte0
                bool can = false; // 初始化可攻击标志为 false

                // 遍历连接的城市 ID
                for (byte byte2 = 0; byte2 < (CityListCache.GetCityByCityId(this.tarCity)).connectCityId.Length; byte2 = (byte)(byte2 + 1))
                {
                    byte otherCityId = (byte)(CityListCache.GetCityByCityId(this.tarCity)).connectCityId[byte2]; // 获取连接城市 ID
                    if ((CityListCache.GetCityByCityId(otherCityId)).cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                        if (!theCityIsAlliance(otherCityId)) // 如果城市不是联盟城市
                        {
                            can = true; // 设置可以攻击标志为 true
                            break; // 退出循环
                        }
                }

                if (can)
                {
                    this.a_boolean_fld = false; // 设置 a_boolean_fld 为 false
                    DoMenuSwitch(); // 执行 DoMenuSwitch 方法
                }
                else
                {
                    SetTipsInfo(CityListCache.GetCityByCityId(this.tarCity).prefectId, "当前无可战争城市!"); // 设置提示信息
                    this.Y = 8; // 设置 Y 坐标为 8
                }
            }
        }

        // 根据输入的整数 i1 计算返回值
        int int_i_a(int i1)
        {
            byte byte0; // 定义 byte0

            // 根据 i1 的值确定 byte0 的值
            if (i1 < 0)
            {
                i1 = -1;
            }
            else
            {
                i1 /= 1000;
            }

            switch (i1)
            {
                case -1:
                    byte0 = 5;
                    break;
                case 0:
                    byte0 = 10;
                    break;
                case 1:
                    byte0 = 20;
                    break;
                case 2:
                    byte0 = 50;
                    break;
                case 3:
                    byte0 = 70;
                    break;
                default:
                    byte0 = 80;
                    break;
            }

            // 根据随机数决定是否修改 X 的值
            if (CommonUtils.getRandomInt() % 250 > byte0)
                this.X = 0;

            return i1; // 返回 i1
        }

        // 执行 void_bs1b_a 方法
        void void_bs1b_a(byte byte0, short[] aword0, byte byte1)
        {
            CityListCache.GetCityByCityId(byte0).prefectId = aword0[0]; // 设置城市的 prefectId
        }

        // 执行 void_bs1b_b 方法
        void void_bs1b_b(byte byte0, short[] aword0, byte byte1)
        {
            AiAppointmentPrefect(byte0, aword0, byte1); // 执行 AppointmentPrefect 方法
        }

        // 执行 void_s1b_c 方法
        void void_s1b_c(short[] aword0, byte byte0)
        {
            for (int i1 = 0; i1 < byte0; i1++)
            {
                if (aword0[i1] == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing) // 检查是否与城市的国王相同
                {
                    short word0 = aword0[0];
                    aword0[0] = aword0[i1];
                    aword0[i1] = word0; // 交换数组元素
                    return; // 退出方法
                }
            }
        }


        /// <summary>
        /// 计算所需食物的数量
        /// </summary>
        /// <param name="city"></param>
        /// <param name="chooseGeneralIdArray"></param>
        /// <param name="chooseGeneralNum"></param>
        /// <returns></returns>
        int NeedFoodValue(City city, short[] chooseGeneralIdArray, int chooseGeneralNum)
        {
            int allGeneralSoldier = 0; // 初始化所有将军的士兵数量
            allGeneralSoldier = CalculateTotalGeneralSoldierNum(chooseGeneralIdArray, (byte)chooseGeneralNum); // 计算所有将军的士兵数量
            allGeneralSoldier = allGeneralSoldier * 4 / 1000 + 1; // 计算修正后的士兵数量

            // 计算所需食物数量
            int needFood = CommonUtils.getRandomInt() % allGeneralSoldier * 30 + allGeneralSoldier * 30;
            if (needFood < city.GetFood() / 2)
            {
                needFood = city.GetFood() / 2; // 如果所需食物少于城市的一半食物，则取城市食物的一半
            }
            else if (needFood >= city.GetFood())
            {
                needFood = city.GetFood() * 2 / 3; // 如果所需食物大于等于城市食物，则取城市食物的三分之二
            }
            return needFood; // 返回所需食物数量
        }

        /// <summary>
        /// 执行占领城市方法
        /// </summary>
        /// <param name="generalIdArray"></param>
        /// <param name="generalNum"></param>
        /// <param name="food"></param>
        /// <param name="money"></param>
        void OccupyCity(short[] generalIdArray, byte generalNum, int food, int money)
        {
            CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).AddCity(this.curCity); // 将当前城市添加到国家
            City city = CityListCache.GetCityByCityId(this.curCity); // 获取城市对象
            for (int k1 = 0; k1 < generalNum; k1++)
                city.AddOfficeGeneralId(generalIdArray[k1]); // 将将军 ID 添加到城市中
            city.cityBelongKing = CityListCache.GetCityByCityId(this.tarCity).cityBelongKing; // 设置城市的国王
            city.prefectId = generalIdArray[0]; // 设置城市的 prefectId
            city.AddFood((short)food); // 添加食物
            city.AddMoney((short)money); // 添加资金
        }

        /// <summary>
        /// 执行 DefenseTurnToAttack 方法
        /// </summary>
        void DefenseTurnToAttack()
        {
            Country attackCountry = CountryListCache.GetCountryByKingId(CityListCache.GetCityByCityId(this.tarCity).cityBelongKing); // 获取攻击国
            Country defenseCountry = CountryListCache.GetCountryByKingId(CityListCache.GetCityByCityId(this.curCity).cityBelongKing); // 获取防御国
            attackCountry.AddCity(this.curCity); // 将城市添加到攻击国
            defenseCountry.RemoveCity(this.curCity); // 从防御国中移除城市
        }

        // 执行俘获武将到登用界面方法
        void void_s_j(short generalId)
        {
            CityListCache.GetCityByCityId(this.curCity).AddNotFoundGeneralId(generalId); // 将将军 ID 添加到未找到的将军列表
        }

        /// <summary>
        /// 执行俘获将领方法
        /// </summary>
        /// <param name="word0"></param>
        void CaptureGeneral(short word0)
        {
            General general = GeneralListCache.GetGeneral(word0); // 获取将军对象
            byte AddLoyalty = (byte)(100 - general.getLoyalty()); // 计算增加的忠诚度
            byte baseLoyalty = (byte)(60 + AddLoyalty); // 计算基础忠诚度
            if (baseLoyalty >= 99 || baseLoyalty < 0)
            {
                general.SetLoyalty((byte)99); // 如果基础忠诚度不在有效范围内，则设置为 99
            }
            else
            {
                general.SetLoyalty((byte)(baseLoyalty + CommonUtils.getRandomInt() % (99 - baseLoyalty))); // 设置将军的忠诚度
            }
            CityListCache.GetCityByCityId(this.curCity).AddOfficeGeneralId(word0); // 将将军 ID 添加到城市中
        }

        // 执行占领空城方法
        byte MoveGeneralToEmptyCity(short generalId, byte[] abyte0, byte byte0, byte cityId, short kingId)
        {
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
            if (city.cityBelongKing == 0) // 如果城市没有国王
            {
                Country country = CountryListCache.GetCountryByKingId(kingId); // 获取国家对象
                country.AddCity(cityId); // 将城市添加到国家
                city.cityBelongKing = country.countryKingId; // 设置城市的国王
                city.AddOfficeGeneralId(generalId); // 将将军 ID 添加到城市中
                return byte0; // 返回 byte0
            }
            city.AddOfficeGeneralId(generalId); // 将将军 ID 添加到城市中
            if (city.getCityGeneralNum() == 10) // 如果城市中将军数量达到 10
            {
                byte0 = (byte)(byte0 - 1); // 减少 byte0 的值
                if (byte0 != 0)
                {
                    byte byte4 = 0;
                    while (byte4 < byte0)
                    {
                        if (abyte0[byte4] == cityId) // 查找与城市 ID 相同的元素
                        {
                            abyte0[byte4] = abyte0[byte0]; // 交换元素
                            break; // 退出循环
                        }
                        byte4 = (byte)(byte4 + 1); // 增加索引
                    }
                }
            }
            return byte0; // 返回 byte0
        }

        // 执行 MoveAddCityMoneyFood 方法
        void MoveAddCityMoneyFood(byte byte0, int i1, int j1)
        {
            City city = CityListCache.GetCityByCityId(byte0); // 获取城市对象
            if (i1 < 0)
                i1 = 0; // 确保食物值为非负
            if (j1 < 0)
                j1 = 0; // 确保资金值为非负
            city.AddMoney((short)j1); // 添加资金
            city.AddFood((short)i1); // 添加食物
        }

       

        /// <summary>
        /// 处理将军撤退逻辑并判断是否成功撤退
        /// </summary>
        /// <param name="generalIdArray"></param>
        /// <param name="generalNum"></param>
        /// <param name="kingId"></param>
        /// <param name="food"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        bool IsRetreat(short[] generalIdArray, byte generalNum, short kingId, int food, int money)
        {
            Country country = CountryListCache.GetCountryByKingId(kingId); // 根据国王ID获取国家
            City city = CityListCache.GetCityByCityId(this.curCity); // 获取当前城市
            short[] tempGeneralIdArray = new short[generalNum]; // 临时将军ID数组
            byte tempGeneralNum = 0; // 临时将军数量
            bool chiefGeneralCaptured = false; // 标记主将是否被俘获

            // 遍历所有将军ID
            for (int i = 0; i < generalNum; i++)
            {
                short generalId = generalIdArray[i];
                if (generalId == country.countryKingId) // 判断将军是否为国王
                {
                    tempGeneralIdArray[tempGeneralNum] = generalId;
                    tempGeneralNum = (byte)(tempGeneralNum + 1);
                    continue; // 跳过后续操作
                }

                if (city.getCityGeneralNum() > 9) // 如果城市中的将军数量大于9
                {
                    tempGeneralIdArray[tempGeneralNum] = generalId;
                    tempGeneralNum = (byte)(tempGeneralNum + 1);
                    continue; // 跳过后续操作
                }

                byte[] citys = country.GetCities(); // 获取国家的所有城市
                General general = GeneralListCache.GetGeneral(generalIdArray[i]); // 获取将军对象

                // 判断国家是否只剩下当前城市
                if (citys.Length < 1 || (citys.Length == 1 && citys[0] == this.curCity))
                {
                    // 根据将军和国王的 phase 值计算是否俘获
                    if (GetdPhase(GeneralListCache.GetGeneral(kingId).phase, general.phase) > 20)
                    {
                        CaptureGeneral(generalId); // 将将军俘获
                        if (i == 0)
                        {
                            chiefGeneralCaptured = true; // 标记主将被俘获
                            Console.WriteLine("主将：" + general.generalName + "被俘获！！！！");
                        }
                        else
                        {
                            Console.WriteLine("武将：" + general.generalName + "被俘获！！！！");
                        }
                        continue;
                    }
                }
                else if (general.getCurPhysical() <= 40 && general.generalSoldier <= 0 && GetdPhase(GeneralListCache.GetGeneral(kingId).phase, general.phase) > 15)
                {
                    byte capturedProbability;

                    // 根据将军的 IQ、force 和 lead 值计算被俘几率
                    if (general.IQ >= 95 || general.force >= 95 || general.lead >= 95)
                    {
                        capturedProbability = 5;
                    }
                    else if (general.IQ >= 90 || general.force >= 90 || general.lead >= 95)
                    {
                        capturedProbability = 15;
                    }
                    else if (general.IQ >= 80 || general.force >= 80 || general.lead >= 95)
                    {
                        capturedProbability = 25;
                    }
                    else
                    {
                        capturedProbability = 40;
                    }

                    // 随机判断是否俘获将军
                    if (CommonUtils.getRandomInt() % 100 <= capturedProbability)
                    {
                        CaptureGeneral(generalId); // 将将军俘获
                        if (i == 0)
                        {
                            chiefGeneralCaptured = true; // 标记主将被俘获
                            Console.WriteLine("主将：" + general.generalName + "被俘获！！！！");
                        }
                        else
                        {
                            Console.WriteLine("武将：" + general.generalName + "被俘获！！！！");
                        }
                        continue;
                    }
                }
                tempGeneralIdArray[tempGeneralNum] = generalId; // 将将军ID添加到临时数组
                tempGeneralNum = (byte)(tempGeneralNum + 1);
                continue;
            }

            bool masterRetreat = false; // 标记主将是否撤退成功
            if (tempGeneralNum > 0)
            {
                if (generalIdArray.Length > tempGeneralNum)
                {
                    short[] tempOfficeGeneralId = new short[tempGeneralNum];
                    Array.Copy(tempGeneralIdArray, 0, tempOfficeGeneralId, 0, tempGeneralNum); // 复制临时将军数组
                    generalIdArray = tempOfficeGeneralId; // 更新将军数组
                }
                masterRetreat = country.RetreatGeneralToCity(generalIdArray, this.curCity, food, money, chiefGeneralCaptured); // 将将军撤退到城市
            }

            if (!masterRetreat) // 如果主将没有成功撤退
            {
                city.AddFood((short)food); // 给城市添加食物
                city.AddMoney((short)money); // 给城市添加金钱
                if (kingId == generalIdArray[0])
                    return true; // 如果国王是第一个撤退的将军，返回true
            }

            return false; // 返回false
        }

        /// <summary>
        /// 处理势力灭亡逻辑
        /// </summary>
        /// <param name="attackGeneralArray"></param>
        /// <param name="attackGeneralNum"></param>
        /// <param name="carryFood"></param>
        /// <param name="money"></param>
        void IsDestroyed(short[] attackGeneralArray, byte attackGeneralNum, int carryFood, int money)
        {
            City city = CityListCache.GetCityByCityId(this.curCity); // 获取当前城市
            byte defenseGeneralNum = city.getCityGeneralNum(); // 获取防御将军数量
            short kingId = city.cityBelongKing; // 获取城市所属国王
            Country country = CountryListCache.GetCountryByKingId(kingId); // 获取国家对象
            short[] defenseGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市中的防御将军ID数组

            city.ClearAllOfficeGeneral(); // 清空城市中的所有将军
            DefenseTurnToAttack(); // 处理城市所属国的变更

            for (int l1 = 0; l1 < attackGeneralNum; l1++)
                city.AddOfficeGeneralId(attackGeneralArray[l1]); // 将进攻方的将军ID添加到城市中

            city.prefectId = attackGeneralArray[0]; // 设置城市的 prefectId
            city.cityBelongKing = CityListCache.GetCityByCityId(this.tarCity).cityBelongKing; // 更新城市的国王

            short takeThing = city.GetMoney(); // 获取城市当前金钱
            city.SetMoney((short)money); // 更新城市金钱
            money = takeThing; // 保存原有金钱

            takeThing = city.GetFood(); // 获取城市当前食物
            city.SetFood((short)carryFood); // 更新城市食物
            carryFood = takeThing; // 保存原有食物

            // 判断防御将军是否撤退成功
            bool flag = IsRetreat(defenseGeneralIdArray, defenseGeneralNum, kingId, carryFood, money);
            if (flag) // 如果撤退成功
            {
                if (country.GetHaveCityNum() > 0)
                {
                    GameInfo.countryDieTips = 1;
                    short newKingGeneralId = country.Inherit(); // 继承新国王
                    GameInfo.ShowInfo = GeneralListCache.GetGeneral(defenseGeneralIdArray[0]).generalName + "死亡,新君主 " + GeneralListCache.GetGeneral(newKingGeneralId).generalName + " 继位!";
                    this.f_short_fld = newKingGeneralId; // 更新继位的将军ID
                }
                else
                {
                    // 处理国家消亡后的逻辑
                    byte[] tempCountryOrder = new byte[this.countryOrder.Length - 1];
                    int index = 0;
                    for (int i = 0; i < this.countryOrder.Length; i++)
                    {
                        if (this.countryOrder[i] != country.countryId)
                        {
                            if (index == this.countryOrder.Length - 1)
                            {
                                Console.Error.WriteLine("系统错误!无法找到与countryId:" + country.countryId + "相同的势力编号");
                            }
                            else
                            {
                                tempCountryOrder[index] = this.countryOrder[i];
                                index++;
                            }
                        }
                    }
                    GameInfo.chooseGeneralName = GeneralListCache.GetGeneral(country.countryKingId).generalName; // 设置消亡国家的国王名字
                    this.countryOrder = tempCountryOrder; // 更新国家顺序
                    CountryListCache.removeCountry(country.countryId); // 移除国家
                }
            }
        }


        // 计算进攻与防守双方的武将战斗结果
        void ffzs(short[] aword0, byte byte0, short[] aword1, byte byte1)
        {
            int gfhszl = 0; // 进攻方总战斗力
            int gfxhzl = 0; // 进攻方剩余战斗力
            int pjxhzl = 0; // 平均战斗力
            int ffxhzl = 0; // 防守方剩余战斗力
            byte[] gfjq = new byte[byte0]; // 进攻方武将战斗加权
            byte[] ffjq = new byte[byte1]; // 防守方武将战斗加权
            int[] xhbl = new int[byte1]; // 损兵比例

            // 计算进攻方每个武将的战斗加权
            for (byte byte5 = 0; byte5 < byte0; byte5 = (byte)(byte5 + 1))
            {
                int k = 1; // 武将战斗力基数
                byte zl = (GeneralListCache.GetGeneral(aword0[byte5])).IQ; // 智力
                byte wl = (GeneralListCache.GetGeneral(aword0[byte5])).lead; // 统率

                // 根据智力调整战斗力
                if (zl >= 100) k += 6;
                else if (zl >= 95) k += 5;
                else if (zl >= 88) k += 4;
                else if (zl >= 82) k += 3;
                else if (zl >= 75) k += 2;
                else if (zl >= 68) k++;

                // 根据统率调整战斗力
                if (wl >= 100) k += 6;
                else if (wl >= 95) k += 5;
                else if (wl >= 88) k += 4;
                else if (wl >= 82) k += 3;
                else if (wl >= 75) k += 2;
                else if (wl >= 68) k++;

                // 根据智力低值减少战斗力
                if (zl <= 55) k--;
                else if (zl <= 40) k -= 2;
                else if (zl <= 25) k -= 3;

                if (k < 1) k = 1; // 确保战斗力不低于1
                gfjq[byte5] = (byte)k;
            }

            // 计算进攻方总战斗力
            for (int i = 0; i < byte0; i++)
            {
                gfhszl += gfjq[i] * (GeneralListCache.GetGeneral(aword0[i]).IQ + 3 * GeneralListCache.GetGeneral(aword0[i]).lead / 2) *
                            (GeneralListCache.GetGeneral(aword0[i]).generalSoldier + 200) / 100;
            }
            gfxhzl = this.gfZZL - gfhszl; // 计算进攻方剩余战斗力
            ffxhzl = gfxhzl; // 初始化防守方剩余战斗力
            pjxhzl = ffxhzl / byte1; // 计算防守方的平均战斗力

            // 计算防守方每个武将的战斗加权
            for (byte byte6 = 0; byte6 < byte1; byte6 = (byte)(byte6 + 1))
            {
                int k = 1; // 武将战斗力基数
                byte zl = (GeneralListCache.GetGeneral(aword1[byte6])).IQ; // 智力
                byte wl = (GeneralListCache.GetGeneral(aword1[byte6])).lead; // 统率

                // 根据智力调整战斗力
                if (zl >= 100) k += 6;
                else if (zl >= 95) k += 5;
                else if (zl >= 88) k += 4;
                else if (zl >= 82) k += 3;
                else if (zl >= 75) k += 2;
                else if (zl >= 68) k++;

                // 根据统率调整战斗力
                if (wl >= 100) k += 6;
                else if (wl >= 95) k += 5;
                else if (wl >= 88) k += 4;
                else if (wl >= 82) k += 3;
                else if (wl >= 75) k += 2;
                else if (wl >= 68) k++;

                // 根据智力低值减少战斗力
                if (zl <= 55) k--;
                else if (zl <= 40) k -= 2;
                else if (zl <= 25) k -= 3;

                if (byte6 == 0) k += 2; // 主将额外加成
                if (k < 1) k = 1; // 确保战斗力不低于1
                ffjq[byte6] = (byte)k;
            }

            // 计算防守方每个武将的损兵比例
            for (int j = 0; j < byte1; j++)
            {
                xhbl[j] = pjxhzl * 100 / ffjq[j] * (GeneralListCache.GetGeneral(aword1[j]).IQ + 3 * GeneralListCache.GetGeneral(aword1[j]).lead / 2) - 200;
                if (xhbl[j] < 0) xhbl[j] = 0; // 确保损兵比例不为负
            }

            // 模拟战斗过程
            while (true)
            {
                int wb = 0; // 记录战斗已结束的武将数

                // 计算战斗损失
                for (int k = 0; k < byte1; k++)
                {
                    if (GeneralListCache.GetGeneral(aword1[k]).generalSoldier == 0) wb++;
                    if (GeneralListCache.GetGeneral(aword1[k]).generalSoldier > 0)
                    {
                        if (GeneralListCache.GetGeneral(aword1[k]).generalSoldier > xhbl[k])
                        {
                            GeneralListCache.GetGeneral(aword1[k]).generalSoldier -= (short)xhbl[k];
                            ffxhzl -= ffjq[k] * (GeneralListCache.GetGeneral(aword1[k]).IQ + 3 * GeneralListCache.GetGeneral(aword1[k]).lead / 2) * xhbl[k] / 100;
                        }
                        else
                        {
                            ffxhzl -= ffjq[k] * (GeneralListCache.GetGeneral(aword1[k]).IQ + 3 * GeneralListCache.GetGeneral(aword1[k]).lead / 2) *
                                        (GeneralListCache.GetGeneral(aword1[k]).generalSoldier + 200) / 100;
                            GeneralListCache.GetGeneral(aword1[k]).generalSoldier = 0;
                            wb++;
                        }
                    }
                }

                // 重新计算剩余战斗力
                if (wb < byte1 - 1)
                {
                    pjxhzl = ffxhzl / (byte1 - wb); // 重新分配剩余战斗力
                    for (int m = 0; m < byte1; m++)
                    {
                        if (GeneralListCache.GetGeneral(aword1[m]).generalSoldier > 0)
                        {
                            xhbl[m] = pjxhzl * 100 / ffjq[m] * (GeneralListCache.GetGeneral(aword1[m]).IQ + 3 * GeneralListCache.GetGeneral(aword1[m]).lead / 2);
                            if (xhbl[m] < 0) xhbl[m] = 0; // 确保损兵比例不为负
                        }
                    }
                    if (ffxhzl <= 100) break; // 如果剩余战斗力低于一定值，战斗结束
                }
                else break;
            }
        }


        /// <summary>
        /// 返回将兵差值单位的数量
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int DiffSoldierGen(byte byte0, int i1)
        {
            return i1;
        }

        /// <summary>
        /// 计算单个武将的总战斗力
        /// </summary>
        /// <param name="generalId"></param>
        /// <returns></returns>
        int SingleGeneralFightValue(short generalId)
        {
            General general = GeneralListCache.GetGeneral(generalId); // 根据武将ID获取武将
            if (general == null)
                return 0;

            // 计算战斗力 (武力、智力、统帅等因素影响)
            int i1 = (general.force + general.IQ + general.lead * 2) / 2 * (general.generalSoldier + 150);
            return i1;
        }

        /// <summary>
        /// 计算整个武将军团的总战斗力
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        int WholeGeneralFightValue(short[] aword0, int i1)
        {
            int j1 = 0;
            for (int l1 = 0; l1 < i1; l1++)
            {
                int k1 = SingleGeneralFightValue(aword0[l1]); // 计算每个武将的战斗力
                j1 += k1; // 累加总战斗力
            }
            return j1;
        }

        // 根据武将数组计算己方阵列的战斗力
        void gffpjy(short[] generalIdArray, byte generalNum)
        {
            this.gfZL = new int[generalNum]; // 己方总战斗力
            this.gfzdl = new int[generalNum]; // 己方单个武将战斗力
            this.gfZZL = 1; // 己方总战斗力初始值

            for (byte i = 0; i < generalNum; i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(generalIdArray[i]); // 获取武将
                byte zl = general.IQ; // 智力
                byte ts = general.lead; // 统帅
                byte dj = general.level; // 等级
                byte wl = general.force; // 武力

                // 计算武将战斗力 (多属性加成公式)
                int gjl = (int)(ts * 1.42D + zl * 0.25D + wl * 0.33D + ((ts * 2 + wl + zl) * (dj - 1)) * 0.04D);

                // 根据智力值的不同调整战斗力
                if (zl >= 100)
                    gjl += 15;
                else if (zl >= 95)
                    gjl += 12;
                else if (zl >= 88)
                    gjl += 8;
                else if (zl >= 80)
                    gjl += 5;
                else if (zl >= 70)
                    gjl += 3;
                else if (zl >= 55)
                    gjl -= 5;
                else if (zl >= 40)
                    gjl -= 10;
                else
                    gjl -= 20;

                // 最终战斗力计算 (考虑平方值与兵力的影响)
                long gjl2 = (gjl * gjl * gjl / 100000 + 1);
                this.gfzdl[i] = (int)gjl2;

                // 调整战斗力上限与下限
                if (general.generalSoldier < 500)
                    this.gfzdl[i] = Math.Min(100, this.gfzdl[i]);

                if (this.gfzdl[i] < 20)
                    this.gfzdl[i] = Math.Max(general.generalSoldier / 150, this.gfzdl[i]);

                // 总战斗力计算
                this.gfZL[i] = this.gfzdl[i];
                this.gfZL[i] = this.gfZL[i] * (general.generalSoldier + 1);
                this.gfZZL += this.gfZL[i];
            }
        }

        // 根据武将数组计算敌方阵列的战斗力
        void fffpjy(short[] generalIdArray)
        {
            this.ffZL = new int[generalIdArray.Length]; // 敌方总战斗力
            this.ffzdl = new int[generalIdArray.Length]; // 敌方单个武将战斗力
            this.ffZZL = 1; // 敌方总战斗力初始值

            for (byte i = 0; i < generalIdArray.Length; i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(generalIdArray[i]); // 获取武将
                byte zl = general.IQ; // 智力
                byte ts = general.lead; // 统帅
                byte dj = general.level; // 等级
                byte wl = general.force; // 武力

                // 计算武将战斗力 (多属性加成公式)
                int gjl = (int)(ts * 1.42D + zl * 0.25D + wl * 0.33D + ((ts * 2 + wl + zl) * (dj - 1)) * 0.04D);

                if (i == 0)
                    gjl = (int)(gjl * 1.3D); // 队长额外加成

                // 根据智力值的不同调整战斗力
                if (zl >= 100)
                    gjl += 15;
                else if (zl >= 95)
                    gjl += 12;
                else if (zl >= 88)
                    gjl += 8;
                else if (zl >= 80)
                    gjl += 5;
                else if (zl >= 70)
                    gjl += 3;
                else if (zl >= 55)
                    gjl -= 5;
                else if (zl >= 40)
                    gjl -= 10;
                else
                    gjl -= 20;

                // 最终战斗力计算
                long gjl2 = (gjl * gjl * gjl / 100000 + 1);
                this.ffzdl[i] = (int)gjl2;

                // 调整战斗力上限与下限
                if (general.generalSoldier < 500)
                    this.ffzdl[i] = Math.Min(150, this.ffzdl[i]);

                if (this.ffzdl[i] < 20)
                    this.ffzdl[i] = Math.Max(general.generalSoldier / 150, this.ffzdl[i]);

                // 总战斗力计算
                if (i == 0)
                    this.ffZL[i] = this.ffZL[i] * (general.generalSoldier + 1);
                else
                    this.ffZL[i] = this.ffZL[i] * (general.generalSoldier + 1);

                this.ffZZL += this.ffZL[i];
            }
        }


        // 判断是否占领城市
        bool isCapture(short[] generalIdArray, byte generalNum, int food, int j1)
        {
            gffpjy(generalIdArray, generalNum); // 计算己方武将的战斗力
            City city = CityListCache.GetCityByCityId(this.curCity); // 获取当前城市
            fffpjy(city.getCityOfficeGeneralIdArray()); // 计算敌方武将的战斗力

            // 若AI进行战争
            if (AIWar2(generalIdArray, generalNum, food))
            {
                IsDestroyed(generalIdArray, generalNum, food, j1); // 处理战后事宜
                return true; // 占领成功
            }

            // 战争失败，进行相应处理
            IsRetreat(generalIdArray, generalNum, (CityListCache.GetCityByCityId(this.tarCity)).cityBelongKing, food, j1);
            return false;
        }

        // 计算进攻方的消耗粮草
        short atkEatFood(short[] genId, byte genNum)
        {
            short eatNum = 3; // 初始消耗为3
            short atkTotleSoldier = CalculateTotalGeneralSoldierNum(genId, genNum); // 计算进攻方的总兵力
            eatNum = (short)(eatNum + atkTotleSoldier * 4 / 1000); // 按兵力比例增加消耗
            return eatNum;
        }

        // 计算防守方的消耗粮草
        short defEatFood(short[] genId)
        {
            short eatNum = 1; // 初始消耗为1
            short defTotleSoldier = CalculateTotalGeneralSoldierNum(genId, (byte)genId.Length); // 计算防守方的总兵力
            eatNum = (short)(eatNum + defTotleSoldier * 4 / 1000); // 按兵力比例增加消耗
            return eatNum;
        }

        // AI进行战争模拟
        bool AIWar2(short[] genId, byte genNum, int atkfood)
        {
            bool occupy = false; // 是否占领
            bool atknot = false; // 进攻方是否无法进攻
            bool defnot = false; // 防守方是否无法防守
            byte day = 0; // 战斗持续天数
            City city = CityListCache.GetCityByCityId(this.curCity); // 获取当前城市

            // 战斗模拟循环
            while (true)
            {
                day = (byte)(day + 1); // 天数增加
                atkfood -= atkEatFood(genId, genNum); // 进攻方消耗粮草

                if (atkfood <= 0)
                {
                    atkfood = 0; // 粮草耗尽
                    break;
                }

                // 防守方消耗粮草
                city.DecreaseFood(defEatFood(city.getCityOfficeGeneralIdArray()));

                // 若防守方粮草耗尽
                if (city.GetFood() <= 0)
                {
                    city.SetFood((short)0); // 设置防守方粮草为0
                    occupy = true; // 城市被占领
                    break;
                }

                if (day < 3) // 战斗持续时间小于3天继续
                    continue;

                if (day > 30) // 战斗持续时间超过30天结束
                    break;

                // 寻找进攻方的攻击武将
                short attackGeneralId = -1;
                byte[] sequence1 = new byte[genNum];
                for (byte i = 0; i < genNum; i = (byte)(i + 1))
                    sequence1[i] = i;
                sequence1 = randomArray(sequence1); // 随机打乱进攻方武将顺序

                // 查找能够进攻的武将
                for (byte i = 0; i < sequence1.Length; i = (byte)(i + 1))
                {
                    byte index1 = sequence1[i];
                    int soldier = GeneralListCache.GetGeneral(genId[index1]).generalSoldier;
                    byte phy = GeneralListCache.GetGeneral(genId[index1]).getCurPhysical();
                    if (soldier > 0 || phy > 50)
                    {
                        attackGeneralId = genId[index1]; // 找到攻击武将
                        atknot = false;
                        break;
                    }
                    atknot = true; // 无法找到攻击武将
                }

                // 随机跳过本次战斗
                if (CommonUtils.getRandomInt() % 100 < 15)
                    continue;

                if (atknot)
                    break; // 无法继续进攻

                // 寻找防守方的防守武将
                short preventGeneralId = -1;
                byte[] sequence2 = new byte[city.getCityGeneralNum()];
                for (byte b1 = 0; b1 < city.getCityGeneralNum(); b1 = (byte)(b1 + 1))
                    sequence2[b1] = b1;
                sequence2 = randomArray(sequence2); // 随机打乱防守方武将顺序
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

                // 查找能够防守的武将
                for (byte j = 0; j < sequence2.Length; j = (byte)(j + 1))
                {
                    byte index2 = sequence2[j];
                    short generalId = officeGeneralIdArray[index2];
                    int soldier = GeneralListCache.GetGeneral(generalId).generalSoldier;
                    byte phy = GeneralListCache.GetGeneral(generalId).getCurPhysical();
                    if (soldier > 0 || phy > 50)
                    {
                        preventGeneralId = generalId; // 找到防守武将
                        defnot = false;
                        break;
                    }
                    defnot = true; // 无法找到防守武将
                }

                if (defnot)
                {
                    occupy = true; // 防守失败，占领城市
                    break;
                }

                if (attackGeneralId > 0 && preventGeneralId > 0)
                    moniAtk2(attackGeneralId, preventGeneralId); // 模拟攻防战
            }

            return occupy; // 返回是否占领成功
        }

        // 增加武将的经验
        void addExp_P(short atkGen, short defGen, int totalExp)
        {
            // 计算经验比例
            float pesent = satrapVal(defGen) / satrapVal(atkGen);
            if (pesent > 1.5F)
                pesent = 1.5F;
            else if (pesent < 0.1F)
                pesent = 0.1F;

            // 计算可获取的经验值
            short canhaveExp = (short)(int)(totalExp * pesent);
            General general = GeneralListCache.GetGeneral(atkGen); // 获取进攻武将
            general.addexperience(canhaveExp / 3); // 增加经验
        }

        // AI战争增加经验
        void AIWarAddEXP(short atkGen, short defGen, int totalExp)
        {
            float pesent = satrapVal(defGen) / satrapVal(atkGen);
            if (pesent > 1.5F)
                pesent = 1.5F;
            else if (pesent < 0.5F)
                pesent = 0.5F;

            // 计算可获取的总经验
            short canhaveExp = (short)(int)(totalExp * pesent + 1.0F);
            short IQExp = 0, leadExp = 0, forceExp = 0;

            // 获取进攻和防守的武将
            General atkGeneral = GeneralListCache.GetGeneral(atkGen);
            General defGeneral = GeneralListCache.GetGeneral(defGen);

            // 若智力差距较大，增加智力经验
            if (atkGeneral.IQ > defGeneral.IQ + 20)
                IQExp = (short)(int)(canhaveExp * 0.3F);

            // 若武力差距较大，增加武力经验并减少体力
            if (atkGeneral.force > defGeneral.force + 20 && atkGeneral.getCurPhysical() * 2 > atkGeneral.maxPhysical)
            {
                byte physical = (byte)(CommonUtils.getRandomInt() % (atkGeneral.getCurPhysical() - atkGeneral.maxPhysical / 2 + 1));
                float forcepecent = (physical * 2) / atkGeneral.getCurPhysical();
                if (forcepecent < 0.3F)
                    forcepecent = 0.3F;

                forceExp = (short)(int)(forcepecent * canhaveExp * 0.2F);
                atkGeneral.decreaseCurPhysical(physical); // 减少体力
            }

            // 计算统帅经验
            leadExp = (short)(canhaveExp - IQExp - forceExp);

            // 增加各属性经验
            GeneralListCache.addforceExp(atkGen, (byte)(forceExp / 50));
            GeneralListCache.addIQExp(atkGen, (byte)(IQExp / 100));
            GeneralListCache.addLeadExp(atkGen, (byte)(leadExp / 300));
        }


        void AIWarAddEXP2(short atkGen, short defGen, int totalExp)
        {
            // 计算经验百分比，取值范围在0.5到1.5之间
            float pesent = satrapVal(defGen) / satrapVal(atkGen);
            if (pesent > 1.5F)
            {
                pesent = 1.5F;
            }
            else if (pesent < 0.5F)
            {
                pesent = 0.5F;
            }

            // 计算可获得的总经验
            short canhaveExp = (short)(int)(totalExp * pesent + 1.0F);
            short IQExp = 0;
            short leadExp = 0;

            // 如果攻击将领的智力比防守将领高出20，智力经验加成
            if (GeneralListCache.GetGeneral(atkGen).IQ > GeneralListCache.GetGeneral(defGen).IQ + 20)
                IQExp = (short)(int)(canhaveExp * 0.3F);

            // 剩余经验分配给领导力
            leadExp = (short)(canhaveExp - IQExp);

            // 增加将领的智力和领导力经验
            GeneralListCache.addIQExp(atkGen, (byte)(IQExp / 100));
            GeneralListCache.addLeadExp(atkGen, (byte)(leadExp / 300));
        }

        int getSword(int power, byte t, short genId)
        {
            // 根据军队类型t调整power值
            switch (t)
            {
                case 0:
                    if (GeneralListCache.GetGeneral(genId).army[0] == 0)
                        power = (int)(power * 0.8F);
                    else if (GeneralListCache.GetGeneral(genId).army[0] == 1)
                        power = (int)(power * 0.9F);
                    else if (GeneralListCache.GetGeneral(genId).army[0] == 2)
                        power = (int)(power * 1.0F);
                    else if (GeneralListCache.GetGeneral(genId).army[0] == 3)
                        power = (int)(power * 1.1F);
                    break;
                case 1:
                    if (GeneralListCache.GetGeneral(genId).army[1] == 0)
                        power = (int)(power * 0.8F);
                    else if (GeneralListCache.GetGeneral(genId).army[1] == 1)
                        power = (int)(power * 0.9F);
                    else if (GeneralListCache.GetGeneral(genId).army[1] == 2)
                        power = (int)(power * 1.0F);
                    else if (GeneralListCache.GetGeneral(genId).army[1] == 3)
                        power = (int)(power * 1.1F);
                    break;
                case 2:
                    if (GeneralListCache.GetGeneral(genId).army[2] == 0)
                        power = (int)(power * 0.8F);
                    else if (GeneralListCache.GetGeneral(genId).army[2] == 1)
                        power = (int)(power * 0.9F);
                    else if (GeneralListCache.GetGeneral(genId).army[2] == 2)
                        power = (int)(power * 1.0F);
                    else if (GeneralListCache.GetGeneral(genId).army[2] == 3)
                        power = (int)(power * 1.1F);
                    break;
            }

            // 如果power小于等于0，则将其设置为1
            if (power <= 0)
                power = 1;

            return power;
        }

        byte getWarTTT(byte city)
        {
            // 根据随机数判断战争状态
            byte index = (byte)(CommonUtils.getRandomInt() % 10);
            if (index >= this.moniwarT[city][1])
            {
                index = 2;
            }
            else if (index >= this.moniwarT[city][0])
            {
                index = 1;
            }
            else
            {
                index = 0;
            }

            return index;
        }

        int moniAtkgetGenPower(int power, bool ists, short genId)
        {
            // 根据将领的士兵数量调整攻击力
            long gjl_jq = (1 + power * power * power / 100000);
            if (ists && GeneralListCache.GetGeneral(genId).generalSoldier <= 500)
                gjl_jq = Math.Min(100L, gjl_jq);

            return (int)gjl_jq;
        }

        int getGenSinglePower(short id)
        {
            // 计算将领的单个战斗力
            int power = GeneralListCache.GetGeneral(id).force * 2 +
                        GeneralListCache.GetGeneral(id).force * WeaponListCache.getWeapon(GeneralListCache.GetGeneral(id).weapon).weaponProperties / 100 +
                        GeneralListCache.GetGeneral(id).force * WeaponListCache.getWeapon(GeneralListCache.GetGeneral(id).armor).weaponProperties / 100;
            long p = (1 + power * power * power / 100000);

            return (int)p;
        }

        byte cangetphy(short id)
        {
            // 获取将领的当前体力
            byte phy;
            if (GeneralListCache.GetGeneral(id).getCurPhysical() > 35)
            {
                int ph = CommonUtils.getRandomInt() % GeneralListCache.GetGeneral(id).getCurPhysical() + 30;
                if (ph >= GeneralListCache.GetGeneral(id).getCurPhysical())
                    ph = GeneralListCache.GetGeneral(id).getCurPhysical() - 35;

                phy = (byte)ph;
            }
            else
            {
                phy = 1;
            }

            return phy;
        }


        void moniAtk2(short attackGeneralId, short preventGeneralId)
        {
            City city = CityListCache.GetCityByCityId(this.curCity);
            bool isprefectId = (city.prefectId == preventGeneralId);
            short soldier1 = (GeneralListCache.GetGeneral(attackGeneralId)).generalSoldier;
            short soldier2 = (GeneralListCache.GetGeneral(preventGeneralId)).generalSoldier;
            if (soldier1 > 0 && soldier2 > 0)
            {
                if (isprefectId)
                {
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power2 = (int)(power2 * 1.33D);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    power2 = moniAtkgetGenPower(power2, true, preventGeneralId);
                    int sword1 = power1 * soldier1;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        int dea2 = sword2 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                    else
                    {
                        int dea1 = sword1 / power1;
                        int dea2 = sword1 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                }
                else
                {
                    byte t = getWarTTT(this.tarCity);
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power1 = getSword(power1, t, attackGeneralId);
                    power2 = getSword(power2, t, preventGeneralId);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    power2 = moniAtkgetGenPower(power2, false, preventGeneralId);
                    int sword1 = power1 * soldier1;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        int dea2 = sword2 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                    else
                    {
                        int dea1 = sword1 / power1;
                        int dea2 = sword1 / power2;
                        changeSoldier(attackGeneralId, (short)dea1);
                        changeSoldier(preventGeneralId, (short)dea2);
                        addExp_P(attackGeneralId, preventGeneralId, dea2);
                        AIWarAddEXP2(attackGeneralId, preventGeneralId, (short)dea2);
                        addExp_P(preventGeneralId, attackGeneralId, dea1);
                        AIWarAddEXP2(preventGeneralId, attackGeneralId, (short)dea1);
                    }
                }
            }
            else if (soldier1 > 0 && soldier2 <= 0)
            {
                if (isprefectId)
                {
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = getGenSinglePower(preventGeneralId);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    int sword1 = power1 * soldier1;
                    byte phy = cangetphy(preventGeneralId);
                    int sword2 = power2 * phy * 3;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        changeSoldier(attackGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(dea1 / 50));
                    }
                    else
                    {
                        (GeneralListCache.GetGeneral(attackGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword1 / power2 * 3);
                        GeneralListCache.GetGeneral(preventGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(soldier1 / 50));
                    }
                }
                else
                {
                    byte t = getWarTTT(this.tarCity);
                    int power1 = satrapVal(attackGeneralId);
                    int power2 = getGenSinglePower(preventGeneralId);
                    power1 = getSword(power1, t, attackGeneralId);
                    power1 = moniAtkgetGenPower(power1, false, attackGeneralId);
                    int sword1 = power1 * soldier1;
                    byte phy = cangetphy(preventGeneralId);
                    int sword2 = power2 * phy * 2;
                    if (sword1 > sword2)
                    {
                        int dea1 = sword2 / power1;
                        changeSoldier(attackGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(dea1 / 50));
                    }
                    else
                    {
                        (GeneralListCache.GetGeneral(attackGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword1 / power2 * 2);
                        GeneralListCache.GetGeneral(preventGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(preventGeneralId, (byte)(soldier1 / 50));
                    }
                }
            }
            else if (soldier1 <= 0 && soldier2 > 0)
            {
                if (isprefectId)
                {
                    int power1 = getGenSinglePower(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power2 = (int)(power2 * 1.33D);
                    power2 = moniAtkgetGenPower(power2, true, preventGeneralId);
                    byte phy = cangetphy(attackGeneralId);
                    int sword1 = power1 * phy;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        (GeneralListCache.GetGeneral(preventGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword2 / power1);
                        GeneralListCache.GetGeneral(attackGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(soldier2 / 50));
                    }
                    else
                    {
                        int dea1 = sword1 / power2;
                        changeSoldier(preventGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(dea1 / 50));
                    }
                }
                else
                {
                    byte t = getWarTTT(this.tarCity);
                    int power1 = getGenSinglePower(attackGeneralId);
                    int power2 = satrapVal(preventGeneralId);
                    power2 = getSword(power2, t, preventGeneralId);
                    power2 = moniAtkgetGenPower(power2, false, preventGeneralId);
                    byte phy = cangetphy(attackGeneralId);
                    int sword1 = power1 * phy * 2;
                    int sword2 = power2 * soldier2;
                    if (sword1 > sword2)
                    {
                        (GeneralListCache.GetGeneral(preventGeneralId)).generalSoldier = 0;
                        byte physical = (byte)(sword2 / power1 * 2);
                        GeneralListCache.GetGeneral(attackGeneralId).decreaseCurPhysical(physical);
                        if (GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical() < 1)
                            GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)1);
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(soldier2 / 50));
                    }
                    else
                    {
                        int dea1 = sword1 / power2;
                        changeSoldier(preventGeneralId, (short)dea1);
                        GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)(35 + CommonUtils.getRandomInt() % 5));
                        GeneralListCache.addforceExp(attackGeneralId, (byte)(dea1 / 50));
                    }
                }
            }
            else if (soldier1 <= 0 && soldier2 <= 0)
            {
                int power1 = (GeneralListCache.GetGeneral(attackGeneralId)).force + (GeneralListCache.GetGeneral(attackGeneralId)).force * ((WeaponListCache.getWeapon((GeneralListCache.GetGeneral(attackGeneralId)).weapon)).weaponProperties + (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(attackGeneralId)).armor)).weaponProperties) / 100;
                int power2 = (GeneralListCache.GetGeneral(preventGeneralId)).force + (GeneralListCache.GetGeneral(preventGeneralId)).force * ((WeaponListCache.getWeapon((GeneralListCache.GetGeneral(preventGeneralId)).weapon)).weaponProperties + (WeaponListCache.getWeapon((GeneralListCache.GetGeneral(preventGeneralId)).armor)).weaponProperties) / 100;
                power1 = 1 + power1 * power1 / 2;
                power2 = 1 + power2 * power2 / 2;
                byte phy1 = GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical();
                byte phy2 = GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical();
                if (power1 * phy1 > power2 * phy2)
                {
                    GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)10);
                    byte x = (byte)((power1 * phy1 - power2 * phy2) / power1);
                    GeneralListCache.GetGeneral(attackGeneralId).decreaseCurPhysical(x);
                    if (GeneralListCache.GetGeneral(attackGeneralId).getCurPhysical() < 10)
                        GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)10);
                    GeneralListCache.addforceExp(attackGeneralId, (byte)10);
                    GeneralListCache.addforceExp(preventGeneralId, (byte)2);
                }
                else if (power1 * phy1 == power2 * phy2)
                {
                    GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)(10 + CommonUtils.getRandomInt() % 5));
                    GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)(10 + CommonUtils.getRandomInt() % 5));
                    GeneralListCache.addforceExp(attackGeneralId, (byte)5);
                    GeneralListCache.addforceExp(preventGeneralId, (byte)5);
                }
                else
                {
                    GeneralListCache.GetGeneral(attackGeneralId).setCurPhysical((byte)10);
                    byte x = (byte)((power2 * phy2 - power1 * phy1) / power2);
                    GeneralListCache.GetGeneral(preventGeneralId).decreaseCurPhysical(x);
                    if (GeneralListCache.GetGeneral(preventGeneralId).getCurPhysical() < 10)
                        GeneralListCache.GetGeneral(preventGeneralId).setCurPhysical((byte)10);
                    GeneralListCache.addforceExp(attackGeneralId, (byte)2);
                    GeneralListCache.addforceExp(preventGeneralId, (byte)10);
                }
            }
        }

        void moniAtk(short[] genId1, short[] genId2, byte index1, byte index2)
        {
            // 判断攻击方的战力是否大于防守方
            if (this.gfZL[index1] > this.ffZL[index2])
            {
                // 计算防守方损失的士兵数量，dea1 为攻击方，dea2 为防守方
                int dea1 = this.ffZL[index2] / this.gfzdl[index1];
                int dea2;
                // 判断防守方是否为第一个防守将领
                if (index2 == 0)
                {
                    dea2 = this.ffZL[index2] / this.ffzdl[index2];
                }
                else
                {
                    dea2 = this.ffZL[index2] / this.ffzdl[index2];
                }
                // 调整攻击方和防守方的士兵数量
                changeSoldier(genId1[index1], (short)dea1);
                changeSoldier(genId2[index2], (short)dea2);
                // 更新战力
                this.gfZL[index1] = this.gfZL[index1] - this.ffZL[index2];
                this.ffZL[index2] = 0;
                // 增加经验值
                addExp_P(genId1[index1], genId2[index2], dea2);
                AIWarAddEXP(genId1[index1], genId2[index2], (short)dea2);
                addExp_P(genId2[index2], genId1[index1], dea1);
                AIWarAddEXP(genId2[index2], genId1[index1], (short)dea1);
            }
            else
            {
                // 计算攻击方损失的士兵数量
                int dea1 = this.gfZL[index1] / this.gfzdl[index1];
                int dea2;
                // 判断防守方是否为第一个防守将领
                if (index2 == 0)
                {
                    dea2 = this.gfZL[index1] / this.ffzdl[index2];
                }
                else
                {
                    dea2 = this.gfZL[index1] / this.ffzdl[index2];
                }
                // 更新防守方的战力
                this.ffZL[index2] = this.ffZL[index2] - this.gfZL[index1];
                this.gfZL[index1] = 0;
                // 调整士兵数量
                changeSoldier(genId1[index1], (short)dea1);
                changeSoldier(genId2[index2], (short)dea2);
                // 增加经验值
                addExp_P(genId1[index1], genId2[index2], dea2);
                AIWarAddEXP(genId1[index1], genId2[index2], (short)dea2);
                addExp_P(genId2[index2], genId1[index1], dea1);
                AIWarAddEXP(genId2[index2], genId1[index1], (short)dea1);
            }
        }


        void changeSoldier(short genId, short num)
        {
            // 减少将领的士兵数量
            GeneralListCache.GetGeneral(genId).generalSoldier -= num;
            // 确保士兵数量不会为负数
            if (GeneralListCache.GetGeneral(genId).generalSoldier < 0)
                GeneralListCache.GetGeneral(genId).generalSoldier = 0;
        }

        //观察模式
        void void_bb()
        {
            // 如果当前是观察模式
            if (GameInfo.isWatch)
            {
                try
                {
                    // 线程同步，暂停 1500 毫秒
                    lock (this)
                    {
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                catch (Exception exception) { }
                // 重绘游戏画面
                //this.gamecanvas.repaint();
            }
            else
            {/*
                // 获取当前系统时间
                for (long l1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    //this.gamecanvas.getKeyValue() == 0; l1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)
                {
                    // 计算经过的时间
                    long l2 = ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - l1);
                    if (l2 < 100)
                    {
                        try
                        {
                            // 线程同步，暂停足够的时间以维持 100 毫秒的间隔
                            lock (this)
                            {
                                System.Threading.Thread.Sleep((int)(100 - l2));
                            }
                        }
                        catch (Exception exception) { }
                    }
                    // 重绘游戏画面
                    //this.gamecanvas.repaint();
                }
          */  }
        }



        // 发起战争
        void startWar()
        {
            int needFood = 0;
            int needMoney = 0;

            // 获取目标城市的实例
            City tCity = CityListCache.GetCityByCityId(this.tarCity);

            // 计算敌方临近城市的最大攻击力
            int enemyAdjacentAtkPower = CountryListCache.getOtherCityMaxAtkPower(this.tarCity, this.curCity);
            enemyAdjacentAtkPower = (int)(enemyAdjacentAtkPower * 0.3D); // 取30%的值

            // 获取战事办公室中的将领 ID 数组
            short[] warOfficeGeneralIdArray = tCity.GetWarOfficeGeneralIdArray(enemyAdjacentAtkPower);

            // 选择的将领数量
            this.chooseGeneralNum = (byte)warOfficeGeneralIdArray.Length;

            // 如果没有将领可以参与战争，直接返回
            if (this.chooseGeneralNum == 0)
                return;

            // 移除战事办公室的将领
            for (int i = 0; i < warOfficeGeneralIdArray.Length; i++)
                tCity.removeOfficeGeneralId(warOfficeGeneralIdArray[i]);

            // 重新任命太守
            tCity.AppointmentPrefect();

            // 初始化选择的将领 ID 数组
            this.chooseGeneralIdArray = new short[10];

            // 将战事办公室的将领 ID 填充到选择的将领数组中
            for (int i = 0; i < warOfficeGeneralIdArray.Length; i++)
                this.chooseGeneralIdArray[i] = warOfficeGeneralIdArray[i];

            // 计算所需粮食
            needFood = NeedFoodValue(tCity, this.chooseGeneralIdArray, this.chooseGeneralNum);

            // 获取当前城市实例
            City cCity = CityListCache.GetCityByCityId(this.curCity);

            // 获取当前城市所属国王的 ID
            short kingId = cCity.cityBelongKing;

            // 计算所需金钱，若金钱少于50，设为0，否则取一半
            if (tCity.GetMoney() < 50)
            {
                needMoney = 0;
            }
            else
            {
                needMoney = tCity.GetMoney() / 2;
            }

            // 如果当前城市没有国王，减少所需粮食和金钱
            if (kingId == 0)
            {
                needFood /= 5;
                needMoney /= 5;
            }

            // 减少目标城市的金钱和粮食
            tCity.DecreaseMoney((short)needMoney);
            tCity.DecreaseFood((short)needFood);

            // 垃圾回收
            System.GC.Collect();

            // 判断进攻方是否是玩家控制的国家
            if (kingId == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
            {
                // 更新显示信息
                GameInfo.ShowInfo = $"{GeneralListCache.GetGeneral((CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId).generalName}军攻打 {cCity.cityName}...";

                // 设置事件 ID
                this.eventId = 1;

                // 执行相应的游戏事件
                RefreshFeedBack((byte)19);
                void_bb();

                // 记录战争中的金钱和粮食
                this.aiMoney_inWar = (short)needMoney;
                this.aiGrain_inWar = (short)needFood;
                this.j_byte_fld = 3;
                return;
            }

            // 若当前城市无国王
            if (kingId == 0)
            {
                this.eventId = 2;
                RefreshFeedBack((byte)19);
                FloodDisasterCanvans();
                OccupyCity(this.chooseGeneralIdArray, this.chooseGeneralNum, needFood, needMoney);
            }
            else
            {
                // 获取敌方国家 ID
                byte countryId = (CountryListCache.GetCountryByKingId(kingId)).countryId;

                // 构建显示信息的字符串
                string str = "[";
                for (int j = 0; j < this.chooseGeneralNum && j < 3; j++)
                    str += $"{GeneralListCache.GetGeneral(this.chooseGeneralIdArray[j]).generalName}、";

                // 移除最后一个 "、"
                str = str.Substring(0, str.Length - 1);
                str += "]";

                if (this.chooseGeneralNum > 3)
                    str += $"等{this.chooseGeneralNum}员大将";

                str = $"{GeneralListCache.GetGeneral((CountryListCache.GetCountryByCountryId(this.curTurnsCountryId)).countryKingId).generalName}军 从{tCity.cityName}派出{str}对{GeneralListCache.GetGeneral(kingId).generalName}的{cCity.cityName}发起战争！";

                // 输出信息到控制台
                Console.WriteLine(str);

                // 更新游戏显示信息
                GameInfo.ShowInfo = str;

                // 设置事件 ID
                this.eventId = 1;

                // 处理战争事件
                RefreshFeedBack((byte)19);
                FloodDisasterCanvans();

                // 判断是否能够占领城市
                if (isCapture(this.chooseGeneralIdArray, this.chooseGeneralNum, needFood, needMoney))
                {
                    this.eventId = 4;
                }
                else
                {
                    this.eventId = 5;
                }

                // 继续处理战争事件
                RefreshFeedBack((byte)19);
                FloodDisasterCanvans();

                // 检查敌方国家是否已经灭亡
                if (CountryListCache.GetCountryByCountryId(countryId) == null)
                {
                    this.AIGeneralId = kingId;
                    this.m_byte_fld = countryId;
                    this.eventId = 18;
                    RefreshFeedBack((byte)19);
                    FloodDisasterCanvans();
                }
                else if ((CountryListCache.GetCountryByCountryId(countryId)).countryKingId != kingId)
                {
                    this.AIGeneralId = kingId;
                    this.m_byte_fld = countryId;
                    this.eventId = 19;
                    RefreshFeedBack((byte)19);
                    FloodDisasterCanvans();
                }
            }

            // 暂停500毫秒以模拟事件延迟
            try
            {
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception exception) { }

            // 垃圾回收
            System.GC.Collect();
        }


        // 检查城市中所有将领的体力是否都大于 40
        bool IsAllGeneralHpTooLow(byte byte0)
        {
            // 获取城市实例
            City city = CityListCache.GetCityByCityId(byte0);

            // 获取城市中在职的将领 ID 数组
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 遍历城市中的将领
            for (int i1 = 0; i1 < city.getCityGeneralNum(); i1++)
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i1]);

                // 如果将领的体力小于最大体力且体力不超过 40，则返回 false
                if (general.getCurPhysical() < general.maxPhysical && general.getCurPhysical() <= 40)
                    return false;
            }

            // 所有将领体力均符合要求，返回 true
            return true;
        }

        // 调用其他方法进行计算
        int TrappedUnitNumb_e(byte byte0, byte byte1)
        {
            return DiffSoldierGenByFightBetweenCity(byte0, byte1);
        }

        // 判断当前国家是否与玩家结盟
        bool isAllianceWithUser()
        {
            // 获取玩家所在的国家
            Country country = CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId);

            // 获取结盟国家的列表
            List<Alliance> allianceCountry = country.allianceList;

            // 如果没有结盟国家，返回 false
            if (allianceCountry.Count == 0)
                return false;

            // 遍历结盟列表，判断是否与当前回合国家结盟
            for (int i = 0; i < allianceCountry.Count; i++)
            {
                Alliance alliance = allianceCountry [i];
                if (alliance.countryId == this.curTurnsCountryId)
                    return true;
            }

            return false;
        }

        // 计算最佳进攻城市
        int FindAttackedCity()
        {
            int j1 = -1001;  // 初始化评分
            bool flag = isAllianceWithUser();  // 判断是否与玩家结盟

            // 遍历当前国家的所有城市
            for (int byte2 = 0; byte2 < CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).GetHaveCityNum(); byte2++)
            {
                byte cityId = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).getCity(byte2);

                // 如果城市的将领数大于 2，则继续判断
                if (CityListCache.GetCityByCityId(cityId).getCityGeneralNum() > 2)
                {
                    // 遍历连接城市
                    for (byte byte3 = 0; byte3 < (CityListCache.GetCityByCityId(cityId)).connectCityId.Length; byte3 = (byte)(byte3 + 1))
                    {
                        byte byte1 = (byte)(CityListCache.GetCityByCityId(cityId)).connectCityId[byte3];

                        // 判断当前城市与连接城市是否属于不同的国王
                        if ((CityListCache.GetCityByCityId(cityId)).cityBelongKing != (CityListCache.GetCityByCityId(byte1)).cityBelongKing &&
                            (!flag || (CityListCache.GetCityByCityId(byte1)).cityBelongKing != (CityListCache.GetCityByCityId(GameInfo.humanCountryId)).cityBelongKing))
                        {
                            // 计算城市进攻价值
                            int i1 = TrappedUnitNumb_e(cityId, byte1);

                            // 记录最大值
                            if (i1 > j1)
                            {
                                j1 = i1;
                                this.tarCity = cityId;  // 目标城市
                                this.curCity = byte1;   // 当前城市
                            }
                        }
                    }
                }
            }

            // 如果评分超过阈值，设置进攻模式
            if (j1 >= -1000)
                this.X = 3;

            return j1;
        }

        // 判断当前回合国家是否需要征兵
        bool needConscription(byte curTurnsCountryId)
        {
            return AiJudDraft(curTurnsCountryId);
        }

        // 征调当前城市所有将领的士兵
        void GeneralSoldierToReserve()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity);

            // 遍历城市中的将领
            for (byte byte0 = 0; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                // 将将领的士兵加入城市的预备士兵中，并将将领的士兵数量置零
                city.cityReserveSoldier += GeneralListCache.GetGeneral(city.getCityOfficeGeneralIdArray()[byte0]).generalSoldier;
                GeneralListCache.GetGeneral(city.getCityOfficeGeneralIdArray()[byte0]).generalSoldier = 0;
            }
        }

        // 对将领进行排序，按统率能力值排序
        void SortGeneralFightValue()
        {
            City city = CityListCache.GetCityByCityId(this.tarCity);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 遍历将领列表进行排序
            for (byte byte0 = 1; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                short generalId1 = officeGeneralIdArray[byte0];
                int i = satrapVal(generalId1);  // 获取将领1的统率能力

                // 与剩余的将领进行比较，找到统率能力更高的将领
                for (byte byte1 = byte0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    short generalId2 = officeGeneralIdArray[byte1];
                    int j = satrapVal(generalId2);  // 获取将领2的统率能力

                    // 如果将领2的能力值更高，则交换
                    if (j > i)
                    {
                        short max = generalId2;
                        generalId2 = generalId1;
                        generalId1 = max;
                    }
                }
            }
        }

        // AI 进行士兵分配
        void AIDistributionSoldier()
        {
            SortGeneralFightValue();  // 对将领进行排序
            GeneralSoldierToReserve();  // 将所有将领的士兵收集到城市的预备士兵中

            short totalSoldier = CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum();  // 总士兵数
            byte generalNum = CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum();    // 将领数量

            // 遍历将领并分配士兵
            for (int i = 0; i < generalNum && totalSoldier > 0; i++)
            {
                General general = GeneralListCache.GetGeneral(CityListCache.GetCityByCityId(this.tarCity).getCityOfficeGeneralIdArray()[i]);
                short needSoldier = (short)(general.getMaxGeneralSoldier() - general.generalSoldier);  // 需要的士兵数

                // 如果将领需要士兵，则分配
                if (needSoldier > 0)
                {
                    if (needSoldier >= totalSoldier)
                    {
                        general.generalSoldier += totalSoldier;  // 分配所有剩余士兵
                        totalSoldier = 0;
                    }
                    else
                    {
                        general.generalSoldier += needSoldier;  // 分配所需士兵
                        totalSoldier -= needSoldier;
                    }
                }
            }
        }


        // AI 自动征兵
        void AIConscription()
        {
            byte thecity = 0;  // 记录人口最多的城市 ID
            int maxpopulation = 0;  // 记录最大人口
            Country curCountry = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // 获取当前回合国家

            if (curCountry == null)  // 如果国家为空，则返回
                return;

            byte CITY_NUM = curCountry.GetHaveCityNum();  // 获取当前国家的城市数量

            if (CITY_NUM < 1)  // 如果没有城市，则返回
                return;

            // 遍历所有城市，找到人口最多的城市
            for (int i = 0; i < CITY_NUM; i++)
            {
                byte cityId = curCountry.getCity(i);  // 获取城市 ID
                City city = CityListCache.GetCityByCityId(cityId);  // 根据 ID 获取城市实例

                // 如果城市人口超过 1000 且大于当前记录的最大人口，更新最大人口和目标城市 ID
                if (city.population > 1000 && city.population > maxpopulation)
                {
                    maxpopulation = city.population;
                    thecity = cityId;
                }
            }

            // 如果没有符合条件的城市或者最大人口少于 1000，返回
            if (thecity == 0 || maxpopulation < 1000)
                return;

            // 遍历所有城市进行征兵操作
            for (int i = 0; i < CITY_NUM; i++)
            {
                byte cityId = curCountry.getCity(i);  // 获取当前城市 ID
                City city = CityListCache.GetCityByCityId(cityId);  // 获取当前城市实例

                int i1 = city.getAllSoldierNum();  // 获取城市的总士兵数
                int j1 = i1 - city.GetCityAllSoldierNum();  // 获取城市非驻守士兵数
                int needSoldierNum = j1 - city.cityReserveSoldier;  // 计算需要补充的士兵数

                // 如果需要补充士兵
                if (needSoldierNum > 0)
                {
                    int needMoney = ((needSoldierNum - 1) / 100 + 1) * 20;  // 计算征兵所需的金钱
                    City thisCity = CityListCache.GetCityByCityId(thecity);  // 获取人口最多的城市实例

                    // 如果当前城市有足够的金钱进行征兵
                    if (city.GetMoney() >= needMoney)
                    {
                        city.DecreaseMoney((short)needMoney);  // 减少城市金钱
                        city.cityReserveSoldier += needMoney * 5;  // 增加城市的预备士兵
                        thisCity.population -= needSoldierNum;  // 减少人口最多城市的人口

                        // 如果人口减少到负数，置为 0
                        if (thisCity.population < 0)
                            thisCity.population = 0;
                    }
                    else  // 如果金钱不足
                    {
                        int i2 = city.GetMoney() / 20 * 20;  // 根据金钱计算可征兵的数量
                        city.DecreaseMoney((short)i2);  // 减少城市金钱
                        city.cityReserveSoldier += i2 * 5;  // 增加城市的预备士兵
                        thisCity.population -= i2 * 5;  // 减少人口最多城市的人口

                        // 如果人口减少到负数，置为 0
                        if (thisCity.population < 0)
                            thisCity.population = 0;
                    }
                }

                // 分配士兵到将领
                city.distributionSoldier();
            }
        }

        // 判断城市是否为敌对城市
        bool cityIsEnemy(byte cityId)
        {
            short[] cityIdArray = CityListCache.GetCityByCityId(cityId).connectCityId;  // 获取当前城市的连接城市 ID 数组

            // 遍历连接的城市，判断是否属于不同国王
            for (byte byte1 = 0; byte1 < cityIdArray.Length; byte1 = (byte)(byte1 + 1))
            {
                // 如果连接城市的国王与当前城市不同，返回 true
                if (CityListCache.GetCityByCityId((byte)cityIdArray[byte1]).cityBelongKing != CityListCache.GetCityByCityId(cityId).cityBelongKing)
                    return true;
            }

            // 如果所有连接的城市都属于同一国王，返回 false
            return false;
        }

        

        // 移动将领到目标城市
        void AiMoveGenToCity(int i1)
        {
            // 移动指定数量的将领
            for (int j1 = 0; j1 < i1; j1++)
            {
                City city = CityListCache.GetCityByCityId(this.curCity);  // 获取当前城市实例
                short generalId = city.getCityOfficeGeneralIdArray()[city.getCityGeneralNum() - 1];  // 获取当前城市最后一个将领 ID

                city.removeOfficeGeneralId(generalId);  // 移除该将领
                CityListCache.GetCityByCityId(this.tarCity).AddOfficeGeneralId(generalId);  // 将该将领添加到目标城市

                // 如果目标城市的将领数达到 10，停止操作
                if (CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum() >= 10)
                    return;
            }
        }

        /// <summary>
        /// AI寻找可治疗将领
        /// </summary>
        void AiFindTreatGeneral()
        {
            // 随机决定是否继续执行操作，1/3 概率执行
            if (CommonUtils.getRandomInt() % 3 > 0)
                return;

            // 遍历当前国家的所有城市
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).GetHaveCityNum(); byte1++)
            {
                byte byte0 = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).getCity(byte1);  // 获取城市 ID

                // 判断城市是否符合条件，且敌对并有足够金钱
                if ((this.k_byte_array1d_fld[byte0] & 0x4) == 4 && CityListCache.GetCityByCityId(byte0).GetMoney() >= 100 && cityIsEnemy(byte0))
                {
                    byte byte2 = 0;
                    while (true)
                    {
                        City city = CityListCache.GetCityByCityId(byte0);  // 获取当前城市实例
                        short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // 获取当前城市的将领 ID 数组

                        // 如果遍历完所有将领，跳出循环
                        if (byte2 >= city.getCityGeneralNum())
                            break;

                        // 判断将领的体力是否小于最大值 40 且小于当前体力
                        if ((GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).maxPhysical - 40 > GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).getCurPhysical())
                        {
                            this.X = 19;  // 设置事件类型为 19
                            this.tarCity = byte0;  // 设置目标城市
                            this.HMGeneralId = officeGeneralIdArray[byte2];  // 设置操作的将领
                            return;
                        }
                        byte2 = (byte)(byte2 + 1);
                    }
                }
            }
        }

        // 判断是否可以治疗
        bool canTreatment()
        {
            return AiFindLowHpEnemyGeneral();  // 调用 AiFindLowHpEnemyGeneral 方法判断
        }

        /// <summary>
        /// 随机返回一个治疗效果值
        /// </summary>
        /// <returns></returns>
        int AiTreatValue()
        {
            return 35 + CommonUtils.getRandomInt() % 17;  // 返回 35 到 51 的随机值
        }

        /// <summary>
        /// 随机返回一个控制效果值
        /// </summary>
        /// <returns></returns>
        int HmTreatValue()
        {
            return 20 + CommonUtils.getRandomInt() % 15;  // 返回 20 到 34 的随机值
        }

        /// <summary>
        /// AI执行治疗操作
        /// </summary>
        void AiTreat()
        {
            byte physical = (byte)AiTreatValue();  // 获取随机治疗效果
            General general = GeneralListCache.GetGeneral(this.HMGeneralId);  // 获取当前操作的将领

            general.addCurPhysical(physical);  // 增加将领的当前体力

            // 如果体力超过最大值或小于等于 0，重置体力为最大值
            if (general.getCurPhysical() > general.maxPhysical || general.getCurPhysical() <= 0)
                general.setCurPhysical(general.maxPhysical);

            CityListCache.GetCityByCityId(this.tarCity).DecreaseMoney((short)50);  // 从城市的金钱中扣除 50
        }

        /// <summary>
        /// AI执行寻找可奖赏将领操作
        /// </summary>
        void AiFindRewardGeneral()
        {
            // 1/5 的几率执行操作
            if (CommonUtils.getRandomInt() % 5 > 0)
                return;

            // 遍历当前国家的所有城市
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).GetHaveCityNum(); byte1++)
            {
                byte byte0 = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).getCity(byte1);  // 获取当前城市 ID

                // 判断城市是否有足够的金钱或宝藏
                if (CityListCache.GetCityByCityId(byte0).GetMoney() >= 200 || CityListCache.GetCityByCityId(byte0).treasureNum != 0)
                {
                    byte byte2 = 0;
                    while (true)
                    {
                        City city = CityListCache.GetCityByCityId(byte0);  // 获取城市实例
                        short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // 获取城市的将领 ID 数组

                        // 遍历完所有将领则跳出
                        if (byte2 >= city.getCityGeneralNum())
                            break;

                        // 判断将领的忠诚度是否小于 50
                        if (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).getLoyalty() < 50)
                        {
                            this.X = 8;  // 设置事件类型为 8
                            this.tarCity = byte0;  // 设置目标城市
                            this.HMGeneralId = officeGeneralIdArray[byte2];  // 设置操作的将领
                            return;
                        }
                        byte2 = (byte)(byte2 + 1);
                    }
                }
            }
        }


        // 执行 AiFindLowLoyaltyGeneral 方法
        void void_bl()
        {
            AiFindLowLoyaltyGeneral();
        }

        // 计算数值，根据传入的 i1 返回不同的随机值
        int int_i_c(int i1)
        {
            // 如果传入 200，返回 11 到 18 之间的随机值
            if (i1 == 200)
                return 11 + CommonUtils.getRandomInt() % 8;

            int j1 = i1 / 8;  // j1 为 i1 除以 8 的商
            int k1 = CommonUtils.getRandomInt() % 8;  // 获取 0 到 7 的随机值

            // 如果 k1 小于 i1 除以 8 的余数，j1 加 1
            if (k1 < i1 % 8)
                j1++;

            // 如果 j1 大于 7，进行调整
            if (j1 > 7)
                j1 += CommonUtils.getRandomInt() % 2 - 1;

            return j1;  // 返回计算后的 j1
        }

        /// <summary>
        /// Ai奖赏将领忠诚度或减少目标城市的宝藏或金钱
        /// </summary>
        void AiRewardGeneral()
        {
            // 如果没有设置目标城市，直接返回
            if (this.tarCity == 0)
                return;

            General general = GeneralListCache.GetGeneral(this.HMGeneralId);  // 获取当前将领
            City city = CityListCache.GetCityByCityId(this.tarCity);  // 获取目标城市

            // 如果将领的忠诚度大于 90 且城市有宝藏
            if (general.getLoyalty() > 90)
            {
                if (city.treasureNum > 0)
                {
                    general.AddLoyalty(false);  // 增加忠诚度但标记为不友好
                    city.treasureNum = (byte)(city.treasureNum - 1);  // 减少城市的宝藏数量
                    return;
                }
            }
            // 否则如果城市金钱大于 50
            else if (city.GetMoney() > 50)
            {
                general.AddLoyalty(true);  // 增加忠诚度且标记为友好
                city.DecreaseMoney((short)50);  // 减少城市的金钱
            }
            // 如果城市没有足够的金钱但有宝藏
            else if (city.treasureNum > 0)
            {
                general.AddLoyalty(false);  // 增加忠诚度但标记为不友好
                city.treasureNum = (byte)(city.treasureNum - 1);  // 减少城市的宝藏
            }
        }

        /// <summary>
        /// AI运输粮食
        /// </summary>
        void AiTransportFood()
        {
            City tCity = CityListCache.GetCityByCityId(this.tarCity);  // 获取目标城市
            City cCity = CityListCache.GetCityByCityId(this.curCity);  // 获取当前城市

            // 如果当前城市没有粮食，直接返回
            if (cCity.GetFood() < 1)
                return;

            short[] curval = new short[3];
            short[] tarval = new short[3];
            curval = cityNeedFood(this.curCity);  // 获取当前城市的粮食需求
            tarval = cityNeedFood(this.tarCity);  // 获取目标城市的粮食需求

            short canNum = 0;
            short mustMum = 0;
            int s = 0;

            // 当前和目标城市都缺粮食
            if (curval[2] < 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);

                if (mustMum + canNum + cCity.GetFood() + tCity.GetFood() != 0)
                {
                    s = (mustMum * cCity.GetFood() - canNum * tCity.GetFood()) / (mustMum + canNum + cCity.GetFood() + tCity.GetFood());
                    if (s > cCity.GetFood() || s < 0)
                        s = cCity.GetFood();
                }
            }
            // 当前城市有粮食，目标城市缺粮
            else if (curval[2] > 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);

                if (mustMum - canNum + cCity.GetFood() + tCity.GetFood() != 0)
                {
                    s = (mustMum * cCity.GetFood() + canNum * tCity.GetFood()) / (mustMum - canNum + cCity.GetFood() + tCity.GetFood());
                    if (s > cCity.GetFood() || s < 0)
                        s = cCity.GetFood();
                }
            }
            // 当前和目标城市都有足够粮食
            else if (curval[2] > 0 && tarval[2] > 0)
            {
                s = canNum;
            }

            // 检查是否超过目标城市的最大粮食容量
            if (s > 30000 - tCity.GetFood())
                s = 30000 - tCity.GetFood();

            if (s < 0)
                s = 0;

            cCity.DecreaseFood((short)s);  // 当前城市减少粮食
            tCity.AddFood((short)s);  // 目标城市增加粮食
            Console.WriteLine($"{cCity.cityName} 运输 {s} 食物到 {tCity.cityName}");  // 输出运输信息
        }

        /// <summary>
        /// AI运输金钱
        /// </summary>
        void AiTransportMoney()
        {
            City cCity = CityListCache.GetCityByCityId(this.curCity);  // 获取当前城市
            City tCity = CityListCache.GetCityByCityId(this.tarCity);  // 获取目标城市

            // 如果当前城市金钱少于 100，直接返回
            if (cCity.GetMoney() < 100)
                return;

            short[] curval = new short[3];
            short[] tarval = new short[3];
            curval = cityNeedMoney(this.curCity);  // 获取当前城市的金钱需求
            tarval = cityNeedMoney(this.tarCity);  // 获取目标城市的金钱需求

            short canNum = 0;
            short mustMum = 0;
            int s = 0;

            // 当前和目标城市都缺钱
            if (curval[2] < 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);
                s = (mustMum * cCity.GetMoney() - canNum * tCity.GetMoney()) / (mustMum + canNum + cCity.GetMoney() + tCity.GetMoney());

                if (s > cCity.GetMoney() || s < 0)
                    s = cCity.GetMoney();
            }
            // 当前城市有钱，目标城市缺钱
            else if (curval[2] > 0 && tarval[2] < 0)
            {
                canNum = (short)Math.Abs(curval[2]);
                mustMum = (short)Math.Abs(tarval[2]);
                int result = mustMum - canNum + cCity.GetMoney() + tCity.GetMoney();
                result = (result == 0) ? 1 : result;
                s = (mustMum * cCity.GetMoney() + canNum * tCity.GetMoney()) / result;

                if (s > cCity.GetMoney() || s < 0)
                    s = cCity.GetMoney();
            }
            // 当前和目标城市都有足够金钱
            else if (curval[2] > 0 && tarval[2] > 0)
            {
                s = canNum;
            }

            // 检查是否超过目标城市的最大金钱容量
            if (s > 30000 - tCity.GetMoney())
                s = 30000 - tCity.GetMoney();

            if (s < 0)
                s = 0;

            cCity.DecreaseMoney((short)s);  // 当前城市减少金钱
            tCity.AddMoney((short)s);  // 目标城市增加金钱
            Console.WriteLine($"{cCity.cityName} 运输 {s} 金钱到 {tCity.cityName}");  // 输出运输信息
        }


        /// <summary>
        /// AI检查某个城市是否有粮店，并处理相关逻辑
        /// </summary>
        /// <param name="byte0"></param>
        /// <returns></returns>
        bool DoAiHasGrainShop(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);  // 获取城市对象
            int i1 = 0;

            // 检查该城市的标志位，如果标志位为8，进行食物与金钱的交换
            if ((this.k_byte_array1d_fld[byte0] & 0x8) == 8)
            {
                // 如果金钱不足100且食物充足，则减少食物增加金钱
                if (city.GetMoney() < 100 && city.GetFood() > 500)
                {
                    city.DecreaseFood((short)200);
                    CityListCache.GetCityByCityId(byte0).AddMoney((short)150);
                    return true;
                }

                // 如果食物不足200且金钱充足，则减少金钱增加食物
                if (city.GetFood() < 200 && city.GetMoney() > 500)
                {
                    city.DecreaseMoney((short)200);
                    city.AddFood((short)266);
                    return true;
                }
            }

            // 检查该城市的标志位，如果标志位为2，进行学习行为
            if ((this.k_byte_array1d_fld[byte0] & 0x2) == 2)
                i1 = AIDoLearn(byte0);

            // 如果学习行为有效，返回true
            if (i1 > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Ai离间玩家将领
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        void AiAlienate(byte byte0, short gohireId, short behireId)
        {
            // 判断分离操作是否成功
            bool flag = IsSuccessOfAlienate(gohireId, behireId);

            // 如果成功且目标城市属于玩家的国家
            if (flag)
            {
                if (CityListCache.GetCityByCityId(byte0).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
                {
                    this.eventId = 16;  // 设置事件ID
                    this.AIGeneralId = behireId;  // 设置AI将领ID
                    RefreshFeedBack((byte)19);  // 触发事件
                    FloodDisasterCanvans();  // 更新事件
                }
                GeneralListCache.addIQExp(gohireId, (byte)1);  // 增加智力经验
            }
        }

        /// <summary>
        /// AI笼络玩家将领
        /// </summary>
        /// <param name="goCity"></param>
        /// <param name="beCity"></param>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        void AiBribe(byte goCity, byte beCity, short word0, short word1)
        {
            bool flag = BribeMovePossibility(goCity, beCity, word0, word1);

            // 如果雇佣成功且目标城市属于玩家的国家
            if (flag && CityListCache.GetCityByCityId(beCity).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
            {
                this.eventId = 17;  // 设置事件ID
                this.tarCity = goCity;  // 设置目标城市
                this.AIGeneralId = word1;  // 设置AI将领ID
                RefreshFeedBack((byte)19);  // 触发事件
                FloodDisasterCanvans();  // 更新事件
            }
        }

        // 移除指定的元素并返回新的数组
        short[] short1_s1bs_b(short[] aword0, byte byte0, short word0)
        {
            // 如果元素个数不足，返回null
            if (byte0 <= 1)
                return null;

            short[] aword1 = new short[byte0 - 1];  // 创建新数组用于存储移除后的数据
            byte byte1 = 0;

            // 遍历原数组，移除指定元素
            for (byte byte2 = 0; byte2 < byte0; byte2 = (byte)(byte2 + 1))
            {
                if (aword0[byte2] != word0)
                {
                    byte1 = (byte)(byte1 + 1);
                    aword1[byte1] = aword0[byte2];
                }
            }

            return aword1;  // 返回新数组
        }

        /// <summary>
        /// 获取将领所属的君主ID
        /// </summary>
        /// <param name="genId"></param>
        /// <returns></returns>
        short GetOfficeGenBelongKing(short genId)
        {
            short kingId = 0;
            General general = GeneralListCache.GetGeneral(genId); // 获取将领对象
            City debutCity = CityListCache.GetCityByCityId(general.debutCity); // 获取将领初次登场的城市
            short[] officeGeneralIdArray = debutCity.getCityOfficeGeneralIdArray(); // 获取城市的任职将领ID数组

            // 遍历城市的任职将领ID数组，查找将领是否在该城市任职
            for (int i = 0; i < officeGeneralIdArray.Length; i++)
            {
                if (officeGeneralIdArray[i] == general.generalId)
                {
                    return debutCity.cityBelongKing; // 返回该城市所属的君主ID
                }
            }

            int inCount = 0; // 计数器
            string cityInfoString = ""; // 用于记录将领所在城市信息

            // 遍历所有城市，查找将领是否在其他城市任职
            for (byte cityId = 1; cityId < CityListCache.CITY_NUM; cityId = (byte)(cityId + 1))
            {
                City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象

                // 遍历城市的任职将领ID数组
                for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
                {
                    if (city.getCityOfficeGeneralIdArray()[index] == genId)
                    {
                        kingId = city.cityBelongKing; // 找到该城市所属的君主ID
                        inCount++; // 计数
                        cityInfoString += city.cityName; // 记录城市名称

                        // 如果将领初次登场城市与当前城市不一致，则更新信息
                        if (general.debutCity != cityId)
                        {
                            city.removeOfficeGeneralId(general.generalId); // 从旧城市移除将领任职信息
                            general.debutCity = cityId; // 更新将领的初次登场城市
                        }
                    }
                }
            }

            // 如果计数器大于0，输出将领的任职城市信息
            if (inCount > 0)
            {
                Debug.Log(general.generalName + "在" + cityInfoString + "任职！"); // 使用Unity的Debug.Log输出信息
            }

            return kingId; // 返回君主ID
        }


        /// <summary>
        /// AI执行雇佣操作
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        bool AiEmploy(short gohireId, short behireId)
        {
            General goGeneral = GeneralListCache.GetGeneral(gohireId);  // 获取雇佣将领
            City city = CityListCache.GetCityByCityId(goGeneral.debutCity);  // 获取该将领所在城市
            General kingGeneral = GeneralListCache.GetGeneral(city.cityBelongKing);  // 获取该城市所属的国王
            General beGeneral = GeneralListCache.GetGeneral(behireId);  // 获取被雇佣的将领

            // 如果被雇佣的将领不存在，返回false
            if (beGeneral == null)
                return false;

            int d1 = GetdPhase(kingGeneral.phase, beGeneral.phase);  // 计算国王与被雇佣将领的相位差
            int d2 = GetdPhase(goGeneral.phase, beGeneral.phase);  // 计算雇佣将领与被雇佣将领的相位差
            int i = MathUtils.getRandomInt(75);  // 获取随机数用于雇佣成功判定

            // 如果相位差满足雇佣条件，雇佣成功
            if ((d1 + d2) / 2 < i)
            {
                Console.WriteLine($"{kingGeneral.generalName} 势力成功雇佣 {beGeneral.generalName}！");
                return true;
            }

            return false;  // 雇佣失败
        }


        /// <summary>
        /// 获取与指定将领相性最接近的国家ID
        /// </summary>
        /// <param name="GenId"></param>
        /// <returns></returns>
        byte GetNearPhaseCountryId(short GenId)
        {
            short min = 100;  // 最小相性差值
            byte mincountryId = 0;  // 初始化国家ID
            byte countrySize = CountryListCache.getCountrySize();  // 获取国家列表大小
            for (byte i = 1; i < countrySize; i = (byte)(i + 1))
            {
                Country country = CountryListCache.getCountryByIndexId(i);  // 获取国家对象
                if (country != null && country.countryKingId > 0 && country.countryId > 0)
                {
                    General general = GeneralListCache.GetGeneral(country.countryKingId);  // 获取国王将领
                    if (general != null)
                    {
                        short curKingPhase = general.phase;  // 获取国王的相性
                        int curd = GetdPhase(curKingPhase, (GeneralListCache.GetGeneral(GenId)).phase);  // 计算当前将领与目标将领的相性差值
                        if (mincountryId == 0 || curd < min)
                        {
                            min = (short)curd;
                            mincountryId = country.countryId;  // 更新最小相性国家ID
                        }
                    }
                }
            }
            if (mincountryId == 0)
                Console.Error.WriteLine("获取最小相性君主失败！");
            return mincountryId;
        }

        /// <summary>
        /// 检查将领是否为某个势力的排他性将领
        /// </summary>
        /// <param name="genId"></param>
        /// <returns></returns>
        bool GenIsExclusive(short genId)
        {
            byte countrySize = CountryListCache.getCountrySize();  // 获取国家列表大小
            for (byte i = 1; i < countrySize; i = (byte)(i + 1))
            {
                Country country = CountryListCache.getCountryByIndexId(i);  // 获取国家对象
                if (country.countryKingId > 0 && country.countryId > 0 &&
                    (GeneralListCache.GetGeneral(country.countryKingId)).phase == (GeneralListCache.GetGeneral(genId)).phase)
                {
                    return true;  // 如果该将领与某个国家的国王将领相性相同，则为排他性将领
                }
            }
            return false;
        }

        /// <summary>
        /// 计算两位将领的相性差值
        /// </summary>
        /// <param name="ph1"></param>
        /// <param name="ph2"></param>
        /// <returns></returns>
        int GetdPhase(short ph1, short ph2)
        {
            int total = Math.Abs(ph1 - ph2);  // 计算绝对差值
            if (total >= 75)
                total = 150 - total;  // 超过75则取反方向相性差值
            return total;
        }

        /// <summary>
        /// 判断是否成功登用或招揽将领
        /// </summary>
        /// <param name="curCity"></param>
        /// <param name="employGeneralId"></param>
        /// <param name="generalId"></param>
        /// <returns></returns>
        bool isEmploy(byte curCity, short employGeneralId, short generalId)
        {
            int i = MathUtils.getRandomInt(100);  // 随机数判定
            if (i > 50)
                return false;  // 随机数大于50则失败

            if (AiEmploy(employGeneralId, generalId))  // 尝试招揽
            {
                GeneralListCache.addMoralExp(employGeneralId, (byte)10);  // 增加道德经验
                City city = CityListCache.GetCityByCityId(curCity);  // 获取当前城市
                city.AddOfficeGeneralId(generalId);  // 将被招揽的将领加入城市的职务名单
                city.RemoveOppositionGeneralId(generalId);  // 将该将领从反对将领列表中移除
                return true;  // 招揽成功
            }
            return false;  // 招揽失败
        }

        /// <summary>
        /// 搜索将领，返回搜索结果
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="notFoundGeneralIdNum"></param>
        /// <returns></returns>
        byte Search(short generalId, byte notFoundGeneralIdNum)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取将领信息
            byte iq = general.IQ;  // 获取将领智力
            byte moral = general.moral;  // 获取将领道德
            int i1 = MathUtils.getRandomInt(100);  // 随机数判定
            bool isyl = false;

            // 如果将领具备技能眼力，修改搜索成功率
            if (GetSkill_4(generalId, 4))
            {
                i1 = 120;
                isyl = true;
            }

            // 根据未找到将领的数量与道德值调整搜索成功率
            if (notFoundGeneralIdNum >= 1 && moral >= 70)
            {
                i1 = 60;
            }
            else if (notFoundGeneralIdNum >= 1 && CommonUtils.getRandomInt() % 3 > 0)
            {
                i1 = 60;
            }

            // 根据智力与搜索成功率判定搜索失败
            if (i1 > iq && !isyl && notFoundGeneralIdNum == 0)
                return 0;

            int i2 = 0;

            // 根据搜索成功率判定结果
            if (i1 > 79)
            {
                if (GetSkill_4(generalId, 4))//如果拥有技能眼力
                {
                    int trand = MathUtils.getRandomInt(10);  // 进一步随机判定
                    if (notFoundGeneralIdNum > 0)
                    {
                        i2 = 3;
                    }
                    else if (trand > 5)
                    {
                        i2 = 2;
                    }
                    else if (trand > 1)
                    {
                        i2 = 1;
                    }
                    else
                    {
                        i2 = 4;
                    }
                }
                else if (notFoundGeneralIdNum > 0)
                {
                    i2 = 3;
                }
                else
                {
                    int j1 = MathUtils.getRandomInt(100);  // 进一步随机判定
                    if (j1 < 5)
                    {
                        i2 = 4;
                    }
                    else if (j1 < 55)
                    {
                        i2 = 2;
                    }
                    else if (j1 < 95)
                    {
                        i2 = 1;
                    }
                }
            }
            else if (i1 > 59 && notFoundGeneralIdNum != 0)
            {
                i2 = 3;
            }
            else
            {
                int j1 = MathUtils.getRandomInt(100);  // 进一步随机判定
                if (j1 < 5)
                {
                    i2 = 4;
                }
                else if (j1 < 45)
                {
                    i2 = 2;
                }
                else if (j1 < 85)
                {
                    i2 = 1;
                }
            }

            return (byte)i2;  // 返回搜索结果
        }

        /// <summary>
        /// 人事搜索操作
        /// </summary>
        /// <param name="curCity"></param>
        /// <param name="generalId"></param>
        void SearchOrder(byte curCity, short generalId)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取指定将领
            general.decreaseCurPhysical((byte)2);  // 减少将领当前体力
            City city = CityListCache.GetCityByCityId(curCity);  // 获取指定城市
            byte kind = Search(generalId, city.getCityNotFoundGeneralNum());  // 搜索将领并获取结果类型
            this.b_int_fld = kind;  // 存储结果类型

            // 根据结果类型设置事件ID
            if (this.b_int_fld == 1 || this.b_int_fld == 2)
            {
                this.eventId = CommonUtils.getRandomInt() % 30 + (general.IQ + general.moral * 3) / 5;
                if (GetSkill_4(generalId, 4))
                    this.eventId += this.eventId / 2;  // 如果有技能眼力，则事件ID增加一半
            }
            else if (this.b_int_fld == 3)
            {
                this.eventId = CommonUtils.getRandomInt() % city.getCityNotFoundGeneralNum();  // 随机事件ID
            }
            else if (this.b_int_fld == 4)
            {
                this.eventId = 1;  // 固定事件ID
            }

            // 根据结果类型对城市进行操作
            if (this.b_int_fld == 1)
            {
                city.AddFood((short)this.eventId);  // 增加城市的粮食
            }
            else if (this.b_int_fld == 2)
            {
                city.AddMoney((short)this.eventId);  // 增加城市的资金
            }
            else if (this.b_int_fld == 3)
            {
                short beGeneralId = city.getNotFoundGeneralId((byte)this.eventId);  // 获取未找到的将领ID
                if (beGeneralId <= 0)
                    return;  // 如果未找到，将领ID无效则返回
                city.removeNotFoundGeneralId(beGeneralId);  // 移除未找到的将领ID
                city.AddOppositionGeneralId(beGeneralId);  // 添加到对立将领ID
            }
            else if (this.b_int_fld == 4)
            {
                city.treasureNum = (byte)(city.treasureNum + this.eventId);  // 增加城市的宝藏数量
                if (city.treasureNum > 99)
                    city.treasureNum = 99;  // 如果宝藏数量超过99，则设为99
            }
        }

        /// <summary>
        /// 尝试找到政务能力最高的将军
        /// </summary>
        /// <param name="byte0"></param>
        /// <returns></returns>
        short GetMostPoliticalGeneral(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);  // 获取指定城市
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();  // 获取城市职务将领ID数组
            short[] aword0 = new short[city.getCityGeneralNum()];  // 存储政务能力高的将领ID
            byte byte1 = 0;  // 政务能力高的将领数量
            int i1 = 0;  // 最高政务能力
            for (byte byte2 = 0; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
            {
                short generalId = officeGeneralIdArray[byte2];  // 获取将领ID
                if (i1 < (GeneralListCache.GetGeneral(generalId)).political)
                {
                    this.HMGeneralId = generalId;  // 更新政务能力最高的将领ID
                    i1 = (GeneralListCache.GetGeneral(this.HMGeneralId)).political;
                }
                    if ((GeneralListCache.GetGeneral(generalId)).political >= 70)
                    {
                        byte1 = (byte)(byte1 + 1);  // 政务能力高于70的将领数量增加
                        aword0[byte1] = generalId;  // 存储该将领ID
                    }
            }
                if (byte1 == 0)
                return this.HMGeneralId;  // 如果没有政务能力高的将领，返回政务能力最高的将领ID
        return aword0[CommonUtils.getRandomInt() % byte1];  // 从政务能力高的将领中随机选择一个
    }

        /// <summary>
        /// 计算内政需要的金钱
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        int GetNeedMoneyOfInterior(short generalId, byte type)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取将领信息
            byte byte0 = 0;  // 用于存储计算结果
            switch (type)
            {
                case 1:
                    byte0 = (byte)((general.force + general.political) / 2);  // 计算力量与政治的平均值
                    break;
                case 2:
                    byte0 = (byte)((general.IQ + general.political) / 2);  // 计算智商与政治的平均值
                    break;
                case 3:
                    byte0 = (byte)((general.lead + general.political) / 2);  // 计算领导力与政治的平均值
                    break;
                case 4:
                    byte0 = (byte)((general.moral + general.political) / 2);  // 计算道德与政治的平均值
                    break;
            }
            int needMoney = 10;  // 基础金钱需求
            needMoney += byte0 / 10;  // 根据计算结果增加金钱需求
            needMoney += 2 * (CommonUtils.getRandomInt() % 5 + 1);  // 加上随机值
            return needMoney;
        }

        /// <summary>
        /// 内政屯田提升值
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int ReclaimValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取将领信息
            byte byte0 = (byte)((general.force + general.political * 2) / 3);  // 计算内政屯田提升的数值
            general.decreaseCurPhysical((byte)2);  // 减少将领当前体力
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // 增加将领经验
            general.addPoliticalExp((byte)1);  // 增加将领政治经验
            int val = 0;  // 用于存储计算结果
            if (byte0 < 12)
            {
                val = 1;  // 如果计算结果小于12，提升值为1
            }
            else
            {
                int k1 = byte0 * useMoney / 100;  // 根据使用金钱计算值
                int j1 = k1 / 2;
                val = j1 + MathUtils.getRandomInt(j1 + 1) / 2;  // 随机计算值
                if (GetSkill_4(generalId, 0))
                {
                    val += val / 4;  // 如果有技能王佐，增加计算值
                }
                else if (GetSkill_4(generalId, 2))
                {
                    val += val / 3;  // 如果有技能屯田，增加计算值
                }
            }
            return val;
        }

        /// <summary>
        /// 内政劝商提升值
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int MercantileValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取将领信息
            byte byte0 = (byte)((general.IQ + general.political * 2) / 3);  // 计算劝商提升的数值
            general.decreaseCurPhysical((byte)2);  // 减少将领当前体力
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // 增加将领经验
            general.addPoliticalExp((byte)1);  // 增加将领政治经验
            int val = 0;  // 用于存储计算结果
            if (byte0 < 12)
            {
                val = 1;  // 如果计算结果小于12，提示值为1
            }
            else
            {
                int k1 = byte0 * useMoney / 100;  // 根据使用金钱计算值
                int j1 = k1 / 2;
                val = j1 + MathUtils.getRandomInt(j1 + 1) / 2;  // 随机计算值
                if (GetSkill_4(generalId, 0))
                {
                    val += val / 4;  // 如果有技能王佐，增加计算值
                }
                else if (GetSkill_4(generalId, 3))
                {
                    val += val / 3;  // 如果有技能商才，增加计算值
                }
            }
            return val;
        }

        /// <summary>
        /// 内政治水提升值
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int TameValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取将领信息
            byte byte0 = (byte)((general.lead + general.political * 2) / 4);  // 计算内政治水提升的数值
            general.decreaseCurPhysical((byte)2);  // 减少将领当前体力
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // 增加将领经验
            general.addPoliticalExp((byte)1);  // 增加将领政治经验
            int val = 0;  // 用于存储计算结果
            if (byte0 < 10)
            {
                val = 1;  // 如果计算结果小于10，提示值为1
            }
            else
            {
                int k1 = byte0 * useMoney / 100;  // 根据使用金钱计算值
                int j1 = k1 / 2;
                val = j1 + MathUtils.getRandomInt(j1 + 1) / 3;  // 随机计算值
                if (GetSkill_4(generalId, 0))
                    val += val / 4;  // 如果有技能王佐，增加计算值
            }
            return val;
        }

        /// <summary>
        /// 内政巡查提升值
        /// </summary>
        /// <param name="generalId"></param>
        /// <param name="useMoney"></param>
        /// <returns></returns>
        int PatrolValue(short generalId, int useMoney)
        {
            General general = GeneralListCache.GetGeneral(generalId);  // 获取将领信息
            byte byte0 = (byte)((general.IQ + general.moral * 2 + general.political * 2) / 5);  // 计算内政巡查的提升值
            general.decreaseCurPhysical((byte)2);  // 减少将领当前体力
            general.addexperience(MathUtils.getRandomInt(50) + 1);  // 增加将领经验
            general.addPoliticalExp((byte)1);  // 增加将领政治经验
            general.addMoralExp((byte)1);  // 增加将领道德经验
            int val = 0;  // 用于存储计算结果
            if (byte0 < 50)
            {
                val = 500;  // 基准值小于50时，提升值固定为500
            }
            else
            {
                val = byte0 * useMoney;  // 根据基准值和使用金钱计算提升值
                if (GetSkill_4(generalId, 0))
                {
                    val += val / 4;  // 如果有技能王佐，增加提升值
                }
                else if (GetSkill_4(generalId, 1))
                {
                    val += val / 3;  // 如果有技能仁政，增加提升值
                }
            }
            return val;
        }

        /// <summary>
        /// AI内政开垦查操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiReclaimOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)1);  // 获取内政开垦需要的金钱
            Reclaim1(byte0, word0, needMoney);  // 执行相关操作
        }

        /// <summary>
        /// AI内政劝商操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiMercantileOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)2);  // 获取内政劝商需要的金钱
            Mercantile1(byte0, word0, needMoney);  // 执行相关操作
        }

        /// <summary>
        /// Ai内政巡查操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiPatrolOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)4);  // 获取内政巡查需要的金钱
            Patrol1(byte0, word0, needMoney);  // 执行相关操作
        }

        /// <summary>
        /// AI内政治水操作
        /// </summary>
        /// <param name="byte0"></param>
        /// <param name="word0"></param>
        void AiTameOrder(byte byte0, short word0)
        {
            int needMoney = GetNeedMoneyOfInterior(word0, (byte)3);  // 获取内政治水需要的金钱
            Tame1(byte0, word0, needMoney);  // 执行相关操作
        }

        /// <summary>
        /// AI内政操作选择命令
        /// </summary>
        /// <param name="byte0"></param>
        void AiInteriorChooseOrder(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);  // 获取指定城市
            if (city.floodControl < 99)
            {
                AiTameOrder(byte0, this.HMGeneralId);  // 如果防洪控制小于99，执行内政招募操作
                return;
            }
            if (CommonUtils.getRandomInt() % 2 > 0)
            {
                if (city.agro < 999 && city.trade < 999)
                {
                    if (GameInfo.month < 4 || GameInfo.month >= 10)
                    {
                        AiReclaimOrder(byte0, this.HMGeneralId);  // 如果月份小于4或大于等于10，执行内政巡查操作
                    }
                    else
                    {
                        AiMercantileOrder(byte0, this.HMGeneralId);  // 否则，执行内政调动操作
                    }
                    return;
                }
                if (city.agro < 999)
                {
                    AiReclaimOrder(byte0, this.HMGeneralId);  // 如果农业小于999，执行内政巡查操作
                    return;
                }
                if (city.trade < 999)
                {
                    AiMercantileOrder(byte0, this.HMGeneralId);  // 如果贸易小于999，执行内政调动操作
                    return;
                }
            }
            if (city.population < 990000)
            {
                AiPatrolOrder(byte0, this.HMGeneralId);  // 如果人口小于990000，执行内政理财操作
                return;
            }
            AiTameOrder(byte0, this.HMGeneralId);  // 默认执行内政招募操作
        }

    /// <summary>
    /// AI执行内政操作先设置将领
    /// </summary>
    /// <param name="byte0"></param>
    void AiInteriorChooseGeneralId(byte byte0)
        {
            this.HMGeneralId = GetMostPoliticalGeneral(byte0);  // 获取智商最高的将领ID
            AiInteriorChooseOrder(byte0);  // 执行内政操作
        }

        // 我方是否招降AI将领？
        bool IsSummonToSurrender(short word0, short word1)
        {
            if (GeneralListCache.GetGeneral(word1).getLoyalty() > 99)
                return false;  // 如果将领忠诚度大于99，不奖励

            int i1 = ((GeneralListCache.GetGeneral(word0)).moral * 7 + (GeneralListCache.GetGeneral(word0)).IQ * 3) * 10 / 99;  // 计算奖励值
            i1 = (i1 - 70) / 5;  // 调整奖励值
            if (i1 == 4)
            {
                i1 = 6;  // 奖励值为6
            }
            else if (i1 == 5)
            {
                i1 = 8;  // 奖励值为8
            }
            i1 = GeneralListCache.GetGeneral(word1).getCurPhysical() + GeneralListCache.GetGeneral(word1).getLoyalty() - i1 + CommonUtils.getRandomInt() % 4;  // 计算最终值
            return (i1 < 100);  // 如果最终值小于100，则返回true
        }

        /// <summary>
        /// AI是否招降我方将领？
        /// </summary>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        /// <returns></returns>
        bool IsSummonToSurrenderEasy(short word0, short word1)
        {
            if (GeneralListCache.GetGeneral(word1).getLoyalty() > 99)
                return false;  // 如果将领忠诚度大于99，不奖励

            int i1 = ((GeneralListCache.GetGeneral(word0)).moral * 7 + (GeneralListCache.GetGeneral(word0)).IQ * 3) * 10 / 99;  // 计算奖励值
            i1 = (i1 - 70) / 5;  // 调整奖励值
            if (i1 == 4)
            {
                i1 = 6;  // 奖励值为6
            }
            else if (i1 == 5)
            {
                i1 = 8;  // 奖励值为8
            }
            i1 = GeneralListCache.GetGeneral(word1).getCurPhysical() + GeneralListCache.GetGeneral(word1).getLoyalty() - i1 + CommonUtils.getRandomInt() % 4;  // 计算最终值
            return (i1 < 110);  // 如果最终值小于110，则返回true
        }

        /// <summary>
        /// 计算基于将军武力值的某种攻击力或效果
        /// </summary>
        /// <param name="word0"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        int GeneralAtkValue(short word0, short word1, short word2)
        {
            int i1 = (GeneralListCache.GetGeneral(word0)).force;  // 获取将军武力值
            i1 *= word1;  // 乘以参数word1
            i1 /= word2;  // 除以参数word2
            if (i1 > 2 * (GeneralListCache.GetGeneral(word0)).force)
                i1 = 2 * (GeneralListCache.GetGeneral(word0)).force;  // 限制最大值
            if (i1 < (GeneralListCache.GetGeneral(word0)).force / 3)
                i1 = (GeneralListCache.GetGeneral(word0)).force / 3;  // 限制最小值
            i1 += i1 / 5;  // 增加5%的计算值
            return i1;
        }

        /// <summary>
        /// 获得确定死亡数
        /// </summary>
        /// <param name="atkId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte getAtkDea(short atkId, short atk, short def)
        {
            byte dea = 1;  // 初始化死亡数
            dea = (byte)(GeneralAtkValue(atkId, atk, def) / 8);  // 根据攻击力计算死亡数
            if (dea < 0)
                dea = 100;  // 确保死亡数不小于0
            return dea;
        }

        /// <summary>
        /// 获得全部攻击死亡数
        /// </summary>
        /// <param name="atkId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte getAllAtkDea(short atkId, short atk, short def)
        {
            byte dea = 1;  // 初始化死亡数
            dea = (byte)(GeneralAtkValue(atkId, atk, def) / 2);  // 根据攻击力计算死亡数
            if (dea < 0)
                dea = 100;  // 确保死亡数不小于0
            return dea;
        }

        /// <summary>
        /// 单次攻击结果
        /// </summary>
        /// <param name="atkGeneralId"></param>
        /// <param name="defGeneralId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte singlePin(short atkGeneralId, short defGeneralId, short atk, short def)
        {
            this.c_int_fld = 1;  // 设置内部标志为1
            byte byte0 = (byte)(GeneralAtkValue(atkGeneralId, atk, def) / 20);  // 计算攻击效果
            if (byte0 > 0)
                return byte0;  // 如果效果大于0，返回效果值
            return 1;  // 否则返回1
        }

        /// <summary>
        /// 单次攻击
        /// </summary>
        /// <param name="atkGeneralId"></param>
        /// <param name="defGeneralId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte singleAtk(short atkGeneralId, short defGeneralId, short atk, short def)
        {
            this.c_int_fld = 2;  // 设置内部标志为2
            bool hmatk = false;  // 标志是否为主要攻击
            byte hurt = 0;  // 伤害值初始化为0
            if (atkGeneralId == this.HMGeneralId)
                hmatk = true;  // 如果攻击者是HMGeneral，设为主要攻击
            if (getPercentage(atkGeneralId, defGeneralId, false, hmatk) > MathUtils.getRandomInt(100))
                hurt = getAtkDea(atkGeneralId, atk, def);  // 如果命中率计算通过，计算伤害值
            return hurt;  // 返回伤害值
        }

        /// <summary>
        /// 群体攻击
        /// </summary>
        /// <param name="atkGeneralId"></param>
        /// <param name="defGeneralId"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        byte singleAllAtk(short atkGeneralId, short defGeneralId, short atk, short def)
        {
            this.X = 3;  // 设置内部标志为3
            bool hmatk = false;  // 标志是否为主要攻击
            byte hurt = 0;  // 伤害值初始化为0
            if (atkGeneralId == this.HMGeneralId)
                hmatk = true;  // 如果攻击者是HMGeneral，设为主要攻击
            if (getPercentage(atkGeneralId, defGeneralId, true, hmatk) > CommonUtils.getRandomInt() % 100)
            {
                hurt = getAllAtkDea(atkGeneralId, atk, def);  // 如果命中率计算通过，计算群体伤害
            }
            else
            {
                hurt = (byte)(this.random.Next() % 5 - 20);  // 否则计算随机伤害值
            }
            return hurt;  // 返回伤害值
        }

        // 根据标志计算短值
        short short_B_a(bool flag)
        {
            short word0 = 0;  // 初始化结果
            if (flag)
            {
                for (byte byte0 = 1; byte0 < 4; byte0++)
                    word0 = (short)(word0 + this.x_short_array1d_fld[byte0]);  // 累加x_short_array1d_fld的值
            }
            else
            {
                for (byte byte1 = 1; byte1 < 4; byte1++)
                    word0 = (short)(word0 + this.y_short_array1d_fld[byte1]);  // 累加y_short_array1d_fld的值
            }
            return word0;  // 返回计算结果
        }


       /// <summary>
       /// 攻击数量
       /// </summary>
        void aatkNum()
        {
            byte aNum = 0;  // 存在的士兵数量
            byte longAtkNum = 0;  // 长距离攻击数量
            byte longAtkaNum = 0;  // 另一种长距离攻击数量

            // 遍历所有小士兵
            for (int index = 0; index < this.aiSmallSoldierNum; index++)
            {
                // 判断士兵是否存活且种类为2（假设为某种士兵类型）
                if (this.smallSoldier_isSurvive[1][index] && this.smallSoldierKind[1][index] == 2)
                {
                    aNum = (byte)(aNum + 1);  // 增加存在的士兵数量

                    // 检查其长距离攻击能力
                    for (byte i = 1; i < 7;)
                    {
                        byte x = (byte)(this.smallSoldierCellX[1][index] - i);  // 获取士兵的X坐标
                        byte y = this.smallSoldierCellY[1][index];  // 获取士兵的Y坐标

                        // 检查是否超出地图范围
                        if (x < 0)
                            break;

                        // 检查是否可以长距离攻击
                        if (this.smallWarCoordinate[y][x] == 64 && i >= 5)
                        {
                            longAtkNum = (byte)(longAtkNum + 1);
                        }
                        else
                        {
                            if (this.smallWarCoordinate[y][x] == 64)
                                break;
                            i = (byte)(i + 1);
                        }

                        // 检查敌方士兵是否在攻击范围内
                        for (int hmindex = 1; hmindex < this.humanSmallSoldierNum; hmindex++)
                        {
                            if (this.smallSoldier_isSurvive[0][hmindex] && this.smallSoldierCellX[0][hmindex] == x && this.smallSoldierCellY[0][hmindex] == y && this.smallSoldierKind[0][hmindex] == 2)
                                longAtkaNum = (byte)(longAtkaNum + 1);
                        }
                        break;
                    }
                }
            }

            // 根据W的值调整攻击条件
            if (this.W < 8)
            {
                if (aNum > 0 && longAtkNum >= aNum / 2 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
            else
            {
                if (aNum > 1 && longAtkNum == aNum)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
                if (aNum > 1 && longAtkaNum >= aNum / 2 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
                if (aNum == 1 && longAtkNum >= aNum)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
        }
        
        /// <summary>
        /// 呐喊攻击力计算
        /// </summary>
        /// <returns></returns>
        byte NaHanAtk()
        {
            byte canAtkNum = 0;  // 可以攻击的士兵数量

            // 遍历所有敌方小士兵
            for (int index = 0; index < this.aiSmallSoldierNum; index++)
            {
                // 判断士兵是否存活
                if (this.smallSoldier_isSurvive[1][index])
                {
                    byte x = this.smallSoldierCellX[1][index];  // 士兵的X坐标
                    byte y = this.smallSoldierCellY[1][index];  // 士兵的Y坐标

                    // 判断士兵类型并检查是否可以攻击
                    if (this.smallSoldierKind[1][index] == 1)
                    {
                        if (x > 0 && this.smallWarCoordinate[y][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y > 0 && this.smallWarCoordinate[y - 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y < 6 && this.smallWarCoordinate[y + 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (x > 1 && this.smallWarCoordinate[y][x - 2] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (x > 0 && y > 0 && this.smallWarCoordinate[y - 1][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (x > 0 && y < 6 && this.smallWarCoordinate[y + 1][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                    }
                    else if (this.smallSoldierKind[1][index] == 0 || this.smallSoldierKind[1][index] == 3)
                    {
                        if (x > 0 && this.smallWarCoordinate[y][x - 1] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y > 0 && this.smallWarCoordinate[y - 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y < 6 && this.smallWarCoordinate[y + 1][x] == 64)
                        {
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                    }
                    else
                    {
                        // 长距离攻击
                        for (int d = 1; d < 5; d++)
                        {
                            if (x > d - 1)
                            {
                                byte hx = (byte)(this.smallSoldierCellX[1][index] - d);
                                byte hy = this.smallSoldierCellY[1][index];
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y > d - 1)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] - d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y < 7 - d)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] + d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return canAtkNum;
        }


        // ai使用战术方法
        void aiUseZhanshu()
        {
            byte unitNum = 0;
            // 计算幸存小兵数量
            for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
            {
                if (this.smallSoldier_isSurvive[1][i])
                    unitNum = (byte)(unitNum + 1);
            }

            // 当W值大于等于8时，优先使用战术
            if (this.W >= 8)
            {
                byte nahanNum = NaHanAtk();  // 获取可攻击单位数量
                                                // 如果可攻击数量足够多且小兵数量足够时，减少W并执行战术
                if (nahanNum >= unitNum / 3 + 1 && unitNum >= 3)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }

                aatkNum();  // 计算远程攻击数量
                if (this.W >= 8 && nahanNum >= unitNum / 2 + 1 && unitNum >= 2)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }

                if (this.W >= 8 && nahanNum >= unitNum && unitNum >= 1)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
            }
            else if (this.W >= 7)
            {
                aatkNum();  // 计算远程攻击数量
            }
        }

        /// <summary>
        /// ai行动的辅助方法
        /// </summary>
        void void_bv()
        {
            aiUseZhanshu();  // ai使用战术
        }

        // ai在特定条件下执行行动
        void void_i_t(int i1)
        {
            // 如果满足特定条件，所有小兵下达命令为2
            if (boolean_f() && i1 >= 4)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
                return;
            }

            void_bv();  // 执行ai行动
            for (byte byte1 = 0; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.smallSoldierOrder[1][byte1] = 1;  // 小兵下达命令为1
        }

        // ai执行更具体的行动
        void void_i_u(int i1)
        {
            // 如果满足特定条件，所有小兵下达命令为2
            if (boolean_f() && i1 >= 4)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
                return;
            }

            void_bv();  // 执行ai行动
            this.smallSoldierOrder[1][0] = 1;  // 第一个小兵下达命令为1
            for (byte byte1 = 1; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.smallSoldierOrder[1][byte1] = 0;  // 其余小兵命令为0
        }

        /// <summary>
        /// 人类小兵检测
        /// </summary>
        void HumanSoldierDetection()
        {
            // 遍历所有人类小兵
            for (byte byte0 = 1; byte0 < this.humanSmallSoldierNum; byte0 = (byte)(byte0 + 1))
            {
                if (this.smallSoldier_isSurvive[0][byte0])
                {
                    byte x = this.smallSoldierCellX[0][byte0];
                    byte y = this.smallSoldierCellY[0][byte0];

                    // 检查小兵是否在指定坐标内，并检查对应的ai小兵是否可以被攻击
                    for (byte byte1 = 1; byte1 < 5; byte1 = (byte)(byte1 + 1))
                    {
                        // 检查上方
                        if (y >= byte1 && (this.smallWarCoordinate[y - byte1][x] & 0x80) != 0)
                        {
                            byte byte2 = 1;
                            while (byte2 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte2] && this.smallSoldierCellX[1][byte2] == x && this.smallSoldierCellY[1][byte2] == y - byte1)
                                {
                                    // 如果对应的小兵不是远程攻击小兵，标记l_boolean_fld为true
                                    if (this.smallSoldierKind[1][byte2] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte2 = (byte)(byte2 + 1);
                            }
                        }

                        // 检查下方
                        if (y + byte1 <= 6 && (this.smallWarCoordinate[y + byte1][x] & 0x80) != 0)
                        {
                            byte byte3 = 1;
                            while (byte3 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte3] && this.smallSoldierCellX[1][byte3] == x && this.smallSoldierCellY[1][byte3] == y + byte1)
                                {
                                    if (this.smallSoldierKind[1][byte3] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte3 = (byte)(byte3 + 1);
                            }
                        }

                        // 检查左侧
                        if (x >= byte1 && (this.smallWarCoordinate[y][x - byte1] & 0x80) != 0)
                        {
                            byte byte4 = 1;
                            while (byte4 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte4] && this.smallSoldierCellX[1][byte4] == x - byte1 && this.smallSoldierCellY[1][byte4] == y)
                                {
                                    if (this.smallSoldierKind[1][byte4] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte4 = (byte)(byte4 + 1);
                            }
                        }

                        // 检查右侧
                        if (x + byte1 <= 15 && (this.smallWarCoordinate[y][x + byte1] & 0x80) != 0)
                        {
                            byte byte5 = 1;
                            while (byte5 < this.aiSmallSoldierNum)
                            {
                                if (this.smallSoldier_isSurvive[1][byte5] && this.smallSoldierCellX[1][byte5] == x + byte1 && this.smallSoldierCellY[1][byte5] == y)
                                {
                                    if (this.smallSoldierKind[1][byte5] != 2)
                                    {
                                        this.l_boolean_fld = true;
                                        return;
                                    }
                                    break;
                                }
                                byte5 = (byte)(byte5 + 1);
                            }
                        }
                    }
                }
            }
        }


        // ai根据条件执行某些操作
        void void_i_v(int i1)
        {
            // 如果满足特定条件并且i1大于等于4，所有小兵下达命令为2
            if (boolean_f() && i1 >= 4)
            {
                for (byte byte0 = 0; byte0 < this.aiSmallSoldierNum; byte0 = (byte)(byte0 + 1))
                    this.smallSoldierOrder[1][byte0] = 2;
                return;
            }

            // 根据条件获取两个短整型值
            short word0 = short_B_a(true);
            short word1 = short_B_a(false);

            // 执行ai行动
            void_bv();

            // 如果l_boolean_fld为false，执行以下逻辑
            if (!this.l_boolean_fld)
            {
                // 所有小兵下达命令为1
                for (byte byte1 = 0; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                    this.smallSoldierOrder[1][byte1] = 1;

                // 比较word1和word0，更新l_boolean_fld
                if (word1 > word0)
                {
                    this.l_boolean_fld = true;
                }
                else
                {
                    HumanSoldierDetection(); // 执行人类小兵检测
                }

                // 如果l_boolean_fld为true，将其余小兵命令设置为0
                if (this.l_boolean_fld)
                {
                    for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                        this.smallSoldierOrder[1][byte2] = 0;
                }
            }
        }

        // 比较两个武将的体力并返回对应状态
        byte byte_ss_c(short word0, short word1)
        {
            // 如果word0武将的体力小于20且随机值满足条件，返回4
            if (GeneralListCache.GetGeneral(word0).getCurPhysical() < 20 && CommonUtils.getRandomInt() % 2 == 0)
                return 4;

            // 否则根据word1武将的体力状态返回1或0
            return (byte)((GeneralListCache.GetGeneral(word1).getCurPhysical() >= (GeneralListCache.GetGeneral(word1)).maxPhysical / 2 || GeneralListCache.GetGeneral(word0).getCurPhysical() - GeneralListCache.GetGeneral(word1).getCurPhysical() <= 10) ? 1 : 0);
        }

        // 根据i1的值执行不同的逻辑
        int int_i_d(int i1)
        {
            byte byte0;
            i1 /= 1000; // 将i1除以1000

            // 根据i1的值设置byte0
            switch (i1)
            {
                case 1:
                    byte0 = 20;
                    break;
                case 2:
                    byte0 = 50;
                    break;
                case 3:
                    byte0 = 70;
                    break;
                default:
                    byte0 = 80;
                    break;
            }

            // 如果随机值大于byte0，将X设置为0
            if (CommonUtils.getRandomInt() % 100 > byte0)
                this.X = 0;

            return i1;
        }

        // 选择忠诚度最高的武将并任命为太守
        void AiAppointPrefectByLoyalty(byte byte0, short[] aword0, byte byte1)
        {
            int i1 = 0;
            short word0 = aword0[0];

            // 遍历所有候选武将，选择忠诚度最高的
            for (byte byte2 = 1; byte2 < byte1; byte2 = (byte)(byte2 + 1))
            {
                if (GeneralListCache.GetGeneral(word0).getLoyalty() < GeneralListCache.GetGeneral(aword0[byte2]).getLoyalty())
                {
                    word0 = aword0[byte2];
                    i1 = byte2;
                }
            }

            // 将忠诚度最高的武将任命为太守
            CityListCache.GetCityByCityId(byte0).prefectId = word0;

            // 调整候选武将列表
            for (byte byte3 = (byte)i1; byte3 > 0; byte3 = (byte)(byte3 - 1))
                aword0[byte3] = aword0[byte3 - 1];

            aword0[0] = word0;
        }

        // 任命太守
        void AiAppointPrefectInCity(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            city.AppointmentPrefect(); // 调用City对象的方法来任命太守
        }

        // 根据候选列表调整顺序，将符合条件的武将置于首位
        void SortOutSuitableGen(short[] aword0, byte byte0)
        {
            short word0 = aword0[0];
            byte byte1 = 0;
            int i1 = 0;

            // 遍历所有候选武将
            for (byte byte2 = 0; byte2 < byte0; byte2 = (byte)(byte2 + 1))
            {
                // 如果武将属于目标城市的国王，将其置于列表首位
                if (aword0[byte2] == CityListCache.GetCityByCityId(this.tarCity).cityBelongKing)
                {
                    word0 = aword0[0];
                    aword0[0] = aword0[byte2];
                    aword0[byte2] = word0;
                    return;
                }

                // 否则选择智力最高的武将
                if (GeneralListCache.GetGeneral(aword0[byte2]).IQ > byte1)
                {
                    word0 = aword0[byte2];
                    i1 = byte2;
                    byte1 = GeneralListCache.GetGeneral(word0).IQ;
                }
            }

            // 将智力最高的武将置于列表首位
            aword0[i1] = aword0[0];
            aword0[0] = word0;
        }

        // 计算两个城市之间的士兵与将领差异
        int DiffSoldierGenBetweenCity(byte byte0, byte byte1)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            int i1 = city.GetFood() / 4 * 1000 / 45;
            int j1;

            // 计算士兵差异
            if (i1 >= city.GetCityAllSoldierNum())
            {
                j1 = city.GetCityAllSoldierNum() - CityListCache.GetCityByCityId(byte1).GetCityAllSoldierNum();
            }
            else
            {
                j1 = i1 - CityListCache.GetCityByCityId(byte1).GetCityAllSoldierNum();
            }

            // 计算将领差异
            j1 += (city.getCityGeneralNum() - CityListCache.GetCityByCityId(byte1).getCityGeneralNum()) * 200;
            return j1;
        }

        // 计算城市与连接城市之间的最大士兵和将领差异
        int TrappedUnitNum_b(byte byte0)
        {
            int i1 = -20000;

            // 遍历连接的城市，计算其士兵和将领的差异
            for (byte byte1 = 0; byte1 < CityListCache.GetCityByCityId(byte0).connectCityId.Length; byte1 = (byte)(byte1 + 1))
            {
                byte byte2 = (byte)CityListCache.GetCityByCityId(byte0).connectCityId[byte1];
                int j1 = CityListCache.GetCityByCityId(byte2).GetCityAllSoldierNum() + CityListCache.GetCityByCityId(byte2).getCityGeneralNum() * 200
                            - CityListCache.GetCityByCityId(byte0).GetCityAllSoldierNum() - CityListCache.GetCityByCityId(byte0).getCityGeneralNum() * 200;

                // 更新i1为最大差异值
                if (i1 < j1)
                    i1 = j1;
            }

            return i1;
        }


        // 根据城市ID和输入值i1，寻找连接的城市，返回最优城市的将领数或计算结果
        int DiffSoldierGenBetweenConnectCityInCountry(byte byte0, int i1)
        {
            int j1 = 1;  // 记录将领数
            int k1 = i1 - 1999;  // 用于比较的差值
            for (byte byte1 = 0; byte1 < CityListCache.GetCityByCityId(byte0).connectCityId.Length; byte1 = (byte)(byte1 + 1))
            {
                byte byte2 = (byte)CityListCache.GetCityByCityId(byte0).connectCityId[byte1];

                // 检查是否属于同一国王，并且该城市的将领数大于1
                if (CityListCache.GetCityByCityId(byte2).cityBelongKing == CityListCache.GetCityByCityId(byte0).cityBelongKing && CityListCache.GetCityByCityId(byte2).getCityGeneralNum() > 1)
                {
                    if (!cityIsEnemy(byte2))  // 如果该城市不是敌对城市
                    {
                        // 更新当前城市为将领数最多的城市
                        if (CityListCache.GetCityByCityId(byte2).getCityGeneralNum() > j1)
                        {
                            this.curCity = byte2;
                            j1 = CityListCache.GetCityByCityId(byte2).getCityGeneralNum();
                        }
                    }
                    // 如果当前城市只有一个将领且i1大于0，尝试更新城市
                    else if (j1 == 1 && i1 > 0)
                    {
                        int l1 = TrappedUnitNum_b(byte2);  // 计算该城市的兵力差
                        if (l1 < k1)
                        {
                            this.curCity = byte2;
                            k1 = l1;
                        }
                    }
                }
            }

            // 如果有多个将领，返回将领数减1
            if (j1 > 1)
                return j1 - 1;

            // 否则，返回根据差值计算的结果
            if (k1 < i1 - 1999)
            {
                int i2 = (i1 - k1) / 2;
                if (i2 > i1)
                    return i1;
                return i2;
            }
            return 0;
        }

        // 计算两个城市之间的兵力差异，并根据将领能力计算最终差异
        int DiffSoldierGenByFightBetweenCity(byte thisCityId, byte byte1)
        {
            int i1 = 0;
            City city = CityListCache.GetCityByCityId(thisCityId);
            int l1 = city.getAlreadyAllSoldierNum() * 4 * 30 / 1000;  // 计算当前城市的兵力值
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            City otherCity = CityListCache.GetCityByCityId(byte1);
            short[] officeGeneralIdArray2 = otherCity.getCityOfficeGeneralIdArray();

            // 如果当前城市属于某个国王，计算该城市的将领能力
            if (city.cityBelongKing > 0)
                i1 = WholeGeneralFightValue(officeGeneralIdArray, city.getCityGeneralNum());

            // 如果城市兵力大于当前粮草数，按比例减少兵力值
            if (l1 > city.GetFood())
                i1 = i1 * city.GetFood() / l1;

            // 如果对方城市属于某个国王，计算对方城市的将领能力并更新差异
            if (CityListCache.GetCityByCityId(byte1).cityBelongKing > 0)
            {
                int j1 = WholeGeneralFightValue(officeGeneralIdArray2, otherCity.getCityGeneralNum());
                int k1 = GeneralListCache.GetGeneral(otherCity.prefectId).lead * GeneralListCache.GetGeneral(otherCity.prefectId).generalSoldier * 3 / 2;
                k1 = DiffSoldierGen(GeneralListCache.GetGeneral(otherCity.prefectId).lead, k1);
                j1 += k1;
                i1 -= j1;
            }

            return i1;
        }

        // 计算一个城市的总兵力，并根据将领能力调整
        int SoldierGenByFightInCity(byte byte0)
        {
            int i1 = 0;
            City city = CityListCache.GetCityByCityId(byte0);
            int l1 = city.getAlreadyAllSoldierNum() * 4 * 30 / 1000;  // 计算当前城市的兵力值

            // 如果城市属于某个国王，计算将领能力
            if (city.cityBelongKing > 0)
                i1 = WholeGeneralFightValue(city.getCityOfficeGeneralIdArray(), city.getCityGeneralNum());

            // 如果粮草不足，按比例减少兵力值
            if (l1 > city.GetFood())
                i1 = i1 * city.GetFood() / l1;

            return i1;
        }

        /// <summary>
        /// 计算某个国家与敌对城市的连接数
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        byte connectNun(byte countryId)
        {
            byte num = 0;

            // 遍历国家的所有城市
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(countryId).GetHaveCityNum(); byte1++)
            {
                byte curCity = CountryListCache.GetCountryByCountryId(countryId).getCity(byte1);

                // 如果当前城市是敌对城市，计算其连接的敌对城市数
                if (cityIsEnemy(curCity))
                {
                    for (byte i = 0; i < CityListCache.GetCityByCityId(curCity).connectCityId.Length; i = (byte)(i + 1))
                    {
                        byte curCity2 = (byte)CityListCache.GetCityByCityId(curCity).connectCityId[i];
                        if (CityListCache.GetCityByCityId(curCity2).cityBelongKing != CountryListCache.GetCountryByCountryId(countryId).countryKingId)
                            num = (byte)(num + 1);
                    }
                }
            }

            return num;
        }

        /// <summary>
        /// 计算某个国家与敌对城市的连接数，排除指定的目标城市
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="removetar"></param>
        /// <returns></returns>
        byte connectNun2(byte countryId, byte removetar)
        {
            byte num = 0;

            // 遍历国家的所有城市
            for (int byte1 = 0; byte1 < CountryListCache.GetCountryByCountryId(countryId).GetHaveCityNum(); byte1++)
            {
                byte curCity = CountryListCache.GetCountryByCountryId(countryId).getCity(byte1);

                // 如果当前城市是敌对城市，计算其连接的敌对城市数，排除指定的目标城市
                if (cityIsEnemy(curCity))
                {
                    for (byte i = 0; i < CityListCache.GetCityByCityId(curCity).connectCityId.Length; i = (byte)(i + 1))
                    {
                        byte curCity2 = (byte)CityListCache.GetCityByCityId(curCity).connectCityId[i];
                        if (CityListCache.GetCityByCityId(curCity2).cityBelongKing != CountryListCache.GetCountryByCountryId(countryId).countryKingId && curCity2 != removetar)
                            num = (byte)(num + 1);
                    }
                }
            }

            return num;
        }


        /// <summary>
        /// 设置占领威胁等级，基于与目标城市的连接数差值
        /// </summary>
        /// <param name="threat"></param>
        /// <param name="tar"></param>
        /// <returns></returns>
        int setOcupiceTheat2(int threat, byte tar)
        {
            byte sub = (byte)(connectNun(this.curTurnsCountryId) - connectNun2(this.curTurnsCountryId, tar));  // 计算连接数差值
            switch (sub)
            {
                case 1:
                    threat += 40000;
                    break;
                case 2:
                    threat += 100000;
                    break;
                case 3:
                    threat += 200000;
                    break;
                case 4:
                    threat += 400000;
                    break;
            }
            return threat;
        }

        /// <summary>
        /// 计算城市是否有被占领的威胁
        /// </summary>
        /// <param name="tar"></param>
        /// <param name="toWarCity"></param>
        /// <returns></returns>
        int getifOcupiceTheat(byte tar, byte toWarCity)
        {
            int threat = 0;
            short[] connectionCityIdArray = CityListCache.GetCityByCityId(tar).connectCityId;  // 获取连接的城市ID数组
            for (byte i = 0; i < connectionCityIdArray.Length; i = (byte)(i + 1))
            {
                short connectionCityId = connectionCityIdArray[i];
                if (connectionCityId != toWarCity && connectionCityId != tar)
                {
                    City connectionCity = CityListCache.GetCityByCityId((byte)connectionCityId);
                    if (connectionCity.cityBelongKing == CityListCache.GetCityByCityId(toWarCity).cityBelongKing)
                    {
                        threat += 60000;  // 如果连接城市与战争目标属于同一个国王，增加威胁
                    }
                    else if (connectionCity.cityBelongKing == 0)
                    {
                        threat += 10000;  // 如果连接城市是中立城市，增加较少威胁
                    }
                    else if (connectionCity.cityBelongKing > 0)
                    {
                        threat -= GetCityAtkPower((byte)connectionCityId) / 8;  // 减少威胁基于攻击力
                        for (byte j = 0; j < CityListCache.GetCityByCityId((byte)connectionCityId).connectCityId.Length; j = (byte)(j + 1))
                        {
                            byte curCity2 = (byte)CityListCache.GetCityByCityId((byte)connectionCityId).connectCityId[j];
                            if (curCity2 == toWarCity)
                                threat -= GetCityAtkPower(curCity2) / 8;  // 如果连接城市是战争城市，进一步减少威胁
                        }
                    }
                }
            }
            if (connectionCityIdArray.Length <= 1)
                threat += 30000;  // 如果只有一个连接城市，增加威胁
            threat = setOcupiceTheat2(threat, tar);  // 设置占领威胁等级
            return threat;
        }

        /// <summary>
        /// 计算空城的威胁等级
        /// </summary>
        /// <param name="city"></param>
        /// <param name="towarCity"></param>
        /// <returns></returns>
        int getEmetyCityThreat(byte city, byte towarCity)
        {
            int threat = 0;
            short[] connectionCityIdArray = CityListCache.GetCityByCityId(city).connectCityId;
            for (byte i = 0; i < connectionCityIdArray.Length; i = (byte)(i + 1))
            {
                short curCity = connectionCityIdArray[i];
                if (curCity != towarCity && curCity != city)
                {
                    City cCity = CityListCache.GetCityByCityId((byte)curCity);
                    if (cCity.cityBelongKing == CityListCache.GetCityByCityId(towarCity).cityBelongKing)
                    {
                        threat += 60000;  // 如果连接城市与战争目标城市同属一个国王，增加威胁
                    }
                    else if (cCity.cityBelongKing == 0)
                    {
                        threat += 30000;  // 如果连接城市是中立城市，增加较少威胁
                    }
                    else if (cCity.cityBelongKing > 0)
                    {
                        threat -= GetCityAtkPower((byte)curCity) / 10;  // 减少威胁基于攻击力
                    }
                }
            }
            if (CityListCache.GetCityByCityId(city).connectCityId.Length <= 1)
                threat += 100000;  // 如果只有一个连接城市，显著增加威胁
            return threat;
        }

        /// <summary>
        /// 计算某个城市的防御能力
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        int getHmCityDefPower(byte cityId)
        {
            int power = 1;
            City city = CityListCache.GetCityByCityId(cityId);
            int needFood = city.getAllSoldierNum() / 8 + 1;  // 计算所需粮食量
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
            {
                short generalId = city.getCityOfficeGeneralIdArray()[index];
                General general = GeneralListCache.GetGeneral(generalId);
                if (index == 0)
                {
                    if (general.generalSoldier < 800)
                    {
                        power += getsatrapGenPower(generalId) / 2;  // 如果将领士兵数少于800，增加较少的力量
                        continue;
                    }
                }
                power += getGenPower(generalId);  // 根据将领的能力增加防御力量
                continue;
            }
            if (city.GetFood() < needFood)
                power = power * (city.GetFood() + 1) / needFood * 2;  // 如果粮食不足，调整防御力量
            power -= power / 2;  // 减少一半防御力量作为惩罚
            return power;
        }

        /// <summary>
        /// AI判断是否发动战争
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        /// <param name="warNum"></param>
        /// <returns></returns>
        bool AIThinkWar(byte curTurnsCountryId, byte warNum)
        {
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);
            int minMustPower = 0;
            bool result = false;
            for (int i = 0; i < country.GetHaveCityNum(); i++)
            {
                byte curCityId = country.getCity(i);
                City curUserCity = CityListCache.GetCityByCityId(curCityId);
                int gl = 100 * curUserCity.getAlreadyAllSoldierNum() / curUserCity.getAllSoldierNum();  // 计算士兵比例
                int gl2 = MathUtils.getRandomInt(101);  // 随机获取一个数值用于判断
                if (gl2 <= gl)  // 根据概率判断是否发动战争
                {
                    int maxAtkPower = (int)(curUserCity.getMaxAtkPower() * (0.5D + 0.5D * warNum));  // 计算最大攻击力
                    int maxEnemyAtkPower = (int)(CountryListCache.GetEnemyAdjacentAtkPowerArray(curCityId) * 0.65D);  // 计算敌人的最大攻击力
                    if (maxAtkPower > maxEnemyAtkPower)  // 如果我方攻击力大于敌方
                    {
                        byte[] adjacentCity = CountryListCache.GetEnemyCityIdArray(curCityId);  // 获取敌方相邻城市
                        for (int enemyIndex = 0; enemyIndex < adjacentCity.Length; enemyIndex++)
                        {
                            byte curEnemyCityId = adjacentCity[enemyIndex];
                            if (GameInfo.isWatch)  // 如果当前为观察模式，跳过玩家所属城市
                            {
                                City enemyCity = CityListCache.GetCityByCityId(curEnemyCityId);
                                if (enemyCity.cityBelongKing != 0 && CountryListCache.GetCountryByKingId(enemyCity.cityBelongKing).countryId == GameInfo.humanCountryId)
                                    continue;
                            }
                            int defenseAbility = CountryListCache.GetEnemyAdjacentCityDefenseAbility(curEnemyCityId, curCityId);  // 获取敌方防御能力
                            if (maxAtkPower - maxEnemyAtkPower > defenseAbility && minMustPower < maxAtkPower - maxEnemyAtkPower - defenseAbility)
                            {
                                minMustPower = maxAtkPower - maxEnemyAtkPower - defenseAbility;  // 更新最小必需攻击力
                                result = true;
                                this.tarCity = curCityId;
                                this.curCity = curEnemyCityId;
                            }
                            continue;
                        }
                    }
                }
            }
            return result;  // 返回是否发动战争的判断结果
        }


        /// <summary>
        /// 战争随机决策函数，根据战争能力计算是否可以胜利
        /// </summary>
        /// <param name="warNum"></param>
        /// <returns></returns>
        bool warRand(byte warNum)
        {
            City cCity = CityListCache.GetCityByCityId(this.curCity); // 获取当前城市信息
            int defenseAbility = cCity.GetDefenseAbility(); // 获取防御能力
            City tCity = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市信息
            int atkPower = tCity.getMaxAtkPower(); // 获取目标城市的最大攻击能力
            double warAbility = (5 * warNum + getWarAbility(atkPower, defenseAbility)); // 计算战争能力
            int random = MathUtils.getRandomInt(100); // 获取0到100的随机数
            if (random <= warAbility) // 如果随机数小于等于战争能力，战争胜利
                return true;

            if (cCity.cityBelongKing == 0) // 如果城市没有归属的国家，战争失败
                return false;

            if ((CountryListCache.GetCountryByKingId(cCity.cityBelongKing)).countryId == GameInfo.humanCountryId) // 如果城市所属国家是玩家国家
            {
                random = MathUtils.getRandomInt(100); // 再次获取随机数
                if (random <= warAbility)
                    return true; // 如果随机数仍然小于战争能力，战争胜利
            }
            return false; // 否则战争失败
        }

        /// <summary>
        /// 计算战争能力值，根据攻击力与防御力的比率得出战争能力
        /// </summary>
        /// <param name="atkPower"></param>
        /// <param name="defenseAbility"></param>
        /// <returns></returns>
        private byte getWarAbility(int atkPower, int defenseAbility)
        {
            byte ability = 0;
            if (atkPower >= 2 * defenseAbility) // 攻击力是防御力的两倍或以上
            {
                ability = 80;
            }
            else if (atkPower >= 1.67D * defenseAbility)
            {
                ability = 70;
            }
            else if (atkPower >= 1.33D * defenseAbility)
            {
                ability = 60;
            }
            else if (atkPower >= defenseAbility)
            {
                ability = 50;
            }
            else if (atkPower >= 0.84D * defenseAbility)
            {
                ability = 40;
            }
            else if (atkPower >= 0.68D * defenseAbility)
            {
                ability = 30;
            }
            else if (atkPower >= 0.52D * defenseAbility)
            {
                ability = 20;
            }
            else if (atkPower >= 0.36D * defenseAbility)
            {
                ability = 10;
            }
            return ability; // 返回战争能力值
        }

        // 执行某种逻辑并对传入的整数进行分段处理
        int int_i_e(int i1)
        {
            byte byte0;
            i1 /= 300000; // 将输入值缩小为特定范围
            switch (i1)
            {
                case 1:
                    byte0 = 50;
                    break;
                case 2:
                    byte0 = 80;
                    break;
                default:
                    byte0 = 90;
                    break;
            }
            // 如果随机数大于设定的阈值，将X设为0
            if (CommonUtils.getRandomInt() % 100 > byte0)
                this.X = 0;
            return i1; // 返回处理后的i1值
        }

        /// <summary>
        /// 将城市中的武将按带兵能力和智力划分为三类武、智、全
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="abyte0"></param>
        /// <param name="abyte1"></param>
        /// <param name="abyte2"></param>
        /// <returns></returns>
        byte[] GenDivideInto3Kind(byte cityId, byte[] abyte0, byte[] abyte1, byte[] abyte2)
        {
            byte[] abyte3 = new byte[3]; // 存储三类武将的数量
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市信息
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市中的任职武将ID列表

            // 遍历城市中的武将
            for (byte i = 0; i < city.getCityGeneralNum(); i++)
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // 获取武将信息
                if (general.generalSoldier >= 100) // 只有士兵数大于100的武将才参与判断
                {
                    if (general.lead >= general.IQ && general.lead >= 80) // 武将带兵能力大于智力，且带兵能力大于等于80
                    {
                        abyte3[0] = (byte)(abyte3[0] + 1); // 带兵型武将数量增加
                        abyte0[abyte3[0]] = i; // 存储该武将的ID
                    }
                    else if (general.IQ >= 80) // 如果智力大于等于80
                    {
                        abyte3[1] = (byte)(abyte3[1] + 1); // 智谋型武将数量增加
                        abyte1[abyte3[1]] = i; // 存储该武将的ID
                    }
                    else // 普通型武将
                    {
                        abyte3[2] = (byte)(abyte3[2] + 1); // 普通型武将数量增加
                        abyte2[abyte3[2]] = i; // 存储该武将的ID
                    }
                }
            }

            // 对带兵型武将按照带兵能力排序
            for (byte i = 0; i < abyte3[0] - 1; i++)
            {
                General general1 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte0[i]]);
                for (int j = i + 1; j < abyte3[0]; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte0[j]]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.lead < general2.lead)
                    {
                        byte temp = abyte0[i];
                        abyte0[i] = abyte0[j];
                        abyte0[j] = temp;
                    }
                }
            }

            // 对智谋型武将按照智力排序
            for (byte i = 0; i < abyte3[1] - 1; i++)
            {
                General general1 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte1[i]]);
                for (int j = i + 1; j < abyte3[1]; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte1[j]]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.IQ < general2.IQ)
                    {
                        byte temp = abyte1[i];
                        abyte1[i] = abyte1[j];
                        abyte1[j] = temp;
                    }
                }
            }

            // 对普通型武将按照带兵能力和智力之和排序
            for (byte i = 0; i < abyte3[2] - 1; i++)
            {
                General general1 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte2[i]]);
                for (int j = i + 1; j < abyte3[2]; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(officeGeneralIdArray[abyte2[j]]);
                    if (general1.IQ + general1.lead < general2.IQ + general2.lead)
                    {
                        byte temp = abyte2[i];
                        abyte2[i] = abyte2[j];
                        abyte2[j] = temp;
                    }
                }
            }

            return abyte3; // 返回三类武将的数量
        }


        /// <summary>
        /// 获取带兵能力高的武将ID数组
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] getLeadGeneralIdArray(byte cityId)
        {
            short[] abyte0 = new short[0]; // 存储带兵能力高的武将ID数组
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市信息
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市内任职武将的ID数组
            byte i;

            // 遍历城市内的武将
            for (i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // 获取武将信息
                                                                                        // 排除城市太守，并筛选出带兵能力高于智力且带兵能力大于等于80的武将
                if (city.prefectId != general.generalId && general.generalSoldier >= 100 && general.lead >= general.IQ && general.lead >= 80)
                {
                    short[] tempAbyte0 = new short[abyte0.Length + 1]; // 动态扩展数组大小
                    for (int j = 0; j < abyte0.Length; j++)
                        tempAbyte0[j] = abyte0[j]; // 复制原数组内容
                    tempAbyte0[tempAbyte0.Length - 1] = general.generalId; // 添加符合条件的武将ID
                    abyte0 = tempAbyte0; // 更新数组
                }
            }

            // 根据带兵能力排序
            for (i = 0; i < abyte0.Length - 1; i = (byte)(i + 1))
            {
                General general1 = GeneralListCache.GetGeneral(abyte0[i]);
                for (int j = i + 1; j < abyte0.Length; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(abyte0[j]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.lead < general2.lead)
                    {
                        short temp = abyte0[i]; // 交换顺序
                        abyte0[i] = abyte0[j];
                        abyte0[j] = temp;
                    }
                }
            }
            return abyte0; // 返回排序后的武将ID数组
        }

        /// <summary>
        /// 获取智力高的武将ID数组
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] getIQGeneralIdArray(byte cityId)
        {
            short[] abyte1 = new short[0]; // 存储智力高的武将ID数组
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市信息
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市内任职武将的ID数组
            byte i;

            // 遍历城市内的武将
            for (i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // 获取武将信息
                                                                                        // 排除城市太守，筛选出智力大于带兵能力或带兵能力小于80的武将
                if (city.prefectId != general.generalId && general.generalSoldier >= 100 && (general.lead < general.IQ || general.lead < 80))
                    if (general.IQ >= 80)
                    {
                        short[] tempAbyte1 = new short[abyte1.Length + 1]; // 动态扩展数组大小
                        for (int j = 0; j < abyte1.Length; j++)
                            tempAbyte1[j] = abyte1[j]; // 复制原数组内容
                        tempAbyte1[tempAbyte1.Length - 1] = general.generalId; // 添加符合条件的武将ID
                        abyte1 = tempAbyte1; // 更新数组
                    }
            }

            // 根据智力排序
            for (i = 0; i < abyte1.Length - 1; i = (byte)(i + 1))
            {
                General general1 = GeneralListCache.GetGeneral(abyte1[i]);
                for (int j = i + 1; j < abyte1.Length; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(abyte1[j]);
                    if (general1.generalSoldier < general2.generalSoldier && general1.IQ < general2.IQ)
                    {
                        short temp = abyte1[i]; // 交换顺序
                        abyte1[i] = abyte1[j];
                        abyte1[j] = temp;
                    }
                }
            }
            return abyte1; // 返回排序后的武将ID数组
        }

        /// <summary>
        /// 获取普通武将ID数组（带兵和智力能力均不高）
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] getOrdinaryGeneralIdArray(byte cityId)
        {
            short[] abyte2 = new short[0]; // 存储普通武将ID数组
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市信息
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市内任职武将的ID数组

            // 遍历城市内的武将
            for (byte i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
            {
                General general = GeneralListCache.GetGeneral(officeGeneralIdArray[i]); // 获取武将信息
                                                                                        // 排除城市太守，筛选出智力小于80且带兵能力不高的武将
                if (city.prefectId != general.generalId && general.generalSoldier >= 100 && (general.lead < general.IQ || general.lead < 80))
                    if (general.IQ < 80)
                    {
                        short[] tempAbyte2 = new short[abyte2.Length + 1]; // 动态扩展数组大小
                        for (int j = 0; j < abyte2.Length; j++)
                            tempAbyte2[j] = abyte2[j]; // 复制原数组内容
                        tempAbyte2[tempAbyte2.Length - 1] = general.generalId; // 添加符合条件的武将ID
                        abyte2 = tempAbyte2; // 更新数组
                    }
            }

            // 根据智力和带兵能力总和排序
            for (byte i = 0; i < abyte2.Length - 1; i = (byte)(i + 1))
            {
                General general1 = GeneralListCache.GetGeneral(abyte2[i]);
                for (int j = i + 1; j < abyte2.Length; j++)
                {
                    General general2 = GeneralListCache.GetGeneral(abyte2[j]);
                    if (general1.IQ + general1.lead < general2.IQ + general2.lead)
                    {
                        short temp = abyte2[i]; // 交换顺序
                        abyte2[i] = abyte2[j];
                        abyte2[j] = temp;
                    }
                }
            }
            return abyte2; // 返回排序后的普通武将ID数组
        }

        /// <summary>
        /// 计算将领的能力值，根据武将的智力、带兵能力、等级和武力计算
        /// </summary>
        /// <param name="generalId"></param>
        /// <returns></returns>
        int satrapVal(short generalId)
        {
            byte zl = GeneralListCache.GetGeneral(generalId).IQ; // 获取武将的智力值
            byte ts = GeneralListCache.GetGeneral(generalId).lead; // 获取武将的带兵能力值
            byte dj = GeneralListCache.GetGeneral(generalId).level; // 获取武将的等级
            byte wl = GeneralListCache.GetGeneral(generalId).force; // 获取武将的武力值
                                                                    // 计算太守管理值，带兵能力、智力、武力及等级的加权计算
            int gjl = (int)(ts * 1.42D + zl * 0.25D + wl * 0.33D + ((ts * 2 + wl + zl) * (dj - 1)) * 0.04D);
            return gjl; // 返回计算的太守管理值
        }


        /// <summary>
        /// Ai任命太守
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="generlIdArray"></param>
        /// <param name="generlNum"></param>
        void AiAppointmentPrefect(byte cityId, short[] generlIdArray, byte generlNum)
        {
            int i1 = 0;
            int maxWeight = 0;
            short prefectId = 0;

            // 遍历所有将领，寻找最合适的太守
            for (byte byte2 = 0; byte2 < generlNum; byte2 = (byte)(byte2 + 1))
            {
                short generlId = generlIdArray[byte2];

                // 如果该将领是国王的，将其直接任命为太守
                if (generlId == (CityListCache.GetCityByCityId(cityId)).cityBelongKing)
                {
                    maxWeight = 1000;
                    prefectId = generlId;
                    i1 = byte2;
                    break;
                }

                // 如果将领忠诚度大于等于60，并且其太守值大于当前最大值，更新太守候选人
                if (GeneralListCache.GetGeneral(generlId).getLoyalty() >= 60 && satrapVal(generlId) > maxWeight)
                {
                    maxWeight = satrapVal(generlId);
                    prefectId = generlId;
                    i1 = byte2;
                }
            }

            // 如果没有合适的太守候选人，则选择忠诚度最高的将领
            if (maxWeight == 0)
            {
                i1 = 0;
                prefectId = generlIdArray[0];
                for (byte byte3 = 1; byte3 < generlNum; byte3 = (byte)(byte3 + 1))
                {
                    if (GeneralListCache.GetGeneral(prefectId).getLoyalty() < GeneralListCache.GetGeneral(generlIdArray[byte3]).getLoyalty())
                    {
                        prefectId = generlIdArray[byte3];
                        i1 = byte3;
                    }
                }
            }

            // 更新城市的太守信息
            (CityListCache.GetCityByCityId(cityId)).prefectId = prefectId;

            // 将太守放置在将领数组的第一个位置
            for (byte byte4 = (byte)i1; byte4 > 0; byte4 = (byte)(byte4 - 1))
                generlIdArray[byte4] = generlIdArray[byte4 - 1];
            generlIdArray[0] = prefectId;

            // 分配士兵给新太守
            AiAssignSoldier(cityId);
        }

        /// <summary>
        /// 清空城市所有将领的士兵数量
        /// </summary>
        /// <param name="cityId"></param>
        void CleanAllGeneralSoldierInCity(byte cityId)
        {
            for (byte byte0 = 0; byte0 < CityListCache.GetCityByCityId(cityId).getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
                (GeneralListCache.GetGeneral(CityListCache.GetCityByCityId(cityId).getCityOfficeGeneralIdArray()[byte0])).generalSoldier = 0;
        }

        /// <summary>
        /// Ai对城市中的将领按太守值排序
        /// </summary>
        /// <param name="cityId"></param>
        void SortGeneralBySatrapVal(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 从第一个将领开始，按太守值进行排序
            for (byte byte0 = 1; byte0 < city.getCityGeneralNum(); byte0 = (byte)(byte0 + 1))
            {
                int i = satrapVal(officeGeneralIdArray[byte0]);
                for (byte byte1 = byte0; byte1 < city.getCityGeneralNum(); byte1 = (byte)(byte1 + 1))
                {
                    int j = satrapVal(officeGeneralIdArray[byte1]);
                    if (j > i)
                    {
                        int max = officeGeneralIdArray[byte1];
                        officeGeneralIdArray[byte1] = officeGeneralIdArray[byte0];
                        officeGeneralIdArray[byte0] = (short)max;
                    }
                }
            }
        }

        /// <summary>
        /// Ai分配士兵
        /// </summary>
        /// <param name="cityId"></param>
        void AiAssignSoldier(byte cityId)
        {
            SortGeneralBySatrapVal(cityId);
            CleanAllGeneralSoldierInCity(cityId);

            City city = CityListCache.GetCityByCityId(cityId);
            short cityAllSoldierNum = (short)city.GetCityAllSoldierNum();
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();

            // 为太守分配士兵
            short needSoldier = (short)(GeneralListCache.GetGeneral(city.prefectId).getMaxGeneralSoldier() - (GeneralListCache.GetGeneral(city.prefectId)).generalSoldier);
            if (needSoldier > 0)
            {
                if (needSoldier > cityAllSoldierNum)
                    needSoldier = cityAllSoldierNum;
                (GeneralListCache.GetGeneral(city.prefectId)).generalSoldier += needSoldier;
                cityAllSoldierNum -= needSoldier;
            }

            // 为其他将领分配士兵
            if (cityAllSoldierNum > 0)
            {
                for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
                {
                    short needSoldierForGeneral = (short)(GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).getMaxGeneralSoldier() - (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).generalSoldier);
                    if (needSoldierForGeneral > cityAllSoldierNum)
                        needSoldierForGeneral = cityAllSoldierNum;
                    (GeneralListCache.GetGeneral(officeGeneralIdArray[byte2])).generalSoldier += needSoldierForGeneral;
                    cityAllSoldierNum -= needSoldierForGeneral;
                }
            }
        }

        /// <summary>
        /// Ai根据太守值或忠诚度筛选将领
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="generalNum"></param>
        void AiSortGeneralsBySatrapVal(short[] aword0, byte generalNum)
        {
            short firstGeneralId = aword0[0];
            int j1 = 0;

            // 如果将领中有属于国王的，将其放置在第一个位置
            for (byte byte2 = 0; byte2 < generalNum; byte2 = (byte)(byte2 + 1))
            {
                if (aword0[byte2] == (CityListCache.GetCityByCityId(this.tarCity)).cityBelongKing)
                {
                    aword0[0] = aword0[byte2];
                    aword0[byte2] = firstGeneralId;
                    return;
                }
            }

            // 找出太守值最大的将领
            int maxval = 0;
            for (byte b1 = 0; b1 < generalNum; b1 = (byte)(b1 + 1))
            {
                int curVal = ((GeneralListCache.GetGeneral(aword0[b1])).IQ * 2 + (GeneralListCache.GetGeneral(aword0[b1])).lead) / 3;
                if (curVal > maxval && (GeneralListCache.GetGeneral(aword0[b1])).generalSoldier >= 1000)
                {
                    firstGeneralId = aword0[b1];
                    maxval = curVal;
                    j1 = b1;
                }
            }

            // 将找到的将领放置在第一个位置
            aword0[j1] = aword0[0];
            aword0[0] = firstGeneralId;
        }


        /// <summary>
        /// AI选择将领出战，返回派遣的将领数量
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        byte AISelectGenToWar(short[] aword0, int power)
        {
            // 获取目标城市和当前城市的引用
            City city = CityListCache.GetCityByCityId(this.tarCity);
            City cCity = CityListCache.GetCityByCityId(this.curCity);

            // 获取目标城市中的不同类型将领数组
            short[] IQGeneralIdArray = getIQGeneralIdArray(this.tarCity); // 智力型将领
            short[] leadGeneralIdArray = getLeadGeneralIdArray(this.tarCity); // 领导型将领
            short[] ordinaryGeneralIdArray = getOrdinaryGeneralIdArray(this.tarCity); // 普通将领

            byte dispatchGeneralNum = 0; // 已派遣的将领数量
            int totalPower = 0; // 总兵力
            byte byte5 = 0; // 临时计数变量
            short[] cityIdArray = (CityListCache.GetCityByCityId(this.curCity)).connectCityId; // 当前城市相连的城市ID数组

            // 当前城市不属于任何国家时
            if (cCity.cityBelongKing == 0)
            {
                // 查找是否有与目标城市相连的城市
                for (byte5 = 0; byte5 < cityIdArray.Length && (CityListCache.GetCityByCityId((byte)cityIdArray[byte5])).cityBelongKing == this.tarCity;)
                    byte5 = (byte)(byte5 + 1);

                // 如果所有相连城市都属于目标城市
                if (byte5 == cityIdArray.Length)
                {
                    // 从普通将领数组、智力将领数组或领导将领数组中选择最后一个将领
                    if (ordinaryGeneralIdArray.Length > 0)
                    {
                        short generalId = ordinaryGeneralIdArray[ordinaryGeneralIdArray.Length - 1];
                        aword0[0] = generalId;
                    }
                    else if (IQGeneralIdArray.Length > 0)
                    {
                        aword0[0] = IQGeneralIdArray[IQGeneralIdArray.Length - 1];
                    }
                    else
                    {
                        aword0[0] = leadGeneralIdArray[leadGeneralIdArray.Length - 1];
                    }
                    city.removeOfficeGeneralId(aword0[0]); // 移除城市中的该将领
                    return 1; // 返回已派遣的将领数量1
                }
            }

            // 当前城市属于某个国家时
            if (cCity.cityBelongKing > 0)
            {
                // 计算城市的防御能力，并加入随机因素
                totalPower = cCity.GetDefenseAbility();
                totalPower += CommonUtils.getRandomInt() % (totalPower / 4 + 1);

                // 如果当前城市属于玩家的国家，双倍兵力
                if (cCity.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                    totalPower *= 2;
            }

            // 加入额外的兵力
            totalPower += power;

            // 根据总兵力依次从领导型、智力型、普通将领数组中派遣将领
            for (byte leadIndex = 0; leadIndex < leadGeneralIdArray.Length && totalPower > 0; leadIndex = (byte)(leadIndex + 1))
            {
                short generalId = leadGeneralIdArray[leadIndex];
                aword0[dispatchGeneralNum] = generalId;
                city.removeOfficeGeneralId(generalId);
                int l1 = getGenPower(generalId); // 获取将领的战斗力
                dispatchGeneralNum = (byte)(dispatchGeneralNum + 1);
                totalPower -= l1;
            }

            for (byte IQIndex = 0; IQIndex < IQGeneralIdArray.Length && totalPower > 0; IQIndex = (byte)(IQIndex + 1))
            {
                short generalId = IQGeneralIdArray[IQIndex];
                aword0[dispatchGeneralNum] = generalId;
                city.removeOfficeGeneralId(generalId);
                int l1 = getGenPower(generalId); // 获取将领的战斗力
                dispatchGeneralNum = (byte)(dispatchGeneralNum + 1);
                totalPower -= l1;
            }

            for (byte i = 0; i < ordinaryGeneralIdArray.Length && totalPower > 0; i = (byte)(i + 1))
            {
                short generalId = ordinaryGeneralIdArray[i];
                aword0[dispatchGeneralNum] = generalId;
                city.removeOfficeGeneralId(generalId);
                int j2 = getGenPower(aword0[dispatchGeneralNum]); // 获取将领的战斗力
                dispatchGeneralNum = (byte)(dispatchGeneralNum + 1);
                totalPower -= j2;
            }

            // 调整将领数组顺序
            AiSortGeneralsBySatrapVal(aword0, dispatchGeneralNum);

            // 返回派遣的将领数量
            return dispatchGeneralNum;
        }


        /// <summary>
        /// 将领选择逻辑，返回派遣的将领数量
        /// </summary>
        /// <param name="aword0"></param>
        /// <param name="i1"></param>
        /// <returns></returns>
        byte AISelectGenTo2(short[] aword0, int i1)
        {
            // 获取目标城市和其下属的将领信息
            City city = CityListCache.GetCityByCityId(this.tarCity);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市的所有官员ID
            byte generalNum = city.getCityGeneralNum(); // 获取城市的将领数量

            // 定义三个不同类型的将领数组
            byte[] abyte0 = new byte[generalNum]; // 用于存储特定类型的将领
            byte[] abyte1 = new byte[generalNum]; // 用于存储另一种类型的将领
            byte[] abyte2 = new byte[generalNum]; // 用于存储第三种类型的将领

            // 初始化一些控制变量
            byte byte0 = 0;
            byte byte1 = 0;
            byte byte2 = 0;
            byte byte3 = 0;
            int j1 = 0;
            byte byte5 = 0;
            int k2 = 0;

            // 通过调用方法获取将领的分配情况
            byte[] abyte3 = GenDivideInto3Kind(this.tarCity, abyte1, abyte0, abyte2);
            byte1 = abyte3[0];
            byte0 = abyte3[1];
            byte2 = abyte3[2];
            abyte3 = null;

            // 获取当前城市的引用
            City cCity = CityListCache.GetCityByCityId(this.curCity);

            // 当前城市无主的情况
            if (cCity.cityBelongKing == 0)
            {
                // 检查是否与目标城市相连的城市是否也是无主
                for (byte5 = 0; byte5 < (CityListCache.GetCityByCityId(this.curCity)).connectCityId.Length &&
                    (CityListCache.GetCityByCityId((byte)(CityListCache.GetCityByCityId(this.curCity)).connectCityId[byte5])).cityBelongKing == this.tarCity;)
                {
                    byte5 = (byte)(byte5 + 1);
                }

                // 如果所有相连城市都无主
                if (byte5 == (CityListCache.GetCityByCityId(this.curCity)).connectCityId.Length)
                {
                    // 根据优先级选择将领
                    if (byte2 > 0)
                    {
                        short generalId = officeGeneralIdArray[abyte2[byte2 - 1]];
                        aword0[0] = generalId;
                    }
                    else if (byte0 > 0)
                    {
                        short generalId = officeGeneralIdArray[abyte0[byte0 - 1]];
                        aword0[0] = generalId;
                    }
                    else
                    {
                        short generalId = officeGeneralIdArray[abyte1[byte1 - 1]];
                        aword0[0] = generalId;
                    }
                    city.removeOfficeGeneralId(aword0[0]); // 移除选择的将领
                    AiAppointPrefectInCity(this.tarCity); // 更新城市状态
                    return 1; // 返回已派遣的将领数量
                }
            }

            // 统计目标城市与其他城市的连接情况
            int l2 = 0;
            for (byte5 = 0; byte5 < (CityListCache.GetCityByCityId(this.tarCity)).connectCityId.Length; byte5 = (byte)(byte5 + 1))
            {
                if ((CityListCache.GetCityByCityId((byte)(CityListCache.GetCityByCityId(this.tarCity)).connectCityId[byte5])).cityBelongKing != this.tarCity)
                {
                    l2++;
                }
            }

            // 如果目标城市只有一个相连城市不属于它
            if (l2 == 1)
            {
                byte byte4;
                if (byte2 > 0)
                {
                    byte4 = abyte2[byte2 - 1];
                }
                else if (byte0 > 0)
                {
                    byte4 = abyte0[byte0 - 1];
                }
                else
                {
                    byte4 = abyte1[byte1 - 1];
                }

                // 派遣除选择的将领外的所有将领
                for (byte5 = 0; byte5 < city.getCityGeneralNum(); byte5 = (byte)(byte5 + 1))
                {
                    if (byte5 != byte4)
                    {
                        short generalId = officeGeneralIdArray[byte5];
                        byte3 = (byte)(byte3 + 1);
                        aword0[byte3] = generalId;
                        city.removeOfficeGeneralId(generalId);
                    }
                }
                AiAppointPrefectInCity(this.tarCity); // 更新城市状态
                AiSortGeneralsBySatrapVal(aword0, byte3); // 更新将领数组
                return byte3; // 返回派遣的将领数量
            }

            // 当前城市有主的情况
            if (cCity.cityBelongKing > 0)
            {
                // 获取当前城市的兵力值
                j1 = WholeGeneralFightValue(cCity.getCityOfficeGeneralIdArray(), cCity.getCityGeneralNum());
                int k1 = (GeneralListCache.GetGeneral(cCity.prefectId)).lead * ((GeneralListCache.GetGeneral(cCity.prefectId)).generalSoldier + 1500) * 3 / 2;
                k1 = DiffSoldierGen((GeneralListCache.GetGeneral(cCity.prefectId)).lead, k1);
                j1 += k1;

                // 如果当前城市属于玩家的国家
                if (cCity.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                {
                    j1 *= 2;
                }
                else
                {
                    j1 += 700000;
                }
            }

            j1 += i1; // 加入额外兵力
            byte5 = 0;
            k2 = 0;

            // 循环派遣将领，直到兵力不足或所有将领已派出
            while (byte3 < city.getCityGeneralNum() - 1)
            {
                // 优先派遣第一个类型的将领
                if (byte5 < byte1)
                {
                    short generalId = officeGeneralIdArray[abyte1[byte5]];
                    aword0[byte3] = generalId;
                    city.removeOfficeGeneralId(generalId);
                    int l1 = SingleGeneralFightValue(aword0[byte3]); // 计算该将领的战斗力
                    byte3 = (byte)(byte3 + 1);

                    // 特殊处理第一次派遣
                    if (byte5 == 0)
                    {
                        byte5 = (byte)(byte5 + 2);
                    }
                    else
                    {
                        byte5 = (byte)(byte5 + 1);
                    }
                    j1 -= l1;

                    // 如果兵力耗尽或者将领派完
                    if (j1 <= 0 || byte3 >= city.getCityGeneralNum() - 1)
                    {
                        AiAppointPrefectInCity(this.tarCity);
                        AiSortGeneralsBySatrapVal(aword0, byte3);
                        return byte3;
                    }
                }

                // 其次派遣第二个类型的将领
                if (k2 < byte0)
                {
                    short generalId = officeGeneralIdArray[abyte0[k2]];
                    aword0[byte3] = generalId;
                    city.removeOfficeGeneralId(generalId);
                    int i2 = SingleGeneralFightValue(aword0[byte3]);
                    byte3 = (byte)(byte3 + 1);
                    if (k2 == 0)
                    {
                        k2 += 2;
                    }
                    else
                    {
                        k2++;
                    }
                    j1 -= i2;

                    if (j1 <= 0)
                    {
                        AiAppointPrefectInCity(this.tarCity);
                        AiSortGeneralsBySatrapVal(aword0, byte3);
                        return byte3;
                    }
                }

                if (byte5 >= byte1 && k2 >= byte0)
                {
                    break;
                }
            }

            // 最后派遣第三个类型的将领
            for (byte byte6 = 0; byte3 < CityListCache.GetCityByCityId(this.tarCity).getCityGeneralNum() - 1 && byte6 < byte2;)
            {
                short generalId = officeGeneralIdArray[abyte2[byte6]];
                aword0[byte3] = generalId;
                city.removeOfficeGeneralId(generalId);
                int j2 = SingleGeneralFightValue(aword0[byte3]);
                byte3 = (byte)(byte3 + 1);
                byte6 = (byte)(byte6 + 1);
                j1 -= j2;

                if (j1 <= 0)
                {
                    AiAppointPrefectInCity(this.tarCity);
                    AiSortGeneralsBySatrapVal(aword0, byte3);
                    return byte3;
                }
            }

            // 更新城市状态并返回派遣的将领数量
            AiAppointPrefectInCity(this.tarCity);
            AiSortGeneralsBySatrapVal(aword0, byte3);
            return byte3;
        }


        /// <summary>
        /// 判断是否需要征兵，返回布尔值表示是否征兵
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        /// <returns></returns>
        bool AiJudDraft(byte curTurnsCountryId)
        {
            this.tarCity = 0; // 初始化目标城市
            int minPower = -300000; // 设置初始的最小兵力差
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId); // 获取当前轮次国家对象
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray(); // 获取邻近的敌方城市列表

            // 遍历每一个邻近的敌方城市
            for (byte index = 0; index < adjacentCity.Length; index = (byte)(index + 1))
            {
                byte curCity = adjacentCity[index];
                if (curCity != 0)
                {
                    City city = CityListCache.GetCityByCityId(curCity); // 获取当前城市对象
                    int needSoldierNum = city.getAllSoldierNum() - city.cityReserveSoldier; // 计算需要的士兵数量
                    if (needSoldierNum > 0 && city.GetMoney() >= 100) // 当需要士兵且城市资金大于100时
                        for (int index2 = 0; index2 < (CityListCache.GetCityByCityId(curCity)).connectCityId.Length; index2++)
                        {
                            byte enemyCityId = (byte)(CityListCache.GetCityByCityId(curCity)).connectCityId[index2]; // 获取连接的城市ID
                                                                                                                // 检查是否连接的城市为敌方城市
                            if ((CityListCache.GetCityByCityId(enemyCityId)).cityBelongKing != (CityListCache.GetCityByCityId(curCity)).cityBelongKing)
                            {
                                int enemyCityAtkPower = GetCityAtkPower(enemyCityId); // 获取敌方城市的攻击力
                                int curCityDefPower = GetCityDefPower(curCity); // 获取当前城市的防御力
                                int gap = enemyCityAtkPower - curCityDefPower; // 计算攻击防御力差
                                                                                // 更新最大攻击差并设置目标城市
                                if (gap > minPower)
                                {
                                    minPower = gap;
                                    this.tarCity = curCity;
                                }
                            }
                        }
                }
            }

            // 如果没有符合条件的目标城市，进行进一步检查
            if (this.tarCity == 0)
            {
                int minNum = 0;
                for (int i = 0; i < adjacentCity.Length; i++)
                {
                    byte curCity = adjacentCity[i];
                    City city = CityListCache.GetCityByCityId(curCity);
                    int num = city.getAllSoldierNum() - city.cityReserveSoldier;
                    if (num > 0 && city.GetMoney() >= 600) // 检查城市是否有足够的士兵和资金
                        if (num > minNum)
                        {
                            minNum = num;
                            this.tarCity = curCity; // 更新目标城市为士兵数量最多的城市
                        }
                }

                // 如果仍没有符合条件的目标城市，继续寻找
                if (this.tarCity == 0)
                {
                    int con2num = 0;
                    byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray(); // 获取无敌方相邻城市列表
                    for (int j = 0; j < adjacentCity.Length; j++)
                    {
                        byte city0 = adjacentCity[j];
                        for (int k = 0; k < noAdjacentCity.Length; k++)
                        {
                            byte city1 = noAdjacentCity[k];
                            City city = CityListCache.GetCityByCityId(city1);
                            // 检查是否相连城市符合条件
                            for (int m = 0; m < (CityListCache.GetCityByCityId(city1)).connectCityId.Length; m++)
                            {
                                byte city3 = (byte)(CityListCache.GetCityByCityId(city1)).connectCityId[m];
                                if (city3 == city0)
                                {
                                    int must = city.getAllSoldierNum() - city.cityReserveSoldier;
                                    if (must > 0 && city.GetMoney() >= 500)
                                    {
                                        if (must > con2num)
                                        {
                                            con2num = must;
                                            this.tarCity = city1; // 更新目标城市为士兵最多的城市
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return (this.tarCity != 0); // 返回是否找到了目标城市
        }

        // 计算城市的攻击力
        int GetCityAtkPower(byte cityId)
        {
            int power = 1;
            City city = CityListCache.GetCityByCityId(cityId);
            int needFood = city.getAllSoldierNum() / 8 + 1; // 计算所需粮食
                                                            // 遍历城市将领，计算其攻击力
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
                power += getGenPower(city.getCityOfficeGeneralIdArray()[index]); // 获取每个将领的攻击力

            int mufood = city.GetFood() + 1;
            // 检查粮食是否不足，降低攻击力
            if (mufood < needFood && city.cityBelongKing != (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                power = power * mufood / needFood;

            // 如果城市属于玩家国家，增加攻击力
            if (city.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                power = (int)(power * 1.75D);

            return power;
        }

        // 计算城市的防御力
        int GetCityDefPower(byte cityId)
        {
            int power = 1;
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市的将领ID数组
            int needFood = city.getAllSoldierNum() / 8 + 1; // 计算所需粮食

            // 遍历将领，计算防御力
            for (byte index = 0; index < city.getCityGeneralNum(); index = (byte)(index + 1))
            {
                if (officeGeneralIdArray[index] == city.prefectId) // 如果是太守，使用特殊防御力计算
                {
                    power += getsatrapGenPower(officeGeneralIdArray[index]);
                }
                else
                {
                    power += getGenPower(officeGeneralIdArray[index]); // 获取普通将领的防御力
                }
            }

            // 检查粮食不足的情况，减少防御力
            if (city.GetFood() < needFood)
                power = power * (city.GetFood() + 1) / needFood;

            // 如果城市属于玩家国家，增加防御力
            if (city.cityBelongKing == (CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId)).countryKingId)
                power = (int)(power * 1.2D);

            return power;
        }


        // 计算普通将领的战斗力
        int getGenPower(short generalId)
        {
            int power = 1; // 初始化战斗力
            short gjl = (short)satrapVal(generalId); // 获取将领能力值
            long gjl_jq = (1 + gjl * gjl * gjl / 100000); // 计算将领的基础战斗力增益

            General general = GeneralListCache.GetGeneral(generalId); // 获取将领对象

            // 如果将领的士兵少于100，限制战斗力并返回0
            if (general.generalSoldier < 100)
            {
                gjl_jq = Math.Min(100L, gjl_jq);
                return 0;
            }

            // 如果战斗力增益低于20，重新计算
            if (gjl_jq < 20L)
                gjl_jq = Math.Max((general.generalSoldier / 150), gjl_jq);

            power = (int)(power + gjl_jq * (general.generalSoldier + 1)); // 计算总战斗力
            return power;
        }

        // 计算太守将领的战斗力
        int getsatrapGenPower(short id)
        {
            General general = GeneralListCache.GetGeneral(id); // 获取将领对象
            int power = 1; // 初始化战斗力
            short gjl = (short)satrapVal(id); // 获取将领能力值

            // 太守将领的能力值增加30%
            gjl = (short)(int)(gjl * 1.3D);
            long gjl_jq = (1 + gjl * gjl * gjl / 100000); // 计算基础战斗力增益

            // 如果士兵少于500，限制战斗力
            if (general.generalSoldier < 500)
                gjl_jq = Math.Min(150L, gjl_jq);

            // 如果战斗力增益低于20，重新计算
            if (gjl_jq < 20L)
                gjl_jq = Math.Max((general.generalSoldier / 150), gjl_jq);

            power = (int)(power + gjl_jq * (general.generalSoldier + 1)); // 计算总战斗力
            return power;
        }

        // 计算将领的移动战斗力
        bool getMoveGenPower(byte curTurnsCountryId)
        {
            this.tarCity = 0; // 初始化目标城市
            this.curCity = 0; // 初始化当前城市
            int movePower = 0; // 初始化移动战斗力
            bool result = false; // 初始化结果标志

            // 获取当前国家相邻的敌方城市ID数组
            byte[] adjacentCity = CountryListCache.GetEnemyAdjacentCityIdArray(curTurnsCountryId);

            // 遍历相邻的敌方城市
            for (int index = 0; index < adjacentCity.Length; index++)
            {
                byte cityId = adjacentCity[index];
                City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象

                // 计算敌方相邻城市的攻击力和当前城市的防御能力
                int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId);
                int defenseAbility = city.GetDefenseAbility();

                // 如果当前的移动战斗力小于攻击差值，更新移动战斗力并设置目标城市
                if (movePower < enemyAdjacentAtkPower - defenseAbility)
                {
                    movePower = enemyAdjacentAtkPower - defenseAbility;
                    this.tarCity = cityId;
                    result = true;
                }
            }

            // 如果找到合适的目标城市，进行进一步处理
            if (result)
            {
                City tCity = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市对象
                int defenseAbility = tCity.GetDefenseAbility(); // 获取目标城市的防御能力
                int enemyAdjacentAtkPower = CountryListCache.GetEnemyAdjacentAtkPowerArray(this.tarCity); // 获取相邻敌方攻击力
                movePower = enemyAdjacentAtkPower - defenseAbility;

                Country country = CountryListCache.GetCountryByKingId(tCity.cityBelongKing); // 获取目标城市所属国家
                byte[] cityIds = CountryListCache.GetNoEnemyAdjacentCityIdArray(country.countryId); // 获取无敌方相邻的城市ID数组

                // 遍历无敌方相邻的城市，转移将领以减少移动战斗力
                for (int i = 0; i < cityIds.Length && movePower > 0; i++)
                {
                    byte cityId = cityIds[i];
                    City city = CityListCache.GetCityByCityId(cityId);
                    short[] generalIds = city.GetWarOfficeGeneralIdArray(1); // 获取战争办公厅的将领ID数组

                    if (generalIds.Length != 0)
                    {
                        for (int j = 0; j < generalIds.Length && movePower > 0; j++)
                        {
                            short generalId = generalIds[j];
                            General general = GeneralListCache.GetGeneral(generalId); // 获取将领对象
                            movePower = (int)(movePower - general.GetBattlePower()); // 减少战斗力
                            city.removeOfficeGeneralId(generalId); // 从当前城市移除将领
                            tCity.AddOfficeGeneralId(generalId); // 将将领添加到目标城市
                        }
                        city.AppointmentPrefect(); // 为城市任命太守
                    }
                }

                // 遍历敌方相邻的城市，继续转移将领以减少战斗力
                cityIds = CountryListCache.GetEnemyAdjacentCityIdArray(country.countryId);
                for (int i = 0; i < cityIds.Length && movePower > 0; i++)
                {
                    byte cityId = cityIds[i];
                    City city = CityListCache.GetCityByCityId(cityId);
                    int defenseAbility1 = city.GetDefenseAbility(); // 获取城市的防御能力
                    int enemyAdjacentAtkPower1 = CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId); // 获取敌方攻击力

                    // 检查攻击力是否小于等于防御力
                    if (enemyAdjacentAtkPower1 <= defenseAbility1)
                    {
                        short[] generalIds = city.GetWarOfficeGeneralIdArray(enemyAdjacentAtkPower1);
                        if (generalIds.Length != 0)
                        {
                            for (int j = 0; j < generalIds.Length && movePower > 0; j++)
                            {
                                short generalId = generalIds[j];
                                General general = GeneralListCache.GetGeneral(generalId); // 获取将领对象
                                movePower = (int)(movePower - general.GetBattlePower()); // 减少战斗力
                                city.removeOfficeGeneralId(generalId); // 移除将领
                                tCity.AddOfficeGeneralId(generalId); // 将将领添加到目标城市
                            }
                            city.AppointmentPrefect(); // 任命太守
                        }
                    }
                }
            }
            else
            {
                int minPower = 0; // 初始化最小战斗力

                // 遍历相邻的敌方城市，寻找最适合的目标城市
                for (int i = 0; i < adjacentCity.Length; i++)
                {
                    byte cityId = adjacentCity[i];
                    City city = CityListCache.GetCityByCityId(cityId); // 获取当前城市对象
                    byte[] enemyCityIdArray = CountryListCache.GetEnemyCityIdArray(cityId); // 获取敌方城市ID数组

                    for (int j = 0; j < enemyCityIdArray.Length; j++)
                    {
                        byte enemyCityId = enemyCityIdArray[j];
                        int defenseAbility = CountryListCache.GetEnemyAdjacentCityDefenseAbility(enemyCityId, cityId); // 获取敌方城市防御能力

                        // 检查是否满足战斗力条件，更新最小战斗力并设置目标城市
                        if (city.getCityGeneralNum() < 10 && (minPower == 0 || minPower > city.getMaxAtkPower() - CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId) - defenseAbility))
                        {
                            minPower = city.getMaxAtkPower() - CountryListCache.GetEnemyAdjacentAtkPowerArray(cityId) - defenseAbility;
                            result = true;
                            this.tarCity = cityId; // 设置目标城市
                        }
                    }
                }

                // 如果找到合适的目标城市，继续处理
                if (result)
                {
                    byte[] cityIds = CountryListCache.GetNoEnemyAdjacentCityIdArray(curTurnsCountryId); // 获取无敌方相邻的城市
                    City tCity = CityListCache.GetCityByCityId(this.tarCity); // 获取目标城市
                    bool isMove = false; // 标志是否完成将领转移

                    // 遍历无敌方相邻的城市，转移将领
                    for (int j = 0; j < cityIds.Length && !isMove; j++)
                    {
                        byte cityId = cityIds[j];
                        City city = CityListCache.GetCityByCityId(cityId);
                        short[] generalIds = city.GetWarOfficeGeneralIdArray(1); // 获取战争办公厅的将领ID

                        if (generalIds.Length != 0)
                        {
                            for (int k = 0; k < generalIds.Length; k++)
                            {
                                short generalId = generalIds[k];
                                General general = GeneralListCache.GetGeneral(generalId); // 获取将领对象
                                movePower = (int)(movePower - general.GetBattlePower()); // 减少战斗力
                                city.removeOfficeGeneralId(generalId); // 移除将领
                                tCity.AddOfficeGeneralId(generalId); // 将将领添加到目标城市
                                isMove = true; // 标记已完成将领转移
                            }
                            city.AppointmentPrefect(); // 任命太守
                        }
                    }
                }
            }

            return result; // 返回结果
        }


        // 计算城市的最大威胁值
        int getCityMaxTheat(byte city)
        {
            int min = -20000000; // 初始化最小威胁值
                                    // 遍历当前城市的相邻城市
            for (int index = 0; index < CityListCache.GetCityByCityId(city).connectCityId.Length; index++)
            {
                short tcity = CityListCache.GetCityByCityId(city).connectCityId[index]; // 获取相邻城市ID
                                                                                        // 如果相邻城市的所属国家不同
                if (CityListCache.GetCityByCityId((byte)tcity).cityBelongKing != CityListCache.GetCityByCityId(city).cityBelongKing)
                {
                    int enemyatkPower = GetCityAtkPower((byte)tcity); // 获取敌方城市攻击力
                    int mydefPower = GetCityDefPower(city); // 获取当前城市防御力
                    int sub = enemyatkPower - mydefPower; // 计算威胁值差
                    if (sub > min)
                        min = sub; // 更新最大威胁值
                }
            }
            return min; // 返回最大威胁值
        }

        // 计算城市可获取的战斗力
        int cityCangetPower(byte city, int needPower)
        {
            this.curCity = 0; // 初始化当前城市
            int cangetGenPower = 1; // 初始化可获取的将领战斗力
            int cangetPower = needPower; // 初始化需要的战斗力
                                            // 遍历所有城市
            for (byte id = 1; id < CityListCache.CITY_NUM; id = (byte)(id + 1))
            {
                City city2 = CityListCache.GetCityByCityId(id); // 获取当前城市对象
                                                                // 检查城市是否属于同一国家且将领数量大于1
                if (id != city && city2.cityBelongKing == CityListCache.GetCityByCityId(city).cityBelongKing && city2.getCityGeneralNum() > 1)
                {
                    if (!cityIsEnemy(id)) // 检查是否没有敌人
                    {
                        if (city2.getCityGeneralNum() > cangetGenPower)
                        {
                            this.curCity = id; // 更新当前城市
                            cangetGenPower = city2.getCityGeneralNum(); // 更新可获取的将领战斗力
                        }
                    }
                    else if (cangetGenPower == 1 && needPower >= 0) // 如果将领战斗力为1且需要战斗力大于等于0
                    {
                        int threat = getCityMaxTheat(id); // 获取城市的最大威胁
                        if (threat < cangetPower)
                        {
                            this.curCity = id; // 更新当前城市
                            cangetPower = threat; // 更新可获取的战斗力
                        }
                    }
                }
            }
            // 如果可获取的将领战斗力大于1，返回值减少1
            if (cangetGenPower > 1)
                return cangetGenPower - 1;
            // 如果找到合适的城市
            if (this.curCity != 0)
            {
                int pj = (needPower - cangetPower) / 2; // 计算中间值
                if (pj > needPower)
                    return needPower; // 如果中间值大于所需战斗力，返回所需战斗力
                return pj; // 否则返回中间值
            }
            return 0; // 如果没有找到合适的城市，返回0
        }

        /// <summary>
        /// 处理AiFindLowHpEnemyGeneral方法
        /// </summary>
        /// <returns></returns>
        bool AiFindLowHpEnemyGeneral()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // 获取当前国家
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray(); // 获取相邻敌方城市ID数组
            byte byte3 = 0; // 初始化最大智力/领导值
                                // 遍历相邻敌方城市
            for (byte byte1 = 0; byte1 < adjacentCity.Length; byte1 = (byte)(byte1 + 1))
            {
                byte adjacentCityId = adjacentCity[byte1]; // 获取相邻城市ID
                if (adjacentCityId <= 0) // 如果ID无效，跳出循环
                    break;
                City city = CityListCache.GetCityByCityId(adjacentCityId); // 获取城市对象
                short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市办公厅将领ID数组
                if (city.GetMoney() >= 100) // 如果城市金钱大于等于100
                {
                    // 遍历城市将领
                    for (byte byte2 = 0; byte2 < city.getCityGeneralNum(); byte2 = (byte)(byte2 + 1))
                    {
                        short generalId = officeGeneralIdArray[byte2]; // 获取将领ID
                                                                        // 检查将领体力是否小于等于最大体力的一半
                        if (GeneralListCache.GetGeneral(generalId).getCurPhysical() <= GeneralListCache.GetGeneral(generalId).maxPhysical / 2)
                        {
                            // 如果将领智力大于领导力
                            if (GeneralListCache.GetGeneral(generalId).IQ > GeneralListCache.GetGeneral(generalId).lead)
                            {
                                if (GeneralListCache.GetGeneral(generalId).IQ > byte3) // 更新最大智力
                                {
                                    byte3 = GeneralListCache.GetGeneral(generalId).IQ;
                                    this.tarCity = adjacentCityId; // 设置目标城市
                                    this.HMGeneralId = generalId; // 设置目标将领
                                }
                            }
                            else if (GeneralListCache.GetGeneral(generalId).lead > byte3) // 否则比较领导力
                            {
                                byte3 = GeneralListCache.GetGeneral(generalId).lead;
                                this.tarCity = adjacentCityId; // 设置目标城市
                                this.HMGeneralId = generalId; // 设置目标将领
                            }
                            this.X = 19; // 设置某个状态值
                            this.tarCity = adjacentCityId; // 再次设置目标城市
                            this.HMGeneralId = generalId; // 再次设置目标将领
                        }
                    }
                }
            }
            return (byte3 >= 0); // 如果找到了合适的将领，返回true
        }

        /// <summary>
        /// Ai检测低忠诚度将领方法
        /// </summary>
        /// <returns></returns>
        bool AiFindLowLoyaltyGeneral()
        {
            int maxGeneralScore = 0; // 初始化最大将领得分
            short tempGeneralId = 0; // 初始化临时将领ID
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // 获取当前国家
                                                                                                // 遍历国家中的城市
            for (int k = 0; k < country.GetHaveCityNum(); k++)
            {
                byte cityId = country.getCity(k); // 获取城市ID
                City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
                                                                    // 检查城市金钱或宝物数量
                if (city.GetMoney() >= 50 || city.treasureNum != 0)
                {
                    short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray(); // 获取城市办公厅将领ID数组
                                                                                        // 遍历城市中的将领
                    for (byte i = 0; i < city.getCityGeneralNum(); i = (byte)(i + 1))
                    {
                        short GeneralId = officeGeneralIdArray[i]; // 获取将领ID
                        General general = GeneralListCache.GetGeneral(GeneralId); // 获取将领对象
                        int generalScore = general.getGeneralScore(); // 获取将领得分
                                                                        // 检查将领忠诚度和城市的金钱/宝物条件
                        if (generalScore > maxGeneralScore)
                            if (general.getLoyalty() < 90 && city.GetMoney() > 50 && city.GetMoney() / 50 > MathUtils.getRandomInt(4))
                            {
                                maxGeneralScore = generalScore; // 更新最大得分
                                tempGeneralId = GeneralId; // 更新临时将领ID
                                this.HMGeneralId = tempGeneralId; // 设置目标将领
                                this.tarCity = cityId; // 设置目标城市
                            }
                            else if (general.getLoyalty() >= 90 && city.treasureNum > 0 && city.treasureNum > MathUtils.getRandomInt(4))
                            {
                                maxGeneralScore = generalScore; // 更新最大得分
                                tempGeneralId = GeneralId; // 更新临时将领ID
                                this.HMGeneralId = tempGeneralId; // 设置目标将领
                                this.tarCity = cityId; // 设置目标城市
                            }
                    }
                }
            }
            if (tempGeneralId == 0) // 如果没有找到合适的将领
                return false;
            this.X = 8; // 设置某个状态值
            return true; // 返回true
        }


        /// <summary>
        /// Ai检查是否需要将资金从一个城市运往另一个城市
        /// </summary>
        /// <returns></returns>
        bool needTransportMoneyToOtherCity()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);
            byte num = country.GetHaveCityNum(); // 获取国家拥有的城市数量
            if (num < 2)
                return false; // 如果城市数量小于2，则无需运输资金

            int[][] dat = new int[num * num][];
            for (int i = 0; i < num * num; i++)
                dat[i] = new int[3];

            try
            {
                // 初始化dat数组，存储城市间的资金信息
                for (int k = 0; k < num; k++)
                {
                    for (int m = 0; m < num; m++)
                    {
                        dat[k * num + m][0] = country.getCity(k); // 城市1
                        dat[k * num + m][1] = country.getCity(m); // 城市2
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message); // 捕捉并输出异常
                return false;
            }

            // 计算每对城市的资金差异
            for (int i = 0; i < dat.Length; i++)
            {
                if (dat[i][0] != dat[i][1])
                {
                    byte cityId1 = (byte)dat[i][0];
                    City city1 = CityListCache.GetCityByCityId(cityId1); // 城市1对象
                    byte cityId2 = (byte)dat[i][1];
                    City city2 = CityListCache.GetCityByCityId(cityId2); // 城市2对象

                    short needMoney1 = 0;
                    short needMoney2 = 0;

                    // 判断城市1是否邻近敌城，决定其所需资金
                    if (CountryListCache.GetEnemyCityIdArray(cityId1).Length != 0)
                    {
                        needMoney1 = (short)(200 + city1.getCityGeneralNum() * 2000 - city1.getAllSoldierNum() / 5);
                    }
                    else
                    {
                        needMoney1 = (short)(200 + city1.getCityGeneralNum() * 600 - city1.getAllSoldierNum() / 5);
                    }

                    // 判断城市2是否邻近敌城，决定其所需资金
                    if (CountryListCache.GetEnemyCityIdArray(cityId2).Length != 0)
                    {
                        needMoney2 = (short)(200 + city2.getCityGeneralNum() * 2000 - city2.getAllSoldierNum() / 5);
                    }
                    else
                    {
                        needMoney2 = (short)(200 + city2.getCityGeneralNum() * 600 - city2.getAllSoldierNum() / 5);
                    }

                    // 计算两座城市之间的资金差
                    dat[i][2] = city1.GetMoney() - needMoney1 - city2.GetMoney() + needMoney2;
                }
            }

            // 寻找资金差最大的城市对
            int val = -100000;
            byte pCity = 0;
            byte ACity = 0;

            for (int j = 0; j < dat.Length; j++)
            {
                if (dat[j][2] > val)
                {
                    byte cityId1 = (byte)dat[j][0];
                    byte cityId2 = (byte)dat[j][1];
                    City city1 = CityListCache.GetCityByCityId(cityId1);
                    City city2 = CityListCache.GetCityByCityId(cityId2);

                    if (city1 == null || city2 == null)
                        break;

                    // 根据资金情况及敌我关系，确定需要运输资金的城市
                    if (city1.GetMoney() > 200 && !cityIsEnemy(cityId1) && cityIsEnemy(cityId2))
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                    else if (city1.GetMoney() > 200 && cityIsEnemy(cityId1) && cityIsEnemy(cityId2) && city2.GetMoney() < 200)
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                    else if (city1.GetMoney() > 200 && cityIsEnemy(cityId1) && !cityIsEnemy(cityId2) && city2.GetMoney() < 100)
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                    else if (city1.GetMoney() > 200 && !cityIsEnemy(cityId1) && !cityIsEnemy(cityId2) && city2.GetMoney() < 200)
                    {
                        pCity = cityId1;
                        ACity = cityId2;
                        val = dat[j][2];
                    }
                }
            }

            // 如果找到合适的城市对，则返回true
            if (pCity > 0 && ACity > 0)
            {
                this.tarCity = ACity;
                this.curCity = pCity;
                return true;
            }

            return false; // 否则返回false
        }

        /// <summary>
        /// Ai检查城市是否需要粮食
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] cityNeedFood(byte cityId)
        {
            short[] needVal = new short[3]; // 存储返回的粮食需求信息
            short needFood = 0;
            bool isNearEnemy = false;
            City city = CityListCache.GetCityByCityId(cityId);
            short food = CityListCache.GetCityByCityId(cityId).GetFood(); // 获取城市当前的粮食数量

            // 如果城市邻近敌城，则增加战争和收获的粮食需求
            if (cityIsEnemy(cityId))
            {
                isNearEnemy = true;
                needFood = (short)(needFood + city.needFoodWarAMonth());
                needFood = (short)(needFood + city.needFoodToHarvest());
            }
            else
            {
                needFood = (short)(needFood + city.needFoodToHarvest());
                if (food > needFood)
                    needFood = (short)(needFood - food - needFood); // 如果粮食超过需求，则减少需求
            }

            // 计算粮食需求情况
            if (needFood > food)
            {
                needVal[0] = 1;
                byte v1 = (byte)((needFood - food) / 100); // 计算粮食缺口
                short num = (short)(food - needFood); // 计算当前粮食余额
                if (isNearEnemy)
                    v1 = (byte)(v1 * 4 / 3); // 如果邻近敌城，则增加需求系数
                needVal[1] = v1;
                needVal[2] = num;
            }
            else
            {
                needVal[0] = 0;
                byte v2 = (byte)((needFood - food) / 100);
                short num = (short)(food - needFood);
                needVal[1] = v2;
                needVal[2] = num;
            }

            return needVal; // 返回粮食需求信息
        }


        /// <summary>
        /// AI判断是否需要运输粮食
        /// </summary>
        /// <returns></returns>
        bool judTransportFood()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // 获取当前回合的国家
            if (country.GetHaveCityNum() < 2)
                return false; // 如果城市数量小于2，则无需运输粮食

            this.tarCity = 0;
            this.curCity = 0;

            // 初始化一个存储每个城市粮食需求的二维数组
            short[][] needprot = new short[country.GetHaveCityNum()][];
            for (int i = 0; i < country.GetHaveCityNum(); i++)
            {
                byte city = country.getCity(i); // 获取国家的每个城市ID
                needprot[i] = cityNeedFood(city); // 调用方法获取该城市的粮食需求信息
            }

            // 初始化最大和最小的粮食需求量及其对应的城市
            byte max = (byte)needprot[0][1];
            byte min = (byte)needprot[0][1];
            byte maxcity = country.getCity(0);
            byte mincity = country.getCity(0);

            // 遍历所有城市，找到粮食需求最多和最少的城市
            for (int j = 0; j < needprot.Length; j++)
            {
                if (needprot[j][1] > max)
                {
                    max = (byte)needprot[j][1];
                    maxcity = country.getCity(j);
                }
                if (needprot[j][1] < min)
                {
                    min = (byte)needprot[j][1];
                    mincity = country.getCity(j);
                }
            }

            // 如果最大和最小的城市是同一个，则不需要运输粮食
            if (maxcity == mincity)
                return false;

            // 根据最大最小城市粮食需求的不同情况进行判断
            if (max == min && max > 0 && min > 0)
            {
                // 如果最大城市是敌城，最小城市不是敌城，则需要运输粮食
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
                if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == country.countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            return true;
                        }
                    }
                }
            }
            else if (max == min && max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
            }
            else if (max > 0 && min > 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
                if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == country.countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            return true;
                        }
                    }
                }
                else if (cityIsEnemy(maxcity) && cityIsEnemy(mincity) && max > min + 3)
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
            }
            else if (max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                    return true;
                }
            }
            else
            {
                this.tarCity = maxcity;
                this.curCity = mincity;
                this.X = 12;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ai判断城市的资金需求
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short[] cityNeedMoney(byte cityId)
        {
            short[] needVal = new short[3]; // 用于存储返回的资金需求信息
            short needMoney = 0; // 初始资金需求为0
            bool isNearEnemy = false; // 标记该城市是否邻近敌城
            City city = CityListCache.GetCityByCityId(cityId); // 获取城市对象
            byte generalNum = city.getCityGeneralNum(); // 获取该城市的将领数量

            // 如果该城市邻近敌城
            if (cityIsEnemy(cityId))
            {
                isNearEnemy = true;
                needMoney = (short)(needMoney + 100 + (city.getAllSoldierNum() - city.GetCityAllSoldierNum()) / 3);
                if (needMoney < 200 && city.GetMoney() < generalNum * 600)
                    needMoney = (short)(needMoney + generalNum * 600); // 如果资金不足，则增加需求
            }
            else
            {
                needMoney = (short)(needMoney + 100 + (city.getAllSoldierNum() - city.GetCityAllSoldierNum()) / 3); // 不邻近敌城时的资金需求
            }

            // 如果资金需求大于当前城市资金
            if (needMoney > city.GetMoney())
            {
                needVal[0] = 1; // 标记需要资金
                byte v1 = (byte)((needMoney - city.GetMoney()) / 100); // 计算资金缺口
                short num = (short)(city.GetMoney() - needMoney); // 当前城市资金余额
                if (isNearEnemy)
                    v1 = (byte)(v1 * 4 / 3); // 如果邻近敌城，需求增加
                needVal[1] = v1;
                needVal[2] = num;
            }
            else
            {
                needVal[0] = 0; // 标记不需要资金
                byte v2 = (byte)((needMoney - city.GetMoney()) / 100); // 计算资金缺口
                short num = (short)(city.GetMoney() - needMoney); // 当前城市资金余额
                needVal[1] = v2;
                needVal[2] = num;
            }

            return needVal; // 返回资金需求信息
        }


        /// <summary>
        /// Ai判断是否需要运输资金
        /// </summary>
        void judTransportMoney()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // 获取当前回合的国家
            if (country.GetHaveCityNum() < 2)
                return; // 如果该国家城市数量小于2，则不需要运输资金

            this.tarCity = 0;
            this.curCity = 0;

            // 初始化二维数组，存储每个城市的资金需求情况
            short[][] needprot = new short[country.GetHaveCityNum()][];
            for (int i = 0; i < country.GetHaveCityNum(); i++)
            {
                byte city = country.getCity(i); // 获取城市ID
                needprot[i] = cityNeedMoney(city); // 获取该城市的资金需求
            }

            // 初始化最大和最小资金需求及其对应的城市
            byte max = (byte)needprot[0][1];
            byte min = (byte)needprot[0][1];
            byte maxcity = country.getCity(0);
            byte mincity = country.getCity(0);

            // 遍历所有城市，寻找最大和最小的资金需求城市
            for (int j = 0; j < needprot.Length; j++)
            {
                if (needprot[j][1] > max)
                {
                    max = (byte)needprot[j][1];
                    maxcity = country.getCity(j);
                }
                if (needprot[j][1] < min)
                {
                    min = (byte)needprot[j][1];
                    mincity = country.getCity(j);
                }
            }

            // 如果最大和最小的城市是同一个，则不需要运输资金
            if (maxcity == mincity)
                return;

            // 根据最大最小城市的资金需求情况判断是否运输资金
            if (max == min && max > 0 && min > 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12; // 设置运输资金的距离
                }
                else if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            break;
                        }
                    }
                }
            }
            else if (max == min && max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
            }
            else if (max > 0 && min > 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
                else if (cityIsEnemy(maxcity))
                {
                    for (int j = 0; j < CityListCache.GetCityByCityId(maxcity).connectCityId.Length; j++)
                    {
                        byte city = (byte)CityListCache.GetCityByCityId(maxcity).connectCityId[j];
                        if (CityListCache.GetCityByCityId(city).cityBelongKing == CountryListCache.GetCountryByCountryId(GameInfo.humanCountryId).countryKingId)
                        {
                            this.tarCity = maxcity;
                            this.curCity = mincity;
                            this.X = 12;
                            break;
                        }
                    }
                }
                else if (cityIsEnemy(maxcity) && cityIsEnemy(mincity) && max > min + 3)
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
            }
            else if (max < 0 && min < 0)
            {
                if (cityIsEnemy(maxcity) && !cityIsEnemy(mincity))
                {
                    this.tarCity = maxcity;
                    this.curCity = mincity;
                    this.X = 12;
                }
            }
            else
            {
                this.tarCity = maxcity;
                this.curCity = mincity;
                this.X = 12;
            }
        }

        /// <summary>
        /// Ai将将领从一个城市调动到另一个城市
        /// </summary>
        /// <returns></returns>
        bool AiMoveGeneralToOtherCity()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId); // 获取当前回合的国家
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray(); // 获取邻近敌方的城市ID数组
            byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray(); // 获取不邻近敌方的城市ID数组
            if (noAdjacentCity.Length <= 0)
                return false; // 如果没有不邻近敌方的城市，则不需要调动

            double maxBattlePower = 0.0D; // 最大战斗力
            short moveGeneralId = 0; // 需要移动的将领ID
            byte moveCityId = 0; // 需要移动的城市ID

            // 遍历所有不邻近敌方的城市，寻找战斗力最高的将领
            for (int index = 0; index < noAdjacentCity.Length; index++)
            {
                byte thisCity = noAdjacentCity[index];
                City city = CityListCache.GetCityByCityId(thisCity);
                for (byte id = 0; id < city.getCityGeneralNum(); id++)
                {
                    short generalId = city.getCityOfficeGeneralIdArray()[id];
                    if (generalId != 0)
                    {
                        General general = GeneralListCache.GetGeneral(generalId);
                        double curVal = general.GetBattlePower();
                        if (curVal > maxBattlePower)
                        {
                            moveGeneralId = generalId;
                            maxBattlePower = curVal;
                            moveCityId = thisCity;
                        }
                    }
                }
            }

            double minBattlePower = maxBattlePower; // 最小战斗力
            short beMoveId = 0; // 被替换的将领ID
            byte beCityId = 0; // 被替换的城市ID

            // 遍历所有邻近敌方的城市，寻找战斗力最低的将领
            for (int i = 0; i < adjacentCity.Length; i++)
            {
                byte thisCity = adjacentCity[i];
                City city = CityListCache.GetCityByCityId(thisCity);
                for (byte id = 0; id < city.getCityGeneralNum(); id++)
                {
                    short generalId = city.getCityOfficeGeneralIdArray()[id];
                    if (generalId != 0)
                    {
                        General general = GeneralListCache.GetGeneral(generalId);
                        double curVal = general.GetBattlePower();
                        if (curVal < minBattlePower)
                        {
                            beMoveId = generalId;
                            minBattlePower = curVal;
                            beCityId = thisCity;
                        }
                    }
                }
            }

            // 如果战斗力最高的将领比战斗力最低的将领高，则进行调动
            if (maxBattlePower > minBattlePower)
            {
                country.ChangeGeneral(moveCityId, moveGeneralId, beCityId, beMoveId); // 调动将领
                return true;
            }

            return false;
        }


        /// <summary>
        /// AI判断相邻城市是否符合条件
        /// </summary>
        /// <returns></returns>
        bool AiJudCityFit()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // 获取当前回合的国家
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray();  // 获取敌方相邻城市ID数组
            byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray();  // 获取非敌方相邻城市ID数组
            byte byte1 = 0;

            // 检查相邻敌方城市是否符合条件
            for (byte byte3 = 0; byte3 < adjacentCity.Length; byte3++)
            {
                if ((this.k_byte_array1d_fld[adjacentCity[byte3]] & 0x2) == 2)  // 检查标志位是否为2
                    byte1 = 1;
            }

            // 如果没有相邻的敌方城市符合条件，则检查非敌方相邻城市
            if (byte1 == 0)
            {
                for (byte byte4 = 0; byte4 < noAdjacentCity.Length; byte4++)
                {
                    if ((this.k_byte_array1d_fld[noAdjacentCity[byte4]] & 0x2) == 2)  // 检查标志位是否为2
                        byte1 = 1;
                }
            }

            // 如果仍然没有符合条件的城市，返回false
            return byte1 != 0;
        }

        /// <summary>
        /// Ai判断是否有粮仓
        /// </summary>
        /// <returns></returns>
        bool haveGrainShop()
        {
            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // 获取当前回合的国家
            byte[] adjacentCity = country.GetEnemyAdjacentCityIdArray();  // 获取敌方相邻城市ID数组
            byte byte1 = 0;

            // 检查相邻敌方城市是否有粮仓
            for (byte byte3 = 0; byte3 < adjacentCity.Length; byte3++)
            {
                if ((this.k_byte_array1d_fld[adjacentCity[byte3]] & 0x8) == 8)  // 检查粮仓标志位
                    byte1 = 1;
            }

            byte[] noAdjacentCity = country.GetNoEnemyAdjacentCityIdArray();  // 获取非敌方相邻城市ID数组

            // 如果没有敌方城市有粮仓，则检查非敌方相邻城市
            if (byte1 == 0)
            {
                for (byte byte4 = 0; byte4 < noAdjacentCity.Length; byte4++)
                {
                    if ((this.k_byte_array1d_fld[noAdjacentCity[byte4]] & 0x8) == 8)  // 检查粮仓标志位
                        byte1 = 1;
                }
            }

            // 返回是否有粮仓
            return byte1 != 0;
        }

        // 根据给定的智力值查找将领
        short AiFindMostLeadEnemyGeneral(byte byte0)
        {
            short word0 = 0;
            int i1 = 0;

            // 遍历所有城市
            for (byte byte1 = 1; byte1 < CityListCache.CITY_NUM; byte1++)
            {
                byte k1 = byte1;

                // 判断城市是否不属于当前国家
                if (CityListCache.GetCityByCityId(k1).cityBelongKing != CountryListCache.GetCountryByCountryId(this.curTurnsCountryId).countryKingId)
                {
                    // 遍历该城市的所有将领
                    for (byte byte2 = 0; byte2 < CityListCache.GetCityByCityId(k1).getCityGeneralNum(); byte2++)
                    {
                        short word1 = CityListCache.GetCityByCityId(k1).getCityOfficeGeneralIdArray()[byte2];
                        General general = GeneralListCache.GetGeneral(word1);

                        // 筛选符合条件的将领
                        if (general.lead > i1 && general.getLoyalty() < 99 &&
                            (general.getLoyalty() <= 96 || general.IQ + 70 <= byte0) &&
                            (general.getLoyalty() <= 89 || general.IQ + 40 <= byte0) &&
                            general.IQ + 20 <= byte0)
                        {
                            word0 = word1;
                            i1 = general.lead;  // 更新当前最大的领导力
                        }
                    }
                }
            }
            return word0;
        }

        /// <summary>
        /// AI计算笼络将领的概率
        /// </summary>
        /// <param name="gohireId"></param>
        /// <param name="behireId"></param>
        /// <returns></returns>
        int AiBribeProbability(short gohireId, short behireId)
        {
            General beGeneral = GeneralListCache.GetGeneral(behireId);  // 获取被招揽的将领
            General goGeneral = GeneralListCache.GetGeneral(gohireId);  // 获取招揽的将领

            if (beGeneral.getLoyalty() == 100)  // 如果忠诚度为100，直接返回0
                return 0;

            short kingId = GetOfficeGenBelongKing(behireId);  // 获取被招揽将领所属的君主
            if (kingId <= 0)
            {
                Debug.Log("未找到" + beGeneral.generalName + "所属君主！");
                return 0;
            }

            short bepk = GeneralListCache.GetGeneral(kingId).phase;  // 被招揽将领的君主相性
            short pk = GeneralListCache.GetGeneral(GetOfficeGenBelongKing(gohireId)).phase;  // 招揽将领的君主相性

            int d1 = GetdPhase(bepk, beGeneral.phase);  // 计算相性差距
            int d2 = GetdPhase(pk, beGeneral.phase);    // 计算相性差距
            int d3 = GetdPhase(goGeneral.phase, beGeneral.phase);  // 招揽将领与被招揽将领的相性差距

            if (d1 == 0)
                return 0;
            if (d2 == 0)
                return 1000;

            int val = d1 - d2 - d3 * 2 + 100 - beGeneral.getLoyalty();  // 计算招揽成功的几率
            if (val > 0)
                return val * 20;

            // 随机数判断是否招揽成功
            if (CommonUtils.getRandomInt() % 120 < goGeneral.IQ - beGeneral.IQ)
                return (goGeneral.IQ - beGeneral.IQ) / 2;

            return 0;
        }

        /// <summary>
        /// Ai判断笼络操作
        /// </summary>
        /// <returns></returns>
        bool AiJudgeBribe()
        {
            short gohireId = 0;
            short behireId = 0;
            byte behireCity = 0;
            byte gohireCity = 0;
            int val = 0;

            Country country = CountryListCache.GetCountryByCountryId(this.curTurnsCountryId);  // 获取当前回合国家
            byte[] cityIds = country.GetCities();  // 获取该国家的所有城市

            // 遍历所有城市
            for (byte i = 1; i < CityListCache.CITY_NUM; i++)
            {
                City otherCity = CityListCache.GetCityByCityId(i);

                if (otherCity.cityBelongKing != country.countryKingId)  // 判断是否为敌方城市
                {
                    short[] otherOfficeGeneralIdArray = otherCity.getCityOfficeGeneralIdArray();

                    for (byte j = 0; j < cityIds.Length; j++)
                    {
                        City thisCity = CityListCache.GetCityByCityId(cityIds[j]);

                        if (thisCity.getCityGeneralNum() <= 9)  // 如果城市的将领数量不超过9
                        {
                            short[] thisOfficeGeneralIdArray = thisCity.getCityOfficeGeneralIdArray();

                            for (int k = 0; k < thisOfficeGeneralIdArray.Length; k++)
                            {
                                short thisGeneralId = thisOfficeGeneralIdArray[k];

                                for (int m = 0; m < otherOfficeGeneralIdArray.Length; m++)
                                {
                                    short otherGeneralId = otherOfficeGeneralIdArray[m];
                                    int per = AiBribeProbability(thisGeneralId, otherGeneralId);  // 计算招揽成功率

                                    if (per > 0)
                                    {
                                        General otherGeneral = GeneralListCache.GetGeneral(otherGeneralId);
                                        int curval = (otherGeneral.lead * 3 + otherGeneral.force + otherGeneral.IQ) * per;

                                        if (curval > val)
                                        {
                                            behireId = otherGeneralId;
                                            gohireId = thisGeneralId;
                                            behireCity = i;
                                            gohireCity = cityIds[j];
                                            val = curval;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (behireId == 0)
                return false;

            // 执行招揽操作
            if (behireId != 0 && gohireCity != 0 && gohireId != 0)
            {
                if (BribeRate(gohireId, behireId))  // 判断招揽成功
                {
                    AiBribe(gohireCity, behireCity, gohireId, behireId);
                    return true;
                }
                AiAlienate(behireCity, gohireId, behireId);  // 如果招揽失败，执行其他操作
                return true;
            }

            return false;
        }

        // 是否招揽
        bool AiJudgeEmploy(short word0, short word1)
        {
            // 如果将领忠诚度小于80，进行招揽
            if (GeneralListCache.GetGeneral(word1).getLoyalty() < 80)
                return AiEmploy(word0, word1);
            return false;
        }

        // 计算智力差异
        int CalculateIQDIfference(short word0, short word1)
        {
            byte byte0 = GeneralListCache.GetGeneral(word0).IQ;
            int i1 = GeneralListCache.GetGeneral(word1).IQ;
            byte byte1 = GeneralListCache.GetGeneral(word1).getLoyalty();

            if (byte1 > 99)
            {
                i1 = 10000; // 忠诚度极高时的特殊处理
            }
            else if (byte1 > 96)
            {
                i1 += 50; // 忠诚度大于96时增加额外值
            }
            else if (byte1 > 89)
            {
                i1 += 20; // 忠诚度大于89时增加额外值
            }

            return byte0 - i1; // 返回智力差值
        }

        /// <summary>
        /// 获取城市中德望最高的将领ID
        /// </summary>
        /// <param name="byte0"></param>
        /// <returns></returns>
        short GetMostMoralGeneralInCity(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short word0 = officeGeneralIdArray[0];
            byte byte1 = GeneralListCache.GetGeneral(word0).moral;

            // 遍历将领数组，找出德望最高的将领
            for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2++)
            {
                if (byte1 < GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]).moral)
                {
                    word0 = officeGeneralIdArray[byte2];
                    byte1 = GeneralListCache.GetGeneral(word0).moral;
                }
            }
            return word0;
        }

        /// <summary>
        /// 获取城市中智力和德望的综合最高将领ID
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short GetMostIQMoralGeneralInCity(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short generalId = officeGeneralIdArray[0];
            General general = GeneralListCache.GetGeneral(generalId);
            int i1 = general.IQ + general.moral / 2;

            // 遍历城市将领，计算出智力+德望的综合值最高的将领
            for (byte byte1 = 1; byte1 < city.getCityGeneralNum(); byte1++)
            {
                General otherGeneral = GeneralListCache.GetGeneral(officeGeneralIdArray[byte1]);
                if (i1 < otherGeneral.IQ + otherGeneral.moral / 2)
                {
                    generalId = officeGeneralIdArray[byte1];
                    i1 = otherGeneral.IQ + otherGeneral.moral / 2;
                }
            }
            return generalId;
        }

        /// <summary>
        /// 根据获取最适合搜索的将领
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="beGenId"></param>
        /// <returns></returns>
        short GetDoSearchGen(byte cityId, short beGenId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short generalId = officeGeneralIdArray[0];
            byte d = 100;

            // 遍历城市将领，找出与目标将领亲和度最低的将领
            for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2++)
            {
                short curId = officeGeneralIdArray[byte2];
                byte curd = (byte)GetdPhase(curId, beGenId);
                if (curd < d)
                {
                    generalId = officeGeneralIdArray[byte2];
                    d = curd;
                }
            }
            return generalId;
        }

        /// <summary>
        /// AI搜索将领招揽
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        void aiDoSearchGen(byte curTurnsCountryId)
        {
            // 随机50%几率进行搜索
            if (MathUtils.getRandomInt(100) < 50)
                return;

            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);

            // 遍历国家所有城市，寻找可以招揽的将领
            for (int index = 0; index < country.GetHaveCityNum(); index++)
            {
                byte curCityId = country.getCity(index);
                City city = CityListCache.GetCityByCityId(curCityId);
                if (city.getCityGeneralNum() < 10 && city.GetOppositionGeneralNum() > 0)
                {
                    short generalId = city.GetOppositionGeneralId((byte)(CommonUtils.getRandomInt() % city.GetOppositionGeneralNum()));
                    if (generalId > 0)
                    {
                        short employGeneralId = GetDoSearchGen(curCityId, generalId);
                        if (isEmploy(curCityId, employGeneralId, generalId))
                            return;
                    }
                }
            }

            // 再次遍历，处理剩余的招揽
            for (int byte1 = 0; byte1 < country.GetHaveCityNum(); byte1++)
            {
                byte curCityId = country.getCity(byte1);
                City city = CityListCache.GetCityByCityId(curCityId);
                if (city.GetOppositionGeneralNum() > 0)
                {
                    short generalId = GetMostIQMoralGeneralInCity(curCityId);
                    SearchOrder(curCityId, generalId);
                }
            }
        }

        // 招揽过程
        void AiDoSearchEmploy(byte byte0)
        {
            City city = CityListCache.GetCityByCityId(byte0);
            try
            {
                // 如果城市将领数量少于10，尝试进行招揽
                if (city.getCityGeneralNum() < 10 && city.GetOppositionGeneralNum() > 0)
                {
                    short behireId = city.GetOppositionGeneralId((byte)(CommonUtils.getRandomInt() % city.GetOppositionGeneralNum()));
                    if (behireId <= 0)
                        return;

                    short word0 = GetMostMoralGeneralInCity(byte0);
                    isEmploy(byte0, word0, behireId);
                }

                short word1 = GetMostIQMoralGeneralInCity(byte0);
                SearchOrder(byte0, word1);
            }
            catch (Exception exception)
            {
            Debug.Log(exception); // 捕获异常，防止程序崩溃
            }
        }


        /// <summary>
        /// AI获取城市中智力和政治综合能力最高的将领ID
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        short AiFindMostIQPoliticalGeneralInCity(byte cityId)
        {
            City city = CityListCache.GetCityByCityId(cityId);
            short[] officeGeneralIdArray = city.getCityOfficeGeneralIdArray();
            short generalId = officeGeneralIdArray[0];
            General general = GeneralListCache.GetGeneral(generalId);

            // 计算综合能力值 (智力 + 政治 * 2) / 3
            short byte1 = (short)((general.IQ + general.political * 2) / 3);

            // 遍历将领数组，找出综合能力值最高的将领
            for (byte byte2 = 1; byte2 < city.getCityGeneralNum(); byte2++)
            {
                General curGeneral = GeneralListCache.GetGeneral(officeGeneralIdArray[byte2]);
                short curVal = (short)((curGeneral.IQ + curGeneral.political * 2) / 3);
                if (byte1 < curVal)
                {
                    generalId = officeGeneralIdArray[byte2];
                    byte1 = curVal;
                    // 如果将领具备某些特技王佐屯田商才，能力值加倍
                    if (GetSkill_4(generalId, 0) || GetSkill_4(generalId, 2) || GetSkill_4(generalId, 3))
                        byte1 = (short)(byte1 * 2);
                }
            }
            return generalId;
        }

        // AI获取最佳治理将领
        short AIgetGenToXC(byte city)
        {
            short id = CityListCache.GetCityByCityId(city).getCityOfficeGeneralIdArray()[0];
            General general = GeneralListCache.GetGeneral(id);

            // 计算初始综合能力值 (智力 + 政治 * 2 + 德望 * 2) / 5
            int val = (general.IQ + general.political * 2 + general.moral * 2) / 5;

            // 遍历将领数组，找出综合能力值最高的将领
            for (byte index = 0; index < CityListCache.GetCityByCityId(city).getCityGeneralNum(); index++)
            {
                short curId = CityListCache.GetCityByCityId(city).getCityOfficeGeneralIdArray()[index];
                General curGeneral = GeneralListCache.GetGeneral(curId);
                int curVal = (curGeneral.IQ + curGeneral.political * 2 + curGeneral.moral * 2) / 5;

                // 如果将领具备某些特技，能力值加倍
                if (GetSkill_4(curId, 0) || GetSkill_4(curId, 1))
                    curVal *= 2;
                if (curVal > val)
                {
                    id = curId;
                    val = curVal;
                }
            }
            return id;
        }

        /// <summary>
        /// AI自动选择内政策略
        /// </summary>
        /// <param name="cityId"></param>
        void AutoInteriorLogic(byte cityId)
        {
            short generalId = AiFindMostIQPoliticalGeneralInCity(cityId);
            City city = CityListCache.GetCityByCityId(cityId);

            // 优先进行治水
            if (city.floodControl < 99)
            {
                AiTameOrder(cityId, generalId);
                return;
            }

            // 决定优先发展农业或贸易
            if (CommonUtils.getRandomInt() % 3 > 1)
            {
                if (city.agro < 999 && city.trade < 999)
                {
                    if (GameInfo.month < 4 || GameInfo.month >= 10)
                    {
                        AiMercantileOrder(cityId, generalId);
                    }
                    else
                    {
                        AiReclaimOrder(cityId, generalId);
                    }
                    return;
                }
                if (city.agro < 999)
                {
                    AiReclaimOrder(cityId, generalId);
                    return;
                }
                if (city.trade < 999)
                {
                    AiMercantileOrder(cityId, generalId);
                    return;
                }
            }

            // 人口未达上限则优先发展人口
            if (city.population < 990000)
            {
                generalId = AIgetGenToXC(cityId);
                AiPatrolOrder(cityId, generalId);
                return;
            }

            // 否则继续治水
            AiTameOrder(cityId, generalId);
        }

        /// <summary>
        /// AI计算并执行内政策略
        /// </summary>
        /// <param name="cityId"></param>
        void AiCalculateInterior(byte cityId)
        {
            int i = MathUtils.getRandomInt(13);
            short generalId = AiFindMostIQPoliticalGeneralInCity(cityId);
            City city = CityListCache.GetCityByCityId(cityId);

            // 城市资金不足时，优先选择特定策略
            if (city.GetMoney() < 50)
                i = 7;

            // 根据随机结果选择内政行动
            switch (i)
            {
                case 0:
                    if (city.floodControl < 99)
                        AiTameOrder(cityId, generalId);
                    break;
                case 1:
                    if (city.agro < 999)
                        AiReclaimOrder(cityId, generalId);
                    break;
                case 2:
                    if (city.trade < 999)
                        AiMercantileOrder(cityId, generalId);
                    break;
                case 3:
                case 4:
                    if (city.population < 990000)
                    {
                        generalId = AIgetGenToXC(cityId);
                        AiPatrolOrder(cityId, generalId);
                    }
                    break;
                case 5:
                case 6:
                    AiJudgeBribe(); // 执行特定行为
                    break;
                case 7:
                case 8:
                    AiDoSearchEmploy(cityId); // 执行招揽行动
                    break;
            }
        }

        /// <summary>
        /// Ai开始执行内政策略
        /// </summary>
        /// <param name="curTurnsCountryId"></param>
        void AiStartInterior(byte curTurnsCountryId)
        {
            Country country = CountryListCache.GetCountryByCountryId(curTurnsCountryId);
            byte cityId = 0;
            byte CITY_NUM = country.GetHaveCityNum();

            // 随机选择一个城市进行内政计算
            int index = CommonUtils.getRandomInt() % CITY_NUM;
            cityId = country.getCity(index);
            AiCalculateInterior(cityId);
        }

        /// <summary>
        /// 计算战争中人类将领的总能力值
        /// </summary>
        /// <param name="humanGeneralId_inWar"></param>
        /// <param name="humanGeneralNum_inWar"></param>
        /// <param name="abyte0"></param>
        /// <returns></returns>
        int GetTotalGeneralFightValInWar(short[] humanGeneralId_inWar, int humanGeneralNum_inWar, byte[] abyte0)
        {
            int j1 = 0;

            // 遍历参战的将领，计算符合条件的总能力值
            for (int index = 0; index < humanGeneralNum_inWar; index++)
            {
                if (abyte0[index] <= 0 || abyte0[index] >= 4)
                {
                    int k1 = SingleGeneralFightValue(humanGeneralId_inWar[index]);
                    j1 += k1;
                }
            }
            return j1;
        }

        /// <summary>
        /// 判断将领是否具备参与战争的条件
        /// </summary>
        /// <param name="i1"></param>
        /// <returns></returns>
        bool AiJudgeGeneralToWar(int i1)
        {
            // 检查是否满足基本条件
            if (!boolean_bsi_a(curWarCityId, this.aiKingId))
                return false;

            // 检查将领的士兵数量是否小于100
            return (GeneralListCache.GetGeneral(this.aiGeneralId_inWar[i1]).generalSoldier < 100);
        }


        /// <summary>
        /// 获取可以撤退的城市ID
        /// </summary>
        /// <param name="kingId"></param>
        /// <param name="canRetreatCityIdArray"></param>
        /// <param name="canRetreatNum"></param>
        /// <param name="curWarCity"></param>
        /// <returns></returns>
        byte getCanRetreatCityId(short kingId, byte[] canRetreatCityIdArray, byte canRetreatNum, byte curWarCity)
        {
            // 定义一个新的数组存储属于kingId的城市
            byte[] abyte1 = new byte[canRetreatNum];
            byte byte2 = 0;

            // 遍历可以撤退的城市ID数组，找出属于kingId的城市
            for (byte i = 0; i < canRetreatNum; i++)
            {
                if (CityListCache.GetCityByCityId(canRetreatCityIdArray[i]).cityBelongKing == kingId)
                {
                    abyte1[byte2] = canRetreatCityIdArray[i];
                    byte2++;
                }
            }

            // 如果找到了属于kingId的城市
            if (byte2 > 0)
            {
                byte x = 10; // 初始设置为最大将领数
                byte y = 0;
                byte mb = 0; // 最适合撤退的城市ID

                // 遍历找到的城市，选择将领数最少的城市
                for (byte b1 = 0; b1 < byte2; b1++)
                {
                    byte b3 = abyte1[b1];
                    byte generalNum = CityListCache.GetCityByCityId(b3).getCityGeneralNum();

                    // 排除当前战斗城市，找出将领数少于10且最小的城市
                    if (b3 != curWarCity && CityListCache.GetCityByCityId(b3).cityBelongKing == kingId && generalNum < 10 && generalNum < x)
                    {
                        x = generalNum;
                        mb = b3;
                        y++;
                    }
                }

                // 如果找到了合适的城市，返回该城市ID
                if (y > 0)
                    return mb;

                // 否则返回将领数量最多的城市
                byte cityId = abyte1[0];
                for (byte b2 = 1; b2 < byte2; b2++)
                {
                    if (CityListCache.GetCityByCityId(cityId).getCityGeneralNum() < CityListCache.GetCityByCityId(abyte1[b2]).getCityGeneralNum())
                        cityId = abyte1[b2];
                }
                return cityId;
            }

            // 如果没有找到属于kingId的城市，尝试找一个可以撤退的城市
            if (canRetreatNum > 0)
            {
                for (byte i = 0; i < canRetreatNum; i++)
                {
                    for (byte byte8 = 1; byte8 < CityListCache.CITY_NUM; byte8++)
                    {
                        if (byte8 != curWarCity && CityListCache.GetCityByCityId(byte8).cityBelongKing == kingId && CityListCache.GetCityByCityId(byte8).getCityGeneralNum() < 10)
                            return canRetreatCityIdArray[i];
                    }
                }
                // 随机返回一个城市ID
                return canRetreatCityIdArray[CommonUtils.getRandomInt() % canRetreatNum];
            }

            // 如果没有找到可以撤退的城市，返回0
            return 0;
        }

        /// <summary>
        /// AI判断是否撤退
        /// </summary>
        /// <returns></returns>
        bool aiGenchetui1()
        {
            // 判断当前将领的体力是否低于对方攻击造成的伤害
            if (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) + 1)
                return true;

            // 如果竞争失败则撤退
            return !IsSuccessOfCompetition();
        }


        /// <summary>
        /// AI判断是否撤退
        /// </summary>
        /// <returns></returns>
        bool aiGenchetui()
        {
            // 获取参与战斗的士兵数量，分别计算己方和敌方的数量
            short word0 = soldierInWarNum(true);  // 己方士兵数量
            short word1 = soldierInWarNum(false); // 敌方士兵数量

            // 获取己方士兵的初始坐标
            byte aix = this.smallSoldierCellX[1][0]; // AI士兵的X坐标
            byte aiy = this.smallSoldierCellY[1][0]; // AI士兵的Y坐标

            short canatkps = 0;  // 可攻击点数
            byte testx = 0;     // 测试用X坐标
            byte testy = 0;     // 测试用Y坐标

            try
            {
                // 遍历战场的每一个单元格，查找可以进行攻击的敌人
                for (byte celly = 0; celly < 7; celly++)
                {
                    for (byte cellx = 0; cellx < 16; cellx++)
                    {
                        testx = cellx;
                        testy = celly;

                        // 检查当前单元格是否有敌方士兵
                        if (this.smallWarCoordinate[celly][cellx] == 64)
                        {
                            byte dx = (byte)Math.Abs(aix - cellx); // X方向上的距离
                            byte dy = (byte)Math.Abs(aiy - celly); // Y方向上的距离
                            bool flag1 = false; // 判断是否可以攻击
                            bool flag2 = false; // 未使用的标志位

                            // 检查士兵种类和攻击条件（不同的攻击逻辑适用于不同的士兵种类）
                            if (this.coodinateSoldierKind[celly][cellx] == 2 && ((dx <= 6 && dy == 0) || dx == 0 || dx + dy <= 2))
                            {
                                // 处理dx >= 5 的情况并判断是否可以攻击
                                if (dx >= 5 && dx <= 6 && dy == 0 && (this.aa & 0xF0) == 48 && aix > cellx)
                                {
                                    for (int i = 1; i < dx; i++)
                                    {
                                        if (this.smallWarCoordinate[celly][cellx + i] == Byte.MinValue)
                                        {
                                            flag1 = false;
                                            break;
                                        }
                                        flag1 = true;
                                    }
                                }

                                // 其他条件的判断，具体逻辑类似，不同的dx和dy会触发不同的判断
                                if (dx <= 4 && dx >= 1 && dy == 0 && aix > cellx)
                                {
                                    if (aix > cellx + 1)
                                    {
                                        for (int i = 1; i < dx; i++)
                                        {
                                            if (this.smallWarCoordinate[celly][cellx + i] == Byte.MinValue)
                                            {
                                                flag1 = false;
                                                break;
                                            }
                                            flag1 = true;
                                        }
                                    }
                                    else if (aix == cellx + 1)
                                    {
                                        flag1 = true;
                                    }
                                }

                                // 其他方向上的判断
                                if (dx == 0)
                                {
                                    if (aiy > celly + 1)
                                    {
                                        for (int i = 1; i < dy; i++)
                                        {
                                            if (this.smallWarCoordinate[celly + i][cellx] == Byte.MinValue)
                                            {
                                                flag1 = false;
                                                break;
                                            }
                                            flag1 = true;
                                        }
                                    }
                                    else if (aiy < celly - 1)
                                    {
                                        for (int i = 1; i < dy; i++)
                                        {
                                            if (this.smallWarCoordinate[celly - i][cellx] == Byte.MinValue)
                                            {
                                                flag1 = false;
                                                break;
                                            }
                                            flag1 = true;
                                        }
                                    }
                                    else if (aiy == celly + 1 || aiy == celly - 1)
                                    {
                                        flag1 = true;
                                    }
                                }
                            }

                            // 类似的逻辑用于不同种类的士兵
                            else if (this.coodinateSoldierKind[celly][cellx] == 1 && dx + dy <= 2)
                            {
                                // 判断是否可以攻击的条件
                                if (aiy == celly && aix == cellx + 2 && this.smallWarCoordinate[aiy][aix - 1] != Byte.MinValue)
                                    flag1 = true;
                                if (aiy == celly && aix == cellx + 1)
                                    flag1 = true;
                                if (aiy == celly && aix == cellx - 2 && this.smallWarCoordinate[aiy][aix + 1] != Byte.MinValue)
                                    flag1 = true;
                                if (aiy == celly && aix == cellx + 1)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly + 2 && this.smallWarCoordinate[aiy + 1][aix] != Byte.MinValue)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly + 1)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly - 2 && this.smallWarCoordinate[aiy - 1][aix] != Byte.MinValue)
                                    flag1 = true;
                                if (aix == cellx && aiy == celly - 1)
                                    flag1 = true;
                            }

                            // 如果可以攻击，计算攻击点数
                            if (flag1)
                            {
                                short blood = 1;
                                short atk = 1;

                                // 遍历己方士兵列表，找到对应的士兵并计算其攻击点数
                                for (int hmindex = 0; hmindex < this.humanSmallSoldierNum; hmindex++)
                                {
                                    if (this.smallSoldier_isSurvive[0][hmindex] && this.smallSoldierCellX[0][hmindex] == cellx && this.smallSoldierCellY[0][hmindex] == celly)
                                    {
                                        if (this.smallSoldierKind[0][hmindex] == 0)
                                        {
                                            blood = 300;
                                            atk = this.smallSoldierAtk[0][0];
                                            break;
                                        }
                                        blood = this.smallSoldierBlood[0][hmindex];
                                        atk = this.smallSoldierAtk[0][hmindex];
                                        break;
                                    }
                                }
                                canatkps = (short)(canatkps + getshs(atk, this.smallSoldierDef[1][0], blood));
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                canatkps = 50; // 捕获异常，设置默认攻击点数
                Debug.LogError(e);
            }

            // 根据计算的攻击点数和当前AI将领的体力判断是否撤退
            if ((canatkps > GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() - 35 && canatkps > 0) || (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < 35 && word0 > 450 && word1 < 100 && this.W < 12))
                return true;

            // 判断是否需要执行"卖血保卫"策略
            if (maibebaowei(canatkps))
                return true;

            return false;
        }


        /// <summary>
        /// 计算伤害值
        /// </summary>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <param name="blood"></param>
        /// <returns></returns>
        short getshs(short atk, short def, short blood)
        {
            int gjl = atk; // 攻击力
            int fyl = def; // 防御力
            int F = blood / 20; // 血量因子
            float t1 = fyl / 150.0F; // 计算防御比例
            t1 *= d.hj[fyl - 1]; // 防御系数调整
            float sh = gjl * 1.0F / (1.0F + t1); // 计算基础伤害值
            if (blood < 200) // 如果血量低于200，伤害按比例调整
                sh = sh * blood / 200.0F;
            if (sh < F) // 伤害值不小于最低伤害值F
                sh = F;
            sh /= 6.0F; // 平均伤害值
            if (sh < 1.0F) // 伤害值不小于1
                sh = 1.0F;
            return (short)(int)sh;
        }

        /// <summary>
        /// AI行为控制
        /// </summary>
        /// <param name="truns"></param>
        void aifield(int truns)
        {
            byte x = this.smallSoldierCellX[1][0]; // AI士兵X坐标
            byte y = this.smallSoldierCellY[1][0]; // AI士兵Y坐标
            byte s0Num = 0; // 0血量的士兵数量
            byte s50Num = 0; // 血量大于等于50的士兵数量

            // 统计AI所有士兵的血量信息
            for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
            {
                if (this.smallSoldierBlood[1][index] > 0)
                    s0Num = (byte)(s0Num + 1);
                if (this.smallSoldierBlood[1][index] >= 50)
                    s50Num = (byte)(s50Num + 1);
            }

            // 如果W值大于等于12，则根据距离决定AI行为
            if (this.W >= 12)
            {
                byte hmX = this.smallSoldierCellX[0][0]; // 玩家士兵X坐标
                byte hmY = this.smallSoldierCellY[0][0]; // 玩家士兵Y坐标
                byte dx = (byte)(x - hmX); // X轴距离
                byte dy = (byte)Math.Abs(y - hmY); // Y轴距离

                // 如果AI与玩家士兵的距离符合条件，则减少W值并设置AI行动标志
                if (dx >= 1 && dx <= 3 && dy <= 1)
                {
                    this.W = (byte)(this.W - 12);
                    //this.gamecanvas.w_boolean_fld = true; // 设置布尔标志表示AI已经行动
                    this.ah = 40; // 设置行动后的状态
                }
                else
                {
                    byte canBoolNum = 0; // 可行动的格子数量

                    // 遍历战场上的所有格子，计算可以行动的格子数量
                    for (byte cellY = 0; cellY < 7; cellY = (byte)(cellY + 1))
                    {
                        for (byte cellX = 0; cellX < 16; cellX = (byte)(cellX + 1))
                        {
                            if (this.smallWarCoordinate[cellY][cellX] == 64)
                            {
                                byte dsx = (byte)(x - cellX);
                                byte dsy = (byte)Math.Abs(y - cellY);
                                if (dsx >= 1 && dsx <= 3 && dsy <= 1)
                                    canBoolNum = (byte)(canBoolNum + 1);
                            }
                        }
                    }

                    bool doBool = false; // 是否决定行动

                    // 根据血量大于等于50的士兵数量和可以行动的格子数量决定是否行动
                    if (s50Num <= 1 && canBoolNum >= 1)
                    {
                        doBool = true;
                    }
                    else if (s50Num <= 2 && canBoolNum >= 2)
                    {
                        doBool = true;
                    }
                    else if (canBoolNum >= 3)
                    {
                        doBool = true;
                    }

                    if (doBool)
                    {
                        this.W = (byte)(this.W - 12);
                        //this.gamecanvas.w_boolean_fld = true; // 设置布尔标志表示AI已经行动
                        this.ah = 40; // 设置行动后的状态
                    }
                }
            }

            // 获取AI和玩家战场中的士兵数量
            short word0 = soldierInWarNum(true);
            short word1 = soldierInWarNum(false);
            void_bv(); // 执行AI的辅助功能

            // 如果AI未设置撤退标志
            if (!this.l_boolean_fld)
            {
                // 设置所有AI士兵的行动指令为进攻
                for (byte byte1 = 0; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                    this.smallSoldierOrder[1][byte1] = 1;

                // 判断是否需要撤退
                if (word1 > word0 * 2 || word1 >= 350)
                {
                    this.l_boolean_fld = true; // 设置撤退标志
                }
                else
                {
                    HumanSoldierDetection(); // 执行AI的进攻逻辑
                }

                // 如果需要撤退，则将所有AI士兵的行动指令设置为防守
                if (this.l_boolean_fld)
                {
                    for (byte byte2 = 1; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                        this.smallSoldierOrder[1][byte2] = 0;
                }
            }

            int maxsh = 0; // 玩家最大伤害值

            // 计算玩家所有士兵的总伤害
            for (int j = 1; j < this.humanSmallSoldierNum; j++)
            {
                if (this.smallSoldier_isSurvive[0][j])
                {
                    int cursh = getshs(this.smallSoldierAtk[0][j], this.smallSoldierDef[1][0], this.smallSoldierBlood[0][j]);
                    maxsh += cursh;
                }
            }

            byte hm70Num = 0; // 血量大于等于100的玩家士兵数量
            for (int i = 1; i < this.humanSmallSoldierNum; i++)
            {
                if (this.smallSoldierBlood[0][i] >= 100)
                    hm70Num = (byte)(hm70Num + 1);
            }

            // 根据玩家当前状态和AI状态调整AI的策略
            if (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() - 35 > maxsh && (hm70Num < 3 || maxsh < 25) && !aiGenchetui1())
            {
                if (maibeSingleAtk2() && aiGenchetui1())
                {
                    this.smallSoldierOrder[1][0] = 1; // 进攻
                }
                else
                {
                    this.smallSoldierOrder[1][0] = 0; // 防守
                }
            }
            else
            {
                this.smallSoldierOrder[1][0] = 1; // 进攻
            }

            // AI撤退判断
            if (aiGenchetui())
                this.smallSoldierOrder[1][0] = 2;

            if ((aiGenchetui1() && word1 < 100) || (maibeSingleAtk() && aiGenchetui1()))
                this.smallSoldierOrder[1][0] = 2;

            // 如果AI能够单挑胜利且接近玩家士兵，则进行单挑
            if (canSingleWin() && canNearSingle())
                this.smallSoldierOrder[1][0] = 0;
        }

        /// <summary>
        /// 判断AI是否能够单挑获胜
        /// </summary>
        /// <returns></returns>
        bool canSingleWin()
        {
            if (GeneralListCache.GetGeneral(this.AIGeneralId).getCurPhysical() < getAtkDea(this.HMGeneralId, this.HMSingleAtk, this.AISingleDef) + 1)
                return false;
            if (IsSuccessOfCompetition())
                return true;
            return false;
        }

        /// <summary>
        /// 判断AI是否接近可以单挑的位置
        /// </summary>
        /// <returns></returns>
        bool canNearSingle()
        {
            byte aix = this.smallSoldierCellX[1][0]; // AI士兵X坐标
            byte aiy = this.smallSoldierCellY[1][0]; // AI士兵Y坐标
            byte hmx = this.smallSoldierCellX[0][0]; // 玩家士兵X坐标
            byte hmy = this.smallSoldierCellY[0][0]; // 玩家士兵Y坐标

            if (this.aq > 0) // 如果AQ值大于0，不允许单挑
                return false;

            // 判断AI是否可以接近玩家士兵
            if (aix > hmx)
            {
                if (aix - hmx == 2 && aiy == hmy && this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                    return true;
                if (aix - hmx == 1 && aiy - hmy == 1 && this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                    return true;
                if (aix - hmx == 1 && hmy - aiy == 1 && this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                    return true;
            }
            else if (aix == hmx)
            {
                if (Math.Abs(aiy - hmy) <= 2)
                    return true;
            }
            else
            {
                if (hmx - aix == 2 && hmy == aiy)
                    return true;
                if (hmx - aix == 1 && Math.Abs(aiy - hmy) <= 2)
                    return true;
            }
            return false;
        }


        // 检查是否能够使用卖贝保护
        bool maibebaowei(short hurt)
        {
            byte aix = this.smallSoldierCellX[1][0];
            byte aiy = this.smallSoldierCellY[1][0];
            bool flag = false;

            // 遍历战场坐标
            for (int celly = 0; celly < 7; celly++)
            {
                for (int cellx = 0; cellx < 16; cellx++)
                {
                    if (this.smallWarCoordinate[celly][cellx] == 64 && (this.coodinateSoldierKind[celly][cellx] == 0 || this.coodinateSoldierKind[celly][cellx] == 1))
                    {
                        // 检查是否在保护范围内
                        if (aix == cellx && Mathf.Abs(celly - aiy) == 1)
                        {
                            flag = true;
                            break;
                        }
                        if (cellx == aix + 1 && Mathf.Abs(celly - aiy) <= 2)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }

            General aiGeneral = GeneralListCache.GetGeneral(this.AIGeneralId);
            if (aiGeneral.getCurPhysical() - hurt - 15 < 0 && flag)
                return true;

            byte curps = aiGeneral.getCurPhysical();
            aiGeneral.decreaseCurPhysical((byte)hurt);
            if (aiGeneral.getCurPhysical() < 1)
                aiGeneral.setCurPhysical((byte)1);

            if (aiGenchetui1() && flag)
            {
                aiGeneral.setCurPhysical(curps);
                return true;
            }

            aiGeneral.setCurPhysical(curps);
            return false;
        }

        // 获取在战斗中的士兵数量
        short soldierInWarNum(bool ishm)
        {
            short num = 0;

            if (ishm)
            {
                for (byte index = 1; index < this.humanSmallSoldierNum; index = (byte)(index + 1))
                {
                    if (this.smallSoldier_isSurvive[0][index])
                        num = (short)(num + this.smallSoldierBlood[0][index]);
                }
            }
            else
            {
                for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
                {
                    if (this.smallSoldier_isSurvive[1][index])
                        num = (short)(num + this.smallSoldierBlood[1][index]);
                }
            }

            return num;
        }

        // AI 进行围攻
        void aiSiege(int turns)
        {
            byte x = this.smallSoldierCellX[1][0];
            byte y = this.smallSoldierCellY[1][0];
            byte s0Num = 0;
            byte s50Num = 0;

            // 统计 AI 小兵状态
            for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
            {
                if (this.smallSoldier_isSurvive[1][index])
                {
                    if (this.smallSoldierBlood[1][index] > 0)
                        s0Num = (byte)(s0Num + 1);
                    if (this.smallSoldierBlood[1][index] >= 50)
                        s50Num = (byte)(s50Num + 1);
                }
            }

            if (this.W >= 12)
            {
                byte hmX = this.smallSoldierCellX[0][0];
                byte hmY = this.smallSoldierCellY[0][0];
                byte dx = (byte)(x - hmX);
                byte dy = (byte)Mathf.Abs(y - hmY);

                if (dx >= 1 && dx <= 3 && dy <= 1)
                {
                    this.W = (byte)(this.W - 12);
                    //this.gamecanvas.w_boolean_fld = true;
                    this.ah = 40;
                }
                else
                {
                    byte canBoolNum = 0;
                    for (byte cellY = 0; cellY < 7; cellY = (byte)(cellY + 1))
                    {
                        for (byte cellX = 0; cellX < 16; cellX = (byte)(cellX + 1))
                        {
                            if (this.smallWarCoordinate[cellY][cellX] == 64)
                            {
                                byte dsx = (byte)(x - cellX);
                                byte dsy = (byte)Mathf.Abs(y - cellY);
                                if (dsx >= 1 && dsx <= 3 && dsy <= 1)
                                    canBoolNum = (byte)(canBoolNum + 1);
                            }
                        }
                    }

                    bool doBool = false;
                    if (s50Num <= 1 && canBoolNum >= 1)
                    {
                        doBool = true;
                    }
                    else if (s50Num <= 2 && canBoolNum >= 2)
                    {
                        doBool = true;
                    }
                    else if (canBoolNum >= 3)
                    {
                        doBool = true;
                    }

                    if (doBool)
                    {
                        this.W = (byte)(this.W - 12);
                        //this.gamecanvas.w_boolean_fld = true;
                        this.ah = 40;
                    }
                }
            }

            short hmsoldier = soldierInWarNum(true);
            short word0 = soldierInWarNum(false);
            aiCastleDefUseZhanshu();

            for (byte byte1 = 1; byte1 < this.aiSmallSoldierNum; byte1 = (byte)(byte1 + 1))
                this.smallSoldierOrder[1][byte1] = 0;
            this.smallSoldierOrder[1][0] = 1;

            byte aiAtcherNum = 0;
            for (byte aiIndex = 1; aiIndex < this.aiSmallSoldierNum; aiIndex = (byte)(aiIndex + 1))
            {
                if (this.smallSoldier_isSurvive[1][aiIndex] && this.smallSoldierKind[1][aiIndex] == 2)
                    aiAtcherNum = (byte)(aiAtcherNum + 1);
            }

            byte hmAtcherNum = 0;
            for (int hmIndex = 1; hmIndex < this.humanSmallSoldierNum; hmIndex++)
            {
                if (this.smallSoldier_isSurvive[0][hmIndex] && this.smallSoldierKind[0][hmIndex] == 2)
                    hmAtcherNum = (byte)(hmAtcherNum + 1);
            }

            if (hmAtcherNum >= 2 && aiAtcherNum <= 1)
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 3 && this.smallSoldierCellX[1][i] >= 8 && !sroundCanAtk(this.smallSoldierCellX[1][i], this.smallSoldierCellY[1][i]))
                        this.smallSoldierOrder[1][i] = 2;
                }

            if (word0 < 100 || aiGenchetui() || (maibeSingleAtk() && aiGenchetui1()))
                this.smallSoldierOrder[1][0] = 2;

            if (hmsoldier <= 100 && !aiGenchetui1())
                this.smallSoldierOrder[1][0] = 0;
        }


        // 检查给定坐标 (x, y) 是否可以被攻击
        bool sroundCanAtk(byte x, byte y)
        {
            if (x < 15 && x > 0)
            {
                if (y == 0)
                {
                    // 检查上、下、左右相邻坐标是否可攻击
                    if (this.smallWarCoordinate[y][x - 1] == 64 ||
                        this.smallWarCoordinate[y][x + 1] == 64 ||
                        this.smallWarCoordinate[y + 1][x] == 64)
                        return true;
                }
                else if (y == 6)
                {
                    // 检查上、下、左右相邻坐标是否可攻击
                    if (this.smallWarCoordinate[y][x - 1] == 64 ||
                        this.smallWarCoordinate[y][x + 1] == 64 ||
                        this.smallWarCoordinate[y - 1][x] == 64)
                        return true;
                }
                else
                {
                    // 检查上、下、左右相邻坐标是否可攻击
                    if (this.smallWarCoordinate[y][x - 1] == 64 ||
                        this.smallWarCoordinate[y][x + 1] == 64 ||
                        this.smallWarCoordinate[y - 1][x] == 64 ||
                        this.smallWarCoordinate[y + 1][x] == 64)
                        return true;
                }
            }
            return false;
        }

        // AI 防御围攻策略
        void aiDefSiege(int turns)
        {
            byte x = this.smallSoldierCellX[1][0];
            byte y = this.smallSoldierCellY[1][0];
            byte s0Num = 0;
            byte s50Num = 0;

            // 统计 AI 小兵的血量
            for (byte index = 1; index < this.aiSmallSoldierNum; index = (byte)(index + 1))
            {
                if (this.smallSoldierBlood[1][index] > 0)
                    s0Num = (byte)(s0Num + 1);
                if (this.smallSoldierBlood[1][index] >= 50)
                    s50Num = (byte)(s50Num + 1);
            }

            byte hmX = this.smallSoldierCellX[0][0];
            byte hmY = this.smallSoldierCellY[0][0];

            if (this.W >= 12)
            {
                byte dx = (byte)(x - hmX);
                byte dy = (byte)Mathf.Abs(y - hmY);

                if (dx >= 1 && dx <= 3 && dy <= 1)
                {
                    this.W = (byte)(this.W - 12);
                    //this.gamecanvas.w_boolean_fld = true;
                    this.ah = 40;
                }
                else
                {
                    byte canBoolNum = 0;

                    // 检查是否有可以攻击的范围
                    for (byte cellY = 0; cellY < 7; cellY = (byte)(cellY + 1))
                    {
                        for (byte cellX = 0; cellX < 16; cellX = (byte)(cellX + 1))
                        {
                            if (this.smallWarCoordinate[cellY][cellX] == 64)
                            {
                                byte dsx = (byte)(x - cellX);
                                byte dsy = (byte)Mathf.Abs(y - cellY);
                                if (dsx >= 1 && dsx <= 3 && dsy <= 1)
                                    canBoolNum = (byte)(canBoolNum + 1);
                            }
                        }
                    }

                    bool doBool = false;
                    if (s50Num <= 1 && canBoolNum >= 1)
                    {
                        doBool = true;
                    }
                    else if (s50Num <= 2 && canBoolNum >= 2)
                    {
                        doBool = true;
                    }
                    else if (canBoolNum >= 3)
                    {
                        doBool = true;
                    }

                    if (doBool)
                    {
                        this.W = (byte)(this.W - 12);
                        //this.gamecanvas.w_boolean_fld = true;
                        this.ah = 40;
                    }
                }
            }

            short hmSoldierNum = soldierInWarNum(true);
            short aiSoldierNum = soldierInWarNum(false);
            aiCastleDefUseZhanshu();

            // 初始化小兵订单
            for (byte byte2 = 0; byte2 < this.aiSmallSoldierNum; byte2 = (byte)(byte2 + 1))
                this.smallSoldierOrder[1][byte2] = 1;

            byte aiAtcherNum = 0;
            for (byte aiIndex = 1; aiIndex < this.aiSmallSoldierNum; aiIndex = (byte)(aiIndex + 1))
            {
                if (this.smallSoldier_isSurvive[1][aiIndex] && this.smallSoldierKind[1][aiIndex] == 2)
                    aiAtcherNum = (byte)(aiAtcherNum + 1);
            }

            byte hmAtcherNum = 0;
            for (int hmIndex = 1; hmIndex < this.humanSmallSoldierNum; hmIndex++)
            {
                if (this.smallSoldier_isSurvive[0][hmIndex] && this.smallSoldierKind[0][hmIndex] == 2)
                    hmAtcherNum = (byte)(hmAtcherNum + 1);
            }

            // 根据弓箭手的数量决定小兵的攻击策略
            if (hmAtcherNum >= 1 && aiAtcherNum <= 1)
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 3 && !sroundCanAtk(this.smallSoldierCellX[1][i], this.smallSoldierCellY[1][i]))
                        this.smallSoldierOrder[1][i] = 2;
                }

            if (getSkill_2(this.HMGeneralId, 6))
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 2)
                        this.smallSoldierOrder[1][i] = 0;
                }

            if (hmX >= 9)
                for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
                {
                    if (this.smallSoldier_isSurvive[1][i] && this.smallSoldierKind[1][i] == 2)
                        this.smallSoldierOrder[1][i] = 0;
                }

            if (aiAtcherNum == 0 && hmAtcherNum > 0)
                this.smallSoldierOrder[1][0] = 2;

            if ((aiSoldierNum < 100 && (hmSoldierNum > 450 || hmAtcherNum >= 1)) || aiGenchetui() || (maibeSingleAtk() && aiGenchetui1()))
                this.smallSoldierOrder[1][0] = 2;
        }


        // 判断是否可以单次攻击
        bool maibeSingleAtk()
        {
            byte aix = this.smallSoldierCellX[1][0];
            byte aiy = this.smallSoldierCellY[1][0];
            byte hmx = this.smallSoldierCellX[0][0];
            byte hmy = this.smallSoldierCellY[0][0];

            // 判断条件是否满足攻击
            if (aix > hmx)
            {
                if (aix - hmx == 2 && aiy == hmy && this.smallWarCoordinate[aiy][aix - 1] >= 0 && this.smallWarCoordinate[aiy][aix - 1] <= 16)
                    return true;
                if (aix - hmx == 1 && aiy == hmy)
                    return true;
                if (aix - hmx == 1 && aiy - hmy == 1 && this.smallWarCoordinate[aiy - 1][aix] >= 0 && this.smallWarCoordinate[aiy - 1][aix] <= 16)
                    return true;
                if (aix - hmx == 1 && hmy - aiy == 1 && this.smallWarCoordinate[aiy + 1][aix] >= 0 && this.smallWarCoordinate[aiy + 1][aix] <= 16)
                    return true;
            }
            else if (aix == hmx)
            {
                // 判断纵坐标差是否小于等于 2
                if (Mathf.Abs(aiy - hmy) <= 2)
                    return true;
            }
            else
            {
                if (hmx - aix == 2 && hmy == aiy)
                    return true;
                if (hmx - aix == 1 && Mathf.Abs(aiy - hmy) <= 2)
                    return true;
            }
            return false;
        }

        // 判断是否可以进行单次攻击（另一种情况）
        bool maibeSingleAtk2()
        {
            byte aix = this.smallSoldierCellX[1][0];
            byte aiy = this.smallSoldierCellY[1][0];
            byte hmx = this.smallSoldierCellX[0][0];
            byte hmy = this.smallSoldierCellY[0][0];

            // 判断曼哈顿距离是否小于等于 3
            if (Mathf.Abs(aix - hmx) + Mathf.Abs(aiy - hmy) <= 3)
                return true;
            return false;
        }

        // 计算弓箭手能攻击的数量
        void archerCanAtkNum()
        {
            byte aNum = 0; // 弓箭手数量
            byte longAtkNum = 0; // 长距离攻击数量
            byte longAtkaNum = 0; // 被长距离攻击的数量

            // 遍历所有小兵
            for (int index = 1; index < this.aiSmallSoldierNum; index++)
            {
                if (this.smallSoldier_isSurvive[1][index] && this.smallSoldierKind[1][index] == 2)
                {
                    aNum = (byte)(aNum + 1);
                    for (byte i = 1; i < 7;)
                    {
                        byte x = (byte)(this.smallSoldierCellX[1][index] - i);
                        byte y = this.smallSoldierCellY[1][index];
                        if (x < 0)
                            break;
                        if (this.smallWarCoordinate[y][x] == 64 && i >= 5)
                        {
                            longAtkNum = (byte)(longAtkNum + 1);
                        }
                        else
                        {
                            if (this.smallWarCoordinate[y][x] == 64)
                                break;
                            i = (byte)(i + 1);
                        }
                        for (int hmindex = 1; hmindex < this.humanSmallSoldierNum; hmindex++)
                        {
                            if (this.smallSoldier_isSurvive[0][hmindex] && this.smallSoldierCellX[0][hmindex] == x && this.smallSoldierCellY[0][hmindex] == y && this.smallSoldierKind[0][hmindex] == 2)
                                longAtkaNum = (byte)(longAtkaNum + 1);
                        }
                        break;
                    }
                }
            }

            // 判断是否可以进行攻击
            if (this.W < 8)
            {
                if (aNum > 0 && longAtkNum >= aNum / 3 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
            else
            {
                if (aNum > 1 && longAtkNum == aNum / 2 + 1)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
                if (aNum == 1 && longAtkNum >= aNum)
                {
                    this.W = (byte)(this.W - 7);
                    this.ab = 51;
                    return;
                }
            }
        }

        // 计算火焰攻击的数量
        byte fireAtk()
        {
            byte canAtkNum = 0;

            // 遍历所有小兵
            for (int index = 1; index < this.aiSmallSoldierNum; index++)
            {
                if (this.smallSoldier_isSurvive[1][index] && this.smallSoldierKind[1][index] == 2)
                {
                    byte x = this.smallSoldierCellX[1][index];
                    byte y = this.smallSoldierCellY[1][index];

                    // 检查上下左右的攻击范围
                    for (int d = 1; d < 5; d++)
                    {
                        if (x > d - 1)
                        {
                            byte hx = (byte)(this.smallSoldierCellX[1][index] - d);
                            byte hy = this.smallSoldierCellY[1][index];
                            if (this.smallWarCoordinate[hy][hx] == 64)
                            {
                                if (this.coodinateSoldierKind[hy][hx] == 2)
                                    canAtkNum = (byte)(canAtkNum + 1);
                                canAtkNum = (byte)(canAtkNum + 1);
                                break;
                            }
                        }
                        if (y > d - 1)
                        {
                            byte hx = this.smallSoldierCellX[1][index];
                            byte hy = (byte)(this.smallSoldierCellY[1][index] - d);
                            if (this.smallWarCoordinate[hy][hx] == 64)
                            {
                                if (this.coodinateSoldierKind[hy][hx] == 2)
                                    canAtkNum = (byte)(canAtkNum + 1);
                                canAtkNum = (byte)(canAtkNum + 1);
                                break;
                            }
                        }
                        if (y < 7 - d)
                        {
                            byte hx = this.smallSoldierCellX[1][index];
                            byte hy = (byte)(this.smallSoldierCellY[1][index] + d);
                            if (this.smallWarCoordinate[hy][hx] == 64)
                            {
                                if (this.coodinateSoldierKind[hy][hx] == 2)
                                    canAtkNum = (byte)(canAtkNum + 1);
                                canAtkNum = (byte)(canAtkNum + 1);
                                break;
                            }
                        }
                    }
                }
            }
            return canAtkNum;
        }


        // 计算可以进行纳汉攻击的数量
        byte defNaHanAtk()
        {
            byte canAtkNum = 0;

            // 遍历所有小兵
            for (int index = 0; index < this.aiSmallSoldierNum; index++)
            {
                if (this.smallSoldier_isSurvive[1][index])
                {
                    byte x = this.smallSoldierCellX[1][index];
                    byte y = this.smallSoldierCellY[1][index];

                    // 判断小兵类型，并检查其周围是否有可攻击的目标
                    if (this.smallSoldierKind[1][index] == 0 || this.smallSoldierKind[1][index] == 1 || this.smallSoldierKind[1][index] == 3)
                    {
                        if (x > 0 && this.smallWarCoordinate[y][x - 1] == 64)
                        {
                            if (this.coodinateSoldierKind[y][x - 1] == 2)
                                canAtkNum = (byte)(canAtkNum + 1);
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y > 0 && this.smallWarCoordinate[y - 1][x] == 64)
                        {
                            if (this.coodinateSoldierKind[y - 1][x] == 2)
                                canAtkNum = (byte)(canAtkNum + 1);
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                        else if (y < 6 && this.smallWarCoordinate[y + 1][x] == 64)
                        {
                            if (this.coodinateSoldierKind[y + 1][x] == 2)
                                canAtkNum = (byte)(canAtkNum + 1);
                            canAtkNum = (byte)(canAtkNum + 1);
                        }
                    }
                    else
                    {
                        // 检查小兵周围的长距离攻击范围
                        for (int d = 1; d < 5; d++)
                        {
                            if (x > d - 1)
                            {
                                byte hx = (byte)(this.smallSoldierCellX[1][index] - d);
                                byte hy = this.smallSoldierCellY[1][index];
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    if (this.coodinateSoldierKind[hy][hx] == 2)
                                        canAtkNum = (byte)(canAtkNum + 1);
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y > d - 1)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] - d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    if (this.coodinateSoldierKind[hy][hx] == 2)
                                        canAtkNum = (byte)(canAtkNum + 1);
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                            if (y < 7 - d)
                            {
                                byte hx = this.smallSoldierCellX[1][index];
                                byte hy = (byte)(this.smallSoldierCellY[1][index] + d);
                                if (this.smallWarCoordinate[hy][hx] == 64)
                                {
                                    if (this.coodinateSoldierKind[hy][hx] == 2)
                                        canAtkNum = (byte)(canAtkNum + 1);
                                    canAtkNum = (byte)(canAtkNum + 1);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return canAtkNum;
        }

        // AI 城堡防御使用战术
        void aiCastleDefUseZhanshu()
        {
            byte unitNum = 0; // 小兵数量
            byte actherNum = 0; // 弓箭手数量

            // 统计存活的小兵数量和弓箭手数量
            for (byte i = 1; i < this.aiSmallSoldierNum; i = (byte)(i + 1))
            {
                if (this.smallSoldier_isSurvive[1][i])
                {
                    unitNum = (byte)(unitNum + 1);
                    if (this.smallSoldierKind[1][i] == 2)
                        actherNum = (byte)(actherNum + 1);
                }
            }

            // 根据不同条件选择战术
            if (this.W >= 10)
            {
                byte fireNum = fireAtk();
                if (fireNum >= actherNum / 3 + 1)
                {
                    this.W = (byte)(this.W - 10);
                    this.ab = 83;
                    return;
                }
                if (fireNum >= 2 && actherNum <= 2)
                {
                    this.W = (byte)(this.W - 10);
                    this.ab = 83;
                    return;
                }
                if (fireNum == 1 && actherNum == 1)
                {
                    this.W = (byte)(this.W - 10);
                    this.ab = 83;
                    return;
                }
            }
            else if (this.W >= 8)
            {
                byte nahanNum = defNaHanAtk();
                if (nahanNum >= unitNum / 3 + 1 && unitNum >= 3)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
                aatkNum();
                if (this.W >= 8 && nahanNum >= unitNum / 2 + 1 && unitNum >= 2)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
                if (this.W >= 8 && nahanNum >= unitNum && unitNum >= 1)
                {
                    this.W = (byte)(this.W - 8);
                    this.ab = 68;
                    return;
                }
            }
            else if (this.W >= 7)
            {
                aatkNum();
            }
        }

        // AI 单次指令
        byte AISingleOrder(short aigeneralId, short hmgeneralId)
        {
            // 判断是否可以进行攻击
            if (singlePin(aigeneralId, hmgeneralId, this.AISingleAtk, this.HMSingleDef) >= GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical())
                return 0;
            if (getAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) >= GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical())
                return 1;
            if (GeneralListCache.GetGeneral(aigeneralId).getCurPhysical() < 20 || getAtkDea(hmgeneralId, this.HMSingleAtk, this.AISingleDef) >= GeneralListCache.GetGeneral(aigeneralId).getCurPhysical())
                return 4;
            if (GeneralListCache.GetGeneral(aigeneralId).getCurPhysical() > 35 && getPercentage(aigeneralId, hmgeneralId, true, false) >= 30 && getAllAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) >= GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical() && getAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) + 5 < getAtkDea(hmgeneralId, this.HMSingleAtk, this.AISingleDef) && GeneralListCache.GetGeneral(aigeneralId).getCurPhysical() + 10 < GeneralListCache.GetGeneral(hmgeneralId).getCurPhysical() && getPercentage(aigeneralId, hmgeneralId, true, false) >= CommonUtils.getRandomInt() % 40)
                return 2;
            int qw = getPercentage(aigeneralId, hmgeneralId, false, false) * getAtkDea(aigeneralId, this.AISingleAtk, this.HMSingleDef) / 100;
            if (qw > singlePin(aigeneralId, hmgeneralId, this.AISingleAtk, this.HMSingleDef) + 1)
                return 1;
            return 0;
        }


    
    }


