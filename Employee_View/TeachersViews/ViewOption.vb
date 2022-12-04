Public Class ViewOption
    Private Sub btnViewEvalScores_Click(sender As Object, e As EventArgs) Handles btnViewEvalScores.Click
        Dim evalStatus As New EvalScoreView
        evalStatus.ShowDialog()

    End Sub


End Class