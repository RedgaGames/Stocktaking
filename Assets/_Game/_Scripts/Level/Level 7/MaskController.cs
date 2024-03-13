using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    [SerializeField] GameObject maskOnTable;
    [SerializeField] GameObject maskOnFace;

    public void PutMaskOn()
    {
        maskOnTable.SetActive(false);
        maskOnFace.SetActive(true);
    }
}
