using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

/// <summary>
/// Clase para manejar el carrusel de personajes.
/// </summary>
public class CharacterCarousel : MonoBehaviour
{
    public RawImage characterImage; // Imagen para mostrar el personaje seleccionado
    public Texture[] characterPortraits; // Array de retratos de los personajes
    public string[] characterStats; // Array de estad�sticas de los personajes
    public TextMeshProUGUI textStats; // Referencia al TextMeshPro para mostrar las estad�sticas

    private int currentIndex = 0; // �ndice actual del personaje

    void Start()
    {
        // Mostrar el primer personaje y sus estad�sticas al inicio
        if (characterPortraits.Length > 0 && characterStats.Length > 0)
        {
            UpdateCharacterDisplay();
        }
    }

    // M�todo para mostrar el siguiente personaje
    public void ShowNextCharacter()
    {
        if (characterPortraits.Length == 0 || characterStats.Length == 0) return;

        currentIndex = (currentIndex + 1) % characterPortraits.Length;
        UpdateCharacterDisplay();
    }

    // M�todo para mostrar el personaje anterior
    public void ShowPreviousCharacter()
    {
        if (characterPortraits.Length == 0 || characterStats.Length == 0) return;

        currentIndex = (currentIndex - 1 + characterPortraits.Length) % characterPortraits.Length;
        UpdateCharacterDisplay();
    }

    // M�todo para actualizar la imagen del personaje y sus estad�sticas
    private void UpdateCharacterDisplay()
    {
        characterImage.texture = characterPortraits[currentIndex];
        textStats.text = characterStats[currentIndex];
    }
}
