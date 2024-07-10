using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscrewPotassiumContainer : MonoBehaviour
{
    public GameObject lid;
    [SerializeField] private Animator unscrewAnimationController;
    private bool play = false;
    private bool previous = true;

    void Start()
    {
        //unscrewAnimationController.SetBool("Vial - Scintillation - 20 mL.001|Vial - Scintillation - 20 mL.001Action", false);
    }

    void Update()
    {
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
        }
        else
        {
            //waterLeak.Stop();
        }
    }
}
