﻿using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line" || collision.gameObject.tag == "Star")
        {
            if (Input.GetMouseButton(0))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}


