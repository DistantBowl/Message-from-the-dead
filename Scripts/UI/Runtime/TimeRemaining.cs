using TMPro;
using UnityEngine;

public class TimeRemaining : MonoBehaviour
{
    private TMP_Text timeDisplay;
    private DeathMarker deathMarks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeDisplay = gameObject.GetComponent<TMP_Text>();
        deathMarks = GameObject.Find("Death Marks").GetComponent<DeathMarker>();
    }

    // Update is called once per frame
    void Update()
    {
        int minuets = (int)deathMarks.deathTime/60;
        int seconds = (int)deathMarks.deathTime-minuets*60;
        // Ensures both time values are held to 2 sig figs
        timeDisplay.text = $"{(minuets.ToString().Length == 1 ? "0" : "")}{minuets}:{(seconds.ToString().Length == 1 ? "0" : "")}{seconds}";
    }
}
