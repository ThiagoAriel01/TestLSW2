using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D arrowCursor;
    void Start()
    {
        Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

}
