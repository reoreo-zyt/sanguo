extends Node

# 默认文本提示
var current_message_title = '黄巾之乱'

# 文本说明
var text_message = {
	"中平六年": "中平（184年农历12月29日—189年农历4月12日）是东汉皇帝汉灵帝刘宏的第四个年号，同时也是汉献帝刘协的第二个年号。汉朝使用这个年号时间共记6年。",
	"黄巾之乱": "黄巾之乱，又称黄巾起义、黄巾民变，是中国历史上东汉灵帝时的大规模民变，也是中国历史上大规模的以宗教形式（太平道）组织的起义之一，开始于汉灵帝光和七年（184年），由张角、张宝、张梁等人领导，对东汉朝廷的统治产生了巨大的冲击。汉末三国时期一干著名诸侯群雄几乎全部都有直接、间接参与讨伐黄巾军。同时，此战亦造成各地诸侯拥兵自重，割据一方，间接促成汉朝灭亡与三国时代的开始。",
	"诸侯": "诸侯国，狭义上主要是指中国历史对封地的称呼，也被称为“诸侯列国”、“列国”、“封国”或“侯国”；封地君主最高统治者被赐与“诸侯”的封号。广义上指封建时代（封建社会）及其以前人类文明时期共主（天子）对其家族、功臣给予的封地，直至宣统退位以后，中华民国北洋政府取消世爵。",

	"十常侍": "十常侍泛指中国古代东汉灵帝时期（168年－189年在位）操弄政权的张让、赵忠、夏恽、郭胜、孙璋、毕岚、栗嵩、段珪、高望、张恭、韩悝、宋典等十二位宦官，他们因任职中常侍（黄门常侍）被后代史书称十常侍。其中以张让、赵忠最为受宠于灵帝，灵帝亦说：“张常侍是我公，赵常侍是我母。”",
	"何进": "何进（？—189年9月22日），字遂高，南阳宛县（今河南省南阳市）人，东汉末年外戚，官至大将军，录尚书事，封慎侯。何进为了对付十常侍而召董卓率军队入京，成为东汉末年直至三国割据的重要事件之一，而自己也被十常侍杀死。",
	"汉灵帝": "汉灵帝刘宏（156年—189年5月13日），东汉第十二位皇帝（168年2月17日－189年5月13日在位），在位22年，葬于汉文陵，其正式谥号为“孝灵皇帝”，后世省略“孝”字称“汉灵帝”。灵帝是东汉最后一个握有实权的皇帝。",
	"袁绍": "袁绍（？—202年6月28日），字本初，汝南郡汝阳县（今河南省商水县）人，为东汉末年割据势力之一。曾带兵进宫诛杀十常侍，后被各路诸侯推举为盟主讨伐董卓。在易京之战击败公孙瓒后，其势力达到巅峰；极盛时期据有冀州、幽州、并州、青州等河朔四州，官至大将军，使其一度成为东汉末年实力最强的诸侯。但在官渡之战惨败给曹操而受到重挫，接着在仓亭之战再败给曹军，不久后就病逝。",
	"刘辩": "汉少帝刘辩（176年—190年3月6日，熹平五年－初平元年正月十二癸丑日），中国汉朝皇帝（光熹元年四月十三戊午日至昭宁元年九月初一甲戌日，即公元189年5月15日－189年9月28日在位）。他是东汉第十三位、亦即倒数第二位皇帝，是汉灵帝刘宏与皇后何氏的独生儿子，即是嫡长子，后遭董卓废黜。刘辩在灵帝驾崩后继位为帝，由于年幼，实权掌握在临朝称制的母亲何太后和母舅大将军何进手中。少帝在位时期，东汉政权已经名存实亡，他即位后不久即遭遇以何进为首的外戚集团火并以十常侍为首的内廷宦官集团，为了避祸被迫出宫，回宫后又受制于以“勤王”为名进京的西北军阀董卓，之后被废为弘农王，成为东汉唯一一位被废黜的皇帝，其同父异母弟陈留王刘协继位为帝，是为汉献帝。被废黜一年之后，刘辩在董卓胁迫下自尽，时年仅十五岁[1]，其弟献帝追谥他为怀王。华夏史书称刘辩为皇子辩、少帝和弘农王等，但因为刘辩在位不逾年，一般不视其作正统皇帝，不单独为他撰写专属于帝王的传记（即本纪），不过现代史学界也有观点承认他是汉朝皇帝。",
	"刘协": "汉献帝刘协（181年4月2日[1]—234年4月21日），字伯和，是汉朝第29任皇帝（东汉第14任），189年至220年在位，为东汉的统治者。曹魏给其谥号为“孝献皇帝”，后世省略“孝”字称“汉献帝”。蜀汉给其上谥号为“孝愍皇帝”。献帝在位时，东汉王朝基本上已经名存实亡，帝国疆域内群雄割据，天子亦受权臣控制，是中国史上一段极度不安定的时期。",
	"何太后": "灵思皇后（176年前—189年9月30日），何姓，真名失传。东汉灵帝第二任皇后。何进异母妹，何苗同母妹。另有一妹为张让儿媳（或为张奉妻）。",
	"董卓": "董卓（2世纪—192年5月22日），字仲颖，凉州陇西临洮（今甘肃岷县）人，东汉与羌的战争中崛起的汉军将领。董卓长期参与汉羌战争，先后跟过张奂、段颎两位汉军高级将领。董卓于汉灵帝时代担任并州刺史，河东太守，军衔至中郎将。受汉大将军何进调令进军东汉首都洛阳以胁迫十常侍，在十常侍与何进火拼并同时死亡的情况下利用手中军队独霸汉廷。之后废汉少帝刘辩为弘农王，立陈留王刘协为帝（即汉献帝），并自封为东汉太尉、相国，引致董卓讨伐战。后来联军发生内哄，转而成为各军阀互相争战的情况。董卓本人则被王允、吕布设计诛杀，死后部下李傕和郭汜两人为了把持朝政互相火拼，皇帝与朝廷流离失所，各地州牧、刺史、太守占据属地完全脱离中央控制，开启东汉末年以至三国时代。",
	"周毖": "周毖（？—190年），又作周珌，字仲远，武威郡姑臧人，《英雄记》作武威人。豫州刺史周慎之子。董卓当权时，与伍琼一起为董卓信任，以周毖为吏部尚书，多次向董卓推举韩馥、刘岱、孔伷、张咨、张邈等人出宰州郡。但这些人后来都反过来讨伐董卓，董卓欲迁都长安，太尉黄琬、司徒杨彪力争不可，周毖、伍琼又出来劝谏。董卓因此大怒曰：“卓初入朝，二子劝用善士，故相从，而诸君到官，举兵相图。此二君卖卓，卓何用相负！”遂斩伍琼、周毖。",
	"伍琼": "伍琼（？—190年），字德瑜，汝南（今河南驻马店市汝南县）人，东汉城门校尉。",
	"曹操": "曹操（155年—220年3月15日），曹嵩之子，字孟德，一名吉利，小字阿瞒，沛国谯县（今安徽亳州）人。东汉末年丞相、外戚、军事家、政治家、文学家和诗人，东汉末年主要群雄之一，为汉末实际上的最高掌权者，亦是三国时代曹魏奠基者。其子曹丕建立曹魏，追尊其庙号为太祖，追谥武皇帝。",
	"刘备": "汉昭烈帝刘备（161年—223年6月10日），字玄德，涿郡涿县（今河北省涿州市）人，亦称蜀先主，是三国时代蜀汉的开国皇帝，在位三年。谥号昭烈皇帝，庙号烈祖。刘备与同宗刘德然、辽西人公孙瓒一起拜卢植为师学习。东汉末年起兵参与镇压黄巾军。后颠沛流离，多次转投他人门下，先后依附于公孙瓒、陶谦、曹操、袁绍、刘表等人。后“三顾茅庐”请诸葛亮出山，开始在众多军阀中崭露头角。208年，刘备遣诸葛亮向南与孙权联合，促成孙刘联军，于赤壁大败曹操。战后占领荆州之地，实力逐渐雄厚。后得张松献图，进军益州成功，并北上夺取汉中，呈现三足鼎立之势。219年自立为“汉中王”。221年，刘备在成都称帝，国号汉，建元章武，史称“蜀汉”，占有今重庆、四川、云南大部、贵州全部、陕西汉中和甘肃白龙江一部分。然而此前吕蒙袭取荆州、诛杀关羽，使其称帝后兴兵孙吴，但大败而归，损耗大量国力。223年，刘备病逝白帝城，终年六十三岁，葬于惠陵，其子刘禅即位。刘备虽为汉景帝后代，但世系久远，实由布衣起步而终得一方天下。",
	"丁原": "丁原（140年？—189年），字建阳，东汉末年的地方豪杰之一，被董卓设计由其部将吕布刺杀。拜武猛都尉，并州刺史，官至执金吾。",
	"吕布": "吕布（不晚于161年—199年2月7日），字奉先，并州五原郡九原（今内蒙古自治区包头市九原区）人，东汉末年武将与军阀，被封为温侯。先后为丁原、董卓的部将，也曾为袁绍效力，后趁刘备与袁术交战时而占据徐州，自成一方势力。建安三年十二月（199年2月7日），在下邳被曹操击败处死。",
	"荀爽": "荀爽（128年—190年），一名谞，字慈明，颍川颍阴（今河南许昌）人，荀淑第六子，东汉末大臣、政论家，经学家，在兄弟中最为有名，有“荀氏八龙，慈明无双”之称，亦以95日“白衣登三公”而闻名。其易学思想被称为“荀氏易学”。",
	"陈纪": "陈纪 (东汉)，东汉名士陈寔之子，曹魏重臣陈群之父。在东汉官至大鸿胪。",
	"刘岱": "刘岱 (兖州刺史)，东汉兖州刺史",
	"张邈": "张邈（？—195年），字孟卓，东汉末期政治人物，兖州东平郡寿张县（今山东东平）人。",
	"张咨": "张咨（？—190年），字子议，东汉末年人物，南阳郡太守。",
	
	"凉州武威": "武威市，中华人民共和国甘肃省下属的地级市，市政府驻凉州区，位于西北地区中部，河西走廊东端，有“天下要冲”，“国家蕃卫”之称。古称凉州、姑臧，是国家历史文化名城，河西四郡之一，前凉、后凉、南凉、北凉、大凉和西夏（夏神宗）均曾建都于此，故称“西北首府”，“六朝古都”。",
	"凉州金城": "金城郡，中国古郡名。西汉始元六年（前81年）置。西汉末年其辖境大致相当于今甘肃省兰州市、青海省西宁市、海东市一带，属凉州刺史部。",
	"凉州武都": "两汉之际，武都郡为公孙述所据。东汉前期，罢平乐道、嘉陵道、循成道三道，郡治移至下辨县（县治在今甘肃省成县西北），改属凉州刺史部。安帝永初五年（111年），陇西郡羌道别属武都郡。顺帝永和五年（140年），武都郡有20102户，81728人。汉末，曹操分司州、凉州置雍州，武都郡改属雍州。献帝建安二十四年（219年），刘备攻取了曹操控制下的汉中郡，阻碍了武都与雍州的联系，曹操遂迁武都郡的人口于右扶风小槐里。后来蜀汉于建威之战稳定掌握武都郡。",

	# 原版特技
	"看破": "对方计策成功率减少",
	"鬼谋": "计策范围增加一格",
	"百出": "计策消耗机动力-2",
	"深谋": "计策成功后伤害1.5倍",
	"火神": "火计、劫火成功率增加且伤害2倍",
	"神算": "全计策成功率增加，对方计策成功率减少",
	"反计": "对方计策不成功，某些计策可以反作用于对方",
	"待伏": "伏兵范围增加一格，成功率增加",
	"袭粮": "劫粮、烧粮成功率增加，范围增加一格",
	"内讧": "共杀、水攻成功率增加，范围增加一格",
	"骑神": "骑兵攻击33%概率暴击",
	"骑将": "骑兵攻击20%概率暴击",
	"弓神": "弓兵攻击33%概率暴击",
	"弓将": "弓兵攻击20%概率暴击",
	"水神": "水战全军攻击15%概率暴击（概率可以与弓神或弓将加成）",
	"乱战": "树林、森林攻击全军15%概率暴击（概率可以与弓神或弓将，骑神或骑将加成）",
	"连弩": "弓箭攻击射程为增加1格（非连弩情况下），连弩战术后再增加2格",
	"金刚": "对方攻击微弱时33%概率伤害为0",
	"不屈": "小兵单位血量小于50时，受对方攻击33%概率伤害为0",
	"猛将": "武将攻击小兵33%概率暴击",
	"单骑": "武将攻击小兵50%概率暴击，没兵撤退低概率减少少量体力",
	"奇袭": "部队主动攻击士兵攻防增加15%，对方守城无效",
	"铁壁": "部队被动攻击士兵攻防增加15%，守城时无效",
	"攻城": "攻城时士兵攻防增加20%",
	"守城": "守城时士兵攻防增加20%",
	"强行": "部队经过山地、树林、森林消耗机动力减少",
	"攻心": "小战场战斗结束后20%概率把对方的三分之一伤害变成我方士兵，本方战败无效（模拟战无效）",
	"军神": "全地形士兵攻防增加25%（可以与奇袭、铁壁叠加，无军魂效果叠加）",
	"军魂": "本方部队士兵攻防增加20%，周围己方部队攻防增加15%（可以与奇袭、铁壁叠加；不可与攻城、守城叠加）",
	"兵圣": "士兵受到的伤害减半",
	"王佐": "全内政效果增加",
	"仁政": "巡查效果增加",
	"屯田": "开垦效果增加",
	"经商": "劝商效果增加",
	"眼力": "搜索必定搜索到钱或粮或宝物，搜索到的量增加（有在野武将必定搜索到）",
	"风水": "武将所在城池金钱、粮食收入增加",
	"义军": "武将所在城池每个月增加一定量的士兵",
	"神医": "武将所在城池每个月城池受伤的武将体力恢复增加",
	"仁义": "武将所在城池每个月城池中忠诚未满的武将忠诚增加",
	"抢运": "武将所在城池往其他城池运送物资不需要消耗指令",

	# 新增特技
	"仁德": "",
	"枭雄": "",
	"四世三公": "",
	"小霸王": "",
	"酒池肉林": "",
	"宽柔无威": "",
	"勇冠四州": "",
	"经汤莫若": "",
	"忠义尽节": "",
	"马超八健将": ""
}

######### 武器
# name 武器名称
#########
var weapons = {
	"002e7d6a-c5f3-8ebf-2694-6b032a458a26": {
		"name": "短剑",
	},
	"aec2aab0-9203-bd96-22ed-76df286ccd83": {
		"name": "矛",
	},
	"0172a8c4-56fc-5f6e-c2c7-6a49d1f4f978": {
		"name": "雌雄双股剑",
	},
	"716f6a59-c241-0f0e-831f-ed8eb2cf107b": {
		"name": "青钢剑",
	},
	"8bc8766e-804f-770d-281a-600b7bcbebcb": {
		"name": "倚天剑",
	},
	"cb670c15-b222-f01c-9fa7-6173826f77c0": {
		"name": "龙牙刀"
	},
	"e7911e0f-5360-0b88-785e-be47f99f4680": {
		"name": "七星剑"
	}
}

######### 防具
# name 防具名称
#########
var armors = {
	"9758bc13-633b-b16f-adf4-37003b972b85": {
		"name": "龙鳞宝铠",
	},
	"dceaf567-ca94-2a19-01d9-efbb9844ffc6": {
		"name": "甲胄",
	},
	"c1a0342c-4bce-79ef-8425-285723a9b6fa": {
		"name": "硬皮"
	},
	"b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649": {
		"name": "兜"
	},
	"b06f5ac3-d5e6-32f6-90c4-659c0e78fd0e": {
		"name": "纶巾"
	}
}

var skills = {
	"98473e88-f758-7d97-45b6-0bff7c7373a0": {
		"name": "看破",
		"desc": text_message["看破"],
		"type": "normal",
	},
	"4f3b8a53-42e5-2f84-48a4-7f663232417c": {
		"name": "鬼谋",
		"desc": text_message["鬼谋"],
		"type": "normal",
	},
	"58ef4952-9076-e050-1268-4891f9def91d": {
		"name": "百出",
		"desc": text_message["百出"],
		"type": "normal",
	},
	"9ea2890f-47cf-c9c6-00a4-5218d675dae6": {
		"name": "深谋",
		"desc": text_message["深谋"],
		"type": "normal",
	},
	"b6fc8337-540c-b6df-343e-b99057d3199c": {
		"name": "火神",
		"desc": text_message["火神"],
		"type": "normal",
	},
	"3b745eaa-bd2b-58bc-f96a-1d0dbbb34952": {
		"name": "神算",
		"desc": text_message["神算"],
		"type": "normal",
	},
	"c0442188-804e-0ca5-f31b-60385a5fdcf6": {
		"name": "反计",
		"desc": text_message["反计"],
		"type": "normal",
	},
	"37529850-a031-9185-c890-8b6b7c7ef4be": {
		"name": "待伏",
		"desc": text_message["待伏"],
		"type": "normal",
	},
	"be437047-2f70-655e-5a15-25d0f1965db8": {
		"name": "袭粮",
		"desc": text_message["袭粮"],
		"type": "normal",
	},
	"62fec892-6287-ffc9-3ace-345fd50c18a3": {
		"name": "内讧",
		"desc": text_message["内讧"],
		"type": "normal",
	},
	"59b93b98-5c9a-5a2a-acca-3574e09e1239": {
		"name": "骑神",
		"desc": text_message["骑神"],
		"type": "normal",
	},
	"7e1823d0-f790-5fb1-d171-81fb6d7ca747": {
		"name": "骑将",
		"desc": text_message["骑将"],
		"type": "normal",
	},
	"846eb914-4e0e-3e73-b044-440f5fdc8765": {
		"name": "弓神",
		"desc": text_message["弓神"],
		"type": "normal",
	},
	"8ae0e098-dd48-a7f1-b7b6-7346abe47051": {
		"name": "弓将",
		"desc": text_message["弓将"],
		"type": "normal",
	},
	"0a0f2128-32cb-7992-f419-18f2d3cc6717": {
		"name": "水神",
		"desc": text_message["水神"],
		"type": "normal",
	},
	"71ee42eb-ffd4-fe3c-b52e-f57db580909e": {
		"name": "乱战",
		"desc": text_message["乱战"],
		"type": "normal",
	},
	"fc2dac9d-bdf5-514b-c15b-5a9934189089": {
		"name": "连弩",
		"desc": text_message["连弩"],
		"type": "normal",
	},
	"a091a2c4-2033-3c31-d86c-27866f38e90d": {
		"name": "金刚",
		"desc": text_message["金刚"],
		"type": "normal",
	},
	"d50438b5-166d-2968-5b41-59ebe08099fb": {
		"name": "不屈",
		"desc": text_message["不屈"],
		"type": "normal",
	},
	"88752da3-9ce2-7ffb-318d-fa9a8a55732b": {
		"name": "猛将",
		"desc": text_message["猛将"],
		"type": "normal",
	},
	"a58964fe-b462-4265-74f5-e7a3f60b5d80": {
		"name": "单骑",
		"desc": text_message["单骑"],
		"type": "normal",
	},
	"997c2db0-2dec-a7d4-5923-75b7f9f5c500": {
		"name": "奇袭",
		"desc": text_message["奇袭"],
		"type": "normal",
	},
	"1b967567-4d0b-4922-84f9-bb7d94023790": {
		"name": "铁壁",
		"desc": text_message["铁壁"],
		"type": "normal",
	},
	"976bce1c-7f84-0fad-f6f5-57f133e80766": {
		"name": "攻城",
		"desc": text_message["攻城"],
		"type": "normal",
	},
	"a38e9043-4ce9-e5d0-7113-bdde3546ec30": {
		"name": "守城",
		"desc": text_message["守城"],
		"type": "normal",
	},
	"4712053d-3587-bf76-8e9c-abf692f69555": {
		"name": "强行",
		"desc": text_message["强行"],
		"type": "normal",
	},
	"b3e63ced-2bc7-a75c-4a1c-2d9efc8d7020": {
		"name": "攻心",
		"desc": text_message["攻心"],
		"type": "normal",
	},
	"25b7216b-1998-82c6-5cbd-22460175645c": {
		"name": "军神",
		"desc": text_message["军神"],
		"type": "normal",
	},
	"6d7b87b6-4023-7b80-24f8-734d583e06d7": {
		"name": "军魂",
		"desc": text_message["军魂"],
		"type": "normal",
	},
	"7afdbe45-08d4-575b-c996-85959beee5cc": {
		"name": "兵圣",
		"desc": text_message["兵圣"],
		"type": "normal",
	},
	"e203610a-defa-5f50-6b34-d3a4d2d7212e": {
		"name": "王佐",
		"desc": text_message["王佐"],
		"type": "normal",
	},
	"feb8d909-2a8b-1db4-3b54-1329f9ee1730": {
		"name": "仁政",
		"desc": text_message["仁政"],
		"type": "normal",
	},
	"e44f3e8a-8a69-3427-d340-e17fd86a28a0": {
		"name": "屯田",
		"desc": text_message["屯田"],
		"type": "normal",
	},
	"d140202d-55d6-1709-7675-35b80263f6a6": {
		"name": "经商",
		"desc": text_message["经商"],
		"type": "normal",
	},
	"76706277-c4e3-bb1e-42e5-72cb4805f0cd": {
		"name": "眼力",
		"desc": text_message["眼力"],
		"type": "normal",
	},
	"ce122fed-cf87-0f23-ec7b-5b33b6dd1861": {
		"name": "风水",
		"desc": text_message["风水"],
		"type": "normal",
	},
	"48193d31-df5a-2535-2e63-53aa517b679d": {
		"name": "义军",
		"desc": text_message["义军"],
		"type": "normal",
	},
	"4518efa5-444a-0fb6-8c5c-1ecb466375a4": {
		"name": "神医",
		"desc": text_message["神医"],
		"type": "normal",
	},
	"e0f6c8e3-5c8a-7c9f-7b6b-9b6a4e8e8d9f": {
		"name": "仁义",
		"desc": text_message["仁义"],
		"type": "normal",
	},
	"1d7e2d1a-3b09-04c4-5029-14ca721bbe84": {
		"name": "抢运",
		"desc": text_message["抢运"],
		"type": "normal",
	},

	"0602b27f-98fb-7c3b-23f0-b43a622c5476": {
		"name": "仁德",
		"desc": text_message["仁德"],
		"type": "self",
	},
	"f065ded1-72df-0d63-8479-5cc38e77bee8": {
		"name": "枭雄",
		"desc": text_message["枭雄"],
		"type": "self",
	},
	"5ec6b2fd-7559-e832-05f9-aa5be4e0c502": {
		"name": "四世三公",
		"desc": text_message["四世三公"],
		"type": "self",
	},
	"3e096696-4a2c-533e-1ed6-dc5c03d88a25": {
		"name": "小霸王",
		"desc": text_message["小霸王"],
		"type": "self",
	},
	"335ba8c3-916a-20e7-5a61-563202e99805": {
		"name": "酒池肉林",
		"desc": text_message["酒池肉林"],
		"type": "self",
	},
	"f555fb3a-8dc8-9f15-2a39-be6555714dcf": {
		"name": "宽柔无威",
		"desc": text_message["宽柔无威"],
		"type": "self_bad",
	},
	"b4950dc9-1472-3a65-539a-539175e4bf4c": {
		"name": "勇冠四州",
		"desc": text_message["勇冠四州"],
		"type": "self",
	},
	"337a5371-fd68-d7df-3565-a3e6177bb13d": {
		"name": "经汤莫若",
		"desc": text_message["经汤莫若"],
		"type": "self",
	},
	"44037d60-ee22-4bd8-4e04-f966f0af082d": {
		"name": "忠义尽节",
		"desc": text_message["忠义尽节"],
		"type": "self",
	},
	"77d464d9-e901-f941-663e-020850cdf7b4": {
		"name": "马超八健将",
		"desc": text_message["马超八健将"],
		"type": "self",
	}
}

# 当前选择的城池
var cur_city = "61b9c512-225d-d918-086c-e2da4edb860f"

######### 187 剧本城池数据
#########
var citys = {
	"61b9c512-225d-d918-086c-e2da4edb860f": {
		"name": "凉州武威",
		"ownerId": 7,
		"lordId": 100,
		"tong": 60,
		"ren": 20000,
		"jiang": [
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107
		],
		"bing": 15600,
		"nong": 25,
		"shang": 25,
		"zhi": 60,
		"jin": 300,
		"liang": 600
	}
}

######### 角色数据
######### 。。。用数字100累加表示，0-7 是君主
var characters = {
	# 除了君主以外的其他将领
	100: {
		"name": "成公英",
		"headImg": "res://assets/texture/profile/成公英 cheng gong ying.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [
			"44037d60-ee22-4bd8-4e04-f966f0af082d"
		],
		"attrs": {
			"level": 20,
			"command": 73,
			"force": 71,
			"intelligence": 80,
			"politics": 62,
			"morality": 68,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 99,
			"curr_physical_strength": 100,
		},
		"work": 189,
		"born": 172,
		"dead": 220
	},
	101: {
		"name": "张横",
		"headImg": "res://assets/texture/profile/张横 zhang heng.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [
			"77d464d9-e901-f941-663e-020850cdf7b4"
		],
		"attrs": {
			"level": 20,
			"command": 59,
			"force": 70,
			"intelligence": 23,
			"politics": 24,
			"morality": 49,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 89,
			"curr_physical_strength": 100,
		},
		"work": 197,
		"born": 178,
		"dead": 211
	},
	102: {
		"name": "邓贤",
		"headImg": "res://assets/texture/profile/邓贤 deng Xian.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 61,
			"force": 73,
			"intelligence": 45,
			"politics": 36,
			"morality": 51,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 208,
		"born": 188,
		"dead": 248
	},
	103: {
		"name": "李堪",
		"headImg": "res://assets/texture/profile/李堪 Li Kan.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 58,
			"force": 59,
			"intelligence": 33,
			"politics": 37,
			"morality": 45,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 195,
		"born": 176,
		"dead": 211
	},
	104: {
		"name": "梁兴",
		"headImg": "res://assets/texture/profile/梁兴 Liang Xin.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 61,
			"force": 65,
			"intelligence": 19,
			"politics": 22,
			"morality": 26,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 188,
		"born": 169,
		"dead": 211
	},
	105: {
		"name": "马岱",
		"headImg": "res://assets/texture/profile/马岱 Ma Dai.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "dceaf567-ca94-2a19-01d9-efbb9844ffc6",
		"skillIds": [],
		"attrs": {
			"level": 30,
			"command": 81,
			"force": 85,
			"intelligence": 56,
			"politics": 54,
			"morality": 74,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 197,
		"born": 183,
		"dead": 246
	},
	106: {
		"name": "杨欣",
		"headImg": "res://assets/texture/profile/杨兴 Yang Xin.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 61,
			"force": 68,
			"intelligence": 61,
			"politics": 58,
			"morality": 64,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 239,
		"born": 220,
		"dead": 278
	},
	107: {
		"name": "张横",
		"headImg": "res://assets/texture/profile/张横 Zhang Heng.jpg",
		"weaponId": "002e7d6a-c5f3-8ebf-2694-6b032a458a26",
		"armorId": "b179eeaf-ff6d-5e8b-dc6d-1ff3a6848649",
		"skillIds": [],
		"attrs": {
			"level": 20,
			"command": 59,
			"force": 70,
			"intelligence": 23,
			"politics": 24,
			"morality": 49,
			"physical_strength": 100,
			"speed": 80,

			"lorty": 92,
			"curr_physical_strength": 100,
		},
		"work": 197,
		"born": 178,
		"dead": 211
	},
}

######### 初始剧本数据
# name 君主名称
# city_material 城池颜色
# weaponId 武器id
# armorId 防具id
# skillIds 技能id列表
#########
var characters_select = {
	0: {
		"name": '无人占领城池',
		"city_material": {
			"green_blue": false,
			"green_red": false,
			"blue_red": false,
			"blue": 1,
			"green": 1,
			"red": 1
		}
	},
	1: {
		"name": "刘备",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0.4,
			"green": 0.8,
			"red": 0.3
		},
		"headImg": "res://assets/texture/profile/刘备 Liu Bei.jpg",
		"weaponId": "0172a8c4-56fc-5f6e-c2c7-6a49d1f4f978",
		"armorId": "9758bc13-633b-b16f-adf4-37003b972b85",
		"skillIds": [
			"0602b27f-98fb-7c3b-23f0-b43a622c5476",
			"b3e63ced-2bc7-a75c-4a1c-2d9efc8d7020",
			"feb8d909-2a8b-1db4-3b54-1329f9ee1730",
			"d140202d-55d6-1709-7675-35b80263f6a6",
			"48193d31-df5a-2535-2e63-53aa517b679d",
			"e0f6c8e3-5c8a-7c9f-7b6b-9b6a4e8e8d9f",
		],
		"attrs": {
			"level": 30,
			"command": 81,
			"politics": 84,
			"force": 73,
			"intelligence": 74,
			"physical_strength": 100,
			"morality": 100,
			"speed": 80
		}
	},
	2: {
		"name": "曹操",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0.1,
			"green": 0.3,
			"red": 1
		},
		"headImg": "res://assets/texture/profile/曹操 Cao Cao.jpg",
		"weaponId": "716f6a59-c241-0f0e-831f-ed8eb2cf107b",
		"armorId": "dceaf567-ca94-2a19-01d9-efbb9844ffc6",
		"skillIds": [
			"f065ded1-72df-0d63-8479-5cc38e77bee8",
			"9ea2890f-47cf-c9c6-00a4-5218d675dae6",
			"be437047-2f70-655e-5a15-25d0f1965db8",
			"62fec892-6287-ffc9-3ace-345fd50c18a3",
			"997c2db0-2dec-a7d4-5923-75b7f9f5c500",
			"b3e63ced-2bc7-a75c-4a1c-2d9efc8d7020",
			"6d7b87b6-4023-7b80-24f8-734d583e06d7"
		],
		"attrs": {
			"level": 30,
			"command": 97,
			"politics": 94,
			"force": 71,
			"intelligence": 91,
			"physical_strength": 100,
			"morality": 96,
			"speed": 80
		}
	},
	3: {
		"name": "袁绍",
		"headImg": "res://assets/texture/profile/袁绍 Yuan Shao.jpg",
		"weaponId": "cb670c15-b222-f01c-9fa7-6173826f77c0",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"city_material": {
			"green_blue": false,
			"green_red": true,
			"blue_red": false,
			"blue": 0,
			"green": 0.3,
			"red": 0.2
		},
		"skillIds": [
			"5ec6b2fd-7559-e832-05f9-aa5be4e0c502",
			"976bce1c-7f84-0fad-f6f5-57f133e80766",
			"48193d31-df5a-2535-2e63-53aa517b679d"
		],
		"attrs": {
			"level": 40,
			"command": 81,
			"politics": 82,
			"force": 69,
			"intelligence": 70,
			"physical_strength": 100,
			"morality": 87,
			"speed": 80
		}
	},
	4: {
		"name": "孙策",
		"city_material": {
			"green_blue": false,
			"green_red": true,
			"blue_red": false,
			"blue": 0,
			"green": 0.1,
			"red": 0.4
		},
		"headImg": "res://assets/texture/profile/孙策 Sun Ce.jpg",
		"weaponId": "cb670c15-b222-f01c-9fa7-6173826f77c0",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"skillIds": [
			"3e096696-4a2c-533e-1ed6-dc5c03d88a25",
			"7e1823d0-f790-5fb1-d171-81fb6d7ca747",
			"88752da3-9ce2-7ffb-318d-fa9a8a55732b",
			"976bce1c-7f84-0fad-f6f5-57f133e80766",
			"48193d31-df5a-2535-2e63-53aa517b679d"
		],
		"attrs": {
			"level": 40,
			"command": 92,
			"politics": 70,
			"force": 92,
			"intelligence": 68,
			"physical_strength": 100,
			"morality": 90,
			"speed": 80
		}
	},
	5: {
		"name": "董卓",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0.8,
			"green": 0.1,
			"red": 0
		},
		"headImg": "res://assets/texture/profile/董卓 Dong Zhuo.jpg",
		"weaponId": "e7911e0f-5360-0b88-785e-be47f99f4680",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"skillIds": [
			"335ba8c3-916a-20e7-5a61-563202e99805",
			"a091a2c4-2033-3c31-d86c-27866f38e90d",
			"976bce1c-7f84-0fad-f6f5-57f133e80766"
		],
		"attrs": {
			"level": 50,
			"command": 81,
			"politics": 34,
			"force": 87,
			"intelligence": 69,
			"physical_strength": 100,
			"morality": 25,
			"speed": 80
		}
	},
	6: {
		"name": "刘璋",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 0,
			"green": 0.6,
			"red": 1
		},
		"headImg": "res://assets/texture/profile/刘璋 Liu Zhang.jpg",
		"weaponId": "cb670c15-b222-f01c-9fa7-6173826f77c0",
		"armorId": "b06f5ac3-d5e6-32f6-90c4-659c0e78fd0e",
		"skillIds": [
			"f555fb3a-8dc8-9f15-2a39-be6555714dcf",
			"e0f6c8e3-5c8a-7c9f-7b6b-9b6a4e8e8d9f"
		],
		"attrs": {
			"level": 20,
			"command": 27,
			"politics": 68,
			"force": 31,
			"intelligence": 44,
			"physical_strength": 100,
			"morality": 84,
			"speed": 80
		}
	},
	7: {
		"name": "马腾",
		"city_material": {
			"green_blue": true,
			"green_red": false,
			"blue_red": false,
			"blue": 1,
			"green": 1,
			"red": 1
		},
		"headImg": "res://assets/texture/profile/马腾 Ma Teng.jpg",
		"weaponId": "8bc8766e-804f-770d-281a-600b7bcbebcb",
		"armorId": "c1a0342c-4bce-79ef-8425-285723a9b6fa",
		"skillIds": [
			"b4950dc9-1472-3a65-539a-539175e4bf4c",
			"337a5371-fd68-d7df-3565-a3e6177bb13d",
			"7e1823d0-f790-5fb1-d171-81fb6d7ca747",
			"48193d31-df5a-2535-2e63-53aa517b679d"
		],
		"attrs": {
			"level": 40,
			"command": 82,
			"politics": 59,
			"force": 80,
			"intelligence": 51,
			"physical_strength": 100,
			"morality": 89,
			"speed": 80
		},
		"has_citys": [
			"61b9c512-225d-d918-086c-e2da4edb860f"
		]
	}
}


# 公用方法
func set_name_text(name):
	return "[center][color=#91c2d5][u][url]" + name + "[/url][/u][/color]"

func set_text(str):
	return "[center][color=#91c2d5]" + str(str) + "[/color]"

func clear_children(parent: Node):
	for child in parent.get_children():
		child.queue_free()
