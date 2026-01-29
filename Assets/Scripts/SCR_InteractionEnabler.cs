using System.Threading;
using UnityEngine;

public class SCR_InteractionEnabler : MonoBehaviour
{
    public SCR_PlayerMovement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            print("Du är framför lådan");


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Du gick ifrån :(");
        }
    }
}
