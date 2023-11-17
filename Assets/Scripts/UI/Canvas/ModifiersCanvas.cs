using UnityEngine;

public class ModifiersCanvas : MonoBehaviour
{
    public Modifier[] Modifiers { get; private set; }

    [SerializeField] private Transform _contentParent;

	private IModifierService _modifierService;


    public void Init()
    {
		try
		{
            _modifierService = AllServices.Container.Single<IModifierService>();
            Modifiers = _contentParent.GetComponentsInChildren<Modifier>();

			foreach (Modifier modifier in Modifiers)
			{
                _modifierService.ConstructModifier(modifier);
            }

        }
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }
}
