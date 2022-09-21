using UnityEngine;

public class MaxHealthModifier : Interactable
{
    [SerializeField] private int maxHealthModifier;
    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Health.BuffMaxHealth(maxHealthModifier);
        else
            Character.CharacterM.Health.DeBuffMaxHealth(maxHealthModifier);
    }
}