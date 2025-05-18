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
            string usernamesString = PlayerPrefs.GetString("Usernames");
            string[] usernames = usernamesString.Split(", ");
            usernames.Reverse();

            string scoresString = PlayerPrefs.GetString("Scores");
            List<string> scoresInts = scoresString.Split(", ").ToList();
            scoresInts.Reverse();

            int entryID = 0;
            for ( int i = 0; i < 5; i++) 
            {
                GameObject entry = GameObject.Find($"Entry ({entryID})");
                entry.transform.GetChild(0).GetComponent<TMP_Text>().text = usernames[entryID]+": "+scoresInts[entryID].ToString();
                entryID++;
                if (entryID == scoresInts.Count) { i = 5; }
            }
        }
    }
}
