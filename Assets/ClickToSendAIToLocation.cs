using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSendAIToLocation : MonoBehaviour {

    // The KinematicCore component of the agent we want to move.
    public KinematicCore controlledAI;

	void Start () {
		
	}
	
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000, 1 << LayerMask.NameToLayer("Floor")))
            {
                if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                {
                    controlledAI.Flee(hitInfo.point);
                }
                else
                {
                    controlledAI.Seek(hitInfo.point);
                }

            }
        }
		
	}



}
