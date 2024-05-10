using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    public GameObject paintPrefab;
    HashSet<int> visited = new HashSet<int>();
    bool isMustStop = false;
    BucketCollision bucketCollision;

 

    private void Update()
    {
 
        if (Input.GetMouseButtonDown(0))
        {
          

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            visited = new HashSet<int>();
            floodFill(mousePosition, 20);
            
             
        }
        
    }

    
    void floodFill(Vector2 objectPosition , int n)
    {
/*
        if (visited.Contains(n) || visited.Count > 20)
            return;
        visited.Add(n);
*/

        GameObject paintInstance = Instantiate(paintPrefab, objectPosition, Quaternion.identity);

        bucketCollision = paintInstance.GetComponent<BucketCollision>();

        // Wait for the collision detection to complete
        StartCoroutine(WaitForCollision(bucketCollision, () =>
        {
            if (bucketCollision.IsMustStop)
            {
                return;
            }
       
            floodFill(new Vector2(objectPosition.x, objectPosition.y + 0.2f), n - 1);
            floodFill(new Vector2(objectPosition.x, objectPosition.y - 0.2f), n - 1);
            floodFill(new Vector2(objectPosition.x + 0.2f, objectPosition.y), n - 1);
            floodFill(new Vector2(objectPosition.x - 0.2f, objectPosition.y), n - 1);
        }));
    }

    private IEnumerator WaitForCollision(BucketCollision bucketCollision, Action callback)
    {
        yield return new WaitForFixedUpdate();
        callback();
    }

}
    

