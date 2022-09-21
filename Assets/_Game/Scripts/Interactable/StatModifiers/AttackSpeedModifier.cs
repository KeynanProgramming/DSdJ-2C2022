using UnityEngine;

public class AttackSpeedModifier : Interactable
{
    [SerializeField] [Tooltip("0.25f steps")]
    private float attackSpeedModifier;

    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Stats.AttackSpeedBuff(attackSpeedModifier);
        else
            Character.CharacterM.Stats.AttackSpeedDeBuff(attackSpeedModifier);
    }
}