using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIModel: MonoBehaviour
{

    private Color[] _colorPallete = { new Color(0.43f, 1f, 0.38f), new Color(1f, 0.5f, 0.46f) };

    public Color[] GetPallete()
    {
        return _colorPallete;
    }
    
}
