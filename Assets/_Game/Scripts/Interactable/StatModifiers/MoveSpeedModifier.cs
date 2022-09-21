using UnityEngine;

public class MoveSpeedModifier : Interactable
{
    [SerializeField] private float moveSpeedModifier;
    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Stats.MoveSpeedBuff(moveSpeedModifier);
        else
            Character.CharacterM.Stats.MoveSpeedDeBuff(moveSpeedModifier);
    }
}