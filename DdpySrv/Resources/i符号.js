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
