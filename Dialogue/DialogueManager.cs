using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox; // dialogue box
    public Animator animator; // for animation but currently disabled
    public Text nameText; // name of speaker
    public Text dialogueText; // text
    public bool dialogActive; // ensures the box pops up
    public int currentSentence; // what sentence is currently on 
    

    private Queue<string> sentences; // using queue for FIFO to hold sentences instead of array like initially
    private PlayerController thePlayer; // the player
  

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>(); // initialize
       
        sentences = new Queue<string>(); // initailze
	}
    private void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.F)) // if pressing down F and the dbox is open to close or open GAIN
        {
            dBox.SetActive(false);
            dialogActive = false;
          
          
        }
        if(dialogActive && Input.GetKeyDown(KeyCode.X)) // to move to the next sentence
        {
            //dBox.SetActive(false);
            //dialogActive = false;
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue) // begins the dialigue 

    {

            dialogActive = true;
            dBox.SetActive(true);
            nameText.text = dialogue.name;
            sentences.Clear(); // clears before displaying the next one
            thePlayer.canMove = false;

        foreach (string sentence in dialogue.sentences) // finds each sentece
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        
    }
  
    public void DisplayNextSentence() // self explanatory
    {
        
        if(sentences.Count == 0)
        {
            dBox.SetActive(false);
            dialogActive = false;
            EndDialogue();
           // thePlayer.canMove = true;
            return;
        }
        thePlayer.canMove = false;
        string sentence = sentences.Dequeue();
        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = ""; // allows for senetnce to be leter by letter not full blown word
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue() // the dialogue is over so player can move again 
    {

        thePlayer.canMove = true;
        Debug.Log("End of Conversation");
        //animator.SetBool("IsOpen", false);

    }
}
