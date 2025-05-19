using UnityEngine;
using UnityEngine.SceneManagement;
using static SetPersistance;

public class StartButtonController : MonoBehaviour
{
    public AudioClip buttonClick;

    public void startButtonClicked() 
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene("MainScene");
    }

    public void leaderboardButtonClicked()
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene("Leaderboard");
    }

    public void quitButtonClicked() 
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        Application.Quit();
    }
}
