using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushableObject : MonoBehaviour
{
    public MovementDirection pushDirection;

    public Transform startPos;
    public Transform endPos;

    private List<GameObject> attachedFish = new List<GameObject>();
    float rangePos = 0;

    public UnityEvent onPathEnd;

    [SerializeField]
    private string fmodPushParam = "";
    private float pushFloat = 0f;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Pushing Object If Fish Are Attached
        if (attachedFish.Count > 0)
        {
            MoveObject();
        }
    }


    /*
    ====================================================================================================
    Fish Interaction
    ====================================================================================================
    */
    public void Interact(GameObject fish, bool isAttaching)
    {
        if (isAttaching)
        {
            AttachFish(fish);
        }
        else
        {
            DetachFish(fish);
        }
    }
    private void AttachFish(GameObject fishToAttach)
    {
        // Checking if the fish is on the right side compared to the object's push direction
        Vector3 objectPosition = this.transform.position;
        Vector3 fishPosition = fishToAttach.transform.position;


        // Getting angle that fish is at relative to object
        Vector3 fishLocalPos = fishPosition - objectPosition;
        float angle = Vector3.Angle(Vector3.forward, fishLocalPos);//fishPositionRot.y;
        if (angle < 0)
        {
            angle += 360;
        }

        // Comparing against object's push direction
        if (pushDirection == MovementDirection.Z_AXIS)
        {
            // Top Side
            if ((angle > 0) && (angle < 45))
            {
                attachedFish.Add(fishToAttach);
                fishToAttach.transform.parent = this.transform;

                Rigidbody rb = fishToAttach.GetComponent<Rigidbody>();
                rb.centerOfMass = (transform.forward * 1.5f);
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            else if ((angle > 315) && (angle < 360))
            {
                attachedFish.Add(fishToAttach);
                fishToAttach.transform.parent = this.transform;

                Rigidbody rb = fishToAttach.GetComponent<Rigidbody>();
                rb.centerOfMass = (transform.forward * 1.5f);
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            // Bottom Side
            else if((angle > 135) && (angle < 225))
            {
                attachedFish.Add(fishToAttach);
                fishToAttach.transform.parent = this.transform;

                Rigidbody rb = fishToAttach.GetComponent<Rigidbody>();
                rb.centerOfMass = (transform.forward * 1.5f);
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        else
        {
            // Right Side
            if ((angle > 45) && (angle < 135))
            {
                attachedFish.Add(fishToAttach);
                fishToAttach.transform.parent = this.transform;

                Rigidbody rb = fishToAttach.GetComponent<Rigidbody>();
                rb.centerOfMass = (transform.forward * 1.5f);
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            // Left Side
            else if ((angle > 225) && (angle < 315))
            {
                attachedFish.Add(fishToAttach);
                fishToAttach.transform.parent = this.transform;

                Rigidbody rb = fishToAttach.GetComponent<Rigidbody>();
                rb.centerOfMass = (transform.forward * 1.5f);
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
    private void DetachFish(GameObject fishToDetach)
    {
        attachedFish.Remove(fishToDetach);
        fishToDetach.transform.parent = null;

        Rigidbody rb = fishToDetach.GetComponent<Rigidbody>();
        rb.ResetCenterOfMass();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }


    /*
    ====================================================================================================
    Object Moving
    ====================================================================================================
    */
    private void MoveObject()
    {
        Vector3 movementDirection = new Vector3();

        // Getting Movement Direction Based On Fish's User Input
        for (int i = 0; i < attachedFish.Count; i++)
        {
            FishMovementController movementController = attachedFish[i].GetComponent<FishMovementController>();
            Vector3 desiredMovementDirection = new Vector3
            {
                x = (Input.GetAxis(movementController.horizontalInputCode + "Keyboard") + Input.GetAxis(movementController.horizontalInputCode + "Controller")),
                y = 0,
                z = (Input.GetAxis(movementController.verticalInputCode + "Keyboard") + Input.GetAxis(movementController.verticalInputCode + "Controller"))
            };
            desiredMovementDirection.Normalize();

            if (pushDirection == MovementDirection.X_AXIS)
            {
                movementDirection.x += desiredMovementDirection.x;
            }
            else
            {
                movementDirection.z += desiredMovementDirection.z;
            }
        }

        if (movementDirection.magnitude > 0)
        {

             if (gameObject.tag == "LeftFish")
             {
                fmodPushParam = "LeftStopDrag";
             }
             else
             {
                fmodPushParam = "RightStopDrag";
             }

             
                pushFloat = 0f;
                FMODUnity.RuntimeManager.PlayOneShot(fmodPushParam, transform.position);
                FMODUnity.StudioEventEmitter[] emmiters = attachedFish[0].GetComponents<FMODUnity.StudioEventEmitter>();
            emmiters[1].Play();
            emmiters[1].SetParameter(fmodPushParam, pushFloat);
        }     
        else
        {
             {
                FMODUnity.StudioEventEmitter[] emmiters = attachedFish[0].GetComponents<FMODUnity.StudioEventEmitter>();
                emmiters[1].Play();
                emmiters[1].SetParameter(fmodPushParam, 1);
             }

        }

        // Checking how far along the path the object is
        // Checking direction of travel
        Vector3 directionOfPath = (endPos.position - startPos.position).normalized;
        Debug.Log("directionOfPath: " + directionOfPath);
        Debug.Log("movementDirection: " + movementDirection.normalized);

        if (pushDirection == MovementDirection.X_AXIS)
        {
            if ((directionOfPath.x > 0) && (movementDirection.x > 0))
            {
                rangePos += Time.deltaTime;
            }
            else if ((directionOfPath.x < 0) && (movementDirection.x < 0))
            {
                rangePos += Time.deltaTime;
            }
            else if (movementDirection.x == 0)
            {
                rangePos += 0;
            }
            else
            {
                rangePos -= Time.deltaTime;
            }
        }
        else
        {
            if ((directionOfPath.z > 0) && (movementDirection.z > 0))
            {
                rangePos += Time.deltaTime;
            }
            else if ((directionOfPath.z < 0) && (movementDirection.z < 0))
            {
                rangePos += Time.deltaTime;
            }
            else if (movementDirection.z == 0)
            {
                rangePos += 0;
            }
            else
            {
                rangePos -= Time.deltaTime;
            }
        }



        Vector3 newPosition = startPos.position;
        float lineMagnitude = Vector3.Distance(startPos.position, endPos.position);
        if (rangePos < 0)
        {
            newPosition = startPos.position;
        }
        else if (rangePos > lineMagnitude)
        {
            newPosition = endPos.position;

            foreach (GameObject g in attachedFish)
            {
                DetachFish(g);
            }
            onPathEnd.Invoke();
            if (gameObject.tag == "LeftFish")
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fish/SignalLeft", transform.position);
            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fish/SignalRight", transform.position);
            }
            
        }
        else
        {
            newPosition = (startPos.position + (directionOfPath * rangePos));
        }
        this.transform.position = newPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        // Drawing Start Pos
        if (startPos != null)
        {
            Gizmos.DrawWireSphere(startPos.position, 0.2f);
        }
        // Drawing End Pos
        if (endPos != null)
        {
            Gizmos.DrawWireSphere(endPos.position, 0.2f);
        }

        Gizmos.color = Color.red;
        // Indicating Direction Path
        Vector3 movementDirection = endPos.position - startPos.position;
        int iterations = Mathf.FloorToInt(movementDirection.magnitude);
        for (int i = 0; i < iterations; i++)
        {
            Vector3 start = startPos.position + (movementDirection.normalized * i);
            Vector3 end = start + movementDirection.normalized;
            Gizmos.DrawLine(start, end);
            Gizmos.DrawSphere(end, 0.1f);
        }
        Gizmos.DrawLine(startPos.position + (movementDirection.normalized * iterations), endPos.position);
    }
}

public enum MovementDirection
{
    X_AXIS,
    Z_AXIS
}