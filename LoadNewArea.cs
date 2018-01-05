using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {
    public string levelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) // when entering a certain trigger zone such as  front door player enters new scene assoicated with it
    {
        if(collision.gameObject.name == "MainPlaye")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
