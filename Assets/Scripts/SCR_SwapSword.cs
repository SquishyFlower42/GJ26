using UnityEngine;

public class SCR_SwapSword : MonoBehaviour
{

    public SCR_SwapSword holdSwordRight;
    public SCR_SwapSword holdSwordLeft;


    public GameObject swappedSword;

    public GameObject currentSword;
    public GameObject currentPos;

    public int swordNumber;

    public void MoveSwordRight()
    {

        swappedSword = holdSwordRight.currentSword;

        currentSword.transform.position = new Vector3(holdSwordRight.currentPos.transform.position.x, holdSwordRight.currentPos.transform.position.y,
            holdSwordRight.currentPos.transform.position.z);

        holdSwordRight.currentSword = currentSword;

        swappedSword.transform.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y,
            currentPos.transform.position.z);
        


        currentSword = swappedSword;

       
    }

    public void MoveSwordLeft()
    {

        swappedSword = holdSwordLeft.currentSword;

        currentSword.transform.position = new Vector3(holdSwordLeft.currentPos.transform.position.x, holdSwordLeft.currentPos.transform.position.y,
            holdSwordLeft.currentPos.transform.position.z);

        holdSwordLeft.currentSword = currentSword;

        swappedSword.transform.position = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y,
            currentPos.transform.position.z);



        currentSword = swappedSword;



    }




}
