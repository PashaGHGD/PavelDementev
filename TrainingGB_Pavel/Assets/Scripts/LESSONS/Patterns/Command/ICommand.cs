using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand {

    bool Succeeded { get; }
    bool Execute(Transform box);
    void Undo(Transform box);
}
internal sealed class MoveForward : ICommand {
    private readonly float _moveDistance;
    public bool Succeeded { get; private set; }
    public MoveForward(float moveDistance) {
        _moveDistance = moveDistance;
    }
    public bool Execute(Transform box) {
        box.Translate(box.forward * _moveDistance);
        Succeeded = true;
        return Succeeded;
    }
    public void Undo(Transform box) {
        box.Translate(-box.forward * _moveDistance);
    }
}
internal sealed class MoveReverse : ICommand {
    private readonly float _moveDistance;
    public bool Succeeded { get; private set; }
    public MoveReverse(float moveDistance) {
        _moveDistance = moveDistance;
    }
    public bool Execute(Transform box) {
        box.Translate(-box.forward * _moveDistance);
        Succeeded = true;
        return Succeeded;
    }
    public void Undo(Transform box) {
        box.Translate(box.forward * _moveDistance);
    }
}
internal sealed class MoveLeft : ICommand {
    private readonly float _moveDistance;
    public bool Succeeded { get; private set; }
    public MoveLeft(float moveDistance) {
        _moveDistance = moveDistance;
    }
    public bool Execute(Transform box) {
        box.Translate(-box.right * _moveDistance);
        Succeeded = true;
        return Succeeded;
    }
    public void Undo(Transform box) {
        box.Translate(box.right * _moveDistance);
    }
}
internal sealed class MoveRight : ICommand {
    private readonly float _moveDistance;
    public bool Succeeded { get; private set; }
    public MoveRight(float moveDistance) {
        _moveDistance = moveDistance;
    }
    public bool Execute(Transform box) {
        box.Translate(box.right * _moveDistance);
        Succeeded = true;
        return Succeeded;
    }
    public void Undo(Transform box) {
        box.Translate(-box.right * _moveDistance);
    }
}

internal sealed class UndoCommand : ICommand {//отмена команды

    private readonly List<ICommand> _commands;
    public bool Succeeded { get; private set; }
    public UndoCommand(List<ICommand> commands) {
        _commands = commands;
    }
    public bool Execute(Transform box) {
        if (_commands.Count > 0) {
            ICommand latestCommand = _commands[_commands.Count - 1];
            if (latestCommand.Succeeded) {
                latestCommand.Undo(box);
                _commands.RemoveAt(_commands.Count - 1);
                Succeeded = true;
            }
        }
        Succeeded = false;
        return Succeeded;
    }
    public void Undo(Transform box) {
    }
}
internal sealed class DoNothing : ICommand {
    public bool Succeeded { get; private set; }
    public bool Execute(Transform box) {
        Succeeded = true;
        return Succeeded;
    }
    public void Undo(Transform box) {
    }
}

