using UnityEngine;

public class SCR_LockPick : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    public GameObject lockPickIcon;
    public GameObject parent;
    private bool interactable;
    private bool inRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable && inRange)
        {
            player.cellLockpick = true;
            lockPickIcon.SetActive(true);
            Destroy(parent);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable && !player.day)
        {
            interactText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && interactable)
        {
            interactText.SetActive(false);
            inRange = false;
        }
    }
}
