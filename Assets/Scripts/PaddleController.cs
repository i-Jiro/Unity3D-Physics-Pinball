using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    [SerializeField] GameObject _rightPaddle;
    [SerializeField] GameObject _rightPivotPoint;
    [SerializeField] GameObject _leftPaddle;
    [SerializeField] GameObject _leftPivotPoint;
    [SerializeField] float _speed = 500f;
    [SerializeField] float _hitForce = 30f;
    private Paddle _leftPaddleDetector;
    private Paddle _rightPaddleDetector;

    // Start is called before the first frame updates
    void Start()
    {
        _leftPaddleDetector = _leftPaddle.GetComponent<Paddle>();
        _rightPaddleDetector = _rightPaddle.GetComponent<Paddle>();
        _leftPaddleDetector.setHitForce(_hitForce);
        _rightPaddleDetector.setHitForce(_hitForce);
    }

    private void Update()
    {
        // Check each paddle if the ball is touching it. If touching, launched the ball on key press down.
        if (_leftPaddleDetector.isTouchingBall && Input.GetKeyDown(KeyCode.LeftShift))
        {
            _leftPaddleDetector.Launch();
        }
        if (_rightPaddleDetector.isTouchingBall && Input.GetKeyDown(KeyCode.RightShift))
        {
            _rightPaddleDetector.Launch();
        }
    }

    private void LateUpdate()
    {
        // Clamp paddles to certain degrees in euler angles.
        if (Input.GetKey(KeyCode.LeftShift)
            && ((_leftPaddle.transform.rotation.eulerAngles.x < 15f)
            || (_leftPaddle.transform.rotation.eulerAngles.x < 360f) && _leftPaddle.transform.rotation.eulerAngles.x > 330f))
        {
            // Rotate paddle around a pivot point transform.
            _leftPaddle.transform.RotateAround(_leftPivotPoint.transform.position, Vector3.forward, _speed * Time.deltaTime);
        }
        // Rotate paddle back to starting rotation when not pressing shift
        else if (!Input.GetKey(KeyCode.LeftShift)
            && ((_leftPaddle.transform.rotation.eulerAngles.x > 330f) && (_leftPaddle.transform.rotation.eulerAngles.x < 360f)
            || (_leftPaddle.transform.rotation.eulerAngles.x > 15f)))
        {
            _leftPaddle.transform.RotateAround(_leftPivotPoint.transform.position, -Vector3.forward, _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightShift)
            && ((_rightPaddle.transform.rotation.eulerAngles.x < 15f)
            || (_rightPaddle.transform.rotation.eulerAngles.x < 360f) && _rightPaddle.transform.rotation.eulerAngles.x > 330f))
        {
            _rightPaddle.transform.RotateAround(_rightPivotPoint.transform.position, -Vector3.forward, _speed * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.RightShift)
           && ((_rightPaddle.transform.rotation.eulerAngles.x > 330f) && (_rightPaddle.transform.rotation.eulerAngles.x < 360f)
           || (_rightPaddle.transform.rotation.eulerAngles.x > 15f)))
        {
            _rightPaddle.transform.RotateAround(_rightPivotPoint.transform.position, Vector3.forward, _speed * Time.deltaTime);
        }
    }
}
