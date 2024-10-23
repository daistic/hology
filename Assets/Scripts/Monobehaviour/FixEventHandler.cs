using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FixEventHandler : MonoBehaviour
{
    public List<Card> cards;
    public Sprite[] hiddenSprite;

    bool firstGuess, secondGuess;
    int firstGuessIndex, secondGuessIndex;
    string firstGuessSprite, secondGuessSprite;

    public Sprite originalSprite;
    public int correctGuesses;
    public int eventGuesses;

    public LogicManagerScript logicManager;
    public int knowledgeStatIncrease;
    public GameObject fixEvent;
    public FixEventHandler fixEventHandler;

    [System.Serializable]
    public struct Card
    {
        public Button button;
        public Sprite clickSprite;
    }

    private void OnEnable()
    {
        for (int i=0; i<cards.Count; i++)
        {
            cards[i].button.image.sprite = originalSprite;
            cards[i].button.image.color = new Color(255, 255, 255);
            cards[i].button.interactable = true;
        }

        List<Sprite> spritePool = new List<Sprite>();

        for (int i = 0; i < hiddenSprite.Length; i++)
        {
            spritePool.Add(hiddenSprite[i]);
            spritePool.Add(hiddenSprite[i]);
        }

        spritePool = spritePool.OrderBy(a => Random.Range(0, spritePool.Count)).ToList();

        for (int i = 0; i < cards.Count; i++)
        {
            var tempCard = cards[i];
            tempCard.clickSprite = spritePool[i];
            cards[i] = tempCard;
        }

        firstGuess = false;
        secondGuess = false;
        correctGuesses = 0;
    }

    public void PickCard()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessSprite = cards[firstGuessIndex].clickSprite.name;

            cards[firstGuessIndex].button.image.sprite = cards[firstGuessIndex].clickSprite;
        }
        
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessSprite = cards[secondGuessIndex].clickSprite.name;

            cards[secondGuessIndex].button.image.sprite = cards[secondGuessIndex].clickSprite;

            if(firstGuessSprite == secondGuessSprite)
            {
                Debug.Log("Match");
            }
            else
            {
                Debug.Log("Don't Match");
            }

            StartCoroutine(checkMatch());
        }
    }

    private IEnumerator checkMatch()
    {
        yield return new WaitForSeconds(0.5f);

        if (firstGuessSprite == secondGuessSprite)
        {
            cards[firstGuessIndex].button.interactable = false;
            cards[secondGuessIndex].button.interactable = false;

            cards[firstGuessIndex].button.image.color = new Color (0, 0, 0);
            cards[secondGuessIndex].button.image.color = new Color(0, 0, 0);

            checkGameFinished();
        }

        else
        {
            cards[firstGuessIndex].button.image.sprite = originalSprite;
            cards[secondGuessIndex].button.image.sprite = originalSprite;
        }

        yield return new WaitForSeconds(0.5f);

        firstGuess = secondGuess = false;
    }

    public void checkGameFinished()
    {
        correctGuesses++;

        if (correctGuesses >= eventGuesses)
        {
            Debug.Log("Game Finished");

            logicManager.increaseKnowledgeStat(knowledgeStatIncrease);
            logicManager.playFixScene();
            logicManager.changeDay();

            fixEvent.SetActive(false);
            fixEventHandler.enabled = false;
        }
    }

}
