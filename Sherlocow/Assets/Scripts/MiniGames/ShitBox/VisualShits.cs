using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisualShits : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isActive = false;    
    public bool IsActive
    {
        get { return isActive; }
    }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = isActive;
    }
    private void OnMouseDown()
    {
        isActive = !isActive;
        spriteRenderer.enabled = isActive;        
    }
}
