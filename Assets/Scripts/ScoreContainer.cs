using UnityEngine;
using TMPro;

public class ScoreContainer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent = null;

    GameSession gameSession = null;
    void Start()
    {
        textComponent.text = "0";
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        textComponent.text = gameSession.GetCurrentScore().ToString();
    }
}
