
namespace Engine.Interfaces
{
    public interface IActor
    {
        string Name { get; set; }
        int FirePower { get; set; }
        int Morale { get; set; }
        int Range { get; set; }
        int XP { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}