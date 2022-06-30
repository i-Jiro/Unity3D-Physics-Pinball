using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Collision pinball;
    private float _hitForce;
    public bool isTouchingBall = false;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Pinball"))
        {
            pinball = collision;
            isTouchingBall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouchingBall = false;
        pinball = null;
    }

    //Launch pinball in direction of y axis
    public void Launch()
    {
        if (pinball == null)
            return;
        Debug.Log(gameObject.name + " Launched " + _hitForce);
        Rigidbody pinballRb = pinball.gameObject.GetComponent<Rigidbody>();
        pinballRb.AddForce(Vector3.up * _hitForce, ForceMode.Impulse);
    }

    public void setHitForce(float hitForce)
    {
        _hitForce = hitForce;
    }
}
