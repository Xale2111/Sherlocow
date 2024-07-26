using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerifyShit : MonoBehaviour
{
    [SerializeField] private ShitManager shitManager;
    [SerializeField] private GameObject optionContainer;
    [SerializeField] private TextMeshPro totalWeightText;
    [SerializeField] private GameObject validateButton;

    Option[] options;
    int[] allBoxes = new int[3];
    bool isLost = false;

    private void Awake()
    {
        options = optionContainer.GetComponentsInChildren<Option>();
        optionContainer.SetActive(false);
    }

    private void Update()
    {
        foreach(Option option in options)
        {
            if (option.IsClicked)
            {
                if (VerifyAll(option.CorrespondingBox))
                { 
                    //NOICE
                }
                else
                {
                    //YOU LOOSE
                }
            }
        }
        if (shitManager.BoxesNotEmpty)
        {
            validateButton.SetActive(true);            
        }
        else
        {
            validateButton.SetActive(false);
        }

    }

    
    private void OnMouseUp()
    {
        allBoxes = shitManager.GetNumberAllVisibleShits();    
        shitManager.DestroyAllShitCollider();
        VerifyNumberOfShits();
        optionContainer.SetActive(true);        
    }

    private void VerifyNumberOfShits()
    {
        if (allBoxes[0] != allBoxes[1] && allBoxes[1] != allBoxes[2] && allBoxes[0] != allBoxes[2])
        {
            print("All different");
        }
        else
        {
            isLost = true;
        }
        print(shitManager.WrongBoxeId);
        CalculateFinalWeight();
    }

    private void CalculateFinalWeight()
    {
        int finalWeight = 0;

        for (int i = 0; i < allBoxes.Length; i++)
        {
            if (i == shitManager.WrongBoxeId)
            {
                finalWeight += 3 * allBoxes[i];
            }
            else
            {
                finalWeight += 5 * allBoxes[i];
            }
        }
        totalWeightText.text = "Poids total : " +finalWeight.ToString() + "KG";        
    }


    private bool VerifyAll(int choosenBox)
    {
        if (isLost)
        { 
            return false;
        }

        if (choosenBox == shitManager.WrongBoxeId)
        {
            return true;
        }

        return false;
    }

    //Choisir le nombre de caca -> OK
    //vérifier -> Tous différent + poids total
    //dire le poids total des cacas -> OK
    //demander quel est le box avec les faux cacas -> TODO
    //Si le nombre de caca n'est pas différent => par défaut perdu
    //Si le nombre de caca est différent mais quel le box n'est pas le bon => perdu
    //Si le nombre de caca est différent et que le box est le bon => réussi !
    //Si réussi => suite dialog
    //Si perdu => petite animation, restart de la scene (relance le random ?)


}
