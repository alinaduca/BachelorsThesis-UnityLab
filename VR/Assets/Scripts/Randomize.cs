using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    [SerializeField] CountdownTimer countdown;
    public GameObject randomizer;
    public int currentReactionInTestPhase;
    public bool generateNewReaction;
    public TMP_Text canvasText;
    public GameObject canvasForReactionTask;
    public GameObject canvasForTheoreticalTask;

    GameObject container_CuO;
    GameObject correct_erlenmeyer_with_substance;
    GameObject erlenmeyer_hcl;
    GameObject berzelius_hcl_nahco3;
    GameObject correct_berzelius_with_substance;
    GameObject container_nahco3;
    GameObject NatriumContainer;
    GameObject container_fenolftaleina_full;
    GameObject correct_berzelius_with_substance_NaOH;
    GameObject correct_erlenmeyer_with_substance_H2O;
    public GameObject NewNatriumContainer;

    GameObject Water;
    GameObject Metiloranj;
    GameObject PotassiumContainer;
    public GameObject NewPotassiumContainer;
    GameObject KOHContainer;

    GameObject TubeWithSubstance;
    GameObject pipette;
    GameObject small_vase_new;
    GameObject SuportEprubeta1;
    GameObject TurnesolPaper;
    GameObject waterBeaker;
    GameObject BunsenBurner;
    GameObject water_ali3;
    GameObject container_aluminum;
    GameObject CaOH_beaker22;
    GameObject BunsenBurner1;
    GameObject containerCaO;
    GameObject container_iodine;
    GameObject TubeWithSubstance1;
    GameObject SuportEprubeta;
    GameObject Balon;

    List<int> reactionsDone;
    public bool stopTesting;
    private int totalReactionsNumber;

    void Start()
    {
        //StaticData.includedTasksValue = 1;
        //StaticData.includedTasksValue = 2;
        FindAllObjects();
        generateNewReaction = true;
        //currentReactionInTestPhase = 5;
        stopTesting = false;
        reactionsDone = new List<int>();
        //Debug.Log(StaticData.includedTasksValue);
    }

    void HideAllObjects()
    {
        List<GameObject> objectsToHide = new List<GameObject> {
            container_CuO,
            correct_erlenmeyer_with_substance,
            erlenmeyer_hcl,
            berzelius_hcl_nahco3,
            correct_berzelius_with_substance,
            container_nahco3,
            NatriumContainer,
            container_fenolftaleina_full,
            correct_berzelius_with_substance_NaOH,
            correct_erlenmeyer_with_substance_H2O,
            Water,
            Metiloranj,
            PotassiumContainer,
            NewPotassiumContainer,
            KOHContainer,
            NewNatriumContainer,
            canvasForReactionTask,
            canvasForTheoreticalTask,
            TubeWithSubstance,
            pipette,
            small_vase_new,
            SuportEprubeta1,
            TurnesolPaper,
            waterBeaker,
            BunsenBurner,
            water_ali3,
            container_aluminum,
            CaOH_beaker22,
            BunsenBurner1,
            containerCaO,
            container_iodine,
            TubeWithSubstance1,
            SuportEprubeta,
            Balon
        };

        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    void FindAllObjects()
    {
        container_CuO = GameObject.Find("container_CuO");
        correct_erlenmeyer_with_substance = GameObject.Find("correct_erlenmeyer-with-substance");
        erlenmeyer_hcl = GameObject.Find("erlenmeyer-hcl");
        berzelius_hcl_nahco3 = GameObject.Find("berzelius_hcl_nahco3");
        correct_berzelius_with_substance = GameObject.Find("correct_berzelius-with-substance");
        container_nahco3 = GameObject.Find("container_nahco3");
        NatriumContainer = GameObject.Find("NatriumContainer");
        container_fenolftaleina_full = GameObject.Find("container_fenolftaleina_full");
        correct_berzelius_with_substance_NaOH = GameObject.Find("correct_berzelius-with-substance_NaOH");
        correct_erlenmeyer_with_substance_H2O = GameObject.Find("correct_erlenmeyer-with-substance_H2O");
        Water = GameObject.Find("Water");
        Metiloranj = GameObject.Find("Metiloranj");
        PotassiumContainer = GameObject.Find("PotassiumContainer");
        KOHContainer = GameObject.Find("KOHContainer");

        TubeWithSubstance = GameObject.Find("TubeWithSubstance");
        pipette = GameObject.Find("pipette");
        small_vase_new = GameObject.Find("small_vase_new");
        SuportEprubeta1 = GameObject.Find("SuportEprubeta1");
        TurnesolPaper = GameObject.Find("TurnesolPaper");
        waterBeaker = GameObject.Find("waterBeaker");
        BunsenBurner = GameObject.Find("BunsenBurner");
        water_ali3 = GameObject.Find("water_ali3");
        container_aluminum = GameObject.Find("container_aluminum");
        CaOH_beaker22 = GameObject.Find("CaOH_beaker22");
        BunsenBurner1 = GameObject.Find("BunsenBurner1");
        containerCaO = GameObject.Find("containerCaO");
        container_iodine = GameObject.Find("container_iodine");
        TubeWithSubstance1 = GameObject.Find("TubeWithSubstance1");
        SuportEprubeta = GameObject.Find("SuportEprubeta");
        Balon = GameObject.Find("Balon");
    }

    void Update()
    {
        if (stopTesting)
        {
            canvasText.text = "You have finished all the tasks!";
        }
        else
        {
            if (generateNewReaction)
            {
                HideAllObjects();
                if (StaticData.includedTasksValue == 0)
                {
                    do
                    {
                        currentReactionInTestPhase = Random.Range(1, 9);
                    } while (reactionsDone.Contains(currentReactionInTestPhase));
                    totalReactionsNumber = 8;
                }
                else if (StaticData.includedTasksValue == 1)
                {
                    do
                    {
                        currentReactionInTestPhase = Random.Range(9, 19);
                    } while (reactionsDone.Contains(currentReactionInTestPhase));
                    totalReactionsNumber = 10;
                }
                else if (StaticData.includedTasksValue == 2)
                {
                    do
                    {
                        currentReactionInTestPhase = Random.Range(1, 19);
                    } while (reactionsDone.Contains(currentReactionInTestPhase));
                    totalReactionsNumber = 18;
                }
                reactionsDone.Add(currentReactionInTestPhase);
                if (reactionsDone.Count >= totalReactionsNumber || reactionsDone.Count >= 10) // || reactionsDone.Count >= 10)
                {
                    stopTesting = true;
                }
                Debug.Log($"Generated Random Number: {currentReactionInTestPhase}");
                if (currentReactionInTestPhase < 9)
                {
                    canvasForReactionTask.SetActive(true);
                }
                else
                {
                    canvasForTheoreticalTask.SetActive(true);
                }
                countdown.reset = true;
                if (currentReactionInTestPhase == 1) //Na + H2O + phenolphtalein
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        correct_berzelius_with_substance_NaOH,
                        correct_erlenmeyer_with_substance_H2O,
                        NatriumContainer,
                        container_fenolftaleina_full,
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 2) //hcl+nahco3
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        erlenmeyer_hcl,
                        berzelius_hcl_nahco3,
                        container_nahco3,
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 3) //CuO+h2so4
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        correct_berzelius_with_substance,
                        correct_erlenmeyer_with_substance,
                        container_CuO,
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 4) // KOH + H2O + methyl orange
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        KOHContainer,
                        Water,
                        PotassiumContainer,
                        Metiloranj,
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 5) // aluminiu
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        pipette,
                        small_vase_new,
                        water_ali3,
                        container_aluminum,
                        container_iodine
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 6) // cao+h2o
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        TurnesolPaper,
                        waterBeaker,
                        CaOH_beaker22,
                        containerCaO
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 7) // caco3
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        SuportEprubeta1,
                        BunsenBurner1,
                        TubeWithSubstance1,
                        Balon
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                else if (currentReactionInTestPhase == 8) // feso4
                {
                    List<GameObject> objectsToShow = new List<GameObject> {
                        TubeWithSubstance,
                        BunsenBurner,
                        SuportEprubeta
                    };

                    foreach (GameObject obj in objectsToShow)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(true);
                        }
                    }
                }
                generateNewReaction = false;
            }
        }
    }
}
