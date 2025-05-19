using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SetPersistance;

public class GameOverButtonController : MonoBehaviour
{
    public AudioClip buttonClick;
    private PlayerValues playerValues;
    private TMP_Text notice;
    private TMP_InputField usernameInput;

    private void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
        notice = GameObject.Find("Notice").GetComponent<TMP_Text>();
        usernameInput = GameObject.Find("Username").GetComponent<TMP_InputField>();
    }

    public void submitButtonClicked() 
    {
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);

        bool saveData = PlayerPrefs.HasKey("Usernames") && PlayerPrefs.HasKey("Scores");

        if (saveData)
        {
            // Load and process the username save data
            string usernamesString = PlayerPrefs.GetString("Usernames");
            List<string> usernames = usernamesString.Split(", ").ToList();

            // Load and process the score save data
            string scoresString = PlayerPrefs.GetString("Scores");
            string[] scores = scoresString.Split(", ");
            List<int> scoresInts = new List<int>();
            foreach (string s in scores)
            {
                scoresInts.Add(int.Parse(s));
            }

            // Add data if the stored list isn't full (5 entries)
            if (scoresInts.Count < 5)
            {
                scoresInts.Add(playerValues.score);
                scoresInts.Sort();
                usernames.Add(usernameInput.text);
                notice.text = "Score successfully saved";
            }

            // Replace remove the lowest score to add the new one
            else if (playerValues.score > scoresInts[0])
            {
                scoresInts.Add(playerValues.score);
                scoresInts.Sort();
                scoresInts.RemoveAt(0);
                usernames[scoresInts.LastIndexOf(playerValues.score)] = usernameInput.text;
                notice.text = "Score successfully saved";
            }

            // Don't add the score if it's lower then the current lowest
            else { notice.text = "You didn't make it on the leaderboard."; }

            // Store the values for saving
            PlayerPrefs.SetString("Usernames", usernames.ToCommaSeparatedString());
            PlayerPrefs.SetString("Scores", scoresInts.ToCommaSeparatedString());
        }
        else 
        {
            // Store the values for saving
            PlayerPrefs.SetString("Usernames", usernameInput.text);
            PlayerPrefs.SetString("Scores", playerValues.score.ToString());
            notice.text = "Score successfully saved";
        }

        // Save the data and remove the username input box
        PlayerPrefs.Save();
        usernameInput.gameObject.SetActive(false);
    }

    public void mainMenuButtonClicked() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>().inputs.Disable();
        instance.GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene("MainMenu");
    }
}
