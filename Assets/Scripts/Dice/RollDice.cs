using System;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public static event Action<int> OnRollResultGenerated;
    public static event Action OnRollBegin;

    public void Roll()
    {
        OnRollBegin?.Invoke();

        try
        {
            int result = UnityEngine.Random.Range(0, RollService.DiceSides);
            OnRollResultGenerated?.Invoke(result);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
