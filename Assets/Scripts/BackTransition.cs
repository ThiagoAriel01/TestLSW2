using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTransition : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject player;

    internal void InitTransition()
    {
        Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(player.transform, destination.position - player.transform.position);
        player.transform.position = new Vector3(destination.position.x, destination.position.y, player.transform.position.z);
    }
}
