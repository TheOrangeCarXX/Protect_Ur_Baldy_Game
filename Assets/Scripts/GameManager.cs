using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI winnerText;
    public GameObject player;
    public GameObject player1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayerDied(string losingPlayer)
    {
        string winner = (losingPlayer == "Blue Baldy") ? "Red Baldy" : "Blue Baldy";

        gameOverPanel.SetActive(true);
        winnerText.text = winner + " Wins!";
        if (player != null) player.SetActive(false);
        if (player1 != null) player1.SetActive(false);
    }
}
