using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private int initialArrowCount = 0;
    public int CurrentArrowCount { get; private set; }

    private Animator playerAnimator;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerInputActions = new PlayerInputActions();
        CurrentArrowCount = initialArrowCount;
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Shoot.performed += HandleShootInput;
        GameEvents.ArrowPickedUp += AddArrows;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Shoot.performed -= HandleShootInput;
        playerInputActions.Disable();
        GameEvents.ArrowPickedUp -= AddArrows;
    }

    public void AddArrows(int amountToAdd)
    {
        CurrentArrowCount += amountToAdd;
    }

    private void HandleShootInput(InputAction.CallbackContext ctx)
    {
        TryShoot();
    }

    private void TryShoot()
    {
        if (CurrentArrowCount <= 0) return;
        Vector2 direction = GetShootDirection();
        ShootArrow(direction);
        CurrentArrowCount--;
    }

    //only mouse...later i will fix
    private Vector2 GetShootDirection()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        return (mouseWorldPosition - (Vector2)arrowSpawnPoint.position).normalized;
    }

    private void ShootArrow(Vector2 direction)
    {
        GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        newArrow.GetComponent<Arrow>().Initialize(direction);
    }
}
