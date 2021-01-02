using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JointController : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(100, 0, 0), 0.8f);
    }

}
