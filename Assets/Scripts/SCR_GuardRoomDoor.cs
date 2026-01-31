using Unity.VisualScripting;
using UnityEngine;

public class SCR_GuardRoomDoor : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    public GameObject guardDoor;
    public Vector3 moveTowards;
    public Vector3 moveMiddle;
    public Vector3 moveEnd;
    public Vector3 moveStart;
    public float moveSpeed = 0.3f;
    private bool interactable;
    private bool inRange;

    public AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
        moveTowards = guardDoor.transform.position;
        moveStart = guardDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.interactKey) && interactable && inRange)
        {
            sound.Play();
            interactable = false;
            interactText.SetActive(false);
            moveTowards = moveMiddle;
        }

        if (guardDoor.transform.position != moveTowards)
        {
            guardDoor.transform.position = Vector3.MoveTowards(guardDoor.transform.position, moveTowards, Vector3.Distance(moveStart, moveTowards) * moveSpeed * Time.deltaTime);
        }

        if (guardDoor.transform.position.z >= moveMiddle.z - 0.05f)
        {
            moveTowards = moveEnd;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable && player.lockOpened)
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
