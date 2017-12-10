using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpenDoor : MonoBehaviour {

    public GameObject wall; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // open the door
            // may be there is a better wall than SetActive
            wall.SetActive(false);
            // delete key
            gameObject.SetActive(false);
        }
    }
}
