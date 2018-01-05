using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static bool musicExist;
    public AudioSource[] tracks;
    public int currentTrack;
    public bool musicCanPlay;

	// Use this for initialization
	void Start () {
        if (!musicExist) //if player exist is false them
        {
            musicExist = true;
            DontDestroyOnLoad(transform.gameObject); // When a nevel level is loaded it makes sure the sound effect isnt deleted.

        }
        else
        {
            Destroy(gameObject); //the new player gets destoryed so stop duplicates
        }

    }

    // Update is called once per frame
    void Update () {
        if (musicCanPlay)
        {
            if (!tracks[currentTrack].isPlaying) // plays the current track
            {
                tracks[currentTrack].Play();
            }
        }
        else
        {
            tracks[currentTrack].Stop();
        }
	}
    public void SwitchTracks(int newTrack) // when wanting to switch tracks
    {
        tracks[currentTrack].Stop();
        currentTrack = newTrack;
        tracks[currentTrack].Play();

    }
}
