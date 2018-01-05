using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {
    //ATTACH TO SOUnD EFFECTS AND MUSIC
    private AudioSource theAudio;
    private float audioLevel;
    public float defaultAudio;

	// Use this for initialization
	void Start ()
    {
        theAudio = GetComponent<AudioSource>();

		
	}
	
	
    public void SetAudioLevel(float volume)

    {
        if(theAudio == null)
        {
            theAudio = GetComponent<AudioSource>();
        }
        audioLevel = defaultAudio * volume; // allows for custom volume levels to stay the same 
        theAudio.volume = audioLevel;
    }
}
