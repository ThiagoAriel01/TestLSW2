using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float rotationSpeed = 100, rotation;

    void Update()
    {
        rotation += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
