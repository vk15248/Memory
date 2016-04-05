using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorijaUniversal
{
    public class Card
    {
        private int number;
        private bool isout;

        public Card(int number)
        {
            Number = number;
            isout = false;
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public bool Isout
        {
            get
            {
                return isout;
            }

            set
            {
                isout = value;
            }
        }
    }
}
