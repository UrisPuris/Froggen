using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Frog : MonoBehaviour
{
    public float speed;
    public float  up;
    public bool jugadorA;
    private float tronquicalma;
    public GameObject Cuadrao;
    public GameObject Rana;
    public TMP_Text Numero;
    int Vidas = 5;
    int counterrana = 0;
    private int bate = 0;
   public bool tronqui => bate > 0;
    public Animator rana;
    void Start()
    {
        rana = GetComponent<Animator>();
    }


 
    private void Respawn()
    {
        transform.SetParent(null);
        bate = 0;
        tronquicalma = 0;
        transform.position = Cuadrao.transform.position;
        Vidas--;
        Numero.text = Vidas.ToString();
    }

    public void AddPoints()
    {
        counterrana++;
 }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Final")
        {
            
            AddPoints();
           
            transform.position = Cuadrao.transform.position;
            Debug.Log("Entro");
           
        }
        if (collision.gameObject.tag == "Coche")
        {
            Respawn();
            Debug.Log("melto");
        
            return;
        }

        if (collision.gameObject.tag == "Tronco")
        {

            bate++;
            if (collision.GetComponent<Rigidbody2D>())
            {
                tronquicalma = collision.GetComponent<Tronco>().speed;
            }

        }
 



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mar" && tronqui == false)
        {

            Respawn();
            Debug.Log("acua");
        



        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tronco")
        {
            bate--;
            if (bate <= 0)
            {
                bate = 0;
                tronquicalma = 0;
            }
        }
    }

   
    void Update()
    {
        if(counterrana == 5)
        {
            SceneManager.LoadScene("Victory");

        }
        if (Vidas == 0)
        {
            SceneManager.LoadScene("Game Over");

        }

        if (tronqui == true)
        {
            transform.Translate(new Vector3(tronquicalma, 0, 0) * Time.deltaTime);
        }
    

        if (jugadorA)
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Translate(new Vector3(0, up , 0), Space.World);
                rana.Play("Alante");

            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(speed, 0, 0)  * Time.deltaTime, Space.World);
                rana.Play("Derecha");

            }
            if (Input.GetKeyDown(KeyCode.S))

            {
                transform.Translate(new Vector3(0, -up, 0), Space.World);
                rana.Play("Detras");

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-speed, 0, 0)  * Time.deltaTime, Space.World);
                rana.Play("Izquierda");

            }

        }
     


    
    }
}
