using UnityEngine;

public class AttackDamageModifier : Interactable
{
    [SerializeField] private int damageModifier;
    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Stats.AttackDamageBuff(damageModifier);
        else
            Character.CharacterM.Stats.AttackDamageDeBuff(damageModifier);
    }
}