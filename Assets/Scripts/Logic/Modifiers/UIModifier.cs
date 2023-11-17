using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIModifier : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _image;

    public void InitCellUI(Modifier modifier)
    {
        try
        {
            _valueText.text = modifier.Value.ToString();
            _nameText.text = modifier.AbilityName.ToString();
            _image.sprite = modifier.Sprite;
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
        }
    }
}
