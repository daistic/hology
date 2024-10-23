using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PromptHandlerScript: MonoBehaviour 
{
    public GameObject prompts;
    public GameObject bottomBar;
    public SceneController Scene;

    public GameObject fixEvent;
    public FixEventHandler fixEventHandler;

    public GameObject dateEvent;
    

    public void talk()
    {
        Scene.enabled = true;
    }

    public void fix()
    {
        fixEvent.SetActive(true);
        fixEventHandler.enabled = true;

        prompts.SetActive(false);
        bottomBar.SetActive(false);
    }

    public void date()
    {
        dateEvent.SetActive(true);

        prompts.SetActive(false);
        bottomBar.SetActive(false);
    }

    public void test()
    {
        Debug.Log("Click");
    }
}