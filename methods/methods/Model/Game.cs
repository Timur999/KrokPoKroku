using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods.Model
{
    static class Game
    {
        private const int LEVEL_IN_GAME = 99;
        static public string Play(string name)
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
            return $"{status}! {name} You are the Winner!";
        } 
    }
}
