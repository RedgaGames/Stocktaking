using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoObject : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rig;

    private void Start() {
        _rig = GetComponent<Rigidbody>();
    }

    public void ApplyForce()
    {
        float randomX = Random.Range(-0.5f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 randomDirection = new Vector3(randomX, 0f, randomZ).normalized;

        Vector3 upDirection = Vector3.up;
        Vector3 finalForce = randomDirection + upDirection;

        _rig.AddForce(finalForce.normalized * _force, ForceMode.Impulse);

    }

}
