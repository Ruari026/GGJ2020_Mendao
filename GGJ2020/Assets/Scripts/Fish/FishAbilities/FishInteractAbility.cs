using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishInteractAbility : FishAbility
{
    public float triggerDistance;
    public float triggerRadius;

    public UnityEvent OnPushEvent;

    public override void ActivateFishAbility()
    {
        // Affecting Other Objects In Front Of The Fish
        Collider[] colliders = Physics.OverlapSphere(this.transform.position + (this.transform.forward * triggerDistance), triggerRadius);
        foreach (Collider c in colliders)
        {
            IInteractable otherObject = c.gameObject.GetComponent<IInteractable>();
            if (otherObject != null)
            {
                OnPushEvent.Invoke();
                otherObject.OnInteract(this.gameObject);
            }
        }
    }
}
