using System;
using UnityEngine;

public class TutorialButtonController : MonoBehaviour
{
    public void startButtonClicked()
    {
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
