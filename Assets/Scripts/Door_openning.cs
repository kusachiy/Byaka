using UnityEngine;
using System.Collections;

public class Door_openning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
