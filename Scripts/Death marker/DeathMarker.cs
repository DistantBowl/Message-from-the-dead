using Unity.Mathematics;
using UnityEngine;

public class DeathMarker : MonoBehaviour
{
    public float deathTime = 15;
    private GameObject currentMark;
    private PlayerValues playerValues;
    public GameObject vengeful;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
        currentMark = selectMarker();
        revealDeathMark();
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer();
        deathTime -= Time.deltaTime;
        if (deathTime <= 0) 
        {
            Instantiate(vengeful, currentMark.transform.position, new quaternion(0,0,0,0));
            deathTime += 15;
            currentMark.layer = LayerMask.NameToLayer("Invisible markers");
            currentMark = selectMarker();
            revealDeathMark();
        }
    }

    void detectPlayer() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(player.transform.position, currentMark.transform.position);

        if (distance <= 1.5) 
        {
            gameObject.GetComponent<AudioSource>().Play();
            playerValues.score += (int)(50 * deathTime);
            currentMark.layer = LayerMask.NameToLayer("Invisible markers");
            currentMark = selectMarker();
            revealDeathMark();
        }
    }  

    void revealDeathMark() 
    {
        currentMark.layer = LayerMask.NameToLayer("Visible markers");
    }

    GameObject selectMarker() 
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Death marker");
        int markerID = (int)UnityEngine.Random.Range(0,markers.Length);

        deathTime += UnityEngine.Random.Range(1, 5);

        return markers[markerID];
    }
}
