using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideLock : MonoBehaviour
{
    [SerializeField] GameObject lockPanel;
    [SerializeField] GameObject showLock;

    private void OnMouseDown()
    {
        lockPanel.SetActive(false);
        showLock.SetActive(true);
    }
}
