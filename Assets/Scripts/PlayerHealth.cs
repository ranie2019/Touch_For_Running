using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerLives = 7;
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesText();
    }

    public void PlayerDies()
    {
        playerLives--;

        if (playerLives > 0)
        {
            Debug.Log("O jogador morreu. Vidas restantes: " + playerLives);
            UpdateLivesText();
        }
        else
        {
            Debug.Log("Game Over! O jogador está sem vidas.");
            // Adicione aqui a lógica para lidar com o fim do jogo, como reiniciar o jogo ou exibir uma tela de game over.
        }
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = ": " + playerLives;
        }
        else
        {
            Debug.LogWarning("Componente TextMeshProUGUI não atribuído para exibir a quantidade de vidas.");
        }
    }
}
