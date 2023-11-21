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

    /// <summary>
    /// Отключает кнопу броска кубика
    /// </summary>
    public void DeactivateRollButton() =>
       ButtonIsActive(_rollDiceButton, false);

    /// <summary>
    /// Начинает плавную анимацию появления кнопки
    /// </summary>
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

    /// <summary>
    /// Меняет текущее состояние кнопки на новое
    /// </summary>
    /// <param name="button">Ссылка на кнопку</param>
    /// <param name="isActive">Новое состояние кнопки</param>
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

    /// <summary>
    /// Устанавливает состояния кнопок в исходное состояние
    /// </summary>
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
