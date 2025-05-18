using UnityEngine;

public class ExpandMap : MonoBehaviour
{
    private PlayerValues playerValues;
    public GameObject map;
    public GameObject miniMap;
    private bool switched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
        int itemsLocated = 0;

        // Find the map game object when they are inactive
        GameObject[] gameObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (GameObject item in gameObjects) 
        {
            if (item.name == "Map backround") {map = item; itemsLocated++;}
            else if (item.name == "Mini map backround") {miniMap = item; itemsLocated++;}
            if (itemsLocated == 2) {break;}  // Breaks once both are found for efficiency      
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerValues.inputs.Player.ExpandMap.ReadValue<float>() > 0)  // If the set key is pressed
        {
            if (!switched) 
            {
                map.SetActive(!map.activeSelf);  // Flip active condition
                miniMap.SetActive(!miniMap.activeSelf);
                switched = true;
            }
        }
        else { switched = false; }
    }
}
