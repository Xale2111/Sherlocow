using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLock : MonoBehaviour
{
    [SerializeField] GameObject lockPanel;
    private void OnMouseUp()
    {
        lockPanel.SetActive(!lockPanel.active);
        gameObject.SetActive(false);
    }
}
