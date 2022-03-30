using Core.StorageSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileStorage : Storage
{
    public FileStorage(string fileName)
    {

    }

    protected override void LoadInternal()
    {
        throw new NotImplementedException();
    }

    protected override void LoadWithCallbackInternal(Action<GameData> callback = null)
    {
        throw new NotImplementedException();
    }

    protected override Coroutine LoadWithRoutineInternal(Action<GameData> callback = null)
    {
        throw new NotImplementedException();
    }

    protected override void SaveInternal()
    {
        throw new NotImplementedException();
    }

    protected override void SaveWithCallbackInternal(Action callback = null)
    {
        throw new NotImplementedException();
    }

    protected override Coroutine SaveWithRoutineInternal(Action callback = null)
    {
        throw new NotImplementedException();
    }
}
