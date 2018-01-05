using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    private MusicManager theMC;
    public int newTrack;

    public bool switchOnStart;

	// Use this for initialization
	void Start () {
        theMC = FindObjectOfType<MusicManager>();
        if (switchOnStart)
        {
            theMC.SwitchTracks(newTrack); // if a trigger occurs then switch tracks 
            gameObject.SetActive(false);
        }

		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "MainPlaye")
        {
            theMC.SwitchTracks(newTrack);
            gameObject.SetActive(false);
        }
    }
}
