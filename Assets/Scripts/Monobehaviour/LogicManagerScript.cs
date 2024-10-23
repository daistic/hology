using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicManagerScript : MonoBehaviour
{
    public int knowledgeStat;
    public int heartStat;
    public int day;

    public TextMeshProUGUI dayText;

    private void Awake()
    {
        knowledgeStat = 0;
        heartStat = 0;
        day = 1;
    }

    public void increaseKnowledgeStat(int statIncrease)
    {
        knowledgeStat += statIncrease;
    }

    public void changeDay()
    {
        dayText.text = "Day " + day.ToString();
    }
}
