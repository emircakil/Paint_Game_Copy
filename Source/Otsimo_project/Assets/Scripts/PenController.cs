using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : MonoBehaviour
{
    // Controller for tools.

    public GameObject eraser;
    public GameObject pen;
    public GameObject bucket;
    public GameObject star;
    public GameObject paintball;
    public void switchPen()
    {

        pen.SetActive(true);
        eraser.SetActive(false);
        bucket.SetActive(false);
        star.SetActive(false);
        paintball.SetActive(false);
    }

    public void switchErase()
    {

        pen.SetActive(false);
        eraser.SetActive(true);
        bucket.SetActive(false);
        star.SetActive(false);
        paintball.SetActive(false);
    }

    public void switchBucket()
    {

        pen.SetActive(false);
        eraser.SetActive(false);
        bucket.SetActive(true);
        star.SetActive(false);
        paintball.SetActive(false);
    }

    public void switchStar()
    {

        pen.SetActive(false);
        eraser.SetActive(false);
        bucket.SetActive(false);
        star.SetActive(true);
        paintball.SetActive(false);
    }

    public void switchPaintball() {

        pen.SetActive(false);
        eraser.SetActive(false);
        bucket.SetActive(false);
        star.SetActive(false);
        paintball.SetActive(true);
    }
}
