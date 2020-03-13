// Copyright (c) 2019 Soichiro Sugimoto.
// Licensed under the MIT License. See README in the project root for license information.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ARImageTracking
{
    public class ARMarkerManager : MonoBehaviour
    {
        [SerializeField] private ARTrackedImageManager _TrackedImageManager;
        [SerializeField] private List<ARMarkerSetting> _ARMarkerSettingList = new List<ARMarkerSetting>();

        private Dictionary<string, GameObject> _ARObjectPrefabs = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> _ARObjects = new Dictionary<string, GameObject>();

        void OnEnable()
        {
            _TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        void OnDisable()
        {
            _TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        void Start()
        {
            foreach (var markerSetting in _ARMarkerSettingList)
            {
                _ARObjectPrefabs.Add(markerSetting.ARMarkerImage.name, markerSetting.ARObjectPrefab);
            }
        }

        void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {
                UpdateARMarker(trackedImage);
            }

            foreach (var trackedImage in eventArgs.updated)
            {
                UpdateARMarker(trackedImage);
            }
        }

        void UpdateARMarker(ARTrackedImage trackedImage)
        {
            if (trackedImage.trackingState != TrackingState.None)
            {
                trackedImage.transform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);
                if (trackedImage.referenceImage.texture != null)
                {
                    var material = trackedImage.gameObject.GetComponentInChildren<MeshRenderer>().material;
                    material.mainTexture = trackedImage.referenceImage.texture;
                }

                string imageName = trackedImage.referenceImage.name;
                Vector3 localScale = new Vector3(trackedImage.size.x, trackedImage.size.x, trackedImage.size.x);

                GameObject arObject = null;
                GameObject prefab = null;
                if (!_ARObjects.TryGetValue(imageName, out arObject))
                {
                    if(_ARObjectPrefabs.TryGetValue(imageName, out prefab))
                    {
                        arObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
                        _ARObjects.Add(imageName, arObject);
                    }
                }
                arObject.transform.localScale = localScale;
                arObject.transform.position = trackedImage.transform.position;
                arObject.transform.rotation = trackedImage.transform.rotation;
            }
        }
    }
}
