﻿using UnityEngine;
using System.Collections;

public class FurflyController : MonoBehaviour
{   
    public float maxSpeed = 6f;
    public float jumpForce = 1000f;   
    public float verticalSpeed = 20;
    [HideInInspector]
    public bool lookingRight = true;   
    public GameObject Boost;

    private Animator cloudanim;
    public GameObject Cloud;


    private Rigidbody2D rb2d;    
    private Animator anim; 


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        
        //cloudanim = GetComponent<Animator>();
        Cloud = GameObject.Find("Cloud");
        //cloudanim = GameObject.Find("Cloud(Clone)").GetComponent<Animator>();    
    } 


    void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.relativeVelocity.magnitude > 20)
        {
            Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
            //	cloudanim.Play("cloud");	

        }
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2d.AddForce(new Vector2(0, jumpForce));           
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            rb2d.AddForce(new Vector2(0, -jumpForce));
            Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
            //cloudanim.Play("cloud");
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