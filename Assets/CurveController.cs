using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveController : MonoBehaviour
{
    public Transform Curve;
    public float rotateAngle;
    private void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(RotateCurve());
    }

    IEnumerator RotateCurve()
    {
        float percent = 0;
        while (percent <1)
        {
            percent += Time.deltaTime / 0.2f;
            Curve.Rotate(0,0,Time.deltaTime / 0.2f * rotateAngle);

            yield return null;
        }
    }
}
