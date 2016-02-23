using UnityEngine;
using System.Collections;

public class GameRules : MonoBehaviour
{
    public GUIText gui;
    int playersOnExit = 0;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playersOnExit++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playersOnExit--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playersOnExit == 2)
        {
            gui.text = "Mission Comleted";
        }
    }
}
    
   
