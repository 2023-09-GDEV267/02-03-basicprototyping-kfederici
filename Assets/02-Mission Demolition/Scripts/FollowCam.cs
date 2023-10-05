using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //the static point of interest
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    //the desired Z pos of the camera
    public float camZ;

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    //if there's only one line following an if, it doesn't need braces
    void FixedUpdate()
    {
        //return if there is no poi
        if (POI == null) return;
        //get the position of the poi
        Vector3 destination = POI.transform.position;
        //limit the X and Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        //set the camera to the destination
        transform.position = destination;
        //set the orthographicSize of the Camera to keep the ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }
}
