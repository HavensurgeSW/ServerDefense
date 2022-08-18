using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    bool isSelected;
    public SpriteRenderer sr;
    public string id;

    public Tower tower;

    private void Start()
    {
        isSelected = false;
        tower = null;
    }

    public void ToggleSelected(bool b) {
        isSelected = b;
    }

    public void ToggleColor(Color clr) {
        sr.color = clr;
    }

    public bool CheckForLocationAvailability() {
        if (tower == null)
            return true;
        else
            return false;
    }

    public void TowerInstaller(Tower t) {
        tower = t;
        Instantiate(t, transform);
    }
}
