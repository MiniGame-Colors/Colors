/*这个脚本用于范围检测，在范围内的道具会显示彩色的子对象
使用这个脚本需要在对象下面建立一个空的GameObject，然后给这个GameObject
添加一个Sphere Collider，并选择is Trigger*/

/*为了实现检测的效果，需要给每个道具添加Colors这个标签，还是有点麻烦，
后面优化的目标主要是看能不能给所有的道具设置相同的Layer通过Layer来检测*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    private float length = 0.0f;

    //道具进入灯光的范围的时候
    void OnTriggerEnter2D(Collider2D other) {
        //只需要进入一次，后面就记住这个距离，一直用这个距离来测试
        if(length == 0 && other.CompareTag("light"))
        {
            length = Mathf.Abs(other.gameObject.transform.position.x - this.transform.position.x);
        }
    }

    //根据距离判断alpha值，起到颜色渐变效果
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("light"))
        {
            float temp = Mathf.Abs(other.gameObject.transform.position.x - this.transform.position.x);

            SpriteRenderer[] sprite = this.gameObject.GetComponentsInChildren<SpriteRenderer>(true);

            float alpha = temp / length;

            sprite[0].color = new Vector4(sprite[0].color.r, sprite[0].color.g, sprite[0].color.b, alpha);
        }

    }
}
