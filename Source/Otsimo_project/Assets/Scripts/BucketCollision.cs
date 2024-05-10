using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCollision : MonoBehaviour
{
    public bool IsMustStop { get;  set; }


    [ExecuteInEditMode]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line" || collision.gameObject.tag == "Star")
        {

            IsMustStop = true;

            Debug.Log("entered");
        }
    }
 
}
