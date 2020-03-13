using UnityEngine;
using UnityEngine.EventSystems;

namespace ARImageTracking.Example
{
    public class ClickEventHandler : MonoBehaviour, IPointerClickHandler
    {
        public GameObject TargetObject;

        public void OnPointerClick(PointerEventData eventData)
        {
            ActiveStateInverter inverter = TargetObject.GetComponent<ActiveStateInverter>();
            if (inverter != null)
            {
                inverter.InvertActiveState();
            }
        }
    }
}
