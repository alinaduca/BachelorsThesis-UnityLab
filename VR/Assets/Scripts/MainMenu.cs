using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject settingsPanel;

    public GameObject practiceToggle;
    public GameObject theoryToggle;

    public bool activeMenu = true;
    
    void Start()
    {
        settingsPanel.SetActive(false);
        InitializeToggles();
    }

    public void OpenLabScene()
    {
        SceneManager.LoadScene("LabScene");
        Debug.Log("Opening LabScene");
    }

    public void OpenTestingPhaseLabScene()
    {
        SceneManager.LoadScene("TestingPhaseLab");
        Debug.Log("Opening TestingPhaseLab");
    }

    public void OpenLabAssistantScene()
    {
        SceneManager.LoadScene("LabAssistantScene");
        Debug.Log("Opening LabAssistantScene");
    }

    public void QuitApplication()
    {
        Debug.Log("Application Quitted!!!");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    void InitializeToggles()
    {
        if (StaticData.includedTasksValue == 0)
        {
            practiceToggle.GetComponent<Toggle>().isOn = true;
            theoryToggle.GetComponent<Toggle>().isOn = false;
            practiceToggle.GetComponent<Toggle>().interactable = false;
            theoryToggle.GetComponent<Toggle>().interactable = true;
        }
        else if (StaticData.includedTasksValue == 1)
        {
            practiceToggle.GetComponent<Toggle>().isOn = false;
            theoryToggle.GetComponent<Toggle>().isOn = true;
            theoryToggle.GetComponent<Toggle>().interactable = false;
            practiceToggle.GetComponent<Toggle>().interactable = true;
        }
        else if (StaticData.includedTasksValue == 2)
        {
            practiceToggle.GetComponent<Toggle>().isOn = true;
            theoryToggle.GetComponent<Toggle>().isOn = true;
            theoryToggle.GetComponent<Toggle>().interactable = true;
            practiceToggle.GetComponent<Toggle>().interactable = true;
        }

        practiceToggle.GetComponent<Toggle>().onValueChanged.AddListener(delegate { UpdateIncludedTaskTypes(); });
        theoryToggle.GetComponent<Toggle>().onValueChanged.AddListener(delegate { UpdateIncludedTaskTypes(); });
    }

    public void UpdateIncludedTaskTypes()
    {
        if (practiceToggle.GetComponent<Toggle>().isOn && theoryToggle.GetComponent<Toggle>().isOn)
        {
            StaticData.includedTasksValue = 2;
            practiceToggle.GetComponent<Toggle>().interactable = true;
            theoryToggle.GetComponent<Toggle>().interactable = true;
        }
        else if (practiceToggle.GetComponent<Toggle>().isOn)
        {
            StaticData.includedTasksValue = 0;
            practiceToggle.GetComponent<Toggle>().interactable = false;
        }
        else if (theoryToggle.GetComponent<Toggle>().isOn)
        {
            StaticData.includedTasksValue = 1;
            theoryToggle.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            StaticData.includedTasksValue = 0;
        }
        Debug.Log("Updated includedTaskTypes to: " + StaticData.includedTasksValue);
    }
}
