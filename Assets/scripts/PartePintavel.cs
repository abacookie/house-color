using System.Collections;
using UnityEngine;

public class PartePintavel : MonoBehaviour
{
    public int numeroDaParte;
    public Color corCorreta;
    public float toleranciaCor = 0.1f;
    
    private Renderer meuRenderer;
    private Color corOriginal;
    public bool foiPintadoCorretamente { get; private set; }
    public bool foiPintado { get; private set; }

    void Start()
    {
        meuRenderer = GetComponent<Renderer>();
        corOriginal = meuRenderer.material.color;
    }

    public bool VerificarAcerto(Color corUsada)
    {
        bool vermelhoOk = Mathf.Abs(corUsada.r - corCorreta.r) < toleranciaCor;
        bool verdeOk = Mathf.Abs(corUsada.g - corCorreta.g) < toleranciaCor;
        bool azulOk = Mathf.Abs(corUsada.b - corCorreta.b) < toleranciaCor;
        return vermelhoOk && verdeOk && azulOk;
    }

    public void MostrarFeedback(bool acertou, Color corAplicada)
    {
        foiPintado = true;
        foiPintadoCorretamente = acertou;
        
        if (acertou)
        {
            meuRenderer.material.color = corAplicada;
            Debug.Log($"✅ Acertou! Parte {numeroDaParte}");
        }
        else
        {
            StartCoroutine(EfeitoErro(corAplicada));
            Debug.Log($"❌ Errou! Parte {numeroDaParte}");
        }
    }

    private IEnumerator EfeitoErro(Color corTemporaria)
    {
        Color original = meuRenderer.material.color;
        meuRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        meuRenderer.material.color = corTemporaria;
    }
}