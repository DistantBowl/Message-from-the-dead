using TMPro;
using UnityEngine;

public class ScoreElement : MonoBehaviour
{
    private TMP_Text score;
    private PlayerValues playerValues;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = gameObject.GetComponent<TMP_Text>();
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = playerValues.score.ToString();
    }
}
