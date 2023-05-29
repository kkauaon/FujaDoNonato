using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    [System.Serializable]
    public class Andar {
        public GameObject porta;
        public Vector3 posAberta;
        public Vector3 posFechada;
    }

    public Andar[] andares;
    public int andarAtual = 0;
    public GameObject porta;
    public GameObject jogador;
    public Vector3 escalaFechada;
    public Vector3 escalaAberta;
    public Vector3 posFechada;
    public Vector3 posAberta;
    public bool portaAberta = false;

    private void Start()
    {
        jogador = GameObject.Find("Jogador");
        StartCoroutine(AbrirPorta());
    }

    IEnumerator Subir()
    {
        yield return new WaitForSeconds(5.0f);

        andarAtual += 1;

        //jogador.transform.SetParent(transform, true);

        Andar andar = andares[andarAtual];
        GameObject porta2 = andar.porta;
        float totalMovementTime = 5f;
        float currentMovementTime = 0f;
        Vector3 target = new Vector3(transform.localPosition.x, porta2.transform.localPosition.y, transform.localPosition.z);
        Vector3 init = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

        while (transform.localPosition != target)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(init, target, currentMovementTime / totalMovementTime);
            yield return null;
        }

        //jogador.transform.SetParent(null, true);
        StartCoroutine(AbrirPorta());
    }

    IEnumerator AbrirPorta()
    {
        if (!portaAberta) {
            float totalMovementTime = 5f;
            float currentMovementTime = 0f;
            portaAberta = true;
            GameObject porta2 = andares[andarAtual].porta;
            Andar andar = andares[andarAtual];
            while (porta.transform.localScale != escalaAberta && porta2.transform.localScale != escalaAberta) {
                currentMovementTime += Time.deltaTime;
                porta.transform.localScale = Vector3.Lerp (escalaFechada, escalaAberta, currentMovementTime / totalMovementTime);
                porta2.transform.localScale = Vector3.Lerp (escalaFechada, escalaAberta, currentMovementTime / totalMovementTime);
                porta.transform.localPosition = Vector3.Lerp (posFechada, posAberta, currentMovementTime / totalMovementTime);
                porta2.transform.localPosition = Vector3.Lerp (andar.posFechada, andar.posAberta, currentMovementTime / totalMovementTime);
                yield return null;
            }

            yield return new WaitForSeconds(5.0f);
            StartCoroutine(AbrirPorta());            
        } else {
            float totalMovementTime = 5f;
            float currentMovementTime = 0f;
            portaAberta = false;
            GameObject porta2 = andares[andarAtual].porta;
            Andar andar = andares[andarAtual];
            while (porta.transform.localScale != escalaFechada && porta2.transform.localScale != escalaFechada) {
                currentMovementTime += Time.deltaTime;
                porta.transform.localScale = Vector3.Lerp (escalaAberta, escalaFechada, currentMovementTime / totalMovementTime);
                porta2.transform.localScale = Vector3.Lerp (escalaAberta, escalaFechada, currentMovementTime / totalMovementTime);
                porta.transform.localPosition = Vector3.Lerp (posAberta, posFechada, currentMovementTime / totalMovementTime);
                porta2.transform.localPosition = Vector3.Lerp (andar.posAberta, andar.posFechada, currentMovementTime / totalMovementTime);
                yield return null;
            } 

            StartCoroutine(Subir());
        }

    }


}
