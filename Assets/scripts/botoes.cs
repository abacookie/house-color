using UnityEngine;
using UnityEngine.UI;

public class Botoes : MonoBehaviour
{
    public Tinta controladorTinta;
    public int indiceCor;

    void Start()
    {
        Button botao = GetComponent<Button>();
        if(botao != null)
        {
            botao.onClick.AddListener(() => {
                if(controladorTinta != null)
                    controladorTinta.SelecionarCor(indiceCor);
            });
        }

        Image imagem = GetComponent<Image>();
        if(imagem != null && controladorTinta != null && indiceCor < controladorTinta.cores.Length)
        {
            imagem.color = controladorTinta.cores[indiceCor];
        }
    }
}