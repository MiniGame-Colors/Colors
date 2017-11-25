//这个类用于在切换场景时在场景之间传递数据


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DataTransformer {
    //主角是否觉醒黄色的能力
    public static bool yellow = false;
    //控制用户输入
    public static bool enableInput = true;

    public static bool grounded = true;

    public static Vector3 position = new Vector3(-21.35f, -1.12582f, -10.0f);
    //public static Vector2 position;
    //public static int facingDirectio = 1;
}