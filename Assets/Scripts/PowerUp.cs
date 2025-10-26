using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public static PowerUp Instance;
    public Sprite[] spriteFrames;
    public int indiceAleatorio;

    void Start()
    {
        if (Instance == null && Random.value < 0.5f)
        {
            Instance = this;

            indiceAleatorio = Random.Range(0, spriteFrames.Length);

            if ((indiceAleatorio <= 3 || indiceAleatorio == 5) && Random.value < 0.25f)
            {
                Destroy(gameObject);
                return;
            }

            GetComponent<SpriteRenderer>().sprite = spriteFrames[indiceAleatorio];
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            
            Debug.Log(indiceAleatorio);
            if (indiceAleatorio == 0)
            {
                Time.timeScale = GameManager.Instance.escala_tempo_inicial;
            }
            else if (indiceAleatorio == 1)
            {
                GameManager.Instance.abertura = 4f;
                Spawner.Instance.taxaSpawn += 0.015f;
            }
            else if (indiceAleatorio == 2)
            {
                Spawner.Instance.taxaSpawn += 0.025f;

                CanoClasse[] canos = FindObjectsByType<CanoClasse>(FindObjectsSortMode.None);
                foreach (CanoClasse cano in canos)
                {
                    Destroy(cano.gameObject);
                }
            }
            else if (indiceAleatorio == 3)
            {
                GameManager.Instance.abertura = 3f;
                Spawner.Instance.taxaSpawn -= 0.075f;
            }
            else if (indiceAleatorio == 4)
            {
                other.gameObject.GetComponent<Player>().velocidade = 5f;
            }
            else if (indiceAleatorio == 5)
            {
                other.gameObject.GetComponent<Player>().velocidade = 40f;
            }
            else
            {
                GameManager.Instance.pontuacao += 50;
            }
            Destroy(gameObject);
        }
    }
}
