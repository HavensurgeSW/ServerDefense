using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    bool isSelected;
    public SpriteRenderer sr;
    public string ID;

    private void Start()
    {
        isSelected = false;
    }

    public void ToggleSelected(bool b) {
        isSelected = b;
    }

    void ToggleColor(Color clr) {
        sr.color = clr;
    }
}
