using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class wordleLetterContainer : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public TextMeshProUGUI letterText;
    public Image containerImage;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    //public void SetContainerColor(Color color) => containerImage.color = color;
    public void SetContainerText(string letter) => letterText.text = letter;
    public void SetContainerColor(Color color) => containerImage.color = color;
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
