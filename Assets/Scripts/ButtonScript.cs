using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnGuardarConfig()
    {
        GameManager.instance.GuardarConfiguración();
    }
    public void btnJugar()
    {
        GameManager.instance.CargarJuego();
    }

    public void btnCrearConfig()
    {
        GameManager.instance.CargarConfiguración();
    }

    public void btnVolverMenu()
    {
        GameManager.instance.VolverMenu();
    }

    public void btnResetear()
    {
        GameManager.instance.ResetearObjetos();
    }



    public void btnSaliAplicacion()
    {
        GameManager.instance.SalirAplicacion();
    }



}
