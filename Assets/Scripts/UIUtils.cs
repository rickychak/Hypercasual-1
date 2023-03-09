using System;
using UnityEngine;

namespace RickyUIUtils
{
    public class UIUtils
    {
        public Camera _cam;
        public GameObject _UIMother;
        public Vector2 _deviceResolution;
        private Vector2 _referenceScale;
        private Vector2 _originalScale;
        private Transform _UIMothertransform;

        public UIUtils(Camera cam, GameObject uiMother, Vector2 deviceResolution)
        {
            _cam = cam;
            _UIMother = uiMother;
            _deviceResolution = deviceResolution;
        }

        public void SetResolutionOnStart()
        {
            _UIMothertransform = _UIMother.transform;
            _originalScale = _UIMothertransform.localScale; //255, 255, 0
            _referenceScale.y = (_cam.pixelHeight/_deviceResolution.y)*_originalScale.y;
            _referenceScale.x = (_cam.pixelWidth/_deviceResolution.x)*_originalScale.x;
            _UIMothertransform.localScale = _referenceScale;
        }
    }
}

