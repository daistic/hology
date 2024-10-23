using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomController bottomBar;
    public SceneController sceneController;

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
                    if (bottomBar.isGameSceneMover())
                    {
                        SceneManager.LoadScene(bottomBar.getGameSceneName(), LoadSceneMode.Single);
                    } 
                    
                    else if (bottomBar.isBacktoMain())
                    {
                        
                    }

                    else
                    {
                        sceneController.enabled = false;
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
