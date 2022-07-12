Form1
Imports System.Data.OleDb
Public Class Form1
 Dim con As New OleDbConnection
Private Sub Button2_Click(sender As Object, e As EventArgs) Handles
Button2.Click
 con.ConnectionString = 
"Provider=Microsoft.ACE.OLEDB.12.0;Data 
Source=C:\Users\Lenovo\Documents\Visual Studio 
2012\Projects\Restaurant\Restaurant\Database4.accdb"
 Try
 con.Open()
 Dim cmd As New OleDbCommand("select count(*) from Admin 
where [Username]='" & TextBox1.Text & " ' and [Password]='" & 
TextBox2.Text & " ' ", con)
 cmd.Parameters.AddWithValue("@1", 
OleDbType.VarChar).Value = TextBox1.Text
 cmd.Parameters.AddWithValue("@2", 
OleDbType.VarChar).Value = TextBox2.Text
 Dim count = Convert.ToInt32(cmd.ExecuteScalar())
 If (count > 0) Then
 Me.Hide()
 Home.Show()
 Else
 MsgBox(" Invalid Username or password")
 End If
 Catch ex As Exception
 Finally
 con.Close()
 End Try
 End Sub
 Private Sub Button1_Click(sender As Object, e As EventArgs) 
Handles Button1.Click
 Application.Exit()
 End Sub
 
End Class
Home
Public Class Home 
 Private Sub btnstock_Click(sender As Object, e As EventArgs) 
Handles btnstock.Click
 Me.Hide()
 Stocks.Show()
 End Sub
 Private Sub btnedit_Click(sender As Object, e As EventArgs) 
Handles btnedit.Click
 Me.Hide()
 Stocksedit.Show()
 End Sub
 Private Sub btnlogout_Click(sender As Object, e As EventArgs) 
Handles btnlogout.Click
 Me.Hide()
 Form1.Show()
 End Sub
 Private Sub Button1_Click_1(sender As Object, e As EventArgs) 
Handles Button1.Click
 Application.Exit()
 End Sub
 
 
 Private Sub Button2_Click(sender As Object, e As EventArgs) 
Handles Button2.Click
 Me.Hide()
 Delstock.Show()
 End Sub
 Private Sub Home_Load(sender As Object, e As EventArgs) Handles
MyBase.Load
 End Sub
End Class
SHOWSTOCKS
Public Class Stocks
 Private Sub Button1_Click(sender As Object, e As EventArgs) 
Handles Button1.Click
 Me.Hide()
 Home.Show()
 End Sub
 Private Sub Button2_Click(sender As Object, e As EventArgs) 
Handles Button2.Click
 Application.Exit()
 End Sub
 Private Sub Stocks_Load(sender As Object, e As EventArgs) 
Handles MyBase.Load
 'TODO: This line of code loads data into the 
'Database4DataSet.Stocks' table. You can move, or remove it, as 
needed.
 Me.StocksTableAdapter.Fill(Me.Database4DataSet.Stocks)
 End Sub
 
 
 
 
End Class
ADDSTOCKS
Imports System.Data.OleDb
Public Class Stocksedit
 Dim provider As String
 Dim datafile As String
 Dim connstring As String
 Dim conn As New OleDbConnection
 
 Private Sub Button4_Click(sender As Object, e As EventArgs) 
Handles Button4.Click
 Me.Hide()
 Home.Show()
 End Sub
 Private Sub Button5_Click(sender As Object, e As EventArgs) 
Handles Button5.Click
 Application.Exit()
 End Sub
 Private Sub Button3_Click(sender As Object, e As EventArgs) 
Handles Button3.Click
 provider = "Provider= Microsoft.ACE.OLEDB.12.0; Data 
source="
 datafile = "C:\Users\Lenovo\Documents\Visual Studio 
2012\Projects\Restaurant\Restaurant\Database4.accdb"
 connstring = provider & datafile
 conn.ConnectionString = connstring
 conn.Open()
 Dim str As String
 str = "Insert into 
Stocks([ID],[Name],[Quantity],[Price],[Total price]) 
values(?,?,?,?,?)"
 Dim cmd As OleDbCommand = New OleDbCommand(str, conn)
 cmd.Parameters.Add(New OleDbParameter("ID", 
CType(TextBox1.Text, String)))
 cmd.Parameters.Add(New OleDbParameter("Name", 
CType(TextBox2.Text, String)))
 cmd.Parameters.Add(New OleDbParameter("Quantity", 
CType(TextBox3.Text, String)))
 cmd.Parameters.Add(New OleDbParameter("Price", 
CType(TextBox4.Text, String)))
 cmd.Parameters.Add(New OleDbParameter("Total price", 
CType(TextBox5.Text, String)))
 Try
 cmd.ExecuteNonQuery()
 cmd.Dispose()
 conn.Close()
 TextBox1.Clear()
 TextBox2.Clear()
 TextBox3.Clear()
 TextBox4.Clear()
 TextBox5.Clear()
 Catch ex As Exception
 MsgBox(ex.Message)
 End Try
 End Sub
 Private Sub Button2_Click(sender As Object, e As EventArgs) 
Handles Button2.Click
 TextBox1.Clear()
 TextBox2.Clear()
 TextBox3.Clear()
 TextBox4.Clear()
 TextBox5.Clear()
 End Sub
 Private Sub Stocksedit_Load(sender As Object, e As EventArgs) 
Handles MyBase.Load
 End Sub
End Class
REMOVESTOCKS
Imports System.Data.OleDb
Public Class Delstock
 Dim provider As String
 Dim datafile As String
 Dim connstring As String
 Dim conn As New OleDbConnection
 Private Sub Button4_Click(sender As Object, e As EventArgs) 
Handles Button4.Click
 Me.Hide()
 Home.Show()
 End Sub
 Private Sub Button5_Click(sender As Object, e As EventArgs) 
Handles Button5.Click
 Application.Exit()
 End Sub
 Private Sub Button7_Click(sender As Object, e As EventArgs) 
Handles Button7.Click
 provider = "Provider= Microsoft.ACE.OLEDB.12.0; Data 
source="
 datafile = "C:\Users\Lenovo\Documents\Visual Studio 
2012\Projects\Restaurant\Restaurant\Database4.accdb"
 connstring = provider & datafile
 conn.ConnectionString = connstring
 conn.Open()
 Dim str As String
 str = "Delete from [Stocks] where [ID]=" & TextBox1.Text & 
""
 Dim cmd As OleDbCommand = New OleDbCommand(str, conn)
 
 Try
 cmd.ExecuteNonQuery()
 cmd.Dispose()
 conn.Close()
 TextBox1.Clear()
 
 Catch ex As Exception
 MsgBox(ex.Message)
 End Try
 End Sub
End Class
