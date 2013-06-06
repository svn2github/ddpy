// 符号输入用脚本例子，编码栏输入“ifh”时被调用
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

// 张仲景伤寒论条文例
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


// 神农本草例
function execBc(codes)
{
	var bFlg = false;
	var aryRet = new Array();
	var cd = codes.substring(2);

	if ( !cd.isBlank() ) {
		var oBc = getBcObject();

		for (var key in oBc) {
			if ( key == cd ){
				aryRet[aryRet.length] = ddpyCreateCand(oBc[key][1]);
				bFlg = true;
			}else if ( key.startWith(cd) ){
				aryRet[aryRet.length] = ddpyCreateCand(oBc[key][0], key.substring(cd.length));
				bFlg = true;
			}
		}
		
		if ( !bFlg ){
			aryRet["Tip"] = "你要的东东没找到，目前暂不支持别名，请回退后重新输入";
		}
	}

	return aryRet;
}

function getBcObject()
{
	var oBc = new Object();
	
    oBc["dsb"] = ["丹砂", "丹砂　味甘微寒，无毒。（上品）<br>　治身体五脏百病，养精神，安魂魄，益气，明目，杀精魅、邪恶鬼。久服通神明，不老，能化为汞"];
    oBc["ym"] = ["云母", "云母　味甘平。（上品）<br>　主身皮死肌，中风寒热，如在车船上，除邪气，安五脏，益子精，明目，久服轻身延年"];
    oBc["yq"] = ["玉泉", "玉泉　味甘平。（上品）<br>　主五脏百病。柔筋强骨，安魂魄，长肌肉，益气，久服耐寒暑，不饥渴，不老神仙"];
    oBc["szr"] = ["石钟乳", "石钟乳　味甘温。（上品）<br>　主咳逆上气，明目益精，安五脏，通百节，利九窍，下乳汁"];
    oBc["nsa"] = ["涅石", "涅石　味酸寒。（上品）<br>　主寒热泄利，白沃阴蚀，恶创，目痛，坚筋骨齿。炼饵服之，轻身、不老、增年"];
    oBc["xsa"] = ["硝石", "硝石　味苦寒。（上品）<br>　主五脏积热，胃张闭，涤去蓄结饮食，推陈致新，除邪气。炼之如膏，久服轻身"];
    oBc["px"] = ["朴硝", "朴硝　味苦寒。（上品）<br>　主百病，除寒热邪气，逐六腑积聚，结固留癖，能化七十二种石。炼饵服之，轻身神仙"];
    oBc["hsb"] = ["滑石", "滑石　味甘寒。（上品）<br>　主身热泄，女子乳难，癃闭。利小便，荡胃中积聚寒热，益精气。久服，轻身、耐饥、长年"];
    oBc["kq"] = ["空青", "空青　味甘寒。（上品）<br>　主眚盲耳聋。明目，利九窍，通血脉，养精神。久服，轻身、延年、不老"];
    oBc["cqq"] = ["曾青", "曾青　味酸小寒。（上品）<br>　主目痛，止泪，出风痹，利关节，通九窍，破症坚积聚。久服轻身，能化金铜"];
    oBc["yyl"] = ["禹余粮", "禹余粮　味甘寒。（上品）<br>　主咳逆，寒热烦满，下（痢）赤白，血闭症瘕，大热。炼饵服之，不饥、轻身、延年"];
    oBc["tyy"] = ["太乙余食", "太乙余食　味甘平。（上品）<br>　主咳逆上气，症瘕、血闭、漏下，余邪气。久服，耐寒暑、不饥，轻身、飞行千里、神仙"];
    oBc["bsy"] = ["白石英", "白石英　味甘微温。（上品）<br>　主消渴，阴痿不足，咳逆，胸膈间久寒，益气，除风湿痹。久服，轻身长年"];
    oBc["zsy"] = ["紫石英", "紫石英　味甘温。（上品）<br>　主心腹咳逆，邪气，补不足，女子风寒在子宫，绝孕十年无子。久服，温中、轻身、延年"];
    oBc["bqb"] = ["白青", "白青　味甘平。（上品）<br>　主明目，利九窍，耳聋，心下邪气，令人吐，杀诸毒、三虫。久服，通神明，轻身、延年、不老"];
    oBc["bqq"] = ["扁青", "扁青　味甘平。（上品）<br>　主目痛，明目，折跌，痈肿，金创不疗，破积聚，解毒瓦斯，利精神。久服轻身不老"];
    oBc["cp"] = ["菖蒲", "菖蒲　味辛温。（上品）<br>　主风寒湿痹，咳逆上气，开心孔，补五脏，通九窍，明耳目，出声音。久服，轻身、不忘、不迷或，延年"];
    oBc["jh"] = ["鞠华", "鞠华　味苦平。（上品）<br>　主风，头眩肿痛，目欲脱，泪出，皮肤死肌，恶风湿痹。久服，利血气，轻身、耐老、延年"];
    oBc["rs"] = ["人参", "人参　味甘微寒。（上品）<br>　主补五脏，安精神，定魂魄，止惊悸，除邪气，明目、开心、益智。久服轻身延年"];
    oBc["tmd"] = ["天门冬", "天门冬　味苦平。（上品）<br>　主诸暴风湿偏痹，强骨髓，杀三虫，去伏尸。久服轻身益气延年"];
    oBc["gc"] = ["甘草", "甘草　味甘平。（上品）<br>　主五脏六腑寒热邪气，坚筋骨，长肌肉，倍力，金创，解毒。久服轻身延年"];
    oBc["gdh"] = ["干地黄", "干地黄　味甘寒。（上品）<br>　主折跌绝筋，伤中，逐血痹，填骨髓，长肌肉，作汤，除寒热积聚，除痹，生者尤良。久服轻身不老"];
    oBc["za"] = ["术", "术　味苦温。（上品）<br>　主风寒湿痹、死肌、痉、疸。止汗，除热，消食，作煎饵。久服轻身延年不饥"];
    oBc["nqa"] = ["牛膝", "牛膝　味苦酸。（上品）<br>　主寒湿痿痹，四肢拘挛，膝痛不可屈伸，逐血气，伤热火烂，堕胎。久服轻身耐老"];
    oBc["cyz"] = ["充蔚子", "充蔚子　味辛微温。（上品）<br>　主明目益精，除水气。久服轻身，茎主瘾疹痒，可作浴汤"];
    oBc["nwa"] = ["女萎", "女萎　味甘平。（上品）<br>　主中风暴热，不能动摇，跌筋结肉，诸不足。久服，去面黑，好颜色、润泽，轻身不老"];
    oBc["fk"] = ["防葵", "防葵　味辛寒。（上品）<br>　主疝瘕肠泄，膀胱热结，溺不下。咳逆，温疟，癫痫，惊邪狂走。久服坚骨髓、益气轻身"];
    oBc["cha"] = ["柴胡", "柴胡　味苦平。（上品）<br>　主心腹，去肠胃中结气，饮食积聚，寒热邪气，推陈致新。久服轻身明目益精"];
    oBc["mmd"] = ["麦门冬", "麦门冬　味甘平。（上品）<br>　主心腹结气，伤中、伤饱，胃络脉绝，羸瘦短气。久服轻身不老不饥"];
    oBc["dha"] = ["独活", "独活　味苦平。（上品）<br>　主风寒所击，金疮，止痛，贲豚，痫痉，女子疝瘕。久服轻身耐老"];
    oBc["cqz"] = ["车前子", "车前子　味甘寒，无毒。（上品）<br>　主气癃，止痛，利水道小便，除湿痹。久服轻身耐老"];
    oBc["mxx"] = ["木香", "木香　味辛。（上品）<br>　主邪气，辟毒疫温鬼，强志。主淋露。久服，不梦寤魇寐"];
    oBc["sya"] = ["薯蓣", "薯蓣　味甘温。（上品）<br>　主伤中，补虚羸，除寒热邪气，补中，益气力，长肌肉。久服，耳目聪明，轻身不饥延年"];
    oBc["yyr"] = ["薏苡仁", "薏苡仁　味甘微寒。（上品）<br>　主筋急，拘挛不可屈神，风湿痹，下气。久服轻身益气。其根，下三虫"];
    oBc["zx"] = ["泽泻", "泽泻　味甘寒。（上品）<br>　主风寒湿痹，乳难。消水，养五脏，益气力，肥健。久服，耳目聪明，不饥、延、轻身，面生光，能行水上"];
    oBc["yza"] = ["远志", "远志　味苦温。（上品）<br>　主咳逆伤中，补不足，除邪气，利九窍，益智慧，耳目聪明，不忘，强志倍力。久服轻身不老"];
    oBc["ldd"] = ["龙胆", "龙胆　味苦涩。（上品）<br>　主骨间寒热，惊痫邪气，续绝伤，定五脏，杀蛊毒。久服益智不忘，轻身耐老"];
    oBc["xx"] = ["细辛", "细辛　味辛温。（上品）<br>　主咳逆，头痛脑动，百节拘挛，风湿。痹痛、死肌。久服明目、利九窍，轻身长年"];
    oBc["sha"] = ["石斛", "石斛　味甘平。（上品）<br>　主伤中，除痹，下气，补五脏虚劳、羸瘦，强阴。久服，浓肠胃、轻身延年"];
    oBc["bjt"] = ["巴戟天", "巴戟天　味辛微温。（上品）<br>　主大风邪气，阴痿不起，强筋骨，安五脏，补中"];
    oBc["by"] = ["白英", "白英　味甘寒。（上品）<br>　主寒热、八疽、消渴，补中益气。久服轻身延年"];
    oBc["bhb"] = ["白蒿", "白蒿　味甘平。（上品）<br>　主五脏邪气，风寒湿痹，补中益气，长毛发，令黑，疗心悬、少食、常饥。轻身、耳目聪明、不老"];
    oBc["cja"] = ["赤箭", "赤箭　味辛温。（上品）<br>　主杀鬼精物、蛊毒恶气。久服益气力，长阴肥健，轻身增年"];
    oBc["ylz"] = ["奄闾子", "奄闾子　味苦微寒。（上品）<br>　主五脏瘀血，腹中水气，胪张留热，风寒湿痹，身体诸痛。久服轻身延年不老"];
    oBc["xza"] = ["析子", "析子　味辛微温。（上品）<br>　主明目，目痛泪出，除痹，补五脏，益精光。久服轻身不老"];
    oBc["ssb"] = ["蓍实", "蓍实　味苦平。（上品）<br>　主益气，充肌肤，明目、聪慧、先知。久服不饥不老轻身"];
    oBc["cz"] = ["赤芝", "赤芝　味苦平。（上品）<br>　主胸中结，益心气，补中，增智慧，不忘。久食轻身不老、延年、神仙"];
    oBc["qz"] = ["青芝", "青芝　味酸平。（上品）<br>　主明目，补肝气，安精魂，仁恕，久食，轻身不老、延年、神仙"];
    oBc["bza"] = ["白芝", "白芝　味辛平。（上品）<br>　主咳逆上气，益肺气，通利口鼻，强志意，勇悍，安魄。久食，轻身不老、延年、神仙"];
    oBc["hza"] = ["黄芝", "黄芝　味甘平。（上品）<br>　主心腹五邪，益脾气，安神，忠信和乐。久食，轻身、不老、延年、神仙"];
    oBc["zzb"] = ["紫芝", "紫芝　味甘温。（上品）<br>　主耳聋，利关节，保神，益精气，坚筋骨，好颜色。久服轻身不老延年"];
    oBc["jb"] = ["卷柏", "卷柏　味辛温。（上品）<br>　主五脏邪气，女子阴中寒热痛，症瘕、血闭、绝子。久服轻身"];
    oBc["lsa"] = ["蓝实", "蓝实　味苦寒。（上品）<br>　主解诸毒，杀蛊、注鬼、螫毒。久服，头不白、轻身"];
    oBc["xa"] = ["芎", "芎　味辛温。（上品）<br>　主中风入脑，头痛，寒痹，筋挛缓急，金创，妇人血闭无子"];
    oBc["mw"] = ["蘼芜", "蘼芜　味辛温。（上品）<br>　主咳逆，定惊气，辟邪恶，除蛊毒鬼注，去三虫，久服通神"];
    oBc["hl"] = ["黄连", "黄连　味苦寒。（上品）<br>　主热气目痛、伤泣出，明目，肠，腹痛下利，妇人阴中肿痛。久服令人不忘"];
    oBc["lsb"] = ["络石", "络石　味苦温。（上品）<br>　主风热死肌痈伤，口干舌焦，痈肿不消，喉舌肿，水浆不下。久服轻身明目、润泽、好颜色，不老延年"];
    oBc["zlz"] = ["蒺藜子", "蒺藜子　味苦温。（上品）<br>　主恶血，破症结积聚，喉痹，乳难。久服长肌肉，明目轻身"];
    oBc["hqa"] = ["黄芪", "黄芪　味甘微温。（上品）<br>　主痈疽久败创，排脓止痛，大风，痢疾，五痔，鼠瘘，补虚，小儿百病"];
    oBc["rcr"] = ["肉松蓉", "肉松蓉　味甘微温。（上品）<br>　主五劳七伤，补中，除茎中寒热痛，养五脏，强阴，益精气，多子，妇人症瘕。久服轻身"];
    oBc["ff"] = ["防风", "防风　味苦温，无毒。（上品）<br>　主大风、头眩痛，恶风风邪，目盲无所见，风行周身，骨节疼痹(痛)，烦满。久服轻身"];
    oBc["ph"] = ["蒲黄", "蒲黄　味甘平。（上品）<br>　主心腹、膀胱寒热，利小便，止血，消瘀血。久服，轻身、益气力，延年、神仙"];
    oBc["xp"] = ["香蒲", "香蒲　味甘平。（上品）<br>　主五脏心下邪气，口中烂臭，坚齿，明目，聪耳。久服轻身耐老"];
    oBc["dxx"] = ["续断", "续断　味苦微温。（上品）<br>　主伤寒，补不足，金创痈伤，折跌，续筋骨，妇人乳难。久服，益气力"];
    oBc["lla"] = ["漏芦", "漏芦　味甘咸寒。（上品）<br>　主皮肤热、恶创、疽痔、湿痹，下乳汁。久服轻身益气，耳目聪明，不老延年"];
    oBc["ysb"] = ["营实", "营实　味酸温。（上品）<br>　主痈疽恶创，结肉跌筋，败创，热气，阴蚀不疗，利关节"];
    oBc["tmj"] = ["天名精", "天名精　味甘寒。（上品）<br>　主瘀血、血瘕欲死、下血。止血，利小便。久服轻身耐老"];
    oBc["jmz"] = ["决明子", "决明子　味咸平。（上品）<br>　主青盲、目淫、肤赤、白膜、眼赤痛、泪出。久服，益精光，轻身"];
    oBc["dsa"] = ["丹参", "丹参　味苦微寒。（上品）<br>　主心腹邪气，肠鸣幽幽如走水，寒热积聚；破症除瘕，止烦满，益气"];
    oBc["xgg"] = ["茜根", "茜根　味苦寒。（上品）<br>　主寒湿，风痹，黄胆，补中"];
    oBc["fla"] = ["飞廉", "飞廉　味苦平。（上品）<br>　主骨节热，胫重酸疼。久服，令人身轻"];
    oBc["wwz"] = ["五味子", "五味子　味酸温。（上品）<br>　主益气，咳逆上气，劳伤羸瘦。补不足，强阴，益男子精"];
    oBc["xhb"] = ["旋华", "旋华　味甘温。（上品）<br>　主益气，去面(黑)。其根味辛。主腹中寒热邪气，利小便。久服不饥轻身"];
    oBc["lcc"] = ["兰草", "兰草　味辛平。（上品）<br>　主利水道，杀蛊毒，辟不祥。久服，益气、轻身、不老、通神明"];
    oBc["scz"] = ["蛇床子", "蛇床子　味苦平。（上品）<br>　主妇人阴中肿痛，男子阳痿、湿痒，除痹气，利关节，癫痫恶创。久服轻身"];
    oBc["dfz"] = ["地肤子", "地肤子　味苦寒。（上品）<br>　主膀胱热，利小便，补中，益精气。久服，耳目聪明、轻身耐老"];
    oBc["jtt"] = ["景天", "景天　味苦平。（上品）<br>　主大热、火创、身热烦，邪恶气。花，主女人漏下赤白，轻身明目"];
    oBc["yc"] = ["茵陈", "茵陈　味苦平。（上品）<br>　主风湿寒热邪气，热结、黄胆。久服，轻身、益气、耐老"];
    oBc["dr"] = ["杜若", "杜若　味辛微温。（上品）<br>　主胸胁下逆气，温中，风入脑户，头肿痛，多涕泪出。久服益精、明目轻身"];
    oBc["ssa"] = ["沙参", "沙参　味苦微寒。（上品）<br>　主血积惊气，除寒热，补中，益肺气。久服利人"];
    oBc["bth"] = ["白兔藿", "白兔藿　味苦平。（上品）<br>　主蛇虺，蜂虿，狗，菜、肉、蛊毒"];
    oBc["xzq"] = ["徐长卿", "徐长卿　味辛温。（上品）<br>　主鬼物、百精、蛊毒，疫疾，邪恶气，温疟。久服，强悍、轻身"];
    oBc["slc"] = ["石龙刍", "石龙刍　味苦微寒。（上品）<br>　主心腹邪气，小便不利，淋闭，风湿，鬼注，恶毒。久服，补虚羸，轻身。耳目聪明，延年"];
    oBc["wx"] = ["薇衔", "薇衔　味苦平。（上品）<br>　主风湿痹、历节痛，惊痫、吐舌、悸气，贼风，鼠，痈肿"];
    oBc["ysc"] = ["云实", "云实　味辛温。（上品）<br>　主泄利肠，杀虫蛊毒，去邪恶结气，止痛、除热，平，主见鬼精物；多食，令人狂走。久服轻身通神明"];
    oBc["wbl"] = ["王不留行", "王不留行　味苦平。（上品）<br>　主金创，止血逐痛，出刺，除风痹内寒。久服轻身耐老增寿"];
    oBc["sma"] = ["升麻", "升麻　味甘辛(平)。（上品）<br>　主解百毒，杀百老物殃鬼，辟温疾、障邪毒蛊。久服不夭"];
    oBc["qxx"] = ["青蘘", "青蘘　味甘寒。（上品）<br>　主五脏邪气，风寒湿痹，益气，补脑髓，坚筋骨。久服，耳目聪明、不饥不老、增寿"];
    oBc["gh"] = ["姑活", "姑活　味甘温。（上品）<br>　主大风邪气，湿痹寒痛。久服，轻身、益寿、耐老"];
    oBc["bjd"] = ["别羁", "别羁　味苦微温。（上品）<br>　主风寒湿痹，身重，四肢疼酸，寒邪历节痛"];
    oBc["qca"] = ["屈草", "屈草　味苦。（上品）<br>　主胸胁下痛，邪气，腹间寒热阴痹。久服轻身益气耐老"];
    oBc["hma"] = ["淮木", "淮木　味苦平。（上品）<br>　主久咳上气，肠中虚羸，女子阴蚀、漏下赤白沃"];
    oBc["mga"] = ["牡桂", "牡桂　味辛温。（上品）<br>　主上气咳逆，结气，喉痹吐吸。利关节，补中益气。久服通神轻身不老"];
    oBc["jga"] = ["菌桂", "菌桂　味辛温。（上品）<br>　主百病，养精神，和颜色，为诸药先聘通使。久服，轻身、不老，面生光华，媚好常如童子"];
    oBc["szb"] = ["松脂", "松脂　味苦温。（上品）<br>　主疽，恶创，头疡，白秃，疥瘙风气。五脏，除热。久服轻身不老延年"];
    oBc["hsc"] = ["槐实", "槐实　味苦寒。（上品）<br>　主五内邪气热，止涎唾，补绝伤，五痔，火创，妇人乳瘕，子藏急痛"];
    oBc["bss"] = ["柏实", "柏实　味甘平。（上品）<br>　主惊悸，安五脏，益气，除湿痹。久服，令人悦泽美色，耳目聪明，不饥不老，轻身延年"];
    oBc["yp"] = ["榆皮", "榆皮　味甘平。（上品）<br>　主大小便不通，利水道，除邪气。久服轻身不饥"];
    oBc["sza"] = ["酸枣", "酸枣　味酸平。（上品）<br>　主心腹寒热，邪结气聚，四肢酸疼，湿痹。久服，安五脏，轻身延年"];
    oBc["mu"] = ["木", "木　味苦寒。（上品）<br>　主五脏、肠胃中结热，黄胆，肠痔，止泄利，女子漏下赤白，阴阳蚀创"];
    oBc["gq"] = ["干漆", "干漆　味辛温，无毒。（上品）<br>　主绝伤，补中，续筋骨，填髓脑，安五脏，五缓六急，风寒湿痹。生漆，去长虫。久服轻身耐老"];
    oBc["wjp"] = ["五加皮", "五加皮　味辛温。（上品）<br>　主心腹疝气，腹痛，益气疗，小儿不能行，疸创阴蚀"];
    oBc["mjs"] = ["蔓荆实", "蔓荆实　味苦微寒。（上品）<br>　主筋骨间寒热痹、拘挛，明目坚齿，利九窍，去白虫。久服轻身耐老，小荆实亦等"];
    oBc["xy"] = ["辛夷", "辛夷　味辛温。（上品）<br>　主五脏身体寒风，头脑痛，面。久服下气、轻身、明目、增年、耐老"];
    oBc["ssj"] = ["桑上寄生", "桑上寄生　味苦平。（上品）<br>　主腰痛，小儿背强，痈肿，安胎，充肌肤，坚发齿，长须眉。其实，明目轻身通神"];
    oBc["dzb"] = ["杜仲", "杜仲　味辛平。（上品）<br>　主腰脊痛，补中，益精气，坚筋骨，强志，除阴下痒湿，小便余沥。久服轻身耐老"];
    oBc["nzs"] = ["女贞实", "女贞实　味苦平。（上品）<br>　主补中，安五脏，养精神，除百疾。久服肥健轻身不老"];
    oBc["mld"] = ["木兰", "木兰　味苦寒。（上品）<br>　主身大热在皮肤中，去面热、赤、酒，恶风疾，阴下痒湿。明耳目"];
    oBc["rha"] = ["蕤核", "蕤核　味甘温。（上品）<br>　主心腹邪气，明目，目赤痛伤泪出。久服轻身益气不饥"];
    oBc["jy"] = ["橘柚", "橘柚　味辛温。（上品）<br>　主胸中瘕热逆气，利水谷。久服去臭下气通神"];
    oBc["fa"] = ["发", "发　味苦温。（上品）<br>　主五癃，关格不通，利小便水道，疗小儿痫、大人痉，仍自还神化"];
    oBc["lga"] = ["龙骨", "龙骨　味甘平。（上品）<br>　主心腹鬼注，精物老魁，咳逆，泄利脓血，女子漏下症瘕坚结，小儿热气惊痫。<br>　齿∶主小儿、大人惊痫疾狂走，心下结气，不能喘息，诸痉，杀精物。久服，轻身、通神明、延年"];
    oBc["sxa"] = ["麝香", "麝香　味辛温。（上品）<br>　主辟恶气，杀鬼精物，温疟，蛊毒，痫痉，去三虫。久服除邪，不梦寤厌寐"];
    oBc["nh"] = ["牛黄", "牛黄　味苦平。（上品）<br>　主惊痫，寒热热盛狂痉，除邪逐鬼"];
    oBc["xzb"] = ["熊脂", "熊脂　味甘微寒。（上品）<br>　主风痹不仁，筋急，五脏腹中积聚，寒热羸瘦，头疡白秃，面。久服强志不饥轻身"];
    oBc["bje"] = ["白胶", "白胶　味甘平。（上品）<br>　主伤中劳绝，腰痛，羸瘦，补中益气，女人血闭无子，止痛、安胎。久服轻身延年"];
    oBc["aj"] = ["阿胶", "阿胶　味甘平。（上品）<br>　主心腹内崩，劳极，洒洒如疟状，腰腹痛，四肢酸疼，女子下血，安胎。久服轻身益气"];
    oBc["dxj"] = ["丹雄鸡", "丹雄鸡　味甘微温。（上品）<br>　主女人崩中漏下，赤白沃，补虚温中，止血，通神，杀毒，辟不祥"];
    oBc["yf"] = ["雁肪", "雁肪　味甘平。（上品）<br>　主风挛拘急，偏枯，气不通利。久服益气不饥轻身耐老"];
    oBc["smb"] = ["石蜜", "石蜜　味甘平。（上品）<br>　主心腹邪气，诸惊痉痫，安五脏，诸不足，益气补中，止痛解毒，除众病，和百药。久服强志轻身不饥不老"];
    oBc["fzb"] = ["蜂子", "蜂子　味甘平。（上品）<br>　主风头，除蛊毒，补虚羸伤中。久服，令人光泽、好颜色，不老"];
    oBc["mlc"] = ["蜜蜡", "蜜蜡　味甘微温。（上品）<br>　主下利脓血，补中，续绝伤金创。益气、不饥、耐老"];
    oBc["mla"] = ["牡蛎", "牡蛎　味咸平。（上品）<br>　主伤寒寒热，温疟洒洒，惊恚怒气，除拘缓鼠，女子带下赤白。久服强骨节杀邪气延年"];
    oBc["gjb"] = ["龟甲", "龟甲　味咸平。（上品）<br>　主漏下赤白，破症瘕、疟，五痔、阴蚀，湿痹，四肢重弱，小儿囟不合。久服轻身不饥"];
    oBc["spx"] = ["桑螵蛸", "桑螵蛸　味咸平。（上品）<br>　主伤中，疝瘕，阴痿，益精生子，女子血闭腰痛，通五淋，利小便水道"];
    oBc["hha"] = ["海蛤", "海蛤　味苦平。（上品）<br>　主咳逆上气，喘息烦满，胸痛寒热"];
    oBc["wh"] = ["文蛤", "文蛤　（上品）<br>　主恶疮，蚀（《御览》作除阴蚀）五痔"];
    oBc["lyd"] = ["鲤鱼胆", "鲤鱼胆　味苦寒。（上品）<br>　主目热赤痛青盲，明目。久服，强悍、益志气志气"];
    oBc["osj"] = ["藕实茎", "藕实茎　味甘平。（上品）<br>　主补中养神，益气力，除百疾。久服轻身耐老不饥延年"];
    oBc["dza"] = ["大枣", "大枣　味甘平。（上品）<br>　主心腹邪气，安中养脾，肋十二经，平胃气，通九窍，补少气、少津液、身中不足，大惊，四肢重，和百药。久服轻身长年"];
    oBc["pt"] = ["葡萄", "葡萄　味甘平。（上品）<br>　主筋骨湿痹，益气、倍力、强志，令人肥健、耐饥、忍风寒。久食轻身不老延年"];
    oBc["pl"] = ["蓬蔂", "蓬蔂　味酸平。（上品）<br>　主安五脏，益精气，长阴令坚，强志倍力，有子。久服轻身不老"];
    oBc["jts"] = ["鸡头实", "鸡头实　味苦平。（上品）<br>　主湿痹，腰脊膝痛，补中，除暴疾，益精气，强志，令耳目聪明。久服轻身不饥耐老神仙"];
    oBc["hmb"] = ["胡麻", "胡麻　味甘平。（上品）<br>　主伤中虚羸，补五内（《御览》作脏），益气力，长肌肉，填髓脑。久服轻身不老"];
    oBc["mb"] = ["麻贲", "麻贲　味辛平。（上品）<br>　主五劳七伤，利五脏，下血，寒气。多食，令人见鬼狂走。久服通神明轻身"];
    oBc["dk"] = ["冬葵子", "冬葵子　味甘寒。（上品）<br>　主五脏六腑寒热、羸瘦、五癃，利小便。久服坚骨长肌肉轻身"];
    oBc["xsb"] = ["苋实", "苋实　味甘寒。（上品）<br>　主青盲，明目，除邪，利大小便，去寒热。久服益气力不饥轻身"];
    oBc["gdd"] = ["瓜蒂", "瓜蒂　味苦寒。（上品）<br>　主大水身面四肢浮肿，下水，杀蛊毒，咳逆上气，及食诸果，病在胸腹中，皆吐下之"];
    oBc["gza"] = ["瓜子", "瓜子　味甘平。（上品）<br>　主令人阅泽，好颜色，益气不饥。久服轻身耐老"];
    oBc["kc"] = ["苦菜", "苦菜　味苦寒。（上品）<br>　主五脏邪气，厌谷，胃痹。久服，安心益气，聪察少卧，轻身耐老"];
    oBc["xha"] = ["雄黄", "雄黄　味苦平、寒。（中品）<br>　主寒热，鼠恶创，疽痔死肌，杀精物、恶鬼、邪气、百虫毒，胜五兵。炼食之，轻身神仙"];
    oBc["slh"] = ["石流黄", "石流黄　味酸温。（中品）<br>　主妇人阴蚀，痈痔恶血，坚筋骨，除头秃，能化金银铜铁奇物"];
    oBc["chb"] = ["雌黄", "雌黄　味辛平。（中品）<br>　主恶创头秃痂疥，杀毒虫虱，身痒，邪气、诸毒。炼之。久服，轻身、增年、不老"];
    oBc["syc"] = ["水银", "水银　味辛寒。（中品）<br>　主疥痂疡、白秃，杀皮肤中虱，堕胎，除热，杀金、银、铜、锡毒。熔化还复为丹，久服神仙不死"];
    oBc["sga"] = ["石膏", "石膏　味辛微寒。（中品）<br>　主中风寒热，心下逆气惊喘，口干苦焦，不能息，腹中坚痛，除邪鬼，产乳，金创"];
    oBc["csa"] = ["磁石", "磁石　味辛寒。（中品）<br>　主周痹风湿，肢节中痛，不可持物，洗洗酸消，除大热烦满及耳聋"];
    oBc["nss"] = ["凝水石", "凝水石　味辛寒。（中品）<br>　主身热，腹中积聚、邪气，皮中如火烧，烦满。水饮之，久服，不饥"];
    oBc["yn"] = ["殷孽", "殷孽　味辛温。（中品）<br>　主烂伤瘀血，泄利寒热，鼠寒，症瘕结气"];
    oBc["tj"] = ["铁精", "铁精　平。（中品）<br>　主明目，化铜。铁落∶味辛平。主风热恶创，疡疽创痂，疥气在皮肤中"];
    oBc["lsc"] = ["理石", "理石　味辛寒。（中品）<br>　主身热，利胃解烦，益精明目，破积聚，去三虫"];
    oBc["csc"] = ["长石", "长石　味辛寒。（中品）<br>　主身热，四肢寒厥，利小便，通血脉，明目，去翳眇，下三虫，杀蛊毒。久服，不饥"];
    oBc["fq"] = ["肤青", "肤青　味辛平。（中品）<br>　主蛊毒及蛇、菜、肉诸毒，恶创"];
    oBc["gja"] = ["干姜", "干姜　味辛温。（中品）<br>　主胸满咳逆上气，温中止血，出汗，逐风湿痹，肠，下利。生者，尤良。久服，去臭气、通神明"];
    oBc["es"] = ["耳实", "耳实　味甘温。（中品）<br>　主风头寒痛，风湿周痹，四肢拘挛痛，恶肉死肌。久服益气，耳目聪明，强志轻身"];
    oBc["gg"] = ["葛根", "葛根　味甘平。（中品）<br>　主消渴，身大热，呕吐，诸痹，起阴气，解诸毒，葛谷，主下利十岁以上"];
    oBc["klg"] = ["栝蒌根", "栝蒌根　味苦寒。（中品）<br>　主消渴，身热烦满，大热，补虚安中，续绝伤"];
    oBc["ks"] = ["苦参", "苦参　味苦寒。（中品）<br>　主心腹结气，症瘕积聚，黄胆，溺有余沥，逐水，除痈肿，补中明目，止泪"];
    oBc["dg"] = ["当归", "当归　味甘温。（中品）<br>　主咳逆上气，温疟、寒热，洗在皮肤中，妇人漏下绝子，诸恶创疡、金创"];
    oBc["mh"] = ["麻黄", "麻黄　味苦温。（中品）<br>　主中风，伤寒头痛，温疟，发表出汗，去邪热气，止咳逆上气，除寒热，破症坚积聚"];
    oBc["tc"] = ["通草", "通草　味辛平。（中品）<br>　主去恶虫，除脾胃寒热，通利九窍、血脉、关节，令人不忘"];
    oBc["syb"] = ["芍药", "芍药　味苦平。（中品）<br>　主邪气腹痛，除血痹，破坚积、寒热、疝瘕，止痛，利小便，益气"];
    oBc["lsd"] = ["蠡实", "蠡实　味甘平。（中品）<br>　主皮肤寒热，胃中热气，寒湿痹，坚筋骨，令人嗜食。久服，轻身。花、叶∶去白虫"];
    oBc["qm"] = ["瞿麦", "瞿麦　味苦寒。（中品）<br>　主关格，诸癃结，小便不通，出刺，决痈肿，明目去翳，破胎堕子，下闭血"];
    oBc["ysa"] = ["元参", "元参　味苦微寒。（中品）<br>　主腹中寒热积聚，女子产乳余疾，补肾气，令人目明"];
    oBc["qj"] = ["秦艽", "秦艽　味苦平。（中品）<br>　主寒热邪气，寒湿，风痹，肢节痛，下水，利小便"];
    oBc["bha"] = ["百合", "百合　味甘平。（中品）<br>　主邪气腹张，心痛，利大小便，补中益气"];
    oBc["zm"] = ["知母", "知母　味苦寒。（中品）<br>　主消渴热中，除邪气，肢体浮肿，下水，补不足，益气"];
    oBc["bma"] = ["贝母", "贝母　味辛平。（中品）<br>　主伤寒烦热，淋沥，邪气，疝瘕，喉痹，乳难，金创，风痉"];
    oBc["bzb"] = ["白芷", "白芷　味辛温。（中品）<br>　主女人漏下赤白，血闭，阴肿，寒热，风头侵目泪出。长肌肤，润泽，可作面脂"];
    oBc["yyh"] = ["淫羊藿", "淫羊藿　味辛寒。（中品）<br>　主阳痿绝伤，茎中痛，利小便，益气力，强志"];
    oBc["hqb"] = ["黄芩", "黄芩　味苦平。（中品）<br>　主诸热黄胆，肠泄利，逐水，下血闭，恶创，恒蚀火疡"];
    oBc["gjc"] = ["狗脊", "狗脊　味苦平。（中品）<br>　主腰背，强关机，缓急，周痹寒湿，膝痛。颇利老人"];
    oBc["slr"] = ["石龙芮", "石龙芮　味苦平。（中品）<br>　主风寒湿痹，心腹邪气，利关节，止烦满。久服，轻身、明目、不老"];
    oBc["mgb"] = ["茅根", "茅根　味甘寒。（中品）<br>　主劳伤虚羸，补中益气，除瘀血、血闭、寒热，利小便。其苗，主下水"];
    oBc["zwa"] = ["紫菀", "紫菀　味苦温。（中品）<br>　主咳逆上气，胸中寒热结气，去蛊毒、痿蹷，安五藏"];
    oBc["zca"] = ["紫草", "紫草　味苦寒。（中品）<br>　主心腹邪气，五疸，补中益气，利九窍，通水道"];
    oBc["bjf"] = ["败酱", "败酱　味苦平。（中品）<br>　主暴热火创、赤气，疥瘙，疸痔，马鞍热气"];
    oBc["bxb"] = ["白藓", "白藓　味苦寒。（中品）<br>　主头风，黄胆，咳逆，淋沥，女子阴中肿痛，湿痹死肌，不可屈伸起止行步"];
    oBc["sja"] = ["酸酱", "酸酱　味酸平。（中品）<br>　主热烦满，定志益气，利水道。产难，吞其实立产"];
    oBc["zsb"] = ["紫参", "紫参　味苦辛，寒。（中品）<br>　主心腹积聚，寒热邪气，通九窍，利大小便"];
    oBc["gb"] = ["藁本", "藁本　味辛温。（中品）<br>　主妇人疝瘕，阴中寒、肿痛，腹中急，除风头痛，长肌肤，悦颜色"];
    oBc["sw"] = ["石苇", "石苇　味苦平。（中品）<br>　主劳热邪气，五癃闭不通，利小便水道"];
    oBc["bxc"] = ["萆薢", "萆薢　味苦平。（中品）<br>　主腰背痛，强骨节，风寒湿、周痹，恶创不瘳，热气"];
    oBc["bw"] = ["白薇", "白薇　味苦平。（中品）<br>　主暴中风，身热肢满，忽忽不知人，狂惑，邪气，寒热酸，温疟洗洗，发作有时"];
    oBc["spp"] = ["水萍", "水萍　味辛寒。（中品）<br>　主暴热身痒，下水气，胜酒，长须发，消渴。久服轻身"];
    oBc["wgb"] = ["王瓜", "王瓜　味苦寒。（中品）<br>　主消渴内痹瘀血，月闭，寒热，酸疼，益气，俞聋"];
    oBc["dy"] = ["地榆", "地榆　味苦微寒。（中品）<br>　主妇人乳痛，七伤、带下病，止痛，除恶肉，止汗，疗金创"];
    oBc["hzb"] = ["海藻", "海藻　味苦寒。（中品）<br>　主瘿瘤气，颈下核，破散结气、痈肿、症瘕、坚气，腹中上下鸣，下十二水肿"];
    oBc["zlb"] = ["泽兰", "泽兰　味苦微温。（中品）<br>　主乳妇内衄，中风余疾，大腹水肿，身面四肢浮肿，骨节中水，金创、痈肿、创脓"];
    oBc["fj"] = ["防己", "防己　味辛平。（中品）<br>　主风寒温疟，热气诸痈，除邪，利大小便"];
    oBc["kdh"] = ["款冬花", "款冬花　味辛温。（中品）<br>　主咳逆上气，善喘、喉痹，诸惊痫，寒热邪气"];
    oBc["mda"] = ["牡丹", "牡丹　味苦辛，寒。（中品）<br>　主寒热，中风、螈、痉，惊痫邪气，除症坚，瘀血留舍肠胃，安五脏，疗痈创"];
    oBc["mxh"] = ["马先蒿", "马先蒿　味平。（中品）<br>　主寒热鬼注，中风湿痹，女子带下病，无子"];
    oBc["jxc"] = ["积雪草", "积雪草　味苦寒。（中品）<br>　主大热，恶创，痈疽，浸淫赤，皮肤赤，身热"];
    oBc["nwb"] = ["女菀", "女菀　味辛温。（中品）<br>　主风寒洗洗，霍乱泄痢，肠鸣上下无常处，惊痫，寒热百疾"];
    oBc["ws"] = ["王孙", "王孙　味苦平。（中品）<br>　主五脏邪气，寒湿痹，四肢疼酸，膝冷痛"];
    oBc["syq"] = ["蜀羊泉", "蜀羊泉　味苦微寒。（中品）<br>　主头秃恶创，热气疥，瘙痂，癣虫，疗龋齿"];
    oBc["jca"] = ["爵床", "爵床　味咸寒。（中品）<br>　主腰脊痛，不得着床，俯仰艰难，除热，可作浴汤"];
    oBc["js"] = ["假苏", "假苏　味辛温。（中品）<br>　主寒热鼠，瘰生创，破结聚气，下瘀血，除湿痹"];
    oBc["sgb"] = ["桑根白皮", "桑根白皮　味甘寒。（中品）<br>　主伤中、五劳六极、羸瘦，崩中脉绝，补虚益气"];
    oBc["zy"] = ["竹叶", "竹叶　味苦平。（中品）<br>　主咳逆上气溢，筋急恶疡，杀小虫"];
    oBc["wzya"] = ["吴茱萸", "吴茱萸　味辛温。（中品）<br>　主温中，下气，止痛，咳逆，寒热，除湿、血痹，逐风邪，开凑理。根∶杀三虫"];
    oBc["zza"] = ["栀子", "栀子　味苦寒。（中品）<br>　主五内邪气，胃中热气，面赤、酒泡、鼻，白赖、赤癞，创疡"];
    oBc["wyb"] = ["芜荑", "芜荑　味辛。（中品）<br>　主五内邪气，散皮肤骨节中淫淫温行毒，去三虫，化食"];
    oBc["zsa"] = ["枳实", "枳实　味苦寒。（中品）<br>　主大风在皮肤中，如麻豆苦痒。除寒热结，止利。长肌肉，利五脏，益气、轻身"];
    oBc["np"] = ["浓朴", "浓朴　味苦温。（中品）<br>　主中风、伤寒、头痛、寒热，惊悸气，血痹死肌，去三虫"];
    oBc["qp"] = ["秦皮", "秦皮　味苦微寒。（中品）<br>　主风寒湿痹，洗洗寒气，除热，目中青翳、白膜。久服，头不白、轻身"];
    oBc["qs"] = ["秦菽", "秦菽　味辛温。（中品）<br>　主风邪气，温中，除寒痹，坚齿发、明目。久服，轻身、好颜色、耐老、增年、通神"];
    oBc["zwb"] = ["紫葳", "紫葳　味酸微寒。（中品）<br>　主妇人产乳余疾，崩中，症瘕血闭，寒热羸瘦，养胎"];
    oBc["zla"] = ["猪苓", "猪苓　味甘平。（中品）<br>　主疟，解毒蛊注不祥，利水道。久服，轻身、耐老"];
    oBc["bjg"] = ["白棘", "白棘　味辛寒。（中品）<br>　主心腹痛，痈肿渍脓，止痛"];
    oBc["lya"] = ["龙眼", "龙眼　味甘平。（中品）<br>　主五脏邪气，安志厌食。久服，强魂、聪明、轻身、不老，通神明"];
    oBc["sgc"] = ["松罗", "松罗　味苦平。（中品）<br>　主嗔怒邪气，止虚汗、头风，女子阴寒、肿病"];
    oBc["wm"] = ["卫矛", "卫矛　味苦寒。（中品）<br>　主女子崩中下血，腹满汗出，除邪，杀鬼毒、虫注"];
    oBc["hhb"] = ["合欢", "合欢　味甘平。（中品）<br>　主安五脏，利心志。令人献乐无忧。久服，轻身、明目、所欲"];
    oBc["bmj"] = ["白马茎", "白马茎　味咸平。（中品）<br>　主伤中脉绝，阴不起，强志益气，长肌肉，肥健，生子"];
    oBc["lra"] = ["鹿茸", "鹿茸　味甘温。（中品）<br>　主漏下恶血，寒热，惊痫，益气强志，生齿不老。角，主恶创痈肿，逐邪恶气，留血在阴中"];
    oBc["nj"] = ["牛角", "牛角　（中品）<br>　下闭血，瘀血疼痛，女人带下血。髓∶补中，填骨髓。久服，增年"];
    oBc["gyj"] = ["羖羊角", "羖羊角　味咸温。（中品）<br>　主青盲，明目，杀疥虫，止寒泄，辟恶鬼虎野狼，止惊悸。久服，安心、益气、轻身"];
    oBc["mgyj"] = ["牡狗阴茎", "牡狗阴茎　味咸平。（中品）<br>　主伤中，阴痿不起，令强、热、大、生子，除女子带下十二疾"];
    oBc["lyj"] = ["羚羊角", "羚羊角　味咸寒。（中品）<br>　主明目，益气，起阴，去恶血注下，辟蛊毒恶鬼不祥，安心气，常不大厌寐"];
    oBc["xj"] = ["犀角", "犀角　味苦寒。（中品）<br>　主百毒虫注，邪鬼、障气，杀钩吻、鸩羽、蛇毒，除不迷或厌寐。久服轻血"];
    oBc["ysd"] = ["燕屎", "燕屎　味辛平。（中品）<br>　主蛊毒鬼注，逐不祥邪气，破五癃，利小便"];
    oBc["tss"] = ["天鼠屎", "天鼠屎　味辛寒。（中品）<br>　主面痈肿，皮肤洗洗时痛，肠中血气，破寒热积聚，除惊悸"];
    oBc["wp"] = ["猥皮", "猥皮　味苦平。（中品）<br>　主五痔阴蚀，下血赤白五色，血汁不止，阴肿、痛引要背"];
    oBc["lff"] = ["露蜂房", "露蜂房　味苦平。（中品）<br>　主惊痫，寒热邪气，疾，鬼精蛊毒，肠痔。火熬之，良"];
    oBc["bja"] = ["鳖甲", "鳖甲　味咸平。（中品）<br>　主心腹症瘕坚积、寒热，去痞、息肉、阴蚀、痔、恶肉"];
    oBc["xie"] = ["蟹", "蟹　味咸寒。（中品）<br>　主胸中邪气、热结痛，僻而肿。败漆烧之，致鼠"];
    oBc["zcb"] = ["柞蝉", "柞蝉　味咸寒。（中品）<br>　主小儿惊痫、夜啼，病，寒热"];
    oBc["qcc"] = ["蛴螬", "蛴螬　味咸微温。（中品）<br>　主恶血、血瘀，痹气，破折、血在胁下坚满痛，月闭，目中淫肤，青翳白膜"];
    oBc["wzyg"] = ["乌贼鱼骨", "乌贼鱼骨　味咸微温。（中品）<br>　主女子漏下赤白经汁，血闭，阴蚀肿痛，寒热症瘕，无子"];
    oBc["bjc"] = ["白僵蚕", "白僵蚕　味咸。（中品）<br>　主小儿惊痫夜啼，去三虫，减黑，令人面色好，男子阴疡病"];
    oBc["yj"] = ["鱼甲", "鱼甲　味辛微温。（中品）<br>　主心腹症瘕、伏坚、积聚、寒热，女子崩中，下血五色，小腹阴中相引痛，创疥死肌"];
    oBc["cjb"] = ["樗鸡", "樗鸡　味苦平。（中品）<br>　主心腹邪气，阴痿，益精强志，生子，好色、补中、轻身"];
    oBc["ky"] = ["蛞蝓", "蛞蝓　味咸寒。（中品）<br>　主贼风僻，轶筋及脱肛，惊痫挛缩"];
    oBc["slz"] = ["石龙子", "石龙子　味咸寒。（中品）<br>　主五癃邪结气，破石淋，下血，利小便水道"];
    oBc["mmm"] = ["木虻", "木虻　味苦平。（中品）<br>　主目赤痛，伤泪出，瘀血血闭，寒热酸，无子"];
    oBc["fm"] = ["蜚虻", "蜚虻　味苦微寒。（中品）<br>　主逐瘀血，破下血积、坚痞症瘕、寒热，通利血脉及九窍"];
    oBc["flb"] = ["蜚廉", "蜚廉　味咸寒。（中品）<br>　主血瘀、症坚、寒热，破积聚，喉咽痹，内寒，无子"];
    oBc["zcc"] = ["蟅虫", "蟅虫　味咸寒。（中品）<br>　主心腹寒热洗洗，血积症瘕，破坚，下血闭，生子大良"];
    oBc["fy"] = ["伏翼", "伏翼　味咸平。（中品）<br>　主目瞑，明目，夜视有精光。久服，令人喜乐，媚好无忧"];
    oBc["ms"] = ["梅实", "梅实　味酸平。（中品）<br>　主下气，除热、烦、满，安心，肢体痛，偏枯不仁，死肌，去青黑志，恶"];
    oBc["dhd"] = ["大黄豆卷", "大黄豆卷　味甘平。（中品）<br>　主湿痹，筋挛，膝痛。生大豆涂痈肿，煮汁饮，杀鬼毒，止痛。赤小豆主下水，排痈肿脓血"];
    oBc["smc"] = ["粟米", "粟米　味咸微寒。（中品）<br>　主养肾气，去胃、脾中热，益气。陈者，味苦主胃热，消渴，利小便"];
    oBc["smd"] = ["黍米", "黍米　味甘温。（中品）<br>　主益气补中，多热、令人烦"];
    oBc["lse"] = ["蓼实", "蓼实　味辛温。（中品）<br>　主明目温中，耐风寒，下水气，面目浮肿，痈疡。马蓼，去肠中蛭虫，轻身"];
    oBc["csb"] = ["葱实", "葱实　味辛温。（中品）<br>　主明目，补中不足。其茎可作汤，主伤寒寒热，出汗，中风面目肿"];
    oBc["ssc"] = ["水苏", "水苏　味辛温。（中品）<br>　主金创，创败，轻身、不饥、耐老"];
    oBc["dsc"] = ["锻石", "锻石　味辛温。（下品）<br>　主疽疡、疥瘙、热气，恶创、癞疾、死肌，堕眉，杀痔虫，去黑子息肉"];
    oBc["yse"] = ["礜石", "礜石　味辛大热。（下品）<br>　主寒热，鼠蚀创，死肌，风痹，腹中坚"];
    oBc["qd"] = ["铅丹", "铅丹　味辛微寒。（下品）<br>　主土逆胃反，惊痫疾，除热下气。炼化还成九光。久服，通神明"];
    oBc["fx"] = ["粉锡", "粉锡　味辛寒。（下品）<br>　主伏尸毒螫，杀三虫"];
    oBc["dzc"] = ["代赭", "代赭　味苦寒。（下品）<br>　主鬼注、贼风、蛊毒，杀精物恶鬼，腹中毒邪气，女子赤沃漏下"];
    oBc["ry"] = ["戎盐", "戎盐　（下品）<br>　主明目、目痛，益气、坚肌骨，去毒蛊。大盐∶令人吐。卤盐∶味苦寒，主大热，消渴狂烦，除邪及下蛊毒，柔肌肤"];
    oBc["be"] = ["白垩", "白垩　味苦温。（下品）<br>　主女子寒热、症瘕、目闭、积聚"];
    oBc["dhc"] = ["冬灰", "冬灰　味辛微温。（下品）<br>　主黑子，去疣、息肉、疽蚀、疥瘙"];
    oBc["qla"] = ["青琅", "青琅　味辛平。（下品）<br>　主身痒、火创，痈伤、疥瘙、死肌"];
    oBc["fza"] = ["附子", "附子　味辛温。（下品）<br>　主风寒咳逆邪气，温中，金创，破症坚积聚，血瘕，寒温，踒(痿)。躄拘挛，脚痛，不能行步"];
    oBc["wt"] = ["乌头", "乌头　味辛温。（下品）<br>　主中内、恶风洗洗，出汗，除寒湿痹，咳逆上气，破积聚、寒热。其汁，煎之，名射罔，杀禽兽"];
    oBc["tx"] = ["天雄", "天雄　味辛温。（下品）<br>　主大风，寒湿痹，沥节痛，拘挛缓急，破积聚，邪气，金创，强筋骨，轻身健行"];
    oBc["bxa"] = ["半夏", "半夏　味辛平。（下品）<br>　主伤寒寒热，心下坚，下气，喉咽肿痛，头眩胸胀，咳逆肠鸣，止汗"];
    oBc["hzc"] = ["虎掌", "虎掌　味苦温。（下品）<br>　主心痛寒热，结气、积聚、伏梁，伤筋、痿、拘缓，利水道"];
    oBc["ywa"] = ["鸢尾", "鸢尾　味苦平。（下品）<br>　主蛊毒邪气，鬼注，诸毒，破症瘕积聚，去水，下三虫"];
    oBc["dhb"] = ["大黄", "大黄　味苦寒。（下品）<br>　主下瘀血、血闭、寒热，破症瘕积聚，留饮宿食，荡涤肠胃，推陈致新，通利水杀，调中化食，安和五脏"];
    oBc["tla"] = ["亭历", "亭历　味辛寒。（下品）<br>　主症瘕、积聚、结气，饮食、寒热，破坚"];
    oBc["jgb"] = ["桔梗", "桔梗　味辛微温。（下品）<br>　主胸胁痛如刀刺，腹满，肠鸣幽幽，惊恐悸气"];
    oBc["ldz"] = ["莨荡子", "莨荡子　味苦寒。（下品）<br>　主齿痛出虫，肉痹拘急，使人健行，见鬼。多食，令人狂走。久服，轻身、走及奔马、强志、益力、通神"];
    oBc["chc"] = ["草蒿", "草蒿　味苦寒。（下品）<br>　主疥瘙、痂痒、恶创，杀虫，留热在骨节间，明目"];
    oBc["xfh"] = ["旋复花", "旋复花　味咸温。（下品）<br>　主结气、胁下满、惊悸，除水，去五脏间寒热，补中下气"];
    oBc["llb"] = ["藜芦", "藜芦　味辛寒。（下品）<br>　主蛊毒，咳逆，泄葱苒"];
    oBc["gw"] = ["钩吻", "钩吻　味辛温。（下品）<br>　主金创乳，中恶风，咳逆上气，水肿，杀鬼疰，蛊毒"];
    oBc["sgd"] = ["射干", "射干　味苦平。（下品）<br>　主咳逆上气，喉痹咽痛不得消息，散急气，腹中邪逆，食饮大热"];
    oBc["shb"] = ["蛇合", "蛇合　味苦微寒。（下品）<br>　主惊痫寒热邪气，除热，金创，疽痔鼠，恶创，头疡"];
    oBc["hsd"] = ["恒山", "恒山　味苦寒。（下品）<br>　主伤寒，寒热，热发温疟，鬼毒，胸中痰结吐逆"];
    oBc["sq"] = ["蜀漆", "蜀漆　味辛平。（下品）<br>　主疟及咳逆寒热，腹中症坚、痞结、积聚，邪气、蛊毒、鬼疰"];
    oBc["gs"] = ["甘遂", "甘遂　味苦寒。（下品）<br>　主大腹疝瘕，腹满，面目浮肿，留饮宿食，破症坚积聚，利水谷道"];
    oBc["bl"] = ["白蔹", "白蔹　味苦平。（下品）<br>　主痈肿疽创，散结气，止痛除热，目中赤，小儿惊痫，温疟，女子阴中肿痛"];
    oBc["qxz"] = ["青葙子", "青葙子　味苦微寒。（下品）<br>　主邪气，皮肤中热，风瘙身痒，杀三虫"];
    oBc["gjd"] = ["雚菌", "雚菌　味咸平。（下品）<br>　主心痛，温中，去长患、白、蛲虫、蛇螫毒，症瘕、诸虫"];
    oBc["bjb"] = ["白芨", "白芨　味苦平。（下品）<br>　主痈肿、恶创、败疽，伤阴，死肌，胃中邪气，贼风鬼击，痱缓不收"];
    oBc["dj"] = ["大戟", "大戟　味苦寒。（下品）<br>　主蛊毒、十二水，肿满急痛，积聚，中风，皮肤疼痛，吐逆"];
    oBc["zq"] = ["泽漆", "泽漆　味苦微寒。（下品）<br>　主皮肤热，大腹、水气，四肢面目浮肿，丈夫阴气不足"];
    oBc["yya"] = ["茵芋", "茵芋　味苦温。（下品）<br>　主五脏邪气，心腹寒热，羸瘦如疟状，发作有时，诸关节风"];
    oBc["gzb"] = ["贯众", "贯众　味苦微寒。（下品）<br>　主腹中邪热气，诸毒，杀三虫"];
    oBc["rhb"] = ["荛花", "荛花　味苦平，寒。（下品）<br>　主伤寒温疟，下十二水，破积聚、大坚、症瘕，荡涤肠胃中留癖饮食、寒热邪气，利水道"];
    oBc["yzb"] = ["牙子", "牙子　味苦寒。（下品）<br>　主邪气、热气，疥瘙、恶疡、创痔，去白虫"];
    oBc["yzz"] = ["羊踯躅", "羊踯躅　味辛温。（下品）<br>　主贼风在皮肤中，淫淫痛，温疟，恶毒，诸痹"];
    oBc["sld"] = ["商陆", "商陆　味辛平。（下品）<br>　主水张、疝瘕、痹，熨除痈肿，杀鬼精物"];
    oBc["yta"] = ["羊蹄", "羊蹄　味苦寒。（下品）<br>　主头秃、疥瘙，除热，女子阴蚀"];
    oBc["bxd"] = ["萹蓄", "萹蓄　味辛平。（下品）<br>　主浸淫、疥瘙、疽痔，杀三虫"];
    oBc["yld"] = ["野狼毒", "野狼毒　味辛平。（下品）<br>　主咳逆上气，破积聚、饮食、寒热，水气、恶创，鼠、疽蚀，鬼精、蛊毒，杀飞鸟、走兽"];
    oBc["btw"] = ["白头翁", "白头翁　味苦温。（下品）<br>　主温疟、易狂、寒热、症瘕积聚、瘿气，逐血、止痛，疗金疮"];
    oBc["gje"] = ["鬼臼", "鬼臼　味辛温。（下品）<br>　主杀蛊毒鬼注、精物，辟恶气不祥，逐邪，解百毒"];
    oBc["ytb"] = ["羊桃", "羊桃　味苦寒。（下品）<br>　主热，身暴赤色，风水积聚，恶疡，除小儿热"];
    oBc["nqb"] = ["女青", "女青　味辛平。（下品）<br>　主蛊毒，逐邪恶气，杀鬼温疟，辟不祥"];
    oBc["lq"] = ["连翘", "连翘　味苦平。（下品）<br>　主寒热、鼠，瘰、痈肿，恶创，瘿瘤，结热蛊毒"];
    oBc["lrb"] = ["兰茹", "兰茹　味辛寒。（下品）<br>　主蚀恶肉、败创、死肌，杀疥虫，排脓恶血，除大风，善忘不乐"];
    oBc["wf"] = ["乌韭", "乌韭　味甘寒。（下品）<br>　主皮肤往来寒热，利小肠膀胱气"];
    oBc["lha"] = ["鹿藿", "鹿藿　味苦平。（下品）<br>　主蛊毒，女子腰腹痛，不乐，肠痈、瘰(历)、疡气"];
    oBc["sxb"] = ["蚤休", "蚤休　味苦微寒。（下品）<br>　主惊痫、摇头弄舌，热气在腹中，疾痈创，阴蚀，下三虫，去蛇毒"];
    oBc["scs"] = ["石长生", "石长生　味咸微寒。（下品）<br>　主寒热、恶创、火热，辟鬼气不祥"];
    oBc["lyb"] = ["陆英", "陆英　味苦寒。（下品）<br>　主骨间诸痹，四肢拘挛、疼酸，膝寒痛，阴痿，短气不足，脚肿"];
    oBc["jcb"] = ["荩草", "荩草　味苦平。（下品）<br>　主久咳上气、喘逆，久寒，惊悸，痂疥、白秃、疡气，杀皮肤小虫"];
    oBc["nb"] = ["牛扁", "牛扁　味甘微寒。（下品）<br>　主身皮创热气，可作浴汤，杀牛虱小虫，又疗牛病"];
    oBc["xgc"] = ["夏枯草", "夏枯草　味苦辛。（下品）<br>　主寒热、瘰、鼠、头创，破症，散瘿、结气，脚肿，湿痹。轻身"];
    oBc["yha"] = ["芫花", "芫花　味辛温。（下品）<br>　主咳逆上气，喉鸣、喘，咽肿、短气，蛊毒、鬼疟，疝瘕、痈肿，杀虫鱼"];
    oBc["bd"] = ["巴豆", "巴豆　味辛温。（下品）<br>　主伤寒、温疟、寒热，破症瘕、结聚、坚积，留饮、痰癖。<br>　大腹水张，荡炼五脏六腑，开通闭塞，利水谷道，去恶内，除鬼毒蛊注邪物，杀虫鱼"];
    oBc["ssd"] = ["蜀菽", "蜀菽　味辛温。（下品）<br>　主邪气、咳逆，温中，逐骨节，皮肤死肌，寒湿痹痛，下气。久服之，头不白、轻身、增年"];
    oBc["zjc"] = ["皂荚", "皂荚　味辛、咸，温。（下品）<br>　主风痹、死肌、邪气，风头、泪出，利九窍，杀精物"];
    oBc["lhb"] = ["柳花", "柳花　味苦寒。（下品）<br>　主风水黄胆，面热黑"];
    oBc["lsf"] = ["楝实", "楝实　味苦寒。（下品）<br>　主温疾伤寒，大热烦狂，杀三虫、疥疡，利小便水道"];
    oBc["ylr"] = ["郁李仁", "郁李仁　味酸平。（下品）<br>　主大腹水肿，面目四肢浮肿，利小便水道。根∶主齿龈肿，龋齿"];
    oBc["mc"] = ["莽草", "莽草　味辛温。（下品）<br>　主风头痈肿、乳痈、疝瘕，除结气、疥瘙（《御览》有痈疮二字），杀虫鱼"];
    oBc["tya"] = ["桐叶", "桐叶　味苦寒。（下品）<br>　主恶蚀、创着阴皮，主五痔，杀三虫"];
    oBc["xbp"] = ["梓白皮", "梓白皮　味苦寒。（下品）<br>　主热，去三虫"];
    oBc["sn"] = ["石南", "石南　味辛苦。（下品）<br>　主养肾气、内伤、阴衰，利筋骨皮毛。实∶杀蛊毒，破积聚，逐风痹"];
    oBc["hhc"] = ["黄环", "黄环　味苦平。（下品）<br>　主蛊毒、鬼注、鬼魅、邪气在脏中，除咳逆寒热"];
    oBc["sse"] = ["溲疏", "溲疏　味辛寒。（下品）<br>　主身皮肤中热，除邪气，止遗溺，可作浴汤"];
    oBc["sle"] = ["鼠李", "鼠李　（下品）<br>　主寒热瘰创"];
    oBc["ysg"] = ["药实根", "药实根　味辛温。（下品）<br>　主邪气，诸痹疼酸，续绝伤，补骨髓"];
    oBc["lhc"] = ["栾花", "栾花　味苦寒。（下品）<br>　主目痛、泪出、伤，消目肿"];
    oBc["mje"] = ["蔓椒", "蔓椒　味苦温。（下品）<br>　主风寒湿痹、节疼，除四肢厥气、膝痛"];
    oBc["tlb"] = ["豚卵", "豚卵　味苦温。（下品）<br>　主惊痫、疾，鬼注、蛊毒，除寒热，贲豚、五癃，邪气、挛缩"];
    oBc["mz"] = ["麋脂", "麋脂　味辛温。（下品）<br>　主痈肿、恶创、死肌，寒、风、湿痹，四肢拘缓不收，风头，肿气，通腠理"];
    oBc["lsg"] = ["鼺鼠", "鼺鼠　（下品）<br>　主堕胎，令人产易"];
    oBc["lcm"] = ["六畜毛蹄甲", "六畜毛蹄甲　味咸平。（下品）<br>　主鬼注，蛊毒，寒热，惊痫，瘨痓，狂走，骆驼毛，尤良"];
    oBc["xm"] = ["虾蟆", "虾蟆　味辛寒。（下品）<br>　主邪气，破症坚，血、痈肿、阴创。服之，不患热病"];
    oBc["mdb"] = ["马刀", "马刀　味辛微寒。（下品）<br>　主漏下赤白，寒热，破石淋，杀禽兽贼鼠"];
    oBc["sd"] = ["蛇蜕", "蛇蜕　味咸平。（下品）<br>　主小儿百二十种惊痫、螈、疾、寒热、肠痔，虫毒，蛇痫。火熬之，良"];
    oBc["qy"] = ["蚯蚓", "蚯蚓　味咸寒。（下品）<br>　主蛇瘕，去三虫、伏尸、鬼注、蛊毒，杀长虫。仍自化作水"];
    oBc["ywb"] = ["蠮螉", "蠮螉　味辛平。（下品）<br>　主久聋、咳逆、毒瓦斯，出刺出汗"];
    oBc["wga"] = ["蜈蚣", "蜈蚣　味辛温。（下品）<br>　主鬼注、蛊毒，啖诸蛇、早、鱼毒，杀鬼物、老精、温疟，去三虫"];
    oBc["szc"] = ["水蛭", "水蛭　味咸平。（下品）<br>　主逐恶血、瘀血、月闭，破血瘕积聚，无子，利水道"];
    oBc["bmb"] = ["班苗", "班苗　味辛寒。（下品）<br>　主寒热、鬼注蛊毒、鼠恶创、疽蚀死肌，破石癃"];
    oBc["bzc"] = ["贝子", "贝子　味咸平。（下品）<br>　主目翳、鬼注虫毒、腹痛、下血、五癃，利水道。烧用之，良"];
    oBc["scc"] = ["石蚕", "石蚕　味咸寒。（下品）<br>　主五癃，破五淋，堕胎，内解结气，利水道，除热"];
    oBc["qw"] = ["雀瓮", "雀瓮　味甘平。（下品）<br>　主小儿惊痫，寒热结气，蛊毒鬼注"];
    oBc["qlb"] = ["蜣螂", "蜣螂　味咸寒。（下品）<br>　主小儿惊痫、螈，腹胀寒热，大人疾狂易"];
    oBc["lgb"] = ["蝼蛄", "蝼蛄　味咸寒。（下品）<br>　主产难，出肉中刺，溃痈肿，下哽噎，解毒，除恶创"];
    oBc["mlb"] = ["马陆", "马陆　味辛温。（下品）<br>　主腹中大坚症，破积聚、息肉、恶创、白秃"];
    oBc["dd"] = ["地胆", "地胆　味辛寒。（下品）<br>　主鬼注、寒热，鼠蝼，恶创、死肌，破症瘕，堕胎"];
    oBc["sf"] = ["鼠妇", "鼠妇　味酸温。（下品）<br>　主气癃不得小便，女人月闭、血症，痫症、寒热，利水道"];
    oBc["yhb"] = ["荧火", "荧火　味辛微温。（下品）<br>　主明目，小儿火创伤，热气、蛊毒、鬼注，通神"];
    oBc["yyb"] = ["衣鱼", "衣鱼　味咸温，无毒。（下品）<br>　主妇人疝瘕，小便不利，小儿中风、项强，背起摩之"];
    oBc["thr"] = ["桃核仁", "桃核仁　味苦平。（下品）<br>　主淤血，血闭瘕邪，杀小虫"];
    oBc["xhr"] = ["杏核仁", "杏核仁　味甘温。（下品）<br>　主咳逆上气，雷鸣，喉痹下气，产乳，金创、寒心、贲豚"];
    oBc["fb"] = ["腐婢", "腐婢　味辛平。（下品）<br>　主疟，寒热、邪气，泄利，阴不起，病酒，头痛"];
    oBc["kh"] = ["苦瓠", "苦瓠　味苦寒。（下品）<br>　主大水，面目四肢浮肿，下水，令人吐"];
    oBc["sjb"] = ["水靳", "水靳　味甘平。（下品）<br>　主女子赤沃，止血养精，保血脉，益气，令人肥健、嗜食"];
    oBc["bzd"] = ["彼子", "彼子　味甘温。（下品）<br>　主腹中邪气，去三虫、蛇螫、蛊毒、鬼注、伏尸"];

	
	return oBc;
}

//ddpyResetCmd();
ddpyRegisterCommand("zj", "仲景条文...", "execZj", "请输入条文编号 1～398", "推广中医，为人民服务", "1");
ddpyRegisterCommand("bc", "神农本草...", "execBc", "请输入拼音缩写，如“gc”即甘草", "推广中医，为人民服务");
ddpyRegisterCommand("fh", "符号...", "execFh", null, "淡定“i”模式——爱符号");
