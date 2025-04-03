using UnityEngine;

public class Tinta : MonoBehaviour
{
    public Color[] cores = {
        new Color(0.03f, 0.55f, 0.01f), // Verde
        new Color(0.95f, 0.83f, 0.68f),  // Bege
        new Color(0.55f, 0.20f, 0.07f),  // Marrom
        new Color(0.15f, 0.07f, 0.06f),  // Marrom escuro
        new Color(0.95f, 0.95f, 0.95f)   // Branco
    };

    private Color corSelecionada;
    private bool temCorSelecionada = false;

    public void SelecionarCor(int indiceCor)
    {
        if(indiceCor < 0 || indiceCor >= cores.Length) return;
        
        corSelecionada = cores[indiceCor];
        temCorSelecionada = true;
        Debug.Log($"Cor selecionada: {indiceCor}");
    }

    public void Pintar(Renderer objetoRenderer)
    {
        if(!temCorSelecionada) return;

        PartePintavel parte = objetoRenderer.GetComponent<PartePintavel>();
        if(parte != null)
        {
            bool acertou = parte.VerificarAcerto(corSelecionada);
            parte.MostrarFeedback(acertou, corSelecionada);
            
            if(GerenciadorPontuacao.Instance != null)
                GerenciadorPontuacao.Instance.VerificarPontuacao();
        }
    }
}