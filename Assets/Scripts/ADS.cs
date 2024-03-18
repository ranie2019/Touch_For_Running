using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour
{
    void Start()
    {
        // Método Start() vazio, pois não é necessário inicializar nada aqui no momento
        if(Advertisement.isInitialized)
        {
            ExibirAnuncio();
        }

    }

    // Método para exibir o anúncio
    public void ExibirAnuncio()
    {
        // Verifica se um anúncio está sendo exibido atualmente
        bool isShowing = Advertisement.isShowing;

        // Imprime no console se o anúncio está sendo exibido ou não
        Debug.Log("Anúncio está sendo exibido: " + isShowing);
    }
}
