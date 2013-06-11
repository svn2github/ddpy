// Js脚本扩充信息检索
// 返回扩充窗口显示用文本
//（codes为不包含前两位“淡定”的编码）
//【注意】方法名固定为 ddpyJsScriptSearch 不可修改
function ddpyJsScriptSearch(codes)
{
	if ( codes == "" ){
		return "";
	}
	
	if ( codes == "淡定拼音" ){
		return "淡定拼音输入法主页\thttp://code.google.com/p/ddpy/";
	}else if ( codes == "丹砂" ){
		return "丹砂　味甘微寒，无毒。（上品）<br>治身体五脏百病，养精神，安魂魄，益气，明目，杀精魅、邪恶鬼。久服通神明，不老，能化为汞";
	}else if ( codes == "云母" ){
		return "云母　味甘平。（上品）<br>主身皮死肌，中风寒热，如在车船上，除邪气，安五脏，益子精，明目，久服轻身延年";
	}else{
		
	}
	

	return "";
}
