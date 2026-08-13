using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float speed = 2f;
    [SerializeField] float arriveDistance = 0.15f;

    int index;

    void Update()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        Transform target = patrolPoints[index];
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        Vector3 dir = target.position - transform.position;
        if (dir.sqrMagnitude > 0.001f)
            transform.forward = Vector3.Slerp(transform.forward, dir.normalized, 8f * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= arriveDistance)
            index = (index + 1) % patrolPoints.Length;
    }
}
