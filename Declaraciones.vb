Imports System.Web
<Serializable()> Public Class Declaraciones

    Public UserID As String = ""        'UID
    Public UserName As String = ""      'UN
    Public role As String = ""
    Public ID As String            'NI
    Public L As Boolean
    Public User As Integer
    'input new register is false

    Public anadir As Boolean = False

    'Location of the database
    'Jose Computer
    Public Const Coneccion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Universidad\Concentracion\Web Programming with Databases\Clinica Veterinaria Inter v2\Clinica.mdf;Integrated Security=True;Connect Timeout=30"

    'Profesor Computer
    'Public Const Coneccion As String = "Password=12345678;Persist Security Info=True;User ID=sa;Initial Catalog=Clinica;Data Source=NODE33\SQLEXPRESS"
End Class
