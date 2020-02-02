using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishDestroyAbility : FishAbility
{
    private Rigidbody theRB;

    public float chargeForce;
    public float destroyThreshold;

    private bool isDestroying = false;

    public UnityEvent OnBoostEvent;


    // Start is called before the first frame update
    void Start()
    {
        theRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theRB.velocity.magnitude > destroyThreshold)
        {
            isDestroying = true;
        }
        else
        {
            isDestroying = false;
        }
    }

    public override void ActivateFishAbility()
    {
        theRB.AddForce(this.transform.forward * chargeForce);
        OnBoostEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDestroying)
        {
            DestructableObject otherObject = collision.gameObject.GetComponent<DestructableObject>();
            if (otherObject != null)
            {
                otherObject.SetObjectState(DestructionState.DESTROYED);
            }
        }
    }
}
