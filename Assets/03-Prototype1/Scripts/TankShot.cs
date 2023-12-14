using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShot : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bottomZ = -30f;
    public static float topZ = 30f;
    public static float leftX = -30f;
    public static float rightX = 30f;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;                  // b

        pos.x += speed * Time.deltaTime;                   // c

        transform.position = pos;

        if (transform.position.z < bottomZ)
        {

            Destroy(this.gameObject);                                      // b

        }
        if (transform.position.z > topZ)
        {

            Destroy(this.gameObject);                                      // b

        }
        if (transform.position.x < leftX)
        {

            Destroy(this.gameObject);                                      // b

        }
        if (transform.position.x > rightX)
        {

            Destroy(this.gameObject);                                      // b

        }
        return;
    }
}
