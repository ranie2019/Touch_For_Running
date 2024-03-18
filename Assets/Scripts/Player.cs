using UnityEngine;
using TMPro; // Adiciona a referência ao TextMeshPro
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float speed;
    public TMP_Text scoreTxt; // Substitui o tipo de Text para TextMeshPro
    public int score;
    public GameObject campoEnergiaPrefab;

    // Método chamado quando o objeto é inicializado
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Método chamado a cada frame
    void Update()
    {
        // Atualiza o texto da pontuação
        scoreTxt.text = score.ToString();

        // Verifica se o botão do mouse foi pressionado e inverte a direção do jogador
        if (Input.GetMouseButtonDown(0))
        {
            Flip();
        }

        // Move o jogador na direção definida pela variável 'speed'
        playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
    }

    // Método para inverter a direção do jogador
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;
    }

    // Método chamado quando ocorre uma colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com inimigo e chama o método GameOver
        if (collision.gameObject.tag == "Inimigo")
        {
            GameOver();
        }

        // Verifica se colidiu com o escudo e cria um campo de energia temporário
        if (collision.gameObject.tag == "Escudo")
        {
            GameObject campoEnergia = Instantiate(campoEnergiaPrefab, transform) as GameObject;
            Destroy(campoEnergia, 3);
        }
    }

    // Método chamado quando ocorre um trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se entrou em contato com um inimigo e chama o método GameOver
        if (collision.gameObject.tag == "Inimigo")
        {
            GameOver();
        }
    }

    // Método para encerrar o jogo
    void GameOver()
    {
        // Salva a pontuação atual
        PlayerPrefs.SetInt("score", score);

        // Atualiza o recorde, se necessário
        if (score > PlayerPrefs.GetInt("recorde"))
        {
            PlayerPrefs.SetInt("recorde", score);
        }

        // Carrega a cena de Game Over
        SceneManager.LoadScene("GameOver");
    }
}
