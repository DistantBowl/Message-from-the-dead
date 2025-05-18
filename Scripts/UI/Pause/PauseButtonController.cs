using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonController : MonoBehaviour
{
    public void resumeButtonClicked() 
    {
        Time.timeScale = 1;  // resume time
        gameObject.SetActive(false);
    }

    public void mainMenuButtonClicked() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>().inputs.Disable();  // Disable inputs for optimisation
        Wait(150);  // Wait for sound to finish
        SceneManager.LoadScene("MainMenu");
    }
    private IEnumerable Wait(int ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }
}
