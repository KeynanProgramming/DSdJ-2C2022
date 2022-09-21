using UnityEngine;

public class AttackPierceModifier : Interactable
{
    [SerializeField] private int pierceModifier;
    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Stats.AttackPierceBuff(pierceModifier);
        else
            Character.CharacterM.Stats.AttackPierceDeBuff(pierceModifier);
    }
}