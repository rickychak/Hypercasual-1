using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonModel: MonoBehaviour
{

    private Color[] _colorPallete = { new Color(0.43f, 1f, 0.38f), new Color(1f, 0.5f, 0.46f) };
    [SerializeField] private Image _image;

    public Image GetImage()
    {
        return _image;
    }

    public Color[] GetPallete()
    {
        return _colorPallete;
    }
    
}
