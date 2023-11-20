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
        PlayUIShowModifiersAnimation();
    }

    private void GetServiceReference() => 
        _rollService = AllServices.Container.Single<IRollDiceService>();

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

    private void PlayUIShowModifiersAnimation()
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
