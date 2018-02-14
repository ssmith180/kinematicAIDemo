using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapOnExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        Vector3 otherPosition = other.transform.position;

        if (otherPosition.x < -transform.localScale.x / 2)
        {
            otherPosition.x += transform.localScale.x * 0.9f;
        }

        if (otherPosition.x > transform.localScale.x / 2)
        {
            otherPosition.x -= transform.localScale.x * 0.9f;
        }

        if (otherPosition.z < -transform.localScale.z / 2)
        {
            otherPosition.z += transform.localScale.z * 0.9f;
        }

        if (otherPosition.z > transform.localScale.z / 2)
        {
            otherPosition.z -= transform.localScale.z * 0.9f;
        }

        other.transform.position = otherPosition;

    }
}
