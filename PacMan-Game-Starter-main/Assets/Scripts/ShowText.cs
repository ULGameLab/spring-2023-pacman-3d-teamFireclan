using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShowText : MonoBehaviour
{
    public Texture aTexture;
    void OnGUI()
    {
        if (!aTexture)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        GUI.DrawTexture(new Rect(Screen.width - 130, 10, 120, 120), aTexture, ScaleMode.ScaleToFit, true);
    }
}