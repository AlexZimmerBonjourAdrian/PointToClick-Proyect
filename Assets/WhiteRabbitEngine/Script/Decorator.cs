using UnityEngine;

// --- Component Interface ---
// The base interface that defines the core functionality.
public interface ICharacter
{
    string GetDescription();
    float GetHealth();
    float GetDamage();
    void GetHit(float damage);
    
}

// --- Concrete Component ---
// The base character implementation.
public class BasicCharacter : MonoBehaviour, ICharacter
{
    protected float health = 100f;
    protected float damage = 10f;
    protected string description = "Basic Character";

    public string GetDescription()
    {
        return description;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetDamage()
    {
      return damage;
    }

    public void GetHit(float damage)
    {
        health -= damage;
        if(health < 0)
        {
          Debug.Log("Character is dead!");
        }
        else
        {
          Debug.Log("Character get hit for " + damage + " damage. Now has " + health + " health");
        }
    }
}

// --- Decorator Abstract Class ---
// The base decorator that implements the component interface.
// It also holds a reference to the component it is decorating.
public abstract class CharacterDecorator : MonoBehaviour, ICharacter
{
    protected ICharacter decoratedCharacter;

    public CharacterDecorator(ICharacter character)
    {
        this.decoratedCharacter = character;
    }

    public virtual string GetDescription()
    {
        return decoratedCharacter.GetDescription();
    }

    public virtual float GetHealth()
    {
      return decoratedCharacter.GetHealth();
    }

    public virtual float GetDamage()
    {
      return decoratedCharacter.GetDamage();
    }
    public virtual void GetHit(float damage)
    {
      decoratedCharacter.GetHit(damage);
    }
}

// --- Concrete Decorators ---
// Add specific enhancements.

public class ArmorDecorator : CharacterDecorator
{
    private float armor;
    public ArmorDecorator(ICharacter character, float armor) : base(character)
    {
      this.armor = armor;
    }

    public override string GetDescription()
    {
        return decoratedCharacter.GetDescription() + ", with Armor";
    }

    public override float GetHealth()
    {
        return decoratedCharacter.GetHealth() + armor;
    }

    public override void GetHit(float damage)
    {
        if(damage <= armor)
        {
          Debug.Log("Armor protected to the character!");
        }
        else
        {
            decoratedCharacter.GetHit(damage - armor);
        }
    }

}

public class PowerUpDecorator : CharacterDecorator
{
    private float damageBuff;

    public PowerUpDecorator(ICharacter character, float damageBuff) : base(character)
    {
        this.damageBuff = damageBuff;
    }

    public override string GetDescription()
    {
        return decoratedCharacter.GetDescription() + ", with Power Up";
    }

    public override float GetDamage()
    {
        return decoratedCharacter.GetDamage() + damageBuff;
    }
}

// --- Example Usage ---
public class DecoratorExample : MonoBehaviour
{
    private void Start()
    {
        // Create a basic character
        GameObject characterObject = new GameObject("Character");
        BasicCharacter basicCharacter = characterObject.AddComponent<BasicCharacter>();

        // Add some Armor
        ArmorDecorator armoredCharacter = new ArmorDecorator(basicCharacter, 20f);
        Debug.Log("Character: " + armoredCharacter.GetDescription() + ", Health: " + armoredCharacter.GetHealth());
        armoredCharacter.GetHit(10); //Armor protect to the character.
        armoredCharacter.GetHit(30); //Character get hit for 10.
        // Add a Power Up
        PowerUpDecorator poweredUpCharacter = new PowerUpDecorator(armoredCharacter, 5f);
        Debug.Log("Character: " + poweredUpCharacter.GetDescription() + ", Damage: " + poweredUpCharacter.GetDamage() + ", Health: " + poweredUpCharacter.GetHealth());
        poweredUpCharacter.GetHit(40); //Character get hit for 20.

    }
}



