using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFracture : MonoBehaviour
{

    public GameObject chain;
    public float time;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fracture());
        }
    }

    private IEnumerator Fracture()
    {
        yield return new WaitForSeconds(time);
        chain.GetComponent<HingeJoint2D>().enabled = false;
    }
}
