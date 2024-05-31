using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexgGridOnMap : MonoBehaviour
{
    public GameObject hexPrefab; // Prefab del hexágono
    public Vector2 gridSize; // Tamaño de la cuadrícula (x, y)

    private float sideLength = 1.0382f;
    private float apothem = 0.9045f;
    private float hexWidth;
    private float hexHeight;
    private float hexHorizontalOffset;
    private float hexVerticalOffset;

    void Start()
    {
        // Calcular dimensiones del hexágono
        hexWidth = 2 * sideLength;
        hexHeight = 2 * apothem;
        hexHorizontalOffset = 0.75f * hexWidth;
        hexVerticalOffset = hexHeight * 0.5f;

        CreateGrid();
    }

    void CreateGrid()
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                // Calcula la posición del nuevo hexágono
                float xPos = x * hexHeight -6f;
                float zPos = y * hexHorizontalOffset  -5.5f;

                // Ajuste para filas impares
                if (y % 2 == 1)
                {
                    xPos += .913f;
                }

                Vector3 hexPosition = new Vector3(xPos, 0, zPos);
                Instantiate(hexPrefab, hexPosition, Quaternion.identity, transform);
            }
        }
    }
}
