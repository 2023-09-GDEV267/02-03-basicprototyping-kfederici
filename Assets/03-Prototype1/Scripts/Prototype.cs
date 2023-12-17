using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prototype : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
        {
            
        }
    }

    public void TankShotDestroyed()
    {
        // destroy all of the falling apples
        GameObject[] tShotArray = GameObject.FindGameObjectsWithTag("TankShot");
        foreach (GameObject tGO in tShotArray)
        {
            Destroy(tGO);
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
