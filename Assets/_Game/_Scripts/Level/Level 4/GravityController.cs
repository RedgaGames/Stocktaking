using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public List<GameObject> objectsWithRigidbody = new List<GameObject>();

    private bool _GravityActivated = false;

    public void EnableGravityForAll()
    {
        if (_GravityActivated)
        {
            foreach (GameObject obj in objectsWithRigidbody)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                        rb.useGravity = false;
                }
            }
            _GravityActivated = false;
        }
        else
        {
            foreach (GameObject obj in objectsWithRigidbody)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                        rb.useGravity = true;
                }
            }
            _GravityActivated = true;
        }
    }
}
