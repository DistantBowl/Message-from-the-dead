using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonManager : MonoBehaviour
{
    public void resumeButtonClicked() 
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void mainMenuButtonClicked() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>().inputs.Disable();
        SceneManager.LoadScene("Main Menu");
    }
}
