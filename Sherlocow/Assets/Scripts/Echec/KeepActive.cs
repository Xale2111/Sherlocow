using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepActive : MonoBehaviour
{
    public bool keepActive;
    // Start is called before the first frame update
    void Start()
    {
        keepActive = false;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        keepActive = true;
    }
    private void OnMouseExit()
    {
        keepActive = false;
    }
}
