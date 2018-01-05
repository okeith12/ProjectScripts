using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
    public float moveSpeed; // speed npc moves
    private Animator anim; // ensures animation of NPC
   
    private Rigidbody2D myRigidBody; // gives NPC a rigidbody 
    public bool isWalking; // check if NPC is walking
    public float walkTime; // how long NPC can walk 
    public float waitTime; // how long he most wait to walk again
    private float walkCounter; // the counter to see if he must walk
    private float waitCounter; // the counter to see if he must wait

    private int walkDirection; // the direction choice the NPC moves

    public Collider2D walkArea; // the restricted area that the NPC must move 
    private Vector2 mimWalkPoint; // the distance before it collides with walkARea
    private Vector2 maxWalkPoint; // the distance before it collides with walkARWA
    public Vector2 lastMove; // just like player to ensure IDLE

    private bool hasWalkArea = false; // automicatlly set it to false
    public bool canMove; // if dialogue would be false
  
    private DialogueManager dMan; // dialogue
    private PlayerController thePlayer; // interaction with player

    public int movementChoice; // 4 different random NPC movements I created

    public Transform[] path; // for one of the differnt NPC movement 
    public float speed = 5.0f; // speed he moves
    public float reachDist = 1.0f; // the distance till he reach the given path
    public int currentPoint = 0; // the location where he is at
   


  



	// Use this for initialization
	void Start () {
        
        canMove = true;
        dMan = FindObjectOfType<DialogueManager>(); // iinitialzing 
        thePlayer = FindObjectOfType<PlayerController>(); // same thing
        myRigidBody = GetComponent<Rigidbody2D>(); // same 
        anim = GetComponent<Animator>(); // also the same


        waitCounter = waitTime; // however long the counter is howeer long the NPC wait to move again
        walkCounter = walkTime; // same as above but for walking
        chooseDirection(); // the inital direction but can be changed
        if (walkArea != null) // if the walk area is present
        {
            mimWalkPoint = walkArea.bounds.min;
            maxWalkPoint = walkArea.bounds.max;
            hasWalkArea = true;
        }

	}
	
	// Update is called once per frame
	void Update () {
       

        if (!dMan.dialogActive) // if dialogue is over, then NPC can move
        {
            canMove = true; 
           
           
          

        }

        if (!canMove) // if dialogue active he cant move and thier velocity is stand still
        {

            myRigidBody.velocity = Vector2.zero;
        

            
            //  lastMove = new Vector2(-1f, 0f);
            
            return;
           
            
           
        }
        


        if (isWalking) // if is wlaking is true
        {
            lastMove = Vector2.zero; // initalize the last move
            walkCounter -= Time.deltaTime; // decrease the walk time over period of time
           
            switch (walkDirection) // choose which direction NPC wants based off random
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed); //MOVE UP
                    lastMove = new Vector2(0f, 1f);
                    if (hasWalkArea && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                    
                        waitCounter = waitTime;

                    }
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed); //MOVE DOWN
                    lastMove = new Vector2(0f, -1f);
                    if (hasWalkArea && transform.position.y < mimWalkPoint.y)
                    {
                        isWalking = false;
                     
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0); //MOVELEFT
                    lastMove = new Vector2(-1f, 0f);
                    if (hasWalkArea && transform.position.x < mimWalkPoint.x)
                    {
                        isWalking = false;
              
                        waitCounter = waitTime;
                        myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    }
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0); //MOVERIGHT
                    lastMove = new Vector2(1f, 0f);
                    if (hasWalkArea && transform.position.x < maxWalkPoint.x)
                    {
                        isWalking = false;
                       
                        waitCounter = waitTime;
                        myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    }
                    break;
            }
            if (walkCounter < 0) // WAITTIME
            {
                isWalking = false;
                waitCounter = waitTime;
               
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (waitCounter < 0)

            {
                switch (movementChoice)
                {
                    case 0:
                        chooseDirection();
                        break;
                    case 1:
                        chooseDirection2Way();
                        break;
                    case 2:
                        chooseDirection3Way();
                        break;
                    case 3:
                        chooseDirection4Way();
                        break;
                    case 4:
                        chooseDirectionPath();
                        break;
                }
                    

            }
        }
        anim.SetBool("IsWalking", isWalking);
        anim.SetFloat("MoveX", myRigidBody.velocity.x);
        anim.SetFloat("MoveY", myRigidBody.velocity.y);
        anim.SetFloat("LastMoveX", lastMove.x); // give the animator the last move x
        anim.SetFloat("LastMoveY", lastMove.y);

      
    }
    public void chooseDirection() // moves all for directions if wanted in random
    {
            walkDirection = Random.Range(0, 4);
            isWalking = true;
            walkCounter = walkTime;
 
        
    }
    public void chooseDirection2Way() // moves all diredctions expect right
    {
        walkDirection = Random.Range(0, 3);
        isWalking = true;
        walkCounter = walkTime;
    }
    public void chooseDirection3Way() // move only right or left
    {
        walkDirection = Random.Range(2, 3);
        isWalking = true;
        walkCounter = walkTime;
    }
    public void chooseDirection4Way() // doesnt move but stay idle
    {
        walkDirection = 0;
        isWalking = false;
        lastMove = new Vector2(0f, -1f);
    }
    private void OnDrawGizmos() // draws the path
    {
        if (path.Length > 0)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    // Gizmos.DrawLine()
                    Gizmos.DrawSphere(path[i].position, reachDist);
                }
            }
        }
    }
    public void chooseDirectionPath() //follows the path
    {
         for (int i = 0; i<path.Length; i++) {

            if (path[i] != null) {
                
                // walkCounter = walkTime;
                if (canMove)
                {
                    float dist = Vector3.Distance(path[currentPoint].position, transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);


                    if (dist <= reachDist)
                    {
                        currentPoint++;
                    }
                    if (currentPoint >= path.Length)
                    {
                        currentPoint = 0;
                    }
                }
            }
        }
        
    }

}
