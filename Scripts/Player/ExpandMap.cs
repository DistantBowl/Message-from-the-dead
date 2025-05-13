using UnityEngine;

public class ExpandMap : MonoBehaviour
{
    private PlayerValues playerValues;
    private GameObject map;
    private GameObject miniMap;
    private bool switched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerValues>();
        map = GameObject.Find("Map backround");
        map.SetActive(false);
        miniMap = GameObject.Find("Mini map backround");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerValues.inputs.Player.ExpandMap.ReadValue<float>() > 0) 
        {
            if (!switched) 
            {
                map.SetActive(!map.activeSelf);
                miniMap.SetActive(!miniMap.activeSelf);
                switched = true;
            }
        }
        else { switched = false; }
    }
}
