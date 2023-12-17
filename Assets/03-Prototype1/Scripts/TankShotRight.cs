using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotRight : MonoBehaviour
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
        Vector3 pos = transform.position;                  

        pos.x += speed * Time.deltaTime;                   

        transform.position = pos;

        
        if (transform.position.x > rightX)
        {

            Destroy(this.gameObject);

            Prototype pScript = Camera.main.GetComponent<Prototype>();


            pScript.TankShotDestroyed();

        }
        
    }
}
