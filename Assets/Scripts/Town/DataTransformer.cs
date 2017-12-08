//这个类用于在切换场景时在场景之间传递数据


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DataTransformer {
    //主角是否觉醒黄色的能力
    //public static bool yellow = false;
    //控制用户输入
    public static bool enableInput = true;
    //检测用户此时是否着地
    public static bool grounded = true;
    //检测用户此时是否处于推箱子的状态
    public static bool push = false;
    public static float deltaLength;
    //检测角色当前是否处于攀爬状态
    public static bool climb = false;
    //确保角色不会一直处于攀爬状态
    public static bool hasClimbed = false;

    //存档位置
    public static Vector3 position = new Vector3(-21.35f, -1.12582f, -10.0f);
}