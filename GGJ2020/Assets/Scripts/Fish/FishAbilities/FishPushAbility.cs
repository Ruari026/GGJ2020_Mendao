using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishPushAbility : FishAbility
{
    public float triggerDistance;
    public float triggerRadius;

    public UnityEvent OnPushEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateFishAbility()
    {
        // Affecting Other Objects In Front Of The Fish
        Collider[] colliders = Physics.OverlapSphere(this.transform.position + (this.transform.forward * triggerDistance), triggerRadius);
        foreach (Collider c in colliders)
        {
            PushableObject otherObject = c.gameObject.GetComponent<PushableObject>();
            if (otherObject != null)
            {
                OnPushEvent.Invoke();
                otherObject.Interact(this.gameObject, true);
            }
        }
    }
    public override void DeactivateFishAbility()
    {
        // Affecting Other Objects In Front Of The Fish
        Collider[] colliders = Physics.OverlapSphere(this.transform.position + (this.transform.forward * triggerDistance), triggerRadius);
        foreach (Collider c in colliders)
        {
            PushableObject otherObject = c.gameObject.GetComponent<PushableObject>();
            if (otherObject != null)
            {
                otherObject.Interact(this.gameObject, false);
            }
        }
    }
}
