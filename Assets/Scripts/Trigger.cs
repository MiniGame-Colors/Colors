/*这个脚本用于范围检测，在范围内的道具会显示彩色的子对象
使用这个脚本需要在对象下面建立一个空的GameObject，然后给这个GameObject
添加一个Sphere Collider，并选择is Trigger*/

/*为了实现检测的效果，需要给每个道具添加Colors这个标签，还是有点麻烦，
后面优化的目标主要是看能不能给所有的道具设置相同的Layer通过Layer来检测*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    //道具进入灯光的范围的时候
    void OnTriggerEnter2D(Collider2D other) {
            //Debug.Log(other);
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Colors"))
        {
            //显示灰白的子对象
            //Transform gray = (other.gameObject.transform.GetChild(0)) as Transform;
            //gray.gameObject.SetActive(false);
            //隐藏彩色的子对象
            //Transform color = (other.gameObject.transform.GetChild(1)) as Transform;
            //color.gameObject.SetActive(true);

            SpriteRenderer[] sprite = other.gameObject.GetComponentsInChildren<SpriteRenderer>(true);
            Debug.Log(sprite[0].name);
            float alpha = Mathf.Lerp(sprite[0].color.a, 0.0f, 2.0f * Time.deltaTime);

            sprite[0].color = new Vector4(sprite[0].color.r, sprite[0].color.g, sprite[0].color.b, alpha);

        }
        

    }

    //道具离开灯光的范围的时候
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Colors"))
        {
            //显示灰白的子对象
            //Transform gray = (other.gameObject.transform.GetChild(0)) as Transform;
            //gray.gameObject.SetActive(false);
            //隐藏彩色的子对象
            //Transform color = (other.gameObject.transform.GetChild(1)) as Transform;
            //color.gameObject.SetActive(true);

            SpriteRenderer[] sprite = other.gameObject.GetComponentsInChildren<SpriteRenderer>(true);
            Debug.Log(sprite[0].name);
            float alpha = Mathf.Lerp(sprite[0].color.a, 1.0f, 2.0f * Time.deltaTime);

            sprite[0].color = new Vector4(sprite[0].color.r, sprite[0].color.g, sprite[0].color.b, 1);

        }
    }
}
