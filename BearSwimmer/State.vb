Imports System.Math
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units
Public Structure State ' Current state of a participant
    Public Sub New(name As String, location As Point2D, speed As Double, angle As Angle)
        _Name = name
        _Location = location
        _Speed = speed
        _Angle = angle
        _Clockwise = angle.Degrees <= 180
    End Sub
    Public Sub Move(amount As Vector2D)
        Dim amountangle As Angle = amount.GetAngle
        Dim before As Vector2D = Location.ToVector2D
        Dim beforeangle As Angle = before.GetAngle
        Dim after As Vector2D = before + amount
        Dim afterangle As Angle = after.GetAngle
        Dim rotated As Angle
        If Moved.Length <> 0 Then ' first time, no previous angle
            rotated = Rotation(before, after)
        End If
        _Clockwise = rotated.Radians >= 0
        _Location += amount
        If Double.IsNaN(_Location.X) Then
            Throw New Exception("Location IsNaN")
        End If
        _Turned += Angle.FromRadians(Abs(rotated.Radians))
        _Moved = amount
        _Angle = amountangle
        _Travel += amount.Length
    End Sub
    Public ReadOnly Property Angle As Angle ' travel
    Public ReadOnly Property Clockwise As Boolean
    Public ReadOnly Property Location As Point2D
    Public ReadOnly Property Moved As Vector2D
    Public ReadOnly Property Name As String
    Public ReadOnly Property Speed As Double
    Public ReadOnly Property Turned As Angle
    Public ReadOnly Property Travel As Double
    Public Overrides Function ToString() As String
        Dim cw As String = If(Clockwise, "CW", "CCW")
        Return $"{Name} {cw} at {Location.X:0.000},{Location.Y:0.000} {Angle.Degrees:0.0}° Moved {Moved.X:0.000},{Moved.Y:0.000} Turned {Turned.Degrees:0.0}°"
    End Function
End Structure
