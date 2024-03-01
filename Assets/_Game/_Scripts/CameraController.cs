using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private Camera mainCamera;
    public float cameraRoatationSpeed = 90f;
    private bool isRotating = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DreheKamera(-90f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DreheKamera(90f);
        }
    }

    // Funktion zum Drehen der Kamera
    void DreheKamera(float winkel)
    {
        if (isRotating) { return; }

        StartCoroutine(DreheKameraCoroutine(winkel));
    }

    IEnumerator DreheKameraCoroutine(float zielWinkel)
    {
        isRotating = true;

        // Aktuelle Rotation der Kamera holen
        Quaternion aktuelleRotation = mainCamera.transform.rotation;

        // Zielrotation berechnen
        Quaternion zielRotation = Quaternion.Euler(aktuelleRotation.eulerAngles + new Vector3(0f, zielWinkel, 0f));

        float elapsedTime = 0f;
        float animationDuration = 1f; // 1 Sekunde

        while (elapsedTime < animationDuration)
        {
            // Rotation mithilfe von RotateTowards animieren
            mainCamera.transform.rotation = Quaternion.RotateTowards(aktuelleRotation, zielRotation, cameraRoatationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Stelle sicher, dass die Kamera genau auf dem Zielwinkel endet
        mainCamera.transform.rotation = zielRotation;

        isRotating = false;
    }
}
