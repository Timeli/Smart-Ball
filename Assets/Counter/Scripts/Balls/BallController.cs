using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Ball _ball;
    private Mover _mover;
    private ColorChanger _colorChanger;

    private float _toGreenTime = 3f;
    private float _toOrangeTime = 6f;
    private float _toRedTime = 10f;

    private void Awake()
    {
        Init();
    }

    float abc = 0;
    private void Update()
    {
        if (_ball.InBox)
        {
            abc += Time.deltaTime;
            Debug.Log(abc);
        }
    }

    private void Init()
    {
        _ball = GetComponent<Ball>();
        _colorChanger = GetComponent<ColorChanger>();
        _mover = GetComponent<Mover>();
    }
}
