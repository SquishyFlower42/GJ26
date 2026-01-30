using Unity.VisualScripting;
using UnityEngine;

public class SCR_GuardRoomDoor : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    public GameObject guardDoor;
    public Vector3 moveTowards;
    public Vector3 moveEnd;
    public float moveSpeed = 0.3f;
    private bool interactable;
    private bool inRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
        moveTowards = guardDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable && inRange)
        {
            interactable = false;
            interactText.SetActive(false);
            moveTowards = moveEnd;
        }

        if (guardDoor.transform.position != moveTowards)
        {
            guardDoor.transform.position = Vector3.MoveTowards(guardDoor.transform.position, moveTowards, Vector3.Distance(guardDoor.transform.position, moveTowards) * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable && player.guardroomKey)
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
