using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordlePopUp : BaseView
{
    #region PUBLIC_PROPERTIES
    public TextMeshProUGUI disPlayText;
    public TextMeshProUGUI correctWordText;

    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField]private GameObject closeButton;
    [SerializeField] private GameObject PlayButton;
    #endregion

    #region UNITY_CALLBACKS
    private void OnEnable()
    {
        correctWordText.gameObject.SetActive(false);
        ShowCloseButton();
    }
    #endregion

    #region PUBLIC_METHODS
    public void ShowWinWord(string word)
    {
        correctWordText.gameObject.SetActive(true);
        correctWordText.text = "Correct Word: " + word;
    }

    public void ShowText(string textMsg)
    {
        disPlayText.text = textMsg;
    }

    public void ShowCloseButton()
    {
        if(WordleManagers.Instance.isGameEnded)
        {
            closeButton.SetActive(true);
            PlayButton.SetActive(true);
        }
        else
        {
            PlayButton.SetActive(false);
            closeButton.SetActive(false);
            StartCoroutine(PopUpDisplay());
        }
    }

    public void OnClickPlaynClose()
    {
        HideView();
        WordleManagers.Instance.StartGame();
    }

    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGATE_CALLBACKS
    #endregion

    #region Coroutines
    private IEnumerator PopUpDisplay()
    {
        WordleUiManager.Instance.panelTouchBlock.ShowView();
        ShowView();
        yield return new WaitForSeconds(2f);
        HideView();
        WordleUiManager.Instance.panelTouchBlock.HideView();
    }
    #endregion
}
