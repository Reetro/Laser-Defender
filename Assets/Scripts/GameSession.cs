using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update

    int currentScore = 0;

    void Awake()
    {
        int musicPlayerCount = FindObjectsOfType(GetType()).Length;

        if (musicPlayerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddToScore(int Amount)
    {
        currentScore += Amount;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
