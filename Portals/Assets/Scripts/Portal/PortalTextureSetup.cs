using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingCrow.Portals
{
    public class PortalTextureSetup : MonoBehaviour
    {

        [SerializeField] private List<PortalCameraMaterial> PortalCameraMaterials;

        private void Start()
        {
            foreach (PortalCameraMaterial portalCameraMaterial in PortalCameraMaterials)
            {
                if (portalCameraMaterial.portalCam.targetTexture != null)
                {
                    portalCameraMaterial.portalCam.targetTexture.Release();
                }

                portalCameraMaterial.portalCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
                portalCameraMaterial.portalMaterial.mainTexture = portalCameraMaterial.portalCam.targetTexture;
            }
            
        }

    }

    [System.Serializable]
    class PortalCameraMaterial
    {
        public Camera portalCam;
        public Material portalMaterial;
    }
}