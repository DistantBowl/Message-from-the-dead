using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public void startButtonClicked() 
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void quitButtonClicked() 
    {
        Application.Quit();
    }
}
