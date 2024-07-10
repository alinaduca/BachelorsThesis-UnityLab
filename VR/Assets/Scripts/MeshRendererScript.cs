using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererScript : MonoBehaviour
{
    public MeshRenderer gameObject1;
    public MeshRenderer gameObject2;
    public bool balonPesteEprubeta = false;

    private void Start()
    {
        Disable();
    }

    public void Enable()
    {
        gameObject1.enabled = true;
        gameObject2.enabled = true;
        balonPesteEprubeta = true;
    }

    public void Disable()
    {
        gameObject1.enabled = false;
        gameObject2.enabled = false;
        balonPesteEprubeta = false;
    }
}
