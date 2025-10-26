using UnityEngine;
using UnityEngine.Serialization;

public class Pipes : MonoBehaviour
{
    public Transform superior;
    public Transform inferior;
    public float velocidade = 5f;
    public float abertura = 3f;

    private float bordaEsquerda;

    private void Start()
    {
        velocidade += .005f;
        
        Spawner.Instance.taxaSpawn = Mathf.Max(0.15f, Spawner.Instance.taxaSpawn - 0.05f);
        bordaEsquerda = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        superior.position += Vector3.up * abertura / 2;
        inferior.position += Vector3.down * abertura / 2;
    }

    private void Update()
    {
        transform.position += velocidade * Time.deltaTime * Vector3.left;
        
        if (transform.position.x < bordaEsquerda) {
            Destroy(gameObject);
        }
    }

}
