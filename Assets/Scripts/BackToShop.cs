using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToShop : Interactable
{
    public override void Hit()
    {
        transform.parent.GetComponent<BackTransition>().InitTransition();
    }
}
