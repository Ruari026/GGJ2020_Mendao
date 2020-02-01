using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool inRange;
    public GameObject fishLeft;
    public  GameObject fishRight;
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
        if (inRange == true && Input.GetKeyDown(KeyCode.T) )
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true; 
        if (other.tag = "FishLeft")
        {
            left = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }


}
