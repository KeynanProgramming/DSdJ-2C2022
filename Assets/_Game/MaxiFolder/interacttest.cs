using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacttest : Interactable
{
    private void Start()
    {
        InteractableName = "Test";
    }

    public override void Interaction()
    {
        print("INTERACTUARON CONMIGO");
    }
}
