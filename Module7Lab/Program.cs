using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}
public class Light
{
    public void On()
    {
        Console.WriteLine("Свет включен.");
    }

    public void Off()
    {
        Console.WriteLine("Свет выключен.");
    }
}

public class Television
{
    public void On()
    {
        Console.WriteLine("Телевизор включен.");
    }

    public void Off()
    {
        Console.WriteLine("Телевизор выключен.");
    }
}
public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}
public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}
public class TelevisionOnCommand : ICommand
{
    private Television _television;

    public TelevisionOnCommand(Television television)
    {
        _television = television;
    }

    public void Execute()
    {
        _television.On();
    }

    public void Undo()
    {
        _television.Off();
    }
}
public class TelevisionOffCommand : ICommand
{
    private Television _television;

    public TelevisionOffCommand(Television television)
    {
        _television = television;
    }

    public void Execute()
    {
        _television.Off();
    }

    public void Undo()
    {
        _television.On();
    }
}
public class RemoteControl
{
    private ICommand _onCommand;
    private ICommand _offCommand;

    public void SetCommands(ICommand onCommand, ICommand offCommand)
    {
        _onCommand = onCommand;
        _offCommand = offCommand;
    }

    public void PressOnButton()
    {
        _onCommand.Execute();
    }

    public void PressOffButton()
    {
        _offCommand.Execute();
    }

    public void PressUndoButton()
    {
        _onCommand.Undo();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создаем устройства
        Light livingRoomLight = new Light();
        Television tv = new Television();

        // Создаем команды для управления светом
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        // Создаем команды для управления телевизором
        ICommand tvOn = new TelevisionOnCommand(tv);
        ICommand tvOff = new TelevisionOffCommand(tv);

        // Создаем пульт и привязываем команды к кнопкам
        RemoteControl remote = new RemoteControl();

        // Управляем светом
        remote.SetCommands(lightOn, lightOff);
        Console.WriteLine("Управление светом:");
        remote.PressOnButton();
        remote.PressOffButton();
        remote.PressUndoButton();

        // Управляем телевизором
        remote.SetCommands(tvOn, tvOff);
        Console.WriteLine("\nУправление телевизором:");
        remote.PressOnButton();
        remote.PressOffButton();
        remote.PressUndoButton();

        Console.ReadLine();
    }
}
