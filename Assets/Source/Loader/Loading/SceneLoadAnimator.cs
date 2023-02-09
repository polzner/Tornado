using System;
using UnityEngine;

[Serializable]
public class SceneLoadAnimator
{
    [SerializeField] private ImageMover _imageMover1;
    [SerializeField] private ImageMover _imageMover2;
    
    public void OpenScene()
    {
        _imageMover1.MoveDefaulPosition();
        _imageMover2.MoveDefaulPosition();
    }

    public void CloseScene()
    {
        _imageMover1.Move();
        _imageMover2.Move();
    }
}
