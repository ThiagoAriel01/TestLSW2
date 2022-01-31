using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolHit : Interactable
{
    public override void Hit()
    {
        transform.parent.GetComponent<Transition>().InitTransition();
    }
}


