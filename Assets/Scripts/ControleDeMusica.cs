using UnityEngine;

public class ControleDeMusica : MonoBehaviour
{
    // Refer�ncia est�tica para garantir o padr�o Singleton
    private static ControleDeMusica instance;

    // Refer�ncia ao componente de �udio
    private AudioSource audioSource;

    // Flag para rastrear o estado da m�sica
    private bool musicaLigada = true;

    // Chave para armazenar o estado da m�sica nas PlayerPrefs
    private const string PlayerPrefsKey = "MusicaLigada";

    // M�todo para obter a inst�ncia do controle de m�sica
    public static ControleDeMusica Instance
    {
        get
        {
            if (instance == null)
            {
                // Procura a inst�ncia existente ou cria uma nova se n�o existir
                instance = FindObjectOfType<ControleDeMusica>();

                // Cria um objeto se n�o encontrou a inst�ncia
                if (instance == null)
                {
                    GameObject obj = new GameObject("ControleDeMusica");
                    instance = obj.AddComponent<ControleDeMusica>();
                }

                // Mant�m o objeto entre cenas
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    // Inicializa��o
    void Start()
    {
        // Obt�m o componente de �udio do objeto atual
        audioSource = GetComponent<AudioSource>();

        // Garante que o componente de �udio existe
        if (audioSource == null)
        {
            Debug.LogError("Componente de �udio n�o encontrado no objeto atual.");
        }
        else
        {
            // Carrega o estado da m�sica das PlayerPrefs ou usa o padr�o (ligado)
            musicaLigada = PlayerPrefs.GetInt(PlayerPrefsKey, 1) == 1;

            // Atualiza o estado do �udio conforme necess�rio
            audioSource.enabled = musicaLigada;

            // Exibe uma mensagem no console indicando o estado atual da m�sica
            if (musicaLigada)
            {
                Debug.Log("M�sica ligada.");
            }
            else
            {
                Debug.Log("M�sica desligada.");
            }
        }
    }

    // Fun��o para ligar ou desligar a m�sica
    public void ToggleMusic()
    {
        // Inverte o estado da m�sica (liga se estiver desligada, desliga se estiver ligada)
        musicaLigada = !musicaLigada;

        // Atualiza o estado do �udio
        audioSource.enabled = musicaLigada;

        // Salva o estado da m�sica nas PlayerPrefs
        PlayerPrefs.SetInt(PlayerPrefsKey, musicaLigada ? 1 : 0);

        // Exibe uma mensagem no console indicando o estado atual da m�sica
        if (musicaLigada)
        {
            Debug.Log("M�sica ligada.");
        }
        else
        {
            Debug.Log("M�sica desligada.");
        }
    }
}
