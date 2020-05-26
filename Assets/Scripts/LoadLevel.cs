using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] float gameoverLoadDelay = 1f;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine("StartGameOver");
    }

    public void LoadMainGame()
    {
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
