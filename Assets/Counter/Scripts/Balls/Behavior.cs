using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Random;

public class Behavior : MonoBehaviour
{
    [SerializeField] private BallController _ballController;

    private Rigidbody _body;
    private bool _isGround;

    private readonly int _scared = 3;
    private readonly int _nervous = 11;
    private readonly int _desperate = 21;

    [Header("Quiet")]
    public float minSpeedQ = 0.5f;
    public float maxMinSpeedQ = 1.5f;
    public float minForceQ = 2f;
    public float maxForceQ = 4f;

    [Header("Scared")]
    public float minSpeedS = 0.2f;
    public float minForceS = 0.4f;
    public float maxForceS = 0.8f;

    [Header("Nervous")]
    public float minSpeedN = 2f;
    public float minForceN = 3f;
    public float maxForceN = 6f;

    [Header("Jump")]
    public float jumpAngle = 0.3f;
    public float JumpMinForce = 7f;
    public float JumpMaxForce = 10f;


    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GroundChecker();
    }

    private void ChangeBehavior(float allTimeInBox)
    {
        if (allTimeInBox <= _scared)
            RoamAround(Range(minSpeedQ, maxMinSpeedQ), minForceQ, maxForceQ);
        else if (allTimeInBox > _scared && allTimeInBox < _nervous)
            RoamAround(minSpeedS, minForceS, maxForceS);
        else if (allTimeInBox > _nervous && allTimeInBox <= _desperate)
            RoamAround(minSpeedN, minForceN, maxForceN);
        else if (allTimeInBox > _desperate && _isGround)
            JumpOver(JumpMinForce, JumpMaxForce);
    }

    private void RoamAround(float minSpeed, float minForce, float maxForce)
    {
        if (_body.velocity.magnitude <= minSpeed)
            _body.AddForce(GetRandomDirection() * Range(minForce, maxForce), ForceMode.Impulse);
    }

    private Vector3 GetRandomDirection()
    {
        var direction = new Vector3(Range(-1f, 1f), 0, Range(-1f, 1f));
        return direction.normalized;
    }

    private void JumpOver(float minForce, float maxForce)
    {
        var direction = new Vector3(Range(-jumpAngle, jumpAngle), 1, Range(-jumpAngle, jumpAngle));
        _body.AddForce(direction * Range(minForce, maxForce), ForceMode.Impulse);
    }


    private void OnMouseDrag()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), 
            out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")); // Layer в инспекторе
        
        if (hit)
        {
            transform.position = hitInfo.point + Vector3.up * 3f;
        }
    }

    private void GroundChecker()
    {
        RaycastHit hit;
        Vector3 position = new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z);
        if (Physics.Raycast(position, Vector3.down, out hit, 0.07f))
        {
            if (hit.collider.GetComponent<Ground>())
                _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }

    private void OnEnable()
    {
        _ballController.Ticked += ChangeBehavior;
    }


    private void OnDisable()
    {
        _ballController.Ticked -= ChangeBehavior;
    }
}
