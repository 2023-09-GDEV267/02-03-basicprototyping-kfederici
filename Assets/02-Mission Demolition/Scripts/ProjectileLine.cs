using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; //singleton

    [Header("Set In Inspector")]
    public float minDist = 0.1f;
    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;
    
    void Awake()
    {
        S = this;  //set the singleton
        //get a reference to the LineRenderer
        line = GetComponent<LineRenderer>();
        // disable the line renderer until it's needed
        line.enabled = false;
        //initialize the points List
        points = new List<Vector3>();
    }

    //this is a property ( a method masquerading as a field)
    public GameObject poi
    {
        get
        {
            return (_poi);
        }
        set
        {
            _poi = value;
            if (poi!= null)
            {
                //when _poi is set to something new, it resets
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        
        }
    }
    //this can be used to clear the line directly
    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }
    public void AddPoint()
    {
        //this is called to add a point to a line
        Vector3 pt = _poi.transform.position;
        if (points.Count>0 && (pt - lastPoint).magnitude < minDist)
        {
            //if the point isn't far enough from the last point, it returns
            return;
        }
        if (points.Count == 0)
        {
            Vector3 launchPosDiff = pt -Slingshot.LAUNCH_POS;
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            //sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            //enables the line renderer
            line.enabled = true;
        }
        else
        {
            //normal behavior of adding a point
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }
    }
    //returns the location of the most recently added point
    public Vector3 lastPoint
    {
        get
        {
            if (points == null)
            {
                //if there are no points, returns Vector3.zero
                return (Vector3.zero);
            }
            return points[points.Count - 1];
        }
    }
    void FixedUpdate()
    {
        if (line != null)
        {
            //if there is no poi, search for one
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    //return if we didn't find a poi
                    return;
                }
            }
            else
            {
                //return if we didn't find a poi
                return;
            }
        }
        //if there is a poi, it's loc is added evert FixedUpdate
        AddPoint();
        if (FollowCam.POI == null)
        {
            //once FollowCam.POI is null, make the local poi null too
            poi = null;
        }
    }
}
