using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{	
    public GameObject player1;
    public GameObject player2;
	public float m_speed = 0.1f;
	Camera mycam;
    Transform Player;
    float[] camSize = {0.7f,0.5f,0.3f };
    int currentCam = 0;

    public void Start()
	{
        Player = player1.transform;
		mycam = GetComponent<Camera> ();
        mycam.orthographicSize = (Screen.height / 100f) / 0.7f;
    }

    public void Update()
	{


		if (Player) 
		{		
			transform.position = Vector3.Lerp(transform.position, Player.position, m_speed) + new Vector3(0, 0, -12);
		}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player = Player==player1.transform?player2.transform:player1.transform;
            player1.GetComponent<FurryController>().enabled = !player1.GetComponent<FurryController>().enabled;
            player2.GetComponent<FurflyController>().enabled = !player2.GetComponent<FurflyController>().enabled;
            if (player2.GetComponent<FurflyController>().enabled)
            {
                player2.GetComponent<FurflyAutopilot>().enabled = false;                
                
            }
            else
            {
                player2.GetComponent<FurflyAutopilot>().enabled = true;
            }
       }
        if (Input.GetKeyDown(KeyCode.V))
        {
            mycam.orthographicSize = (Screen.height / 100f) / camSize[currentCam = (currentCam+1)%3];
        }
    }
}
