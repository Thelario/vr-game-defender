namespace Game
{
    public class TeleportSpell : Spell
    {
        protected override void CreateSpellRay(int currentPlayerMana)
        {
            print("Casting teleport spell - mana cost: " + currentManaCost
                          + " - Player mana before spell: " + currentPlayerMana
                          + " - Player mana after spell: " + (currentPlayerMana - currentManaCost));
        }
    }
}