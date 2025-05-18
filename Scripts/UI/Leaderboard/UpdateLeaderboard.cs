using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateLeaderboard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool saveData = PlayerPrefs.HasKey("Usernames") && PlayerPrefs.HasKey("Scores");

        if (saveData)
        {
            // Load and process username data
            string usernamesString = PlayerPrefs.GetString("Usernames");
            string[] usernames = usernamesString.Split(", ");
            usernames.Reverse();  // Flip order from ascending to decending

            // Load and process username data
            string scoresString = PlayerPrefs.GetString("Scores");
            List<string> scoresInts = scoresString.Split(", ").ToList();
            scoresInts.Reverse();  // Flip order from ascending to decending

            int entryID = 0;
            for ( int i = 0; i < 5; i++)  // Loop for the max of 5 entries
            {
                GameObject entry = GameObject.Find($"Entry ({entryID})");  // Find the entry object
                entry.transform.GetChild(0).GetComponent<TMP_Text>().text = usernames[entryID]+": "+scoresInts[entryID].ToString(); // Write the data
                entryID++;
            }
        }
    }
}
