using Runtime.Actor.InteractActions;
using UnityEngine;

namespace Runtime.Actor
{
    [System.Serializable]
    public class ActionInput
    {
        public InteractionType type;
        public KeyCode inputValue;

        public bool Pressed() => Input.GetKeyDown(inputValue);
    }
}