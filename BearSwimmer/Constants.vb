Imports System.Math
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units

Public Module Constants
    Public Const EPSILON As Double = 0.000000000001 ' 1e-12
    Public Const ToRadians As Double = PI / 180
    Public Const ToDegrees As Double = 180 / PI
    Public ReadOnly VECTOR2DZERO As New Vector2D(0, 0)
    Public ReadOnly POINT2DZERO As New Point2D(0, 0)
    Public ReadOnly ANGLEZERO As Angle = Angle.FromRadians(0)
End Module
