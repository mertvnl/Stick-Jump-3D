using UnityEngine;
using BzKovSoft.ObjectSlicer;
using System.Diagnostics;
using System;
using Sirenix.Utilities;
using Debug = UnityEngine.Debug;

namespace BzKovSoft.ObjectSlicerSamples
{
    /// <summary>
    /// Test class for demonstration purpose
    /// </summary>
    public class ObstacleController : MonoBehaviour
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
        private void Update()
        {
            int _sliceId = 0;

            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward * -1);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1000f))
            {
                
                Debug.Log("Did Hit");
                ++_sliceId;
            
                IBzSliceable sliceable = hit.transform.GetComponent<IBzSliceable>();

                Vector3 direction = Vector3.Cross(ray.direction, Camera.main.transform.right);
                Plane plane = new Plane(direction, ray.origin);

                if (sliceable != null)
                {
                    sliceable.Slice(plane);
                    hit.rigidbody.constraints = RigidbodyConstraints.None;
                    hit.collider.enabled = false;
                    hit.rigidbody.AddForce(Vector3.right * (500 * Time.deltaTime));
                }
            }
            Debug.DrawRay(transform.position, Vector3.back * 1000f, Color.red);
            


        }
    }
}