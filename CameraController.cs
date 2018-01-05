using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //ALL THOSE COMMENTED OUT ONLY WORKS ON BIG LOCATIONS DUE TO ME SEARCHING FOR THE END OF THE MAP THEN SPLITING THAT TIME SO tHE CAMERA DOESNT DRAG OFF
    //IN A SMALL MAP IT RESTRICTS THE BOUND SO BAD I CANT CONTINUE
    public GameObject target;
    private Vector3 targetPosition;
    public float cameraSpeed;
    private static bool cameraExist;
    //public BoxCollider2D boundBox;
    //private Vector3 minBounds;
    //private Vector3 maxBounds;

 //   private Camera theCamera;
   // private float halfHeight;
    //private float halfWidth;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        if (!cameraExist) //if player exist is false them
        {
            cameraExist = true;
            DontDestroyOnLoad(transform.gameObject); // When a nevel level is loaded it makes sure the lpayer controller isnt deleted.

        }
        else
        {
            Destroy(gameObject); //the new player gets destoryed so stop duplicates
        }
   //     minBounds = boundBox.bounds.min;
     //   maxBounds = boundBox.bounds.max; 
       // theCamera = GetComponent<Camera>();
        //halfHeight = theCamera.orthographicSize;
        //halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
      /*  if (boundBox == null)
        {
            boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;

        }
        
        if (boundBox != null) //INPUT THE IF STATEMENT IF SMALL AREA
        {
        float clampedx = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedy = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedx, clampedy, transform.position.z);
        }
        
    */
	}
    //public void SetBounds(BoxCollider2D newBounds)
    //{
      //  boundBox = newBounds;
        //minBounds = boundBox.bounds.min;
        //maxBounds = boundBox.bounds.max;

 //   }
}
