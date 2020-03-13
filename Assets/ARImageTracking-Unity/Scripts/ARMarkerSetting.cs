using System;
using UnityEngine;

namespace ARImageTracking
{
    [Serializable]
    [CreateAssetMenu(menuName = "ARImageTracking/AR Marker Setting", fileName = "ARMarkerSetting")]
    public class ARMarkerSetting : ScriptableObject
    {
        public Texture ARMarkerImage;
        public GameObject ARObjectPrefab;
    }
}
