using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCollision : MonoBehaviour
{ 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line" || collision.gameObject.tag == "Star")
        {
           
           
                
            
        }
    }

}
