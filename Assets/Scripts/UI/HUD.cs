using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    [SerializeField] private Button up;
    [SerializeField] private Button down;
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    [SerializeField] private TextMeshProUGUI movementPoints;
    [SerializeField] private TextMeshProUGUI currentSeason;
    [SerializeField] private Button inventory;

    void OnEnable()
    {
        Instance = this;
        left.onClick.AddListener(delegate { Movement.Instance.MoveCamera(0); });
        up.onClick.AddListener(delegate { Movement.Instance.MoveCamera(1); });
        right.onClick.AddListener(delegate { Movement.Instance.MoveCamera(2); });
        down.onClick.AddListener(delegate { Movement.Instance.MoveCamera(3); });

        inventory.onClick.AddListener(delegate { InventoryUI.Instance.OpenInventory(); });

    }
    private void OnDisable()
    {
        left.onClick.RemoveListener(delegate { Movement.Instance.MoveCamera(0); });
        up.onClick.RemoveListener(delegate { Movement.Instance.MoveCamera(1); });
        right.onClick.RemoveListener(delegate { Movement.Instance.MoveCamera(2); });
        down.onClick.RemoveListener(delegate { Movement.Instance.MoveCamera(3); });

        inventory.onClick.RemoveListener(delegate { InventoryUI.Instance.OpenInventory(); });

        SeasonManager.Instance.OnChangeSeason -= UpdateCurrentSeason;
    }

    private void Start()
    {
        SeasonManager.Instance.OnChangeSeason += UpdateCurrentSeason;

        UpdateMovementPointUI(Movement.Instance.movementPoints);
        UpdateCurrentSeason(SeasonManager.Instance.currentSeason);

    }

    public void UpdateMovementPointUI(int points)
    {
        movementPoints.text = points.ToString();
    }

    public void UpdateCurrentSeason(Season season)
    {
        currentSeason.text = season.ToString();
    }
}
