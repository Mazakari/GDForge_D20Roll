using System;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
   public static event Action OnContinueButtonPress;

    public void Continue() => 
        OnContinueButtonPress?.Invoke();
}
