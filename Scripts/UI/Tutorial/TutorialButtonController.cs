using UnityEngine;
using static SetPersistance;

public class TutorialButtonController : MonoBehaviour
{
    public AudioClip buttonClick;

    public void startButtonClicked()
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        GameObject[] gameObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (GameObject item in gameObjects) 
        {
            if (item.name == "Runtime") 
            {
                item.SetActive(true);
                break;
            }          
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    } 
}
