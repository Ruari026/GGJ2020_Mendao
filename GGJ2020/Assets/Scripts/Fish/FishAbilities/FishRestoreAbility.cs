using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRestoreAbility : FishAbility
{
    public float restoreDistance;
    public float restoreRadius;

    // Fish Components
    Animator theAnimController;

    // Start is called before the first frame update
    void Start()
    {
        theAnimController = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ActivateFishAbility()
    {
        // Affecting Other Objects In Front Of The Fish
        Collider[] colliders = Physics.OverlapSphere(this.transform.position + (this.transform.forward * restoreDistance), restoreRadius);
        foreach (Collider c in colliders)
        {
            DestructableObject otherObject = c.gameObject.GetComponent<DestructableObject>();
            if (otherObject != null)
            {
                otherObject.SetObjectState(DestructionState.REPAIRED);
            }
        }

        // Triggering Restoration Animation On The Fish
        theAnimController.SetTrigger("Restoring");
    }
}
