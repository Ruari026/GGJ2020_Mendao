using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EscapeController : MonoBehaviour
{
    public UnityEvent onSceneEscape;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onSceneEscape.Invoke();
            StartCoroutine(WaitThenEscape());
        }
    }

    private IEnumerator WaitThenEscape()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MenuScene");
    }
}
