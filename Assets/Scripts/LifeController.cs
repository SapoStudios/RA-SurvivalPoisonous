using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ganado;
    public GameObject perdido;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Scrollbar>().size -= 0.1f * Time.deltaTime;

        if (GetComponent<Scrollbar>().size == 0 )
        {
            
            
            Time.timeScale = 0.0f;
            perdido.SetActive(true);
            GameManager.instance.cont = 0;
            //Has Perdido
        }

        if (GetComponent<Scrollbar>().size > 0 && GameManager.instance.cont == 0)
        {
            
            
            Time.timeScale = 0.0f;
            ganado.SetActive(true);
            GameManager.instance.cont = 0;
            //Enhorabuena has Ganado
        }
    }
}
