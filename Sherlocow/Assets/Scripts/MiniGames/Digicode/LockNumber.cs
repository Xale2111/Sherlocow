using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockNumber : MonoBehaviour, IPointerDownHandler
{
    [SerializeField][Range(0,9)] private int answer;
    public int Answer
    {
        get { return answer; }
    }


    [SerializeField] private GameObject upNumber;
    [SerializeField] private GameObject downNumber;
    [SerializeField] private TextMeshPro numberText;

    public bool isDown = false;
    int currentNumber;
    public int CurrentNumber
    {
        get { return currentNumber; }
    }

    private void Start()
    {
        AddPhysics2DRaycaster();
        ShowNumber();
    }

    public void OnPointerDown(PointerEventData eventData)
    {        
        switch (eventData.pointerCurrentRaycast.gameObject.name.ToLower())
        {
            case "up":
                currentNumber++;
                break;

            case "down":
                currentNumber--;
                break;
        }

        if (currentNumber > 9)
        {
            currentNumber = 0;
        }
        else if (currentNumber < 0)
        {
            currentNumber = 9;
        }
        ShowNumber();
        isDown = true;
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    private void ShowNumber()
    { 
        numberText.text = currentNumber.ToString();
    }

}


