using UnityEngine;

public class PlayerMovememnt : MonoBehaviour
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public int No_Jmps=2;
    private int Jmps_left=2;
    public bool isKnockedBack = false;
    public float knockbackTimer = 0f;
    [SerializeField] public float knockbackDuration = 0.3f;
    public string playerName = "Blue Baldy";
    public AudioSource shootAudio;

    void Update()
    {
        // A = left, D = right
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        else
        {
            horizontal = 0f;
        }

        if (IsGrounded()) {
            Jmps_left=No_Jmps-1;
        }
        if (Input.GetKeyDown(KeyCode.W) && Jmps_left>0)
        {
            Jmps_left-=1;
            Debug.Log("No.Of Jumps left:" + Jmps_left);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        Flip();

        // T = shoot
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            // Instantiate bullet and set direction
            ProjectileBehaviour bullet = Instantiate(ProjectilePrefab, LaunchOffset.position, Quaternion.identity);
            bullet.Direction = isFacingRight ? Vector2.right : Vector2.left;
            shootAudio.Play();
        }
        if (GetComponent<Dead>().Lives <= 0)
        {
            GameManager.instance.PlayerDied(playerName);
        }
    }

    private void FixedUpdate()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.fixedDeltaTime;
            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
            }
            return; // skip movement
        }

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }



    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            float flipOffset = 0.5f; // You can tweak this value
            Vector3 position = transform.position;

            // Move player slightly in the new facing direction
            position.x += isFacingRight ? flipOffset : -flipOffset;

            transform.position = position;
        }
    }
}
