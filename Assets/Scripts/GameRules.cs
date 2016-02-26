using UnityEngine;
using System.Collections;

public class GameRules : MonoBehaviour
{
    public GUIText gui;
    public GameObject Player1;
    public GameObject Player2;
    public Camera GlobalCam;
    private Vector3 Player1Respawn;
    private Vector3 Player2Respawn;
    int playersOnExit = 0;
    // Use this for initialization
    void Start()
    {
        Player1Respawn = Player1.transform.position;
        Player2Respawn = Player2.transform.position;
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
        if (!Player1)
        {
            Player1 = new GameObject();
            Invoke("ResurrectionFurry", 7f);
        }
        if (!Player2)
        {
            Player2 = new GameObject();
            Invoke("ResurrectionFurfly", 7f);            
        }
    }

    void ResurrectionFurry()
    {
        Player1 = Instantiate(Resources.Load("Prefabs/Furry") as GameObject, Player1Respawn, Quaternion.identity) as GameObject;
        Player1.GetComponent<FurryController>().enabled = false;
        GlobalCam.GetComponent<CameraController>().player1 = Player1;
    }
    void ResurrectionFurfly()
    {
        Player2 = Instantiate(Resources.Load("Prefabs/Furfly") as GameObject, Player2Respawn, Quaternion.identity) as GameObject;
        GlobalCam.GetComponent<CameraController>().player2 = Player2;
    }
}
    
   
