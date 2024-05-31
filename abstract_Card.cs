public abstract class Card
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Este método será implementado por cada tipo de carta
    public abstract void ApplyEffect();
    public abstract void ApplyFXEffect();
}

public class ArmorCard : Card
{
    public ArmorCard()
    {
        Name = "Armadura";
        Description = "Aumenta la defensa del jugador";
    }

    public override void ApplyEffect()
    {
        // Implementa el efecto de la carta de armadura aquí
    }

    public override void ApplyFXEffect()
    {
        // Implementa el efecto de FX de la carta de armadura aquí
    }
}
public class HealthRestorationCard : Card
{
    public HealthRestorationCard()
    {
        Name = "Restauración de Vida";
        Description = "Restaura la vida del jugador";
    }

    public override void ApplyEffect()
    {
        // Implementa el efecto de la carta de restauración de vida aquí
    }

    public override void ApplyFXEffect()
    {
        // Implementa el efecto de FX de la carta de restauración de vida aquí
    }
}

public class PhysicalDamageCard : Card
{
    public PhysicalDamageCard()
    {
        Name = "Daño Físico";
        Description = "Inflige daño físico al enemigo";
    }

    public override void ApplyEffect()
    {
        // Implementa el efecto de la carta de daño físico aquí
    }

    public override void ApplyFXEffect()
    {
        // Implementa el efecto de FX de la carta de daño físico aquí
    }
}

// Agrega otras clases de cartas de manera similar para cada tipo de carta que necesites

