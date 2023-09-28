using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        // destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //destroy one of the baskets
        //get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        //get a reference to that Basket GameObject
        GameObject tBasketGo = basketList[basketIndex];
        //remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);
        //if there are no Baskets left, restart the game
        if (basketList.Count==0)
        {
            SceneManager.LoadScene("Scene1");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
