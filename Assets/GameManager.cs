using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public TMP_Text textoColocacion;
    public int cont;
    public GameObject[] spawnedObjectArray;
    GameObject btnJugar;
    public GameObject arSession;
    public GameObject xrOrigin;
    bool instanciado = true;

    private void Awake()
    {
        
        



            if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ConfigureScene" && instanciado)
        {
            Destroy(GameObject.Find("Trackables"));
            GameObject ar = GameObject.Find("AR Session(Clone)");
            GameObject xr = GameObject.Find("XR Origin(Clone)");
            Destroy(ar);
            Destroy(xr);
            Instantiate(arSession);
            Instantiate(xrOrigin);
            instanciado = false;
        }


        if (SceneManager.GetActiveScene().name == "ConfigureScene")
        {
            
            textoColocacion = GameObject.Find("textoColocacion").GetComponent<TMP_Text>();
            spawnedObjectArray = GameObject.FindGameObjectsWithTag("Pociones");
            textoColocacion.text = cont.ToString();
        }
        
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            Time.timeScale = 1.0f;
            if (Input.GetMouseButtonDown(0))
            {
                EliminarPociones();
            }

           
        }

        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            instanciado = true;
            if (cont > 0)
            {
                btnJugar = GameObject.Find("btnJugar");
                btnJugar.GetComponent<Button>().interactable = true;
            }
            else
            {
                btnJugar = GameObject.Find("btnJugar");
                btnJugar.GetComponent<Button>().interactable = false;
            }
        }


    }


    public void CargarConfiguración()
    {
        SceneManager.LoadScene("ConfigureScene");
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GuardarConfiguración()
    {
        SceneManager.LoadScene("MenuScene");
       
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuScene");
        

    }

    public void ResetearObjetos()
    {
        cont = 0;
        foreach (GameObject a in spawnedObjectArray)
        {
            Destroy(a);
        }


    }




    public void SalirAplicacion()
    {
        Application.Quit();

    }


    public void EliminarPociones()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Comprueba si el rayo ha colisionado con un objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica si el objeto colisionado tiene un componente Collider
                if (hit.collider != null)
                {
                    // Elimina el objeto colisionado
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                    cont--;
                    GameObject.Find("Scrollbar").GetComponent<Scrollbar>().size += 0.5f;
                    
                }
            }
        }
    }


}
