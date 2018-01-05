using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
    public AudioSource playerHurt; //ANY AUDIO SOURCE FOR WHATEVER SOUND YOU WANT
    private static bool sfxExist;


	// Use this for initialization
	void Start () {
        if (!sfxExist) //if player exist is false them
        {
            sfxExist = true;
            DontDestroyOnLoad(transform.gameObject); // When a nevel level is loaded it makes sure the sound effect isnt deleted.

        }
        else
        {
            Destroy(gameObject); //the new player gets destoryed so stop duplicates
        }


    }

  
}
