using Unity.Netcode;
using Unity.Cinemachine;
using UnityEngine;
using Unity.Services.Matchmaker.Models;

public class PlayerNetworkController : NetworkBehaviour
{
    [SerializeField] private CinemachineCamera playerCamera;

    public override void OnNetworkSpawn()
    {
        playerCamera.gameObject.SetActive(IsOwner);
    }
}
