using UnityEngine;
using UnityEngine.SceneManagement;
using static SetPersistance;

public class LeaderboardButtonController : MonoBehaviour
{
    public AudioClip buttonClick;

    public void mainMenuButtonClicked() 
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene("MainMenu");
    }
}
