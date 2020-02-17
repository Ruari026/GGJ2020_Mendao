using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTeleporter : MonoBehaviour, IInteractable
{
    public GameObject fishLeft;
    public GameObject fishRight;

    // Start is called before the first frame update
    void Start()
    {
        fishRight = GameObject.FindGameObjectWithTag("RightFish");
        fishLeft = GameObject.FindGameObjectWithTag("LeftFish");

        if (gameObject.layer == 9)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (gameObject.layer == 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void OnInteract(GameObject interactingFish)
    {
        string fishType = interactingFish.tag;

        if (fishType == "RightFish")
        {
            FishMovementController fmc = fishLeft.GetComponent<FishMovementController>();
            if (fmc.enabled)
            {
                fishLeft.transform.position = fishRight.transform.position;
            }
        }
        else
        {
            FishMovementController fmc = fishRight.GetComponent<FishMovementController>();
            if (fmc.enabled)
            {
                fishRight.transform.position = fishLeft.transform.position;
            }
        }
    }
}