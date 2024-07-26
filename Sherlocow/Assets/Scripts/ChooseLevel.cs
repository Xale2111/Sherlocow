using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnMouseUp()
    {
        SceneManager.LoadScene(sceneName);
    }
}
