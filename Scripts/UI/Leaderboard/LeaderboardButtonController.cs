using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardButtonController : MonoBehaviour
{
    public void mainMenuButtonClicked() 
    {
        Wait(150);
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerable Wait(int ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }
}
