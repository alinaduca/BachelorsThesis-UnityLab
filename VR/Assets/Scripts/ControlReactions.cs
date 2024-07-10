using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlReactions : MonoBehaviour
{
    public GameObject waterRecipient1;
    public GameObject natriumRecipient;
    public GameObject newNatriumRecipient;
    public GameObject phenolphthaleinRecipient;
    public GameObject naohRecipient;
    
    public GameObject h2so4Recipient;
    public GameObject cuoRecipient;
    public GameObject cuso4Recipient;

    public GameObject hclRecipient;
    public GameObject nahco3Recipient;
    public GameObject naclRecipient;

    public GameObject waterRecipient2;
    public GameObject potassiumRecipient;
    public GameObject newPotassiumRecipient;
    public GameObject methylorangeRecipient;
    public GameObject kohRecipient;

    public GameObject waterRecipient3;
    public GameObject iodineRecipient;
    public GameObject aluminumRecipient;
    public GameObject pipette;
    public GameObject crystallizingDish;

    public GameObject waterRecipient4;
    public GameObject CaO_container;
    public GameObject CaOH_berzelius;
    public GameObject TurnesolPaper;

    public GameObject bunsenBurner1;
    public GameObject testTubeSuport1;
    public GameObject balloon;
    public GameObject testTube1;

    public GameObject bunsenBurner2;
    public GameObject testTubeSuport2;
    public GameObject testTube2;

    public AudioSource audioSource_guidance;
    public AudioClip clip_guidance_sodium;
    public AudioClip clip_guidance_potassium;
    public AudioClip clip_guidance_nacl;
    public AudioClip clip_guidance_CuSO4;
    public AudioClip clip_guidance_AlI3;
    public AudioClip clip_guidance_CaOH;
    public AudioClip clip_guidance_CaCO3;
    public AudioClip clip_guidance_FeSO4;

    public TMP_Text canvasText;
    public GameObject popupWindow;

    public GameObject experimentSheet1;
    public GameObject experimentSheet2;
    public GameObject experimentSheet3;
    public GameObject experimentSheet4;
    public GameObject experimentSheet5;
    public GameObject experimentSheet6;
    public GameObject experimentSheet7;
    public GameObject experimentSheet8;

    [SerializeField] FlipPages flipPages;
    public bool newReaction = false;

    void Start()
    {
        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);
    }

    void Update()
    {
        if (flipPages.selectedReaction != -1)
        {
            switch (flipPages.selectedReaction)
            {
                case 1: StartReaction1(); flipPages.selectedReaction = -1; break;
                case 2: StartReaction2(); flipPages.selectedReaction = -1; break;
                case 3: StartReaction3(); flipPages.selectedReaction = -1; break;
                case 4: StartReaction4(); flipPages.selectedReaction = -1; break;
                case 5: StartReaction5(); flipPages.selectedReaction = -1; break;
                case 6: StartReaction6(); flipPages.selectedReaction = -1; break;
                case 7: StartReaction7(); flipPages.selectedReaction = -1; break;
                case 8: StartReaction8(); flipPages.selectedReaction = -1; break;
            }
        }
    }

    public void StartReaction1()
    {
        newReaction = true;

        waterRecipient1.SetActive(true);
        natriumRecipient.SetActive(true);
        phenolphthaleinRecipient.SetActive(true);
        naohRecipient.SetActive(true);
        newNatriumRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        experimentSheet1.SetActive(true);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To create caustic soda, you can start by grabbing the Erlenmeyer beaker of water with the grep button, and then pour it over the Berzelius beaker.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_sodium);
    }

    public void StartReaction2()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(true);
        cuoRecipient.SetActive(true);
        cuso4Recipient.SetActive(true);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(true);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To create copper(II) sulfate (also known as blue vitriol), you can start by grabbing the Erlenmeyer beaker of sulfuric acid with the grep button, and then pour it over the Berzelius beaker.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_CuSO4);
    }

    public void StartReaction3()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(true);
        nahco3Recipient.SetActive(true);
        naclRecipient.SetActive(true);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(true);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To create sodium chloride (also known as table salt), you can start by grabbing the Erlenmeyer beaker of hydrochloric acid with the grep button, and then pour it over the Berzelius beaker.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_nacl);
    }

    public void StartReaction4()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(true);
        potassiumRecipient.SetActive(true);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(true);
        kohRecipient.SetActive(true);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(true);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To create potassium hydroxide, you can start by grabbing the Erlenmeyer beaker of water with the grep button, and then pour it over the Berzelius beaker.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_potassium);
    }

    public void StartReaction5()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(true);
        iodineRecipient.SetActive(true);
        aluminumRecipient.SetActive(true);
        pipette.SetActive(true);
        crystallizingDish.SetActive(true);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(true);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To create aluminum iodide, you can start by grabbing the Aluminum beaker with the grep button, and then pour it over the crystallizing dish.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_AlI3);
    }

    public void StartReaction6()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(true);
        CaO_container.SetActive(true);
        CaOH_berzelius.SetActive(true);
        TurnesolPaper.SetActive(true);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(true);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To create calcium hydroxide, you can start by grabbing the Erlenmeyer beaker of water with the grep button, and then pour it over the Berzelius beaker.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_CaOH);
    }

    public void StartReaction7()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(true);
        balloon.SetActive(true);
        testTube1.SetActive(true);
        testTubeSuport1.SetActive(true);

        bunsenBurner2.SetActive(false);
        testTube2.SetActive(false);
        testTubeSuport2.SetActive(false);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(true);
        experimentSheet8.SetActive(false);

        popupWindow.SetActive(true);
        canvasText.text = "To decompose the calcium carbonate into calcium oxide and carbon dioxide, you can start by attaching the balloon to the top of the test tube.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_CaCO3);
    }

    public void StartReaction8()
    {
        newReaction = true;

        waterRecipient1.SetActive(false);
        natriumRecipient.SetActive(false);
        newNatriumRecipient.SetActive(false);
        phenolphthaleinRecipient.SetActive(false);
        naohRecipient.SetActive(false);

        h2so4Recipient.SetActive(false);
        cuoRecipient.SetActive(false);
        cuso4Recipient.SetActive(false);

        hclRecipient.SetActive(false);
        nahco3Recipient.SetActive(false);
        naclRecipient.SetActive(false);

        waterRecipient2.SetActive(false);
        potassiumRecipient.SetActive(false);
        newPotassiumRecipient.SetActive(false);
        methylorangeRecipient.SetActive(false);
        kohRecipient.SetActive(false);

        waterRecipient3.SetActive(false);
        iodineRecipient.SetActive(false);
        aluminumRecipient.SetActive(false);
        pipette.SetActive(false);
        crystallizingDish.SetActive(false);

        waterRecipient4.SetActive(false);
        CaO_container.SetActive(false);
        CaOH_berzelius.SetActive(false);
        TurnesolPaper.SetActive(false);

        bunsenBurner1.SetActive(false);
        balloon.SetActive(false);
        testTube1.SetActive(false);
        testTubeSuport1.SetActive(false);

        bunsenBurner2.SetActive(true);
        testTube2.SetActive(true);
        testTubeSuport2.SetActive(true);

        experimentSheet1.SetActive(false);
        experimentSheet2.SetActive(false);
        experimentSheet3.SetActive(false);
        experimentSheet4.SetActive(false);
        experimentSheet5.SetActive(false);
        experimentSheet6.SetActive(false);
        experimentSheet7.SetActive(false);
        experimentSheet8.SetActive(true);

        popupWindow.SetActive(true);
        canvasText.text = "To decompose iron sulfate into iron oxide, sulfur dioxide, and sulfur trioxide, you can start by lighting the Bunsen burner by pressing the white button on the burner with the grep button.";
        audioSource_guidance.Stop();
        audioSource_guidance.PlayOneShot(clip_guidance_FeSO4);
    }
}
