using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        // Rigidbody.AddForce(Vector3.up * 200f);
        // transform.DOPunchRotation(new Vector3(-30, 0, 0), 2f);
        transform.DORotate(new Vector3(-180,0,0), 0.5f);
        Rigidbody.AddForce(Vector3.back * 200f);
        Destroy(transform.parent.gameObject, 3f);
    }
}
