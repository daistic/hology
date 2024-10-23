using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DateEventHandler : MonoBehaviour
{
    public LogicManagerScript LogicManager;
    public int knowledgeStatIncrease = 5;
    public int heartStatIncrease = 30;

    public SceneController storyScene;
    public StoryScene[] dateScenes;

    public GameObject bottomBar;
    public GameObject datePrompts;
    public Button[] buttons;

    public void malioboro()
    {
        storyScene.currentScene = dateScenes[0];

        LogicManager.cutsceneMode();

        LogicManager.increaceHeartStat(heartStatIncrease);
        LogicManager.increaseKnowledgeStat(knowledgeStatIncrease);
        LogicManager.dateCount++;

        storyScene.enabled = true;

        LogicManager.changeDay();
        datePrompts.SetActive(false);
        buttons[0].interactable = false;
    }

    public void beach()
    {
        storyScene.currentScene = dateScenes[1];

        LogicManager.cutsceneMode();

        LogicManager.increaceHeartStat(heartStatIncrease);
        LogicManager.increaseKnowledgeStat(knowledgeStatIncrease);
        LogicManager.dateCount++;

        storyScene.enabled = true;

        LogicManager.changeDay();
        datePrompts.SetActive(false);
        buttons[1].interactable = false;
    }
    public void mall()
    {
        storyScene.currentScene = dateScenes[2];

        LogicManager.cutsceneMode();

        LogicManager.increaceHeartStat(heartStatIncrease);
        LogicManager.increaseKnowledgeStat(knowledgeStatIncrease);
        LogicManager.dateCount++;

        storyScene.enabled = true;

        LogicManager.changeDay();
        datePrompts.SetActive(false);
        buttons[2].interactable = false;
    }
    public void UGM()
    {
        storyScene.currentScene = dateScenes[3];

        LogicManager.cutsceneMode();

        LogicManager.increaceHeartStat(heartStatIncrease);
        LogicManager.increaseKnowledgeStat(knowledgeStatIncrease);
        LogicManager.dateCount++;

        storyScene.enabled = true;

        LogicManager.changeDay();
        datePrompts.SetActive(false);
        buttons[3].interactable = false;
    }
}
