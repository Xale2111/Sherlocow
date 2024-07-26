using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor;
using System.Threading;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("VisualDialog")]
    [Space(3)]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image rightCharacter; 
    [SerializeField] private Image leftBGContainer;
    [SerializeField] private Image rightBGContainer;
    [SerializeField] private TextMeshProUGUI dialogueBox;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private TextMeshProUGUI speakingCharacterName;
    [SerializeField] private GameObject speakingCharacterNameContainer;


    [Header("VisualDialog images")]
    [Space(3)]
    [SerializeField] private Sprite character1;
    [SerializeField] private Sprite character2;
    [SerializeField] private Sprite character2SecondDialog;
    [SerializeField] private Sprite leftBG;
    [SerializeField] private Sprite rightBG;

    [Header("Minigame")]
    [Space(3)]
    [SerializeField] GameObject minigame;
    [SerializeField] Game_Manager gameManager;

    [Header("Dialog Folder")]
    [Space(3)]
    [SerializeField] string dialogFolder;

    const string DIALOG_FILE_NAME = "Dialogue";
    const string DIALOG_CANVAS_TAG = "UIDialog";
    const string NEXT_SCENE_NAME = "ChooseLevel";
   

    int currentDialogIndex = 0;
    private int dialogLenght = 0;

    List<Tuple<int,string, string>> fullDialog = new List<Tuple<int,string, string>>();

    bool inDialog = false;
    int dialogIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        leftCharacter.sprite = character1;
        rightCharacter.sprite = character2;
        leftBGContainer.sprite = leftBG;
        rightBGContainer.sprite = rightBG;
        minigame.SetActive(false);
        ChangeToNextDialog();
    }

    void GetDialogue()
    {
        fullDialog.Clear();
        dialogLenght = 0;
        //Improve to put character name and style know which one is num 1 and which one num 2
        string path = "Assets/Dialogue/"+ dialogFolder+"/" + DIALOG_FILE_NAME + currentDialogIndex + ".txt";

        var dialog = (TextAsset)AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset));        

        if (dialog != null)
        {
            //print(dialog);
            string[] rawText = dialog.text.Split(";;");

            foreach (string line in rawText)
            {              
                Tuple<int,string, string> newLine;                
                string speakingCharacter = line.Split(':')[0];                
                if (speakingCharacter.Contains("P1"))
                {
                    newLine = new Tuple<int,string, string>(1, speakingCharacter.Split("/")[1], line.Split(':')[1]);                   
                }
                else if (speakingCharacter.Contains("P2"))
                {
                    newLine = new Tuple<int, string, string>(2, speakingCharacter.Split("/")[1], line.Split(':')[1]);                    
                }
                else
                {                    
                    newLine = new Tuple<int, string, string>(3, "*", line.Split(':')[1]);
                }
                fullDialog.Add(newLine);
                dialogLenght++;
            }
        }


        if (character2 == null && currentDialogIndex == 0)
        {
            rightCharacter.enabled = false;
        }
        ShowDialogue();

    }

    void ShowDialogue()
    {
        if (inDialog && fullDialog.Count>0)
        {
            dialogueBox.fontStyle = FontStyles.Normal;            
            string finalText = string.Empty;
            switch (fullDialog[dialogIndex].Item1)
            {
                case 1:                    
                    MoveCharacterForward(leftCharacter);
                    MoveCharacterBackward(rightCharacter);
                    //Play speaking animation
                    ManageDialog(speakingCharacterName,true);

                    break;

                case 2:                    
                    MoveCharacterForward(rightCharacter);
                    MoveCharacterBackward(leftCharacter);
                    //Play speaking animation
                    ManageDialog(speakingCharacterName,true);
                    break;

                case 3:                    
                    MoveCharacterBackward(rightCharacter);
                    MoveCharacterBackward(leftCharacter);
                    ManageDialog(speakingCharacterName, false);

                    dialogueBox.fontStyle = FontStyles.Italic;
                    break;

                default:
                    break;
            }
            finalText = fullDialog[dialogIndex].Item3;
            dialogueBox.text = finalText;

                       
        }
    }

    private void ManageDialog(TextMeshProUGUI characterName, bool showCharacterName)
    {
        speakingCharacterNameContainer.SetActive(showCharacterName);
        characterName.text = fullDialog[dialogIndex].Item2;      
    }
    public void NextDialogue(CallbackContext value)
    {
        if(value.performed && inDialog)
        {
            if (dialogIndex < dialogLenght-1)
            {
                dialogIndex++;
                ShowDialogue();
            }
            else 
            {
                inDialog = false; 
                dialogIndex = 0;                
                EndDialog();
                if (currentDialogIndex > 1)
                {
                    SceneManager.LoadScene(NEXT_SCENE_NAME);
                }
            }
        }
    }
    private void MoveCharacterForward(Image characterToMove)
    {
        characterToMove.color = new Color(1,1,1);
        characterToMove.rectTransform.localScale = new Vector2(1.3f, 1.3f);    
    }
    private void MoveCharacterBackward(Image characterToMove)
    {
        float grayColored = 0.6f;
        characterToMove.color = new Color(grayColored, grayColored, grayColored);
        characterToMove.rectTransform.localScale = new Vector2(1.15f, 1.15f);
    }

    private void EndDialog()
    {
        MoveCharacterForward(leftCharacter);
        MoveCharacterForward(rightCharacter);
        textContainer.SetActive(false);
        speakingCharacterNameContainer.SetActive(false);
        minigame.SetActive(true);
        if (gameManager != null)
        {
            gameManager.StartChrono();
        }
        currentDialogIndex++;
    }

    public void ChangeToNextDialog()
    {
        inDialog = true;
        textContainer.SetActive(true);
        speakingCharacterNameContainer.SetActive(true);
        dialogIndex = 0;
        rightCharacter.sprite = character2SecondDialog;
        if (character2SecondDialog != null && currentDialogIndex > 0)
        {
            print("OK");
            rightCharacter.enabled = true;
        }
        GetDialogue();
    }
    
}
