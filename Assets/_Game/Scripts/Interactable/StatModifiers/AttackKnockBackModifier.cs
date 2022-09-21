using UnityEngine;

public class AttackKnockBackModifier : Interactable
{
    [SerializeField] private float attackKnockBackModifier;
    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Stats.AttackKnockBackBuff(attackKnockBackModifier);
        else
            Character.CharacterM.Stats.AttackKnockBackDeBuff(attackKnockBackModifier);
    }
}