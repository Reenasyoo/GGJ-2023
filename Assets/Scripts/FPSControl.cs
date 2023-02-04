using UnityEngine;
using System.Collections;
using TMPro;

public class FPSControl : MonoBehaviour
{
    public TMP_Text fpsText;
    public float deltaTime;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString();
    }
}