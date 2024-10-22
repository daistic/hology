using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomController bottomBar;

    void Start()
    {
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bottomBar.isCompleted())
            {
                bottomBar.PlayNextSentence();
            }

            else
            {
                bottomBar.FinishSentence();
            }
        }
    }
}
