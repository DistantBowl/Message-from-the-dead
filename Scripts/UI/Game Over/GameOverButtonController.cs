using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonController : MonoBehaviour
{
    public async void mainMenuButtonClicked() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>().inputs.Disable();
        await Wait(150);
        SceneManager.LoadScene("Main Menu");
    }

    private async Task Wait(int delay)
    {
        await Task.Delay(delay);
    }
}
