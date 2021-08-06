using UnityEngine;

/// <summary>
/// Hacky way of resetting the car when collides with the borders
/// </summary>
public class ResetCarOnly : MonoBehaviour
{

    public bool enable = true;
    public bool flipSide = false;
    public Transform startPos;

    private void OnCollisionEnter(Collision other)
    {
        if (enable)
        {
            other.transform.position = startPos.position;
            other.transform.rotation = startPos.rotation;

            if (flipSide)
                other.transform.Rotate(0f, 180f, 0f, Space.World);

            if (other.gameObject.TryGetComponent(out Rigidbody rb))
                rb.velocity = Vector3.zero;
        }
    }
}
