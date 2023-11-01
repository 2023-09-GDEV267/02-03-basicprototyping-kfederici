using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject TankShotPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenTankShots = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireTankShot", 2f);
    }
    void FireTankShot()
    {                                                  // b

        GameObject TankShot = Instantiate<GameObject>(TankShotPrefab);      // c

        TankShot.transform.position = transform.position;                  // d

        Invoke("FireTankShot", secondsBetweenFireTankShot);                // e

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;                  // b

        pos.x += speed * Time.deltaTime;                   // c

        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {                             // a

            speed = Mathf.Abs(speed); // Move right                    // b

        }
        else if (pos.x > leftAndRightEdge)
        {                       // c

            speed = -Mathf.Abs(speed); // Move left                    // c

        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {                     // b

            speed *= -1; // Change direction

        }
    }
}
