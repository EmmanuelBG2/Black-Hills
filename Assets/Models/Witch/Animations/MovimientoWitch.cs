using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoWitch : MonoBehaviour
{
    [SerializeField]
    float velMov;

    [SerializeField]
    float velRot;

    public Transform target;

    public AudioSource audioSusto;

    private int tiempoReaccion, movimiento;

    public float rangoAlerta = 20F;
    public float rangoAttack = 15F;
    public float velocidad = 25F;

    public LayerMask capaDelJugador;

    bool espera, camina, gira;

    bool estarAlerta;
    bool hacerScream;
    bool audioPlayed = false;


    private Rigidbody rb;

    void Awake()
    {
        target = GameObject.Find("Player")?.transform;

        if (target == null)
        {
            Debug.LogWarning("El objeto Player no se encontró en la escena. Asegúrate de que el objeto exista y tenga el componente Transform.");
        }

        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }


    void Update()
    {

        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaDelJugador);

        hacerScream = Physics.CheckSphere(transform.position, rangoAttack, capaDelJugador);

        if (espera)
        {
            GetComponent<Animator>().SetBool("Active", false);
            GetComponent<Animator>().SetBool("_isRunning", false);
        }
        if (estarAlerta)
        {

            Vector3 posJugador = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(posJugador);

            GetComponent<Animator>().SetBool("Active", true);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velMov * Time.deltaTime);

            if (hacerScream)
            {
                GetComponent<Animator>().SetBool("_isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);

                if (!audioPlayed)
                {
                    AudioSource audioSource1 = Instantiate(audioSusto, transform.position, Quaternion.identity);
                    audioSource1.Play();

                    audioPlayed = true;
                    Destroy(audioSource1.gameObject, 4F);
                }
            }

            if (gira)
            {
                transform.Rotate(Vector3.up * velRot * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAttack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
