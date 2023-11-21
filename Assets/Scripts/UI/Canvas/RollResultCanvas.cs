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
    /// ��������� �������� �������� ��������� ������ � ����������� �������� ������
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
    /// ��������� ������ �� ������ �������� ���������
    /// </summary>
    /// <returns>true, ���� ������ �������, ����� false</returns>
    private bool IsRollResultSuccessful() =>
        _rollService.RollResult >= _rollService.RollDifficulty;

    /// <summary>
    /// ���������� ����� � ����������� �������� ��������� ������ ������
    /// </summary>
    /// <param name="success">�������� � ����������� ��������</param>
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
    /// ��������� ��������� �������� � �������
    /// </summary>
    /// <param name="result">��������� ������ ������</param>
    private void SaveRollResult(int result) =>
       _rollService.SaveRollResult(result);

    private void SubscribeRollCallbacks() =>
      RollDice.OnRollResultGenerated += SaveRollResult;
    private void UnsubscribeRollCallbacks() =>
       RollDice.OnRollResultGenerated -= SaveRollResult;

    /// <summary>
    /// ��������� �������� �������� ��������� ������ � ����������� �������� ������ ������
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
