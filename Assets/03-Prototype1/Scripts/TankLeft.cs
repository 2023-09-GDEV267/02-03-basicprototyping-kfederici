using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankLeft : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject TankShotRightPrefab;
    public float speed = 6f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenFireTankShot = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireTankShot", 2f);
    }
    void FireTankShot()
    {                                                  

        GameObject TankShotRight = Instantiate<GameObject>(TankShotRightPrefab);      

        TankShotRight.transform.position = transform.position;                  

        Invoke("FireTankShot", secondsBetweenFireTankShot);                

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;                  

        pos.z += speed * Time.deltaTime;                   

        transform.position = pos;

        if (pos.z < -leftAndRightEdge)
        {                             

            speed = Mathf.Abs(speed); // Move right                    

        }
        else if (pos.z > leftAndRightEdge)
        {                       

            speed = -Mathf.Abs(speed); // Move left                    

        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {                     

            speed *= -1; // Change direction

        }
    }
}