using methods.Model;
using methods.Profesions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Podczas kompilacji kompilator zapisuje sobie wszystkie metody, ich sygnatury. Dzięki temu wie z jakimi parametrami bedzie wywoływana metoda, w przypadku przeciązenia jakies metody.
            //Natomiast w przypadku parametrow domyslnych nalezy je zainicjować wartościami 'const' inaczej kompilator nie bedzie wstanie zapisac sobie sygnatury 

            //metoda wcielająca wyrażenie
            int minusNumbers(int a, int b) => a - b;
            int plusNumbers(int a, int b) => Calclator.Add(a, b);

            //próba rzutowania typu
            double x = 10;
            float y = 10f;
            //Calclator.Add(x, y); //Cannot convert double and float to int. Próba niejawnej konwersji
            Calclator.Add((int)x, (int)y); //Jawna konwersja na inta. double > float > int. W przypadku rzutowania typu wiekszego na mniejszy, nalezy jawnie zdefiniowac typ
            int t = 1;
            int u = 1;
            Calclator.Multi(t, u); //nie jawnie rzutuje inta na inny typ. Metoda Multi przyjmuje paramerty double i float

            //Zwracanie więcej niż jednej wartości z funkcji.
            //krotka (tuple) mała kolekcja wartości. Aby użyc krotki nalezy zainstalować pakiet ValueTuple. 
            int retValue1, retValue2;
            (retValue1, retValue2) = Calclator.Devide(11, 2);

            // Wywołanie metoda przeciązonej           
            Calclator.ShowResult(retValue1, retValue2);

            //rekurencja
            Console.WriteLine(Game.Play("Tomas"));

            //Parametry opcjionalne. 
            //CLR (Common Language Runtime) platformy .Net Framework jest zależny od COM, który nie wpiera motod przeciązonych zamiast tego uzywa Parametry opcjionalne. 
            Character character;
            Status status;
            string typeName = typeof(Knight).ToString(); //typeof(Knight) = {Name = "Knight" FullName = "methods.Profesions.Knight"}  typeof(Knight).ToString() = "methods.Profesions.Knight"
            Type characterKnightType = Type.GetType(typeof(Knight).ToString()); // characterKnightType = {Name = "Knight" FullName = "methods.Profesions.Knight"}
            Type characterPaladinType = typeof(Paladin);  // alternative

            (status, character) = Game.CreateCharacter(characterKnightType); //(Status, Character) CreateCharacter(Type type, string name = "Herring cream", string weapon = "knife")
            //wywołanie motody z nazwami parametrów
            (status, character) = Game.CreateCharacter(type: characterPaladinType, weapon: "short bow");
            (status, character) = Game.CreateCharacter(characterPaladinType, weapon: "short bow");
            //(status, character) = Game.CreateCharacter(weapon: "short bow",characterPaladinType); // bład. sposob mieszny w tedy podajemy na poczatku wartosc zmiennej bez nazwy. jak wyrzej

            //rozwiazywanie niejasnosci w przypadku 
            //        1. static public string Play(string name, int hp = 100, int dungeonsLevel=1), 2. static public string Play(string name, int hp=100, int dungeonsLevel=1, int heroLevel=7)
            //  w takim przypadku wygrywa metoda najbardziej dopoasowana
            //  Play( name, 100, 1) ---- 1
            //  Play( name, 100, 1, 7) ---- 2
            //  Play(name, heroLevel: 7)---- 2
            //  Play( name, 100) ---- blad i w kazdym innym przypadku.

            Console.WriteLine(Game.Play(character));

            Console.ReadKey();
        }
    }
}
