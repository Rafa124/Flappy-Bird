using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{

    public static Spawner Instance;
    public CanoClasse prefabCanos;
    public float taxaSpawn = 1f;
    public float alturaMinima = -1f;
    public float alturaMaxima = 2f;
    public float aberturaVertical = 3f;

    private float tempoDesdeUltimoSpawn = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        tempoDesdeUltimoSpawn = 0f;
    }

    private void Update()
    {
        if (Time.timeScale == 0f) return;

        tempoDesdeUltimoSpawn += Time.deltaTime;

        if (tempoDesdeUltimoSpawn >= taxaSpawn) {
            tempoDesdeUltimoSpawn = 0f;
            Gerar();
        }
    }

    private void Gerar()
    {
        CanoClasse canos = Instantiate(prefabCanos, transform.position, Quaternion.identity);
        canos.transform.position += Vector3.up * Random.Range(alturaMinima, alturaMaxima);
    }

}
