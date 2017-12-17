using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour {

    public bool activePower;
    private string activePowerMessage = @"窃取颜色的人，太过愚蠢
我不知昏迷多时，世界亦黯然受苦
请把颜色还给我们。
神啊，你心已经向我，不然这火焰，如何熊熊燃起。";
    private string otherMessage = @"《论颜色》
物质产生的不同颜色的物理特性，被人们称为颜色。
混沌中的物质需要通过颜色，成为独一无二的存在。
其中，红、黄、蓝被称为三原色，它们可以混合出世界上所有的颜色。";

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            if (activePower) {
                DataTransformer.Awakening = true;

                PromptManager.Instance.PromptShow(activePowerMessage);

            }else {

                PromptManager.Instance.PromptShow(otherMessage);
            }
        }

    }
}
