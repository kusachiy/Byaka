using UnityEngine;
using System.Collections;

public class badBoy : MonoBehaviour {
    public GameObject MagicKey;
    public int maxSpeed = 6;
    private GameObject cloud;
    // Use this for initialization
    bool MovedRight = true;
    bool PlayerIn = false;
    Rigidbody2D rb2d;   
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();        
	}

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.relativeVelocity.y > 10 &&collision2D.gameObject.name!="Furfly")
        {
            for (int i = 0; i < 4; i++)
                cloud = Instantiate(Resources.Load("Prefabs/BigCloud"), transform.position, transform.rotation) as GameObject;
            Instantiate(MagicKey, transform.position, transform.rotation);
            Destroy(gameObject);
        }           
        //Debug.Log ("Check");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" || other.tag == "Door" || other.tag == "Box")
        {
            Flip();
        }
        if (other.tag == "Player")
        {
            for (int i = 0; i < 4; i++)
                cloud = Instantiate(Resources.Load("Prefabs/BigCloud"), transform.position, transform.rotation) as GameObject;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }   

    // Update is called once per frame
    void Update () {
        int sign = MovedRight ? 1 : -1;
        rb2d.velocity = new Vector2(maxSpeed*sign, rb2d.velocity.y);
    }

    public void Flip()
    {
        MovedRight = !MovedRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }
}
