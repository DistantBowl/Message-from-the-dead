using UnityEngine;

public class ChooseDeathMarker : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject selectMarker() 
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Death marker");
        int markerID = (int)Random.Range(0,markers.Length);
        return markers[markerID];
    }
}
