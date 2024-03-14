using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{
    public List<GameObject> objectsToHide = new List<GameObject>();

    public void HideNotVisibleObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (IsObjectVisible(obj))
            {
                // Objekt anzeigen
                //obj.SetActive(true);
            }
            else
            {
                // Objekt ausblenden
                obj.SetActive(false);
            }
        }
    }

    public void ShowNotVisibleObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (IsObjectVisible(obj))
            {
                // Objekt anzeigen
                //obj.SetActive(false);
            }
            else
            {
                // Objekt ausblenden
                obj.SetActive(true);
            }
        }
    }

    // Methode, um zu überprüfen, ob ein Objekt von der Kamera erfasst wird
    private bool IsObjectVisible(GameObject obj)
    {
        if (obj == null)
        {
            return false;
        }

        // Überprüfe, ob das Objekt innerhalb des Sichtfelds der Kamera liegt
        //Vector3 screenPoint = Camera.main.WorldToViewportPoint(obj.transform.position);
        //bool isVisible = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(obj.transform.position);

        float buffer = 0f; // Hier kannst du den Bereich anpassen
    
        bool isVisible = screenPoint.z > 0 &&
                     screenPoint.x > -buffer && screenPoint.x < 1 + buffer &&
                     screenPoint.y > -buffer && screenPoint.y < 1 + buffer;

        return isVisible;
    }

    public void ActivateAllObjects()
    {
         foreach (GameObject obj in objectsToHide)
        {
             obj.SetActive(true);    
        }  
    }
}
