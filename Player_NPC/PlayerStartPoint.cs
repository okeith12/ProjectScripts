using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{

    private PlayerController thePlayer;// using the concept of inhertiance of the player
    private CameraController theCamera; // using the inhertaince of the camera

    public Vector2 startDirection; // For the starting direction when characters enter the house

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>(); // find the object that has the player controller attached to it
        thePlayer.transform.position = transform.position; // put the player at the same start point as the startug point
        thePlayer.lastMove = startDirection;
        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z); // to ensure the z point doesnt change
    }

    // Update is called once per frame
    void Update()
    {

    }
}