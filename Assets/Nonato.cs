using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nonato : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject jogador;
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        jogador = GameObject.Find("Jogador");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(jogador.transform.position);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameover.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
