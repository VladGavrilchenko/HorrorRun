using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollisionHandler>())
        {
            other.gameObject.GetComponent<CollisionHandler>().EndLevel();
            FindObjectOfType<EnemyMover>().StopeMove();
        }
    }
}
