//这个脚本用于保存全局数据
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTransformer {
    //角色是否死亡
    public static bool dead = false;
    //角色能力是否觉醒
    public static bool Awakening = false;
    //角色当前是否正在推东西
    public static bool push = false;
    //是否禁用输入
    public static bool enableInput = true;

    //角色是否获得开启城堡大厅的钥匙
    public static bool keyOfHall = false;

    
    //当前是否处于场景转换状态
    public static bool changeScene = false;

    //检测桌子是否被触发过
    //public static bool deskTrigger = false;



    //存档点位置
    public static Vector3 position;
}
