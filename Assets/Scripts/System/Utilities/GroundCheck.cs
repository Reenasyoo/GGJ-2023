using UnityEngine;

namespace System.Utilities
{
    public class GroundCheck 
    {
        private readonly Collider _collider;
        private readonly float _distanceToGround;
        private const float _RADIUS = 0.2f;
        private static readonly Vector3 _UpDirection = new Vector3(0, 1, 0);
        private static readonly Vector3 _DownDirection = new Vector3(0, -1, 0);
        private Vector3 Origin => _collider.transform.position;

        public GroundCheck(Collider collider)
        {
            _collider = collider;
            _distanceToGround = _collider.bounds.extents.y;
        }

        public bool IsGrounded() => Physics.SphereCast(Origin, _RADIUS, _DownDirection, out var raycastHit, _distanceToGround);   
        
        public void DebugGrounded() => Debug.DrawRay(Origin, _DownDirection, Color.red);
    }
}