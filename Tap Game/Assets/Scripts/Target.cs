using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Velocidade dos objetos
    private float minSpeed = 14f;
    private float maxSpeed = 19f;
    private float maxTorque = 10f;

    // Local que o objeto será criado
    private float xRange = 5f;
    private float ySpawnPos = -6f;

    // Corpo do objeto
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
        rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomForce() 
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);

        // incrementa pontuação
        if (this.tag == "GoodTarget" && GameManager.timer > 0)
        {
            GameManager.score += 10;
            GameManager.timer += 10;
        }

        // decrementa tempo de jogo
        if (this.tag == "BadTarget" && GameManager.timer > 0)
        {
            GameManager.timer -= 10;
        }
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     Destroy(gameObject);
    // }
}
