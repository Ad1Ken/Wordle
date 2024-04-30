using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wordleHorizontalLayout : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    [SerializeField] public List<wordleLetterContainer> letterContainer = new List<wordleLetterContainer>() ;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    //Set the text of each text
    public void SetContainerText(int letterIndex, string letter)
    {
        letterContainer[letterIndex].SetContainerText(letter);
    }
    //Set the color of each text
    public void SetContainerColor(int letterIndex, Color color)
    {
        letterContainer[letterIndex].SetContainerColor(color);
    }

    public void DeleteLetter(int letterIndex)
    {
        letterContainer[letterIndex].SetContainerText("");
    }
    #endregion


    #region PRIVATE_METHODS
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
