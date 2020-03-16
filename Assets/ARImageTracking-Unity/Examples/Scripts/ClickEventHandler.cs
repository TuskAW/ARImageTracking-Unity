using UnityEngine;
using UnityEngine.EventSystems;

namespace ARImageTracking.Example
{
    public class ClickEventHandler : MonoBehaviour, IPointerClickHandler
    {
        public GameObject TargetObject;

        private ActiveStateInverter _ActiveStateInverter;
        private ColorChanger _ColorChanger;

        void Start()
        {
            _ActiveStateInverter = TargetObject.GetComponent<ActiveStateInverter>();
            _ColorChanger = TargetObject.GetComponent<ColorChanger>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_ActiveStateInverter != null)
            {
                _ActiveStateInverter.InvertActiveState();
            }

            if (_ColorChanger != null)
            {
                _ColorChanger.ChangeCurrentColor();
            }
        }
    }
}
