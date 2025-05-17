using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonController : MonoBehaviour
{
    public void resumeButtonClicked() 
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

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
