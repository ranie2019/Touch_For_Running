using UnityEngine;

public class ControleDeMusica : MonoBehaviour
{
    // Referência estática para garantir o padrão Singleton
    private static ControleDeMusica instance;

    // Referência ao componente de áudio
    private AudioSource audioSource;

    // Flag para rastrear o estado da música
    private bool musicaLigada = true;

    // Chave para armazenar o estado da música nas PlayerPrefs
    private const string PlayerPrefsKey = "MusicaLigada";

    // Método para obter a instância do controle de música
    public static ControleDeMusica Instance
    {
        get
        {
            if (instance == null)
            {
                // Procura a instância existente ou cria uma nova se não existir
                instance = FindObjectOfType<ControleDeMusica>();

                // Cria um objeto se não encontrou a instância
                if (instance == null)
                {
                    GameObject obj = new GameObject("ControleDeMusica");
                    instance = obj.AddComponent<ControleDeMusica>();
                }

                // Mantém o objeto entre cenas
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    // Inicialização
    void Start()
    {
        // Obtém o componente de áudio do objeto atual
        audioSource = GetComponent<AudioSource>();

        // Garante que o componente de áudio existe
        if (audioSource == null)
        {
            Debug.LogError("Componente de áudio não encontrado no objeto atual.");
        }
        else
        {
            // Carrega o estado da música das PlayerPrefs ou usa o padrão (ligado)
            musicaLigada = PlayerPrefs.GetInt(PlayerPrefsKey, 1) == 1;

            // Atualiza o estado do áudio conforme necessário
            audioSource.enabled = musicaLigada;

            // Exibe uma mensagem no console indicando o estado atual da música
            if (musicaLigada)
            {
                Debug.Log("Música ligada.");
            }
            else
            {
                Debug.Log("Música desligada.");
            }
        }
    }

    // Função para ligar ou desligar a música
    public void ToggleMusic()
    {
        // Inverte o estado da música (liga se estiver desligada, desliga se estiver ligada)
        musicaLigada = !musicaLigada;

        // Atualiza o estado do áudio
        audioSource.enabled = musicaLigada;

        // Salva o estado da música nas PlayerPrefs
        PlayerPrefs.SetInt(PlayerPrefsKey, musicaLigada ? 1 : 0);

        // Exibe uma mensagem no console indicando o estado atual da música
        if (musicaLigada)
        {
            Debug.Log("Música ligada.");
        }
        else
        {
            Debug.Log("Música desligada.");
        }
    }
}
