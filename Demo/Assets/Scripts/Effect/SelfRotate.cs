using UnityEngine;
public class SelfRotate:MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 100f * Time.deltaTime);
    }
}