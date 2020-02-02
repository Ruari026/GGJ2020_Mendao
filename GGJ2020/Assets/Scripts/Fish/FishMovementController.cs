using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovementController : MonoBehaviour
{
    public string verticalInputCode;
    public string horizontalInputCode;

    public float movementSpeed = 10.0f;
    public float rotationSpeed = 30.0f;
    
    private Rigidbody theRB;
    public Animator theAnimController;

    // Start is called before the first frame update
    void Start()
    {
        theRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Test Input
        Vector3 desiredMovementDirection = new Vector3
        {
            x = Input.GetAxis(horizontalInputCode),
            y = 0,
            z = Input.GetAxis(verticalInputCode)
        };
        desiredMovementDirection.Normalize();


        // Movement Forces
        if (desiredMovementDirection.magnitude != 0)
        {
            Vector3 newMovementDirection = new Vector3
            {
                x = Mathf.Lerp(transform.forward.x, desiredMovementDirection.x, Time.deltaTime),
                y = 0,
                z = Mathf.Lerp(transform.forward.z, desiredMovementDirection.z, Time.deltaTime),
            };
            theRB.AddForce(newMovementDirection.normalized * movementSpeed);
        }


        // Rotational Forces
        if (desiredMovementDirection.magnitude > 0)
        {
            // Getting Desired Rotation To Face
            Quaternion desiredRotation = Quaternion.LookRotation(desiredMovementDirection.normalized, Vector3.up);
            Quaternion currentRotation = this.transform.rotation;

            // Comparing To Current Rotation
            Vector3 rotationDirection = Quaternion.ToEulerAngles(desiredRotation * Quaternion.Inverse(currentRotation));

            // Applying Forces
            theRB.AddTorque(rotationDirection.normalized * (rotationSpeed));
            theAnimController.SetBool("IsMoving", true);
        }
        else
        {
            theAnimController.SetBool("IsMoving", false);
        }
        
    }
}
