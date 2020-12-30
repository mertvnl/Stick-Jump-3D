using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public float stickSizeToGain = 0.1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StickUp();
        }
    }

    public void StickUp()
    {
        Vector3 newStickSize = new Vector3(0, stickSizeToGain, 0);
        transform.position += newStickSize;
        transform.localScale += newStickSize;
    }
}
