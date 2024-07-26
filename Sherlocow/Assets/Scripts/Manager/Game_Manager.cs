using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private float TimeToResolve = 30.0f;
    [SerializeField] private TextMeshPro _text;
    [SerializeField] GameObject minigame;


    bool _isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        _text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isStart)
        { 
            TimeToResolve -= Time.deltaTime;
            if(TimeToResolve <= 0)
            {
                _text.text = 0.ToString();
                _isStart = false;
                StopMiniGame();
                //call function disable mini game
            }
            else
            {                
                _text.text = System.Math.Ceiling(TimeToResolve).ToString() + "s";
            }
        }
    }

    public void StartChrono()
    {
        _text.enabled = true;
        _isStart = true;
    }

    public void StopMiniGame()
    {
        minigame.SetActive(false);
        _text.enabled = false;
        _isStart = false;
    }
}
