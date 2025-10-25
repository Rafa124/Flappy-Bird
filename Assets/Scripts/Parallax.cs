using UnityEngine;
using UnityEngine.Serialization;

public class Parallax : MonoBehaviour
{
    public float velocidadeAnimacao = 1f;
    private MeshRenderer renderizadorMalha;

    private void Awake()
    {
        renderizadorMalha = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        renderizadorMalha.material.mainTextureOffset += new Vector2(velocidadeAnimacao * Time.deltaTime, 0);
    }

}
