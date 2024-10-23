using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProloguwButtonHandler : MonoBehaviour
{
    public GameObject[] toActivate;
    public GameObject[] toDeactivate;

    public void gameStart()
    {
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].gameObject.SetActive(true);
        }

        for (int i = 0;i < toDeactivate.Length; i++)
        {
            toDeactivate[i].gameObject.SetActive(false);
        }
    }
}
