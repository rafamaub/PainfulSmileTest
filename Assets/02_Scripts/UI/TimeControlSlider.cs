using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeControlSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Slider meSlider;
    [SerializeField] private bool onlySeconds;

    private void Awake()
    {
        meSlider.onValueChanged.AddListener(UpdateTimeText);
        UpdateTimeText(meSlider.value);
    }

    public void UpdateTimeText(float value)
    {

        if(onlySeconds)
        {
            timeText.text = value.ToString() + " s";
        }
        else
        {
            timeText.text = TimeSpan.FromSeconds(value).ToString("mm\\:ss");
        }
    }
}
