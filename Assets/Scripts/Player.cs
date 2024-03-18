using UnityEngine;
using TMPro; // Adiciona a refer�ncia ao TextMeshPro
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float speed;
    public TMP_Text scoreTxt; // Substitui o tipo de Text para TextMeshPro
    public int score;
    public GameObject campoEnergiaPrefab;

    // M�todo chamado quando o objeto � inicializado
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // M�todo chamado a cada frame
    void Update()
    {
        // Atualiza o texto da pontua��o
        scoreTxt.text = score.ToString();

        // Verifica se o bot�o do mouse foi pressionado e inverte a dire��o do jogador
        if (Input.GetMouseButtonDown(0))
        {
            Flip();
        }

        // Move o jogador na dire��o definida pela vari�vel 'speed'
        playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
    }

    // M�todo para inverter a dire��o do jogador
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;
    }

    // M�todo chamado quando ocorre uma colis�o
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com inimigo e chama o m�todo GameOver
        if (collision.gameObject.tag == "Inimigo")
        {
            GameOver();
        }

        // Verifica se colidiu com o escudo e cria um campo de energia tempor�rio
        if (collision.gameObject.tag == "Escudo")
        {
            GameObject campoEnergia = Instantiate(campoEnergiaPrefab, transform) as GameObject;
            Destroy(campoEnergia, 3);
        }
    }

    // M�todo chamado quando ocorre um trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se entrou em contato com um inimigo e chama o m�todo GameOver
        if (collision.gameObject.tag == "Inimigo")
        {
            GameOver();
        }
    }

    // M�todo para encerrar o jogo
    void GameOver()
    {
        // Salva a pontua��o atual
        PlayerPrefs.SetInt("score", score);

        // Atualiza o recorde, se necess�rio
        if (score > PlayerPrefs.GetInt("recorde"))
        {
            PlayerPrefs.SetInt("recorde", score);
        }

        // Carrega a cena de Game Over
        SceneManager.LoadScene("GameOver");
    }
}
