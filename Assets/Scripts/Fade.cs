using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image fadeImg;

    private void Start()
    {
        fadeImg.gameObject.SetActive(true);
        StartCoroutine(FadeOut(0.4f));
    }

    public void StartBtn()
    {
        StartCoroutine(FadeIn(0.4f));
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public IEnumerator FadeIn(float timeSpeed)
    {
        fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, 0);
        while (fadeImg.color.a < 1.0f)
        {
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, fadeImg.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
        //load scene
        SceneManager.LoadSceneAsync("Art");
    }
    public IEnumerator FadeOut(float timeSpeed)
    {
        fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, 1);
        while (fadeImg.color.a > 0.0f)
        {
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, fadeImg.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
}
