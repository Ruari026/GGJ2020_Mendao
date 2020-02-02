using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class TextFlash : MonoBehaviour
{
    private bool menuLoaded = false;

    public TextMeshProUGUI text;
    public Color color;
    bool textActive;

    public UnityEvent startGameEvent;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (menuLoaded)
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

    public IEnumerator OnGameStart()
    {
        yield return new WaitForSeconds(2.50f);
        menuLoaded = true;
    }
}
