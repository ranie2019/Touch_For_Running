using UnityEngine;
using TMPro; // Adiciona esta linha para incluir o TextMeshPro
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text score, recorde; // Altera Text para TMP_Text

    void Start()
    {
        // Obtém e exibe a pontuação salva no PlayerPrefs
        score.text = PlayerPrefs.GetInt("score").ToString();

        // Obtém e exibe o recorde salvo no PlayerPrefs
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    // Função para carregar uma cena com o nome fornecido
    public void irPara(string nomecena)
    {
        SceneManager.LoadScene(nomecena);
    }

    // Função para fechar o aplicativo
    public void sair()
    {
        Application.Quit();
    }
}
