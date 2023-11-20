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

    public void ShowResultText()
    {
        try
        {
            GetRollResult();
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
        }
    }

    private void GetRollResult()
    {
        bool success = _rollService.RollResult >= _rollService.RollDifficulty;
        ShowSucessText(success);
    }

    private void ShowSucessText(bool success)
    {
        try
        {
            _successText.gameObject.SetActive(success);
            _failText.gameObject.SetActive(!success);

            PlayShowAnimation();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void GetServicesReferences() =>
       _rollService = AllServices.Container.Single<IRollDiceService>();

    private void SaveRollResult(int result) =>
       _rollService.SaveRollResult(result);

    private void SubscribeRollCallbacks() =>
      RollDice.OnRollResultGenerated += SaveRollResult;
    private void UnsubscribeRollCallbacks() =>
       RollDice.OnRollResultGenerated -= SaveRollResult;

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
