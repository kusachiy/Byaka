using UnityEngine;
using System.Collections;


public class HitVelDetection : MonoBehaviour {
    public GameObject cloud;
	// Use this for initialization
	void Start(){
		

	}

	void OnCollisionEnter2D(Collision2D collision2D) {

        if (collision2D.relativeVelocity.magnitude > 35)
        {
            for (int i = 0; i < 4; i++)          
                cloud = Instantiate(Resources.Load("Prefabs/BigCloud"), transform.position, transform.rotation) as GameObject;                       
            Destroy(gameObject);
        }
		//Debug.Log ("Check");
	
	}  



    // Update is called once per frame
    void Update () {
		
	}
}