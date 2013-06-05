﻿// 符号输入用脚本例子，编码栏输入“ifh”时被调用
//（codes为不包含第一位“i”的编码）
function execFh(codes)
{
	var aryRet = new Array();
	var cd = codes.substring(2);

	aryRet["Title"] = '淡定“i”模式——爱符号';
	var sFhs = "→⇒←↑↓≠＊≧≦○◎●▲△▼▽☆★◇◆□■";
	for ( var i = 0; i < sFhs.length; i++ ){
		aryRet[aryRet.length] = ddpyCreateCand(sFhs.substring(i, i+1));
	}

	return aryRet;
}

// 张仲景伤寒论条文
function execZj(codes)
{
	var i = 1;
	var aryRet = new Array();
	var cd = codes.substring(2);

	if ( cd.isBlank() ) {
		aryRet["Tip"] = "请输入条文编号 1～398";
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("1、太阳之为病，脉浮，头项强痛而恶寒。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("2、太阳病，发热汗出，恶风，脉缓者，名为中风。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("3、太阳病，或已发热，或未发热，必恶寒，体痛，呕逆，脉阴阳俱紧者，名为伤寒。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("4、伤寒一日，太阳受之，脉若静者，为不传，颇欲吐，若躁烦脉数急者，为传也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("5、伤寒二、三日，阳明、少阳证不见者，为不传也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("6、太阳病，发热而渴，不恶寒者为温病。<br>若发汗已，身灼热者，名风温。<br>风温为病，脉阴阳俱浮，自汗出，身重，多眠睡，鼻息必鼾，语言难出。<br>若被下者，小便不利，直视失溲；<br>若被火者，微发黄色，剧则如惊痫，时瘈疭；<br>若火熏之，一逆尚引日，再逆促命期。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("7、病有发热恶寒者，发于阳也。无热恶寒者，发于阴也。发于阳，七日愈。发于阴，六日愈。以阳数七阴数六故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("8、太阳病，头痛至七日以上自愈者，以行其经尽故也。若欲作再经者，针足阳明，使经不传则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("9、太阳病，欲解时，从巳至未上。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("10、风家，表解而不了了者，十二日愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("11、病人身大热，反欲得衣者，热在皮肤，寒在骨髓也，身大寒，反欲不近衣者，寒在皮肤，热在骨髓也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("12、太阳中风，阳浮而阴弱。阳浮者，热自发；阴弱者，汗自出。<br>啬啬恶寒，淅淅恶风，翕翕发热，鼻鸣干呕者，桂枝汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("13、太阳病，头痛发热，汗出恶风，桂枝汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("14、太阳病，项背强几几，反汗出恶风者，桂枝加葛根汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("15、太阳病，下之后，其气上冲者，可与桂枝汤，方用前法，若不上冲者，不得与之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("16、太阳病三日，已发汗，若吐、若下、若温针，仍不解者，此为坏病，桂枝不中与之也。<br>观其脉证，知犯何逆，随证治之。<br>桂枝本为解肌，若其人脉浮紧，发热汗不出者，不可与之也。常须识此，勿令误也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("17、若酒客病，不可与桂枝汤，得之则呕，以酒客不喜甘故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("18、喘家作，桂枝汤加厚朴、杏子佳。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("19、凡服桂枝汤吐者，其后必吐脓血也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("20、太阳病，发汗，遂漏不止，其人恶风，小便难，四肢微急，难以屈伸者，桂枝加附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("21、太阳病，下之后，脉促，胸满者，桂枝去芍药汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("22、若微寒者，桂枝去芍药加附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("23、太阳病，得之八九日，如疟状，发热恶寒，热多寒少，其人不呕，圊便欲自可，一日二三度发。<br>脉微缓者，为欲愈也，脉微而恶寒者，此阴阳俱虚，不可更发汗、更下、更吐也。<br>面色反有热色者，未欲解也，以其不能得小汗出，身必痒，宜桂枝麻黄各半汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("24、太阳病，初服桂枝汤，反烦不解者，先刺风池、风府，却与桂枝汤则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("25、服桂枝汤，大汗出，脉洪大者，与桂技汤，如前法，若形似疟，一日再发者，汗出必解，宜桂枝二麻黄一汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("26、服桂枝汤，大汗出后，大烦渴不解，脉洪大者，白虎加人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("27、太阳病，发热恶寒，热多寒少，脉微弱者，此无阳也，不可发汗，宜桂枝二越婢一汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("28、服桂枝汤，或下之，仍头项强痛，翕翕发热，无汗，心下满微痛，小便不利者，桂枝去桂加茯苓白术汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("29、伤寒，脉浮，自汗出，小便数，心烦，微恶寒，脚挛急。反与桂枝欲攻其表，此误也。<br>得之便厥，咽中干，烦躁吐逆者，作甘草干姜汤与之，以复其阳。<br>若厥愈足温者，更作芍药甘草汤与之，其脚即伸；<br>若胃气不和，谵语者，少与调胃承气汤，若重发汗，复加烧针者，四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("30、问曰：证象阳旦，按法治之而增剧，厥逆，咽中干，两胫拘急而谵语。<br>师曰：言夜半手足当温，两脚当伸。后如师言。<br>何以知此？<br>答曰：寸口脉浮而大，浮为风，大为虚，风则生微热，虚则两胫挛，<br>病形象桂枝，因加附子参其间，增桂令汗出，附子温经，亡阳故也。<br>厥逆，咽中干，烦躁，阳明内结，谵语烦乱，更饮甘草干姜汤。<br>夜半阳气还，两足当热，胫尚微拘急，重与芍药甘草汤，尔乃胫伸。<br>以承气汤微溏，则止其谵语，故知病可愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("31、太阳病，项背强几几，无汗恶风（者），葛根汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("32、太阳与阳明合病者，必自下利。葛根汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("33、太阳与阳明合病，不下利，但呕者，葛根加半夏汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("34、太阳病，桂枝证，医反下之，利遂不止。脉促者，表未解也，喘而汗出者，葛根黄芩黄连汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("35、太阳病，头痛发热，身疼腰痛，骨节疼痛，恶风无汗而喘者，麻黄汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("36、太阳与阳明合病，喘而胸满者，不可下，宜麻黄汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("37、太阳病，十日已去，脉浮细而嗜卧者，外已解也。设胸满胁痛者，与小柴胡汤，脉但浮者，与麻黄汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("38、太阳中风，脉浮紧，发热恶寒，身疼痛，不汗出而烦躁者，大青龙汤主之。<br>若脉微弱，汗出恶风者，不可服之，服之则厥逆，筋惕肉瞤，此为逆也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("39、伤寒、脉浮缓，身不疼，但重，乍有轻时，无少阴证者，大青龙汤发之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("40、伤寒表不解，心下有水气，干呕，发热而咳，或渴，或利，或噎，或小便不利、少腹满，或喘者，小青龙汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("41、伤寒，心下有水气，咳而微喘，发热不渴，服汤已，渴者，此寒去欲解也，小青龙汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("42、太阳病，外证未解，脉浮弱者，当以汗解，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("43、太阳病，下之微喘者，表未解故也，桂枝加厚朴杏子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("44、太阳病，外证未解，不可下也，下之为逆。欲解外者，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("45、太阳病，先发汗，不解，而复下之，脉浮者不愈，浮为在外，而反下之，故令不愈。<br>今脉浮，故知在外，当须解外则愈，宜桂技汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("46、太阳病，脉浮紧，无汗，发热，身疼痛，八九日不解，表证仍在，此当发其汗。<br>服药已微除，其人发烦，目瞑，剧者必衄，衄乃解。<br>所以然者，阳气重故也。麻黄汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("47、太阳病，脉浮紧，发热，身无汗，自衄者愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("48、二阳并病，太阳初得病时，发其汗，汗先出不彻，因转属阳明，续自微汗出，不恶寒。<br>若太阳病证不罢者，不可下，下之为逆，如此可小发汗。<br>设面色缘缘正赤者，阳气怫郁在表，当解之熏之。<br>若发汗不彻，不足言，阳气怫郁不得越，当汗不汗，其人躁烦，不知痛处，<br>乍在腹中，乍在四肢，按之不可得，其人短气但坐，以汗出不彻故也，更发汗则愈。<br>何以知汗出不彻？以脉涩故知也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("49、脉浮数者，法当汗出而愈，若下之，身重，心悸者，不可发汗，当自汗出乃解。<br>所以然者，尺中脉微，此里虚，须表里实，津液自和，便自汗出愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("50、脉浮紧者，法当身疼痛，宜以汗解之。假令尺中迟者，不可发汗。何以知然？以荣气不足，血少故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("51、脉浮者，病在表，可发汗，宜麻黄汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("52、脉浮而数者，可发汗，宜麻黄汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("53、病常自汗出者，此为荣气和。荣气和者，外不谐，以卫气不共荣气谐和故尔。<br>以荣行脉中，卫行脉外，复发其汗，荣卫和则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("54、病人藏无他病，时发热、自汗出而不愈者，此卫气不和也，先其时发汗则愈，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("55、伤寒，脉浮紧，不发汗，因致衄者，麻黄汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("56、伤寒，不大便六七日，头痛有热者，与承气汤，其小便清者，知不在里，仍在表也，当须发汗；<br>若头痛者，必衄，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("57、伤寒发汗，已解。半日许复烦，脉浮数者，可更发汗，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("58、凡病，若发汗，若吐，若下，若亡血、亡津液，阴阳自和者，必自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("59、大下之后，复发汗，小便不利者，亡津液故也。勿治之，得小便利，必自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("60、下之后，复发汗，必振寒，脉微细。所以然者，以内外俱虚故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("61、下之后，复发汗，昼日烦躁不得眠，夜而安静，不呕，不渴，无表证，脉沉微，身无大热者，干姜附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("62、发汗后，身疼痛，脉沉迟者，桂枝加芍药生姜各一两人参三两新加汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("63、发汗后，不可更行桂枝汤。汗出而喘，无大热者，可与麻黄杏仁甘草石膏汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("64、发汗过多，其人叉手自冒心，心下悸，欲得按者，桂枝甘草汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("65、发汗后，其人脐下悸者，欲作奔豚，茯苓桂枝甘草大枣汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("66、发汗后，腹胀满者。厚朴生姜半夏甘草人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("67、伤寒，若吐、若下后，心下逆满，气上冲胸，起则头眩，脉沉紧，发汗则动经，身为振振摇者，茯苓桂枝白术甘草汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("68、发汗病不解，反恶寒者，虚故也，芍药甘草附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("69、发汗，若下之，病仍不解，烦躁者，茯苓四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("70、发汗后，恶寒者，虚故也；不恶寒，但热者，实也，当和胃气，与调胃承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("71、太阳病，发汗后，大汗出，胃中干，烦躁不得眠，欲得饮水者，少少与饮之，令胃气和则愈。<br>若脉浮，小便不利，微热消渴者，五苓散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("72、发汗已，脉浮数，烦渴者，五苓散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("73、伤寒，汗出而渴者，五苓散主之。不渴者，茯苓甘草汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("74、中风发热，六七日不解而烦，有表里证，渴欲饮水，水入则吐者，名曰水逆，五苓散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("75、未持脉时，病人手叉自冒心，师因教试令咳而不咳者，此必两耳聋无闻也，所以然者，以重发汗虚故如此。<br>发汗后，饮水多，必喘；以水灌之，亦喘。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("76、发汗后，水药不得入口，为逆，若更发汗，必吐下不止。<br>发汗吐下后，虚烦不得眠，若剧者，必反复颠倒，心中懊憹，栀子豉汤主之；<br>若少气者，栀子甘草豉汤主之；若呕者，栀子生姜豉汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("77、发汗，若下之，而烦热，胸中窒者，栀子豉汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("78、伤寒五六日，大下之后，身热不去，心中结痛者，未欲解也，栀子豉汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("79、伤寒下后，心烦腹满，卧起不安者，栀子厚朴汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("80、伤寒，医以丸药大下之，身热不去，微烦者，栀子干姜汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("81、凡用栀子汤，病人旧微溏者，不可与服之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("82、太阳病发汗，汗出不解，其人仍发热，心下悸，头眩，身瞤动，振振欲擗地者，真武汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("83、咽喉干燥者，不可发汗。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("84、淋家，不可发汗，汗出必便血。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("85、疮家，虽身疼痛，不可发汗，发汗则痉。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("86、衄家，不可发汗，汗出，必额上陷脉急紧，直视不能眴，不得眠。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("87、亡血家，不可发汗，发汗则寒栗而振。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("88、汗家重发汗，必恍惚心乱，小便已阴疼，与禹余粮丸。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("89、病人有寒，复发汗，胃中冷，必吐蚘。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("90、本发汗而复下之，此为逆也，若先发汗，治不为逆。本先下之而反汗之，为逆；若先下之，治不为逆。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("91、伤寒，医下之，续得下利清谷不止，身疼痛者，急当救里。<br>后身疼痛，清便自调者，急当救表。救里，宜四逆汤；救表，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("92、病发热头痛，脉反沉，若不差，身体疼痛，当救其里，四逆汤方。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("93、太阳病，先下而不愈，因复发汗，以此表里俱虚，其人因致冒，冒家汗出自愈。<br>所以然者，汗出表和故也，里未和，然后复下之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("94、太阳病未解，脉阴阳俱停，必先振栗汗出而解。<br>但阳脉微者，先汗出而解；但阴脉微者，下之而解。若欲下之，宜调胃承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("95、太阳病，发热汗出者，此为荣弱卫强，故使汗出，欲救邪风者，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("96、伤寒五六日，中风，往来寒热，胸胁苦满，嘿嘿不欲饮食，心烦喜呕，或胸中烦而不呕，或渴，<br>或腹中痛，或胁下痞硬，或心下悸、小便不利，或不渴、身有微热，或咳者，小柴胡汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("97、血弱气尽，腠理开，邪气因入，与正气相搏，结于胁下。<br>正邪分争，往来寒热，休作有时，嘿嘿不欲饮食，藏府相连，其痛必下，邪高痛下，故使呕也，小柴胡汤主之。<br>服柴胡汤已，渴者属阳明，以法治之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("98、得病六七日，脉迟浮弱，恶风寒，手足温，医二三下之，不能食，而胁下满痛，面目及身黄，颈项强，小便难者，与柴胡汤，后必下重。<br>本渴饮水而呕者，柴胡不中与也，食谷者哕。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("99、伤寒四五日，身热恶风，颈项强，胁下满，手足温而渴者，小柴胡汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("100、伤寒，阳脉涩，阴脉弦，法当腹中急痛，先与小建中汤，不差者，小柴胡汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("101、伤寒中风，有柴胡证，但见一证便是，不必悉具。<br>凡柴胡汤病证而下之，若柴胡证不罢者，复与柴胡汤，必蒸蒸而振，却复发热汗出而解。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("102、伤寒二三日，心中悸而烦者，小建中汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("103、太阳病，过经十余日，反二三下之，后四五日，柴胡证仍在者，先与小柴胡汤；<br>呕不止，心下急，郁郁微烦者，为未解也，与大柴胡汤下之则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("104、伤寒十三日，不解，胸胁满而呕，日晡所发潮热，已而微利，<br>此本柴胡证，下之以不得利，今反利者，知医以丸药下之，此非其治也。<br>潮热者，实也。先宜服小柴胡汤以解外，后以柴胡加芒硝汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("105、伤寒十三日，过经谵语者，以有热也，当以汤下之。<br>若小便利者，大便当硬，而反下利，脉调和者，知医以丸药下之，非其治也。<br>若自下利者，脉当微厥；今反和者，此为内实也。调胃承气汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("106、太阳病不解，热结膀胱，其人如狂，血自下，下者愈。<br>其外不解者，尚未可攻，当先解其外。<br>外解已，但少腹急结者，乃可攻之，宜桃核承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("107、伤寒八九日，下之，胸满烦惊，小便不利，谵语，一身尽重，不可转侧者，柴胡加龙骨牡蛎汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("108、伤寒腹满谵语，寸口脉浮而紧，此肝乘脾也，名曰纵，刺其门。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("109、伤寒发热，啬啬恶寒，大渴欲饮水，其腹必满，自汗出，小便利，其病欲解，此肝乘肺也，名曰横，刺期门。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("110、太阳病二日，反躁，反(凡)熨其背而大汗出，火热入胃，胃中水竭，躁烦，必发谵语；<br>十余日，振栗，自下利者，此为欲解也。<br>故其汗从腰以下不得汗，欲小便不得，反呕欲失溲，足下恶风，大便硬，小便当数而反不数及不多；<br>大便已，头卓然而痛，其人足心必热，谷气下流故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("111、太阳病中风，以火劫发汗，邪风被火热，血气流溢，失其常度。<br>两阳相熏灼，其身发黄，阳盛则欲衄，阴虚小便难，阴阳俱虚竭，身体则枯燥。<br>但头汗出，剂颈而还，腹满微喘，口干咽烂，或不大便。<br>久则谵语，甚者至哕，手足躁扰，捻衣摸床，小便利者，其人可治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("112、伤寒脉浮，医者以火迫劫之，亡阳，必惊狂，卧起不安者，桂枝去芍药加蜀漆牡蛎龙骨救逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("113、形作伤寒，其脉不弦紧而弱，弱者必渴，被火必谵语，弱者发热脉浮，解之，当汗出愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("114、太阳病，以火熏之，不得汗，其人必躁。到经不解，必清血，名为火邪。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("115、脉浮热甚，而反灸之，此为实。实以虚治，因火而动，必咽燥吐血。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("116、微数之脉，慎不可灸。因火为邪，则为烦逆，追虚逐实，血散脉中，火气虽微，内攻有力，焦骨伤筋，血难复也。<br>脉浮，宜以汗解，用火灸之，邪无从出，因火而盛，病从腰以下，必重而痹，名火逆也。<br>欲自解者，必当先烦，烦乃有汗而解，何以知之？脉浮，故知汗出解。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("117、烧针令其汗，针处被寒，核起而赤者，必发奔豚，<br>气从少腹上冲心者，灸其核上各一壮，与桂枝加桂汤，更加桂二两也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("118、火逆下之，因烧针烦躁者，桂枝甘草龙骨牡蛎汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("119、太阳伤寒者，加温针，必惊也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("120、太阳病，当恶寒发热，今自汗出，反不恶寒发热，关上脉细数者，以医吐之过也。<br>一二日吐之者，腹中饥，口不能食，三四日吐之者，不喜糜粥，欲食冷食，朝食暮吐，以医吐之所致也，此为小逆。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("121、太阳病吐之，但太阳病当恶寒，今反不恶寒，不欲近衣，此为吐之内烦也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("122、病人脉数，数为热，当消谷引食，而反吐者，此以发汗，令阳气微，膈气虚，脉乃数也。<br>数为客热。不能消谷，以胃中虚冷，故吐也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("123、太阳病，过经十余日，心下温温欲吐，而胸中痛，大便反溏，腹微满，郁郁微烦，先此时自极吐下者，与调胃承气汤。<br>若不尔者，不可与。但欲呕，胸中痛，微溏者，此非柴胡汤证，以呕，故知极吐下也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("124、太阳病六七日，表证仍在，脉微而沉，反不结胸，其人发狂者，以热在下焦，少腹当硬满。小便自利者，下血乃愈。<br>所以然者，以太阳随经，瘀热在里故也，抵当汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("125、太阳病，身黄，脉沉结，少腹硬，小便不利者，为无血也；小便自利，其人如狂者，血证谛也，抵当汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("126、伤寒有热，少腹满，应小便不利，今反利者，为有血也。当下之，不可余药，宜抵当丸。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("127、太阳病，小便利者，以饮水多，必心下悸；小便少者，必苦里急也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("128、问曰：病有结胸，有藏结，其状何如？答曰：按之痛，寸脉浮，关脉沉，名曰结胸也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("129、何谓藏结？答曰：如结胸状，饮食如故，时时下利，寸脉浮，关脉小细沉紧，名曰藏结，舌上白胎滑者，难治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("130、藏结无阳证，不往来寒热，其人反静，舌上胎滑者，不可攻也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("131、病发于阳而反下之，热入因作结胸；病发于阴而反下之，因作痞也。<br>所以成结胸者，以下之太早故也。结胸者，项亦强，如柔痓（音瘛，通痉）状，下之则和，宜大陷胸丸。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("132、结胸证，其脉浮大者，不可下，下之则死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("133、结胸证悉具，烦躁者亦死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("134、太阳病，脉浮而动数，浮则为风，数则为热，动则为痛，数则为虚。头痛发热，微盗汗出，而反恶寒者，表未解也。<br>医反下之，动数变迟，膈内拒痛，胃中空虚，客气动膈，短气躁烦，心中懊憹，阳气内陷，心下因硬，则为结胸，大陷胸汤主之。<br>若不结胸，但头汗出，余处无汗，剂颈而还，小便不利，身必发黄。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("135、伤寒六七日，结胸热实，脉沉而紧，心下痛，按之石硬者，大陷胸汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("136、伤寒十余日，热结在里，复往来寒热者，与大柴胡汤；但结胸，无大热者，此为水结在胸胁也，但头微汗出者，大陷胸汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("137、太阳病，重发汗而复下之，不大便五六日，舌上燥而渴，日哺所小有潮热。<br>从心下至少腹便满而痛不可近者，大陷胸汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("138、小结胸病，正在心下，按之则痛，脉浮滑者，小陷胸汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("139、太阳病二三日，不能卧，但欲起，心下必结，脉微弱者，此本有寒分也。<br>反下之，若利止。必作结胸；未止者，四日复下之，此作协热利也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("140、太阳病下之，其脉促，不结胸者，此为欲解也；脉浮者，必结胸，脉紧者，必咽痛；脉弦者，必两胁拘急；脉细数者，头痛未止；脉沉紧者，必欲呕，脉沉滑者，协热利；脉浮滑者，必下血。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("141、病在阳，应以汗解之，反以冷水潠之，若灌之，其热被劫，不得去，弥更益烦，肉上粟起，意欲饮水，反不渴者，服文蛤散；若不差者，与五苓散。寒实结胸，无热证者，与三物小陷胸汤，白散亦可服。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("142、太阳与少阳并病，头项强痛，或眩冒，时如结胸，心下痞硬者，当刺大椎第一间、肺俞、肝俞，慎不可发汗；<br>发汗则谵语，脉弦，五日谵语不止，当刺期门。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("143、妇人中风，发热恶寒，经水适来，得之七八日，热除而脉迟身凉，胸胁下满如结胸状，谵语者。<br>此为热入血室也。当刺期门，随其实而取之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("144、妇人中风七八日，续得寒热，发作有时，经水适断者，此为热入血室。<br>其血必结，故使如疟状，发作有时，小柴胡汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("145、妇人伤寒，发热，经水适来，昼日明了，暮则谵语如见鬼状者，此为热入血室。无犯胃气及上二焦，必自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("146、伤寒六七日，发热，微恶寒，支节烦疼，微呕，心下支结，外证未去者，柴胡桂枝汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("147、伤寒五六日，已发汗而复下之，胸胁满微结，小便不利，渴而不呕，但头汗出，往来寒热，心烦者，<br>此为未解也，柴胡桂枝干姜汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("148、伤寒五六日，头汗出，微恶寒，手足冷，心下满，口不欲食，大便硬，脉细者，此为阳微结，必有表，复有里也。<br>脉沉，亦在里也。汗出，为阳微。假令纯阴结，不得复有外证，悉入在里，此为半在里半在外也。<br>脉虽沉紧，不得为少阴病。所以然者，阴不得有汗，今头汗出，故知非少阴也。<br>可与小柴胡汤。设不了了者，得屎而解。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("149、伤寒五六日，呕而发热者，柴胡汤证具。而以他药下之，柴胡证仍在者，复与柴胡汤。<br>此虽已下之，不为逆，必蒸蒸而振，却发热汗出而解。<br>若心下满而硬痛者，此为结胸也，大陷胸汤主之；<br>但满而不痛者，此为痞，柴胡不中与之，宜半夏泻心汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("150、太阳少阳并病，而反下之，成结胸，心下硬，下利不止，水浆不下，其人心烦。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("151、脉浮而紧，而复下之，紧反入里则作痞。按之自濡，但气痞耳。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("152、太阳中风，下利呕逆，表解者，乃可攻之。<br>其人漐漐汗出，发作有时，头痛，心下痞硬满，引胁下痛，干呕短气，汗出不恶寒者，此表解里未和也。<br>十枣汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("153、太阳病，医发汗，遂发热恶寒，因复下之，心下痞，表里俱虚。阴阳气并竭，无阳则阴独，复加烧针，因胸烦，面色青黄。<br>肤瞤瞤者，难治。今色微黄，手足温者易愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("154、心下痞，按之濡，其脉关上浮者，大黄黄连泻心汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("155、心下痞，而复恶寒汗出者，附子泻心汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("156、本以下之，故心下痞，与泻心汤；痞不解，其人渴而口燥，烦，小便不利者，五苓散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("157、伤寒汗出，解之后，胃中不和，心下痞硬，干噫食臭，胁下有水气，腹中雷鸣，下利者，生姜泻心汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("158、伤寒中风，医反下之，其人下利日数十行，谷不化，腹中雷鸣，心下痞硬而满，干呕，心烦不得安。<br>医见心下痞，谓病不尽，复下之，其痞益甚。<br>此非结热，但以胃中虚，客气上逆，故使硬也。甘草泻心汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("159、伤寒，服汤药，下利不止，心下痞硬。服泻心汤已，复以他药下之，利不止。医以理中与之，利益甚。<br>理中者，理中焦，此利在下焦，赤石脂禹余粮汤主之。<br>复不止者，当利其小便。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("160、伤寒吐下后，发汗，虚烦，脉甚微，八九日心下痞硬，胁下痛，气上冲咽喉，眩冒，经脉动惕者，久而成痿。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("161、伤寒发汗，若吐，若下，解后，心下痞硬，噫气不除者，旋覆代赭汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("162、下后，不可更行桂枝汤；若汗出而喘，无大热者，可与麻黄杏子甘草石膏汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("163、太阳病，外证未除，而数下之，遂协热而利，利下不止，心下痞硬，表里不解者，桂枝人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("164、伤寒大下后，复发汗，心下痞，恶寒者，表未解也，不可攻痞，当先解表，表解乃可攻痞。<br>解表，宜桂枝汤，攻痞，宜大黄黄连泻心汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("165、伤寒发热，汗出不解，心中痞硬，呕吐而下利者，大柴胡汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("166、病如桂枝证，头不痛，项不强，寸脉微浮，胸中痞硬，气上冲喉咽不得息者，此为胸有寒也。当吐之。宜瓜蒂散。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("167、病胁下素有痞，连在脐旁，痛引少腹人阴筋者，此名藏结，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("168、伤寒，若吐、若下后，七八日不解，热结在里，表里俱热，时时恶风，大渴，舌上干燥而烦，欲饮水数升者，白虎加人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("169、伤寒，无大热，口燥渴，心烦，背微恶寒者，白虎加人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("170、伤寒，脉浮，发热无汗，其表不解，不可与白虎汤，渴欲饮水无表证者，白虎加人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("171、太阳少阳并病，心下硬，颈项强而眩者，当刺大椎、肺俞、肝俞。慎勿下之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("172、太阳与少阳合病，自下利者，与黄芩汤；若呕者，黄芩加半夏生姜汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("173、伤寒，胸中有热，胃中有邪气，腹中痛，欲呕吐者，黄连汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("174、伤寒八九日，风湿相搏，身体疼烦，不能自转侧，不呕不渴，脉浮虚而涩者，桂枝附子汤主之，<br>若其人大便硬，小便自利者，去桂加白术汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("175、风湿相搏，骨节疼烦，掣痛不得屈伸，近之则痛剧，汗出短气，小便不利，恶风不欲去衣，或身微肿者，甘草附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("176、伤寒，脉浮滑，此表有热，里有寒，白虎汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("177、伤寒，脉结代，心动悸，炙甘草汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("178、脉按之来缓，时一止复来者，名曰结。又脉来动而中止，更来小数，中有还者反动，名曰结，阴也。<br>脉来动而中止，不能自还，因而复动者，名曰代，阴也。得此脉者，必难治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("179、问曰：病有太阳阳明，有正阳阳明，有少阳阳明，何谓也？<br>答曰：太阳阳明者，脾约是也，正阳阳明者，胃家实是也；<br>少阳阳明者，发汗利小便已，胃中燥烦实，大便难是也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("180、阳明之为病，胃家实是也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("181、问曰：何缘得阳明病？<br>答曰：太阳病，若发汗，若下，若利小便，此亡津液，胃中干燥，因转属阳明，不更衣，内实，大便难者，此名阳明也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("182、问曰：阳明病外证云何？答曰：身热，汗自出，不恶寒反恶热也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("183、问曰：病有得之一日，不发热而恶寒者，何也？答曰：虽得之一日，恶寒将自罢，即自汗出而恶热也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("184、问曰：恶寒何故自罢？答曰：阳明居中主土也，万物所归，无所复传，始虽恶寒，二日自止，此为阳明病也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("185、本太阳，初得病时，发其汗，汗先出不彻，因转属阳明也。<br>伤寒发热无汗，呕不能食，而反汗出濈濈然者，是转属阳明也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("186、伤寒三日，阳明脉大。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("187、伤寒脉浮而缓，手足自温者，是为系在太阴。<br>太阴者，身当发黄，若小便自利者，不能发黄。<br>至七八日，大便硬者，为阳明病也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("188、伤寒转系阳明者，其人濈然微汗出也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("189、阳明中风，口苦咽干，腹满微喘，发热恶寒，脉浮而紧。若下之，则腹满，小便难也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("190、阳明病，若能食，名中风，不能食，名中寒。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("191、阳明病，若中寒者，不能食，小便不利，手足濈然汗出，此欲作固瘕，必大便初硬后溏。<br>所以然者，以胃中冷，水谷不别故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("192、阳明病，初欲食，小便反不利，大便自调，其人骨节疼，翕翕如有热状，奄然发狂，濈然汗出而解者，此水不胜谷气，与汗共并，脉紧则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("193、阳明病，欲解时，从申至戌上。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("194、阳明病，不能食，攻其热必哕。所以然者，胃中虚冷故也；以其人本虚，攻其热必哕。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("195、阳明病，脉迟，食难用饱，饱则微烦头眩，必小便难，此欲作谷瘅。虽下之，腹满如故，所以然者，脉迟故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("196、阳明病，法多汗，反无汗，其身如虫行皮中状者，此以久虚故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("197、阳明病，反无汗而小便利，二三日呕而咳，手足厥者，必苦头痛，若不咳，不呕，手足不厥者，头不痛。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("198、阳明病，但头眩，不恶寒，故能食而咳，其人咽必痛，若不咳者，咽不痛。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("199、阳明病无汗，小便不利，心中懊憹者，身必发黄。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("200、阳明病，被火，额上微汗出而小便不利者，必发黄。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("201、阳明病，脉浮而紧者，必潮热，发作有时，但浮者，必盗汗出。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("202、阳明病，口燥，但欲漱水不欲咽者，此必衄。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("203、阳明病，本自汗出，医更重发汗，病已差，尚微烦不了了者，此必大便硬故也。<br>以亡津液，胃中干燥，故令大便硬。<br>当问其小便日几行，若本小便日三四行，今日再行，故知大便不久出，<br>今为小便数少，以津液当还入胃中，故知不久必大便也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("204、伤寒呕多，虽有阳明证，不可攻之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("205、阳明病，心下硬满者，不可攻之，攻之利遂不止者死，利止者愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("206、阳明病，面合色赤，不可攻之。必发热，色黄者，小便不利也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("207、阳明病，不吐不下，心烦者，可与调胃承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("208、阳明病，脉迟，虽汗出，不恶寒者，其身必重，短气，腹满而喘；有潮热者，此外欲解，可攻里也。<br>手足濈然汗出者，此大便已硬也，大承气汤主之。<br>若汗多，微发热恶寒者，外未解也，其热不潮，未可与承气汤，<br>若腹大满不通者，可与小承气汤微和胃气，勿令至大泄下。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("209、阳明病，潮热，大便微硬者，可与大承气汤，不硬者，不可与之。<br>若不大便六七，恐有燥屎，欲知之法，少与小承气汤，汤入腹中，转矢气者，此有燥屎也，乃可攻之；<br>若不转矢气者，此但初头硬，后必溏，不可攻之，攻之必胀满不能食也。<br>欲饮水者，与水则哕。其后发热者，必大便复硬而少也，以小承气汤和之。<br>不转矢气者，慎不可攻也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("210、夫实则谵语，虚则郑声。郑声者，重语也。直视谵语，喘满者死，下利者亦死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("211、发汗多，重发汗者，亡其阳，谵语，脉短者死，脉自和者不死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("212、伤寒，若吐若下后，不解，不大便五六日，上至十余日，日晡所发潮热，不恶寒，独语如见鬼状。<br>若剧者，发则不识人，循衣摸床，惕而不安，微喘直视，脉弦者生，涩者死，微者，但发热谵语者，大承气汤主之。<br>若一服利，则止后服。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("213、阳明病，其人多汗，以津液外出，胃中燥，大便必硬，硬则谵语，小承气汤主之。若一服谵语止者，更莫复服。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("214、阳明病，谵语，发潮热，脉滑而疾者，小承气汤主之。因与承气汤一升，腹中转气者，更服一升。<br>若不转气者，勿更与之；明日又不大便，脉反微涩者，里虚也，为难治，不可更与承气汤也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("215、阳明病，谵语，有潮热，反不能食者，胃中必有燥屎五六枚也，若能食者，但硬耳，宜大承气汤下之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("216、阳明病，下血谵语者，此为热入血室，但头汗出者，刺期门，随其实而泻之，濈然汗出则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("217、汗出谵语者，以有燥屎在胃中，此为风也。须下者，过经乃可下之。<br>下之若早，语言必乱，以表虚里实故也。下之愈，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("218、伤寒四五日，脉沉而喘满，沉为在里。而反发其汗，津液越出，大便为难。表虚里实，久则谵语。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("219、三阳合病，腹满身重，难于转侧，口不仁面垢，谵语遗尿。<br>发汗则谵语，下之则额上生汗，手足逆冷。若自汗出者，白虎汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("220、二阳并病，太阳证罢，但发潮热，手足漐漐汗出，大便难而谵语者，下之则愈，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("221、阳明病，脉浮而紧，咽燥口苦，腹满而喘，发热汗出，不恶寒，反恶热，身重。<br>若发汗则躁，心愦愦反谵语，若加温针，必怵惕，烦躁不得眠，若下之，则胃中空虚，客气动膈，心中懊憹。<br>舌上胎者。栀子豉汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("222、若渴欲饮水，口干舌燥者，白虎加人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("223、若脉浮，发热，渴欲饮水，小便不利者，猪苓汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("224、阳明病，汗出多而渴者，不可与猪苓汤。以汗多胃中燥，猪苓汤复利其小便故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("225、脉浮而迟，表热里寒，下利清谷者，四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("226、若胃中虚冷，不能食者，饮水则哕。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("227、脉浮发热，口干鼻燥，能食者则衄。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("228、阳明病下之，其外有热，手足温，不结胸，心中懊憹，饥不能食，但头汗出者，栀子豉汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("229、阳明病，发潮热，大便溏，小便自可，胸胁满不去者，与小柴胡汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("230、阳明病，胁下硬满，不大便而呕，舌上白胎者，可与小柴胡汤。上焦得通，津液得下，胃气因和，身濈然汗出而解。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("231、阳明中风，脉弦浮大，而短气，腹都满，胁下及心痛，久按之气不通，鼻干，不得汗，嗜卧，一身及目悉黄，小便难，有潮热，时时哕，耳前后肿。<br>刺之小差，外不解。病过十日，脉续浮者，与小柴胡汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("232、脉但浮，无余证者，与麻黄汤；若不尿，腹满加哕者，不治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("233、阳明病，自汗出，若发汗，小便自利者，此为津液内竭，虽硬不可攻之，当须自欲大便，宜蜜煎导而通之。<br>若土瓜根及大猪胆汁，皆可为导。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("234、阳明病，脉迟，汗出多，微恶寒者，表未解也，可发汗，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("235、阳明病，脉浮，无汗而喘者，发汗则愈，宜麻黄汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("236、阳明病，发热汗出者，此为热越，不能发黄也；但头汗出，身无汗，剂颈而还，小便不利，渴引水浆者，此为瘀热在里，身必发黄，茵陈蒿汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("237、阳明证，其人喜忘者，必有蓄血。所以然者，本有久瘀血，故令喜忘。屎虽硬，大便反易，其色必黑者，宜抵当汤下之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("238、阳明病，下之，心中懊憹而烦，胃中有燥屎者，可攻。腹微满，初头硬，后必溏，不可攻之。若有燥屎者，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("239、病人不大便五六日，绕脐痛，烦躁，发作有时者，此有燥屎，故使不大便也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("240、病人烦热，汗出则解，又如疟状，日晡所发热者，属阳明也。<br>脉实者，宜下之；脉浮虚者，宜发汗。下之，与大承气汤，发汗，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("241、大下后，六七日不大便，烦不解，腹满痛者，此有燥屎也。所以然者，本有宿食故也。宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("242、病人小便不利，大便乍难乍易，时有微热，喘冒不能卧者，有燥屎也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("243、食谷欲呕，属阳明也，吴茱萸汤主之。得汤反剧者，属上焦也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("244、太阳病，寸缓关浮尺弱，其人发热汗出，复恶寒，不呕，但心下痞者，此以医下之也。<br>如其不下者，病人不恶寒而渴者，此转属阳明也。<br>小便数者，大便必硬，不更衣十日，无所苦也。<br>渴欲饮水，少少与之，但以法救之；渴者，宜五苓散。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("245、脉阳微而汗出少者，为自和也，汗出多者，为太过。<br>阳脉实因发其汗，出多者，亦为太过。太过者，为阳绝于里，亡津液，大便因硬也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("246、脉浮而芤，浮为阳，芤为阴。浮芤相搏，胃气生热，其阳则绝。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("247、跌阳脉浮而涩，浮则胃气强，涩则小便数。浮涩相搏，大便则硬，其脾为约。麻子仁丸主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("248、太阳病三日，发汗不解，蒸蒸发热者，属胃也。调胃承气汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("249、伤寒吐后，腹胀满者，与调胃承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("250、太阳病，若吐，若下、若发汗后，微烦，小便数，大便因硬者，与小承气汤和之愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("251、得病二三日，脉弱，无太阳柴胡证，烦躁，心下硬，至四五日，虽能食，以小承气汤少少与微和之，令小安，至六日，与承气汤一升。<br>若不大便六七日，小便少者，虽不受食，但初头硬，后必溏，未定成硬，攻之必溏。<br>须小便利，屎定硬，乃可攻之。宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("252、伤寒六七日，目中不了了，睛不和，无表里证，大便难，身微热者，此为实也。急下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("253、阳明病，发热汗多者，急下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("253、发汗不解，腹满痛者，急下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("255、腹满不减，减不足言，当下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("256、阳明少阳合病，必下利。其脉不负者，为顺也。<br>负者，失也，互相克贼，名为负也。脉滑而数者，有宿食也，当下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("257、病人无表里证，发热七八日，虽脉浮数者，可下之。<br>假令已下，脉数不解，合热则消谷喜饥，至六七日不大便者，有瘀血，宜抵当汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("258、若脉数不解，而下不止，必协热便脓血也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("259、伤寒发汗已，身目为黄。所以然者，以寒湿在里不解故也。以为不可下也，于寒湿中求之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("260、伤寒七八日，身黄如橘子色，小便不利，腹微满者，茵陈蒿汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("261、伤寒身黄，发热，栀子檗皮汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("262、伤寒瘀热在里，身必黄，麻黄连轺赤小豆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("263、少阳之为病，口苦，咽干，目眩也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("264、少阳中风，两耳无所闻，目赤，胸中满而烦者，不可吐下，吐下则悸而惊。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("265、伤寒，脉弦细，头痛发热者，属少阳。少阳不可发汗，发汗则谵语。此属胃，胃和则愈，胃不和，烦而悸。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("266、本太阳病不解，转入少阳者，胁下硬满，干呕不能食，往来寒热。尚未吐下，脉沉紧者，与小柴胡汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("267、若已吐、下、发汗、温针，谵语，柴胡汤证罢，此为坏病。知犯何逆，以法治之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("268、三阳合病，脉浮大，上关上，但欲眠睡，目合则汗。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("269、伤寒六七日，无大热，其人躁烦者，此为阳去入阴故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("270、伤寒三日，三阳为尽，三阴当受邪，其人反能食而不呕，此为三阴不受邪也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("271、伤寒五日，少阳脉小者，欲已也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("272、少阳病，欲解时，从寅至辰上。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("273、太阴之为病，腹满而吐，食不下，自利益甚，时腹自痛。若下之，必胸下结硬。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("274、太阴中风，四肢烦疼，脉阳微阴涩而长者，为欲愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("275、太阴病，欲解时，从亥至丑上。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("276、太阴病，脉浮者，可发汗，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("277、自利不渴者，属太阴，以其藏有寒故也。当温之，宜服四逆辈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("278、伤寒脉浮而缓，手足自温者，系在太阴。太阴当发身黄，若小便自利者，不能发黄。<br>至七八日，虽暴烦下利日十余行，必自止，以脾家实，腐秽当去故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("279、本太阳病，医反下之，因尔腹满时痛者，属太阴也，桂枝加芍药汤主之，大实痛者，桂枝加大黄汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("280、太阴为病，脉弱，其人续自便利，设当行大黄、芍药者，宜减之。以其人胃气弱，易动故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("281、少阴之为病，脉微细，但欲寐也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("282、少阴病，欲吐不吐，心烦，但欲寐，五六日自利而渴者，属少阴也，虚故引水自救；<br>若小便色白者，少阴病形悉具，小便白者，以下焦虚有寒，不能制水，故令色白也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("283、病人脉阴阳俱紧，反汗出者，亡阳也，此属少阴，法当咽痛而复吐利。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("284、少阴病，咳而下利，谵语者，被火气劫故也；小便必难，以强责少阴汗也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("285、少阴病，脉细沉数，病为在里，不可发汗。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("286、少阴病，脉微，不可发汗，亡阳故也，阳已虚，尺脉弱涩者，复不可下之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("287、少阴病，脉紧，至七八日，自下利，脉暴微，手足反温，脉紧反去者，为欲解也，虽烦，下利必自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("288、少阴病，下利，若利自止，恶寒而踡卧，手足温者，可治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("289、少阴病，恶寒而踡，时自烦，欲去衣被者，可治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("290、少阴中风，脉阳微阴浮者，为欲愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("291、少阴病，欲解时，从子至寅上。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("292、少阴病，吐利，手足不逆冷，反发热者，不死。脉不至者，灸少阴七壮。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("293、少阴病八九日，一身手足尽热者，以热在膀胱，必便血也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("294、少阴病，但厥无汗，而强发之，必动其血。未知从何道出，或从口鼻，或从目出者，是名下厥上竭，为难治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("295、少阴病，恶寒身踡而利，手足逆冷者，不治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("296、少阴病，吐利、躁烦、四逆者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("297、少阴病，下利止而头眩，时时自冒者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("298、少阴病，四逆，恶寒而身踡，脉不至，不烦而躁者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("299、少阴病，六七日，息高者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("300、少阴病，脉微细沉，但欲卧，汗出不烦，自欲吐。至五六日，自利，复烦躁不得卧寐者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("301、少阴病，始得之，反发热脉沉者，麻黄细辛附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("302、少阴病，得之二三日，麻黄附子甘草汤微发汗。以二三日无证，故微发汗也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("303、少阴病，得之二三日以上，心中烦，不得卧，黄连阿胶汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("304、少阴病，得之一二日，口中和，其背恶寒者，当灸之，附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("305、少阴病，身体痛，手足寒，骨节痛，脉沉者，附子汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("306、少阴病，下利，便脓血者，桃花汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("307、少阴病，二三日至四五日，腹痛，小便不利，下利不止，便脓血者，桃花汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("308、少阴病，下利，便脓血者，可刺。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("309、少阴病，吐利，手足逆冷，烦躁欲死者，吴茱萸汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("310、少阴病，下利，咽痛，胸满，心烦，猪肤汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("311、少阴病二三日，咽痛者，可与甘草汤；不差者，与桔梗汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("312、少阴病，咽中伤，生疮，不能语言，声不出者，苦酒汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("313、少阴病，咽中痛，半夏散及汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("314、少阴病，下利，白通汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("315、少阴病，下利，脉微者，与白通汤。利不止，厥逆无脉，干呕烦者，白通加猪胆汁汤主之。服汤，脉暴出者死，微续者生。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("316、少阴病，二三日不已，至四五日，腹痛，小便不利，四肢沉重疼痛，自下利者，此为有水气。<br>其人或咳，或小便利，或下利，或呕者，真武汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("317、少阴病，下利清谷，里寒外热，手足厥逆，脉微欲绝，身反不恶寒，其人面色赤。<br>或腹痛，或干呕，或咽痛，或利止脉不出者。通脉四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("318、少阴病，四逆，其人或咳，或悸，或小便不利，或腹中痛，或泄利下重者，四逆散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("319、少阴病，下利六七日，咳而呕渴，心烦不得眠者，猪苓汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("320、少阴病，得之二三日，口燥咽干者，急下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("321、少阴病，自利清水，色纯青，心下必痛，口干燥者，急下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("322、少阴病，六七日，腹胀不大便者，急下之，宜大承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("323、少阴病，脉沉者，急温之，宜四逆场。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("324、少阴病，饮食入口则吐，心中温温欲吐，复不能吐，始得之，手足寒，脉弦迟者，此胸中实，不可下也，当吐之；<br>若膈上有寒饮，干呕者，不可吐也。当温之，宜四逆汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("325、少阴病，下利，脉微涩，呕而汗出，必数更衣，反少者，当温其上，灸之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("326、厥阴之为病，消渴，气上撞心，心中疼热，饥而不欲食，食则吐蚘。下之，利不止。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("327、厥阴中风，脉微浮为欲愈，不浮为未愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("328、厥阴病，欲解时，从丑至卯上。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("329、厥阴病，渴欲饮水者，少少与之愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("330、诸四逆厥者，不可下之，虚家亦然。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("331、伤寒先厥，后发热而利者，必自止，见厥复利。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("332、伤寒始发热六日，厥反九日而利。凡厥利者，当不能食。<br>今反能食者，恐为除中。食以索饼，不发热者，知胃气尚在，必愈。<br>恐暴热来出而复去也，后三日脉之，其热续在者，期之旦日夜半愈。所以然者，本发热六日，厥反九日，复发热三日，并前六日，亦为九日，与厥相应。<br>故期之旦日夜半愈。后三日脉之而脉数，其热不罢者，此为热气有余，必发痈脓也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("333、伤寒脉迟六七日，而反与黄芩汤彻其热。脉迟为寒，今与黄芩汤复除其热，腹中应冷，当不能食，今反能食，此名除中。必死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("334、伤寒先厥后发热，下利必自止，而反汗出，咽中痛者，其喉为痹。<br>发热无汗，而利必自止，若不止，必便脓血，便脓血者，其喉不痹。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("335、伤寒一二日至四五日，厥者必发热，前热者后必厥，厥深者热亦深，厥微者热亦微。<br>厥应下之，而反发汗者，必口伤烂赤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("336、伤寒病，厥五日，热亦五日。设六日，当复厥，不厥者自愈。厥终不过五日，以热五日，故知自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("337、凡厥者，阴阳气不相顺接，便为厥。厥者，手足逆冷者是也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("338、伤寒，脉微而厥，至七八日肤冷，其人躁无暂安时者，此为藏厥，非蚘厥也。<br>蚘厥者，其人当吐蚘。今病者静，而复时烦者，此为藏寒。<br>蚘上入其膈，故烦，须臾复止，得食而呕又烦者，蚘闻食臭出。<br>其人常自吐蚘。蚘厥者，乌梅丸主之。又主久利。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("339、伤寒热少微厥，指头寒，嘿嘿不欲食，烦躁。<br>数日，小便利，色白者，此热除也，欲得食，其病为愈；若厥而呕，胸胁烦满者，其后必便血。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("340、病者手足厥冷，言我不结胸，小腹满，按之痛者，此冷结在膀胱关元也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("341、伤寒发热四日，厥反三日，复热四日，厥少热多者，其病当愈；四日至七日，热不除者，必便脓血。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("342、伤寒厥四日，热反三日，复厥五日，其病为进。寒多热少，阳气退，故为进也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("343、伤寒六七日，脉微，手足厥冷，烦躁，灸厥阴，厥不还者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("344、伤寒发热，下利厥逆，躁不得卧者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("345、伤寒发热，下利至甚，厥不止者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("346、伤寒六七日不利，便发热而利，其人汗出不止者，死，有阴无阳故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("347、伤寒五六日，不结胸，腹濡，脉虚复厥者，不可下。此亡血，下之，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("348、发热而厥，七日下利者，为难治。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("349、伤寒，脉促，手足厥逆，可灸之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("350、伤寒，脉滑而厥者，里有热，白虎汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("351、手足厥寒，脉细欲绝者，当归四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("352、若其人内有久寒者，宜当归四逆加吴茱萸生姜汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("353、大汗出，热不去，内拘急，四肢疼，又下利厥逆而恶寒者，四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("354、大汗，若大下利而厥冷者，四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("355、病人手足厥冷，脉乍紧者，邪结在胸中；心下满而烦，饥不能食者，病在胸中；当须吐之，宜瓜蒂散。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("356、伤寒厥而心下悸，宜先治水，当服茯苓甘草汤，却治其厥。不尔，水渍入胃，必作利也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("357、伤寒六七日，大下后，寸脉沉而迟，手足厥逆，下部脉不至，喉咽不利，唾脓血，泄利不止者，为难治。麻黄升麻汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("358、伤寒四五日，腹中痛，若转气下趣少腹者，此欲自利也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("359、伤寒，本自寒下，医反复吐下之，寒格，更逆吐下，若食入口即吐，干姜黄芩黄连人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("360、下利，有微热而渴，脉弱者，今自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("361、下利，脉数，有微热汗出，今自愈；设复紧，为未解。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("362、下利，手足厥冷，无脉者，灸之。不温，若脉不还，反微喘者，死；少阴负跌阳者为顺也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("363、下利，寸脉反浮数，尺中自涩者，必清脓血。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("364、下利清谷，不可攻表，汗出必胀满。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("365、下利，脉沉弦者，下重也；脉大者，为未止；脉微弱数者，为欲自止，虽发热，不死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("366、下利，脉沉而迟，其人面少赤，身有微热，下利清谷者，必郁冒汗出而解，病人必微厥。<br>所以然者，其面戴阳，下虚故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("367、下利，脉数而渴者，今自愈。设不差，必清脓血，以有热故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("368、下利后脉绝，手足厥冷，晬时脉还，手足温者生，脉不还者死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("369、伤寒下利，日十余行，脉反实者，死。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("370、下利清谷，里寒外热，汗出而厥者，通脉四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("371、热利，下重者，白头翁汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("372、下利腹胀满，身体疼痛者，先温其里，乃攻其表。温里，宜四逆汤；攻表，宜桂枝汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("373、下利，欲饮水者，以有热故也，白头翁汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("374、下利，谵语者，有燥屎也，宜小承气汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("375、下利后，更烦，按之心下濡者，为虚烦也，宜栀子豉汤。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("376、呕家，有痈脓者，不可治呕，脓尽自愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("377、呕而脉弱，小便复利，身有微热，见厥者难治。四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("378、干呕，吐涎沫，头痛者，吴茱萸汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("379、呕而发热者，小柴胡汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("380、伤寒大吐大下之，极虚，复极汗者，其人外气怫郁，复与之水，以发其汗，因得哕。所以然者，胃中寒冷故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("381、伤寒，哕而腹满，视其前后，知何部不利，利之则愈。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("382、问曰，病有霍乱者何？答曰：呕吐而利，此名霍乱。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("383、问曰：病发热，头痛，身疼，恶寒，吐利者，此属何病？答曰。此名霍乱。霍乱自吐下，又利止，复更发热也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("384、伤寒，其脉微涩者，本是霍乱，今是伤寒，却四五日，至阴经上，转入阴必利，本呕下利者，不可治也。<br>欲似大便，而反失气，仍不利者，此属阳明也，便必硬，十三日愈。所以然者，经尽故也。<br>下利后，当便硬，硬则能食者愈。<br>今反不能食，到后经中，颇能食，复过一经能食，过之一日当愈，不愈者，不属阳明也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("385、恶寒脉微而复利，利止亡血也，四逆加人参汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("386、霍乱，头痛发热，身疼痛，热多欲饮水者，五苓散主之，寒多不用水者，理中丸主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("387、吐利止而身痛不休者，当消息和解其外，宜桂枝汤小和之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("388、吐利汗出，发热恶寒，四肢拘急，手足厥冷者，四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("389、既吐且利，小便复利而大汗出，下利清谷，内寒外热，脉微欲绝者，四逆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("390、吐已，下断，汗出而厥，四肢拘急不解，脉微欲绝者，通脉四逆加猪胆汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("391、吐利发汗，脉平，小烦者，以新虚不胜谷气故也。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("392、伤寒阴阳易之为病，其人身体重，少气，少腹里急，或引阴中拘挛，热上冲胸，头重不欲举，眼中生花，膝胫拘急者，烧裈散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("393、大病差后，劳复者，枳实栀子豉汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("394、伤寒差以后，更发热，小柴胡汤主之。脉浮者，以汗解之；脉沉实者，以下解之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("395、大病差后，从腰以下有水气者，牡蛎泽泻散主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("396、大病差后，喜唾，久不了了，胸上有寒，当以丸药温之，宜理中丸。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("397、伤寒解后，虚羸少气，气逆欲吐，竹叶石膏汤主之。", null, 0);
    }else if (cd == i++) {
        aryRet[aryRet.length] = ddpyCreateCand("398、病人脉已解，而日暮微烦，以病新差，人强与谷，脾胃气尚弱，不能消谷，故令微烦。损谷则愈。", null, 0);
	}else{
		aryRet["Tip"] = "已超越仲景，无解。条文编号范围是 1～398，请回退再试";
	}

	return aryRet;
}


//ddpyResetCmd();
ddpyRegisterCommand("zj", "仲景条文...", "execZj", "请输入条文编号 1～398", "推广中医，为人民服务", "1");
ddpyRegisterCommand("fh", "符号...", "execFh", null, "淡定“i”模式——爱符号");
