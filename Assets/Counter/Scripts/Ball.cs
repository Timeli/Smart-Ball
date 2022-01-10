using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool _inbox;
    public bool InBox => _inbox;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Box>())
        {
            _inbox = true;
        }
    }
}
