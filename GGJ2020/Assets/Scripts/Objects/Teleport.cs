using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool inRange;
    GameObject fishLeft;
    GameObject fishRight;
    bool left;

    // Start is called before the first frame update
    void Start()
    {
        fishLeft = GameObject.Find("FishPrefab (Left)");
        fishRight = GameObject.Find("FishPrefab (Right)");
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.T) && left ==true )
        {
            fishLeft.transform.position = fishRight.transform.position;
        }
        else if (inRange == true && Input.GetKeyDown(KeyCode.T) && left == false)
        {
            fishRight.transform.position = fishLeft.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true; 

        if (other.tag == "FishLeft")
        {
            left = true;
        }
        else if (other.tag == "FishRight")
        {
            left = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }


}
