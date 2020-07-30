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

            // Więcej niż jedna wartość z funkcji.
            // krotka (tuple) mała kolekcja wartości. Aby użyc krotki nalezy zainstalować pakiet 'ValueTuple'. 
            int retValue1, retValue2;
            (retValue1, retValue2) = Calclator.Devide(11, 2);

            // Wywołanie metoda przeciązonej. Nazwa taka sama, różne parametry           
            Calclator.ShowResult(retValue1, retValue2);

            //rekurencja
            Console.WriteLine(Game.Play("Tomas"));

            // Parametry opcjonalne. 
            // CLR (Common Language Runtime) platformy .Net Framework jest zależny od COM, który nie wpiera motod przeciązonych zamiast tego uzywa Parametrów opcjonalnych. 
            Character character;
            Status status;
            // Przykład zastosowania typeof i Type.GetType
            string typeName = typeof(Knight).ToString(); //typeof(Knight) = {Name = "Knight" FullName = "methods.Profesions.Knight"}  typeof(Knight).ToString() = "methods.Profesions.Knight"
            Type characterKnightType = Type.GetType(typeof(Knight).ToString()); // characterKnightType = {Name = "Knight" FullName = "methods.Profesions.Knight"}
            Type characterPaladinType = typeof(Paladin);  // alternative

            (status, character) = Game.CreateCharacter(characterKnightType); //(Status, Character) CreateCharacter(Type type, string name = "Herring cream", string weapon = "knife")
            // Przykład wywołania motody z nazwami parametrów. Nie muszą być podane pokolei jak zostały zdefiniowane w funkcji.
            (status, character) = Game.CreateCharacter(type: characterPaladinType, weapon: "short bow");
            (status, character) = Game.CreateCharacter(weapon: "short bow", type: characterPaladinType);
            (status, character) = Game.CreateCharacter(characterPaladinType, weapon: "short bow");
            //(status, character) = Game.CreateCharacter(weapon: "short bow",characterPaladinType); // bład. sposob mieszny w tedy podajemy na poczatku wartosc zmiennej bez nazwy. jak wyrzej

            //rozwiazywanie niejasnosci w przypadku 
            //        1. static public string Play(string name, int hp = 100, int dungeonsLevel=1),
            //        2. static public string Play(string name, int hp = 100, int dungeonsLevel=1, int heroLevel=7)
            //  w takim przypadku wygrywa metoda najbardziej dopoasowana
            //  Play( name, 100, 1) ---- 1 metoda
            //  Play( name, 100, 1, 7) ---- 2 metoda
            //  Play(name, heroLevel: 7)---- 2 metoda
            //  Play( name, 100) ---- blad i w kazdym innym przypadku.

            Console.WriteLine(Game.Play(character));

            Console.ReadKey();
        }
    }
}
