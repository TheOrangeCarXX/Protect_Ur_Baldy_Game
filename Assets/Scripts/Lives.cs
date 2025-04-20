using TMPro;  // For TextMeshPro
using UnityEngine;

public class Lives: MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public Dead player; // Reference to your PlayerMovement script

    void Update()
    {
        if (player != null)
        {
            livesText.text = player.Lives.ToString();
        }
    }
}
