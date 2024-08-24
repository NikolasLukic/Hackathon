using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player1; // The first player to follow
    public Transform player2; // The second player to follow
    public float smoothTime = 0.3f; // Time for the camera to smooth between positions
    public Vector3 offset = new Vector3(0, 0, -10); // Offset to keep the camera behind the players
    public float minCameraSize = 5f; // Minimum orthographic size of the camera
    public float maxCameraSize = 10f; // Maximum orthographic size of the camera
    public float sizeSmoothTime = 0.3f; // Time for the camera size to smooth to the new size
    public float zoomLimiter = 50f; // A factor to control how much the camera zooms out
    public float minYPosition = 0f; // The minimum y position the camera can move to

    private Vector3 velocity = Vector3.zero; // Reference velocity for SmoothDamp
    private float sizeVelocity = 0.0f; // Reference velocity for SmoothDamp on size

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        Vector3 midpoint = Vector3.zero;

        // Calculate the midpoint between the two players
        if (!player1.GetComponent<movementScript>().isDead && !player2.GetComponent<movementScript>().isDead)
        {
            midpoint = (player1.position + player2.position) / 2f + offset; 
        }else if (player1.GetComponent<movementScript>().isDead)
        {
            midpoint = player2.position + offset; 
        }else if (player2.GetComponent<movementScript>().isDead)
        {
            midpoint = player1.position + offset; 
        }

        // Calculate the distance between the two players
        float distance = (player1.position - player2.position).magnitude;

        // Adjust the camera size to fit both players on screen
        float targetSize = Mathf.Clamp(distance / zoomLimiter, minCameraSize, maxCameraSize);
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, targetSize, ref sizeVelocity, sizeSmoothTime);

        // Clamp the y position of the midpoint considering the camera's size
        float cameraHeight = Camera.main.orthographicSize;
        midpoint.y = Mathf.Clamp(midpoint.y, minYPosition + cameraHeight, Mathf.Infinity);

        // Smoothly follow the midpoint position
        transform.position = Vector3.SmoothDamp(transform.position, midpoint, ref velocity, smoothTime);
    }
}
