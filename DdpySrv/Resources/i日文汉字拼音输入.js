// 日文汉字拼音输入
function execRw(codes)
{
    var aryRet = new Array();
    var cd = codes.substring(2);

    if ( cd.isBlank() ){
        aryRet["Tip"] = "请输入单字拼音全拼";
    }else if ( cd == "a" ){
        aryRet = createRwCand("a", "阿");
    }else if ( cd == "ai" ){
        aryRet = createRwCand("ai", "隘愛碍艾矮藹癌皚哀挨埃");
    }else if ( cd == "an" ){
        aryRet = createRwCand("an", "鞍案岸暗按俺安");
    }else if ( cd == "ang" ){
        aryRet = createRwCand("ang", "昂");
    }else if ( cd == "ao" ){
        aryRet = createRwCand("ao", "澳懊奥傲襖熬敖凹");
    }else if ( cd == "ba" ){
        aryRet = createRwCand("ba", "罷覇耙把跋抜巴八笆叭捌芭");
    }else if ( cd == "bai" ){
        aryRet = createRwCand("bai", "稗拝敗佰擺百柏白");
    }else if ( cd == "ban" ){
        aryRet = createRwCand("ban", "絆半瓣伴拌扮版板頒般搬班斑");
    }else if ( cd == "bang" ){
        aryRet = createRwCand("bang", "謗傍蚌磅棒膀榜幇邦");
    }else if ( cd == "bao" ){
        aryRet = createRwCand("bao", "爆鮑豹暴報抱宝飽堡保雹薄剥褒包胞苞");
    }else if ( cd == "bei" ){
        aryRet = createRwCand("bei", "被焙憊備狽倍貝背輩北卑悲碑杯");
    }else if ( cd == "ben" ){
        aryRet = createRwCand("ben", "笨本奔");
    }else if ( cd == "beng" ){
        aryRet = createRwCand("beng", "迸繃崩");
    }else if ( cd == "bi" ){
        aryRet = createRwCand("bi", "鞭陛避臂壁辟必弊敝閉痺庇幣斃畢蔽蓖碧彼筆鄙比鼻逼");
    }else if ( cd == "bian" ){
        aryRet = createRwCand("bian", "遍辮弁辨卞変便扁貶編辺");
    }else if ( cd == "biao" ){
        aryRet = createRwCand("biao", "表彪標");
    }else if ( cd == "bie" ){
        aryRet = createRwCand("bie", "別");
    }else if ( cd == "bin" ){
        aryRet = createRwCand("bin", "擯賓濱瀕斌彬");
    }else if ( cd == "bing" ){
        aryRet = createRwCand("bing", "併病炳餅秉丙柄氷兵");
    }else if ( cd == "bo" ){
        aryRet = createRwCand("bo", "駁泊渤膊舶帛伯箔搏勃博波鉢撥播菠玻");
    }else if ( cd == "bu" ){
        aryRet = createRwCand("bu", "怖部簿歩布不埠補哺卜捕");
    }else if ( cd == "ca" ){
        aryRet = createRwCand("ca", "擦");
    }else if ( cd == "cai" ){
        aryRet = createRwCand("cai", "蔡菜彩採財才材裁猜");
    }else if ( cd == "can" ){
        aryRet = createRwCand("can", "燦惨慚残蚕参餐");
    }else if ( cd == "cang" ){
        aryRet = createRwCand("cang", "蔵滄倉艙蒼");
    }else if ( cd == "cao" ){
        aryRet = createRwCand("cao", "草曹槽操");
    }else if ( cd == "ce" ){
        aryRet = createRwCand("ce", "測冊側策厠");
    }else if ( cd == "ceng" ){
        aryRet = createRwCand("ceng", "層");
    }else if ( cd == "cha" ){
        aryRet = createRwCand("cha", "詫差岔察査茶叉挿");
    }else if ( cd == "chai" ){
        aryRet = createRwCand("chai", "豺柴拆");
    }else if ( cd == "chan" ){
        aryRet = createRwCand("chan", "顫闡産纏讒蝉");
    }else if ( cd == "chang" ){
        aryRet = createRwCand("chang", "倡唱暢敞廠腸償長常嘗場猖昌");
    }else if ( cd == "chao" ){
        aryRet = createRwCand("chao", "炒巣潮嘲朝鈔抄超");
    }else if ( cd == "che" ){
        aryRet = createRwCand("che", "徹掣撤車");
    }else if ( cd == "chen" ){
        aryRet = createRwCand("chen", "襯趁陳沈忱晨塵辰臣");
    }else if ( cd == "cheng" ){
        aryRet = createRwCand("cheng", "秤騁逞承誠澄懲程乗呈成橙城称");
    }else if ( cd == "chi" ){
        aryRet = createRwCand("chi", "熾斥翅赤尺侈歯恥馳弛遅池匙持痴吃");
    }else if ( cd == "chong" ){
        aryRet = createRwCand("chong", "寵崇虫沖充");
    }else if ( cd == "chou" ){
        aryRet = createRwCand("chou", "臭丑綢仇籌愁稠躊畴酬抽");
    }else if ( cd == "chu" ){
        aryRet = createRwCand("chu", "処触矗儲礎楚除雛鋤躇厨出初");
    }else if ( cd == "chuan" ){
        aryRet = createRwCand("chuan", "串喘船伝椽穿川揣");
    }else if ( cd == "chuang" ){
        aryRet = createRwCand("chuang", "創闖床幢窓瘡");
    }else if ( cd == "chui" ){
        aryRet = createRwCand("chui", "垂錘捶炊吹");
    }else if ( cd == "chun" ){
        aryRet = createRwCand("chun", "蠢純淳唇醇椿春");
    }else if ( cd == "chuo" ){
        aryRet = createRwCand("chuo", "綽戳");
    }else if ( cd == "ci" ){
        aryRet = createRwCand("ci", "次賜刺此詞瓷慈辞雌磁茨疵");
    }else if ( cd == "cong" ){
        aryRet = createRwCand("cong", "叢従匆葱聡");
    }else if ( cd == "cou" ){
        aryRet = createRwCand("cou", "粗湊");
    }else if ( cd == "cu" ){
        aryRet = createRwCand("cu", "促簇醋");
    }else if ( cd == "cuan" ){
        aryRet = createRwCand("cuan", "竄簒");
    }else if ( cd == "cui" ){
        aryRet = createRwCand("cui", "翠淬粋瘁脆催崔摧");
    }else if ( cd == "cun" ){
        aryRet = createRwCand("cun", "寸存村");
    }else if ( cd == "cuo" ){
        aryRet = createRwCand("cuo", "錯挫措搓撮磋");
    }else if ( cd == "da" ){
        aryRet = createRwCand("da", "大打答達搭");
    }else if ( cd == "dai" ){
        aryRet = createRwCand("dai", "怠逮待袋貸代殆帯戴歹呆");
    }else if ( cd == "dan" ){
        aryRet = createRwCand("dan", "蛋弾誕淡憚但旦胆鄲単丹担耽");
    }else if ( cd == "dang" ){
        aryRet = createRwCand("dang", "档蕩党当");
    }else if ( cd == "dao" ){
        aryRet = createRwCand("dao", "盗道悼稲到導祷島倒蹈搗刀");
    }else if ( cd == "de" ){
        aryRet = createRwCand("de", "的得徳");
    }else if ( cd == "deng" ){
        aryRet = createRwCand("deng", "鄧等登灯");
    }else if ( cd == "di" ){
        aryRet = createRwCand("di", "締遞弟帝第蒂地底抵嫡滌狄笛敵迪滴低堤");
    }else if ( cd == "dian" ){
        aryRet = createRwCand("dian", "殿澱奠店甸佃電典点顛");
    }else if ( cd == "diao" ){
        aryRet = createRwCand("diao", "調釣吊掉凋彫");
    }else if ( cd == "die" ){
        aryRet = createRwCand("die", "畳諜迭蝶跌");
    }else if ( cd == "ding" ){
        aryRet = createRwCand("ding", "訂定錠鼎頂釘叮丁");
    }else if ( cd == "dong" ){
        aryRet = createRwCand("dong", "洞凍恫棟動董冬東");
    }else if ( cd == "dou" ){
        aryRet = createRwCand("dou", "痘逗豆闘抖兜");
    }else if ( cd == "du" ){
        aryRet = createRwCand("du", "妬渡度肚鍍杜賭睹堵読独犢毒督都");
    }else if ( cd == "duan" ){
        aryRet = createRwCand("duan", "緞断段鍛短端");
    }else if ( cd == "dui" ){
        aryRet = createRwCand("dui", "対隊兌堆");
    }else if ( cd == "dun" ){
        aryRet = createRwCand("dun", "遁盾鈍頓敦蹲噸");
    }else if ( cd == "duo" ){
        aryRet = createRwCand("duo", "堕惰舵朶躱奪多");
    }else if ( cd == "e" ){
        aryRet = createRwCand("e", "餓鄂遏扼厄悪娥訛額俄鵝峨蛾");
    }else if ( cd == "en" ){
        aryRet = createRwCand("en", "恩");
    }else if ( cd == "er" ){
        aryRet = createRwCand("er", "弐二餌爾耳児而");
    }else if ( cd == "fa" ){
        aryRet = createRwCand("fa", "琺法閥乏伐筏罰発");
    }else if ( cd == "fan" ){
        aryRet = createRwCand("fan", "氾飯犯販範返反煩凡繁礬樊翻番帆藩");
    }else if ( cd == "fang" ){
        aryRet = createRwCand("fang", "放紡訪倣妨防房肪方芳坊");
    }else if ( cd == "fei" ){
        aryRet = createRwCand("fei", "費沸廃肺吠誹匪肥飛非菲");
    }else if ( cd == "fen" ){
        aryRet = createRwCand("fen", "糞憤忿奮粉汾焚墳紛分雰吩芬");
    }else if ( cd == "feng" ){
        aryRet = createRwCand("feng", "鳳奉諷縫馮逢烽瘋風鋒峰蜂楓封豊");
    }else if ( cd == "fo" ){
        aryRet = createRwCand("fo", "仏");
    }else if ( cd == "fou" ){
        aryRet = createRwCand("fou", "否");
    }else if ( cd == "fu" ){
        aryRet = createRwCand("fu", "咐縛婦附訃富負腹父阜付傅復賦覆副赴腐府腑脯斧釜俯輔撫甫弗袱福浮服俘伏符幅輻拂扶孵膚敷夫");
    }else if ( cd == "gai" ){
        aryRet = createRwCand("gai", "漑蓋概改該");
    }else if ( cd == "gan" ){
        aryRet = createRwCand("gan", "敢稈感肝竿柑杆甘乾");
    }else if ( cd == "gang" ){
        aryRet = createRwCand("gang", "槓港崗綱肛缸鋼剛岡");
    }else if ( cd == "gao" ){
        aryRet = createRwCand("gao", "告稿鎬羔膏高皐");
    }else if ( cd == "ge" ){
        aryRet = createRwCand("ge", "各個隔閣蛤格葛革割鴿戈擱歌哥");
    }else if ( cd == "gei" ){
        aryRet = createRwCand("gei", "給");
    }else if ( cd == "gen" ){
        aryRet = createRwCand("gen", "跟根");
    }else if ( cd == "geng" ){
        aryRet = createRwCand("geng", "梗耿羹庚更耕");
    }else if ( cd == "gong" ){
        aryRet = createRwCand("gong", "共貢拱汞鞏弓宮公躬供恭功攻工");
    }else if ( cd == "gou" ){
        aryRet = createRwCand("gou", "購構垢狗苟溝勾鈎");
    }else if ( cd == "gu" ){
        aryRet = createRwCand("gu", "雇固顧故股谷骨蠱古鼓姑孤沽估箍辜");
    }else if ( cd == "gua" ){
        aryRet = createRwCand("gua", "褂掛寡瓜刮");
    }else if ( cd == "guai" ){
        aryRet = createRwCand("guai", "怪拐乖");
    }else if ( cd == "guan" ){
        aryRet = createRwCand("guan", "貫潅慣罐館管観冠官関棺");
    }else if ( cd == "guang" ){
        aryRet = createRwCand("guang", "広光");
    }else if ( cd == "gui" ){
        aryRet = createRwCand("gui", "貴跪櫃桂癸詭鬼軌閨亀帰硅圭規瑰");
    }else if ( cd == "gun" ){
        aryRet = createRwCand("gun", "棍滾");
    }else if ( cd == "guo" ){
        aryRet = createRwCand("guo", "過裹果国郭鍋");
    }else if ( cd == "ha" ){
        aryRet = createRwCand("ha", "哈");
    }else if ( cd == "hai" ){
        aryRet = createRwCand("hai", "駭害亥海孩骸");
    }else if ( cd == "han" ){
        aryRet = createRwCand("han", "漢汗悍憾旱捍撼翰罕喊函寒涵含韓邯酣");
    }else if ( cd == "hang" ){
        aryRet = createRwCand("hang", "航杭");
    }else if ( cd == "hao" ){
        aryRet = createRwCand("hao", "浩号耗好毫豪壕");
    }else if ( cd == "he" ){
        aryRet = createRwCand("he", "賀鶴褐赫涸河貉盒合何和禾核荷喝呵");
    }else if ( cd == "hei" ){
        aryRet = createRwCand("hei", "黒");
    }else if ( cd == "hen" ){
        aryRet = createRwCand("hen", "恨狠很痕");
    }else if ( cd == "heng" ){
        aryRet = createRwCand("heng", "恒衡横亨");
    }else if ( cd == "hong" ){
        aryRet = createRwCand("hong", "紅弘宏洪鴻虹哄轟");
    }else if ( cd == "hou" ){
        aryRet = createRwCand("hou", "後候厚吼猴侯喉");
    }else if ( cd == "hu" ){
        aryRet = createRwCand("hu", "戸滬互護虎弧湖糊狐蝴胡葫壷瑚忽乎呼");
    }else if ( cd == "hua" ){
        aryRet = createRwCand("hua", "話化劃画滑猾華嘩花");
    }else if ( cd == "huai" ){
        aryRet = createRwCand("huai", "壊淮懐徊槐");
    }else if ( cd == "huan" ){
        aryRet = createRwCand("huan", "幻宦渙煥豢喚患換緩還桓環歓");
    }else if ( cd == "huang" ){
        aryRet = createRwCand("huang", "恍幌晃煌惶凰皇簧蝗黄慌荒");
    }else if ( cd == "hui" ){
        aryRet = createRwCand("hui", "絵誨諱匯会穢賄晦恵卉慧悔毀回蛔恢徽輝揮灰");
    }else if ( cd == "hun" ){
        aryRet = createRwCand("hun", "混渾魂婚昏葷");
    }else if ( cd == "huo" ){
        aryRet = createRwCand("huo", "禍貨霍惑或獲火夥活豁");
    }else if ( cd == "ji" ){
        aryRet = createRwCand("ji", "紀継妓際忌既記計寂寄済悸剤祭伎季冀技薊己脊幾擠級嫉即汲疾急及集籍輯棘極吉緝績姫鶏譏激跡飢肌箕積稽畸機基撃");
    }else if ( cd == "jia" ){
        aryRet = createRwCand("jia", "嫁駕架価稼假甲賈頬莢加家佳夾枷嘉");
    }else if ( cd == "jian" ){
        aryRet = createRwCand("jian", "建澗濺漸餞剣艦健件箭鍵見賎践鑑檻薦減剪倹簡揀鹸柬検繭緘姦艱肩兼煎間箋尖堅監殲");
    }else if ( cd == "jiang" ){
        aryRet = createRwCand("jiang", "降醤匠講奨蒋彊江漿将姜僵");
    }else if ( cd == "jiao" ){
        aryRet = createRwCand("jiao", "窖叫較轎酵教剿絞餃角狡脚僥矯撹嚼嬌驕澆郊交膠焦礁椒蕉");
    }else if ( cd == "jie" ){
        aryRet = createRwCand("jie", "届誡疥介借界芥藉戒姐解結潔竭睫捷傑桔節劫截階街皆接掲");
    }else if ( cd == "jin" ){
        aryRet = createRwCand("jin", "勁尽浸燼近禁晋進謹僅錦緊襟津今金斤筋巾");
    }else if ( cd == "jing" ){
        aryRet = createRwCand("jing", "浄競竟靖痙径鏡敬境静頚景警井経粳精驚京鯨晶睛茎兢荊");
    }else if ( cd == "jiong" ){
        aryRet = createRwCand("jiong", "窘炯");
    }else if ( cd == "jiu" ){
        aryRet = createRwCand("jiu", "疚就咎舅臼旧救厩酒九灸久韮玖糾究");
    }else if ( cd == "ju" ){
        aryRet = createRwCand("ju", "劇炬惧句倶鋸踞距具巨据拒聚沮挙矩咀局菊駒居疽狙拘鞠");
    }else if ( cd == "juan" ){
        aryRet = createRwCand("juan", "絹巻眷倦娟鵑捐");
    }else if ( cd == "jue" ){
        aryRet = createRwCand("jue", "絶訣決覚爵倔掘抉攫");
    }else if ( cd == "jun" ){
        aryRet = createRwCand("jun", "駿郡浚竣俊峻君軍鈞菌均");
    }else if ( cd == "ka" ){
        aryRet = createRwCand("ka", "咯喀");
    }else if ( cd == "kai" ){
        aryRet = createRwCand("kai", "慨凱楷揩開");
    }else if ( cd == "kan" ){
        aryRet = createRwCand("kan", "看坎勘堪刊");
    }else if ( cd == "kang" ){
        aryRet = createRwCand("kang", "亢抗扛糠慷康");
    }else if ( cd == "kao" ){
        aryRet = createRwCand("kao", "靠拷考");
    }else if ( cd == "ke" ){
        aryRet = createRwCand("ke", "課客刻克渇可咳殻科顆柯苛");
    }else if ( cd == "ken" ){
        aryRet = createRwCand("ken", "懇墾肯");
    }else if ( cd == "keng" ){
        aryRet = createRwCand("keng", "吭坑");
    }else if ( cd == "kong" ){
        aryRet = createRwCand("kong", "控孔恐空");
    }else if ( cd == "kou" ){
        aryRet = createRwCand("kou", "寇釦口");
    }else if ( cd == "ku" ){
        aryRet = createRwCand("ku", "庫酷苦窟哭枯");
    }else if ( cd == "kua" ){
        aryRet = createRwCand("kua", "袴胯跨誇");
    }else if ( cd == "kuai" ){
        aryRet = createRwCand("kuai", "快塊");
    }else if ( cd == "kuan" ){
        aryRet = createRwCand("kuan", "款寛");
    }else if ( cd == "kuang" ){
        aryRet = createRwCand("kuang", "況曠砿框狂筐匡");
    }else if ( cd == "kui" ){
        aryRet = createRwCand("kui", "潰愧饋傀魁奎葵窺虧");
    }else if ( cd == "kun" ){
        aryRet = createRwCand("kun", "困昆坤");
    }else if ( cd == "kuo" ){
        aryRet = createRwCand("kuo", "闊廓拡括");
    }else if ( cd == "la" ){
        aryRet = createRwCand("la", "辣臘蝋喇拉");
    }else if ( cd == "lai" ){
        aryRet = createRwCand("lai", "頼来莱");
    }else if ( cd == "lan" ){
        aryRet = createRwCand("lan", "濫爛纜懶覧攬瀾蘭闌籃欄婪藍");
    }else if ( cd == "lang" ){
        aryRet = createRwCand("lang", "浪朗郎廊狼榔琅");
    }else if ( cd == "lao" ){
        aryRet = createRwCand("lao", "烙酪姥老牢労撈");
    }else if ( cd == "le" ){
        aryRet = createRwCand("le", "楽勒");
    }else if ( cd == "lei" ){
        aryRet = createRwCand("lei", "涙類肋擂塁儡累磊蕾雷");
    }else if ( cd == "leng" ){
        aryRet = createRwCand("leng", "冷楞稜");
    }else if ( cd == "li" ){
        aryRet = createRwCand("li", "哩璃力隷瀝粒立痢俐例利暦礫励厲麗栗吏茘莉礼鯉里李理漓離狸籬黎犁梨厘");
    }else if ( cd == "lia" ){
        aryRet = createRwCand("lia", "倆");
    }else if ( cd == "lian" ){
        aryRet = createRwCand("lian", "練煉恋鏈臉斂簾漣怜廉連蓮聯");
    }else if ( cd == "liang" ){
        aryRet = createRwCand("liang", "諒亮量輛良粱梁涼糧");
    }else if ( cd == "liao" ){
        aryRet = createRwCand("liao", "料廖鐐了潦遼寥燎療僚聊撩");
    }else if ( cd == "lie" ){
        aryRet = createRwCand("lie", "猟劣烈裂列");
    }else if ( cd == "lin" ){
        aryRet = createRwCand("lin", "吝賃凛淋鱗鄰臨霖燐林琳");
    }else if ( cd == "ling" ){
        aryRet = createRwCand("ling", "令領嶺陵霊凌羚伶鈴齢零菱玲");
    }else if ( cd == "liu" ){
        aryRet = createRwCand("liu", "六柳流瘤劉留餾硫榴琉溜");
    }else if ( cd == "long" ){
        aryRet = createRwCand("long", "隴壟隆窿篭聾竜");
    }else if ( cd == "lou" ){
        aryRet = createRwCand("lou", "陋漏簍婁楼");
    }else if ( cd == "lu" ){
        aryRet = createRwCand("lu", "戮陸録禄鹿賂路露碌麓魯虜鹵炉廬顱盧芦");
    }else if ( cd == "luan" ){
        aryRet = createRwCand("luan", "乱卵攣巒");
    }else if ( cd == "lun" ){
        aryRet = createRwCand("lun", "論綸淪侖倫輪");
    }else if ( cd == "luo" ){
        aryRet = createRwCand("luo", "絡駱洛落裸騾鑼邏羅螺蘿");
    }else if ( cd == "lv" ){
        aryRet = createRwCand("lv", "緑濾率律慮縷屡履旅侶呂驢");
    }else if ( cd == "lue" ){
        aryRet = createRwCand("lue", "略掠");
    }else if ( cd == "ma" ){
        aryRet = createRwCand("ma", "嘛罵馬碼瑪麻媽");
    }else if ( cd == "mai" ){
        aryRet = createRwCand("mai", "脈邁売麦買埋");
    }else if ( cd == "man" ){
        aryRet = createRwCand("man", "謾漫慢曼蔓満蛮饅瞞");
    }else if ( cd == "mang" ){
        aryRet = createRwCand("mang", "莽忙氓盲茫芒");
    }else if ( cd == "mao" ){
        aryRet = createRwCand("mao", "貿貌帽冒茂卯鉚矛毛錨茅猫");
    }else if ( cd == "me" ){
        aryRet = createRwCand("me", "麼");
    }else if ( cd == "mei" ){
        aryRet = createRwCand("mei", "媚妹寐昧美毎媒眉没煤黴梅枚");
    }else if ( cd == "men" ){
        aryRet = createRwCand("men", "們悶門");
    }else if ( cd == "meng" ){
        aryRet = createRwCand("meng", "孟夢猛盟檬蒙萌");
    }else if ( cd == "mi" ){
        aryRet = createRwCand("mi", "冪密蜜泌覓秘米弥謎迷糜靡");
    }else if ( cd == "mian" ){
        aryRet = createRwCand("mian", "面緬娩勉免冕綿眠棉");
    }else if ( cd == "miao" ){
        aryRet = createRwCand("miao", "妙廟渺秒藐描苗");
    }else if ( cd == "mie" ){
        aryRet = createRwCand("mie", "滅蔑");
    }else if ( cd == "min" ){
        aryRet = createRwCand("min", "憫敏皿民");
    }else if ( cd == "ming" ){
        aryRet = createRwCand("ming", "明命名銘鳴螟");
    }else if ( cd == "miu" ){
        aryRet = createRwCand("miu", "謬");
    }else if ( cd == "mo" ){
        aryRet = createRwCand("mo", "陌寞漠沫黙墨莫末抹魔摩磨膜模摸");
    }else if ( cd == "mou" ){
        aryRet = createRwCand("mou", "某牟謀");
    }else if ( cd == "mu" ){
        aryRet = createRwCand("mu", "穆牧睦目木慕募幕暮墓母姆畝牡拇");
    }else if ( cd == "na" ){
        aryRet = createRwCand("na", "納娜那吶拿");
    }else if ( cd == "nai" ){
        aryRet = createRwCand("nai", "奈耐乃");
    }else if ( cd == "nan" ){
        aryRet = createRwCand("nan", "難男南");
    }else if ( cd == "nang" ){
        aryRet = createRwCand("nang", "嚢");
    }else if ( cd == "nao" ){
        aryRet = createRwCand("nao", "閙悩脳撓");
    }else if ( cd == "nei" ){
        aryRet = createRwCand("nei", "内餒");
    }else if ( cd == "nen" ){
        aryRet = createRwCand("nen", "嫩");
    }else if ( cd == "neng" ){
        aryRet = createRwCand("neng", "能");
    }else if ( cd == "ni" ){
        aryRet = createRwCand("ni", "溺逆膩匿擬尼泥倪霓");
    }else if ( cd == "nian" ){
        aryRet = createRwCand("nian", "念捻碾年拈");
    }else if ( cd == "niang" ){
        aryRet = createRwCand("niang", "醸娘");
    }else if ( cd == "niao" ){
        aryRet = createRwCand("niao", "尿鳥");
    }else if ( cd == "nie" ){
        aryRet = createRwCand("nie", "涅鑷噛聶捏");
    }else if ( cd == "ning" ){
        aryRet = createRwCand("ning", "濘寧凝獰檸");
    }else if ( cd == "niu" ){
        aryRet = createRwCand("niu", "紐鈕牛");
    }else if ( cd == "nong" ){
        aryRet = createRwCand("nong", "弄農濃膿");
    }else if ( cd == "nu" ){
        aryRet = createRwCand("nu", "怒努奴");
    }else if ( cd == "nuan" ){
        aryRet = createRwCand("nuan", "暖");
    }else if ( cd == "nuo" ){
        aryRet = createRwCand("nuo", "諾糯懦");
    }else if ( cd == "nv" ){
        aryRet = createRwCand("nv", "女");
    }else if ( cd == "nve" ){
        aryRet = createRwCand("nve", "瘧虐");
    }else if ( cd == "ou" ){
        aryRet = createRwCand("ou", "偶嘔藕殴鴎欧");
    }else if ( cd == "pa" ){
        aryRet = createRwCand("pa", "琶怕爬");
    }else if ( cd == "pai" ){
        aryRet = createRwCand("pai", "派湃徘牌排拍");
    }else if ( cd == "pan" ){
        aryRet = createRwCand("pan", "叛判畔磐盤潘攀");
    }else if ( cd == "pang" ){
        aryRet = createRwCand("pang", "胖旁");
    }else if ( cd == "pao" ){
        aryRet = createRwCand("pao", "泡袍炮咆抛");
    }else if ( cd == "pei" ){
        aryRet = createRwCand("pei", "沛佩配陪賠裴培胚");
    }else if ( cd == "pen" ){
        aryRet = createRwCand("pen", "盆噴");
    }else if ( cd == "peng" ){
        aryRet = createRwCand("peng", "捧鵬朋膨篷硼棚蓬彭澎烹");
    }else if ( cd == "pi" ){
        aryRet = createRwCand("pi", "譬屁僻痞匹皮疲脾毘琵劈披批霹砒");
    }else if ( cd == "pian" ){
        aryRet = createRwCand("pian", "騙片偏篇");
    }else if ( cd == "piao" ){
        aryRet = createRwCand("piao", "票瓢漂飄");
    }else if ( cd == "pie" ){
        aryRet = createRwCand("pie", "瞥");
    }else if ( cd == "pin" ){
        aryRet = createRwCand("pin", "聘品貧頻");
    }else if ( cd == "ping" ){
        aryRet = createRwCand("ping", "屏評瓶憑平萍苹坪");
    }else if ( cd == "po" ){
        aryRet = createRwCand("po", "粕迫魄破婆頗溌坡");
    }else if ( cd == "pou" ){
        aryRet = createRwCand("pou", "剖");
    }else if ( cd == "pu" ){
        aryRet = createRwCand("pu", "瀑曝譜浦普圃朴埔蒲菩葡僕舗撲");
    }else if ( cd == "qi" ){
        aryRet = createRwCand("qi", "訖泣汽棄迄気器砌契啓企乞豈起騎祁祈旗齊臍崎畦奇棋其漆凄七妻戚栖欺期");
    }else if ( cd == "qia" ){
        aryRet = createRwCand("qia", "洽恰");
    }else if ( cd == "qian" ){
        aryRet = createRwCand("qian", "歉欠嵌塹譴浅遣潜前鉗銭黔乾謙仟簽遷千鉛牽");
    }else if ( cd == "qiang" ){
        aryRet = createRwCand("qiang", "搶強薔墻羌腔槍");
    }else if ( cd == "qiao" ){
        aryRet = createRwCand("qiao", "竅峭翹鞘巧僑喬橋悄敲鍬橇");
    }else if ( cd == "qie" ){
        aryRet = createRwCand("qie", "窃怯且茄切");
    }else if ( cd == "qin" ){
        aryRet = createRwCand("qin", "沁寝禽擒芹勤琴秦親侵欽");
    }else if ( cd == "qing" ){
        aryRet = createRwCand("qing", "慶請頃情晴清卿傾軽青");
    }else if ( cd == "qiong" ){
        aryRet = createRwCand("qiong", "窮瓊");
    }else if ( cd == "qiu" ){
        aryRet = createRwCand("qiu", "泅酋囚求球邱丘秋");
    }else if ( cd == "qu" ){
        aryRet = createRwCand("qu", "去趣齲娶取渠駆屈躯曲蛆区趨");
    }else if ( cd == "quan" ){
        aryRet = createRwCand("quan", "勧券犬拳痊全泉権顴圏");
    }else if ( cd == "que" ){
        aryRet = createRwCand("que", "雀確鵲却缺");
    }else if ( cd == "qun" ){
        aryRet = createRwCand("qun", "群裙");
    }else if ( cd == "ran" ){
        aryRet = createRwCand("ran", "染冉燃然");
    }else if ( cd == "rang" ){
        aryRet = createRwCand("rang", "譲壤壌");
    }else if ( cd == "rao" ){
        aryRet = createRwCand("rao", "繞擾饒");
    }else if ( cd == "re" ){
        aryRet = createRwCand("re", "熱惹");
    }else if ( cd == "ren" ){
        aryRet = createRwCand("ren", "妊刃認任靭忍人仁壬");
    }else if ( cd == "reng" ){
        aryRet = createRwCand("reng", "仍");
    }else if ( cd == "ri" ){
        aryRet = createRwCand("ri", "日");
    }else if ( cd == "rong" ){
        aryRet = createRwCand("rong", "冗絨容溶熔融栄蓉茸戎");
    }else if ( cd == "rou" ){
        aryRet = createRwCand("rou", "肉柔揉");
    }else if ( cd == "ru" ){
        aryRet = createRwCand("ru", "褥入汝乳辱如孺儒蠕茹");
    }else if ( cd == "ruan" ){
        aryRet = createRwCand("ruan", "阮軟");
    }else if ( cd == "rui" ){
        aryRet = createRwCand("rui", "鋭瑞蕊");
    }else if ( cd == "run" ){
        aryRet = createRwCand("run", "潤閏");
    }else if ( cd == "ruo" ){
        aryRet = createRwCand("ruo", "弱若");
    }else if ( cd == "sa" ){
        aryRet = createRwCand("sa", "薩洒撒");
    }else if ( cd == "sai" ){
        aryRet = createRwCand("sai", "賽塞鰓腮");
    }else if ( cd == "san" ){
        aryRet = createRwCand("san", "散傘三");
    }else if ( cd == "sang" ){
        aryRet = createRwCand("sang", "喪桑");
    }else if ( cd == "sao" ){
        aryRet = createRwCand("sao", "嫂掃騒掻");
    }else if ( cd == "se" ){
        aryRet = createRwCand("se", "澀色瑟");
    }else if ( cd == "sen" ){
        aryRet = createRwCand("sen", "森");
    }else if ( cd == "seng" ){
        aryRet = createRwCand("seng", "僧");
    }else if ( cd == "sha" ){
        aryRet = createRwCand("sha", "紗沙刹殺砂莎");
    }else if ( cd == "shai" ){
        aryRet = createRwCand("shai", "晒篩");
    }else if ( cd == "shan" ){
        aryRet = createRwCand("shan", "繕扇汕善膳贍擅陝閃衫煽刪山杉苫珊");
    }else if ( cd == "shang" ){
        aryRet = createRwCand("shang", "裳尚上賞商傷");
    }else if ( cd == "shao" ){
        aryRet = createRwCand("shao", "紹邵哨少韶勺芍焼稍梢");
    }else if ( cd == "she" ){
        aryRet = createRwCand("she", "設社渉懾射摂赦捨舌蛇奢");
    }else if ( cd == "shen" ){
        aryRet = createRwCand("shen", "滲慎腎甚審沈神紳娠深身伸呻申");
    }else if ( cd == "sheng" ){
        aryRet = createRwCand("sheng", "聖勝剰盛省縄昇牲甥生声");
    }else if ( cd == "shi" ){
        aryRet = createRwCand("shi", "試視室恃市氏飾釋侍仕適噬嗜是勢逝誓拭事柿世士示式始駛屎使矢史識実蝕食什時拾石十虱屍詩湿施獅失師");
    }else if ( cd == "shou" ){
        aryRet = createRwCand("shou", "獣痩受售授寿守首手収");
    }else if ( cd == "shu" ){
        aryRet = createRwCand("shu", "恕漱数庶墅竪戍束樹述術属鼠黍蜀署曙暑薯熟孰贖書疏淑舒叔輸抒殊梳枢蔬");
    }else if ( cd == "shua" ){
        aryRet = createRwCand("shua", "刷");
    }else if ( cd == "shuai" ){
        aryRet = createRwCand("shuai", "帥衰");
    }else if ( cd == "shuan" ){
        aryRet = createRwCand("shuan", "栓");
    }else if ( cd == "shuang" ){
        aryRet = createRwCand("shuang", "爽双霜");
    }else if ( cd == "shui" ){
        aryRet = createRwCand("shui", "税睡水誰");
    }else if ( cd == "shun" ){
        aryRet = createRwCand("shun", "舜順瞬吮");
    }else if ( cd == "shuo" ){
        aryRet = createRwCand("shuo", "爍朔碩説");
    }else if ( cd == "si" ){
        aryRet = createRwCand("si", "巳飼似伺四嗣寺肆死絲司私思嘶撕斯");
    }else if ( cd == "song" ){
        aryRet = createRwCand("song", "誦訟宋送頌慫聳松");
    }else if ( cd == "sou" ){
        aryRet = createRwCand("sou", "嗽艘捜");
    }else if ( cd == "su" ){
        aryRet = createRwCand("su", "粛訴宿溯塑粟速素俗酥蘇");
    }else if ( cd == "suan" ){
        aryRet = createRwCand("suan", "算蒜酸");
    }else if ( cd == "sui" ){
        aryRet = createRwCand("sui", "祟隧遂穂歳砕髄綏随隋雖");
    }else if ( cd == "sun" ){
        aryRet = createRwCand("sun", "笋損孫");
    }else if ( cd == "suo" ){
        aryRet = createRwCand("suo", "所鎖索瑣縮唆梭蓑");
    }else if ( cd == "ta" ){
        aryRet = createRwCand("ta", "踏撻獺塔它他");
    }else if ( cd == "tai" ){
        aryRet = createRwCand("tai", "汰態太泰台擡苔胎");
    }else if ( cd == "tan" ){
        aryRet = createRwCand("tan", "炭嘆探袒毯坦談譚潭痰檀壇灘貪攤");
    }else if ( cd == "tang" ){
        aryRet = createRwCand("tang", "淌糖唐棠堂塘湯");
    }else if ( cd == "tao" ){
        aryRet = createRwCand("tao", "套討陶淘逃桃萄絛滔涛掏");
    }else if ( cd == "te" ){
        aryRet = createRwCand("te", "特");
    }else if ( cd == "teng" ){
        aryRet = createRwCand("teng", "謄疼騰藤");
    }else if ( cd == "ti" ){
        aryRet = createRwCand("ti", "剃涕嚏替体啼蹄題提剔梯");
    }else if ( cd == "tian" ){
        aryRet = createRwCand("tian", "腆恬甜田填添天");
    }else if ( cd == "tiao" ){
        aryRet = createRwCand("tiao", "跳眺迢条挑");
    }else if ( cd == "tie" ){
        aryRet = createRwCand("tie", "帖鉄貼");
    }else if ( cd == "ting" ){
        aryRet = createRwCand("ting", "艇挺庭亭停廷汀聴庁");
    }else if ( cd == "tong" ){
        aryRet = createRwCand("tong", "痛統筒桶童銅同瞳桐通");
    }else if ( cd == "tou" ){
        aryRet = createRwCand("tou", "透頭投偸");
    }else if ( cd == "tu" ){
        aryRet = createRwCand("tu", "兎吐土屠塗途徒図突禿凸");
    }else if ( cd == "tuan" ){
        aryRet = createRwCand("tuan", "団湍");
    }else if ( cd == "tui" ){
        aryRet = createRwCand("tui", "退褪蛻腿頽推");
    }else if ( cd == "tun" ){
        aryRet = createRwCand("tun", "臀屯呑");
    }else if ( cd == "tuo" ){
        aryRet = createRwCand("tuo", "唾拓妥橢駝駄陀鴕脱托");
    }else if ( cd == "wa" ){
        aryRet = createRwCand("wa", "襪瓦娃窪蛙哇");
    }else if ( cd == "wai" ){
        aryRet = createRwCand("wai", "外歪");
    }else if ( cd == "wan" ){
        aryRet = createRwCand("wan", "腕万婉宛皖晩挽碗完丸頑玩湾彎豌");
    }else if ( cd == "wang" ){
        aryRet = createRwCand("wang", "妄忘望旺往網枉亡王汪");
    }else if ( cd == "wei" ){
        aryRet = createRwCand("wei", "衛慰尉謂渭位魏胃畏味蔚未緯尾偽偉委萎葦維為惟唯圍違韋危微巍威");
    }else if ( cd == "wen" ){
        aryRet = createRwCand("wen", "問紊穏吻紋聞文蚊温瘟");
    }else if ( cd == "weng" ){
        aryRet = createRwCand("weng", "甕翁");
    }else if ( cd == "wo" ){
        aryRet = createRwCand("wo", "沃握臥斡我窩渦蝸");
    }else if ( cd == "wu" ){
        aryRet = createRwCand("wu", "誤悟務勿物晤霧戊塢侮伍舞午五武毋呉吾梧蕪無屋誣汚烏嗚巫");
    }else if ( cd == "xi" ){
        aryRet = createRwCand("xi", "細戲隙係洗銑喜習席襲檄犀汐渓熄惜夕膝悉希息稀犠錫吸晰西析煕昔");
    }else if ( cd == "xia" ){
        aryRet = createRwCand("xia", "嚇夏厦下狭侠峡暇轄霞匣蝦瞎");
    }else if ( cd == "xian" ){
        aryRet = createRwCand("xian", "線限陥憲羨餡腺県献現険顕嫌弦涎閑舷銜賢咸繊鮮仙先掀");
    }else if ( cd == "xiang" ){
        aryRet = createRwCand("xiang", "象向像橡巷項享響想詳祥翔郷湘襄箱香鑵廂相");
    }else if ( cd == "xiao" ){
        aryRet = createRwCand("xiao", "効笑嘯肖校孝小暁淆宵消銷囂哮削霄硝蕭");
    }else if ( cd == "xie" ){
        aryRet = createRwCand("xie", "屑謝瀉洩懈蟹卸械写諧脅斜邪携挟協鞋蝎歇些楔");
    }else if ( cd == "xin" ){
        aryRet = createRwCand("xin", "釁信心忻新辛欣芯薪");
    }else if ( cd == "xing" ){
        aryRet = createRwCand("xing", "姓性杏幸醒行形型刑興惺猩腥星");
    }else if ( cd == "xiong" ){
        aryRet = createRwCand("xiong", "熊雄洶匈胸兇兄");
    }else if ( cd == "xiu" ){
        aryRet = createRwCand("xiu", "繍袖秀銹嗅朽羞修休");
    }else if ( cd == "xu" ){
        aryRet = createRwCand("xu", "続緒婿絮恤畜序旭叙蓄許徐須嘘虚需戌墟");
    }else if ( cd == "xuan" ){
        aryRet = createRwCand("xuan", "絢眩癬選玄旋懸宣喧軒");
    }else if ( cd == "xue" ){
        aryRet = createRwCand("xue", "血雪穴学薛靴");
    }else if ( cd == "xun" ){
        aryRet = createRwCand("xun", "迅遜訊訓殉巡馴尋詢旬循熏勲");
    }else if ( cd == "ya" ){
        aryRet = createRwCand("ya", "訝亜唖雅涯衙崖牙芽呀鴨鴉押圧");
    }else if ( cd == "yan" ){
        aryRet = createRwCand("yan", "験諺宴焔彦雁硯厭燕堰艶演衍眼掩奄沿炎閻顔言延岩蜒研厳塩淹煙閹咽焉");
    }else if ( cd == "yang" ){
        aryRet = createRwCand("yang", "漾様養痒仰陽洋羊瘍佯揚楊秧鴦央殃");
    }else if ( cd == "yao" ){
        aryRet = createRwCand("yao", "耀要薬咬姚謡窯遥尭揺瑶妖腰邀");
    }else if ( cd == "ye" ){
        aryRet = createRwCand("ye", "液夜腋曳葉業掖頁也冶野爺耶噎椰");
    }else if ( cd == "yi" ){
        aryRet = createRwCand("yi", "繹翌翼異訳誼議詣溢益義憶毅意裔亦疫肄逸臆役億屹邑易抑芸以矣乙已倚蟻椅彝姨宜沂疑儀移遺夷頤衣伊依揖医壹一");
    }else if ( cd == "yin" ){
        aryRet = createRwCand("yin", "印隠引尹飲寅淫銀吟姻陰音殷因蔭茵");
    }else if ( cd == "ying" ){
        aryRet = createRwCand("ying", "映硬穎影盈贏迎蝿営蛍瑩纓応鷹嬰桜英");
    }else if ( cd == "yong" ){
        aryRet = createRwCand("yong", "用勇慂永湧泳詠蛹踊雍庸癰傭擁");
    }else if ( cd == "you" ){
        aryRet = createRwCand("you", "幼又誘釉佑右友有酉遊油猶郵由尤憂悠優幽");
    }else if ( cd == "yu" ){
        aryRet = createRwCand("yu", "馭豫預裕寓浴誉育獄欲愈御峪喩遇吁郁芋域玉羽語宇禹嶼与雨娯予隅漁渝愉魚逾兪余輿愚虞楡盂于淤迂");
    }else if ( cd == "yuan" ){
        aryRet = createRwCand("yuan", "院怨願苑遠縁源猿円員園轅援原袁垣元冤淵鴛");
    }else if ( cd == "yue" ){
        aryRet = createRwCand("yue", "閲悦月粤岳鑰躍越約曰");
    }else if ( cd == "yun" ){
        aryRet = createRwCand("yun", "孕韻暈蘊運允隕雲耘");
    }else if ( cd == "za" ){
        aryRet = createRwCand("za", "雑匝");
    }else if ( cd == "zai" ){
        aryRet = createRwCand("zai", "在再載宰災哉栽");
    }else if ( cd == "zan" ){
        aryRet = createRwCand("zan", "贊暫攅");
    }else if ( cd == "zang" ){
        aryRet = createRwCand("zang", "葬臓賍");
    }else if ( cd == "zao" ){
        aryRet = createRwCand("zao", "燥竃造噪躁蚤澡早棗藻鑿糟遭");
    }else if ( cd == "ze" ){
        aryRet = createRwCand("ze", "沢則擇責");
    }else if ( cd == "zei" ){
        aryRet = createRwCand("zei", "賊");
    }else if ( cd == "zen" ){
        aryRet = createRwCand("zen", "怎");
    }else if ( cd == "zeng" ){
        aryRet = createRwCand("zeng", "贈曾憎増");
    }else if ( cd == "zha" ){
        aryRet = createRwCand("zha", "詐炸乍咋搾柵閘軋札渣扎");
    }else if ( cd == "zhai" ){
        aryRet = createRwCand("zhai", "砦債窄宅齋摘");
    }else if ( cd == "zhan" ){
        aryRet = createRwCand("zhan", "綻湛站戦占桟展嶄輾斬盞沾粘詹氈瞻");
    }else if ( cd == "zhang" ){
        aryRet = createRwCand("zhang", "張障瘴脹仗帳丈杖漲掌彰章樟");
    }else if ( cd == "zhao" ){
        aryRet = createRwCand("zhao", "召肇兆罩照趙沼找昭招");
    }else if ( cd == "zhe" ){
        aryRet = createRwCand("zhe", "浙這蔗者轍蟄哲摺遮");
    }else if ( cd == "zhen" ){
        aryRet = createRwCand("zhen", "陣鎮振震診疹枕偵針貞臻砧甄真斟珍");
    }else if ( cd == "zheng" ){
        aryRet = createRwCand("zheng", "証鄭症陣鎮振震診疹枕偵針貞臻砧甄真斟珍浙這蔗者幀政正拯整争征蒸");
    }else if ( cd == "zhi" ){
        aryRet = createRwCand("zhi", "窒治滞痔炙質稚秩智制峙幟置致至躑摯志紙旨隻趾止指阯姪値執殖植直職織之汁脂肢知蜘支枝芝");
    }else if ( cd == "zhong" ){
        aryRet = createRwCand("zhong", "衆仲重腫種終衷鍾忠中");
    }else if ( cd == "zhou" ){
        aryRet = createRwCand("zhou", "驟昼宙皺呪帚肘軸粥洲州周舟");
    }else if ( cd == "zhu" ){
        aryRet = createRwCand("zhu", "駐祝注住築鋳貯助柱著主嘱矚煮燭竹逐誅諸猪朱蛛株珠");
    }else if ( cd == "zhua" ){
        aryRet = createRwCand("zhua", "爪抓");
    }else if ( cd == "zhuan" ){
        aryRet = createRwCand("zhuan", "篆賺撰転磚専");
    }else if ( cd == "zhuang" ){
        aryRet = createRwCand("zhuang", "状壮撞妝装庄");
    }else if ( cd == "zhui" ){
        aryRet = createRwCand("zhui", "綴墜贅追錐椎");
    }else if ( cd == "zhun" ){
        aryRet = createRwCand("zhun", "准諄");
    }else if ( cd == "zhuo" ){
        aryRet = createRwCand("zhuo", "濁灼着啄酌琢卓拙捉");
    }else if ( cd == "zi" ){
        aryRet = createRwCand("zi", "字漬自子滓仔紫孜滋姿資諮茲");
    }else if ( cd == "zong" ){
        aryRet = createRwCand("zong", "縦総綜宗蹤棕");
    }else if ( cd == "zou" ){
        aryRet = createRwCand("zou", "奏走鄒");
    }else if ( cd == "zu" ){
        aryRet = createRwCand("zu", "組阻詛祖族卒足租");
    }else if ( cd == "zuan" ){
        aryRet = createRwCand("zuan", "纂鑽");
    }else if ( cd == "zui" ){
        aryRet = createRwCand("zui", "罪最酔嘴");
    }else if ( cd == "zun" ){
        aryRet = createRwCand("zun", "遵尊");
    }else{
        aryRet["Tip"] = "请输入单字拼音全拼";
    }

    return aryRet;
}

function createRwCand(py, texts)
{
    var aryRet = new Array();
    for ( var i = 0; i < texts.length; i++ ){
        aryRet[aryRet.length] = ddpyCreateCand(texts.substring(i, i+1));
    }

    return aryRet;
}
