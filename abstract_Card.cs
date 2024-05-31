public abstract class Card
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Este m�todo ser� implementado por cada tipo de carta
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
        // Implementa el efecto de la carta de armadura aqu�
    }

    public override void ApplyFXEffect()
    {
        // Implementa el efecto de FX de la carta de armadura aqu�
    }
}
public class HealthRestorationCard : Card
{
    public HealthRestorationCard()
    {
        Name = "Restauraci�n de Vida";
        Description = "Restaura la vida del jugador";
    }

    public override void ApplyEffect()
    {
        // Implementa el efecto de la carta de restauraci�n de vida aqu�
    }

    public override void ApplyFXEffect()
    {
        // Implementa el efecto de FX de la carta de restauraci�n de vida aqu�
    }
}

public class PhysicalDamageCard : Card
{
    public PhysicalDamageCard()
    {
        Name = "Da�o F�sico";
        Description = "Inflige da�o f�sico al enemigo";
    }

    public override void ApplyEffect()
    {
        // Implementa el efecto de la carta de da�o f�sico aqu�
    }

    public override void ApplyFXEffect()
    {
        // Implementa el efecto de FX de la carta de da�o f�sico aqu�
    }
}

// Agrega otras clases de cartas de manera similar para cada tipo de carta que necesites

