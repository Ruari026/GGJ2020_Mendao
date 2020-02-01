using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelEndObject : MonoBehaviour
{
    public GameObject leftDolly;
    public GameObject rightDolly;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject leftFish = null, rightFish = null;
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 2);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.tag == "LeftFish")
            {
                leftFish = c.gameObject;
            }

            if (c.gameObject.tag == "RightFish")
            {
                rightFish = c.gameObject;
            }
        }

        if ((leftFish != null) && (rightFish != null))
        {
            Debug.Log("Level Ending");

            // Run The Level End Animation
            // Disable User Controls From Fish
            leftFish.GetComponent<FishMovementController>().enabled = false;
            leftFish.GetComponent<FishAbilityController>().enabled = false;

            rightFish.GetComponent<FishMovementController>().enabled = false;
            rightFish.GetComponent<FishAbilityController>().enabled = false;
        }
    }

    private IEnumerator EndLevel()
    {
        float t = 0;
        while (t < 1)
        {
            yield return null;
        }
    }
}