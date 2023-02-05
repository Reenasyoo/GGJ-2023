using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursPivot;
    public Transform minutesPivot;
    public Transform secondsPivot;

    const float hoursToDegrees = 30f, minutesToDegrees = 6f, secondsToDegrees = 6f;
    
    void Awake()
    {
        DateTime time = DateTime.Now;
        hoursPivot.localRotation = Quaternion.Euler(0f, hoursToDegrees * time.Hour, 0f);
        minutesPivot.localRotation = Quaternion.Euler(0f, minutesToDegrees * time.Minute, 0f);
        secondsPivot.localRotation = Quaternion.Euler(0f, secondsToDegrees * time.Second, 0f);
    }

    void Update()
    {
        var time = DateTime.Now;
        hoursPivot.localRotation = Quaternion.Euler(0f,  hoursToDegrees * time.Hour, 0f);
        minutesPivot.localRotation = Quaternion.Euler(0f, minutesToDegrees * time.Minute, 0f);
        secondsPivot.localRotation = Quaternion.Euler(0f, secondsToDegrees * time.Second, 0f);
    }
}