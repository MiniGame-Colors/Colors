using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDown : MonoBehaviour {
    public float speed = 5f;
    public Transform pillar;
    public Transform bottom;

    private bool ready = false;
    private GameObject active;
    private GameObject inactive;

    private void Awake() {
        active = transform.Find("Active").gameObject;

        inactive = transform.Find("Inactive").gameObject;
    }


    private void Update() {
        if(ready && Input.GetKey(KeyCode.X)) {
            active.SetActive(true);
            inactive.SetActive(false);

            float posY = Mathf.Lerp(pillar.position.y, bottom.position.y, speed * Time.deltaTime);
            
            pillar.position = new Vector3(pillar.position.x, posY, pillar.position.z);
        } else {
            active.SetActive(false);
            inactive.SetActive(true);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ready = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ready = false;
        }
    }
}
