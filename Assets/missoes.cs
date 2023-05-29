using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.AI;

public class missoes : MonoBehaviour
{
    public TMP_Text missaoumtexto;

    public int hotcatpegados = 0;
    public int maxHot = 5;

    public GameObject[] toggleVisib;
    public GameObject[] toggleVisib2;
    public CinemachineVirtualCamera vcam;
    public Transform camPos;
    public Transform busao;
    public bool moveBus;
    public NavMeshAgent nonato;

    public void PegarHotcat()
    {
        hotcatpegados += 1;
        missaoumtexto.text = $"pegue os hotcats escondidos ({hotcatpegados}/{maxHot})";
        nonato.speed += 0.15f;

        if (hotcatpegados >= maxHot)
        {
            liberarSaida();
        }
    }

    public void liberarSaida()
    {
        missaoumtexto.text = $"O resgate chegou!! vá para saída principal para escapar";
        missaoumtexto.color = Color.green;

        foreach (GameObject obj in toggleVisib)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FimDeJogoCollider")
        {


            foreach (GameObject obj in toggleVisib2)
            {
                obj.SetActive(!obj.activeSelf);
            }

            moveBus = true;

        }
    }

    void FixedUpdate()
    {
        if (moveBus) busao.position += busao.forward * Time.deltaTime * 5;
    }
}

