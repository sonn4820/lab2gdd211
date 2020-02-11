using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{

    float runSpeed; // player's speed
    float jumpForce; // player's jumpforce
    Animator myAnimator;
    public bool grounded = true; // set grounded as true
    public GameObject groundCheck = null; // gcheck is null
    public bool hott = false; // bool to check if he is on hot pf

    public GameObject panel1;
    public GameObject panel2;
    public GameObject Text;




    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        Text.gameObject.SetActive(true);
    } // set up the panel to communicate with players

    // Update is called once per frame
    void Update()
    {
        

        Debug.DrawLine(transform.position, groundCheck.transform.position, Color.yellow);
        if (Physics2D.Linecast(transform.position, groundCheck.transform.position))
        {
            grounded = true; // if there is a hit on our linecast we are on a platform - set grounded to true
            RaycastHit2D hitPlatform = Physics2D.Linecast(transform.position, groundCheck.transform.position); // name the object we are hitting hitplatform


           if (hitPlatform != null && hitPlatform.collider.tag == "Hot")// if the hitplatform is hot, set the other bool
           {
                 hott = true;
                 runSpeed = 1f;
                 jumpForce = 350f;
           }
        }
        else
        {
            runSpeed = 2.1f;
            jumpForce = 250f;
            grounded = false;
            hott = false;
            //if we aren't hitting any platform, set all bools to false
        }


        // send state of all parameters to the animator
        myAnimator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        myAnimator.SetBool("Grounded", grounded); // jump ani
        myAnimator.SetBool("Hot", hott); // hot ani
        

        float currentYVel = GetComponent<Rigidbody2D>().velocity.y; 

        if (Input.GetKey(KeyCode.A)) // press the button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel); // set the velocity of the player
            gameObject.transform.localScale = new Vector2(-1, transform.localScale.y); // make it move
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);

        
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded) //only jump when grounded
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("Jump"); // jump trigger
            Debug.Log(grounded);

        }
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death") // collide with lava or dragon
        {
            Destroy(gameObject);
            Debug.Log("Hit");
            panel1.gameObject.SetActive(true);
            Text.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Win") // collide with the aegis
        {
            Time.timeScale = 0;
            panel2.gameObject.SetActive(true);
            Text.gameObject.SetActive(false);
        }
    }
}