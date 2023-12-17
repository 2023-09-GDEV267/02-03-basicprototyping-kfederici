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
