using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotcat : MonoBehaviour
{
    public float rotateVal = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f,rotateVal*Time.deltaTime,0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<missoes>().PegarHotcat();
            Destroy(gameObject);
        }
    }
}
