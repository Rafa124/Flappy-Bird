using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float velocidade = 20f;


    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
    }

    private void Update()
    {
        if (Camera.main == null) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float alvoY = mouseWorld.y;

        Vector3 posAtual = transform.position;
        Vector3 alvo = new Vector3(posAtual.x, alvoY, posAtual.z);

        transform.position = Vector3.Lerp(posAtual, alvo, velocidade * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null || other.gameObject == null) return;

        Collider2D collider = other.gameObject.GetComponent<Collider2D>();

        if (collider != null && other.gameObject.name == "Score") {
            GameManager.Instance.AumentarPontuacao();
        } else {
            GameManager.Instance.GameOver();
        }
    }

}
