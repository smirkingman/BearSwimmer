Imports System.Math
Imports System.Runtime.CompilerServices
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units
Module Extensions
    <Extension>
    Function Rotation(v As Vector2D, w As Vector2D) As Angle
        Dim a As Angle = v.SignedAngleTo(w, False, True)
        If a.Radians < -PI Then
            a += Angle.FromRadians(2 * PI)
        End If
        Return a
    End Function
    <Extension>
    Function GetAngle(v As Vector2D) As Angle
        Dim result As Double = Atan2(v.Y, v.X)
        result = (result + 2 * PI) Mod 2 * PI
        Return Angle.FromRadians(result)
    End Function
    <Extension>
    Function ToPoint2D(v As Vector2D) As Point2D
        Return New Point2D(v.X, v.Y)
    End Function
    <Extension>
    Function Normalise(a As Angle) As Angle
        Return Angle.FromRadians((a.Radians + 2 * PI) Mod 2 * PI)
    End Function
End Module
