using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraController theCamera; // if I have bounds for big maps this script get utilized


	// Use this for initialization
	void Start () {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraController>();
       // theCamera.SetBounds(bounds);
	}
	
}
