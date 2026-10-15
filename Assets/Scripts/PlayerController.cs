using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento por suelo")]
    public float velMovimiento = 20f;
    public float accel = 40f;

    [Header("Saltos")]
    public float fuerzaSalto = 10f;
    public float alturaMin = 1.1f;
    public LayerMask groundLayer;

    [Header("Menú de pausa")]
    public GameObject PauseCanvas;
    public bool enPausa = false;

    [Header("Físicas jugador")]
    private Rigidbody rb;
    private bool tocaSuelo;
    private bool quieroSaltar;
    private Vector2 Direccion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        PauseCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        ComprobarSiEnSuelo();
        MoverJugador();
        if (quieroSaltar)
        {
            Saltar();
            quieroSaltar = false;
        }
    }

    public void OnMove(InputValue valor)
    {
        Direccion = valor.Get<Vector2>();
    }

    public void OnJump(InputValue valor2)
    {
        Debug.Log("Tecla de salto pulsada. ¿Toca suelo? " + tocaSuelo);
        if (valor2.isPressed && tocaSuelo)
        {
            quieroSaltar = true;
        }
    }

    public void OnPause(InputValue valor3)
    {
        if(valor3.isPressed)
        {
            HabilitarPausa();
        }
    }
    public void MoverJugador()
    {
        Vector3 targetVelocity = new Vector3(Direccion.x, 0f, Direccion.y) * velMovimiento;
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 velocityChange = (targetVelocity - new Vector3(currentVelocity.x, 0f, currentVelocity.z));

        rb.AddForce(velocityChange * accel, ForceMode.Acceleration);
    }

    public void Saltar()
    {
        ComprobarSiEnSuelo();
        if (tocaSuelo)
        {
                
            Vector3 vel = rb.linearVelocity;
            rb.linearVelocity = new Vector3(vel.x, 0f, vel.z);

            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            tocaSuelo = false;           
        }
    }
    void HabilitarPausa()
    {
        enPausa = !enPausa;
        if (enPausa == true)
        {
            Time.timeScale = 0f;
            PauseCanvas.SetActive(true);
        }
        else if (enPausa == false)
        {
            Time.timeScale = 1f;
            PauseCanvas.SetActive(false);
        }
    }

    void ComprobarSiEnSuelo()
    {
        tocaSuelo = Physics.Raycast(transform.position, Vector3.down, alturaMin, groundLayer);
    }

}
