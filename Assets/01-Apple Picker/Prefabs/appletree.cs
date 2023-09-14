using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appletree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the apple tree moves
    public float speed = 1f;

    //distance where apple tree turns around
    public float leftAndRightEdge = 10f;

    //chance that the apple tree will change direction
    public float chanceToChangeDirections = 0.1f;

    //rate at which apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //dropping apples every second

    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }

    }

    void FixedUpdate()
    {
        //changing direction randomly is time based
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change direction
        }
        
    }
}
