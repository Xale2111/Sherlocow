using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdLetterInput : MonoBehaviour
{
    [SerializeField] private char correctChar;
    [SerializeField] private TextMeshPro correspondingNumber;

    [HideInInspector]
    public bool hasChanged = false;
    const int offset = 2;
    //a-> 97

    private void Start()
    {
        int charToNumber = Convert.ToInt32(correctChar) - 96 + offset;
        correspondingNumber.text = charToNumber.ToString();
    }

    public void GoToNextInput()
    {
        hasChanged = true;
    }   
}
