using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternConsoleApp;

public class TheApplication
{
  public State State { get; set; }
  public Dictionary<string, State> States { get; set; }
     = new Dictionary<string, State>();

  public TheApplication()
  {
     States["Start"] = new StartState(this);
     States["Main"] = new MainScreenState(this);
     States["Goodbye"] = new GoodbyeScreenState(this);
     States["Hello"] = new HelloScreenState(this);
     States["Exit"] = new ExitState(this);
     State = States["Start"];
  }

  public void Run()
  {
     do
     {
        State.Execute();
     } while (State.Name != "Exit");
  }
}

public class State
{
  public string Name { get; set; }
  public TheApplication Application { get; set; }

  public State(TheApplication app)
  {
     Application = app;
  }

  public virtual void Execute()
  {
     Entry();
     Do();
     Exit();
  }

  protected virtual void Entry()
  {
     Console.WriteLine($"Entering state {Name}");
  }

  protected virtual void Do()
  {
  }

  protected virtual void Exit()
  {
     Console.WriteLine($"Exiting state {Name}");
  }

  protected virtual void TransitionTo(State state)
  {
     Application.State = state;
  }
}

public class StartState : State
{
  public StartState(TheApplication app) : base(app)
  {
     Name = "Start";
  }

  protected override void Do()
  {
     TransitionTo(Application.States["Main"]);
  }
}

public class ExitState : State
{
  public ExitState(TheApplication app) : base(app)
  {
     Name = "Exit";
  }
}

public class MainScreenState : State
{
  public MainScreenState(TheApplication app) : base(app)
  {
     Name = "Main Screen";
  }
  protected override void Do()
  {
     string option;
     Console.WriteLine("1 - Hello");
     Console.WriteLine("X - Exit");
     Console.Write("Choose an option: ");
     option = Console.ReadLine();
     if(option == "1")
     {
        TransitionTo(Application.States["Hello"]);
     }
     else if (option == "X")
     {
        TransitionTo(Application.States["Goodbye"]);
     }
  }
}

public class HelloScreenState : State
{
  public HelloScreenState(TheApplication app) : base(app)
  {
     Name = "Hello Screen";
  }

  protected override void Do()
  {
     Console.WriteLine("Hello");
     TransitionTo(Application.States["Main"]);
  }
}

public class GoodbyeScreenState : State
{
  public GoodbyeScreenState(TheApplication app) : base(app)
  {
     Name = "Goodbye Screen";
  }

  protected override void Do()
  {
     Console.WriteLine("Goodbye");
     TransitionTo(Application.States["Exit"]);
  }
}

