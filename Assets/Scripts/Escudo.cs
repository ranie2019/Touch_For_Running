using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private    Player       playerscript;
    private    Rigidbody2D  escudoRb;
    public     float        tempoEspera;
    public     int          AtritoMin, AtritoMax;
    private    Vector3      posicaoInicial;
    public     GameObject   escudoPrefab;


    void Start()
    {

        playerscript = FindObjectOfType(typeof(Player)) as Player;

        posicaoInicial = transform.position;
        escudoRb = GetComponent<Rigidbody2D>();
        escudoRb.isKinematic = true;

        int atrito = Random.Range(AtritoMin, AtritoMax);
        escudoRb.drag = atrito;

        StartCoroutine("soltar");
        
    }

    IEnumerator soltar()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, tempoEspera));
        escudoRb.isKinematic = false;
    }

    void OnCollisionEnter2D()
    {
        GameObject tempBala =  Instantiate(escudoPrefab, posicaoInicial, transform.rotation) as GameObject;
        tempBala.GetComponent<Rigidbody2D>().isKinematic = true;

        Destroy(this.gameObject);
    }

}
