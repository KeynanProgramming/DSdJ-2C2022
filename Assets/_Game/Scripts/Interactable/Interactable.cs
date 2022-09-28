using UnityEngine;

public enum InteractionType
{
    None,
    SpreadI,
    FireRateF,
    VolleyF,
    PierceI,
    KnockBackF,
    DisruptionF,
    DamageI,
    MaxHealthI,
    MoveSpeedF
}

[RequireComponent(typeof(SphereCollider))]
public abstract class Interactable : MonoBehaviour, IInteractable
{
    #region SerializedFields

#pragma warning disable 649
    [SerializeField] private InteractionType interactionType;
#pragma warning restore 649

    #endregion

    protected CharacterC Character;
    protected string InteractableName;
    public string Name => InteractableName;
    public InteractionType InteractionType => interactionType;

    private void Awake()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    public virtual void Interaction()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Character = other.GetComponent<CharacterC>();
            if (Character == null) return;
            Character.Interactable = this;
            Character.IsInInteractRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) CharacterClear();
    }

    private void CharacterClear()
    {
        if (Character == null) return;
        Character.Interactable = null;
        Character.IsInInteractRange = false;
        Character = null;
    }

    private void OnDisable()
    {
        CharacterClear();
    }
}