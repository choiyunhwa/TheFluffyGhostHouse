using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float useStamina;

    [Header("Combat")]
    public int damage;

    private Camera camera;
    private void Start()
    {
        camera = Camera.main;
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            if (PlayerManager.Instance.Player.condition.UseMana(useStamina))
            {
                attacking = true;

                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    private void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            if (hit.collider.TryGetComponent(out Monster monter))
            {
                monter.TakePhysicalDamage(10);
            }

        }
    }
}
