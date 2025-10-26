using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player jogador;
    [SerializeField] private Spawner gerador;
    [SerializeField] private Text textoPontuacao;
    [SerializeField] private GameObject botaoJogar;
    [SerializeField] private GameObject GetReady;
    [SerializeField] private GameObject _GameOver;
    [SerializeField] public float abertura = 3f;
    
    [SerializeField] public Button facil;
    [SerializeField] public Button medio;
    [SerializeField] public Button dificil;

    private float abertura_inicial = 3f;
    public float escala_tempo_inicial = 1f;
    public float taxa_spawn_inicial = 1f;

    [SerializeField] public RectTransform panel;

    public int pontuacao = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        facil.onClick.AddListener(facil_func);
        medio.onClick.AddListener(medio_func);
        dificil.onClick.AddListener(dificil_func);
        _GameOver.SetActive(false);
        medio_func();
        Pause();
    }
    
    
    public void AumentarPontuacao()
    {
        pontuacao++;
        textoPontuacao.text = pontuacao.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        jogador.enabled = false;
    }

    public void Play()
    {
        pontuacao = 0;
        textoPontuacao.text = pontuacao.ToString();

        panel.gameObject.SetActive(false);
        facil.gameObject.SetActive(false);
        medio.gameObject.SetActive(false);
        dificil.gameObject.SetActive(false);
        GetReady.SetActive(false);
        botaoJogar.SetActive(false);
        _GameOver.SetActive(false);

        Time.timeScale = escala_tempo_inicial;
        abertura = abertura_inicial;
        gerador.taxaSpawn = taxa_spawn_inicial;
        jogador.enabled = true;

        CanoClasse[] canos = FindObjectsByType<CanoClasse>(FindObjectsSortMode.None);

        for (int i = 0; i < canos.Length; i++) {
            Destroy(canos[i].gameObject);
        }
    }

    public void GameOver()
    {
        botaoJogar.SetActive(true);
        _GameOver.SetActive(true);


        facil.gameObject.SetActive(true);
        medio.gameObject.SetActive(true);
        dificil.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);

        Pause();
    }


    void facil_func()
    {
        abertura_inicial = 4f;
        escala_tempo_inicial = .75f;
        taxa_spawn_inicial = 1f;
        jogador.velocidade = 40f;
    }

    void medio_func()
    {
        abertura_inicial = 3f;
        escala_tempo_inicial = 1.10f;
        taxa_spawn_inicial = 0.4f;
        jogador.velocidade = 30f;
    }

    void dificil_func()
    {
        abertura_inicial = 3f;
        escala_tempo_inicial = 1.275f;
        taxa_spawn_inicial = 0.275f;
        jogador.velocidade = 20f;
    }


}
