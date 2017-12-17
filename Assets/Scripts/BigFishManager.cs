using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishManager : MonoBehaviour {
    public bool trigger=false;
    public float Speed=3;
    public float delayTime = 3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (trigger)
        //{
        //    transform.Translate(Speed * Time.deltaTime, 0, 0);
        //}
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            if (!trigger) {
                trigger = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
                StartCoroutine(WaitAndPrint(delayTime));//delayTime后执行WaitAndPrint()方法 
            }
        }
        if (collision.gameObject.tag == "road2")
        {
            Debug.Log("trigger");
            trigger = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }
    IEnumerator WaitAndPrint(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作    
       // trigger = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
