using UnityEngine;

namespace Systems.Utilities
{
    public class RigidbodyMovement : IInputVector
    {
        #region Properties
        
        public float ForwardVelocity => _velocityVector.z;

        public bool CanMove { get; set; } = true;
        public bool IsMoving => !_velocityVector.Equals(GLOBALS.ZeroVector);

        #endregion
        
        #region Fields
        
        // Input device/method interface
        private IInput _moveInput = null;
        
        // Vector3 that we get from IInput interface 
        private Vector3 _velocityVector;
        
        private float _moveSpeed = 100f;

        #endregion

        public void SetMoveSpeed(ref float speed) => _moveSpeed = speed;

        public RigidbodyMovement(IInput input, ref float moveSpeed)
        {
            _moveInput = input;
            if (!ReferenceEquals(_moveInput,null)) 
                _moveInput.InputVector = this;
            
            SetMoveSpeed(ref moveSpeed);
        }
        
        public RigidbodyMovement(IInput input, float moveSpeed = 100f)
        {
            _moveInput = input;
            if (!ReferenceEquals(_moveInput,null)) 
                _moveInput.InputVector = this;
            
            SetMoveSpeed(ref moveSpeed);
        }

        #region Fixed Move

        public Vector3 ReturnFixedVelocity(Rigidbody rigidbody)
        {
            if (!CanMove) return GLOBALS.ZeroVector;
            
            // Converts transform from local to world space
            var _targetVelocity = rigidbody.transform.TransformDirection(_velocityVector);
            
            // Add movement speed to target velocity + delta time
            _targetVelocity *= (_moveSpeed * Time.fixedDeltaTime);
            
            // Remove y velocity so we dont disrupt any other applied gravitys
            _targetVelocity.y = rigidbody.velocity.y;
            
            // Return our targetable velocity;
            return _targetVelocity;
        }

        #endregion

        #region IInputVector

        // Get Horizontal and Vertical inputs
        public void GetInputVector(Vector2 inputVector)
        {
            _velocityVector = new Vector3(inputVector.x, 0, inputVector.y);
        }

        #endregion
    }
}