using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveArrows : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public KeepActive keepUp;
    public KeepActive keepDown;
    public KeepActive keepLeft;
    public KeepActive keepRight;
    public KeepActive keeCase;
    public KeepActive[] toKeepActive = new KeepActive[5];
    private bool dontExit;
    private bool onCase;

    // Start is called before the first frame update
    void Start()
    {
        toKeepActive[0] = keepUp;
        toKeepActive[1] = keepDown;
        toKeepActive[2] = keepLeft;
        toKeepActive[3] = keepRight;
        if(keeCase!=null)
        {
            toKeepActive[4] = keeCase;
        }
        up.SetActive(false);
        down.SetActive(false);
        right.SetActive(false);
        left.SetActive(false);
        dontExit = true;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        onCase = true;
    }
    private void OnMouseExit()
    {
        onCase = false;
    }
    private void Update()
    {
        dontExit = false;
        foreach (KeepActive keep in toKeepActive)
        {
            if(keep != null)
            {
                if (keep.keepActive)
                { 
                    up.SetActive(true);
                    down.SetActive(true);
                    right.SetActive(true);
                    left.SetActive(true);
                    dontExit = true;
                }
            }
            
        }
        if (!dontExit)
        {
            if (onCase)
            {
                up.SetActive(true);
                down.SetActive(true);
                right.SetActive(true);
                left.SetActive(true);
            }
            else
            {
                up.SetActive(false);
                down.SetActive(false);
                right.SetActive(false);
                left.SetActive(false);
            }
        }
    }
   
    
}
