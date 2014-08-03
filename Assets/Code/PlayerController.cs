using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a collider to be attached to the same game object
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Character/Player Controller")]

public class PlayerController : MonoBehaviour
{
    private CharacterMotor motor;
	private Transform transform;
	private Vector3 directionVector = Vector3.zero;
	public float timesHit = 0;
	
    // Use this for initialization
    void Awake()
    {
		motor = GetComponent<CharacterMotor>();
		transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input vector from kayboard or analog stick
		directionVector = Vector3.zero;
		directionVector.x = Input.GetAxisRaw("Horizontal");
		directionVector.z = Input.GetAxisRaw("Vertical");
        if (directionVector != Vector3.zero)
        {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1.0f, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }
		
        // Apply the direction to the CharacterMotor
		motor.inputMoveDirection = transform.rotation * directionVector;
		motor.inputJump = Input.GetButton("Jump");
    }
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.name == "Bullet"){
			timesHit++;
			print("Hit Player:" + timesHit);
			Destroy(hit.gameObject);
			return;
		};
    }
}