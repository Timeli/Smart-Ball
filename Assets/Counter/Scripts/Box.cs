using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public event Action<int> Changed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            Changed?.Invoke(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            Changed?.Invoke(-1);
        }
    }
}
