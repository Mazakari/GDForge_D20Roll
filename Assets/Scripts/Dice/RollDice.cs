using System;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public static event Action<int> OnRollResultGenerated;
    public static event Action OnRollBegin;
    public static event Action OnRollEnd;

    public void Roll()
    {
        OnRollBegin?.Invoke();

        try
        {
            int result = UnityEngine.Random.Range(0, RollService.DiceSides);
            OnRollResultGenerated?.Invoke(result);
            OnRollEnd?.Invoke();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
