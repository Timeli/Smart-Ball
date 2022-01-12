using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Transform _cover;

    private BallController[] controllers;
    private bool _isCalm;
    private Vector3 _coverPos = new Vector3(1.4f, 2.7f, -1.8f);

    private void Start()
    {
        controllers = FindObjectsOfType<BallController>();
    }

    private void Update()
    {
        if (_score.Current == 21 && _isCalm == false)
            CalmDowmCleverBalls();
        else if (_score.Current == 21 && _isCalm)
            CoverBox();

    }

    private void CoverBox()
    {
        _cover.position = Vector3.MoveTowards(_cover.position, _coverPos, 1f * Time.deltaTime);
    }

    private void CalmDowmCleverBalls()
    {
        for (int i = 0; i < controllers.Length; i++)
            controllers[i]._allTimeInBox = 0;

        _isCalm = true;
    }


}
