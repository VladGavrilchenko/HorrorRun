using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicUp : MonoBehaviour
{
    [SerializeField] private int _cointCounter;

    private void AddCoints(int addCoints)
    {
        _cointCounter += addCoints;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            AddCoints(other.GetComponent<Coin>().GetCost());
        }
    }


}
