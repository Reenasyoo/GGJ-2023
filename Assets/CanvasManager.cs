using Lumios.System.ScriptableValues;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] resourceTextObject;

    [SerializeField] private IntValue[] resources;

    private void Awake()
    {
        for (var i = 0; i < resourceTextObject.Length; i++)
        {
            var value = resources[i].GetValue().ToString();
            resourceTextObject[i].text = value;
        }
    }

    private void UpdateText(int id)
    {
        var value = resources[id].GetValue().ToString();
        resourceTextObject[id].text = value;
    }
    
    private void Update()
    {
        UpdateText(0);
        UpdateText(1);
    }
}
