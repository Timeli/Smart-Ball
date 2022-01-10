using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private BallController _ballController; 

    [SerializeField] private Material _blue;
    [SerializeField] private Material _green;
    [SerializeField] private Material _orange;
    [SerializeField] private Material _red;

    private readonly int _toGreenTime = 3;
    private readonly int _toOrangeTime = 7;
    private readonly int _toRedTime = 12;

    private Renderer _renderer;
    private float _allTime;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void ChangeColor(float tick)
    {
        _allTime += tick;
        print(_allTime);
        if (_allTime < _toGreenTime)
        {
            _renderer.material = _blue;
        }
        else if (_allTime > _toGreenTime && _allTime < _toOrangeTime)
        {
            _renderer.material = _green;
        }
        else if (_allTime > _toOrangeTime && _allTime <= _toRedTime)
        {
            _renderer.material = _orange;
        }
        else if (_allTime > _toRedTime)
        {
            _renderer.material = _red;
        }
    }

    private void OnEnable()
    {
        _ballController.Ticked += ChangeColor;
    }

    private void OnDisable()
    {
        _ballController.Ticked -= ChangeColor;
    }
}
