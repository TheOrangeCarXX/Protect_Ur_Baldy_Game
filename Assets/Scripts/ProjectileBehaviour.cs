using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;
    public float DestroyTime=10f;
    public Vector2 Direction = Vector2.right;
    public float knockbackStrength = 10f; // You can adjust this value to change the force of the knockback

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void Update()
    {
        transform.position += (Vector3)Direction.normalized * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");

            // Knockback direction
            Debug.Log("Knockback Direction: " + Direction.normalized);

            // Apply force for knockback
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Direction.normalized* knockbackStrength, ForceMode2D.Impulse);
            }

            // Set knockback status
            PlayerMovememnt playerScript = collision.gameObject.GetComponent<PlayerMovememnt>();
            PlayerMovememnt2 playerScript2 = collision.gameObject.GetComponent<PlayerMovememnt2>();
            if (playerScript != null)
            {
                playerScript.isKnockedBack = true;
                playerScript.knockbackTimer = playerScript.knockbackDuration;
            }
            if (playerScript2 != null)
            {
                playerScript2.isKnockedBack = true;
                playerScript2.knockbackTimer = playerScript2.knockbackDuration;
            }
        }
        Destroy(gameObject);
    }
}
