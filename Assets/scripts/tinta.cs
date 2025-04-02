using UnityEngine;

public class Tinta : MonoBehaviour
{
    public Color[] cores = {
        new Color(0.03f, 0.55f, 0.01f),  // #078C03 - Verde gramado
        new Color(0.95f, 0.83f, 0.68f),   // #F2D4AE - Bege claro
        new Color(0.55f, 0.20f, 0.07f),   // #8C3211 - Marrom avermelhado
        new Color(0.15f, 0.07f, 0.06f),   // #261210 - Marrom escuro
        new Color(0.95f, 0.95f, 0.95f)    // #F2F2F2 - Branco gelo
    };
    
    public Renderer telhado;  // Parte 0
    public Renderer parede;   // Parte 1
    public Renderer porta;    // Parte 2
    public Renderer gramado;  // Parte 3

    private Color corAtual;
    private bool corSelecionada = false;

    public void SelecionarCor(int corIndex)
    {
        if(corIndex < 0 || corIndex >= cores.Length) return;
        corAtual = cores[corIndex];
        corSelecionada = true;
        Debug.Log("Cor selecionada: " + corIndex);
    }

    public void PintarParte(Renderer objeto)
    {
        if(!corSelecionada) return;
        
        if(objeto != null)
        {
            objeto.material.color = corAtual;
            Debug.Log("Objeto pintado: " + objeto.name);
        }
    }

    public void ResetarCores()
    {
        if(telhado != null) telhado.material.color = Color.white;
        if(parede != null) parede.material.color = Color.white;
        if(porta != null) porta.material.color = Color.white;
        if(gramado != null) gramado.material.color = new Color(0.03f, 0.55f, 0.01f); // Verde gramado como padrão
    }
}