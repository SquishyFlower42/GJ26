using UnityEngine;
using UnityEngine.SceneManagement;
public class SCR_MainMenu : MonoBehaviour
{


    public void BeginGame()
    {

        SceneManager.LoadScene(1);


    }

    public void ViewCredits()
    {

        SceneManager.LoadScene(2);
    }

    public void BacktoMenu()
    {

        SceneManager.LoadScene(0);

    }


    public void CloseGame()
    {
        Debug.Log("Quit Epicstyle");
        Application.Quit();

    }


}
