using UnityEngine;
using UnityEngine.Serialization;

public class CanoClasse : MonoBehaviour
{
    
    public Transform superior;
    public Transform inferior;
    public float velocidade = 5f;
    
    private float bordaEsquerda;

    private void Start()
    {
        Time.timeScale = Mathf.Min(1.75f, Time.timeScale + 0.005f);

        if (Spawner.Instance != null)
        {
            Spawner.Instance.taxaSpawn = Mathf.Max(0.25f, Spawner.Instance.taxaSpawn - 0.0025f);
        }
        
        bordaEsquerda = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        superior.position += Vector3.up * GameManager.Instance.abertura / 2;
        inferior.position += Vector3.down * GameManager.Instance.abertura / 2;
    }

    private void Update()
    {
        transform.position += velocidade * Time.deltaTime * Vector3.left;

        if (transform.position.x < -1) transform.position -= 0.025f * Vector3.up;
        
        if (transform.position.x < bordaEsquerda) {
            Destroy(gameObject);
        }
    }

}
