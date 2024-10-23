using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public int knowledgeStat;
    public int heartStat;
    public int day;

    public int fixCount;
    public int talkCount;
    public int dateCount;

    public GameObject[] toActivate;
    public GameObject[] toDeactivate;

    public SceneController scene;
    public PromptHandlerScript promptHandler;

    public StoryScene firstFixCutscene;
    public StoryScene defaultFixCutscene;

    public StoryScene[] endingScenes;
    public bool playedEnding;

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI knowledgeStatText;
    public TextMeshProUGUI heartStatText;
    public Image backgroundImage;
    public Sprite backgroundSprite;

    private void Awake()
    {
        knowledgeStat = 0;
        heartStat = 0;
        day = 1;
        playedEnding = false;

        fixCount = 0;
        talkCount = 0;
        dateCount = 0;
    }

    public void increaseKnowledgeStat(int statIncrease)
    {
        fixCount++;
        knowledgeStat += statIncrease;
        knowledgeStatText.text = knowledgeStat.ToString();
    }

    public void playFixScene()
    {
        if (fixCount == 1)
        {
            cutsceneMode();

            scene.currentScene = firstFixCutscene;
            scene.enabled = true;
        }
        else
        {
            cutsceneMode();

            scene.currentScene = defaultFixCutscene;
            scene.enabled = true;
        }
    }

    public void increaceHeartStat(int statIncrease)
    {
        heartStat += statIncrease;
        heartStatText.text = heartStat.ToString();
    }

    public void cutsceneMode()
    {
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < toDeactivate.Length; i++)
        {
            toDeactivate[i].gameObject.SetActive(false);
        }
    }

    public void mainMode()
    {
        backgroundImage.sprite = backgroundSprite;

        for(int i = 0;i < toActivate.Length; i++)
        {
            toActivate [i].gameObject.SetActive(true);
        }

        for(int i = 0; i < toDeactivate.Length; i++)
        {
            toDeactivate [i].gameObject.SetActive(true);
        }
    }

    public void changeDay()
    {
        day++;
        dayText.text = "Day " + day.ToString();

        if (promptHandler.hasTalked())
        {
            promptHandler.talkIndex++;
            promptHandler.talked = false;
            increaseKnowledgeStat(5);
            increaceHeartStat(5);
        }
    }

    public bool deadlineDay()
    {
        return day > 5;
    }

    public void checkEnding()
    {
        if (dateCount > 1 && knowledgeStat >= 65 && heartStat >= 65)
        {
            cutsceneMode();
            scene.currentScene = endingScenes[0];
            scene.enabled = true;
            playedEnding = true;
        }
        else if (knowledgeStat >= 75)
        {
            cutsceneMode();
            scene.currentScene = endingScenes[1];
            scene.enabled = true;
            playedEnding = true;
        }
        else if (heartStat >= 85)
        {
            cutsceneMode();
            scene.currentScene = endingScenes[2];
            scene.enabled = true;
            playedEnding = true;
        }
        else
        {
            cutsceneMode();
            scene.currentScene = endingScenes[3];
            scene.enabled = true;
            playedEnding = true;
        }
    }

    public bool notPlayedEnding()
    {
        return playedEnding;
    }
}
