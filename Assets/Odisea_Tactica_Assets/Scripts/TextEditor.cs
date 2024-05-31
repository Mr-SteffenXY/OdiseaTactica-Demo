using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour
{
    // Referencia al componente TextMeshPro
    public TextMeshProUGUI textMeshPro;

    // Lista de textos para diferentes razas
    public List<string> textosRaza;

    void Update()
    {
        // Verifica si el bot�n del mouse izquierdo fue presionado
        if (Input.GetMouseButtonDown(0))
        {
            // Lanza un rayo desde la c�mara hasta la posici�n del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Si el rayo golpea un objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Si el objeto golpeado tiene el tag "Raza"
                if (hit.transform.gameObject.CompareTag("Raza"))
                {
                    // Aseg�rate de que el componente TextMeshProUGUI est� asignado
                    if (textMeshPro == null)
                    {
                        textMeshPro = GetComponent<TextMeshProUGUI>();
                    }

                    // Si el GameObject existe y tiene un nombre, cambia el texto en consecuencia
                    if (hit.transform.gameObject.name != null)
                    {
                        switch (hit.transform.gameObject.name)
                        {
                            case "Elfo":
                                textMeshPro.text = textosRaza[0]; // Aseg�rate de que este �ndice corresponda al texto para "Elfo"
                                break;
                            case "Humano":
                                textMeshPro.text = textosRaza[1]; // Aseg�rate de que este �ndice corresponda al texto para "Humano"
                                break;
                            case "Orco":
                                textMeshPro.text = textosRaza[2]; // Aseg�rate de que este �ndice corresponda al texto para "Orco"
                                break;
                            default:
                                textMeshPro.text = "Desconocido";
                                break;
                        }
                    }

                }
            }
        }
    }
}
