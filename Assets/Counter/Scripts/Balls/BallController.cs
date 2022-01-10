using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Ball))]
public class BallController : MonoBehaviour
{
    private Ball _ball;
    private float _elapsedTime = 0f;
    private float _notificationTime = 1f;

    public event Action<float> Ticked;

    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    private void Update()
    {
        if (_ball.InBox)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _notificationTime)
            {
                Ticked?.Invoke(_elapsedTime);
                _elapsedTime = 0;
            }
        }
        else
        {
            _elapsedTime = 0;
            Ticked?.Invoke(_elapsedTime);
        }
    }
}
