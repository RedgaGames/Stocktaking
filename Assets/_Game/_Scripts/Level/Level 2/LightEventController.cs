using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventController : MonoBehaviour
{
    DirectorLevel2 directorLevel2;

    private void Start() {
        directorLevel2 = FindObjectOfType<DirectorLevel2>();
    }

    public void StartLightEvent()
    {
        directorLevel2.SwapItems();
    }
}
