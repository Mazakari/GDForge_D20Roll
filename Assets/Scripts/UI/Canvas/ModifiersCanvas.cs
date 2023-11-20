using UnityEngine;

public class ModifiersCanvas : MonoBehaviour
{
    public Modifier[] Modifiers { get; private set; }

    [SerializeField] private Transform _contentParent;

	private IModifierService _modifierService;

    [Space(10)]
    [Header("UI Animation")]
    [SerializeField] private UiFadeOut_Animation _fadeAnimation;


    public void Init()
    {
		try
        {
            SetServiceReference();
            GetActiveModifiersCollection();
            ConstructActiveModifiersData();
            PlayUIShowModifiersAnimation();

        }
        catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }

    private void GetActiveModifiersCollection() => 
        Modifiers = _contentParent.GetComponentsInChildren<Modifier>();

    private void SetServiceReference() => 
        _modifierService = AllServices.Container.Single<IModifierService>();

    private void ConstructActiveModifiersData()
    {
        foreach (Modifier modifier in Modifiers)
        {
            _modifierService.ConstructModifier(modifier);
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
