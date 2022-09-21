using UnityEngine;

public class SpreadModifier : Interactable
{
    [SerializeField] [Range(1, 4)] private int additionalArrows;
    [SerializeField] private string modifierName;
    [SerializeField] private bool isBuff;

    private void Start()
    {
        InteractableName = modifierName;
    }

    public override void Interaction()
    {
        if (isBuff)
            Character.CharacterM.Stats.SimultaneousArrowsBuff(additionalArrows);
        else
            Character.CharacterM.Stats.SimultaneousArrowsDeBuff(additionalArrows);
    }
}