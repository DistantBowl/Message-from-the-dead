using UnityEngine;
using UnityEngine.UI;

public class HealthElement : MonoBehaviour
{
    private PlayerValues playerValues;

    private void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
    }

    private void Update()
    {
        GetComponent<Slider>().value = playerValues.health;
    }
}
