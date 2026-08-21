using UnityEngine;
public class PlayerCanvas : MonoBehaviour
{
    private Vector3 notFlipProgressBar;
    private void Awake()
    {
        notFlipProgressBar = transform.localScale;
    }
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(
            Mathf.Abs(notFlipProgressBar.x),
            Mathf.Abs(notFlipProgressBar.y),
            Mathf.Abs(notFlipProgressBar.z));
    }
}
