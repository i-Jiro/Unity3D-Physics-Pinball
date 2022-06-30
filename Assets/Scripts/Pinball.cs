using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public bool hasLaunched = false;
    public float launchForce = 100f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    //Launch the ball upwards from it's starting position only once.
    private void Launch()
    {
        if (!hasLaunched)
        {
            _rigidbody.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            hasLaunched = true;
        }
    }
}
