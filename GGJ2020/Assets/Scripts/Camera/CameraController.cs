using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3
        {
            x = Mathf.Lerp(this.transform.position.x, followTarget.transform.position.x, Time.deltaTime * moveSpeed),
            y = this.transform.position.y,
            z = Mathf.Lerp(this.transform.position.z, followTarget.transform.position.z, Time.deltaTime * moveSpeed)
        };
        this.transform.position = newPosition;
    }
}
