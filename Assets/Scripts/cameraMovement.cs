using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target; // The target for the camera to follow
    public float smoothTime = 0.3f; // Time for the camera to smooth between positions
    public Vector3 offset = new Vector3(0, 0, -10); // Offset to keep the camera behind the player
    public float cameraSize = 5f; // The desired camera orthographic size
    public float sizeSmoothTime = 0.3f; // Time for the camera size to smooth to the new size

    private Vector3 velocity = Vector3.zero; // Reference velocity for SmoothDamp
    private float sizeVelocity = 0.0f; // Reference velocity for SmoothDamp on size

    void Start()
    {
        // Set the initial camera size
        Camera.main.orthographicSize = cameraSize;
    }

    void LateUpdate()
    {
        // Ensure the target is assigned
        if (target != null)
        {
            // Smoothly follow the target's position with an offset
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        // Smoothly change the camera's orthographic size
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, cameraSize, ref sizeVelocity, sizeSmoothTime);
    }
}
