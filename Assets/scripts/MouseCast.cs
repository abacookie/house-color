using UnityEngine;

public class MouseCast : MonoBehaviour
{
    public Tinta controladorTinta;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if(renderer != null && controladorTinta != null)
                {
                    controladorTinta.Pintar(renderer);
                }
            }
        }
    }
}