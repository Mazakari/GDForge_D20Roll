using TMPro;
using UnityEngine;

public class DiceInfoCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _diceInfoHint;
    [SerializeField] private GameObject _rollResult;

    [SerializeField] private TMP_Text _successText;
    [SerializeField] private TMP_Text _failText;

    private IRollDiceService _rollService;

    public void Init()
    {
        GetServicesReferences();
        ActivateHint();
    }

    public void ShowSucessText(bool success)
    {
        try
        {
            _successText.gameObject.SetActive(success);
            _failText.gameObject.SetActive(!success);

            _rollResult.SetActive(true);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void ActivateHint()
    {
        try
        {
            _diceInfoHint.SetActive(true);
            _rollResult.SetActive(false);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    public void DeactivateHint()
    {
        try
        {
            _diceInfoHint.SetActive(false);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void ShowResultText(int rollResult)
    {
        try
        {
            bool success = rollResult > _rollService.RollDifficulty;
            ShowSucessText(success);
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
    private void GetServicesReferences() =>
       _rollService = AllServices.Container.Single<IRollDiceService>();
}
