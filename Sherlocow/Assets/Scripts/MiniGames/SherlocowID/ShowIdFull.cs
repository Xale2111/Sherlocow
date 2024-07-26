using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShowIdFull : MonoBehaviour
{
    [SerializeField] GameObject fullIdCard;

    private void OnMouseDown()
    {
        fullIdCard.SetActive(true);
    }
}
