using TMPro;
using UnityEngine;

public class DifficultyClassCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text _classValueText;

    private IRollDiceService _rollService;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeOut_Animation _fadeAnimation;

    public void Init()
    {
        GetServiceReference();
        SetDifficultyText();
        PlayShowAnimation();
    }

    private void GetServiceReference() => 
        _rollService = AllServices.Container.Single<IRollDiceService>();

    /// <summary>
    /// Устанавливает новое значение сложности для проверки броска кубика
    /// </summary>
    private void SetDifficultyText()
    {
        try
        {
            _classValueText.text = _rollService.RollDifficulty.ToString();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }

    /// <summary>
    /// Проигрывает анимацию плавного появления текста сложности броска
    /// </summary>
    private void PlayShowAnimation()
    {
        try
        {
            _fadeAnimation.Show();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
