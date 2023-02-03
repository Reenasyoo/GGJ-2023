using UnityEngine;

namespace System.Utilities
{
    [Serializable]
    public class AxisInput : MonoBehaviour, IInput
    {
        #region Properties
        private static float HorizontalInput => Input.GetAxis(HORIZONTAL_STRING);
        private static float VerticalInput => Input.GetAxis(VERTICAL_STRING);
        public IInputVector InputVector { get; set; }

        #endregion

        #region Fields
        
        private const string HORIZONTAL_STRING = "Horizontal";
        private const string VERTICAL_STRING = "Vertical";

        #endregion

        private static Vector2 GetAxisInput() => new Vector2(HorizontalInput, VerticalInput);
        
        private void FixedUpdate()
        {
            InputVector.GetInputVector(GetAxisInput());
        }
    }
}