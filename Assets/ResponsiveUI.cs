using System;
using UnityEngine;

namespace RickyUIUtils
{
    public class ResponsiveUI : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private GameObject _UIMother;
        private Vector2 _referenceResolution;
        private Vector2 _referenceScale;
        private Vector2 _originalScale;
        private Transform _UIMothertransform;
        private void Start()
        {
            _referenceResolution = new Vector2(1170, 2532);
            _UIMothertransform = _UIMother.transform;
            _originalScale = _UIMothertransform.localScale; //255, 255, 0
            
            _referenceScale.y = (_cam.pixelHeight/_referenceResolution.y)*_originalScale.y;
            _referenceScale.x = (_cam.pixelWidth/_referenceResolution.x)*_originalScale.x;
            _UIMothertransform.localScale = _referenceScale;
            
        }
    }
}

