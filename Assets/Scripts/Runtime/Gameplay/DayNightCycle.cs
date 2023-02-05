﻿using System;
using UnityEngine;

namespace Runtime.Gameplay
{
    public enum DayCycle
    {
        Day,
        Night
    }
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] private Light sun;
        [SerializeField] private float secondsInFullDay = 120f;
        [Range(0,1)]
        [SerializeField] private float currentTimeOfDay = 0;
        
        private float timeMultiplier = 1f;
        private DayCycle _currentDayCycle;

        private void Awake()
        {
            SetDayTime(DayCycle.Day);
        }

        private void Update()
        {
            if (_currentDayCycle != DayCycle.Night)
            {
                UpdateSun();
 
                currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            }
            
 
            if (currentTimeOfDay >= 1) {
                currentTimeOfDay = 0;
            }

            if (currentTimeOfDay >= 0.75f)
            {
                _currentDayCycle = DayCycle.Night;
            }
        }

        private void UpdateSun() {
            sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
            
        }

        private void SetDayTime(DayCycle cycle)
        {
            switch (cycle)
            {
                case DayCycle.Day:
                    currentTimeOfDay = 0.25f;
                    _currentDayCycle = DayCycle.Day;
                    break;
                case DayCycle.Night:
                    currentTimeOfDay = 0.75f;
                    _currentDayCycle = DayCycle.Night;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}