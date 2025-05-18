using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public void startButtonClicked() 
    {
        Wait(150);  // Wait for the sound to play before switching scene
        SceneManager.LoadScene("MainScene");
    }

    public void leaderboardButtonClicked()
    {
        Wait(150);  // Wait for the sound to play before switching scene
        SceneManager.LoadScene("Leaderboard");
    }

    public void quitButtonClicked() 
    {
        Wait(150);  // Wait for the sound to play before switching scene
        Application.Quit();
    }

    private IEnumerable Wait(int ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }
}
