﻿using System.Collections;
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

        if (gameObject.layer == 9)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (gameObject.layer == 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
            if (inRange == true && left == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("FireL2") > 0)
                {
                    fishLeft.transform.position = fishRight.transform.position;
                }
            }

            else if (inRange == true && left == false)
            {
         
            
                if (Input.GetKeyDown(KeyCode.O) || Input.GetAxis("FireR2") > 0)
                {
                    fishRight.transform.position = fishLeft.transform.position;
                }
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