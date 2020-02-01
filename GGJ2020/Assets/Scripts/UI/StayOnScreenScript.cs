using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnScreenScript : MonoBehaviour
{
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (left == true)
        {
            pos.x = 0.1f;
        }
        else
        {
            pos.x = 0.9f;
        }
        
        pos.y = Mathf.Clamp(pos.y, 0, 0.1f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
