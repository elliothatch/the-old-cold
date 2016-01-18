using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    public float maxSpeed = 6.0f;

    protected Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void move(float lh, float lv, float rh, float rv)
    {
        

        Vector3 moveDirectionVector = new Vector3(lh, -lv, 0.0f);

        if (moveDirectionVector != Vector3.zero)
        {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = moveDirectionVector.magnitude;
            moveDirectionVector = moveDirectionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            moveDirectionVector = moveDirectionVector * directionLength;
        }

        Vector3 lookDirectionVector = new Vector3(-rh, -rv, 0.0f);
        if (lookDirectionVector != Vector3.zero)
        {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = lookDirectionVector.magnitude;
            lookDirectionVector = lookDirectionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            lookDirectionVector = lookDirectionVector * directionLength;
        }


        Vector3 moveForce = moveDirectionVector * maxSpeed * maxSpeed;
        // Apply the direction to the CharacterMotor
        //if (rb.velocity.magnitude > maxSpeed)
        //{
        //     moveForce = moveForce.
        //}
        rb.AddForce(moveForce);
        if (rh != 0.0f || rv != 0.0f)
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(lookDirectionVector.x, lookDirectionVector.y) * 180.0f / Mathf.PI, Vector3.forward);
        }
        
        //Debug.Log(moveDirectionVector);
        //Debug.Log(lookDirectionVector);
        //motor.inputJump = Input.GetButton("Jump");
    }
}
