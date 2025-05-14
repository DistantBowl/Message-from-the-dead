using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private GameObject player;
    private GameObject pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] gameObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (GameObject item in gameObjects) 
        {
            if (item.name == "Pause") 
            {
                pauseMenu = item;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerValues>().inputs.Player.pause.ReadValue<float>() > 0) 
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
