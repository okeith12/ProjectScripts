using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    public VolumeController[] volumeObjects;

    public float currentVolumeLevel; // the current volume
    public float maxVolumeLevel;

	// Use this for initialization
	void Start () {
        volumeObjects = FindObjectsOfType<VolumeController>();

        if(currentVolumeLevel > maxVolumeLevel)  // ensure the volume cant go higher then 1 (100%)
        {
            currentVolumeLevel = maxVolumeLevel;
        }
       

        for(int i = 0; i < volumeObjects.Length; i++) // set audio for all vlumes 
        {
            volumeObjects[i].SetAudioLevel(currentVolumeLevel);
        }
	}
	
	
}
