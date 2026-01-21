using UnityEngine;

public class Tronco : MonoBehaviour
{
    public float speed = 3f;
    public GameObject Cuadrao;
    public GameObject Rana;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Reset1")
        {
            transform.position = Cuadrao.transform.position;
           
        }
    }
 
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
       {
        
         }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
}
