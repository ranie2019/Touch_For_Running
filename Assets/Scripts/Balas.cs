using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    private    Player       playerscript;
    private    Rigidbody2D  balaRb;
    public     float        tempoEspera;
    public     int          AtritoMin, AtritoMax;
    private    Vector3      posicaoInicial;
    public     GameObject   balaPrefab, explosaoPrefab;
    public     int          pontos;

    void Start()
    {

        playerscript = FindObjectOfType(typeof(Player)) as Player;

        posicaoInicial = transform.position;
        balaRb = GetComponent<Rigidbody2D>();
        balaRb.isKinematic = true;

        int atrito = Random.Range(AtritoMin, AtritoMax);
        balaRb.drag = atrito;

        StartCoroutine("soltar");
        
    }

    IEnumerator soltar()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, tempoEspera));
        balaRb.isKinematic = false;
    }

    void OnCollisionEnter2D()
    {
        GameObject tempBala =  Instantiate(balaPrefab, posicaoInicial, transform.rotation) as GameObject;
        tempBala.GetComponent<Rigidbody2D>().isKinematic = true;

        GameObject explosao = Instantiate(explosaoPrefab, transform.position, transform.rotation) as GameObject;
        Destroy(explosao, 0.3f);

        playerscript.score += pontos;

        Destroy(this.gameObject);
    }

}
