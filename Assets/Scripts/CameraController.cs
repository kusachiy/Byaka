using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{	
    public GameObject player1;
    public GameObject player2;
	public float m_speed = 0.1f;
	Camera mycam;
    Transform Player;

    public void Start()
	{
        Player = player1.transform;
		mycam = GetComponent<Camera> ();
	}

	public void Update()
	{

		mycam.orthographicSize = (Screen.height / 100f) / 0.7f;

		if (Player) 
		{		
			transform.position = Vector3.Lerp(transform.position, Player.position, m_speed) + new Vector3(0, 0, -12);
		}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player = Player==player1.transform?player2.transform:player1.transform;
            player1.GetComponent<FurryController>().enabled = !player1.GetComponent<FurryController>().enabled;
            player2.GetComponent<FurflyController>().enabled = !player2.GetComponent<FurflyController>().enabled;

        }
    }
}
