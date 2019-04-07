Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WebBrowser1.ScriptErrorsSuppressed = True 'webbroser'in sc hata vermesini engelledik

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            ProgressBar1.Increment(1) ''Progresbar'a value 1er 1 er armasını sağladık
            If ProgressBar1.Value = 1 Then
                WebBrowser1.Navigate(TextBox1.Text) 'browser'in url'sini arayüzümüze yönlendirdik.
            ElseIf ProgressBar1.Value = 10 Then
                WebBrowser1.Document.GetElementById("userName").SetAttribute("value", TextBox2.Text) 'login sayfasındaki username textine veriyi gönderdik.
                WebBrowser1.Document.GetElementById("pcPassword").SetAttribute("value", TextBox3.Text) 'login sayfasında parola verisini gönderdik
            ElseIf ProgressBar1.Value = 12 Then
                WebBrowser1.Document.GetElementById("loginBtn").InvokeMember("click") 'login sayfasındaki girişe tıkladık


            ElseIf ProgressBar1.Value = 30 Then

                For Each ds As HtmlElement In WebBrowser1.Document.GetElementsByTagName("a")
                    If ds.GetAttribute("classname") = "T  sel" Then
                        ds.InvokeMember("click")
                    End If
                Next

                End


            ElseIf ProgressBar1.Value = 40 Then
                For Each element As HtmlElement In WebBrowser1.Document.GetElementsByTagName("input")
                    If element.GetAttribute("value") = "Yeni Ekle" Then
                        element.InvokeMember("click")
                    End If
                Next

            ElseIf ProgressBar1.Value = 50 Then
                ' applyPort ipAddr interPort
                WebBrowser1.Document.GetElementById("applyPort").SetAttribute("value", TextBox6.Text)
                WebBrowser1.Document.GetElementById("ipAddr").SetAttribute("value", TextBox5.Text)
                WebBrowser1.Document.GetElementById("interPort").SetAttribute("value", TextBox4.Text)
            ElseIf ProgressBar1.Value = 60 Then
                WebBrowser1.Document.GetElementById("saveBtn").InvokeMember("click")

            End If

        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub a()
        Dim bilgi As HtmlElementCollection = WebBrowser1.Document.All
        For Each element As HtmlElement In bilgi
            If element.GetAttribute("id").Contains("note") Then 'yanlış giriş sonucunda çıkan uyarı id sini aldık 
                'kontrol ettik yanlış ise timer durucak progresbar valeu 0 lanıcak ki tekrardan başlayabilsin
                'ayrıca webbroser1de sayfayı yeniledik.
                Dim yanlışgiriş As String = element.InnerText
                If yanlışgiriş = "uyarı" Then
                    MsgBox("Kullanıcı adı veya parola yanlış")
                    Timer1.Stop()
                    ProgressBar1.Value = 0
                    WebBrowser1.Refresh()
                    MsgBox("Kullanıcı adı veya parola yanlış")
                Else
                    MsgBox("Kullanıcı adı veya parola yanlış")
                End If
            End If
        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Start()
    End Sub
End Class
