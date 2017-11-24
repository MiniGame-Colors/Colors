//这个类用于在切换场景时在场景之间传递数据


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DataTransformer {
    //监测是不是刚刚开始游戏
    public static bool beginGame = true;
    //主角是否觉醒黄色的能力
    public static bool yellow = false;
    //控制用户输入
    public static bool enableInput = true;
    //检测镜子是否碎了
    public static bool deskBroken = false;


    //public static Vector2 position;
    //public static int facingDirectio = 1;
}