using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.InputAction;

public class VerifyID : MonoBehaviour
{
    [Header("R�ponse attendue")]
    [Space(4)]
    [SerializeField] string answer;

    [SerializeField] EventSystem eventSystem;

    [SerializeField] ResetAll reset;

    [SerializeField] DialogueManager dialogueManager;

    IdLetterInput[] allInputs;

    string userAnswer = string.Empty;


    private void Start()
    {        
        allInputs = gameObject.GetComponentsInChildren<IdLetterInput>();
        //get component by tag ?
    }

    private void Update()
    {        
        for (int i = 0; i < allInputs.Length; i++)
        {
            if (allInputs[i].hasChanged)
            {
                allInputs[i].hasChanged = false;
                if (i < allInputs.Length - 1)
                { 
                    eventSystem.SetSelectedGameObject(allInputs[i+1].GetComponentInChildren<TMP_InputField>().gameObject);            
                }
                if (VerifyAnswer())
                {

                }
            }
        }
        if (reset.hasReset)
        {
            eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
            reset.hasReset = false;
        }
    }

    private bool VerifyAnswer()
    {
        userAnswer = string.Empty;
        foreach (var input in allInputs)
        {
            string givenChar = input.GetComponentInChildren<TMP_InputField>().text;            
            userAnswer += givenChar;
        }
        print(userAnswer);        
        if (userAnswer.ToLower() == answer.Replace(" ", string.Empty).ToLower())
        {
            //lancer dialogue
            print("YESSSSSSSSSS");
            return true;
        }
        return false;
    }

    //Gestion des cases
    //Quand 1 est chang�e -> mettre le focus sur la prochaine



}
