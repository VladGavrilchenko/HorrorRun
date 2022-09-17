using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    private bool _isActive;
    public UnityEvent ActivEvent;

    private void Active()
    {
        if (_isActive == false)
        {
            ActivEvent.Invoke();
            _isActive = true;
            GetComponent<Animator>().SetTrigger("Open");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Active();
        }
    }

}
