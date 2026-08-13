using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;

    public Vector2 MoveInput { get; set; }

    void Update()
    {
        Vector3 input = new Vector3(MoveInput.x, 0f, MoveInput.y);
        if (input.sqrMagnitude > 1f) input.Normalize();

        transform.position += input * moveSpeed * Time.deltaTime;

        if (input.sqrMagnitude > 0.001f)
            transform.forward = Vector3.Slerp(transform.forward, input, 12f * Time.deltaTime);
    }
}
