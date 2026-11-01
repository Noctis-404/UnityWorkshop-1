
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float limit = 8f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 pos = transform.position;
        pos.x += move * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -limit, limit);

        transform.position = pos;
    }
}
