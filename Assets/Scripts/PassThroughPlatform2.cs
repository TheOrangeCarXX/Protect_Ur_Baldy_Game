using UnityEngine;
using System.Collections;

public class PassThroughPlatform2: MonoBehaviour
{
    [Tooltip("The key this player uses to drop down through a platform.")]
    public string downKey = "down"; // Use "down" for ArrowDown, etc.

    [Tooltip("How long to ignore collision before resetting.")]
    public float dropTime = 0.3f;

    [Tooltip("Name of the layer that ignores the platform collisions.")]
    public string platformLayerName = "PlatformPassThrough";

    [Tooltip("Transform used to check if the player is grounded.")]
    public Transform groundCheck;

    [Tooltip("Radius of the ground check circle.")]
    public float groundCheckRadius = 0.2f;

    [Tooltip("Which layers count as ground.")]
    public LayerMask groundLayer;

    private int normalLayer;
    private int passThroughLayer;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Start()
    {
        normalLayer = gameObject.layer;
        passThroughLayer = LayerMask.NameToLayer(platformLayerName);
    }

    void Update()
    {
        if (Input.GetKeyDown(downKey) && IsGrounded())
        {
            StartCoroutine(DropThrough());
        }
    }

    private IEnumerator DropThrough()
    {
        SetLayerRecursively(gameObject, passThroughLayer);
        Physics2D.SyncTransforms(); // Ensures physics layer changes take effect immediately

        yield return new WaitForSeconds(dropTime);

        SetLayerRecursively(gameObject, normalLayer);
        Physics2D.SyncTransforms();
    }

    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
