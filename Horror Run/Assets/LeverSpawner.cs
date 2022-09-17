using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeverSpawner : MonoBehaviour
{
    [SerializeField] private int _countAcive;
   
    private void Awake()
    {
        List <Lever> levers = FindObjectsOfType<Lever>().ToList();

        int c = levers.Count - _countAcive;

        for (int i =0; i < c; i++)
        {
            int randomLevers = Random.Range(0, levers.Count);

            levers[randomLevers].gameObject.SetActive(false);
        }
    }
}
