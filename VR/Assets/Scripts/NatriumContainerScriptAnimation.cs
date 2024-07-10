using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatriumContainerScriptAnimation : MonoBehaviour
{
    public GameObject lid;
    [SerializeField] private Animator unscrewAnimationController;
    public GameObject container;
    public GameObject new_container;
    private bool play = false;
    private bool previous = true;
    private DateTime timpInitial;
    private bool active = false;
    private Vector3 coord;

    void Start()
    {
        new_container.SetActive(false);
    }

    void Update()
    {
        if (timpInitial != null)
        {
            if (active && (DateTime.Now - timpInitial).TotalSeconds >= 4)
            {
                coord = container.transform.position;
                container.SetActive(false);
                new_container.transform.position = coord;
                new_container.SetActive(true);
            }
        }
        if (lid.transform.hasChanged == false)
        {
            if (previous == true)
            {
                play = !play;
                previous = false;
            }
        }
        else
        {
            previous = true;
        }
        if (play)
        {
            unscrewAnimationController.SetTrigger("TrUnscrew");
            active = true;
            timpInitial = DateTime.Now;
        }
    }
}
