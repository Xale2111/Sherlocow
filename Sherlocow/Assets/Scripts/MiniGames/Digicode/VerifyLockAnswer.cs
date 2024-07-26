using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class VerifyLockAnswer : MonoBehaviour
{
    [SerializeField] LockNumber firstNumber;
    [SerializeField] LockNumber secondNumber;
    [SerializeField] LockNumber thirdNumber;
    [SerializeField] LockNumber fourthNumber;

    [SerializeField] DialogueManager dialogueManager;

    LockNumber[] numbers = new LockNumber[4];    

    bool resolved = false;

    private void Start()
    {
        numbers[0] = firstNumber;
        numbers[1] = secondNumber;
        numbers[2] = thirdNumber;
        numbers[3] = fourthNumber;
    }
    // Update is called once per frame
    void Update()
    {
        if (!resolved)
        {
            foreach (LockNumber num in numbers)
            {
                if (num.isDown)
                {
                    if (!CheckAnswer())
                    {
                        break;
                    }
                    else
                    {
                        print("CORRECT");
                        resolved = true;
                        dialogueManager.ChangeToNextDialog();
                        Destroy(gameObject);
                        
                    }
                    num.isDown = false;
                }
            }
        }
    }

    private bool CheckAnswer()
    {
        if (firstNumber.CurrentNumber==firstNumber.Answer)
        {
            if (secondNumber.CurrentNumber == secondNumber.Answer)
            {
                if (thirdNumber.CurrentNumber == thirdNumber.Answer)
                {
                    if (fourthNumber.CurrentNumber == fourthNumber.Answer)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
        return false;

    }
}
