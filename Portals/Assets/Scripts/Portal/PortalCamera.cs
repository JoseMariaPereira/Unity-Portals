using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingCrow.Portals
{
    public class PortalCamera : MonoBehaviour
    {

        [SerializeField] private Transform playerCamera;
        [SerializeField] private Transform portal;
        [SerializeField] private Transform otherPortal;

        private void Update()
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            transform.position = portal.position + playerOffsetFromPortal;

            float angleDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);
            Quaternion portalRotationDiff = Quaternion.AngleAxis(angleDifference, Vector3.up);
            Vector3 newCamRotation = portalRotationDiff * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCamRotation, Vector3.up);
        }

    }
}