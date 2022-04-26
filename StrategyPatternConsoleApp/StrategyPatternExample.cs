using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternConsoleApp;

public class Car
{
    private IMoveStrategy _moveStrategy;

    public Car()
    {
        _moveStrategy = new NotMovingStrategy();
    }

    public void SetMoveStrategy(IMoveStrategy moveStrategy)
    {
        _moveStrategy = moveStrategy;
    }

    public void Drive()
    {
        _moveStrategy.Move();
    }
}
public interface IMoveStrategy
{
    void Move();
}
public class NotMovingStrategy : IMoveStrategy
{
    public void Move()
    {
        Console.WriteLine("Not moving");
    }
}
public class MoveFastStrategy : IMoveStrategy
{
    public void Move()
    {
        Console.WriteLine("Moving @ 100 mph");
    }
}
public class MoveMediumStrategy : IMoveStrategy
{
    public void Move()
    {
        Console.WriteLine("Moving @ 30 mph");
    }
}
public class MoveSlowStrategy : IMoveStrategy
{
    public void Move()
    {
        Console.WriteLine("Moving @ 5 mph");
    }
}

