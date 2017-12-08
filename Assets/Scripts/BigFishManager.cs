using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishManager : MonoBehaviour {
    public bool trigger=false;
    public float Speed=3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (trigger)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            trigger = true;
        }
        if (collision.gameObject.tag == "road2")
        {
            trigger = false;
        }
    }
    
}
