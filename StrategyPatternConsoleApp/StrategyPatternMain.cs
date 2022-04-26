using System;

namespace StrategyPatternConsoleApp;

class StrategyPatternMain
{
    static void Main(string[] args)
    {
        Car car = new();

        IMoveStrategy[] strategies =
        {
            new MoveSlowStrategy(), 
            new MoveMediumStrategy(), 
            new MoveFastStrategy()
        };

        car.Drive();
        foreach (var strategy in strategies)
        {
            car.SetMoveStrategy(strategy);
            car.Drive();
        }


    }
}
