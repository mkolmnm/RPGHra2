using System;
using System.Collections.Generic;

namespace RPGHra2
{
    public class HrdinaLogika 
    {
        public static Character VyberPostavu()
        {
            List<Character> listPostav = new List<Character>
            {
                new Warrior(),
                new Mage(),
                new Archer()
            };

            string[] jmena = new string[listPostav.Count];
            for (int i = 0; i < listPostav.Count; i++)
            {
                jmena[i] = listPostav[i].GetType().Name;
            }

            int index = RPGHra2.Moznosti.VykresliMoznosti(jmena, "Vyber si Hrdinu!");
            
            return listPostav[index]; 
        }
    }
}