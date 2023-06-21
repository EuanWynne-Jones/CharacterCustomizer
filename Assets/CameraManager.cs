using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace CharacterCustomizer.Camera
{
    public class CameraManager : MonoBehaviour
    {
        public CinemachineVirtualCamera[] cameras;

        public CinemachineVirtualCamera bodyCamera;
        public CinemachineVirtualCamera faceCamera;

        public CinemachineVirtualCamera startCamera;
        private CinemachineVirtualCamera currentCamera;

        private void Start()
        {
            currentCamera = startCamera;

            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i] == currentCamera)
                {
                    cameras[i].Priority = 20;
                }
                else
                {
                    cameras[i].Priority = 10;
                }
            }
        }

        public void SwitchCamera(CinemachineVirtualCamera cameraToSwitchTo)
        {
            currentCamera = cameraToSwitchTo;
            currentCamera.Priority = 20;

            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i] != currentCamera)
                {
                    cameras[i].Priority = 10;
                }
            }
        }
    }

}
