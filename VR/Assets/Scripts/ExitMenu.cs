using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public GameObject bookCanvas;
    
    void Start()
    {
    }

    public void ReturnMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Opening MainMenuScene");
    }

    public void closeTheBook()
    {
        if (bookCanvas != null)
        {
            bookCanvas.SetActive(false);
        }
        else
        {
            Debug.Log("GameObject not found. Ensure the name is correct and the GameObject exists in the scene.");
        }
    }
}




//prima varianta
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;

//public class ExitMenu : MonoBehaviour
//{
//    public GameObject menu;
//    public bool activeMenu = true;

//    void Start()
//    {
//    }

//    public void ReturnMainMenuScene()
//    {
//        SceneManager.LoadScene("MainMenuScene");
//        Debug.Log("Opening MainMenuScene");
//    }
//}
