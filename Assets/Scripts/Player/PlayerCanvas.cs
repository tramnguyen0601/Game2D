using UnityEngine;
public class PlayerCanvas : MonoBehaviour
{
    
    private Vector3 originalScale;                            //biến lưu kích thước ban đầu;
    private GameObject player;                               //biến lưu đối tượng Player;
    private void Awake()
    {
        originalScale = transform.localScale;               //originalScale = (1, 1, 1);
        player = GameObject.FindGameObjectWithTag("Player");//tìm đối tượng có Tag = Player & lưu reference; (chỉ tìm đúng với 1 Player)
    }
    private void LateUpdate() //Hàm chạy sau Update(),chờ Update xử lý xong hết mới đến LateUpdate()
    {
        if (player == null)
            return;

        float playerScaleX = player.transform.localScale.x;  //biến lưu kích thước của Player: x = 1 or x = -1: trường hợp Player Flip()
        transform.localScale = new Vector3(
            originalScale.x * Mathf.Sign(playerScaleX),
            originalScale.y,
            originalScale.z
        );// Mathf.Sign(playerScaleX): giới hạn -1, 0, 1, làm tròn về giới hạn này;
    }
}
