using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HideIdFull : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject container;
    public void OnPointerDown(PointerEventData eventData)
    {        
        container.SetActive(false);
    }
}

   

