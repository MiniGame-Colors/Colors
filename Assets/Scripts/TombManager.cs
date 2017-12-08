using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombManager : MonoBehaviour {
    public float time = 3;
    public Sprite sprite;
    public Sprite sprite2;
    public Transform Princess;
    public float dis;

    public bool Stay=false;             //用于判断当前是否有主角站在上面
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Stay&&(Princess.position.y - this.transform.position.y)>4)
        {
            time -= Time.deltaTime;
        }
        
        if (time < 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if (time < 0)
        {
            Destroy(this.gameObject);

        }
	}
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Stay = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Stay = false;
    }
}
