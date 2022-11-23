using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    //para ver variables privadas
    //0[SerializeField]private float duration;
    //para controlar vibracion de la camara
    //[SerializeField]private float magnitude;

    void Start() 
    {
        //llamar funcion
        //Shake();
        //llamar corrutina
        //StartCorroutine(Shake())
    }

    public IEnumerator CamaraShake(float duration, float magnitude)
    {
        //yield return 0;

        //Espera X segundos
        //yield return new WaitForSeconds(if);

        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        //dentro del parentesis poner a conidicion para que se ejecute el loop
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + originalPos.x, y + originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        /*for(float i = elapsed; i < duration; i += Time.deltaTime)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + originalPos.x, y + originalPos.y, transform.position.z);
            yield return 0;
        }*/

        //aunque no se cumpla la conidicion, el codigo lo ejecuta almenos una vez. El while solo, si la condicion no se ejecuta no funciona, pero con do while se ejectuda aunque la condicion no se cumpla
        /*do
        {
            Debug.Log("CamaraShake");
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + originalPos.x, y + originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;

        } while (elapsed < duration);*/

        /*GameObject[] vidas;

        foreach(GameObject vida in vidas)
        {
            vida.SetActive(false);
        }*/
    }
}
