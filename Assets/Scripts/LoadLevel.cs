using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] float gameoverLoadDelay = 1f;

    GameSession gameSession = null;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    public void LoadMainMenu()
    {
        gameSession.ResetScore();

        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine("StartGameOver");
    }

    public void LoadMainGame()
    {
        gameSession.ResetScore();

        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(gameoverLoadDelay);
        SceneManager.LoadScene("Game Over");
    }
}
