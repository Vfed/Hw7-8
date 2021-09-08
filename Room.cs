using System;
using System.Collections.Generic;
using System.Text;

namespace Hw8
{
    public class Room
    {
        public int RoomNumber { get; private set; }
        public bool IsPublick { get; set; }
        public int Beds { get; set; }
        public int Floor { get; set; }
        public List<Turist> Turists { get; set; }
        public List<string> furnitures { get; set; }
        public bool IsFree()
        {
            if (IsPublick)
            {
                return Turists.Capacity <= Beds;
            }
            else
            {
                return Turists.Capacity > 0;
            }
        }
        public Room(int number, bool publicRoom, int bedsCount)
        {

        }
    }
}
