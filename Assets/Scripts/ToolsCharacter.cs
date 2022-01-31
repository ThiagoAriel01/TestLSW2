using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacter : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidBody2D;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfIteractableArea = 1.2f;
    [SerializeField] HighLightController highLightController;

    void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Check();
        if (Input.GetKeyDown("e"))
        {
            UseTool();
        }
    }

    public void Check()
    {
        Vector2 position = rigidBody2D.position + character.lastMove * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfIteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highLightController.HighLight(hit.gameObject);
                return;
            }
        }
        highLightController.Hide();

    }

    void UseTool()
    {
        highLightController.Hide();
        Vector2 position = rigidBody2D.position + character.lastMove * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfIteractableArea);
        foreach(Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
        
    }
}
