using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento por suelo")]
    public float velMovimiento = 1f;
    public float accel = 11f;

    [Header("Saltos")]
    public float fuerzaSalto = 5f;
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
        rb.GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        PauseCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        MoverJugador();
        if(quieroSaltar)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            quieroSaltar = false;
        }

    }

    public void OnMove(InputValue valor)
    {
        Direccion = valor.Get<Vector2>();
    }

    public void OnJump(InputValue valor2)
    {
        if(valor2.isPressed && tocaSuelo)
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
}
