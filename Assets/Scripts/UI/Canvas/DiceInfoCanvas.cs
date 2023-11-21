using System;
using UnityEngine;

public class DiceInfoCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _diceInfoHint;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeOut_Animation _showFadeAnimation;
    [SerializeField] private UiFadeIn_Animation _hideFadeAnimation;

    public void Init() => 
        PlayShowAnimation();

    /// <summary>
    /// Проигрывает плавную анимацию исчезания подсказки броска кубика
    /// </summary>
    public void PlayHideAnimation()
    {
        try
        {
            _hideFadeAnimation.Hide();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Проигрывает плавную анимацию появления подсказки броска кубика
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
