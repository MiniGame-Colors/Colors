//这个类用于在切换场景时在场景之间传递数据


using System.Collections;
using System.Collections.Generic;

static public class DataTransformer {
    //监测是不是刚刚开始游戏
    public static bool beginGame = true;

    //有些地方可以直接暂停游戏，有些地方只能禁止用户的输入
    //控制用户输入
    public static bool enableInput = true;
}