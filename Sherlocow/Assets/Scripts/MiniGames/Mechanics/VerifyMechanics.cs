using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class VerifyMechanics : MonoBehaviour
{
    [SerializeField] ArrowMechanics leftArrow;
    [SerializeField] ArrowMechanics rightArrow;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Game_Manager gameManager;

    private void Update()
    {
        if (leftArrow.Clicked)
        {
            //You win
            dialogueManager.ChangeToNextDialog();
            gameManager.StopMiniGame();
            DestroyArrows();
        }
        else if (rightArrow.Clicked)
        {
            //you lose
            //End Screen 
            print("Loose");
            gameManager.StopMiniGame();
            DestroyArrows();
        }
    }

    private void DestroyArrows()
    {
        Destroy(leftArrow);
        Destroy(rightArrow);
        Destroy(gameObject);
    }

}
