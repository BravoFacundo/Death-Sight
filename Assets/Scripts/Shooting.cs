using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera mainCamera;
    public Animator Visor;
    public GameObject laserL;
    public GameObject laserR;
    public LineRenderer lineRendererL;
    public LineRenderer lineRendererR;
    public float hitForce = 10;
    public float rayRange = 50;

    public bool Infinitebattery = false;

    private float timer1 = 0.0f;
    private float timer2 = 0.0f;
    public float battery = 110f;
    private float rechargingRate = 0.1f;
    private float decreasingRate = 0f;
    private float decreasingRateAt110 = 0.1f;
    private float decreasingRateAt100 = 0.5f;
    public bool rayOn = false;
    public bool batteryLock = false;


    void Start()
    {
        mainCamera = Camera.main;
        
    }
 

    void Update()
    {
        //Bateria y propiedades
        if (battery > 100 && battery <= 110)      //Cuando el rayo esta a mas de 100% de carga
        {
            decreasingRate = decreasingRateAt110; //Hacer cada 0.5 segundos
        }
        else if (battery <= 100 && battery > 0)  //Cuando el rayo esta entre 0 y 100% de carga
        {
            decreasingRate = decreasingRateAt100; //Hacer cada 1 segundos
        }
        else if (battery == 0) batteryLock = true;

        if (batteryLock)
        {
            rayOn = false;
            if (battery == 100) batteryLock = false;
        }

        //Rayo prendido/apagado
        if (!rayOn)
        {
            //Carga del rayo
            timer2 += Time.deltaTime;
            if (timer2 >= rechargingRate && battery < 110)
            {
                timer2 = timer2 - rechargingRate;

                if (!Infinitebattery) battery++;
                //Debug.Log(battery);

            }
            //aca deberia haber un nerfeo a la carga de los ultimos 10 de bateria
            //Una vez llegado a 100, deben pasar unos segundos para que cuente hasta 110.
            //De esta manera no se apaga y se prende siempre al 95% de bateria para usar siempre el boost
            //La otra opcion es hacer otro rechargingRate y separar el 0-100 del 100-110 haciendo esos ultimos 10 puntos mas lentos.
            
            lineRendererL.enabled = false;
            lineRendererR.enabled = false;
        }
        else if (rayOn)
        {
            //Dibujar Rayo
            RaycastHit hit;
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            //Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.green);

            lineRendererL.enabled = true;
            lineRendererL.SetPosition(0, laserL.transform.position);
            lineRendererL.SetPosition(1, mainCamera.transform.forward * rayRange + laserL.transform.position);   //lineRendererL.SetPosition(1, hit.point);           
            lineRendererR.enabled = true;
            lineRendererR.SetPosition(0, laserR.transform.position);
            lineRendererR.SetPosition(1, mainCamera.transform.forward * rayRange + laserR.transform.position);


            //Descarga del rayo 
            timer1 += Time.deltaTime;
            if (timer1 >= decreasingRate && battery > 0) //Activar el burst SOLO si se esta en 110, y no en 109. (o no?)
            {
                timer1 = timer1 - decreasingRate;

                if (!Infinitebattery) battery--;
                //Debug.Log(battery);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(ray.direction * hitForce);
                    }
                }
            }

        }
    }

    public void TurnOnLasers()
    {
        StartCoroutine("TurnOnRay");

    }
    public void TurnOffLasers()
    {
        StartCoroutine("TurnOffRay");
    }

    //Ayuda: Los lentes siempre mantienen la rotacion en X e Y de la camara.
    //Excepto cuando se mira abajo y se triggerea que vuelva a -90 de Y (Ahi solo comparte la X).

    //Animacion: al tocar el trigger los lentes siguen subiendo hasta que llegan al angulo deseado
    //angulo deseado: -150 o -155 se ve arriba un poquito || -160 se sale de la camara
    //si se puede: Detectar la velocidad a la que rotan los lentes y mantenerla hasta que llegue al angulo deseado
    public IEnumerator TurnOnRay()
    {
        //Al tocar el trigger de arriba los lentes suben y se fijan en el angulo deseado
        Visor.SetBool("turnOn", true);

        yield return new WaitForSeconds(0.25f);
        rayOn = true;
        StopCoroutine("turnOnRay");

    }
    public IEnumerator TurnOffRay()
    {
        //Al tocar el trigger de abajo los lentes bajan y se fijan en el angulo deseado
        Visor.SetBool("turnOn", false);

        yield return new WaitForSeconds(0.25f);
        rayOn = false;
        StopCoroutine("turnOffRay");
    }

}
