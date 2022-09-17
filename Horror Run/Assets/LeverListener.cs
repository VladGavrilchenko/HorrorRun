using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LeverListener : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCountActiveLever;
    private Gate _gate;
    [SerializeField] private Image _activAllImage;
    private int _coutnOfLever;
    private int _coutnActiveLever;

    

    private void Start()
    {
        _gate = FindObjectOfType<Gate>();
        Lever[] levers = FindObjectsOfType<Lever>();
        _coutnOfLever = levers.Length;

        for (int i=0; i < _coutnOfLever; i++)
        {
            levers[i].ActivEvent.AddListener(AddActiveLever);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        _textCountActiveLever.text = _coutnActiveLever +  "/" + _coutnOfLever;
    }

    private void AddActiveLever()
    {
        _coutnActiveLever++;
        UpdateUI();

        if (_coutnActiveLever == _coutnOfLever)
        {
            _gate.OpenGate();
        }
    }


}
