using System;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public static event Action<int> OnRollResultGenerated;
    public static event Action OnRollBegin;

    private IRollDiceService _rollService;

    private void OnEnable() => GetServiceReference();

    public void Roll()
    {
        OnRollBegin?.Invoke();

        try
        {
            int result = _rollService.RollDice();

            OnRollResultGenerated?.Invoke(result);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void GetServiceReference() =>
        _rollService = AllServices.Container.Single<IRollDiceService>();
}
