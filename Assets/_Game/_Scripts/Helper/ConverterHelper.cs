using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterHelper : MonoBehaviour
{

    // DOTWEEN only works with Vector3 - This is why i have to convert Quaternion to Vector3
    public Vector3 AddAndConvertQuaternionToVector3(Quaternion currentRotation, Vector3 rotationAngleToAdd)
    {
        Quaternion targetRotation = Quaternion.Euler(currentRotation.eulerAngles + rotationAngleToAdd);
        Vector3 eulerRotation = targetRotation.eulerAngles;

        return eulerRotation;
    }



}
