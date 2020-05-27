using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent = null;

    GameSession gameSession = null;
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        if (gameSession.GetCurrentScore() <= 0)
        {
            textComponent.text = "Your Score Was 0 Dang your really bad get good nerd";
        }
        else
        {
            textComponent.text = "Your Score Was " + gameSession.GetCurrentScore().ToString();
        }
    }
}
