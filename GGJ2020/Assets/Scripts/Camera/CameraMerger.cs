using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraMerger : MonoBehaviour
{
    public Camera leftCamera;
    public Camera rightCamera;

    [Range(0, 1)]
    public float mergePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handling LeftCamera
        leftCamera.rect = new Rect
        {
            x = 0,
            y = 0,
            width = Mathf.Lerp(0.5f, 1.0f, mergePoint),
            height = 1
        };

        // Handling RightCamera
        rightCamera.rect = new Rect
        {
            x = Mathf.Lerp(0.5f, 0, mergePoint),
            y = 0,
            width = Mathf.Lerp(0.5f, 1.0f, mergePoint),
            height = 1
        };
    }
}
