﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name) 
            : base(name, 100, 50, 40, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                if (character.Name == base.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                character.TakeDamage(base.AbilityPoints);
            }
        }
    }
}
