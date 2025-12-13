using Unity.Netcode;
using UnityEngine;

public class MysteryBoxCollectible : NetworkBehaviour, ICollectible
{
    [Header("References")]
    [SerializeField] private Animator boxAnimator;
    [SerializeField] private Collider boxCollider;

    [Header("Settings")]
    [SerializeField] private float respawnTimer;


    public void Collect()
    {
        Debug.Log("Mystery Box Collected!");
        CollectRpc();
    }

    [Rpc(SendTo.ClientsAndHost)]
    public void CollectRpc()
    {
        AnimateCollection();
        Invoke(nameof(Respawn), respawnTimer);
    }

    private void AnimateCollection()
    {
        boxCollider.enabled = false;
        boxAnimator.SetTrigger(Consts.BoxAnimations.IS_COLLECTED);
    }

    private void Respawn()
    {
        boxAnimator.SetTrigger(Consts.BoxAnimations.IS_RESPAWNED);
        boxCollider.enabled = true;
    }
}
