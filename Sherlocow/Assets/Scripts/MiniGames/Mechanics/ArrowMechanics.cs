using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMechanics : MonoBehaviour
{
    [SerializeField] string direction;

    private bool isClicked;

    public bool Clicked
    {
        get { return isClicked; }
    }

    private void OnMouseUp()
    {
        isClicked = true;
    }

    public string GetDirection()
    {
        return direction;
    }
}
