using UnityEngine;

public class SCR_InteractBase : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    private bool interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable)
        {
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && interactable)
        {
            interactText.SetActive(false);
        }
    }
}
