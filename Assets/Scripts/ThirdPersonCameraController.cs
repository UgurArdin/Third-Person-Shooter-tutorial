using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Player localPlayer;
    private Transform cameraLookTarget;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float damping;
    void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined+= HandleOnLocalPlayerJoined;
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("CameraLookTarget");
        if (cameraLookTarget == null)
        {
            cameraLookTarget = localPlayer.transform;
        }

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.right * cameraOffset.x +
                                 localPlayer.transform.forward * cameraOffset.z +
                                 localPlayer.transform.up * cameraOffset.y;

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
    }
}
