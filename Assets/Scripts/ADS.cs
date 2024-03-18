using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour
{
    void Start()
    {
        // M�todo Start() vazio, pois n�o � necess�rio inicializar nada aqui no momento
        if(Advertisement.isInitialized)
        {
            ExibirAnuncio();
        }

    }

    // M�todo para exibir o an�ncio
    public void ExibirAnuncio()
    {
        // Verifica se um an�ncio est� sendo exibido atualmente
        bool isShowing = Advertisement.isShowing;

        // Imprime no console se o an�ncio est� sendo exibido ou n�o
        Debug.Log("An�ncio est� sendo exibido: " + isShowing);
    }
}
