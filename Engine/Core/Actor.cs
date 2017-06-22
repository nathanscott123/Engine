using Engine.Systems;
using Engine.Interfaces;
using Engine.Core;

namespace Engine.core
{

    public class Actor : IActor
    {
        // IActor
        public string Name { get; set; }
        public int FirePower { get; set; }
        public int Morale { get; set; }
        public int Range { get; set; }
        public int XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        

    }
}