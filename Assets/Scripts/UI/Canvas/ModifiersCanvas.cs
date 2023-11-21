using UnityEngine;

public class ModifiersCanvas : MonoBehaviour
{
    public Modifier[] Modifiers { get; private set; }

    [SerializeField] private Transform _contentParent;

	private IModifierService _modifierService;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeOut_Animation _showFadeAnimation;
    [SerializeField] private UiFadeIn_Animation _hideFadeAnimation;

    public void Init()
    {
		try
        {
            SetServiceReference();
            GetActiveModifiersCollection();
            ConstructActiveModifiersData();
            PlayShowAnimation();

        }
        catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }

    /// <summary>
    /// Запускает анимацию плавного исчезновения панели с модификаторами
    /// </summary>
    public void HideModifiers()
    {
        try
        {
            _hideFadeAnimation.Hide();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Получает ссылку на коллекцию текущих модификаторов
    /// </summary>
    private void GetActiveModifiersCollection() => 
        Modifiers = _contentParent.GetComponentsInChildren<Modifier>();


    private void SetServiceReference() => 
        _modifierService = AllServices.Container.Single<IModifierService>();

    /// <summary>
    /// Заполняет все активные модификаторы данными из Static Data
    /// </summary>
    private void ConstructActiveModifiersData()
    {
        foreach (Modifier modifier in Modifiers)
        {
            _modifierService.ConstructModifier(modifier);
        }
    }

    /// <summary>
    /// Запускает анимацию плавного появления панели с модификаторами
    /// </summary>
    private void PlayShowAnimation()
    {
        try
        {
            _showFadeAnimation.Show();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
