using UnityEngine;
using TMPro; // Adiciona esta linha para incluir o TextMeshPro
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text score, recorde; // Altera Text para TMP_Text

    void Start()
    {
        // Obt�m e exibe a pontua��o salva no PlayerPrefs
        score.text = PlayerPrefs.GetInt("score").ToString();

        // Obt�m e exibe o recorde salvo no PlayerPrefs
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    // Fun��o para carregar uma cena com o nome fornecido
    public void irPara(string nomecena)
    {
        SceneManager.LoadScene(nomecena);
    }

    // Fun��o para fechar o aplicativo
    public void sair()
    {
        Application.Quit();
    }
}
