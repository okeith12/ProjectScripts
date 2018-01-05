using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; //To control the player speed. PUBLIC means i can change it in unity, private maeans i cant
    private Animator anim; // To Connect to the animators 
    private bool playerMoving; //The bool to see if the player is moving
    public Vector2 lastMove; // Vector 2 takes two arguments x and y while Vector 3 takes x,y,z // this is set up for the two last move variables we have
    private Rigidbody2D myRigidbody; // To connect to the rigidbody which control the collision
    private static bool playerExist; // TO check if the plater already ecist when they dont destroy on load occur
    private bool attacking; //FOr ATTACKING
    public float attackTime; //Hwo long they attack
    private float attackTimeCounter;
    private SFXManager sfxManager;
    public bool canMove;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); //Intialize the animator 
        myRigidbody = GetComponent<Rigidbody2D>(); //Intialize the collison method
        sfxManager = FindObjectOfType<SFXManager>(); // Intialze the Sound effects 
        canMove = true;
        if(!playerExist) //if player exist is false them
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject); // When a nevel level is loaded it makes sure the lpayer controller isnt deleted.

        }
        else
        {
            Destroy(gameObject); //the new player gets destoryed so stop duplicates
        }

        
		
	}
	

	// Update is called once per frame
	void Update () {
        playerMoving = false; // Every frame it will say playerMoving is false then check for an input.
        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (!attacking) //IF IT NOT ATTACKING WE ADD EVERTTHING INTO INTO 
        {

            float movementInputX = Input.GetAxisRaw("Horizontal"); //MOvement in regards to moving left or right
            float movementInputY = Input.GetAxisRaw("Vertical"); //Movement in regards to moving up or down

            Vector2 direction = new Vector2(movementInputX, movementInputY); // the direction the animation face
            direction.Normalize();
            direction *= moveSpeed * Time.deltaTime; //mutiple the speed by time delta time so varies with the update and not increase the speed past normal


            if ((movementInputX != 0f && movementInputY != 0f) || (movementInputX != 0f || movementInputY != 0f)) //if movement isnt zero
            {
                transform.Translate(new Vector3(direction.x, direction.y, 0f)); //transform player object towards imput direction
                myRigidbody.velocity = direction; // rigidbody allows for collision to occur
                playerMoving = true; // bool to check if player should move or not
                lastMove = new Vector2(movementInputX, movementInputY); //ti display the idle animations in regard to last known direction
            }

            if (movementInputX < 0.5f && movementInputX > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y); // allows to be store within the rigidbody for animations
            }

            if (movementInputY < 0.5f && movementInputY > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f); // same as above
            }
            if (Input.GetKeyDown(KeyCode.Space)) //When i press space it shouldl happen
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
              //  sfxManager.playerHurt.Play(); FOR WHATEVER SOUND YOU ARE DOING it is commented out cause i Disabled sfx but works
            }
            

        }

        if(attackTimeCounter > 0) //Give the time to attack
        {
            attackTimeCounter -= Time.deltaTime;
        }
        else
        {
            attacking = false;
            anim.SetBool("Attack", false);

            

        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal")); // TO GIve the animator towards the MOVEX we created to the input which is user moving
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical")); // This is for the vertical axis 
        anim.SetBool("PlayerMoving", playerMoving); // Gives the animator the bool player moving
        anim.SetFloat("LastMoveX", lastMove.x); // give the animator the last move x
        anim.SetFloat("LastMoveY", lastMove.y); // give the animator the last move y
    



    }
}
