using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetAll : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] TMP_InputField firstInputField;

    IdLetterInput[] allInputs;

    public bool hasReset;

    // Start is called before the first frame update
    void Start()
    {
        allInputs = canvas.GetComponentsInChildren<IdLetterInput>();
    }

    private void OnMouseUp()
    {        
        for (int i = 0; i < allInputs.Length; i++)
        {
            allInputs[i].GetComponentInChildren<TMP_InputField>().text = string.Empty;
        }
        hasReset = true;

    }
}
