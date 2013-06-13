// ==================================================================================
// 字符串常用方法封装
// ==================================================================================
String.prototype.trim = function () {
	return this.replace(/(^\s*)|(\s*$)/g,"");
} 

String.prototype.leftTrim = function () {
	return this.replace(/(^[\\s]*)/g, "");
} 

String.prototype.rightTrim = function () {
	return this.replace(/([\\s]*$)/g, "");
} 

String.prototype.left = function (iLength) {
	if (iLength <= 0){
		return "";
	}

	if (this.length > iLength) {
		return this.substring(0, iLength);
	}

	return String(this);
}

String.prototype.right = function (iLength) {
	if (iLength <= 0){
		return "";
	}

	if (this.length > iLength) {
		return this.substring(this.length - iLength);
	}

	return String(this);
}

String.prototype.startWith = function (sInput) {
	if (sInput == null) {
		return false;
	}
	return this.left(sInput.length) == sInput;
}

String.prototype.endWith = function (sInput) {
	if (sInput == null) {
		return false;
	}
	return this.right(sInput.length) == sInput;
}

String.prototype.isBlank = function () {
	return this.trim().length == 0;
}
///////////////////////////////////////////

// 调用淡定拼音输入法后台服务程序显示消息框
function alert(msg)
{
	var obj = new ActiveXObject("DdpySrv.ComClass");
	obj.SvrMsgBox(msg)
}

// 调用淡定拼音输入法后台服务程序访问网页
function getHttpResponse(url, charset)
{
    var obj = new ActiveXObject("DdpySrv.ComClass");
    if (charset == null) {
	    return obj.SrvGetHttpResponse(url)
    } else {
	    return obj.SrvGetHttpResponse(url, charset)
    }

}

///////////////////////////////////////////

// ****************************************
// 淡定脚本基本架构
// ****************************************

// 存放注册对象
var oRegisteredCmd = new Object();

// ----------------------------------------
// 重置注册对象
//
// 【返回值】无
// ----------------------------------------
function ddpyResetCmd()
{
	oRegisteredCmd = new Object();
}

// ----------------------------------------
// 注册方法
//
// 【参数】
// sCmd：编码栏作为拼音输入的命令 [必须]
// sName：候选中作为文本显示的名称 [必须]
// sMethod：对应的方法名 [必须]
// sTip：有值时忽略候选项仅显示该提示 [可选，默认无提示]
// sTitle：输入法窗口标题 [可选，默认不设定标题]
// hasDigitComp：是否把数字作为编码输入 [可选，默认主键盘数字键为非编码]
// 【返回值】无
// ----------------------------------------
function ddpyRegisterCommand(sCmd, sName, sMethod, sTip, sTitle, hasDigitComp)
{
	var oCmd = new Object();
	
	oCmd["Cmd"] = sCmd;
	oCmd["Name"] = sName;
	oCmd["Method"] = sMethod;
	if (sTip != null){
	    oCmd["Tip"] = sTip;
	}else{
		oCmd["Tip"] = "";
	}
	if (sTitle != null){
	    oCmd["Title"] = sTitle;
	}else{
		oCmd["Title"] = "";
	}
    if (hasDigitComp != null) {
        oCmd["HasDigitComp"] = hasDigitComp;
	}else{
        oCmd["HasDigitComp"] = "0";
	}

	oRegisteredCmd[sCmd] = oCmd;
}

// ----------------------------------------
// 调用方法
//
// 【参数】
// sMethod：要调用的方法名 [必须]
// sParms：传入的参数 [必须]
// 【返回值】指定方法被调用后的返回值
// ----------------------------------------
function ddpyExecuteMethod(sMethod, sParms) {
	if ( eval("typeof(" + sMethod +")") == "function" ) {
		return eval(sMethod)(sParms);
	}

	var aryRet = new Array();
	aryRet["Tip"] = "错误：未定义 function“" + sMethod + "”";
	return aryRet;
}

// ----------------------------------------
// 创建一个候选项
//
// 【参数】
// sText：候选项文本（<br>表示换行） [必须]
// sPy：候选项编码 [可选，默认空白串]
// bShowDigit：该候选项是否附加显示数字编号显示 [可选，默认附加显示数字编号]
// sDispText：候选项显示用文本（<br>表示换行） [可选，默认显示候选项文本]
// 【返回值】候选项对象
// ----------------------------------------
function ddpyCreateCand(sText, sPy, bShowDigit, sDispText)
{
	var cand = new Object();
	cand["Text"] = sText;
	if (sPy != null){
		cand["PinYin"] = sPy;
	}else{
		cand["PinYin"] = "";
	}
	if (bShowDigit != null){
		cand["ShowDigit"] = bShowDigit;
	}else{
		cand["ShowDigit"] = "1";
	}
    if (sDispText != null) {
		cand["DispText"] = sDispText;
	}else{
		cand["DispText"] = "";
	}
	return cand;
}

// ----------------------------------------
// 主方法，由淡定拼音输入法后台服务程序调用
//
// 【参数】
// parms：参数，由淡定拼音输入法后台服务程序传入
// 【返回值】
// 脚本运行结果（字符串）
//   - 有提示时首行固定存放提示
//   - 无提示时逐行存放候选项
//   - 倒数第二行固定存放输入法窗口标题
//   - 倒数第一行固定存放数字编码标记
// ----------------------------------------
function main(parms)
{
	var words;
	var aryTxt = new Array();
	var bExec = false;
	
	if ( parms.isBlank() ) {
		words = new Array();
		for (var cmd in oRegisteredCmd) {
			words[words.length] = ddpyCreateCand(oRegisteredCmd[cmd]["Name"], oRegisteredCmd[cmd]["Cmd"]);
		}
		words["Title"] = "淡定“i”模式";
    } else if (parms.startWith("淡定")) {
        return ddpyExecuteMethod("ddpyJsScriptSearch", parms.substring(2));

    } else if (parms.length == 1) {
		words = new Array();
		for (var cmd in oRegisteredCmd) {
			if ( cmd.startWith(parms) ){
				words[words.length] = ddpyCreateCand(oRegisteredCmd[cmd]["Name"], oRegisteredCmd[cmd]["Cmd"].substring(1));
				bExec = true;
			}
		}
		if ( !bExec ){
			words["Tip"] = "不明输入";
		}
		words["Title"] = "淡定“i”模式";
	}else{
		for (var cmd in oRegisteredCmd) {
			if (parms.startWith(cmd)){
			    words = ddpyExecuteMethod(oRegisteredCmd[cmd]["Method"], parms);

			    if (words["Title"] == null) {
			        words["Title"] = oRegisteredCmd[cmd]["Title"];
			    }
			    if (words["HasDigitComp"] == null) {
			        words["HasDigitComp"] = oRegisteredCmd[cmd]["HasDigitComp"];
			    }
			    if ((words.length == 0) && (words["Tip"] == null)) {
			        words["Tip"] = oRegisteredCmd[cmd]["Tip"];
			    }

			    bExec = true;
			}
		}
		if ( !bExec ){
			words = new Array();
			words["Tip"] = "不明输入";
		}
	}

	if (typeof(words["Tip"]) != "undefined" && words["Tip"] != ""){
		// 有提示时首行固定存放提示
		aryTxt[aryTxt.length] = words["Tip"];
	}else{
		// 候选项
		for (var i = 0; i < words.length; i++){
			// Text,PinYin,WordType,IsMixWord,ShowDigit,DispText
			aryTxt[aryTxt.length] = words[i].Text + "\t" + words[i].PinYin + "\t0\t0\t" + words[i].ShowDigit + "\t" + words[i].DispText;
		}
	}

	// 倒数第二行固定存放输入法窗口标题
	if (typeof(words["Title"]) != "undefined") {
		aryTxt[aryTxt.length] = words["Title"];
	}else{
		aryTxt[aryTxt.length] = "";
	}

	// 倒数第一行固定存放数字编码标记
	if (typeof(words["HasDigitComp"]) != "undefined") {
		aryTxt[aryTxt.length] = words["HasDigitComp"];
	}else{
		aryTxt[aryTxt.length] = "0";
	}

	return aryTxt.join("\n");
}
