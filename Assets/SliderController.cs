using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public TMP_Text valueText;
    private Slider _slider;

    public void ChangeValueText(float value)
    {
        valueText.text = value.ToString("0.00");
    }
    
    public void Init(float minValue, float maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.minValue = minValue;

    }

    public void Init(int minValue, int maxValue)
    {
        _slider.wholeNumbers = true;
        _slider.maxValue = maxValue;
        _slider.minValue = minValue;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _slider ??= GetComponent<Slider>();
    }
}
