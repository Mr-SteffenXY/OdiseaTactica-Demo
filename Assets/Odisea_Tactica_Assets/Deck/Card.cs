using UnityEngine;
using TMPro; // Asegúrate de importar el paquete de TextMeshPro
using UnityEngine.EventSystems;
using NUnit.Framework;
using System.Collections.Generic; // Para manejar los eventos del mouse

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string cardDescription;
    public string Name { get; set; }
    public string Description { get; set; }
    private TextMeshProUGUI descriptionText;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private SlotManager slotManager;

    void Start()
    {
        descriptionText = GameObject.Find("CardDescriptionText").GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        slotManager = Object.FindObjectOfType<SlotManager>();

        // Comprueba si el objeto tiene un componente CanvasGroup
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            // Si no tiene un componente CanvasGroup, añádelo
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.text = cardDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.text = "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        slotManager.FillSlotWithNewCard();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        // Destruir el prefab sin importar donde se suelte la carta
        Destroy(this.gameObject);

        // Rellenar el slot que se ha vaciado
        slotManager.FillSlotWithNewCard();
    }
}
