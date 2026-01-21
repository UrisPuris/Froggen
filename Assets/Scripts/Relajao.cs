using UnityEngine;

public class Relajao : MonoBehaviour
{
    public GameObject Rana1;

    public GameObject Finalismio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rana")
        {

            Finalismio.GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(Rana1, transform.position, transform.rotation);

        }
    }
   }
