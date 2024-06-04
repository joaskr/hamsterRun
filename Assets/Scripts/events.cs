using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        managePlayer.isGameStarted = true;
        SceneManager.LoadScene("Level");
    }
    public void QuitQame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        managePlayer.isGameStarted = true;
    }
}
