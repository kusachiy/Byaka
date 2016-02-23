using UnityEngine;
using System.Collections;

public class SilverKey : MonoBehaviour {    
    GameObject door; 
	// Use this for initialization
	void Start () {
        door = GameObject.Find("doorSilverKey");
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            door.GetComponent<Door_openning>().CurrentCount++;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
