using UnityEngine;

public class InteractableLocker : MonoBehaviour, IInteractable
{
    public GameObject fishLeft;
    public Material fishLeftMaterial;

    public GameObject fishRight;
    public Material fishRightMaterial;

    bool fishLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        fishRight = GameObject.FindGameObjectWithTag("RightFish");
        fishLeft = GameObject.FindGameObjectWithTag("LeftFish");

        fishLeftMaterial.EnableKeyword("_EMISSION");
        fishRightMaterial.EnableKeyword("_EMISSION");

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
            if (fishLocked)
            {
                fishRightMaterial.EnableKeyword("_EMISSION");
                fishLocked = false;

                fishRight.GetComponent<FishMovementController>().enabled = true;
            }
            else
            {
                fishRightMaterial.DisableKeyword("_EMISSION");
                fishLocked = true;

                fishRight.GetComponent<FishMovementController>().enabled = false;
            }
        }
        else
        {
            if (fishLocked)
            {
                fishLeftMaterial.EnableKeyword("_EMISSION");
                fishLocked = false;

                fishLeft.GetComponent<FishMovementController>().enabled = true;
            }
            else
            {
                fishLeftMaterial.DisableKeyword("_EMISSION");
                fishLocked = true;

                fishLeft.GetComponent<FishMovementController>().enabled = false;
            }
        }
    }
}
