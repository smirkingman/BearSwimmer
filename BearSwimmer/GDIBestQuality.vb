Imports System.Drawing

Public Module GDIBestQuality_

    Public Sub GDIBestQuality(g As Graphics)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
    End Sub

End Module
