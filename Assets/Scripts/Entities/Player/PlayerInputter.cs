using System;
using System.Linq;
using UnityEngine;

public class PlayerInputter : MonoBehaviour
{
    private PlayerMovement _movementController;
    private WeaponController _weaponController;
    private InventorySystem _inventorySystem;

    private void Awake()
    {
        _movementController = GetComponent<PlayerMovement>();
        _weaponController = GetComponent<WeaponController>();
        _inventorySystem = GetComponent<InventorySystem>();
    }

    private void Update()
    {
        CheckForMovements();
        CheckForJump();
        CheckForShooting();
        CheckForBonusWeaponActivation();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
        }
    }

    private void CheckForJump()
    {
        if (Input.GetKeyDown(PlayerKeys.Jump))
        {
            _movementController.TryJump();
        }
    }

    private void CheckForMovements()
    {
        var zeroVector = Vector3.zero;

        Vector3 nextDirection = zeroVector;

        nextDirection += Vector3.forward * Input.GetAxis(AxisNames.InputVertical);
        nextDirection += Vector3.right * Input.GetAxis(AxisNames.InputHorizontal);


        if (nextDirection != zeroVector)
        {
            _movementController.MoveInDirection(nextDirection);
        }
    }

    private void CheckForShooting()
    {
        if (Input.GetKeyDown(PlayerKeys.Shoot))
        {
            _weaponController.Shoot();
        }
    }

    private void CheckForBonusWeaponActivation()
    {
        if (Input.GetKeyDown(PlayerKeys.ActivateBonus))
        {
            _weaponController.ActivateBonus();
        }
    }
}
