using System.Collections;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    public Transform objeto, pontoA, pontoB;
    private Vector3 destino;
    public float velocidade;
    public float tempoEspera;
    private bool esperando;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa o destino como o ponto A
        destino = pontoA.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move o objeto em dire��o ao destino com uma velocidade espec�fica
        objeto.position = Vector3.MoveTowards(objeto.position, destino, velocidade * Time.deltaTime);

        // Verifica se o objeto atingiu o destino e n�o est� esperando
        if (objeto.position == destino && !esperando)
        {
            // Inicia a rotina para mover a plataforma
            StartCoroutine(MoverPlataforma());
        }
    }

    // Corotina para mover a plataforma
    IEnumerator MoverPlataforma()
    {
        // Define que est� esperando
        esperando = true;

        // Aguarda o tempo de espera
        yield return new WaitForSeconds(tempoEspera);

        // Verifica qual ponto � o destino atual e muda para o outro ponto
        if (destino == pontoA.position)
        {
            destino = pontoB.position;
        }
        else if (destino == pontoB.position)
        {
            destino = pontoA.position;
        }

        // Finaliza a espera
        esperando = false;
    }
}
