using UnityEngine;

public class DeathGroundFollowCamera : MonoBehaviour
{
    public Camera mainCamera;

    public float bottomOffset = 0.5f;

    void LateUpdate()
    {
        float bottomY =
            mainCamera.transform.position.y
            - mainCamera.orthographicSize
            + bottomOffset;

        transform.position = new Vector3(
            mainCamera.transform.position.x,
            bottomY,
            transform.position.z
        );
    }
}
