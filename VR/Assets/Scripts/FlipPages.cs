using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlipPages : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.6f;
    [SerializeField] public List<Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;
    public GameObject popupWindow;
    public TMP_Text canvasText;

    public GameObject bookCanvas;
    public GameObject titlu1;
    public GameObject titlu2;
    public GameObject titlu3;

    public GameObject page1reaction1text;
    public GameObject page1reaction1button;
    public GameObject page1reaction2text;
    public GameObject page1reaction2button;
    public GameObject page2reaction1text;
    public GameObject page2reaction1button;
    public GameObject page2reaction2text;
    public GameObject page2reaction2button;

    public GameObject page0reaction1text;
    public GameObject page0reaction1button;
    public GameObject page0reaction2text;
    public GameObject page0reaction2button;

    [SerializeField] public int selectedReaction = -1;

    private void Start()
    {
        InitialState();
    }

    public void InitialState()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].transform.rotation = Quaternion.identity;
        }
        titlu1.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        TextMeshProUGUI textMeshPro = titlu1.GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            textMeshPro.text = "Decomposition Reactions";
        }
        index = -1;
        pages[0].SetAsLastSibling();
        backButton.SetActive(false);
        forwardButton.SetActive(true);
        page1reaction1text.SetActive(false);
        page1reaction1button.SetActive(false);
        page1reaction2text.SetActive(false);
        page1reaction2button.SetActive(false);

        page0reaction1button.SetActive(true);
        page0reaction2button.SetActive(true);
        page0reaction1text.SetActive(true);
        page0reaction2text.SetActive(true);
    }

    public void closeTheBook()
    {
        InitialState();
        bookCanvas.SetActive(false);
        if (canvasText.text == "Now you can search through the book for the desired reaction by clicking on the Next and Previous buttons. When you have decided, click on the Play button.")
        {
            popupWindow.SetActive(false);
        }
    }

    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180;
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false);
        }
        if (index == 0)
        {
            titlu1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TextMeshProUGUI textMeshPro = titlu1.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Displacement Reactions";
            }
            page0reaction1button.SetActive(false);
            page0reaction2button.SetActive(false);
            page0reaction1text.SetActive(false);
            page0reaction2text.SetActive(false);

            page1reaction1text.SetActive(true);
            page1reaction1button.SetActive(true);
            page1reaction2text.SetActive(true);
            page1reaction2button.SetActive(true);

            forwardButton.SetActive(false);
        }
        else if (index == 1)
        {
            titlu2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TextMeshProUGUI textMeshPro = titlu2.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Redox Reactions";
            }
            page2reaction1button.SetActive(false);
            page2reaction1text.SetActive(false);
            page2reaction2button.SetActive(false);
            page2reaction2text.SetActive(false);
        }
        else if (index == 2)
        {
            titlu3.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TextMeshProUGUI textMeshPro = titlu3.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Precipitation Reactions";
            }
        }
    }

    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 0;
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false);
        }
        if (index == 0)
        {
            titlu1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TextMeshProUGUI textMeshPro = titlu1.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Decomposition Reactions";
            }
            page1reaction1text.SetActive(false);
            page1reaction1button.SetActive(false);
            page1reaction2text.SetActive(false);
            page1reaction2button.SetActive(false);

            page0reaction1button.SetActive(true);
            page0reaction2button.SetActive(true);
            page0reaction1text.SetActive(true);
            page0reaction2text.SetActive(true);
        }
        else if (index == 1)
        {
            titlu2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TextMeshProUGUI textMeshPro = titlu2.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Neutralization Reactions";
            }
            page2reaction1button.SetActive(true);
            page2reaction1text.SetActive(true);
            page2reaction2button.SetActive(true);
            page2reaction2text.SetActive(true);
        }
        else if (index == 2)
        {
            titlu3.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TextMeshProUGUI textMeshPro = titlu3.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "Combustion Reactions";
            }
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;

            }
            yield return null;
        }
    }

    public void Reaction1()
    {
        selectedReaction = 1;
        closeTheBook();
    }

    public void Reaction2()
    {
        selectedReaction = 2;
        closeTheBook();
    }

    public void Reaction3()
    {
        selectedReaction = 3;
        closeTheBook();
    }

    public void Reaction4()
    {
        selectedReaction = 4;
        closeTheBook();
    }

    public void Reaction5()
    {
        selectedReaction = 5;
        closeTheBook();
    }

    public void Reaction6()
    {
        selectedReaction = 6;
        closeTheBook();
    }

    public void Reaction7()
    {
        selectedReaction = 7;
        closeTheBook();
    }

    public void Reaction8()
    {
        selectedReaction = 8;
        closeTheBook();
    }
}
