using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public int score = 0;
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;
    public int health = 4;
    public InputSystem_Actions inputs;

    void Start()
    {
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }
}


