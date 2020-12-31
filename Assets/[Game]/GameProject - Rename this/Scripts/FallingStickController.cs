using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStickController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public Rigidbody Rigidbody
    {
        get
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }

            return rigidbody;
        }
    }

    void Start()
    {
        transform.localScale = new Vector3(.1f, GameManager.Instance.gameData.fallingStickSizeY / 2, .1f);
        Debug.Log(transform.position.y);
        Debug.Log(transform.parent.transform.position.y);
        // Rigidbody.AddForce(Vector3.up * 200f);
        Rigidbody.AddForce(Vector3.back * 15f);
        Destroy(transform.parent.gameObject, 3f);
    }
}
