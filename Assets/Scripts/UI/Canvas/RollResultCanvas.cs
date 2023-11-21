using System;
using TMPro;
using UnityEngine;

public class RollResultCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _successText;
    [SerializeField] private TMP_Text _failText;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeOut_Animation _showFadeAnimation;

    private IRollDiceService _rollService;

    private void OnDisable() =>
       UnsubscribeRollCallbacks();

    public void Init()
    {
        SubscribeRollCallbacks();

        GetServicesReferences();
    }

    /// <summary>
    /// Запускает анимацию плавного появления текста с результатом проверки броска
    /// </summary>
    public void ShowResultText()
    {
        try
        {
            bool success = IsRollResultSuccessful();
            ShowSucessText(success);
            PlayShowAnimation();
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Проверяет прошел ли бросок проверку сложности
    /// </summary>
    /// <returns>true, если бросок успешен, иначе false</returns>
    private bool IsRollResultSuccessful() =>
        _rollService.RollResult >= _rollService.RollDifficulty;

    /// <summary>
    /// Активирует текст с результатом проверки сложности броска кубика
    /// </summary>
    /// <param name="success">Значение с результатом проверки</param>
    private void ShowSucessText(bool success)
    {
        try
        {
            _successText.gameObject.SetActive(success);
            _failText.gameObject.SetActive(!success);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void GetServicesReferences() =>
       _rollService = AllServices.Container.Single<IRollDiceService>();

    /// <summary>
    /// Сохраняет результат проверки в сервисе
    /// </summary>
    /// <param name="result">Результат броска кубика</param>
    private void SaveRollResult(int result) =>
       _rollService.SaveRollResult(result);

    private void SubscribeRollCallbacks() =>
      RollDice.OnRollResultGenerated += SaveRollResult;
    private void UnsubscribeRollCallbacks() =>
       RollDice.OnRollResultGenerated -= SaveRollResult;

    /// <summary>
    /// Запускает анимацию плавного появления текста с результатом проверки броска кубика
    /// </summary>
    private void PlayShowAnimation()
    {
        try
        {
            _showFadeAnimation.Show();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
