using UnityEngine;

namespace ARImageTracking.Example
{
    public class ActiveStateInverter : MonoBehaviour
    {
        public void InvertActiveState()
        {
            bool activeState = this.gameObject.activeSelf;
            this.gameObject.SetActive(!activeState);
        }
    }
}
