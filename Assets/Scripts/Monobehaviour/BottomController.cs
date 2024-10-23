using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    public Image characterSprite;
    public Image backgroundSprite;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private Coroutine typingCoroutine;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }
    public void PlayNextSentence()
    {
        typingCoroutine = StartCoroutine(TypeText(currentScene.Sentences[++sentenceIndex].text));
        personNameText.text = currentScene.Sentences[sentenceIndex].speaker.speakerName;
        backgroundSprite.sprite = currentScene.background;
        //characterSprite.sprite = currentScene.Sentences[sentenceIndex].sprite;
    }

    public void FinishSentence()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        barText.text = currentScene.Sentences[sentenceIndex].text;
        state = State.COMPLETED;
    }

    public bool isCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool isLastSentence()
    {
        return sentenceIndex + 1 == currentScene.Sentences.Count;
    }

    public bool isGameSceneMover()
    {
        return currentScene.Sentences[sentenceIndex].gameSceneMover != "";
    }

    public bool isBacktoMain()
    {
        return currentScene.Sentences[sentenceIndex].isBackToMain;
    }

    public string getGameSceneName()
    {
        return currentScene.Sentences[sentenceIndex].gameSceneMover;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }

}
