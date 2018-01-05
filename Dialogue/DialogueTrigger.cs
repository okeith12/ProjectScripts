using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue; // allows for text
    private DialogueManager dMan; // allows for a dialogue box
   

    

    void Start()
    {
       
        dMan = FindObjectOfType<DialogueManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainPlaye") //Name of main player object, didnt feel like ediiting the R back when named it.
        {
            
            if (Input.GetKeyUp(KeyCode.F)) // if F is pressed
            {

                dMan.StartDialogue(dialogue); // the dialogue function begins showing the dialogue
                
            }
            if(transform.parent.GetComponent<NPCMovement>() != null) // if it is attached to NPC
            {

                transform.parent.GetComponent<NPCMovement>().canMove = false; //it restricts NPC movement during dialogue
                


            }
            
        }

    }
    

}
