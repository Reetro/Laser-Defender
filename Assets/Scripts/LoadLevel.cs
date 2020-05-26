using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
