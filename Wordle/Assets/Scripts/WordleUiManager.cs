using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordleUiManager : MonoBehaviour
{
    public static WordleUiManager Instance;
    #region PUBLIC_PROPERTIES
    public wordleMainView panelWordleMainView;
    public WordleMainMenu panelMainMenu;
    public WordlePopUp panelPopUp;
    public TouchBlock panelTouchBlock;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region PUBLIC_METHODS
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
