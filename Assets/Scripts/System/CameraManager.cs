using Cinemachine;
using Runtime.Actor;
using UnityEngine;

namespace System.Camera
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain _brains;
        [SerializeField] private CinemachineVirtualCamera _playerCamera;

        private void Awake()
        {
            SetPlayerCamera();
        }

        private void SetPlayerCamera()
        {
            var player = FindObjectOfType<ActorFacade>().transform;
            _playerCamera.Follow = player;
            _playerCamera.LookAt = player;
        }
    }
}