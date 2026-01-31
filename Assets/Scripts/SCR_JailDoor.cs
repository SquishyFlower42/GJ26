using Unity.VisualScripting;
using UnityEngine;

public class SCR_JailDoor : MonoBehaviour
{
    public GameObject interactText;
    public SCR_PlayerMovement player;
    public GameObject jailDoor;
    private bool interactable;
    private bool inRange;
    public Vector3 moveTowards;
    public Vector3 moveMiddle;
    public Vector3 moveEnd;
    public Vector3 moveStart;
    public float moveSpeed = 0.7f;

    public AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
        moveTowards = jailDoor.transform.position;
        moveStart = jailDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Input.GetKeyDown(player.interactKey) && interactable && inRange && player.cellLockpick)
        {
            sound.Play();
            interactable = false;
            interactText.SetActive(false);
            moveTowards = moveMiddle;
        }

        if (jailDoor != null && jailDoor.transform.position != moveTowards)
        {
            jailDoor.transform.position = Vector3.MoveTowards(jailDoor.transform.position, moveTowards, Vector3.Distance(moveStart, moveTowards) * moveSpeed * Time.deltaTime);
        }

        if (jailDoor.transform.position.z >= moveMiddle.z - 0.05f)
        {
            moveTowards = moveEnd;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && interactable && player.cellLockpick)
        {
            interactText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && interactable && player.cellLockpick)
        {
            interactText.SetActive(false);
            inRange = false;
        }
    }
}
