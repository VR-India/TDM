using UnityEngine;
using BNG;

/// <summary>
/// Manages haptic feedback for VR controllers.
/// </summary>
public class Haptics : MonoBehaviour
{
    /// <summary>
    /// The singleton instance of the Haptics class.
    /// </summary>
    public static Haptics Instance;

    /// <summary>
    /// The input bridge for VR controller interactions.
    /// </summary>
    public InputBridge input;

    /// <summary>
    /// The frequency of the haptic feedback vibration.
    /// </summary>
    public float VibrateFrequency = 0.3f;

    /// <summary>
    /// The amplitude of the haptic feedback vibration.
    /// </summary>
    public float VibrateAmplitude = 0.1f;

    /// <summary>
    /// The duration of the haptic feedback vibration.
    /// </summary>
    public float VibrateDuration = 0.1f;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Triggers haptic feedback with custom frequency, amplitude, and duration.
    /// </summary>
    /// <param name="touchingHand">The hand that triggers the haptic feedback.</param>
    /// <param name="frequency">The frequency of the haptic feedback vibration.</param>
    /// <param name="amplitude">The amplitude of the haptic feedback vibration.</param>
    /// <param name="duration">The duration of the haptic feedback vibration.</param>
    public void DoHaptics(ControllerHand touchingHand, float frequency, float amplitude, float duration)
    {
        if (input)
        {
            input.VibrateController(frequency, amplitude, duration, touchingHand);
        }
    }

    /// <summary>
    /// Triggers haptic feedback with default frequency, amplitude, and duration.
    /// </summary>
    /// <param name="touchingHand">The hand that triggers the haptic feedback.</param>
    public void DoHaptics(ControllerHand touchingHand)
    {
        DoHaptics(touchingHand, VibrateFrequency, VibrateAmplitude, VibrateDuration);
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        // Example: Trigger haptic feedback when the A button is pressed on the right controller
        if (InputBridge.Instance.AButtonDown)
        {
            DoHaptics(ControllerHand.Right);
        }
    }
}
