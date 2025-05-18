using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardButtonController : MonoBehaviour
{
    public async void mainMenuButtonClicked() 
    {
        await Wait(150);
        SceneManager.LoadScene("Main Menu");
    }

    private async Task Wait(int delay)
    {
        await Task.Delay(delay);
    }
}
