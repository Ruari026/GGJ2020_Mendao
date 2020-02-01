using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFlash : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color color;
    bool textActive;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Destroy(text);
            textActive = false;
        }

        if (textActive == true)
        {
            text.color = new Color(color.r, color.g, color.b, 0.1f + Mathf.PingPong(Time.time * 1.1f, 1f)); 
        }
    }
}
