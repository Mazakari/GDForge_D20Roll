using System;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public static event Action<int> OnRollResultGenerated;
    public static event Action OnRollBegin;

    private IRollDiceService _rollService;

    private void OnEnable() => 
        _rollService = AllServices.Container.Single<IRollDiceService>();


    public void Roll()
    {
        OnRollBegin?.Invoke();

        try
        {
            int result = GetRollResult();

            OnRollResultGenerated?.Invoke(result);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private int GetRollResult() =>
        UnityEngine.Random.Range(0, _rollService.DiceSides);
}
