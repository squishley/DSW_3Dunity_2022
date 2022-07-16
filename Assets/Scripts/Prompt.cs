using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompt : MonoBehaviour
{
    public bool showPrompt;
    public Camera camera; 
    [SerializeField] GameObject button;
    [SerializeField] Spawner spawner;
    private TMP_Text text;
    
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(showPrompt)
        {
            text.color = new Color(255, 255, 255, 255);
            text.text = spawner.isGameStarted ? "Press F to stop" : "Press F to start" ;
        }
        else
        {
            text.color = new Color(255, 255, 255, 0);
        }
    }

    void OnGUI() 
    {  
        var gotransform = button.GetComponent<Transform>();
        transform.position = camera.WorldToScreenPoint(gotransform.position);
    }
}
