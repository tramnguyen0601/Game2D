using UnityEngine;
public class EnemyCavas : MonoBehaviour
{
    private Vector3 originalScale;                           //biến lưu kích thước ban đầu;
    private GameObject enemy;                               //biến lưu đối tượng enemy;
    private void Awake()
    {
        originalScale = transform.localScale;              //originalScale = (1, 1, 1);
        enemy = transform.parent.gameObject;               //biến lưu transform cha Enemy;
        //enemy = GameObject.FindGameObjectWithTag("Enemy");//không dùng được kiểu này vì chỉ tìm dc 1 Enemy -> gây lỗi
    }
    //Hàm chạy sau Update(),chờ Update xử lý xong hết mới đến LateUpdate()
    private void LateUpdate() 
    {
        if (enemy == null)
            return;

        float enemyScaleX = enemy.transform.localScale.x;  //biến lưu kích thước của Enemy: x = 1 or x = -1: trường hợp Enemy Flip()
        transform.localScale = new Vector3(
            originalScale.x * Mathf.Sign(enemyScaleX),
            originalScale.y,
            originalScale.z
        );// Mathf.Sign(playerScaleX): giới hạn -1, 0, 1, làm tròn về giới hạn này;
    }
}
