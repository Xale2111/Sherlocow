using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
	[SerializeField] private int correspondingBox;

    public int CorrespondingBox
    {
        get { return correspondingBox; }
    }

    private bool isClicked;

	public bool IsClicked
	{
		get { return isClicked; }
	}

	private void OnMouseUp()
    {
		isClicked = true; 
		
	}
}
