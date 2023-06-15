using UnityEngine;

namespace SaleSystem.Events
{
    public class SaleZoneIndıcator : MonoBehaviour
    {
        public Transform salesZone;
        public RectTransform uiElement;
        public Camera mainCamera;
        public float edgeOffset = 50f;

        private void LateUpdate()
        {
            Vector3 salesZonePosition = salesZone.position;
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(salesZonePosition);

            if (viewportPosition.z > 0 && viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
            {
                Vector3 uiPosition = mainCamera.WorldToScreenPoint(salesZonePosition);
                uiElement.position = uiPosition;
            }
            else
            {
                Vector3 salesZoneViewportPosition = mainCamera.WorldToViewportPoint(salesZonePosition);
                Vector3 screenPosition = Vector3.zero;

                if (salesZoneViewportPosition.z <= 0)
                {
                    float y = salesZoneViewportPosition.y <= 0.5f ? edgeOffset : Screen.height - edgeOffset;
                    screenPosition = new Vector3(Screen.width / 2f, y, 0f);
                }
                else
                {
                    Vector3 salesZoneScreenPosition = mainCamera.WorldToScreenPoint(salesZonePosition);
                    float x = salesZoneScreenPosition.x <= Screen.width / 2f ? edgeOffset : Screen.width - edgeOffset;
                    float y = salesZoneScreenPosition.y;
                    screenPosition = new Vector3(x, y, 0f);
                }

                uiElement.position = screenPosition;
            }
        }
    }
}