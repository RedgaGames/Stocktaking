using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelScreenHandler : MonoBehaviour
{

    [SerializeField] private GameObject EndLevelScreen;
    [SerializeField] private GameObject DimedBackground;

    public void ShowEndLevelScreen()
    {
        EndLevelScreen.SetActive(true);
        DimedBackground.SetActive(true);
    }


}
