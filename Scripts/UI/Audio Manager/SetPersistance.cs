using System.Collections.Generic;
using UnityEngine;

public class SetPersistance : MonoBehaviour
{
    public static GameObject instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = gameObject;
        }
        else { Destroy(gameObject); } 
    }
}
