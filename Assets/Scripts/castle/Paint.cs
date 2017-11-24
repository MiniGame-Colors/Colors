using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {

	
	void Start () {

        if (DataTransformer.yellow) {
            this.transform.GetChild(0).gameObject.SetActive(false);
        } else {
            this.transform.GetChild(1).gameObject.SetActive(false);
        }

	}


    void Update() {
        if (DataTransformer.yellow) {
            this.transform.GetChild(0).gameObject.SetActive(false);
        } else {
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
