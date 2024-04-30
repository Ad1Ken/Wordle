using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordleKeyboardButton : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public Button keyboardButton;
    public TextMeshProUGUI letterText;
    public Image containerImage;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    public void SetContainerText(string letter) => letterText.text = letter;
    public void SetContainerColor(Color color) => containerImage.color = color;

    public void OnCLickButton()
    {
        WordleManagers.Instance.AddLetter(letterText.text);
        WordleManagers.Instance.buttonsPressed.Add(this);
    }

    public void OnCLickEnter()
    {
        WordleManagers.Instance.SubmitWord();
    }
    public void OnClickDelete()
    {
        WordleManagers.Instance.DeleteLetter();
        WordleManagers.Instance.buttonsPressed.RemoveAt(WordleManagers.Instance.buttonsPressed.Count - 1);
    }
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
