using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public async void startButtonClicked() 
    {
        await Wait(150);  // Wait for the sound to play before switching scene
        SceneManager.LoadScene("Main Scene");
    }

    public async void leaderboardButtonClicked()
    {
        await Wait(150);  // Wait for the sound to play before switching scene
        SceneManager.LoadScene("Leaderboard");
    }

    public async void quitButtonClicked() 
    {
        await Wait(150);  // Wait for the sound to play before switching scene
        Application.Quit();
    }

    private async Task Wait(int delay)
    {
        await Task.Delay(delay);
    }
}
