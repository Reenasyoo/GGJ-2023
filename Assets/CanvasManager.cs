using Lumios.System.ScriptableValues;
using Runtime.Actor;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] resourceTextObject;

    [SerializeField] private IntValue[] resources;

    [SerializeField] private GameObject popUpPanel;
    [SerializeField] private TMP_Text popUpText;

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

    public void EnablePopUp(ActionInput input)
    {
        popUpText.text = $"Press {input.inputValue} to interact";
        popUpPanel.SetActive(true);
    }
    
    public void DisablePopUp()
    {
        popUpPanel.SetActive(false);
    }
}
