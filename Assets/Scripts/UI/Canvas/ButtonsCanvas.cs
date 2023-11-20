using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCanvas : MonoBehaviour
{
    [SerializeField] private Button _rollDiceButton;
    [SerializeField] private Button _continueButton;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeOut_Animation _showFadeAnimation;

    public void Init() => 
        SetInitButtonsStates();

    public void DeactivateRollButton() =>
       ButtonIsActive(_rollDiceButton, false);

    public void ShowContinueButton()
    {
        try
        {
            ButtonIsActive(_continueButton, true);
            _showFadeAnimation.Show();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void ButtonIsActive(Button button, bool isActive)
    {
        try
        {
            button.gameObject.SetActive(isActive);
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }
    private void SetInitButtonsStates()
    {
        try
        {
            ButtonIsActive(_rollDiceButton, true);
            ButtonIsActive(_continueButton, false);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
