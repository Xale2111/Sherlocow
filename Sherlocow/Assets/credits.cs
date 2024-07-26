using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Intro");
    }
}
