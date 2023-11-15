using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCanvas : MonoBehaviour
{
    [SerializeField] private Button _rollDiceButton;
    [SerializeField] private Button _continueButton;

    public void Init()
    {
        try
        {
            ButtonIsActive(_rollDiceButton, true);
            ButtonIsActive(_continueButton, false);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void DeactivateRollButton() =>
       ButtonIsActive(_rollDiceButton, false);

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
}
