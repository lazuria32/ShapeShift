using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftPoint : MonoBehaviour {
    public bool InTargetTrigger;

	// Use this for initialization
	void Start () {
        InTargetTrigger = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public bool IsVisible() {
        return GetComponent<Renderer>().isVisible;
    }

    void OnTriggerEnter(Collider other) {
        InTargetTrigger = true;
    }

    void OnTriggerStay(Collider other) {
        InTargetTrigger = true;
    }

    void OnTriggerExit(Collider other) {
        InTargetTrigger = false;
    }
}
