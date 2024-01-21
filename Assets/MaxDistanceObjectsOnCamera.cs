using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MaxDistanceObjectsOnCamera : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public float distanciaVisible; // Ajusta la distancia a la que el objeto se vuelve visible

    void Start()
    {
        if (arPlaneManager == null)
        {
            arPlaneManager = FindObjectOfType<ARPlaneManager>();
        }

        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += ActualizarVisibilidad;
        }
        else
        {
            Debug.LogError("No se encontr� el componente ARPlaneManager en la escena.");
        }

        // Inicialmente, oculta el objeto

        foreach(GameObject go in GameManager.instance.spawnedObjectArray)
        {
            go.SetActive(false);
        }


        
    }

    void ActualizarVisibilidad(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            // Mira si alg�n plano est� lo suficientemente cerca para activar el objeto
            if (Vector3.Distance(plane.transform.position, Camera.main.transform.position) < distanciaVisible)
            {
                // Activa el objeto cuando est�s lo suficientemente cerca
                foreach (GameObject go in GameManager.instance.spawnedObjectArray)
                {
                    go.SetActive(true);
                }
                break; // Puedes ajustar esta l�gica seg�n tus necesidades
            }
        }
    }
}
