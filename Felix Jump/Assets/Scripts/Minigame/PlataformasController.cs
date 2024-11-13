using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{

    [Header("GameObjects")]
    public GameObject metaFinal;
    public GameObject plataforma1Hole;
    public GameObject plataforma2Hole;
    public GameObject ballPrefab; // Add a reference to the ball prefab

    private GameObject plataformaToSpawn;

    [Header("Generador")]
    public int numeroPlataforma = 0;
    public float distanciaSpawn = 5f;
    public float startingY = 0;

    private float lastOrientationY = 0;

    [Header("Obstaculos")]

    //public GameObject pinchosGameObject;
    public GameObject leafSpawner;
    public GameObject redGameObject;
    public GameObject bolaNieveGameObject;

    public bool aparecerHojas;
    public bool aparecerRedes;
    public bool aparecerBolasNieve;
   
    // Start is called before the first frame update
    void Start()
    {
        
        //Plataformas
        for(int i = 0; i<numeroPlataforma; i++)
        {
            plataformaToSpawn = (Random.Range(0, 2) == 0) ? plataforma1Hole : plataforma2Hole;

            float rotationY = Random.Range(45, 315);
            while( Mathf.Abs(rotationY - lastOrientationY) < 45)
            {
                rotationY = Random.Range(45, 315);
            }
            lastOrientationY = rotationY;

            Instantiate(plataformaToSpawn, new Vector3(0, startingY + (distanciaSpawn * (i+1)), 0), Quaternion.Euler(0, rotationY, 0), CylinderController.instance.cylinder.transform);
        }

        if (aparecerHojas)
        {
            Instantiate(leafSpawner, new Vector3(0, startingY + (distanciaSpawn * (numeroPlataforma)), 0), Quaternion.identity, CylinderController.instance.cylinder.transform);
        }

        Instantiate(metaFinal, new Vector3(0, startingY + (distanciaSpawn * (numeroPlataforma + 1)), 0), Quaternion.identity, CylinderController.instance.cylinder.transform);

        


        //Pelota
        GameObject ball = Instantiate(ballPrefab, new Vector3(0, 0.4f, -0.7f), Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //contador += Time.deltaTime;
        //if (contador > 5)
        //{
        //    GameObject plataforma = Instantiate(plataforma1Hole, CylinderController.instance.cylinder.transform);
        //    plataformas.Add(plataforma.transform);
        //    contador = 0;
        //}


        //foreach(Transform plataforma in plataformas)
        //{
        //    plataforma.transform.position = new Vector3(0, plataforma.transform.position.y - (movementSpeed * Time.deltaTime), 0);
        //}
    }
}
