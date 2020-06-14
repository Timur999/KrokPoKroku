using methods.Profesions;
using System;
using System.Collections.Generic;

namespace methods.Model
{
    static class Game
    {
        private const int LEVEL_IN_GAME = 99;
        static public string Play(string name)
        {
            Status NextLevel(int dungeonsLevel)
            {
                if (LEVEL_IN_GAME < dungeonsLevel)
                {
                    return Result.Success;
                }

                return NextLevel(dungeonsLevel + 1);
            }

            var status = NextLevel(1);
            return $"{status}! {name} You are the Winner!";
        }

        static public string Play(Character character)
        {
            Status NextLevel(int level)
            {
                if (LEVEL_IN_GAME < level)
                {
                    return Result.Success;
                }

                return NextLevel(level + 1);
            }

            var status = NextLevel(1);
            return $"{status}! {character.Name} {character.GetType().Name} You are the Winner!";
        }

        static public (Status, Character) CreateCharacter(Type type, string name = "Herring cream", string weapon = "knife")
        {
            Character character = null;
            if (type.Equals(typeof(Knight)))
            {
                character = new Knight { Name = name, Weapon = weapon, Backpack = new List<string>() { weapon} };
            }
            else
            {
                character = new Paladin { Name = name, Weapon = weapon, Backpack = new List<string>() { weapon } };
            }
            return (Result.Success, character);
        }
    }
}
