using UnityEngine;
using System.Collections;

public class FurflyController : MonoBehaviour
{   
    private float maxSpeed = 3f;
    private float jumpForce = 10f;
        
    [HideInInspector]
    public bool lookingRight = true;   
    public GameObject Boost;

    bool hasObject = false;
          
    public GameObject Cloud;


    private Rigidbody2D rb2d;    
    private Animator anim; 


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();     
        Cloud = GameObject.Find("Cloud");        
    } 


    void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.relativeVelocity.magnitude > 20)
        {
            Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;            
        }      

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(new Vector2(0, jumpForce));           
        }


        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(new Vector2(0, -jumpForce));             
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(0,0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!hasObject)
            {                
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
                if (hit.distance < 1f && (hit.collider.tag == "Box"|| hit.collider.tag == "Player"))
                {
                    jumpForce = 100f;
                    GetComponent<DistanceJoint2D>().connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    GetComponent<DistanceJoint2D>().enabled = true;                    
                    hasObject = true;
                }
            }
            else
            {
                jumpForce = 10f;
                hasObject = false;
                GetComponent<DistanceJoint2D>().enabled = false;
            }
        }

    }


    void FixedUpdate()
    {        

        float hor;
        hor = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0;       

        rb2d.velocity = new Vector2(hor * maxSpeed, rb2d.velocity.y);    

       

        if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
            Flip();

        
        /*float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		  
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();
		
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);*/
    }



    public void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }

}
