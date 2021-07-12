Public Structure AdvanceArgs
    Public ReadOnly Property dT As Double
    Public Property Cancelled As Boolean
    Public Sub New(dt As Double)
        _dT = dt
        _Cancelled = False
    End Sub
End Structure