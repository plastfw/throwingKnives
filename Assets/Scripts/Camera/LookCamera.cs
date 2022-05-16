using UnityEngine;
using Cinemachine;

[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")]
public class LookCamera : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]
    [SerializeField] private float _xPosition;
    [SerializeField] private float _yPosition;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase camera,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var position = state.RawPosition;
            position.x = _xPosition;
            position.y = _yPosition;
            state.RawPosition = position;
        }
    }
}