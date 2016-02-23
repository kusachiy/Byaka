using UnityEngine;
using System.Collections;

public class Door_openning : MonoBehaviour {
    public int keysToWin = 1;
    public int CurrentCount=0;
    
	// Use this for initialization
	void Start () {
        CurrentCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (CurrentCount>=keysToWin)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
