using UnityEngine;
using TMPro; // Adicionado para TextMeshPro
using System.Linq;

public class GerenciadorPontuacao : MonoBehaviour
{
    public static GerenciadorPontuacao Instance { get; private set; }

    [Header("UI")]
    public GameObject painelResultado;
    public TextMeshProUGUI textoNotaFinal; // Alterado para TextMeshPro

    [Header("Partes para Pintar")]
    public PartePintavel[] partesParaPintar;

    private int totalPartes;
    private bool jogoFinalizado = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            totalPartes = partesParaPintar.Length;
            
            if (painelResultado != null)
                painelResultado.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void VerificarPontuacao()
    {
        if (jogoFinalizado || painelResultado == null || textoNotaFinal == null)
            return;

        // Filtra apenas partes que foram pintadas
        var partesPintadas = partesParaPintar.Where(p => p.foiPintado).ToArray();
        int totalPintadas = partesPintadas.Length;
        int acertos = partesPintadas.Count(p => p.foiPintadoCorretamente);

        // Só calcula se todas partes foram pintadas
        if (totalPintadas == totalPartes)
        {
            CalcularNotaFinal(acertos);
            jogoFinalizado = true;
        }
    }

    private void CalcularNotaFinal(int acertos)
    {
        float porcentagem = (float)acertos / totalPartes;
        int nota = Mathf.RoundToInt(porcentagem * 5f);
        
        textoNotaFinal.text = $"Sua nota: {nota}/5";
        painelResultado.SetActive(true);
    }

    // Método para teste (remova depois)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            VerificarPontuacao();
        }
    }
}