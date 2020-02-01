using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DestructableObject : MonoBehaviour
{
    public DestructionState currentState = DestructionState.REPAIRED;

    public UnityEvent OnObjectRepair;
    public UnityEvent OnObjectDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectState(DestructionState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;

            if (newState == DestructionState.REPAIRED)
            {
                OnObjectRepair.Invoke();
            }
            else
            {
                OnObjectDestroy.Invoke();
            }
        }
    }
}
public enum DestructionState
{
    REPAIRED,
    DESTROYED
}