using UnityEngine;

public class Dead : MonoBehaviour
{
    private Vector2 startPosition;
    private Rigidbody2D rb;
    public float respawnDelay = 1.5f;
    public int Lives = 10;
    public float dropStartY = 10f;  // Height to drop the player from

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        Debug.Log("Position of:"+rb+"is"+startPosition);
    }

    void Update()
    {
        // Kill player if it falls off-screen
        if (transform.position.y < -6f && Lives!=0)
        {
            Die();
        }

        // Optional: stop falling when close to start position
        // if (isRespawning && transform.position.y <= startPosition.y)
        // {
        //     rb.linearVelocity = Vector2.zero;
        //     transform.position = startPosition;
        //     isRespawning = false;
        //     isDead = false;
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillZone") && Lives!=-1)
        {
            Die();
        }
        if (Lives==-1) {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        Lives -= 1 ;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameObject.SetActive(false);
        Invoke(nameof(RespawnFromTop), respawnDelay);
    }

    void RespawnFromTop()
    {
        transform.position = new Vector2(startPosition.x, dropStartY);
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;
        gameObject.SetActive(true);
    }
}