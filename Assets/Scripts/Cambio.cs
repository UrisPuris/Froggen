using UnityEngine;
using UnityEngine.SceneManagement;
public class Cambio : MonoBehaviour
{


    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }


    public void Menu()
    {
        Application.Quit();
    }

 

}
