using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Vector3 posicionB;    
    public float velocidad = 2.0f; 

    private Vector3 posicionA;   

    void Start()
    {
        
        posicionA = transform.position;
    }

    void Update()
    {
        // Mathf.PingPong es una función que he encontrado que pendula entre valores: el primer valor es una variable que aumenta con el tiempo de 0 al segundo valor que pongas
        float t = Mathf.PingPong(Time.time * velocidad, 1.0f);

        // Mueve el objeto interpolando entre A y B según el valor de 't'
        transform.position = Vector3.Lerp(posicionA, posicionB, t);
    }
}

