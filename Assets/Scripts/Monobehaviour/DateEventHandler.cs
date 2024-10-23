using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DateEventHandler : MonoBehaviour
{
    public SceneController storyScene;
    public StoryScene[] dateScenes;

    public GameObject bottomBar;
    public GameObject datePrompts;

    public void malioboro()
    {
        storyScene.currentScene = dateScenes[0];

        bottomBar.SetActive(true);
        datePrompts.SetActive(false);
        storyScene.enabled = true;
    }

    public void beach()
    {
        storyScene.currentScene = dateScenes[1];

        bottomBar.SetActive(true);
        datePrompts.SetActive(false);
        storyScene.enabled = true;
    }
    public void mall()
    {
        storyScene.currentScene = dateScenes[2];

        bottomBar.SetActive(true);
        datePrompts.SetActive(false);
        storyScene.enabled = true;
    }
    public void UGM()
    {
        storyScene.currentScene = dateScenes[3];

        bottomBar.SetActive(true);
        datePrompts.SetActive(false);
        storyScene.enabled = true;
    }
}
