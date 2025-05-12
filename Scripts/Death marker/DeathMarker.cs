using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class DeathMarker : MonoBehaviour
{
    public float deathTime = 30;
    private GameObject currentMark;
    public bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMark = selectMarker();
        revealDeathMark();
    }

    // Update is called once per frame
    void Update()
    {
        detectPlayer();
        deathTime -= Time.deltaTime;
        if (deathTime <= 0) {dead = true;}
    }

    void detectPlayer() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(player.transform.position, currentMark.transform.position);

        if (distance <= 1) 
        {
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

        deathTime += UnityEngine.Random.Range(1, 10);

        return markers[markerID];
    }
}
