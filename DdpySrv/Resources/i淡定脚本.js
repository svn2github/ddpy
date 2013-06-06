/*
// ----------------------------------------
【方法名】ddpyRegisterCommand
【概要】注册方法
【参数】
sCmd：编码栏作为拼音输入的命令 [必须]
sName：候选中作为文本显示的名称 [必须]
sMethod：对应的方法名 [必须]
sTip：有值时忽略候选项仅显示该提示 [可选，默认无提示]
sTitle：输入法窗口标题 [可选，默认不设定标题]
hasDigitComp：是否把数字作为编码输入 [可选，默认主键盘数字键为非编码]
【返回值】无


【方法名】ddpyCreateCand
【概要】创建一个候选项
【参数】
sText：候选项文本（<br>表示换行） [必须]
sPy：候选项编码 [可选，默认空白串]
bShowDigit：该候选项是否附加显示数字编号显示 [可选，默认附加显示数字编号]
sDispText：候选项显示用文本（<br>表示换行） [可选，默认显示候选项文本]
【返回值】候选项对象
// ----------------------------------------
*/


ddpyRegisterCommand("zj", "仲景条文", "execZj", "请输入条文编号 1～398", "推广中医，为人民服务", "1");
ddpyRegisterCommand("bc", "神农本草", "execBc", "请输入拼音缩写，如“gc”即甘草", "推广中医，为人民服务");
ddpyRegisterCommand("jf", "伤寒经方", "execJf", "请输入拼音缩写，如“gzt”即桂枝汤", "推广中医，为人民服务");
ddpyRegisterCommand("fh", "符号", "execFh", null, "淡定“i”模式——爱符号");
ddpyRegisterCommand("rw", "日文汉字拼音输入", "execRw", "请输入单字拼音全拼", "日文汉字拼音输入");
