using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordleMainView : BaseView
{
    #region PUBLIC_PROPERTIES
    private List<KeyCode> validkeyCodes = new List<KeyCode>
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
    };
    public List<WordleKeyboardButton> keyboardlettersButtons = new List<WordleKeyboardButton>();

    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private List<wordleHorizontalLayout> horizontalLayout = new List<wordleHorizontalLayout>();
    #endregion

    #region UNITY_CALLBACKS

    public void SetUpButtons()
    {
        for (int i = 0; i < keyboardlettersButtons.Count; i++)
        {
            // Here we use GetChild and then GetComponent, it's not the most efficient way performance wise.
            // For setting things up and one shots it is usually fine, but doing it every frame inside of
            keyboardlettersButtons[i].SetContainerText(WordleManagers.Instance.characterNames[i].ToString());   
        }
        
        // Whenever we click a button, run the function ClickCharacter and output the character to the Console.
        //foreach (var keyboardButton in keyboardCharacterButtons)
        //{
        //    string letter = keyboardButton.transform.GetChild(0).GetComponent<Text>().text;
        //    keyboardButton.GetComponent<Button>().onClick.AddListener(() => ClickCharacter(letter));
        //}
    }
    //public void Start()
    //{
    //    ResetAllLayouts();
    //    SetUpButtons();
    //}
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("EnterPressed2");
                WordleManagers.Instance.SubmitWord();
            }
            if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
                WordleManagers.Instance.DeleteLetter();
            else
                foreach (KeyCode keyCode in validkeyCodes)
                    if (Input.GetKeyDown(keyCode))
                    {
                        WordleManagers.Instance.AddLetter(keyCode.ToString());
                        //AddLetter(keyCode.ToString());
                        break;
                    }       
        }
    }
    #endregion

    #region PUBLIC_METHODS
    public void AddLetter( string letter)
    {
        //horizontalLayout[WordleManagers.Instance.currentWordIndex].letterContainer[WordleManagers.Instance.currentLetterIndex].letterText.text = letter.ToUpper();
        horizontalLayout[WordleManagers.Instance.currentWordIndex].SetContainerText(WordleManagers.Instance.currentLetterIndex, letter.ToUpper());
        WordleManagers.Instance.currentLetterIndex++;
    }
    public void AddColor(int index, Color color)
    {
        horizontalLayout[WordleManagers.Instance.currentWordIndex].SetContainerColor(index, color);
    }
    public void DeleteLastLetters()
    {
        WordleManagers.Instance.currentLetterIndex--;
        horizontalLayout[WordleManagers.Instance.currentWordIndex].DeleteLetter(WordleManagers.Instance.currentLetterIndex);
    }
    #endregion

    #region PRIVATE_METHODS
    public void ResetAllLayouts()
    {
        for (int i = 0; i < horizontalLayout.Count; i++)
        {
            for (int j = 0; j < horizontalLayout[i].letterContainer.Count; j++)
            {
                horizontalLayout[i].letterContainer[j].SetContainerText("");
                horizontalLayout[i].letterContainer[j].SetContainerColor(WordleManagers.Instance.defaultColor);
            }
        }
    }
    public void ResetKeyboardButtons()
    {
        for (int i = 0; i < keyboardlettersButtons.Count; i++)
        {
            keyboardlettersButtons[i].SetContainerColor(WordleManagers.Instance.defaultColor);
        }
    }
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion

}
