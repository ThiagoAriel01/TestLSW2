using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteractable : Interactable
{
    [SerializeField] DialogueContainer dialogue;
    public override void Hit()
    {
        GameManager.instance.dialogueSystem.Init(dialogue);
    }
}
