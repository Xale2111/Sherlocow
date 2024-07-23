using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor;

public class DialogueManager : MonoBehaviour
{
    public Image leftCharacter;
    public Image rightCharacter;
    public TextMeshProUGUI dialogueBox;

    public Sprite Character1;
    public Sprite Character2;



    private int currentDialogIndex = 0;
    private int dialogLenght = 0;
    const string DIALOG_FILE_NAME = "Dialogue";

    List<Tuple<int, string>> fullDialog = new List<Tuple<int, string>>();

    bool inDialog = false;
    int dialogIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        leftCharacter.sprite = Character1;
        rightCharacter.sprite = Character2;
        GetDialogue();
        ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void GetDialogue()
    {

        //Improve to put character name and style know which one is num 1 and which one num 2
        string path = "Assets/Dialogue/" + DIALOG_FILE_NAME + currentDialogIndex + ".txt";

        var dialog = (TextAsset)AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset));

        if (dialog != null)
        {
            //print(dialog);
            string[] rawText = dialog.text.Split(";;");

            foreach (string line in rawText)
            {
                Tuple<int, string> newLine;
                //Debug.Log(line.Split(':')[0].ToLower());
                if (line.Contains("perso1"))
                {
                    newLine = new Tuple<int, string>(1, line.Split(':')[1]);
                    Debug.Log("PERSO 1 : " + line);
                }
                else if (line.Contains("perso2"))
                {
                    newLine = new Tuple<int, string>(2, line.Split(':')[1]);
                    Debug.Log("PERSO 2 : " + line);

                }
                else
                {
                    newLine = new Tuple<int, string>(3, line.Split(':')[1]);
                }
                fullDialog.Add(newLine);
                dialogLenght++;
            }
        }

        currentDialogIndex++;
    }

    void ShowDialogue()
    {
        inDialog = true;
        dialogueBox.text = fullDialog[dialogIndex].Item1 +" : "+ fullDialog[dialogIndex].Item2;
    }

    public void NextDialogue(CallbackContext value)
    {
        if(value.performed)
            if (dialogIndex < dialogLenght-1)
            {
                dialogIndex++;
                dialogueBox.text = fullDialog[dialogIndex].Item1 + " : " + fullDialog[dialogIndex].Item2;
            }
    }

}
