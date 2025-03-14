using UnityEngine;
using System.Collections.Generic;

// --- Strategy Interface ---
// Defines the contract that all concrete strategies must follow.
public interface IAttackStrategy
{
    void Attack(GameObject target);
}

// --- Concrete Strategies ---

// Melee Attack Strategy
public class MeleeAttackStrategy : IAttackStrategy
{
    private float damage;
    private float attackRange;

    public MeleeAttackStrategy(float damage, float attackRange)
    {
        this.damage = damage;
        this.attackRange = attackRange;
    }

    public void Attack(GameObject target)
    {
        if(target != null)
        {
            float distance = Vector3.Distance(target.transform.position, GetAttackOrigin().transform.position);

            if (distance <= attackRange)
            {
                Debug.Log($"Melee attack on {target.name} for {damage} damage!");
                // Implement actual damage logic here, e.g., reducing target's health
            }
            else
            {
                Debug.Log($"Melee attack failed, {target.name} is out of range");
            }

        }
        else
        {
            Debug.Log($"Melee attack failed, there is not target.");
        }
    }

    // Method to get the attack origin
    private GameObject GetAttackOrigin()
    {
        // In a real game, you'd likely get this from the character's transform
        // or a specific attack point on their model.
        // For this example, we'll just use a hardcoded point.
        return GameObject.Find("Player"); // Assuming there's a GameObject named "Player"
    }
}

// Ranged Attack Strategy
public class RangedAttackStrategy : IAttackStrategy
{
    private float damage;
    private float attackRange;
    private GameObject projectilePrefab;

    public RangedAttackStrategy(float damage, float attackRange, GameObject projectilePrefab)
    {
        this.damage = damage;
        this.attackRange = attackRange;
        this.projectilePrefab = projectilePrefab;
    }

    public void Attack(GameObject target)
    {
        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, GetAttackOrigin().transform.position);

            if (distance <= attackRange)
            {
                Debug.Log($"Ranged attack launched towards {target.name} for {damage} damage!");
                // Instantiate projectile and set its target
                if (projectilePrefab != null)
                {
                    GameObject projectile = GameObject.Instantiate(projectilePrefab, GetAttackOrigin().transform.position, Quaternion.identity);
                    Projectile projectileComponent = projectile.AddComponent<Projectile>();
                    projectileComponent.SetTarget(target, damage);
                }
                else
                {
                  Debug.LogWarning($"Projectile prefab is null, can't launch the projectile to {target.name}");
                }
                // Implement actual projectile logic here
            }
            else
            {
                Debug.Log($"Ranged attack failed, {target.name} is out of range");
            }
        }
        else
        {
            Debug.Log($"Ranged attack failed, there is not target.");
        }
    }

    // Method to get the attack origin
    private GameObject GetAttackOrigin()
    {
        // In a real game, you'd likely get this from the character's transform
        // or a specific attack point on their model.
        // For this example, we'll just use a hardcoded point.
         return GameObject.Find("Player"); // Assuming there's a GameObject named "Player"
    }
}

// --- Context ---
// The class that uses the strategy.
public class Character : MonoBehaviour
{
    public IAttackStrategy attackStrategy;
    public GameObject target; //Public for example

    public void SetAttackStrategy(IAttackStrategy strategy)
    {
        attackStrategy = strategy;
    }

    public void PerformAttack()
    {
        if (attackStrategy != null && target != null)
        {
          attackStrategy.Attack(target);
        }
        else
        {
          if(attackStrategy == null)
          {
              Debug.Log("There is not strategy assigned.");
          }
          if(target == null)
          {
            Debug.Log("There is not target assigned.");
          }
        }
    }
}
// --- Projectile  ---
public class Projectile : MonoBehaviour
{
    private GameObject target;
    private float damage;
    private float speed = 10.0f;

    public void SetTarget(GameObject target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private void Update()
    {
        if (target != null)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            // Check if reached the target
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                HitTarget();
            }
        }
        else
        {
            Destroy(gameObject); // Destroy projectile if target is lost
        }
    }

    private void HitTarget()
    {
        Debug.Log($"Projectile hit {target.name} for {damage} damage!");
        // Apply damage to the target
        // ...
        Destroy(gameObject); // Destroy projectile after hitting
    }
}

// --- Example Usage ---
public class StrategyExample : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject targetToAttack;
    private void Start()
    {
        // Create a Character
        GameObject characterObject = new GameObject("Player");
        Character character = characterObject.AddComponent<Character>();
        character.target = targetToAttack;
        // Example Target
        if(targetToAttack == null)
        {
          targetToAttack =  new GameObject("Target");
        }

        // Create Melee and Ranged attack strategies
        MeleeAttackStrategy meleeStrategy = new MeleeAttackStrategy(10, 2);
        RangedAttackStrategy rangedStrategy = new RangedAttackStrategy(5, 10, projectilePrefab);

        // Set the strategy to the character (initially Melee)
        character.SetAttackStrategy(meleeStrategy);
        character.PerformAttack(); // Perform melee attack

        // Change to ranged strategy
        character.SetAttackStrategy(rangedStrategy);
        character.PerformAttack(); // Perform ranged attack
    }
}
