using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Random;

public class Behavior : MonoBehaviour
{
    //[SerializeField] private BallController _ballController;

    //private Rigidbody _body;
    //private bool _isGround;

    //private Vector3[] _directions = 
    //    { 
    //      Vector3.right, Vector3.left, 
    //      Vector3.forward, Vector3.back 
    //                                    };
    
    //private void Start()
    //{
    //    _body = GetComponent<Rigidbody>();
        
    //}

    //private void FixedUpdate()
    //{
    //    GroundChecker();
    //    if (_isGround)
    //        RoamAround();

    //}

    //private void RoamAround()
    //{
    //    if (_body.velocity.magnitude <= 0.2f)
    //        _body.AddForce(_directions[Range(0, 4)] * Range(0.5f, 3f), ForceMode.Impulse);
    //}

    //private void ChangeBehavior(float allTimeInBox)
    //{
       
    //}

    private void OnMouseDrag()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), 
            out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")); // тут Layer в инспекторе
        
        if (hit)
        {
            transform.position = hitInfo.point + Vector3.up * 3f;
        }
    }


    //private void GroundChecker()
    //{
    //    RaycastHit hit;
    //    Vector3 position = new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z);
    //    if (Physics.Raycast(position, Vector3.down, out hit, 0.1f))
    //    {
    //        if (hit.collider.name.Equals("Ground"))
    //        {
    //            _isGround = true;

    //        }
    //    }
    //    else
    //    {
    //        _isGround = false;
            
    //    }
    //}



    //private void OnEnable()
    //{
    //    _ballController.Ticked += ChangeBehavior;
    //}


    //private void OnDisable()
    //{
    //    _ballController.Ticked -= ChangeBehavior;
    //}

   
}
