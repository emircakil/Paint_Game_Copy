using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject() { 
    
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }
}
