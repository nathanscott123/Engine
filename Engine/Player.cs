using Engine.core;
using Engine.Systems;
namespace Engine
{
    public class Player : Actor
    {
        public Player()
        {
            Name = "Squad 1";
            X = 10;
            Y = 10;
            FirePower = 7;
            Morale = 6;
            Range = 4;
            XP = 100;
        }
        public void OutPutPlayerValuesToDebugger()
        {
            Debugger.Print("NAME:  " + Name);
            Debugger.Print("X:  " + X);
            Debugger.Print("Y:  " + Y);
            Debugger.Print("FIREPOWER:  " + FirePower);
            Debugger.Print("MORALE:  " + Morale);
            Debugger.Print("RANGE:  " + Range);
            Debugger.Print("XP:  " + XP);

        }
    }
}