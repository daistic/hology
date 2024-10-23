using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PromptHandlerScript: MonoBehaviour 
{
    public GameObject prompts;
    public GameObject bottomBar;
    public GameObject stats;
    public LogicManagerScript LogicManager;
    public SceneController Scene;

    public StoryScene[] talkScene;
    public int talkIndex;
    public bool talked;

    public GameObject fixEvent;
    public FixEventHandler fixEventHandler;

    public GameObject dateEvent;
    public StoryScene cantDate;

    public StoryScene sleepScene;

    private void Awake()
    {
        talkIndex = 0;
        talked = false;
    }

    public void talk()
    {
        if (LogicManager.fixCount > 0)
        {
            Scene.currentScene = talkScene[talkIndex + 1];
            Scene.enabled = true;

            talked = true;
        } 
        else
        {
            Scene.currentScene = talkScene[0];
            Scene.enabled = true;
        }
    }

    public void fix()
    {
        fixEvent.SetActive(true);
        fixEventHandler.enabled = true;

        prompts.SetActive(false);
        bottomBar.SetActive(false);
        stats.SetActive(false);
    }

    public void date()
    {
        if (LogicManager.fixCount > 0)
        { 
            dateEvent.SetActive(true);

            prompts.SetActive(false);
            bottomBar.SetActive(false);
        }
        else
        {
            Scene.currentScene = cantDate;
            Scene.enabled = true;
        }
    }

    public void sleep()
    {
        LogicManager.cutsceneMode();
        Scene.currentScene = sleepScene;
        Scene.enabled = true;

        LogicManager.changeDay();
    }

    public bool hasTalked()
    {
        return talked;
    }

    public void test()
    {
        Debug.Log("Click");
    }
}