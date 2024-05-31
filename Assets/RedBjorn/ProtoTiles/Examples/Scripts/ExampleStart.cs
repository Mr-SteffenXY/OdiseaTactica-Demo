using UnityEngine;

namespace RedBjorn.ProtoTiles.Example
{
    public class ExampleStart : MonoBehaviour
    {
        public MapSettings Map;
        public KeyCode GridToggle = KeyCode.G;
        public MapView MapView;
        public UnitMove Unit1;
        public UnitMove Unit2;

        private UnitMove selectedUnit;

        public MapEntity MapEntity { get; private set; }

        void Start()
        {
            if (!MapView)
            {
#if UNITY_2023_1_OR_NEWER
                MapView = FindFirstObjectByType<MapView>();
#else
                MapView = FindObjectOfType<MapView>();
#endif
            }
            MapEntity = new MapEntity(Map, MapView);
            if (MapView)
            {
                MapView.Init(MapEntity);
            }
            else
            {
                Log.E("Can't find MapView. Random errors can occur");
            }

            if (!Unit1)
            {
#if UNITY_2023_1_OR_NEWER
                Unit1 = FindFirstObjectByType<UnitMove>();
#else
                Unit1 = FindObjectOfType<UnitMove>();
#endif
            }
            if (Unit1)
            {
                Unit1.Init(MapEntity);
            }
            else
            {
                Log.E("Can't find Unit1. Example level start incorrect");
            }

            if (!Unit2)
            {
#if UNITY_2023_1_OR_NEWER
                Unit2 = FindFirstObjectByType<UnitMove>();
#else
                Unit2 = FindObjectsOfType<UnitMove>()[1]; // Assuming the second unit is the second instance found
#endif
            }
            if (Unit2)
            {
                Unit2.Init(MapEntity);
            }
            else
            {
                Log.E("Can't find Unit2. Example level start incorrect");
            }

            selectedUnit = Unit1; // Default selection
            Debug.Log("Unit 1 selected");
        }

        void Update()
        {
            if (Input.GetKeyUp(GridToggle))
            {
                MapEntity.GridToggle();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                selectedUnit = Unit1;
                Debug.Log("Unit 1 selected");
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                selectedUnit = Unit2;
                Debug.Log("Unit 2 selected");
            }

            if (selectedUnit)
            {
                selectedUnit.HandleInput();
            }
        }
    }
}

