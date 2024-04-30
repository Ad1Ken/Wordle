using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordleMainMenu : BaseView
{
    #region PUBLIC_PROPERTIES
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
 
    #endregion

    #region PUBLIC_METHODS
    public void OnClickPlay()
    {
        HideView();
        WordleUiManager.Instance.panelWordleMainView.ShowView();
        WordleManagers.Instance.StartGame();
    }
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
