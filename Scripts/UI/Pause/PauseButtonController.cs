using UnityEngine;
using UnityEngine.SceneManagement;
using static SetPersistance;

public class PauseButtonController : MonoBehaviour
{
    public AudioClip buttonClick;

    public void resumeButtonClicked() 
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        Time.timeScale = 1;  // resume time
        gameObject.SetActive(false);
    }

    public void mainMenuButtonClicked() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>().inputs.Disable();  // Disable inputs for optimisation
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene("MainMenu");
    }
}
