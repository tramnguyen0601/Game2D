using UnityEngine;

public class DeathGroundFollowCamera : MonoBehaviour
{
    public Camera mainCamera;

    // Dùng để chỉnh mặt đất cao/thấp một chút
    public float bottomOffset = 0.5f;

    void LateUpdate()
    {
        // Tọa độ đáy của Camera
        float bottomY =
            mainCamera.transform.position.y
            - mainCamera.orthographicSize;

        // DeathGround đi theo X Camera
        // và luôn nằm ở đáy màn hình
        transform.position = new Vector3(
            mainCamera.transform.position.x,
            bottomY + bottomOffset,
            transform.position.z
        );
    }
}
