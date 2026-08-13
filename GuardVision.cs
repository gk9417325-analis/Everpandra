using UnityEngine;

public class GuardVision : MonoBehaviour
{
    [SerializeField] float range = 7f;
    [SerializeField, Range(10f, 170f)] float angle = 70f;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask obstacleMask;

    public bool CanSeePlayer(Transform player)
    {
        Vector3 origin = transform.position + Vector3.up * 1.2f;
        Vector3 target = player.position + Vector3.up * 1.0f;
        Vector3 toPlayer = target - origin;

        if (toPlayer.magnitude > range) return false;
        if (Vector3.Angle(transform.forward, toPlayer) > angle * 0.5f) return false;

        if (Physics.Raycast(origin, toPlayer.normalized, out RaycastHit hit, range, playerMask | obstacleMask))
            return ((1 << hit.collider.gameObject.layer) & playerMask) != 0;

        return false;
    }
}
