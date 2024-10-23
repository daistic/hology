using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public StoryScene currentScene;

    public BottomController bottomBar;
    public SceneController sceneController;
    public LogicManagerScript logicManager;

    public GameObject thankYouMassage;

    void OnEnable()
    {
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bottomBar.isCompleted())
            {
                if (bottomBar.isLastSentence())
                {
                    if (!logicManager.deadlineDay())
                    {
                        if (bottomBar.isGameSceneMover())
                        {
                            SceneManager.LoadScene(bottomBar.getGameSceneName(), LoadSceneMode.Single);
                        }

                        else if (bottomBar.isBacktoMain())
                        {
                            logicManager.mainMode();
                            sceneController.enabled = false;
                        }

                        else
                        {
                            sceneController.enabled = false;
                        }
                    }

                    else if (!logicManager.notPlayedEnding())
                    {
                        sceneController.enabled = false;
                        logicManager.checkEnding();
                    }

                    else
                    {
                        sceneController.enabled = false;
                        thankYouMassage.SetActive(true);
                    }
                } 
                
                else
                {
                    bottomBar.PlayNextSentence();
                }
            }

            else
            {
                bottomBar.FinishSentence();
            }
        }
    }
}
