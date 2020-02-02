using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FishAbilityController : MonoBehaviour
{
    public List<FishAbility> fishAbilities;
    public List<string> controllerAbilityTriggers;
    public List<KeyCode> keyboardAbilityTriggers;

    private bool canAbility = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < controllerAbilityTriggers.Count; i++)
        {
            // Activating Abilitys
            if (Input.GetAxis(controllerAbilityTriggers[i]) > 0)
            {
                if (fishAbilities[i].canTrigger && canAbility)
                {
                    canAbility = false;

                    fishAbilities[i].canTrigger = false;
                    fishAbilities[i].ActivateFishAbility();
                }
            }
            else if (Input.GetKeyDown(keyboardAbilityTriggers[i]))
            {
                if (fishAbilities[i].canTrigger && canAbility)
                {
                    canAbility = false;

                    fishAbilities[i].canTrigger = false;
                    fishAbilities[i].ActivateFishAbility();
                }
            }


            // Deactivating Abilities
            else if ((Input.GetAxis(controllerAbilityTriggers[i]) == 0) && !Input.GetKey(keyboardAbilityTriggers[i]))
            {
                if (!fishAbilities[i].canTrigger)
                {
                    canAbility = true;

                    fishAbilities[i].canTrigger = true;
                    fishAbilities[i].DeactivateFishAbility();
                }
            }
        }
    }
}
