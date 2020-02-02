using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool inRange;
    public GameObject fishLeft;
    public GameObject fishRight;
    public bool left;

    // Start is called before the first frame update
    void Start()
    {
        fishRight = GameObject.FindGameObjectWithTag("RightFish");
        fishLeft = GameObject.FindGameObjectWithTag("LeftFish");
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.T) && left == true)
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

        if (other.tag == "LeftFish")
        {
            left = true;
        }
        else if (other.tag == "RightFish")
        {
            left = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }


}