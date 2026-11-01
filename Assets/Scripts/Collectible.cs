using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum ItemType { RegularCoin, Bomb, GoldenCoin }
    public ItemType itemType = ItemType.RegularCoin;

    public float fallSpeed = 4f;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                if (itemType == ItemType.RegularCoin)
                {
                    GameManager.instance.AddScore(1);
                }
                else if (itemType == ItemType.Bomb)
                {
                    GameManager.instance.TakeDamage(1);
                }
                else if (itemType == ItemType.GoldenCoin)
                {
                    GameManager.instance.AddLife(1);
                }
            }
            Destroy(gameObject);
        }
    }
}