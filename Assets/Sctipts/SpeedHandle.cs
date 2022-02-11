using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedHandle : MonoBehaviour
{

    public static event Action<float> SetSpeedHandle = delegate { };
    private Slider _slider;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void ValueChangeCheck()
    {
        SetSpeedHandle.Invoke(_slider.value);
    }
}
