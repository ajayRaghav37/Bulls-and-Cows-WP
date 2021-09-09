Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.Windows.Threading
Imports System.Threading.Tasks
Imports System.Windows.Controls.Primitives
Imports System.IO.IsolatedStorage

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()

        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape

        ' Sample code to localize the ApplicationBar
        'BuildLocalizedApplicationBar()

    End Sub

    ' Sample code for building a localized ApplicationBar
    'Private Sub BuildLocalizedApplicationBar()
    '    ' Set the page's ApplicationBar to a new instance of ApplicationBar.
    '    ApplicationBar = New ApplicationBar()

    '    ' Create a new button and set the text value to the localized string from AppResources.
    '    Dim appBarButton As New ApplicationBarIconButton(New Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative))
    '    appBarButton.Text = AppResources.AppBarButtonText
    '    ApplicationBar.Buttons.Add(appBarButton)

    '    ' Create a new menu item with the localized string from AppResources.
    '    Dim appBarMenuItem As New ApplicationBarMenuItem(AppResources.AppBarMenuItemText)
    '    ApplicationBar.MenuItems.Add(appBarMenuItem)
    'End Sub

    Dim SecretNumber As String
    Dim DisableAll As Boolean
    Dim AttemptNum As Byte = 1
    Dim TempNum As Integer
    Dim TempStr As String
    Dim Randomizer As New Random
    Dim MyMsgResult As Boolean
    Dim IntroNum As Integer = 2

    Private Sub MainPage_BackKeyPress(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.BackKeyPress
        'MessageBox.Show("P", "P", MessageBoxButton.OK)
        e.Cancel = True
        If grdInst.Visibility = System.Windows.Visibility.Visible Then
            Select Case IntroNum
                Case 2
                    grdInst.Visibility = System.Windows.Visibility.Collapsed
                Case 3
                    IntroNum = 1
                    btnGotIt_Click(sender, New RoutedEventArgs)
                Case 4
                    IntroNum = 2
                    btnGotIt_Click(sender, New RoutedEventArgs)
                Case 5
                    IntroNum = 3
                    btnGotIt_Click(sender, New RoutedEventArgs)
                Case 6
                    IntroNum = 4
                    btnGotIt_Click(sender, New RoutedEventArgs)
                Case 7
                    IntroNum = 5
                    btnGotIt_Click(sender, New RoutedEventArgs)
            End Select
        ElseIf MyMsgBox.Visibility = System.Windows.Visibility.Visible Then
            btnMsg2_Click(sender, New RoutedEventArgs)
        ElseIf cnvAnalyzer.Visibility = System.Windows.Visibility.Visible Then
            btnAnalyze_Click(sender, New RoutedEventArgs)
        ElseIf CurrentAttempt.Text <> "" And cnvKeys1.Opacity = 1 Then
            CurrentAttempt.Text = CurrentAttempt.Text.Substring(0, CurrentAttempt.Text.Length - 1)
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If IsolatedStorageSettings.ApplicationSettings.Contains("UsedBefore") Then
            grdInst.Visibility = System.Windows.Visibility.Collapsed
        Else
            IsolatedStorageSettings.ApplicationSettings.Add("UsedBefore", "1")
            IsolatedStorageSettings.ApplicationSettings.Save()
        End If
        SecretNumber = Randomizer.Next(9) + 1
        For JustNumber As Integer = 1 To 3
            Do
                TempNum = Randomizer.Next(10)
            Loop While SecretNumber.Contains(TempNum)
            SecretNumber = SecretNumber & TempNum
        Next
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As RoutedEventArgs) Handles btnCheck.Click
        If Not DisableAll Then
            If CurrentAttempt.Text.Length = 4 Then
                lblErrorLog.Text = ""
                Select Case AttemptNum
                    Case 1 : CheckBC(CurrentAttempt.Text, Attempt1, lblBulls1, lblCows1)
                    Case 2 : CheckBC(CurrentAttempt.Text, Attempt2, lblBulls2, lblCows2)
                    Case 3 : CheckBC(CurrentAttempt.Text, Attempt3, lblBulls3, lblCows3)
                    Case 4 : CheckBC(CurrentAttempt.Text, Attempt4, lblBulls4, lblCows4)
                    Case 5 : CheckBC(CurrentAttempt.Text, Attempt5, lblBulls5, lblCows5)
                    Case 6 : CheckBC(CurrentAttempt.Text, Attempt6, lblBulls6, lblCows6)
                    Case 7 : CheckBC(CurrentAttempt.Text, Attempt7, lblBulls7, lblCows7)
                End Select
                If LayoutRoot.ActualWidth > LayoutRoot.ActualHeight And AttemptNum > 5 Then
                    cnvGameArea.ScrollToVerticalOffset(cnvGameArea.ScrollableHeight)
                End If
            Else
                lblErrorLog.Text = "Number must contain 4 digits"
            End If
        End If
    End Sub

    Private Sub ProcessKeys(KeyNm As SByte)
        Select Case KeyNm
            Case 0 To 9
                If CurrentAttempt.Text.Length < 4 Then
                    lblErrorLog.Text = ""
                    If Not CurrentAttempt.Text.Contains(KeyNm) Then
                        CurrentAttempt.Text = CurrentAttempt.Text & KeyNm
                        lblErrorLog.Text = ""
                    Else
                        lblErrorLog.Text = "Cannot repeat digits in number"
                    End If
                Else
                    lblErrorLog.Text = "Number cannot exceed 9999"
                End If
            Case Else
                lblErrorLog.Text = ""
                CurrentAttempt.Text = ""
        End Select
    End Sub

    Private Sub BtnNum0_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum0.Click
        ProcessKeys(0)
    End Sub

    Private Sub BtnNum1_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum1.Click
        ProcessKeys(1)
    End Sub

    Private Sub BtnNum2_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum2.Click
        ProcessKeys(2)
    End Sub

    Private Sub BtnNum3_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum3.Click
        ProcessKeys(3)
    End Sub

    Private Sub BtnNum4_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum4.Click
        ProcessKeys(4)
    End Sub

    Private Sub BtnNum5_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum5.Click
        ProcessKeys(5)
    End Sub

    Private Sub BtnNum6_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum6.Click
        ProcessKeys(6)
    End Sub

    Private Sub BtnNum7_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum7.Click
        ProcessKeys(7)
    End Sub

    Private Sub BtnNum8_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum8.Click
        ProcessKeys(8)
    End Sub

    Private Sub BtnNum9_Click(sender As Object, e As RoutedEventArgs) Handles BtnNum9.Click
        ProcessKeys(9)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        ProcessKeys(-1)
    End Sub

    Private Sub CheckBC(Attempted As String, lblAttempt As TextBlock, lblBulls As TextBlock, lblCows As TextBlock)
        Dim MarginThick As Thickness = CurrentAttempt.Margin
        GetBnC(SecretNumber, Attempted, lblBulls.Text, lblCows.Text)
        If SecretNumber = Attempted Then
            lblErrorLog.Text = "All bulls discovered in " & AttemptNum & " attempts"
            ShowMsg("Well done!", "Launch new game?", "Sure", "No, Wait!")
        Else
            lblAttempt.Text = Attempted
            CurrentAttempt.Text = ""
            If AttemptNum = 7 Then
                lblErrorLog.Text = "Discovery failed. Secret number was " & SecretNumber
                ShowMsg("Game Over", "Launch new game?", "Sure", "No, Wait!")
            Else
                MarginThick.Top += 53
                CurrentAttempt.Margin = MarginThick
                AttemptNum += 1
            End If
        End If
    End Sub

    Private Function GetChkBox(BoxID As String) As CheckBox
        Select Case BoxID
            Case "01"
                GetChkBox = An01
            Case "11"
                GetChkBox = An11
            Case "21"
                GetChkBox = An21
            Case "31"
                GetChkBox = An31
            Case "41"
                GetChkBox = An41
            Case "51"
                GetChkBox = An51
            Case "61"
                GetChkBox = An61
            Case "71"
                GetChkBox = An71
            Case "81"
                GetChkBox = An81
            Case "91"
                GetChkBox = An91
            Case "02"
                GetChkBox = An02
            Case "12"
                GetChkBox = An12
            Case "22"
                GetChkBox = An22
            Case "32"
                GetChkBox = An32
            Case "42"
                GetChkBox = An42
            Case "52"
                GetChkBox = An52
            Case "62"
                GetChkBox = An62
            Case "72"
                GetChkBox = An72
            Case "82"
                GetChkBox = An82
            Case "92"
                GetChkBox = An92
            Case "03"
                GetChkBox = An03
            Case "13"
                GetChkBox = An13
            Case "23"
                GetChkBox = An23
            Case "33"
                GetChkBox = An33
            Case "43"
                GetChkBox = An43
            Case "53"
                GetChkBox = An53
            Case "63"
                GetChkBox = An63
            Case "73"
                GetChkBox = An73
            Case "83"
                GetChkBox = An83
            Case "93"
                GetChkBox = An93
            Case "04"
                GetChkBox = An04
            Case "14"
                GetChkBox = An14
            Case "24"
                GetChkBox = An24
            Case "34"
                GetChkBox = An34
            Case "44"
                GetChkBox = An44
            Case "54"
                GetChkBox = An54
            Case "64"
                GetChkBox = An64
            Case "74"
                GetChkBox = An74
            Case "84"
                GetChkBox = An84
            Case "94"
                GetChkBox = An94
            Case "05"
                GetChkBox = An05
            Case "15"
                GetChkBox = An15
            Case "25"
                GetChkBox = An25
            Case "35"
                GetChkBox = An35
            Case "45"
                GetChkBox = An45
            Case "55"
                GetChkBox = An55
            Case "65"
                GetChkBox = An65
            Case "75"
                GetChkBox = An75
            Case "85"
                GetChkBox = An85
            Case "95"
                GetChkBox = An95
            Case Else
                GetChkBox = New CheckBox
        End Select
    End Function

    Private Sub An01_Checked(sender As Object, e As RoutedEventArgs) Handles An01.Checked
        An01.IsChecked = False
    End Sub

    Private Sub ManipChks(RCName As String, ToChk As Boolean)
        Select Case RCName
            Case "A"
                btnAnA.IsChecked = ToChk
                For RowID As Integer = 0 To 9
                    GetChkBox(RowID & "1").IsChecked = ToChk
                Next
            Case "B"
                btnAnB.IsChecked = ToChk
                For RowID As Integer = 0 To 9
                    GetChkBox(RowID & "2").IsChecked = ToChk
                Next
            Case "C"
                btnAnC.IsChecked = ToChk
                For RowID As Integer = 0 To 9
                    GetChkBox(RowID & "3").IsChecked = ToChk
                Next
            Case "D"
                btnAnD.IsChecked = ToChk
                For RowID As Integer = 0 To 9
                    GetChkBox(RowID & "4").IsChecked = ToChk
                Next
            Case "S"
                btnAnS.IsChecked = ToChk
                For RowID As Integer = 0 To 9
                    GetChkBox(RowID & "5").IsChecked = ToChk
                Next
            Case Else
                For ColID As Integer = 1 To 5
                    GetChkBox(RCName & ColID).IsChecked = ToChk
                Next
        End Select
    End Sub

    Private Sub btnAn0_Click(sender As Object, e As RoutedEventArgs) Handles btnAn0.Click
        ManipChks("0", btnAn0.IsChecked)
    End Sub

    Private Sub btnAn1_Click(sender As Object, e As RoutedEventArgs) Handles btnAn1.Click
        ManipChks("1", btnAn1.IsChecked)
    End Sub

    Private Sub btnAn2_Click(sender As Object, e As RoutedEventArgs) Handles btnAn2.Click
        ManipChks("2", btnAn2.IsChecked)
    End Sub

    Private Sub btnAn3_Click(sender As Object, e As RoutedEventArgs) Handles btnAn3.Click
        ManipChks("3", btnAn3.IsChecked)
    End Sub

    Private Sub btnAn4_Click(sender As Object, e As RoutedEventArgs) Handles btnAn4.Click
        ManipChks("4", btnAn4.IsChecked)
    End Sub

    Private Sub btnAn5_Click(sender As Object, e As RoutedEventArgs) Handles btnAn5.Click
        ManipChks("5", btnAn5.IsChecked)
    End Sub

    Private Sub btnAn6_Click(sender As Object, e As RoutedEventArgs) Handles btnAn6.Click
        ManipChks("6", btnAn6.IsChecked)
    End Sub

    Private Sub btnAn7_Click(sender As Object, e As RoutedEventArgs) Handles btnAn7.Click
        ManipChks("7", btnAn7.IsChecked)
    End Sub

    Private Sub btnAn8_Click(sender As Object, e As RoutedEventArgs) Handles btnAn8.Click
        ManipChks("8", btnAn8.IsChecked)
    End Sub

    Private Sub btnAn9_Click(sender As Object, e As RoutedEventArgs) Handles btnAn9.Click
        ManipChks("9", btnAn9.IsChecked)
    End Sub

    Private Sub btnAnA_Click(sender As Object, e As RoutedEventArgs) Handles btnAnA.Click
        ManipChks("A", btnAnA.IsChecked)
    End Sub

    Private Sub btnAnB_Click(sender As Object, e As RoutedEventArgs) Handles btnAnB.Click
        ManipChks("B", btnAnB.IsChecked)
    End Sub

    Private Sub btnAnC_Click(sender As Object, e As RoutedEventArgs) Handles btnAnC.Click
        ManipChks("C", btnAnC.IsChecked)
    End Sub

    Private Sub btnAnD_Click(sender As Object, e As RoutedEventArgs) Handles btnAnD.Click
        ManipChks("D", btnAnD.IsChecked)
    End Sub

    Private Sub btnAnS_Click(sender As Object, e As RoutedEventArgs) Handles btnAnS.Click
        ManipChks("S", btnAnS.IsChecked)
    End Sub

    Private Sub ResetAll()
        Attempt1.Text = ""
        lblBulls1.Text = ""
        lblCows1.Text = ""
        Attempt2.Text = ""
        lblBulls2.Text = ""
        lblCows2.Text = ""
        Attempt3.Text = ""
        lblBulls3.Text = ""
        lblCows3.Text = ""
        Attempt4.Text = ""
        lblBulls4.Text = ""
        lblCows4.Text = ""
        Attempt5.Text = ""
        lblBulls5.Text = ""
        lblCows5.Text = ""
        Attempt6.Text = ""
        lblBulls6.Text = ""
        lblCows6.Text = ""
        Attempt7.Text = ""
        lblBulls7.Text = ""
        lblCows7.Text = ""
        AttemptNum = 1
        CurrentAttempt.Margin = Attempt1.Margin
        ManipChks("A", True)
        ManipChks("B", True)
        ManipChks("C", True)
        ManipChks("D", True)
        ManipChks("S", False)
        btnAn0.IsChecked = True
        btnAn1.IsChecked = True
        btnAn2.IsChecked = True
        btnAn3.IsChecked = True
        btnAn4.IsChecked = True
        btnAn5.IsChecked = True
        btnAn6.IsChecked = True
        btnAn7.IsChecked = True
        btnAn8.IsChecked = True
        btnAn9.IsChecked = True
        CurrentAttempt.Text = ""
        GetCode(SecretNumber)
        lblErrorLog.Text = ""
        cnvGameArea.ScrollToVerticalOffset(0)
    End Sub

    Private Sub btnAnalyze_Click(sender As Object, e As RoutedEventArgs) Handles btnAnalyze.Click
        If btnAnalyze.Content.ToString = "Analyze" Then
            cnvGameArea.Visibility = System.Windows.Visibility.Collapsed
            grdGameAttr.Visibility = System.Windows.Visibility.Collapsed
            cnvKeys1.Visibility = System.Windows.Visibility.Collapsed
            cnvKeys2.Visibility = System.Windows.Visibility.Collapsed
            cnvAnalyzer.Visibility = System.Windows.Visibility.Visible
            btnAnalyze.Content = "Return"
        Else
            cnvGameArea.Visibility = System.Windows.Visibility.Visible
            grdGameAttr.Visibility = System.Windows.Visibility.Visible
            If LayoutRoot.ActualWidth < LayoutRoot.ActualHeight Then
                cnvKeys1.Visibility = System.Windows.Visibility.Visible
            Else
                cnvKeys2.Visibility = System.Windows.Visibility.Visible
            End If
            cnvAnalyzer.Visibility = System.Windows.Visibility.Collapsed
            btnAnalyze.Content = "Analyze"
        End If
    End Sub

    Private Sub LayoutRoot_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles LayoutRoot.SizeChanged
        If LayoutRoot.ActualHeight > LayoutRoot.ActualWidth Then
            If btnAnalyze.Content.ToString = "Analyze" Then
                cnvKeys1.Visibility = System.Windows.Visibility.Visible
                cnvKeys2.Visibility = System.Windows.Visibility.Collapsed
            End If
            cnvGameArea.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled
            ScrAnal.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled
            grdIntro.Margin = New Thickness(0, 180, 0, 180)
        Else
            If btnAnalyze.Content.ToString = "Analyze" Then
                cnvKeys1.Visibility = System.Windows.Visibility.Collapsed
                cnvKeys2.Visibility = System.Windows.Visibility.Visible
            End If
            cnvGameArea.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            ScrAnal.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            grdIntro.Margin = New Thickness(0, 90, 0, 90)
        End If
    End Sub

    Private Sub ShowMsg(msgTitleText As String, msgContentText As String, Optional btn1Cap As String = "", Optional btn2Cap As String = "")
        btnMsg1.Content = btn1Cap
        btnMsg2.Content = btn2Cap
        MsgTitle.Text = msgTitleText
        MsgContent.Text = msgContentText
        MyMsgBox.Visibility = System.Windows.Visibility.Visible
    End Sub

    Private Sub btnMsg1_Click(sender As Object, e As RoutedEventArgs) Handles btnMsg1.Click
        ResetAll()
        MyMsgResult = True
        MyMsgBox.Visibility = System.Windows.Visibility.Collapsed
    End Sub

    Private Sub btnMsg2_Click(sender As Object, e As RoutedEventArgs) Handles btnMsg2.Click
        MyMsgResult = False
        MyMsgBox.Visibility = System.Windows.Visibility.Collapsed
        btnNew.Visibility = System.Windows.Visibility.Visible
        cnvKeys1.Opacity = 0.5
        cnvKeys1.IsHitTestVisible = False
        cnvKeys2.Opacity = 0.5
        cnvKeys2.IsHitTestVisible = False
    End Sub

    Private Sub btnNew_Click(sender As Object, e As RoutedEventArgs) Handles btnNew.Click
        ResetAll()
        btnNew.Visibility = System.Windows.Visibility.Collapsed
        cnvKeys1.Opacity = 1
        cnvKeys1.IsHitTestVisible = True
        cnvKeys2.Opacity = 1
        cnvKeys2.IsHitTestVisible = True
        If btnAnalyze.Content.ToString = "Return" Then
            btnAnalyze_Click(sender, e)
        End If
    End Sub

    Private Sub btnGotIt_Click(sender As Object, e As RoutedEventArgs) Handles btnGotIt.Click
        Content1.Visibility = System.Windows.Visibility.Collapsed
        Content2.Visibility = System.Windows.Visibility.Collapsed
        Content3.Visibility = System.Windows.Visibility.Collapsed
        Content4.Visibility = System.Windows.Visibility.Collapsed
        Content5.Visibility = System.Windows.Visibility.Collapsed
        Content6.Visibility = System.Windows.Visibility.Collapsed
        btnNewGen.Visibility = System.Windows.Visibility.Collapsed
        btnGotIt.Content = "Next"
        Select Case IntroNum
            Case 1
                Content1.Visibility = System.Windows.Visibility.Visible
                InstTitle.Text = "Introduction"
            Case 2
                Content2.Visibility = System.Windows.Visibility.Visible
                InstTitle.Text = "Rules"
            Case 3
                Content3.Visibility = System.Windows.Visibility.Visible
                InstTitle.Text = "Bulls"
            Case 4
                Content4.Visibility = System.Windows.Visibility.Visible
                InstTitle.Text = "Cows"
            Case 5
                Content5.Visibility = System.Windows.Visibility.Visible
                InstTitle.Text = "Illustration"
                btnNewGen.Visibility = System.Windows.Visibility.Visible
            Case 6
                Content6.Visibility = System.Windows.Visibility.Visible
                InstTitle.Text = "Analyzer"
                btnGotIt.Content = "Good to go!"
            Case 7
                grdInst.Visibility = System.Windows.Visibility.Collapsed
        End Select
        IntroNum += 1
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As RoutedEventArgs) Handles btnHelp.Click
        IntroNum = 1
        btnGotIt_Click(sender, e)
        grdInst.Visibility = System.Windows.Visibility.Visible
    End Sub

    Private Sub btnSkip_Click(sender As Object, e As RoutedEventArgs) Handles btnSkip.Click
        grdInst.Visibility = System.Windows.Visibility.Collapsed
    End Sub

    Private Sub btnNewGen_Click(sender As Object, e As RoutedEventArgs) Handles btnNewGen.Click
        GetCode(SampleCode.Text)
        GetCode(SampleAttempt.Text, True)
        GetBnC(SampleCode.Text, SampleAttempt.Text, SampleBulls.Text, SampleCows.Text)
    End Sub

    Private Sub GetCode(ByRef CodeTo As String, Optional ZeroAllowed As Boolean = False)
        If ZeroAllowed Then
            CodeTo = Randomizer.Next(10)
        Else
            CodeTo = Randomizer.Next(9) + 1
        End If
        For JustNumber As Integer = 1 To 3
            Do
                TempNum = Randomizer.Next(10)
            Loop While CodeTo.Contains(TempNum)
            CodeTo = CodeTo & TempNum
        Next
    End Sub

    Private Sub GetBnC(CodeNum As String, AttemptNum As String, ByRef NumBulls As String, ByRef NumCows As String)
        Dim NBulls As Byte
        Dim NCows As Byte
        NBulls = 0
        NCows = 0
        For TempNum As Byte = 0 To 3
            TempStr = AttemptNum.Substring(TempNum, 1)
            If TempStr = CodeNum.Substring(TempNum, 1) Then
                NBulls += 1
            ElseIf CodeNum.Contains(TempStr) Then
                NCows += 1
            End If
        Next
        NumBulls = NBulls.ToString
        NumCows = NCows.ToString
    End Sub
End Class