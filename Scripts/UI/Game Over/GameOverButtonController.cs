using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonController : MonoBehaviour
{
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
        bool saveData = PlayerPrefs.HasKey("Usernames") && PlayerPrefs.HasKey("Scores");

        if (saveData)
        {
            string usernamesString = PlayerPrefs.GetString("Usernames");
            List<string> usernames = usernamesString.Split(", ").ToList();

            string scoresString = PlayerPrefs.GetString("Scores");
            string[] scores = scoresString.Split(", ");
            List<int> scoresInts = new List<int>();
            foreach (string s in scores)
            {
                scoresInts.Add(int.Parse(s));
            }

            if (scoresInts.Count < 5)
            {
                scoresInts.Add(playerValues.score);
                scoresInts.Sort();
                usernames.Add(usernameInput.text);
                notice.text = "Score successfully saved";
            }
            else if (playerValues.score > scoresInts[0])
            {
                scoresInts.Add(playerValues.score);
                scoresInts.Sort();
                scoresInts.RemoveAt(0);
                usernames[scoresInts.LastIndexOf(playerValues.score)] = usernameInput.text;
                notice.text = "Score successfully saved";
            }
            else { notice.text = "You didn't make it on the leaderboard."; }


            PlayerPrefs.SetString("Usernames", usernames.ToCommaSeparatedString());
            PlayerPrefs.SetString("Scores", scoresInts.ToCommaSeparatedString());
        }
        else 
        {
            PlayerPrefs.SetString("Usernames", usernameInput.text);
            PlayerPrefs.SetString("Scores", playerValues.score.ToString());
            notice.text = "Score successfully saved";
        }
        PlayerPrefs.Save();
        usernameInput.gameObject.SetActive(false);
    }

    public async void mainMenuButtonClicked() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>().inputs.Disable();
        await Wait(150);
        SceneManager.LoadScene("Main Menu");
    }

    private async Task Wait(int delay)
    {
        await Task.Delay(delay);
    }
}
