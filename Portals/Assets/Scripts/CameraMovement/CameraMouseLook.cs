using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FlyingCrow.CameraMovement
{
    public class CameraMouseLook : MonoBehaviour
    {
        [Range(10, 1000)]
        [SerializeField]
        private float mouseSensitivityX;
        [Range(10, 1000)]
        [SerializeField]
        private float mouseSensitivityY;

        [SerializeField]
        private Transform playerController;

        private float xRotation;

        private bool firstTime = true;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            CameraRotation();
        }

        private void CameraRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

            if (firstTime && (mouseY < -30 || mouseY > 30))
            {
                firstTime = false;
                mouseY = 0;
                mouseX = 0;
            }

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerController.Rotate(Vector3.up * mouseX);
        }
    }
}
