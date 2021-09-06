using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingCrow.Portals
{
    public class PortalTeleporter : MonoBehaviour
    {

        private Transform player = null;
        [SerializeField] private Transform targetPortal;
        [SerializeField] private bool sameDirection = false;

        private void Update()
        {
            if (player != null && Vector3.Dot(transform.up, GetPortalToPlayerPosition()) < 0f)
            {
                TeleportPlayer();
            }
        }

        private void TeleportPlayer()
        {
            CharacterController cc = player.transform.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
            }
            float rotationDiff = -Quaternion.Angle(transform.rotation, targetPortal.rotation);
            if (!sameDirection)
            {
                rotationDiff += 180f;
            }
            player.Rotate(Vector3.up, rotationDiff);

            Vector3 positionOffset = Quaternion.Euler(0, rotationDiff, 0) * GetPortalToPlayerPosition();
            player.position = targetPortal.position + positionOffset;

            if (cc != null)
            {
                cc.enabled = true;
            }

            player = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.transform;
               
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player = null;
            }
        }

        private Vector3 GetPortalToPlayerPosition()
        {
            return player.position - transform.position;
        }

    }
}
