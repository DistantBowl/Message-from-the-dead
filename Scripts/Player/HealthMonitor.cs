using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    private PlayerValues playerValues;
    private GameObject gameOverMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerValues = GetComponent<PlayerValues>();

        // Find the game over GUI when its inactive
        GameObject[] gameObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (GameObject item in gameObjects)
        {
            if (item.name == "Game Over")
            {
                gameOverMenu = item;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerValues.health <= 0) 
        {
            playerValues.gameObject.GetComponent<AudioSource>().Stop();  // Stop the backround music
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;  // Pause the time
        } 
    }
}
