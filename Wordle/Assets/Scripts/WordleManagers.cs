using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordleManagers : MonoBehaviour
{
    public static WordleManagers Instance;
    #region PUBLIC_PROPERTIES
    public int currentWordIndex; //This is index of the current word 
    public int currentLetterIndex;//This is index of the current letter in the word
    public string currentWord = "";
    public string winWord = "";
    public string tempWinWord;

    public Color notInWordColor;
    public Color correctButWrongPlaceColor;
    public Color correctAndCorrectPlaceColor;
    public Color defaultColor;

    public int totalChances = 6;

    // All characters in the keyboard, named from top row to bottom row
    public string characterNames = "QWERTYUIOPASDFGHJKLZXCVBNM";

    public List<WordleKeyboardButton> buttonsPressed = new List<WordleKeyboardButton>();

    public bool isGameEnded = false;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField]private List<string> hints = new List<string>();
    [SerializeField] TextAsset validWordsTextAsset;
    [SerializeField] private List<string> validWords = new List<string>();
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;
        LoadFiles();
    }
    private void Start()
    {
        Init();
    }
    #endregion

    #region PUBLIC_METHODS
    public void Init()
    {
        WordleUiManager.Instance.panelMainMenu.ShowView();
        //WordleUiManager.Instance.panelWordleMainView.ShowView();
        //StartGame();
    }
    public void StartGame()
    {
        WordleUiManager.Instance.panelWordleMainView.SetUpButtons();
        Generate();
    }
    public void Generate()
    {
        ResetActivity();
        winWord = GetRandomWord();
        tempWinWord = winWord;
    }

    public void ResetActivity()
    {
        WordleUiManager.Instance.panelWordleMainView.ResetAllLayouts();
        WordleUiManager.Instance.panelWordleMainView.ResetKeyboardButtons();
        currentLetterIndex = 0;
        currentWord = "";
        totalChances = 6;
        buttonsPressed.Clear();
        currentWordIndex = 0;
        isGameEnded = false;
    }
    public void LoadFiles()
    {
        validWords = TXTFileReader.GetStrings(validWordsTextAsset);
    }
    public string GetRandomWord()
    {
        return validWords[Random.Range(0, validWords.Count)];
    }
    public void AddLetter(string letter)
    {
        if (isGameEnded) return;
        if (currentWord.Length < 5)
        {
            letter = letter.ToLower();
            currentWord += letter;
            WordleUiManager.Instance.panelWordleMainView.AddLetter(letter);
        }
    }
    public void MoveToNextWord()
    {
        isValidAnswer();
        currentWordIndex++;
        currentLetterIndex = 0;
        currentWord = "";
        tempWinWord = winWord;
        totalChances--;
        buttonsPressed.Clear();
        if (totalChances == 0)
        {
            GameLost();
            Debug.Log("That was the last chance");
        }
        ShowHint();
    }

    public void DeleteLetter()
    {
        if (isGameEnded) return;
        if (currentWord.Length > 0)
        {
            currentWord = currentWord.Remove(currentWord.Length - 1);
            WordleUiManager.Instance.panelWordleMainView.DeleteLastLetters();
        }
    }
    //To check the correct answer
    public void isValidAnswer()
    {
        for (int i = 0; i < 5; i++)
        {
            if (IsCorrectPlace(i))
            {
                Debug.Log("correctAndCorrectPlaceColor");
                WordleUiManager.Instance.panelWordleMainView.AddColor(i, correctAndCorrectPlaceColor);
                buttonsPressed[i].SetContainerColor(correctAndCorrectPlaceColor);
            }
            else if(IsLetterInWord(i))
            {
                for (int j = i; j < 5; j++)
                {
                    if(currentWord[i] == winWord[j])
                    {
                        Debug.Log("notInWordColor");
                        WordleUiManager.Instance.panelWordleMainView.AddColor(i, notInWordColor);
                        buttonsPressed[i].SetContainerColor(notInWordColor);
                    }
                    else
                    {
                        Debug.Log("correctButWrongPlaceColor");
                        WordleUiManager.Instance.panelWordleMainView.AddColor(i, correctButWrongPlaceColor);
                        buttonsPressed[i].SetContainerColor(correctButWrongPlaceColor);
                    }
                }
            }
            else
            {
                WordleUiManager.Instance.panelWordleMainView.AddColor(i, notInWordColor);
                buttonsPressed[i].SetContainerColor(notInWordColor);
            }
        }
    }
    public void SubmitWord()
    {
        if (isGameEnded)
            return;
        if(currentWord.Length < 5)
        {
            Debug.Log("Not Enought letters");
            WordleUiManager.Instance.panelPopUp.ShowView();
            WordleUiManager.Instance.panelPopUp.ShowText("Not Enought letters");
            return;
        }
        if(!CheckIfWordIsValid())
        {
            WordleUiManager.Instance.panelPopUp.ShowView();
            WordleUiManager.Instance.panelPopUp.ShowText("Not Valid Word");
            Debug.Log("Not Valid Word");
            return;
        }
        if(currentWord == winWord)
        {
            GameWon();
        }
        else
        {
            MoveToNextWord();
        }
    }
    public void GameWon()
    {
        isGameEnded = true;
        isValidAnswer();
        WordleUiManager.Instance.panelPopUp.ShowView();
        WordleUiManager.Instance.panelPopUp.ShowText("GameWon");
        Debug.Log("GameWon");
    }
    public void GameLost()
    {
        isGameEnded = true;
    }
    #endregion

    #region PRIVATE_METHODS
    private bool IsCorrectPlace(int index)
    {
        return currentWord[index] == winWord[index];
    }
    private bool IsLetterInWord(int index)
    {
        if (tempWinWord.Contains(currentWord[index].ToString()))
        {
            tempWinWord = tempWinWord.Remove(tempWinWord.IndexOf(currentWord[index])) + "1" + tempWinWord.Substring(tempWinWord.IndexOf(currentWord[index]) + 1);
            Debug.Log(tempWinWord);
            return true;
        }
        return false;
    }
    private void ShowHint()
    {
        if(totalChances == 2)
        {
            Debug.Log(hints[0]);
        }
        if(totalChances == 1)
        {
            Debug.Log(hints[1]);
        }
    }
    private bool CheckIfWordIsValid()
    {
        return validWords.Contains(currentWord);
    }
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
public class TXTFileReader
{
    public static List<string> GetStrings(TextAsset textAsset)
    {
        return textAsset.text.Split('\n').ToList();
    }
}

