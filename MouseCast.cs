using UnityEngine;

public class MouseCast : MonoBehaviour
{
    public Tinta tinta;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if(renderer != null && tinta != null)
                {
                    tinta.PintarParte(renderer);
                }
            }
        }
    }
}