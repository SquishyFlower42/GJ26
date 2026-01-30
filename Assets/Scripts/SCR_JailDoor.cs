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
    public Vector3 moveEnd;
    public float moveSpeed = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = true;
        inRange = false;
        moveTowards = jailDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Input.GetKeyDown(player.interactKey) && interactable && inRange && player.cellLockpick)
        {
            interactable = false;
            interactText.SetActive(false);
            moveTowards = moveEnd;
        }

        if (jailDoor != null && jailDoor.transform.position != moveTowards)
        {
            jailDoor.transform.position = Vector3.MoveTowards(jailDoor.transform.position, moveTowards, Vector3.Distance(jailDoor.transform.position, moveTowards) * moveSpeed * Time.deltaTime);
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
