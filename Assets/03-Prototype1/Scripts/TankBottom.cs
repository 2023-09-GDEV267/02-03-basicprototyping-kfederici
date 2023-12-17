using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBottom : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject TankShotPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenFireTankShot = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireTankShot", 2f);
    }
    void FireTankShot()
    {

        GameObject TankShotUp = Instantiate<GameObject>(TankShotPrefab);

        TankShotUp.transform.position = transform.position;

        Invoke("FireTankShot", secondsBetweenFireTankShot);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {

            speed = Mathf.Abs(speed); // Move right                    

        }
        else if (pos.x > leftAndRightEdge)
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
