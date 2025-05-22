using Microsoft.EntityFrameworkCore;
using System;

namespace ForFun.Api
{
    public class Zhouyi
    {
        private OwnDevContext _devContext;
        public Zhouyi(OwnDevContext dbContext)
        {
            _devContext = dbContext;
        }

        //get Hexgram
        public Trigram GetTrigram(int num)
        {
            if (!(num >= 0 && num <= 7))
                return new Trigram() { Num = -1 };
            try
            { 
            var res = _devContext.Trigrams.Single(x => x.Num == num);
            return res;
            }
            catch(Exception ex)
            {
                return new Trigram() { Num = -1 };
            }
        }

        public Hexagram GetHexagram(int up, int bottom)
        {
            if (!(up >= 0 && up <= 7) || !(bottom >= 0 && bottom <= 7))
                return new Hexagram() { NumKey = "" };

            var res = _devContext.Hexagrams.Single(x=>x.Up == up && x.Bottom == bottom);

            return res;
        }


    }
}
