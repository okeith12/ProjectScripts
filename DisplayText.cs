using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour {
    
    public bool guiShow = false;
    public GUIText text;
    private DialogueManager dMan;

    //public float xPosition;
    //public float yPosition;

    public void Start()
    {
        dMan = FindObjectOfType<DialogueManager>(); //Intialize the dialogue manager
    }


    private void OnTriggerEnter2D(Collider2D collision) // if player box collider hits another collider 
    {
       if(collision.gameObject.name == "MainPlaye") // if the colison came from the main player
        {
            guiShow = true; // a bool to check whether to show text or not
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainPlaye") // same as above expect when the player is leaving the trigger zone
        {
            guiShow = false;
            
        }
    }
    private void OnGUI()
    {
        if (guiShow == true) // shows the text
        {
            if (dMan.dialogActive == true) // if dialogue has started disable the GUI text
            {
                guiShow = false;
            }
            else
            {
                GUI.contentColor = Color.black;
                text.text = "Press F To Interact";
                GUI.Label(new Rect(143.46f, 175.93f, 200, 100), text.text); // location and text in the GUI
            }
                
            
            
        }
    }
}
