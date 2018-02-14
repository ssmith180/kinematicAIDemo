using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCore : MonoBehaviour {

    // Our character's movement speed in Unity units per second.
    public float moveSpeed = 5.0f;

    // The Seek radius of satisfaction.
    public float radiusOfSatisfaction = 0.01f;

    // A catch-all for the relevant position to define our behavior.
    // For Seek and Arrive, this is where we're trying to get.
    // For Flee, this is where we're trying to get away from.
    private Vector3 target = Vector3.zero;

    // This tells us whether we're currently in Seek mode.
    private bool isSeekTargetSet = false;

    // This tells us whether we're currently in Flee mode.
    private bool isFleePositionSet = false;

    // The CharacterController assigned to this game object, loaded in Start.
    private CharacterController characterController;

	void Start () {
        // Compare this method of getting a sibling Component to declaring
        // it as public and assigning it directly in the Unity editor.
        // Both methods have pros and cons depending on the situation.
        characterController = GetComponent<CharacterController>();
    }
	
	void Update () {
	
        if (isSeekTargetSet)
        {
            // Move toward our target.
            Vector3 moveDirection = target - transform.position;

            // CharacterController.Move is a special function that allows us to move
            // in this direct-update way, but preserves collision detection. This is 
            // a great simplifier for working with AI that moves.
            characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

            if (Vector3.Distance(target, transform.position) <= radiusOfSatisfaction)
            {
                isSeekTargetSet = false;
            }
        } else if (isFleePositionSet)
        {
            Vector3 moveDirection = transform.position - target;
            characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

    }

    /// <summary>
    /// Seek sets the character's current target. In kinematic mode,
    /// it will travel in a straight line to that position.
    /// 
    /// To prevent clipping into the floor, we will modify the target
    /// position so that its Y position matches ours.
    /// 
    /// We set isSeekTargetSet to true so that the Update loop will
    /// know to use the Seek behavior to update our position.
    /// 
    /// Any other script in the scene that can see this component (KinematicCore)
    /// can use this method to manipulate the behavior of the object.
    /// </summary>
    /// <param name="position"></param>
    public void Seek(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        isSeekTargetSet = true;
    }

    /// <summary>
    /// Flee sets the position the character should always move
    /// directly away from.
    /// 
    /// Like Seek, we'll use a bool flag to determine if we should
    /// be fleeing.
    /// </summary>
    /// <param name="position"></param>
    public void Flee(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        isFleePositionSet = true;
    }
}
